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

            //ArrayLists declared that will be used to store user input
            ArrayList ingNameArrayList = new ArrayList();
            ArrayList ingQuanArrayList = new ArrayList();
            ArrayList ingUnitArrayList = new ArrayList();
            ArrayList recipeNameArrayList = new ArrayList();
            ArrayList stepArrayList = new ArrayList();

            ArrayList scaledIngQuanArrayList = new ArrayList();

            //object to call methods from Recipe.cs
            Recipe recipe = new Recipe();

            // this loop will ensure the app runs until exit is selected
            while (UserOp != 6)
            {
                try
                {

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Welcome to Recipe Tracker Application");
                    Console.WriteLine("Please select an operation");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("1 - Add Recipe");
                    Console.WriteLine("2 - View Recipe");
                    Console.WriteLine("3 - Scale Recipe");
                    Console.WriteLine("4 - Reset Ingredients to original amount");
                    Console.WriteLine("5 - Delete Recipe");
                    Console.WriteLine("6 - Exit program");
                    Console.WriteLine("----------------------------------------");


                    userOp = Console.ReadLine();
                    UserOp = int.Parse(userOp);

                    //this switch case calls all methods from Recipe.cs (method class) that will run based on operation selected by user
                    switch (UserOp)
                    {

                        case 1:
                            recipe.addRecipe(recipeName, ingName, ingQuan, unitMea, userIngAmt, ingNum, recipeNameArrayList, ingNameArrayList, ingQuanArrayList, ingUnitArrayList);
                            recipe.stepsRecipe(userIngAmt, ingNum, stepArrayList, recipeNameArrayList);
                            break;
                        case 2:
                            recipe.viewRecipe(scaledIngQuanArrayList, sumOne, userIngAmt, ingNum, recipeNameArrayList, ingNameArrayList, ingQuanArrayList, ingUnitArrayList, stepArrayList);
                            break;
                        case 3:
                            recipe.scaleRecipe(scaledIngQuanArrayList, sumOne, recipeNameArrayList, ingNameArrayList, ingQuanArrayList, ingUnitArrayList);
                            break;
                        case 4:
                            recipe.resetRecipe(scaledIngQuanArrayList, ingName, ingQuan, unitMea, userIngAmt, ingNum, ingNameArrayList, ingQuanArrayList, ingUnitArrayList, stepArrayList);
                            break;
                        case 5:
                            recipe.deleteRecipe(scaledIngQuanArrayList, recipeNameArrayList, ingNameArrayList, ingQuanArrayList, ingUnitArrayList, stepArrayList);
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Exit program selected goodbye!");
                            Console.WriteLine("----------------------------------------");
                            Console.ResetColor();
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a valid operation");
                            Console.ResetColor();
                            break;
                    }




                }
                catch (FormatException)
                {
                    Console.WriteLine("Invaild operation selected");
                    Console.WriteLine("----------------------------------------");
                }

            }




        }
    }
}
