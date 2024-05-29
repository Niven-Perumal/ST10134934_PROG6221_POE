# **Project Title**
PROG6221 Recipe Storage Application


# **Table of Contents**
- [Purpose of project](#purposeofproject)
- [How to compile and run the application](#howtocompileandruntheapplication)
- [How to use the Recipe Application Part One](#howtousetherecipeapplicationpartone)
- [How to use the Updated Recipe Application Part Two](#howtousetheupdatedrecipeapplicationparttwo).
- [GitHub repository link](#gitHubrepositorylink)
- [Loom video link for demo of application](#loomvideolinkfordemoofapplication)
- [Changes made to Part Two based on feedback from Part One](#changesmadetoparttwobasedonfeedbackfrompartone).
- [Contribution](#contribution)
- [Licenses](#licenses)


# **Purpose of project**
This project was created to be a console-based Visual Studio recipe storage application. This application allows you to easily keep track of your recipes and effortlessly perform functions such as add recipe ingredients, quantities, units of measurements and steps, view the recipe ingredients, quantities, units of measurements, calories and steps in a clear format, scale the recipe ingredients depending on your quantity needs, reset the scaled recipe ingredients to their original values, delete the recipe stored in the application and exit the program. Additionally, to make recipe storage, management, and manipulation easier the user is provided with clear, user-friendly, and visually pleasing menu prompts that efficiently guide the user through the application and its functions.

# **How to compile and run the application**
* **Requirements to compile and run the project:**
    *	Have Visual Studio installed.
* **How to download the project onto your machine**:
    *	Navigate to the GitHub repository using the projects repository link.
    *	Select the green code tab on the repository home page.
    *	Select on “Local” tab.
    *	Select “Download Zip”
* **How to open/run the project**:
    *	Unzip/extract all files from the downloaded zip folder.
    *	Open the file named “ST10134934_PROG6221_PartOne.”
    *	Either select ST10134934_PROG6221_PartOne.sln to open and run the project or open the project using Visual Studio.

# **How to use the Recipe Application Part One**
After the application/project has been opened in Visual Studio the following should be done to interact with the recipe application's core features:
-	**Follow the menu prompts and select a number suitable number listed (1-6)**
    *	**1 – Add Recipe:**
        - Enter the name of the recipe.
        - Enter the number of ingredients to be used in the recipe.
        - Enter the name of the ingredient.
        - Enter the quantity of the ingredient.
        - Enter the unit of measurement used for the ingredient.
    *	**2 – View Recipe:**
        -	This option will display the recipe name and the ingredients with the original ingredient quantities and steps if the recipe has not been scaled.
        -	If the recipe has been scaled the new ingredient quantities will be displayed.
    *	**3 – Scale Recipe:**
        -	This option provides the user with three options, scale recipe quantities by 0.5, 2 or 3. These options will multiply the user-entered ingredient quantities.
    *	**4 – Reset Ingredients to original amount:** 
        -	This option will reset the scaled ingredient quantities back to the original user-entered quantities.
    *	**5 – Delete Recipe:** 
        -	This option will remove/clear/delete the entire recipe that has been entered and stored by the user.
    *	**6 – Exit program:** 
        -	This option will stop running the program.

- **Important colour-coded messages in the application**
    * Green message – Operation has been completed successfully.
    * Red message – Operation returned an error message e.g. Invalid user-input.
    * Blue message – Yes or No decision to be made by the user.
    * White message – Main menu for the user and other prompts for user input.
 

# **How to use the Updated Recipe Application Part Two**
After the application/project has been opened in Visual Studio the following should be done to interact with the recipe application's core features:
-	**Follow the menu prompts and select a number suitable number listed (1-7)**
    *	**1 – Add Recipe:**
        - Enter the name of the recipe.
        - Enter the number of ingredients to be used in the recipe.
        - Enter the name of the ingredient.
        - Enter the quantity of the ingredient.
        - Enter the unit of measurement used for the ingredient.
        - Enter the calorie count for the ingredient.
        - Enter the food group the ingredient belongs to.
    *	**2 – View Recipe:**
        -	This option will prompt the user to enter a recipe name to search for and display if it is stored in the application. If found the recipe name and the ingredients with the                original ingredient quantities and calories and steps will be displayed if the recipe has not been scaled. If the recipe has been scaled the scaled values will be displayed. 
    * **3 - Display all Recipes in Alphabetical order:**
        -   This option will display all recipes stored in the application alphabetically according to the recipe name.
    *	**4 – Scale Recipe:**
        -	This option will prompt the user to search for a recipe name. If the recipe is found the user will be provided with three options, scale recipe quantities/calories by 0.5, 2              or 3. These options will multiply the user-entered ingredient quantities and calories.
    *	**5 – Reset Ingredients to original amount:** 
        -	This option will prompt the user to search for a recipe name. If the recipe is found the scaled ingredient quantities and calories will be reset back to the original
            user-entered quantities and calories.
    *	**6 – Delete Recipe:** 
        -	This option will prompt the user to search for a recipe name. If the recipe is found they will be given the option to remove/clear/delete the entire recipe that has been                 entered and stored by the user.
    *	**7 – Exit program:** 
        -	This option will stop running the program.
 

# **GitHub repository link**
https://github.com/Niven-Perumal/ST10134934_PROG6221_PartOne.git

# **Loom video link for demo of application Part One and Two**
Part One - https://www.loom.com/share/7da5a9104c2c417789fe20a43777944a?sid=ed724ffb-eb1e-4045-8f8c-efefbca1ee87
Part Two -

# **Changes made to Part Two based on feedback from Part One**
* **Based on feedback, the Part Two recipe console application will include the functionality from Part One with the following additional features/functionalities:**
        -   The user can now enter multiple recipes instead of being limited to one.
        -	The user can enter a name for each recipe.
        -	When viewing a recipe, the user can optionally display all recipes alphabetically by name.
        -	The user can search for a recipe to display.
        -	For each ingredient, the user can enter the calorie amount and food group the ingredient is in:
        -	The application will automatically calculate and display the total calories of all the ingredients in a recipe.
        -	The application will notify the user when the total calorie of a recipe is greater than 300.
* **Non-functional requirements:**
        -	The application will now use generic collections (Lists) to store the recipes, ingredients, and steps, and no longer use array lists.
        -	The application will now use a delegate to notify the user when a recipe calorie count exceeds 300.
        -	The application will now include a unit test for the total calorie calculation.


# Contribution
BCA2 student Niven Perumal developed this PROG6221 POE Part One and Two Recipe Application. Additionally, code attribution and references from other developers, websites and online sources have been included in the project.

# Licenses
The PROG6221 POE Part One and Two Recipe Application is released under the MIT License.
