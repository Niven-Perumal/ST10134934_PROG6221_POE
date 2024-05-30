using System.Collections;

namespace ST10134934_PROG6221_PartOne
{
    class Program
    {

        static void Main(string[] args)
        {
            //Values that are declared to be used
            string ingName = null, unitMea = null, recipeName = null;
            double ingQuan = 0;
            string userOp;
            int UserOp = 0;
            int userIngAmt = 0, ingNum = 0;

            double sumOne = 0.0;
            double sumTwo = 0.0;

            double ingCal = 0.0;



            //Gerneric collection List<T>
            List<string> ingNameList = new List<string>();
            List<double> ingQuanList = new List<double>();
            List<string> ingUnitList = new List<string>();
            List<string> recipeNameList = new List<string>();
            List<string> stepList = new List<string>();
            List<double> scaledIngQuanList = new List<double>();

            List<double> ingCalList = new List<double>();
            List<string> ingFoodGroupList = new List<string>();

            List<double> scaledCalList = new List<double>();


            //object to call methods from Recipe.cs
            Recipe recipe = new Recipe();

            // this loop will ensure the app runs until exit is selected
            while (UserOp != 7)
            {
                try
                {

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Welcome to Recipe Tracker Application");
                    Console.WriteLine("Please select an operation");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("1 - Add Recipe");
                    Console.WriteLine("2 - View Recipe");
                    Console.WriteLine("3 - Display all Recipes in Alphabetical order");
                    Console.WriteLine("4 - Scale Recipe");
                    Console.WriteLine("5 - Reset Ingredients to original amount");
                    Console.WriteLine("6 - Delete Recipe");
                    Console.WriteLine("7 - Exit program");
                    Console.WriteLine("----------------------------------------");


                    userOp = Console.ReadLine();
                    UserOp = int.Parse(userOp);

                    //this switch case calls all methods from Recipe.cs (method class) that will run based on operation selected by user
                    switch (UserOp)
                    {

                        case 1:
                            recipe.addRecipe(recipeName, ingName, ingQuan, unitMea, userIngAmt, ingNum, recipeNameList, ingNameList, ingQuanList, ingUnitList, ingCalList, ingFoodGroupList, ingCal);
                            recipe.stepsRecipe(userIngAmt, ingNum, stepList, recipeNameList);
                            break;
                        case 2:
                            recipe.viewRecipe(scaledIngQuanList, sumOne, userIngAmt, ingNum, recipeNameList, ingNameList, ingQuanList, ingUnitList, stepList, ingCalList, ingFoodGroupList, scaledCalList);
                            break;
                        case 3:
                            recipe.displayAlphaOrder(scaledIngQuanList, sumOne, userIngAmt, ingNum, recipeNameList, ingNameList, ingQuanList, ingUnitList, stepList, ingCalList, ingFoodGroupList, scaledCalList);
                            break;
                        case 4:
                            recipe.scaleRecipe(sumTwo, scaledIngQuanList, sumOne, recipeNameList, ingNameList, ingQuanList, ingUnitList, scaledCalList, ingCalList);
                            break;
                        case 5:
                            recipe.resetRecipe(scaledIngQuanList, ingName, ingQuan, unitMea, userIngAmt, ingNum, ingNameList, ingQuanList, ingUnitList, stepList, recipeNameList, scaledCalList, ingCalList);
                            break;
                        case 6:
                            recipe.deleteRecipe(scaledIngQuanList, sumOne, userIngAmt, ingNum, recipeNameList, ingNameList, ingQuanList, ingUnitList, stepList, ingCalList, ingFoodGroupList, scaledCalList);
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Exit program selected goodbye!");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Enter a valid operation");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();
                            break;
                    }




                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Invaild operation selected");
                    Console.WriteLine("----------------------------------------");
                    Console.ResetColor();

                }

            }




        }
    }
}


//Code attribution for changing text colour in app https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//Code attribution for switch cases used in app menus https://www.geeksforgeeks.org/switch-statement-in-c-sharp/
//Code attribution for delegrate https://www.geeksforgeeks.org/c-sharp-delegates/
//Code attribuion for Lists https://www.geeksforgeeks.org/c-sharp-list-class/
