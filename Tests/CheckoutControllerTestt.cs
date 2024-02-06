using FluentAssertions;
using NSubstitute;
using PurchaseApi.Controllers;
using PurchaseApi.Models;
using PurchaseApi.Services;

namespace Tests
{
    public class CheckoutControllerTest
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void ConductCheckout_WhanPaymentSuccessful_ShipIsCalled(
            AddressInfo addressInfo,
            IEnumerable<CartItem> cartItems)
        {
            ICartService cartService = Substitute.For<ICartService>();
            IPaymentService paymentService = Substitute.For<IPaymentService>();
            IShipmentService shipmentService = Substitute.For<IShipmentService>();
            paymentService.Charge(Arg.Any<decimal>(), Arg.Any<Card>()).Returns(true);
            CheckoutController checkoutController = new CheckoutController(cartService, paymentService, shipmentService);

            checkoutController.ConductCheckout(
                new Cart(new Card(string.Empty, string.Empty, DateTime.MaxValue), addressInfo, cartItems));

            shipmentService.Received(1).Ship(addressInfo, cartItems);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void ConductCheckout_WhanPaymentSuccessful_ReturnsResultOfShipment(
            AddressInfo addressInfo,
            IEnumerable<CartItem> cartItems)
        {
            ICartService cartService = Substitute.For<ICartService>();
            IPaymentService paymentService = Substitute.For<IPaymentService>();
            IShipmentService shipmentService = Substitute.For<IShipmentService>();
            paymentService.Charge(Arg.Any<decimal>(), Arg.Any<Card>()).Returns(true);
            string result = "Shipped";
            shipmentService.Ship(Arg.Any<AddressInfo>(), Arg.Any<IEnumerable<CartItem>>()).Returns(result);
            CheckoutController checkoutController = new CheckoutController(cartService, paymentService, shipmentService);

            string actual = checkoutController.ConductCheckout(
                new Cart(new Card(string.Empty, string.Empty, DateTime.MaxValue), addressInfo, cartItems));

            actual.Should().Be(result);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void ConductCheckout_WhanPaymentUnsuccessful_ShipIsNotCalled(
            AddressInfo addressInfo,
            IEnumerable<CartItem> cartItems)
        {
            ICartService cartService = Substitute.For<ICartService>();
            IPaymentService paymentService = Substitute.For<IPaymentService>();
            IShipmentService shipmentService = Substitute.For<IShipmentService>();
            paymentService.Charge(Arg.Any<decimal>(), Arg.Any<Card>()).Returns(false);
            CheckoutController checkoutController = new CheckoutController(cartService, paymentService, shipmentService);

            checkoutController.ConductCheckout(
                new Cart(new Card(string.Empty, string.Empty, DateTime.MaxValue), addressInfo, cartItems));


            shipmentService.Received(0).Ship(Arg.Any<AddressInfo>(), Arg.Any<IEnumerable<CartItem>>());
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void ConductCheckout_WhanPaymentUnsuccessful_NotChargedTextIsReturned(
            AddressInfo addressInfo,
            IEnumerable<CartItem> cartItems)
        {
            ICartService cartService = Substitute.For<ICartService>();
            IPaymentService paymentService = Substitute.For<IPaymentService>();
            IShipmentService shipmentService = Substitute.For<IShipmentService>();
            paymentService.Charge(Arg.Any<decimal>(), Arg.Any<Card>()).Returns(false);
            CheckoutController checkoutController = new CheckoutController(cartService, paymentService, shipmentService);

            string actual = checkoutController.ConductCheckout(
                new Cart(new Card(string.Empty, string.Empty, DateTime.MaxValue), addressInfo, cartItems));


            actual.Should().Be("not charged");
        }

        public static IEnumerable<object[]> GetTestData()
        {
            AddressInfo addressInfo1 = new("Shevchenka", "149", "Lviv", "12345", "344344");
            IEnumerable<CartItem> cartItems1 = new List<CartItem>
            {
                new CartItem("Hoover", 1, 300.0m),
                new CartItem("TV", 2, 400.0m),
                new CartItem("Washing machine", 1, 450m),
            };
            yield return new object[] { addressInfo1, cartItems1 };

            AddressInfo addressInfo2 = new("Shevchenka", "149", "Chernivtsi", "12345", "344344");
            IEnumerable<CartItem> cartItems2 = new List<CartItem>
            {
                new CartItem("Hoover", 1, 300.0m),
                new CartItem("TV", 2, 400.0m),
                new CartItem("Washing machine", 1, 450m),
            };
            yield return new object[] { addressInfo2, cartItems2 };
        }
    }
}