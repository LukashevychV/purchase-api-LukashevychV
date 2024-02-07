using FluentAssertions;
using NSubstitute;
using PurchaseApi.Models;
using PurchaseApi.Services;

namespace Tests
{
    public class ShipmentServiceTest
    {
        [Theory, MemberData(nameof(GetTestData))]
        public void Ship_ReturnsCorrectString(AddressInfo addressInfo, decimal totalSum, int totalQuantity, string expected)
        {
            ICartService cartService = Substitute.For<ICartService>();
            cartService.TotalQuantity(Arg.Any<IEnumerable<CartItem>>()).Returns(totalQuantity);
            cartService.TotalSum(Arg.Any<IEnumerable<CartItem>>()).Returns(totalSum);
            ShipmentService shipmentService = new(cartService);

            shipmentService.Ship(addressInfo, new List<CartItem>()).Should().Be(expected);
        }


        public static IEnumerable<object[]> GetTestData()
        {
            AddressInfo addressInfo1 = new("Shevchenka", "149", "Lviv", "12345", "344344");
            yield return new object[] { addressInfo1, 1000.05m, 2, "Shipped 2 items to  Lviv on total sum 1000.05$" };

            AddressInfo addressInfo2 = new("Shevchenka", "149", "Chernivtsi", "12345", "344344");
            yield return new object[] { addressInfo2, 2000.50m, 5, "Shipped 5 items to  Chernivtsi on total sum 2000.50$" };
        }
    }
}
