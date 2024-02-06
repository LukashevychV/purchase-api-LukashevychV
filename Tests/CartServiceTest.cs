using FluentAssertions;
using PurchaseApi.Models;
using PurchaseApi.Services;

namespace Tests
{
    public class CartServiceTest
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TotalSum_ProvidedColection_ReturnsSum(IEnumerable<CartItem> items, int _, decimal expectedSum)
        {
            CartService cartService = new();

            cartService.TotalSum(items).Should().Be(expectedSum);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TotalQuantity_ProvidedColection_ReturnsQuantity(IEnumerable<CartItem> items, int expectedQuantity, decimal _)
        {
            CartService cartService = new();

            cartService.TotalQuantity(items).Should().Be(expectedQuantity);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            var testCase1 = new List<CartItem> {
                new CartItem("Hoover", 1, 300.0m),
                new CartItem("TV", 2, 400.0m),
                new CartItem("Washing machine", 1, 450m),
            };

            yield return new object[] { testCase1, 4, 1550m };

            var testCase2 = new List<CartItem> {
                new CartItem("Hoover", 2, 300.0m),
                new CartItem("TV", 2, 400.0m),
                new CartItem("Washing machine", 1, 450m),
            };

            yield return new object[] { testCase2, 5, 1850m };

            var testCase3 = new List<CartItem> {
                new CartItem("Hoover", 3, 300.15m),
                new CartItem("TV", 2, 400.0m),
            };

            yield return new object[] { testCase3, 5, 1700.45m };
        }
    }
}