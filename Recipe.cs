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
        public void addRecipe(string recipeName, string ingName, double ingQuan, string unitMea, int userIngAmt, int ingNum, ArrayList recipeNameArrayList, ArrayList ingNameArrayList, ArrayList ingQuanArrayList, ArrayList ingUnitArrayList)
        {
            //this will display a message if a recipe has already been stored
            if (recipeNameArrayList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Cannot add another recipe until existing recipe is deleted.");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }
            else //this runs the add recipe method if there is no recipe currently stored 
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

                    //   unitMea = Console.ReadLine();
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
                            ingUnitArrayList.Add("tsp");

                            break;
                        case 2:
                            Console.WriteLine("tbsp selected");
                            ingUnitArrayList.Add("tbsp");
                            break;
                        case 3:
                            Console.WriteLine("Cup selected");
                            ingUnitArrayList.Add("Cup");
                            break;
                        case 4:
                            Console.WriteLine("ml selected");
                            ingUnitArrayList.Add("ml");
                            break;
                        case 5:
                            Console.WriteLine("L selected");
                            ingUnitArrayList.Add("L");
                            break;
                        case 6:
                            Console.WriteLine("g selected");
                            ingUnitArrayList.Add("g");
                            break;
                        case 7:
                            Console.WriteLine("Kg selected");
                            ingUnitArrayList.Add("Kg");
                            break;
                        default:
                            Console.WriteLine("select a valid unit of measurement");
                            break;
                    }


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Ingredient entered ");
                    Console.WriteLine("----------------------------------------");
                    Console.ResetColor();

                    //Adds values input by user into arrayLists
                    recipeNameArrayList.Add(recipeName);
                    ingNameArrayList.Add(ingName);
                    ingQuanArrayList.Add(ingQuan);


                }
            }
        }



        //This is a method to allow the user to input their steps for their recipe
        public void stepsRecipe(int userIngAmt, int ingNum, ArrayList stepArrayList, ArrayList recipeNameArrayList)
        {
            //this  will run the method if their is no recipe currently stored. If a recipe is stored this will not run.
            if (stepArrayList.Count == 0)
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

                    stepArrayList.Add(step);

                }

            }


        }



        //This is a method to allow the user to scale their recipe ingredients by 0.5, 2 and 3
        public void scaleRecipe(ArrayList scaledIngQuanArrayList, double sumOne, ArrayList recipeNameArrayList, ArrayList ingNameArrayList, ArrayList ingQuanArrayList, ArrayList ingUnitArrayList)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
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

                //    Console.WriteLine("----------------------------------------");
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
                        scaledIngQuanArrayList.Clear();
                        foreach (double val in ingQuanArrayList) //updates all values in the new arrayList
                        {
                            sumOne = val * half;
                            scaledIngQuanArrayList.Add(sumOne);
                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Scaled by 2");
                        Console.WriteLine("----------------------------------------");
                        scaledIngQuanArrayList.Clear();
                        foreach (double val in ingQuanArrayList) //updates all values in the new arrayList
                        {
                            sumOne = val * twice;
                            scaledIngQuanArrayList.Add(sumOne);
                        }
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("Scaled by 3");
                        Console.WriteLine("----------------------------------------");
                        scaledIngQuanArrayList.Clear();
                        foreach (double val in ingQuanArrayList) //updates all values in the new arrayList
                        {
                            sumOne = val * thrice;
                            scaledIngQuanArrayList.Add(sumOne);
                        }
                        break;
                    default:
                        Console.WriteLine("Select a valid option");
                        break;

                }

            }
            Console.ResetColor();



        }



        //This is a method to allow the user to reset the scaled ingredients amounts back to their original amounts
        public void resetRecipe(ArrayList scaledIngQuanArrayList, string ingName, double ingQuan, string unitMea, int userIngAmt, int ingNum, ArrayList ingNameArrayList, ArrayList ingQuanArrayList, ArrayList ingUnitArrayList, ArrayList stepArrayList)
        {
            //If there is a recipe stored, then the ingredients will be reset to their orginal values (before scaled)
            if (scaledIngQuanArrayList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                scaledIngQuanArrayList.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Recipe ingredient values have been reset to original ");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }
            else //if there is no recipe stored then this message will be displayed
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("No recipe ingredients to reset");
                Console.WriteLine("----------------------------------------");
                Console.ResetColor();
            }

        }



        //This is a mehtod that will allow the user to view their recipe
        public void viewRecipe(ArrayList scaledIngQuanArrayList, double sumOne, int userIngAmt, int ingNum, ArrayList recipeNameArrayList, ArrayList ingNameArrayList, ArrayList ingQuanArrayList, ArrayList ingUnitArrayList, ArrayList stepArrayList)
        {

            string[] name = (string[])recipeNameArrayList.ToArray(typeof(string));
            double[] ingQuanArray = (double[])ingQuanArrayList.ToArray(typeof(double));

            Console.ForegroundColor = ConsoleColor.Green;

            //if there is a recipe stored and the ingredients have been scaled, the scaled values will be displayed
            if (scaledIngQuanArrayList.Count != 0)
            {

                Console.WriteLine("----------------------------------------");
                var eleRec = recipeNameArrayList[0];

                Console.WriteLine($"Recipe name: {eleRec}");
                Console.WriteLine($"Ingredients \t\t Quantity");


                int count = ingNameArrayList.Count;

                for (int i = 0; i < count; i++) //displays the recipe ingredients and scaled quantities/unit of measurements
                {
                    int ingCount = i + 1;
                    var eleOne = ingNameArrayList[i];
                    var eleTwo = scaledIngQuanArrayList[i];
                    var eleThree = ingUnitArrayList[i];

                    Console.WriteLine($"{ingCount}: {eleOne} \t\t {eleTwo} {eleThree}");
                }



                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Steps for {eleRec} recipe \n ");

                int count2 = stepArrayList.Count;
                for (int i = 0; i < count2; i++) //displays the recipe steps
                {
                    int stepCount = i + 1;
                    var eleStep = stepArrayList[i];
                    Console.WriteLine($"Step {stepCount}: {eleStep}");

                }
                Console.WriteLine("----------------------------------------");


            }


            // if there is a recipe stored and the ingredients have not been scaled this will be displayed
            if (recipeNameArrayList.Count != 0 && scaledIngQuanArrayList.Count == 0)
            {
                Console.WriteLine("----------------------------------------");
                var eleRec = recipeNameArrayList[0];

                Console.WriteLine($"Recipe name: {eleRec}");
                Console.WriteLine($"Ingredients \t\t Quantity");


                int count = ingNameArrayList.Count;

                for (int i = 0; i < count; i++) //displays the recipe ingredients and quantites/unit of measurements
                {
                    int ingCount = i + 1;
                    var eleOne = ingNameArrayList[i];
                    var eleTwo = ingQuanArrayList[i];
                    var eleThree = ingUnitArrayList[i];

                    Console.WriteLine($"{ingCount}: {eleOne} \t\t {eleTwo} {eleThree}");
                }




                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Steps for {eleRec} recipe \n ");

                int count2 = stepArrayList.Count;
                for (int i = 0; i < count2; i++)
                {
                    int stepCount = i + 1;
                    var eleStep = stepArrayList[i];
                    Console.WriteLine($"Step {stepCount}: {eleStep}");

                }

                Console.WriteLine("----------------------------------------");
            }


            //if there is no recipe stored this message will be displayed
            if (recipeNameArrayList.Count == 0 && scaledIngQuanArrayList.Count == 0)
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
        public void deleteRecipe(ArrayList scaledIngQuanArrayList, ArrayList recipeNameArrayList, ArrayList ingNameArrayList, ArrayList ingQuanArrayList, ArrayList ingUnitArrayList, ArrayList stepArrayList)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Are sure you want to delete recipe?"); //this asks the user if they want to delete recipe
            Console.WriteLine("1 - Yes");
            Console.WriteLine("2 - No");

            string userOp = Console.ReadLine();
            int UserOp = int.Parse(userOp);

            switch (UserOp)
            {
                //if yes is selected the recipe will be deleted
                case 1:
                    Console.WriteLine("Yes selected");
                    Console.WriteLine("----------------------------------------");
                    recipeNameArrayList.Clear();
                    ingNameArrayList.Clear();
                    ingQuanArrayList.Clear();
                    ingUnitArrayList.Clear();
                    stepArrayList.Clear();
                    scaledIngQuanArrayList.Clear();

                    break;
                case 2: //if no is selected the recipe will not be deleted
                    Console.WriteLine("No selected");
                    Console.WriteLine("----------------------------------------");
                    break;
                default:
                    Console.WriteLine("select a valid option");
                    break;

            }

            Console.ResetColor();
        }




    }
}
