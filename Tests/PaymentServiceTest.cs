using FluentAssertions;
using PurchaseApi.Models;
using PurchaseApi.Services;

namespace Tests
{
    public class PaymentServiceTest
    {
        [Theory]
        [MemberData(nameof(GetValidCard))]
        public void Charge_ValidCard_ReturnsTrue(Card card)
        {
            PaymentService paymentService = new();
            const decimal chargeAmount = 100;

            paymentService.Charge(chargeAmount, card).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(GetInvalidCard))]
        public void Charge_InvalidCard_ReturnsFalse(Card card)
        {
            PaymentService paymentService = new();
            const decimal chargeAmount = 100;

            paymentService.Charge(chargeAmount, card).Should().BeFalse();
        }

        public static IEnumerable<object[]> GetValidCard()
        {
            Card card = new("123456789", "Ihor Pertenko", DateTime.Now + TimeSpan.FromDays(1));

            yield return new object[] { card };
        }

        public static IEnumerable<object[]> GetInvalidCard()
        {
            Card card = new("123456789", "Ihor Pertenko", DateTime.Now - TimeSpan.FromDays(1));

            yield return new object[] { card };
        }
    }
}