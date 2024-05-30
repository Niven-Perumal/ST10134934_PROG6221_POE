using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10134934_PROG6221_PartOne
{
    public class Recipe
    {

        //This is a method to input a recipe to be stored
        public void addRecipe(string recipeName, string ingName, double ingQuan, string unitMea, int userIngAmt, int ingNum, List<string> recipeNameList, List<string> ingNameList, List<double> ingQuanList, List<string> ingUnitList, List<double> ingCalList, List<string> ingFoodGroupList, double ingCal)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Add Recipe selected");
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Enter name of recipe");
            recipeName = Console.ReadLine();

            Console.WriteLine("How many Ingredients are in your recipe?");
            while (!int.TryParse(Console.ReadLine(), out userIngAmt) || userIngAmt <= 0) //displays error message if invaild input is entered
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number of ingredients.");
                Console.ResetColor();
            }


            for (ingNum = 0; ingNum < userIngAmt; ingNum++) //counts number of ingredients input by user
            {
                int sum = ingNum + 1;

                Console.WriteLine("Enter Ingredient" + " " + sum + " " + "Name:");
                ingName = Console.ReadLine();

                Console.WriteLine("Enter Quantity of Ingredient:");
                while (!double.TryParse(Console.ReadLine(), out ingQuan) || ingQuan <= 0.0) //displays error message if invaild input is entered
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid quantity amount.");
                    Console.ResetColor();
                }

                Console.WriteLine("Select unit of measurement:");
                Console.WriteLine("1 - tsp (teaspoon)");
                Console.WriteLine("2 - tbsp (tablespoon)");
                Console.WriteLine("3 - C (cup )");
                Console.WriteLine("4 - ml (milliliter)");
                Console.WriteLine("5 - L (liter)");
                Console.WriteLine("6 - g (gram)");
                Console.WriteLine("7 - Kg (kilogram)");


                int UserOp = 0;
                while (!int.TryParse(Console.ReadLine(), out UserOp) || UserOp > 7 || UserOp <= 0) //displays error mesasge if invaild input is entered
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid unit of measurement.");
                    Console.ResetColor();
                }

                //switch case that allows the user to select unit of measurement for ingredients
                switch (UserOp)
                {

                    case 1:
                        Console.WriteLine("tsp selected");
                        ingUnitList.Add("tsp");

                        break;
                    case 2:
                        Console.WriteLine("tbsp selected");
                        ingUnitList.Add("tbsp");
                        break;
                    case 3:
                        Console.WriteLine("Cup selected");
                        ingUnitList.Add("Cup");
                        break;
                    case 4:
                        Console.WriteLine("ml selected");
                        ingUnitList.Add("ml");
                        break;
                    case 5:
                        Console.WriteLine("L selected");
                        ingUnitList.Add("L");
                        break;
                    case 6:
                        Console.WriteLine("g selected");
                        ingUnitList.Add("g");
                        break;
                    case 7:
                        Console.WriteLine("Kg selected");
                        ingUnitList.Add("Kg");
                        break;
                    default:
                        Console.WriteLine("select a valid unit of measurement");
                        break;
                }

                Console.WriteLine("Enter calorie count for ingredient");
                while (!double.TryParse(Console.ReadLine(), out ingCal) || ingCal <= 0.0) //displays error message if invaild input is entered
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid calorie amount.");
                    Console.ResetColor();
                }


                Console.WriteLine("Select unit of measurement:");
                Console.WriteLine("1 - Fats and sugars");
                Console.WriteLine("2 - Proteins");
                Console.WriteLine("3 - Dairy");
                Console.WriteLine("4 - Fruit and vegtables");
                Console.WriteLine("5 - Carbohydrates");

                int UserOpTwo = 0;
                while (!int.TryParse(Console.ReadLine(), out UserOpTwo) || UserOpTwo > 5 || UserOpTwo <= 0) //displays error mesasge if invaild input is entered
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please select a valid food group.");
                    Console.ResetColor();
                }

                //switch case that allows the user to select unit of measurement for ingredients
                switch (UserOpTwo)
                {

                    case 1:
                        Console.WriteLine("Fats and sugars selected");
                        ingFoodGroupList.Add("Fats and sugars");
                        break;
                    case 2:
                        Console.WriteLine("Proteins selected");
                        ingFoodGroupList.Add("Proteins");
                        break;
                    case 3:
                        Console.WriteLine("Dairy selected");
                        ingFoodGroupList.Add("Dairy");
                        break;
                    case 4:
                        Console.WriteLine("Fruit and vegtables selected");
                        ingFoodGroupList.Add("Fruit and vegtables");
                        break;
                    case 5:
                        Console.WriteLine("Carbohydrates selected");
                        ingFoodGroupList.Add("Carbohydrates");
                        break;
                    default:
                        Console.WriteLine("Please select a valid food group.");
                        break;
                }



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Ingredient entered ");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();

                //Adds values input by user into arrayLists
                recipeNameList.Add(recipeName);
                ingNameList.Add(ingName);
                ingQuanList.Add(ingQuan);
                ingCalList.Add(ingCal);

            }

        }



        //This is a method to allow the user to input their steps for their recipe
        public void stepsRecipe(int userIngAmt, int ingNum, List<string> stepList, List<string> recipeNameList)
        {

            Console.WriteLine("How many steps are in your recipe?");
            while (!int.TryParse(Console.ReadLine(), out userIngAmt) || userIngAmt <= 0) //displays error message if invalid input is entered
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number of steps.");
                Console.ResetColor();
            }

            Console.WriteLine("----------------------------------------");

            for (ingNum = 0; ingNum < userIngAmt; ingNum++) //counts number of steps entered by user
            {
                int sum = ingNum + 1;
                Console.WriteLine("Enter step" + " " + sum + ":"); //user enters recipe step
                string step = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Step entered ");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();

                stepList.Add(step);

            }




        }



        //This is a method to allow the user to scale their recipe ingredients by 0.5, 2 and 3
        public void scaleRecipe(double sumTwo, List<double> scaledIngQuanList, double sumOne, List<string> recipeNameList, List<string> ingNameList, List<double> ingQuanList, List<string> ingUnitList, List<double> scaledCalList, List<double> ingCalList)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Enter the name of the recipe you want to scale");
            string search = Console.ReadLine();
            int searchIndex = recipeNameList.IndexOf(search);

            if (searchIndex != -1)
            {
                searchIndex = recipeNameList.IndexOf(search);

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Are sure you want to scale recipe?"); //asks user if they want to scale ingredients
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");


                string userOp = Console.ReadLine();
                int UserOp = int.Parse(userOp);

                //switch case displaying if yes or no selected
                switch (UserOp)
                {

                    case 1:
                        Console.WriteLine("Yes selected");
                        break;
                    case 2:
                        Console.WriteLine("No selected");
                        break;
                    default:
                        Console.WriteLine("Select a valid option");
                        break;

                }



                Console.WriteLine("----------------------------------------");
                Console.ResetColor();

                //values for the ingredients to be multiplied by
                double half = 0.5;
                double twice = 2.0;
                double thrice = 3.0;

                //if the user selects yes this will run and the user will be given a choice to scale their recipe ingredients by the desired values
                if (UserOp == 1)
                {

                    Console.WriteLine("Select value to scale recipe by");
                    Console.WriteLine("1 - 0,5");
                    Console.WriteLine("2 - 2");
                    Console.WriteLine("3 - 3");

                    string userOp2 = Console.ReadLine();
                    int UserOp2 = int.Parse(userOp2);

                    switch (UserOp2)
                    {

                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Scaled by 0,5");
                            Console.WriteLine("----------------------------------------");

                            for (int i = 0; i < ingNameList.Count; i++) //displays the recipe ingredients and quantites/unit of measurements
                            {
                                if (recipeNameList[i] == search)
                                {

                                    sumOne = ingQuanList[i] * half;
                                    sumTwo = ingCalList[i] * half;
                                    scaledIngQuanList.Add(sumOne);
                                    scaledCalList.Add(sumTwo);

                                }
                            }
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Scaled by 2");
                            Console.WriteLine("----------------------------------------");

                            for (int i = 0; i < ingNameList.Count; i++) //displays the recipe ingredients and quantites/unit of measurements
                            {
                                if (recipeNameList[i] == search)
                                {
                                    sumOne = ingQuanList[i] * twice;
                                    sumTwo = ingCalList[i] * twice;
                                    scaledIngQuanList.Add(sumOne);
                                    scaledCalList.Add(sumTwo);
                                }
                            }
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Scaled by 3");
                            Console.WriteLine("----------------------------------------");

                            for (int i = 0; i < ingNameList.Count; i++) //displays the recipe ingredients and quantites/unit of measurements
                            {
                                if (recipeNameList[i] == search)
                                {
                                    sumOne = ingQuanList[i] * thrice;
                                    sumTwo = ingCalList[i] * thrice;
                                    scaledIngQuanList.Add(sumOne);
                                    scaledCalList.Add(sumTwo);
                                }
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Select a valid option");
                            Console.WriteLine("----------------------------------------");
                            break;

                    }

                }

            }
            Console.ResetColor();



        }



        //This is a method to allow the user to reset the scaled ingredients amounts back to their original amounts
        public void resetRecipe(List<double> scaledIngQuanList, string ingName, double ingQuan, string unitMea, int userIngAmt, int ingNum, List<string> ingNameList, List<double> ingQuanList, List<string> ingUnitList, List<string> stepList, List<string> recipeNameList, List<double> scaledCalList, List<double> ingCalList)
        {

            Console.WriteLine("Enter the name of the recipe you want to reset");
            string search = Console.ReadLine();
            int searchIndex = recipeNameList.IndexOf(search);

            if (scaledIngQuanList.Count != 0 && searchIndex != -1)
            {
                //   searchIndex = recipeNameList.IndexOf(search);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Are sure you want to reset recipe?"); //asks user if they want to scale ingredients
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");


                string userOp = Console.ReadLine();
                int UserOp = int.Parse(userOp);

                //switch case displaying if yes or no selected
                switch (UserOp)
                {

                    case 1:
                        Console.WriteLine("Yes selected");
                        break;
                    case 2:
                        Console.WriteLine("No selected");
                        break;
                    default:
                        Console.WriteLine("Select a valid option");
                        break;

                }
                Console.ResetColor();

                if (UserOp == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Resetting ingredient values for '{search}' to original:");
                    Console.WriteLine("----------------------------------------");

                    // Iterate through the ingredients and reset values for the specified recipe
                    for (int i = 0; i < ingNameList.Count; i++)
                    {
                        if (recipeNameList[i] == search)
                        {
                            // Reset the scaled ingredient quantity to its original value
                            scaledIngQuanList.RemoveAt(i); // Assuming original quantities are stored in ingQuanList
                            scaledCalList.RemoveAt(i);

                        }
                    }

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Ingredient values for '{search}' have been reset to original.");
                    Console.ResetColor();
                }
            }

            else
            {
                // Handle cases where the recipe or scaled ingredients are not found
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------------");
                if (searchIndex == -1)
                    Console.WriteLine($"Recipe '{search}' not found.");
                else
                    Console.WriteLine($"No scaled ingredients found for '{search}'.");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }

        }



        //This is a mehtod that will allow the user to view their recipe
        public void viewRecipe(List<double> scaledIngQuanList, double sumOne, int userIngAmt, int ingNum, List<string> recipeNameList, List<string> ingNameList, List<double> ingQuanList, List<string> ingUnitList, List<string> stepList, List<double> ingCalList, List<string> ingFoodGroupList, List<double> scaledCalList)
        {

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Enter the name of the recipe you want to find");
            string search = Console.ReadLine();
            int searchIndex = recipeNameList.IndexOf(search);

            Boolean isDisplayed = false;

            CaloriesAmount caloriesAmount = new CaloriesAmount(300, 0);
            caloriesAmount.CaloriesExceeded += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: Total calories for this recipe exceed 300!");
                Console.ResetColor();
            };



            //if there is a recipe stored and the ingredients have been scaled, the scaled values will be displayed
            if (scaledIngQuanList.Any(q => q != 0) && searchIndex != -1)
            {

                Console.WriteLine("----------------------------------------");
                var eleRec = recipeNameList[searchIndex];

                Console.WriteLine($"Recipe name: {eleRec}");
                Console.WriteLine($"Step \t Ingredients \t\t Quantity \t Calories \t Food Group");


                int ingCount = 0;
                double totalCalories = 0;
                for (int i = 0; i < ingNameList.Count; i++) //displays the recipe ingredients and quantites/unit of measurements
                {
                    if (recipeNameList[i] == search)
                    {
                        ingCount++;
                        var eleOne = ingNameList[i];
                        var eleTwo = i < scaledIngQuanList.Count ? scaledIngQuanList[i] : ingQuanList[i]; // Check if index is within bounds
                        var eleThree = ingUnitList[i];
                        var eleFour = i < scaledCalList.Count ? scaledCalList[i] : ingCalList[i]; // Check if index is within bounds
                        var eleFive = ingFoodGroupList[i];
                        totalCalories += eleFour;
                        Console.WriteLine($"{ingCount}:\t {eleOne} \t\t {eleTwo} {eleThree} \t {eleFour} \t {eleFive}");
                    }
                }
                Console.WriteLine($"Total Calories for '{eleRec}' recipe: {totalCalories}");
                // Update total calories in CaloriesAmount and check if it exceeds the limit
                caloriesAmount.Credit(totalCalories);

                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Steps for {eleRec} recipe \n ");

                int count2 = stepList.Count;
                for (int i = 0; i < count2; i++) //displays the recipe steps
                {
                    if (recipeNameList[i] == search)
                    {
                        int stepCount = i + 1;
                        var eleStep = stepList[i];
                        Console.WriteLine($"Step {stepCount}: {eleStep}");
                    }
                }
                Console.WriteLine("----------------------------------------");

                isDisplayed = true;
            }





            // if there is a recipe stored and the ingredients have not been scaled this will be displayed
            if (searchIndex != -1 && !isDisplayed)
            {
                Console.WriteLine("----------------------------------------");
                var eleRec = recipeNameList[searchIndex];

                Console.WriteLine($"Recipe name: {eleRec}");
                Console.WriteLine($"Step \t Ingredients \t\t Quantity \t Calories \t Food Group");

                int ingCount = 0;
                double totalCalories = 0;
                for (int i = 0; i < ingNameList.Count; i++) //displays the recipe ingredients and quantites/unit of measurements
                {
                    if (recipeNameList[i] == search)
                    {
                        ingCount++;
                        var eleOne = ingNameList[i];
                        var eleTwo = ingQuanList[i];
                        var eleThree = ingUnitList[i];
                        var eleFour = ingCalList[i];
                        var eleFive = ingFoodGroupList[i];
                        totalCalories += eleFour;
                        Console.WriteLine($"{ingCount}:\t {eleOne} \t\t\t {eleTwo} {eleThree} \t\t {eleFour} \t {eleFive}");
                    }
                }

                Console.WriteLine($"Total Calories for '{eleRec}' recipe: {totalCalories}");
                // Update total calories in CaloriesAmount and check if it exceeds the limit
                caloriesAmount.Credit(totalCalories);



                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Steps for {eleRec} recipe \n ");

                int stepCount = 0;
                for (int i = 0; i < stepList.Count; i++)
                {
                    if (recipeNameList[i] == search)
                    {
                        stepCount++;
                        var eleStep = stepList[i];
                        Console.WriteLine($"Step {stepCount}: {eleStep}");
                    }
                }

                Console.WriteLine("----------------------------------------");
                isDisplayed = true;
            }


            //if there is no recipe stored this message will be displayed
            if (!isDisplayed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("No recipe to display");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }

            Console.ResetColor();
        }



        //This method displays all stored recipes in alphabetical order
        public void displayAlphaOrder(List<double> scaledIngQuanList, double sumOne, int userIngAmt, int ingNum, List<string> recipeNameList, List<string> ingNameList, List<double> ingQuanList, List<string> ingUnitList, List<string> stepList, List<double> ingCalList, List<string> ingFoodGroupList, List<double> scaledCalList)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Boolean isDisplayed = false;

            CaloriesAmount caloriesAmount = new CaloriesAmount(300, 0);
            caloriesAmount.CaloriesExceeded += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: Total calories for this recipe exceed 300!");
                Console.ResetColor();
            };

            // Group ingredients and steps by recipes
            var groupedRecipes = recipeNameList
                .Distinct()
                .Select(recipeName => new
                {
                    RecipeName = recipeName,
                    Ingredients = ingNameList
                        .Select((name, index) => new
                        {
                            Name = name,
                            Quan = ingQuanList[index],
                            Unit = ingUnitList[index],
                            Cal = ingCalList[index],
                            FoodGroup = ingFoodGroupList[index],
                            ScaledQuan = scaledIngQuanList.ElementAtOrDefault(index),
                            ScaledCal = scaledCalList.ElementAtOrDefault(index),
                            RecipeIndex = recipeNameList[index]
                        })
                        .Where(ing => ing.RecipeIndex == recipeName)
                        .ToList(),
                    Steps = stepList
                        .Select((step, index) => new { Step = step, Recipe = recipeNameList[index] })
                        .Where(step => step.Recipe == recipeName)
                        .Select(step => step.Step)
                        .ToList()
                })
                .OrderBy(recipe => recipe.RecipeName)
                .ToList();

            // Display the recipes
            foreach (var recipe in groupedRecipes)
            {
                Console.WriteLine("----------------------------------------");

                int ingCount = 0;
                double totalCalories = 0;

                Console.WriteLine($"Recipe name: {recipe.RecipeName}");
                Console.WriteLine($"Step \t Ingredients \t\t Quantity \t Calories \t Food Group");

                foreach (var ing in recipe.Ingredients)
                {
                    ingCount++;
                    var eleTwo = ing.ScaledQuan != 0 ? ing.ScaledQuan : ing.Quan;
                    var eleFour = ing.ScaledCal != 0 ? ing.ScaledCal : ing.Cal;
                    totalCalories += eleFour;

                    Console.WriteLine($"{ingCount}:\t {ing.Name} \t\t {eleTwo} {ing.Unit} \t {eleFour} \t {ing.FoodGroup}");
                }

                Console.WriteLine($"Total Calories for '{recipe.RecipeName}' recipe: {totalCalories}");
                caloriesAmount.Credit(totalCalories);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Steps for {recipe.RecipeName} recipe \n");

                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    Console.WriteLine($"Step {i + 1}: {recipe.Steps[i]}");
                }
                Console.WriteLine("----------------------------------------");

                isDisplayed = true;
            }

            // If there is no recipe stored this message will be displayed
            if (!isDisplayed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("No recipe to display");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }

            Console.ResetColor();
        }


        //This is a method that will allow the user to delete their stored recipe
        public void deleteRecipe(List<double> scaledIngQuanList, double sumOne, int userIngAmt, int ingNum, List<string> recipeNameList, List<string> ingNameList, List<double> ingQuanList, List<string> ingUnitList, List<string> stepList, List<double> ingCalList, List<string> ingFoodGroupList, List<double> scaledCalList)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter the name of the recipe you want to delete:");
            string search = Console.ReadLine();
            int searchIndex = recipeNameList.IndexOf(search);

            if (searchIndex != -1)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("This is the recipe you want to delete");
                Console.WriteLine("----------------------------------------");
                var eleRec = recipeNameList[searchIndex];

                Console.WriteLine($"Recipe name: {eleRec}");
                Console.WriteLine($"Step \t Ingredients \t\t Quantity \t Calories \t Food Group");

                int ingCount = 0;
                double totalCalories = 0;
                for (int i = 0; i < ingNameList.Count; i++) // Display recipe ingredients, quantities, and unit of measurements
                {
                    if (recipeNameList[i] == search)
                    {
                        ingCount++;
                        var eleOne = ingNameList[i];
                        var eleTwo = scaledIngQuanList.Any() ? scaledIngQuanList[i] : ingQuanList[i];
                        var eleThree = ingUnitList[i];
                        var eleFour = scaledCalList.Any() ? scaledCalList[i] : ingCalList[i];
                        var eleFive = ingFoodGroupList[i];
                        totalCalories += eleFour;
                        Console.WriteLine($"{ingCount}:\t {eleOne} \t\t {eleTwo} {eleThree} \t {eleFour} \t {eleFive}");
                    }
                }

                Console.WriteLine($"Total Calories for '{eleRec}' recipe: {totalCalories}");

                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Steps for {eleRec} recipe \n ");

                for (int i = 0; i < stepList.Count; i++) // Display recipe steps
                {
                    if (recipeNameList[i] == search)
                    {
                        var eleStep = stepList[i];
                        Console.WriteLine($"Step {i + 1}: {eleStep}");
                    }
                }

                Console.WriteLine("----------------------------------------");

                Console.WriteLine("Are you sure you want to delete this recipe?");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");

                string userOp = Console.ReadLine();
                int UserOp = int.Parse(userOp);

                switch (UserOp)
                {
                    case 1: // Remove recipe
                        Console.WriteLine("Yes selected");
                        Console.WriteLine("----------------------------------------");
                        recipeNameList.RemoveAt(searchIndex);
                        stepList.RemoveAll(step => recipeNameList[stepList.IndexOf(step)] == search);
                        for (int i = ingNameList.Count - 1; i >= 0; i--)
                        {
                            if (recipeNameList[i] == search)
                            {
                                ingNameList.RemoveAt(i);
                                ingQuanList.RemoveAt(i);
                                ingUnitList.RemoveAt(i);
                                ingCalList.RemoveAt(i);
                                if (scaledIngQuanList.Any())
                                    scaledIngQuanList.RemoveAt(i);
                                if (scaledCalList.Any())
                                    scaledCalList.RemoveAt(i);
                            }
                        }
                        Console.WriteLine("Recipe deleted successfully.");
                        break;
                    case 2:
                        Console.WriteLine("No selected");
                        Console.WriteLine("----------------------------------------");
                        break;
                    default:
                        Console.WriteLine("Invalid option selected");
                        break;
                }

                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Recipe Not Found");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }
        }




    }
}
