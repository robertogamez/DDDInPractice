using System;
using System.Linq;

namespace DddInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public SnackMachine()
        {
            MoneyInside = Money.None;
            MoneyInTransaction = Money.None;
        }

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
            Money[] coinsAndNotes =
            {
                Money.Cent,
                Money.TenCent,
                Money.Quarter,
                Money.Dollar,
                Money.FiveDollar,
                Money.TwentyDollar
            };

            if (!coinsAndNotes.Contains(money))
            {
                throw new InvalidOperationException();
            }

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = Money.None;
        }

    }
}
