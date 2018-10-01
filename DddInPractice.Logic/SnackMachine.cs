namespace DddInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; }
        public Money MoneyInTransaction { get; private set; }

        public int OneCentCountInTransaction { get; private set; }
        public int TenCentCountInTransaction { get; private set; }
        public int QuarterCountInTransaction { get; private set; }
        public int OneDollarCountInTransaction { get; private set; }
        public int FiveDollarCountInTransaction { get; private set; }
        public int TwentyDollarCountInTransaction { get; private set; }

        public void InsertMoney(
            Money money
        )
        {
            MoneyInTransaction = money;
        }

        public void ReturnMoney()
        {
            //MoneyInTransaction = 0;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;

            //MoneyInTransaction = 0;
        }

    }
}
