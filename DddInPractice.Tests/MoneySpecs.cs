using DddInPractice.Logic;
using FluentAssertions;
using System;
using Xunit;

namespace DddInPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void sum_of_two_money_produces_correct_result()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money sum = money1 + money2;

            //Assert.Equal(2, sum.OneCentCount);
            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }

        [Fact]
        public void Two_money_instances_do_not_equal_if_contain_different_money_amount()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            //money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void Two_money_instances_do_not_equal_if_contain_different_money_amounts()
        {
            Money money1 = new Money(0, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().NotBe(money2);
            money1.GetHashCode().Should().NotBe(money2.GetHashCode());
        }

        [Theory]
        [InlineData(-1, 2, 3, 4, 5, 6)]
        [InlineData(1, -2, 3, 4, 5, 6)]
        [InlineData(1, 2, -3, 4, 5, 6)]
        [InlineData(1, 2, 3, -4, 5, 6)]
        [InlineData(1, 2, 3, 4, -5, 6)]
        [InlineData(-1, 2, 3, 4, 5, -6)]
        public void Cannot_create_money_with_negative_value(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount
        )
        {
            Action action = () => new Money(oneCentCount, tenCentCount, quarterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            action.ShouldThrow<InvalidOperationException>();
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 0, 0.01, 0.01)]
        [InlineData(1, 2, 0, 0, 0, 0.21, 0.21)]
        //[InlineData(1, 2, 3, -4, 5, 6)]
        //[InlineData(1, 2, 3, 4, -5, 6)]
        //[InlineData(-1, 2, 3, 4, 5, -6)]
        public void Amount_is_calculated_correctly(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            int expectedAmount
        )
        {
            Money money
                = new Money(oneCentCount, tenCentCount, quarterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);

            money.Amount.ShouldBeEquivalentTo(expectedAmount);
        }

        [Fact]
        public void Substraction_of_two_moneys_produces_correct_result()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money result = money1 - money2;

            result.OneCentCount.Should().Be(0);
            result.TenCentCount.Should().Be(0);
            result.QuarterCount.Should().Be(0);
            result.OneDollarCount.Should().Be(0);
            result.FiveDollarCount.Should().Be(0);
            result.TwentyDollarCount.Should().Be(0);
        }

        [Fact]
        public void Cannot_substract_more_than_exists()
        {
            Money money1 = new Money(0, 1, 0, 0, 0, 0);
            Money money2 = new Money(1, 0, 0, 0, 0, 0);

            Action action = () =>
            {
                Money money = money1 - money2;
            };

            action.ShouldThrow<InvalidOperationException>();
        }
    }
}
