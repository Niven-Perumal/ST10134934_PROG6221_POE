using ST10134934_PROG6221_PartOne;

namespace Unit_Testing
{
    [TestClass]
    public class CalorieTest
    {
        [TestMethod]
        public void CalorieExceedsCount()
        {

            double calorieLimit = 300;
            double initialCalories = 0;
            CaloriesAmount caloriesAmount = new CaloriesAmount(calorieLimit, initialCalories);
            bool eventTriggered = false;

            // CaloriesExceeded event
            caloriesAmount.CaloriesExceeded += (sender, e) => { eventTriggered = true; };

            // Adding 150 calories
            caloriesAmount.Credit(150);
            Assert.IsFalse(eventTriggered, "CaloriesExceeded event should not be triggered yet.");

            // Adding 200  calories
            caloriesAmount.Credit(200);


            Assert.IsTrue(eventTriggered, "CaloriesExceeded event should be triggered when total calories exceed the limit.");
            Assert.AreEqual(350, caloriesAmount.CalTotalAmount, "Total calories should be 350 after crediting 150 and 200.");

        }
    }
}