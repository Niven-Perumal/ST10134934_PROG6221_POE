using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10134934_PROG6221_PartThree
{
    //Declaration get and set values for recipe ingredient values
    public class Ingredient
    {
        public string IngName { get; set; }
        public string IngQuantity { get; set; }
        public string IngUnit { get; set; }
        public string IngCalorieCount { get; set; }
        public string IngFoodGroup { get; set; }
    }

    //Declaration get and set values for recipe instructions
    public class Instructions
    {
        public string RecipeInstructions { get; set; }

    }

    //Declarations for recipes generic collections 
    public class Recipe
    {
        public string RecipeName { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<Instructions> Instructions { get; set; }

        public bool IsScaled { get; set; }

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Instructions = new ObservableCollection<Instructions>();
        }

        // Calculate total calories
        public double TotalCalories
        {
            get
            {
                return Ingredients.Sum(i =>
                {
                    double.TryParse(i.IngCalorieCount, out double calorieCount);
                    return calorieCount;
                });
            }
        }



        //Method to create a deep copy of the recipe
        public Recipe DeepClone()
        {
            var clone = new Recipe
            {
                RecipeName = this.RecipeName,
                IsScaled = this.IsScaled,
                Ingredients = new ObservableCollection<Ingredient>(this.Ingredients.Select(i => new Ingredient
                {
                    IngName = i.IngName,
                    IngQuantity = i.IngQuantity,
                    IngUnit = i.IngUnit,
                    IngCalorieCount = i.IngCalorieCount,
                    IngFoodGroup = i.IngFoodGroup
                })),
                Instructions = new ObservableCollection<Instructions>(this.Instructions.Select(i => new Instructions
                {
                    RecipeInstructions = i.RecipeInstructions
                }))
            };
            return clone;
        }




        //Method to check if filter values match any recipes
        public bool MatchesFilter(string ingredientNameFilter, string foodGroupFilter, double maxCaloriesFilter)
        {
            // Check if the recipe contains the specified ingredient name
            if (!string.IsNullOrEmpty(ingredientNameFilter))
            {
                bool containsIngredient = Ingredients.Any(i => i.IngName.Equals(ingredientNameFilter, StringComparison.OrdinalIgnoreCase));
                if (!containsIngredient)
                    return false;
            }

            // Check if the recipe belongs to the specified food group
            if (!string.IsNullOrEmpty(foodGroupFilter))
            {
                bool belongsToFoodGroup = Ingredients.Any(i => i.IngFoodGroup.Equals(foodGroupFilter, StringComparison.OrdinalIgnoreCase));
                if (!belongsToFoodGroup)
                    return false;
            }

            // Check if the total calories of the recipe are within the specified limit
            if (maxCaloriesFilter > 0)
            {
                double totalCalories = Ingredients.Sum(i =>
                {
                    double.TryParse(i.IngCalorieCount, out double calorieCount);
                    return calorieCount;
                });

                if (totalCalories > maxCaloriesFilter)
                    return false;
            }

            return true; // Recipe matches all filters
        }


    }

}
