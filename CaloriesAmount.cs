using System;

namespace ST10134934_PROG6221_PartOne
{
    public delegate void CaloriesExceededEventHandler(object sender, EventArgs e);

    public class CaloriesAmount
    {
        private double calLimit;
        private double calTotalAmount;

        public event CaloriesExceededEventHandler CaloriesExceeded;

        private CaloriesAmount() { }

        public CaloriesAmount(double calLimit, double calTotalAmount)
        {
            this.calLimit = calLimit;
            this.calTotalAmount = calTotalAmount;
        }

        public double CalLimit => calLimit;
        public double CalTotalAmount => calTotalAmount;

        //not used
        public void Debit(double amount)
        {
            if (amount > calTotalAmount)
                throw new ArgumentOutOfRangeException(nameof(amount));
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            calTotalAmount -= amount;
            CheckCalories();
        }

        // Protected virtual method to raise the CaloriesExceeded event
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            calTotalAmount += amount;
            CheckCalories();
        }

        // check if the total calories exceed the limit
        protected virtual void OnCaloriesExceeded(EventArgs e)
        {
            CaloriesExceeded?.Invoke(this, e);
        }

        // Trigger the CaloriesExceeded event if the total calories exceed 300
        private void CheckCalories()
        {
            if (calTotalAmount > 300)
                OnCaloriesExceeded(EventArgs.Empty);
        }
    }
}
