using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using PurchaseApi.Controllers;
using PurchaseApi.Services;

namespace Tests
{
    public class ProductControllerTest
    {
        [Theory, AutoNSubstituteData]
        public void Get_ReturnsAllProducts([Frozen] IDataProviderService dataProvider, [Frozen] ProductsController sut)
        {
            dataProvider.GetProducts().Returns(new List<string>() { "1", "2" });

            sut.Get().Should().Contain("1").And.Contain("2").And.HaveCount(2);
        }

        [Theory, AutoNSubstituteData]
        public void GetWithIndex_ReturnsCorrectProduct([Frozen] IDataProviderService dataProvider, [Frozen] ProductsController sut, [Frozen] string expected)
        {
            dataProvider.GetProduct(Arg.Any<int>()).Returns(expected);

            sut.Get(1).Should().Be(expected);
        }

        [Theory, AutoNSubstituteData]
        public void Create_ReturnsCreatedProduct([Frozen] IDataProviderService dataProvider, [Frozen] ProductsController sut, [Frozen] string expected)
        {
            dataProvider.CreateProduct(expected).Returns(expected);

            sut.Create(expected).Should().Be(expected);
        }

        [Theory, AutoNSubstituteData]
        public void Create_CallsCreateProductOfService([Frozen] IDataProviderService dataProvider, [Frozen] ProductsController sut, [Frozen] string newValue)
        {
            sut.Create(newValue);

            dataProvider.Received(1).CreateProduct(newValue);
        }
        [Theory, AutoNSubstituteData]
        public void Update_ReturnsUpdatedProduct([Frozen] IDataProviderService dataProvider, [Frozen] ProductsController sut, [Frozen] int index, [Frozen] string expected)
        {
            dataProvider.UpdateProduct(index, expected).Returns(expected);

            sut.Update(index, expected).Should().Be(expected);
        }

        [Theory, AutoNSubstituteData]
        public void Update_CallsUpdateProductOfService([Frozen] IDataProviderService dataProvider, [Frozen] ProductsController sut, [Frozen] int index, [Frozen] string newValue)
        {
            sut.Update(index, newValue);

            dataProvider.Received(1).UpdateProduct(index, newValue);
        }

        [Theory, AutoNSubstituteData]
        public void Delete_CallsUpdateProductOfService([Frozen] IDataProviderService dataProvider, [Frozen] ProductsController sut, [Frozen] int index)
        {
            sut.Delete(index);

            dataProvider.Received(1).DeleteProduct(index);
        }
    }
}
