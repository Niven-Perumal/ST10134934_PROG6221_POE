using System;

namespace ST10134934_PROG6221_PartThree
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

        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            calTotalAmount += amount;
            CheckCalories();
        }

        protected virtual void OnCaloriesExceeded(EventArgs e)
        {
            CaloriesExceeded?.Invoke(this, e);
        }

        private void CheckCalories()
        {
            if (calTotalAmount > 300)
                OnCaloriesExceeded(EventArgs.Empty);
        }
    }
}
