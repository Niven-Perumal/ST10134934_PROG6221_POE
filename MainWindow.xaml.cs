using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10134934_PROG6221_PartThree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<Instructions> Instructions { get; set; }
        public ObservableCollection<Recipe> Recipes { get; set; }

        private Recipe originalRecipe;

        private CaloriesAmount caloriesAmount;

        public MainWindow()
        {
            InitializeComponent();
            Ingredients = new ObservableCollection<Ingredient>();
            Instructions = new ObservableCollection<Instructions>();
            IngredientsItemsControl.ItemsSource = Ingredients;
            InstructionsItemsControl.ItemsSource = Instructions;

            Recipes = new ObservableCollection<Recipe>();
            AllRecipesListBox.ItemsSource = Recipes;

            caloriesAmount = new CaloriesAmount(300, 0); // Set calorie limit to 300
            caloriesAmount.CaloriesExceeded += CaloriesAmount_CaloriesExceeded;

        }

        //Message if calorie amount goes over 300
        private void CaloriesAmount_CaloriesExceeded(object sender, EventArgs e)
        {
            MessageBox.Show("Total calories exceed 300!", "Calorie Limit Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        //Method to sort all recipe alphabetically (All Recipe Tab)
        private void SortRecipesAlphabetically()
        {
            var sortedRecipes = new ObservableCollection<Recipe>(Recipes.OrderBy(r => r.RecipeName));
            Recipes.Clear();
            foreach (var recipe in sortedRecipes)
            {
                Recipes.Add(recipe);
            }
        }


        //Method to clear form/values/inputs/textboxs after recipe is added (Add Recipe Tab)
        private void ClearForm()
        {
            RecipeNameTextBox.Clear();
            Ingredients.Clear();
            Instructions.Clear();
        }

        //Button click to add recipe (Add Recipe Tab)
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var newRecipe = new Recipe
            {
                RecipeName = RecipeNameTextBox.Text,
                Ingredients = new ObservableCollection<Ingredient>(Ingredients),
                Instructions = new ObservableCollection<Instructions>(Instructions)
            };

            // Calculate total calories of the new recipe
            double totalCalories = 0;
            foreach (var ingredient in newRecipe.Ingredients)
            {
                if (double.TryParse(ingredient.IngCalorieCount, out double calorieCount) && double.TryParse(ingredient.IngQuantity, out double ingQuan))
                {
                    totalCalories += calorieCount;
                }
                else
                {
                    MessageBox.Show($"Invalid quantity or calorie count format for ingredient: {ingredient.IngName}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Exit method or handle appropriately
                }
            }

            // Update the CaloriesAmount instance with the new total calories
            caloriesAmount.Credit(totalCalories);

            // Add the new recipe to the Recipes collection
            Recipes.Add(newRecipe);

            // Additional operations (sorting, clearing form, etc.)
            SortRecipesAlphabetically();
            ClearForm();
        }




        //Button click to search for recipe (View Recipe Tab)
        private void SrcBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = SearchRecipeTextBox.Text.Trim();
            var foundRecipe = Recipes.FirstOrDefault(r => r.RecipeName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));

            if (foundRecipe != null)
            {
                RecipeDetailsTextBox.Text = $"Recipe Name: {foundRecipe.RecipeName}\n\n";
                double totalCalories = 0;

                RecipeDetailsTextBox.AppendText("Ingredients:\n");
                RecipeDetailsTextBox.AppendText($"\tQuantity:\t\t  Name: \t\t Calories: \t\t Food Group:\n");

                int ingredientCounter = 1;
                foreach (var ingredient in foundRecipe.Ingredients)
                {
                    RecipeDetailsTextBox.AppendText($"{ingredientCounter}:\t {ingredient.IngQuantity} {ingredient.IngUnit} \t\t {ingredient.IngName} \t\t {ingredient.IngCalorieCount} \t\t {ingredient.IngFoodGroup}\n");
                    double totCal = double.Parse(ingredient.IngCalorieCount);
                    totalCalories += totCal;
                    ingredientCounter++;
                }

                RecipeDetailsTextBox.AppendText($"\nTotal Calories: {totalCalories}\n");

                RecipeDetailsTextBox.AppendText("\nInstructions:\n");
                int instructionCounter = 1;
                foreach (var instruction in foundRecipe.Instructions)
                {
                    RecipeDetailsTextBox.AppendText($"Step {instructionCounter}:\t {instruction.RecipeInstructions}\n");
                    instructionCounter++;
                }
            }
            else
            {
                RecipeDetailsTextBox.Text = "Recipe not found.";
            }

        }





        //Button click to view recipe (Scale Recipe Tab)
        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = ScaleRecipeTextBox.Text.Trim();
            var foundRecipe = Recipes.FirstOrDefault(r => r.RecipeName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));

            if (foundRecipe != null)
            {
                ScaledRecipeTextBox.Text = $"Recipe Name: {foundRecipe.RecipeName}\n\n";
                double totalCalories = 0;

                ScaledRecipeTextBox.AppendText("Ingredients:\n");
                ScaledRecipeTextBox.AppendText($"\tQuantity:\t\t  Name: \t\t Calories: \t\t Food Group:\n");

                int ingredientCounter = 1;
                foreach (var ingredient in foundRecipe.Ingredients)
                {
                    ScaledRecipeTextBox.AppendText($"{ingredientCounter}:\t {ingredient.IngQuantity} {ingredient.IngUnit} \t\t {ingredient.IngName} \t\t {ingredient.IngCalorieCount} \t\t {ingredient.IngFoodGroup}\n");
                    double totCal = double.Parse(ingredient.IngCalorieCount);
                    totalCalories += totCal;
                    ingredientCounter++;
                }

                ScaledRecipeTextBox.AppendText($"\nTotal Calories: {totalCalories}\n");

                ScaledRecipeTextBox.AppendText("\nInstructions:\n");
                int instructionCounter = 1;
                foreach (var instruction in foundRecipe.Instructions)
                {
                    ScaledRecipeTextBox.AppendText($"Step {instructionCounter}:\t {instruction.RecipeInstructions}\n");
                    instructionCounter++;
                }
            }
            else
            {
                ScaledRecipeTextBox.Text = "Recipe not found.";
            }
        }


        //Button click to scale recipe by selected factor (Scale Recipe Tab)
        private void ScaleBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = ScaleRecipeTextBox.Text.Trim();
            if (double.TryParse((ScalingFactorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(), out double scalingFactor))
            {
                var foundRecipe = Recipes.FirstOrDefault(r => r.RecipeName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));

                if (foundRecipe != null && !foundRecipe.IsScaled)
                {
                    if (originalRecipe == null)
                    {
                        originalRecipe = foundRecipe.DeepClone(); // Assuming DeepClone is a method that creates a deep copy of the recipe
                    }

                    ScaledRecipeTextBox.Text = $"Recipe Name: {foundRecipe.RecipeName} (Scaled by {scalingFactor})\n\n";
                    ScaledRecipeTextBox.AppendText("Ingredients:\n");

                    foreach (var ingredient in foundRecipe.Ingredients)
                    {
                        if (double.TryParse(ingredient.IngQuantity, out double originalQuantity) &&
                            double.TryParse(ingredient.IngCalorieCount, out double originalCalories))
                        {
                            double scaledQuantity = originalQuantity * scalingFactor;
                            double scaledCalories = originalCalories * scalingFactor;
                            ingredient.IngQuantity = scaledQuantity.ToString();
                            ingredient.IngCalorieCount = scaledCalories.ToString("F2"); // Formatting to 2 decimal places
                        }
                        ScaledRecipeTextBox.AppendText($"{ingredient.IngQuantity} {ingredient.IngUnit} {ingredient.IngName} ({ingredient.IngCalorieCount} calories)\n");
                    }

                    ScaledRecipeTextBox.AppendText("\nInstructions:\n");
                    foreach (var instruction in foundRecipe.Instructions)
                    {
                        ScaledRecipeTextBox.AppendText($"{instruction.RecipeInstructions}\n");
                    }

                    AllRecipesListBox.Items.Refresh();
                    foundRecipe.IsScaled = true;
                }
                else if (foundRecipe != null)
                {
                    ScaledRecipeTextBox.Text = "Recipe has already been scaled. Please reset it before scaling again.";
                }
                else
                {
                    ScaledRecipeTextBox.Text = "Recipe not found.";
                }
            }
            else
            {
                ScaledRecipeTextBox.Text = "Invalid scaling factor.";
            }
        }

        //Button click to reset scaled recipe (Scale Recipe Tab)
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = ScaleRecipeTextBox.Text.Trim();
            var foundRecipe = Recipes.FirstOrDefault(r => r.RecipeName.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));

            if (foundRecipe != null && originalRecipe != null)
            {
                // Deep copy the original recipe values back to the found recipe
                foundRecipe.Ingredients = new ObservableCollection<Ingredient>(originalRecipe.Ingredients.Select(i => new Ingredient
                {
                    IngQuantity = i.IngQuantity,
                    IngUnit = i.IngUnit,
                    IngName = i.IngName,
                    IngCalorieCount = i.IngCalorieCount,
                    IngFoodGroup = i.IngFoodGroup
                }));

                foundRecipe.Instructions = new ObservableCollection<Instructions>(originalRecipe.Instructions.Select(ins => new Instructions
                {
                    RecipeInstructions = ins.RecipeInstructions
                }));

                // Update the text in the ScaledRecipeTextBox to display the original recipe
                ScaledRecipeTextBox.Text = $"Recipe Name: {foundRecipe.RecipeName}\n\n";
                double totalCalories = 0;

                ScaledRecipeTextBox.AppendText("Ingredients:\n");
                ScaledRecipeTextBox.AppendText($"\tQuantity:\t\t  Name: \t\t Calories: \t\t Food Group:\n");

                int ingredientCounter = 1;
                foreach (var ingredient in foundRecipe.Ingredients)
                {
                    ScaledRecipeTextBox.AppendText($"{ingredientCounter}:\t {ingredient.IngQuantity} {ingredient.IngUnit} \t\t {ingredient.IngName} \t\t {ingredient.IngCalorieCount} \t\t {ingredient.IngFoodGroup}\n");
                    double totCal = double.Parse(ingredient.IngCalorieCount);
                    totalCalories += totCal;
                    ingredientCounter++;
                }

                ScaledRecipeTextBox.AppendText($"\nTotal Calories: {totalCalories}\n");

                ScaledRecipeTextBox.AppendText("\nInstructions:\n");
                int instructionCounter = 1;
                foreach (var instruction in foundRecipe.Instructions)
                {
                    ScaledRecipeTextBox.AppendText($"Step {instructionCounter}:\t {instruction.RecipeInstructions}\n");
                    instructionCounter++;
                }

                // Update the other tabs by refreshing the binding
                AllRecipesListBox.Items.Refresh();

                // Reset the scaled state
                foundRecipe.IsScaled = false;

                // Enable the Scale button and ComboBox for scaling factor
                ScaleBtn.IsEnabled = true;
                ScalingFactorComboBox.IsEnabled = true;
            }
            else
            {
                ScaledRecipeTextBox.Text = "Recipe not found or original recipe data missing.";
            }
        }






        //Method to filter recipes by values
        private void FilterRecipes(string ingredientNameFilter, string foodGroupFilter, double maxCaloriesFilter)
        {
            var filteredRecipes = new ObservableCollection<Recipe>();

            foreach (var recipe in Recipes)
            {
                if (recipe.MatchesFilter(ingredientNameFilter, foodGroupFilter, maxCaloriesFilter))
                {
                    filteredRecipes.Add(recipe);
                }
            }

            AllRecipesListBox.ItemsSource = filteredRecipes; // Update the ListBox with filtered recipes
        }

        //Button click to filter all recipe by selected values (All Recipes Tab)
        private void FilterBtn_Click(object sender, RoutedEventArgs e)
        {
            string ingredientNameFilter = FilterIngredientTextBox.Text.Trim();
            string foodGroupFilter = (FilterFoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            double maxCaloriesFilter = 0;

            if (double.TryParse(FilterMaxCaloriesTextBox.Text, out double maxCalories))
            {
                maxCaloriesFilter = maxCalories;
            }

            FilterRecipes(ingredientNameFilter, foodGroupFilter, maxCaloriesFilter);
        }

        //Button click to reset all filters input by user (All Recipes Tab)
        private void ResetFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            // Clear filter inputs and reset ListBox
            FilterIngredientTextBox.Clear();
            FilterFoodGroupComboBox.SelectedIndex = -1;
            FilterMaxCaloriesTextBox.Clear();
            AllRecipesListBox.ItemsSource = Recipes; // Reset to original full list
        }



        //Button click to delete a recipe selected by user (Delete Recipe Tab)
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string recipeNameToDelete = DeleteRecipeTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(recipeNameToDelete))
            {
                Recipe recipeToDelete = Recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeNameToDelete, StringComparison.OrdinalIgnoreCase));

                if (recipeToDelete != null)
                {
                    // Prompt confirmation from the user
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete recipe '{recipeNameToDelete}'?",
                                                              "Confirm Delete",
                                                              MessageBoxButton.YesNo,
                                                              MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        Recipes.Remove(recipeToDelete);
                        ClearForm(); // Optionally clear the form or any associated UI elements
                        MessageBox.Show($"Recipe '{recipeNameToDelete}' deleted successfully.", "Recipe Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    // If user selects No, do nothing
                }
                else
                {
                    MessageBox.Show($"Recipe '{recipeNameToDelete}' not found.", "Recipe Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a recipe name to delete.", "Missing Recipe Name", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        //Button click to add more ingredients to recipe (Add Recipe Tab)
        private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            Ingredients.Add(new Ingredient());
        }

        //Button click to add more instructions to recipe (Add Recipe Tab)
        private void AddInstructionBtn_Click(object sender, RoutedEventArgs e)
        {
            Instructions.Add(new Instructions());
        }






    }
}




//Code attribution for styling WPF https://www.tutorialspoint.com/wpf/wpf_styles.htm
//Code attribution for observable collection https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-8.0
//Code attribution for delegrate https://www.geeksforgeeks.org/c-sharp-delegates/
//Code attribution for deep clone / copy https://code-maze.com/csharp-deep-copy-of-object/