using AutoFixture;
using FluentAssertions;
using SpecificationDemo.Features.Feature1.Models;

namespace SpecificationDemo.UnitTests.Features.Feature1;

public class OrderTests
{
    private readonly Fixture fixture = new();
    
    [Fact]
    public void IsRushOrder_BadExample_ShouldBeTrue()
    {
        // Arrange
        var mockedOrder = MockOrder(
            "ESP",
            false,
            true,
            150);
        
        // Act
        var isRushOrder = mockedOrder.IsRushOrderBadExample();
        
        // Assert
        isRushOrder.Should().BeTrue();
    }

    [Fact]
    public void IsRushOrder_GoodExample_ShouldBeTrue()
    {
        // Arrange
        var mockedOrder = MockOrder(
            "ESP",
            false,
            true,
            150);
        
        // Act
        var isRushOrder = mockedOrder.IsRushOrderGoodExample();
        
        // Assert
        isRushOrder.Should().BeTrue();
    }
    
    private Order MockOrder(
        string shippingCountry,
        bool shouldContainHazardousMaterial,
        bool shouldBeInStock,
        int orderTotal)
    {
        var items = fixture
            .Build<Product>()
            .With(x => x.ContainsHazardousMaterial, shouldContainHazardousMaterial)
            .With(x => x.IsInStock, shouldBeInStock)
            .CreateMany(10)
            .ToList();

        var order = fixture
            .Build<Order>()
            .With(x => x.ShippingAddress, new Address() {Country = shippingCountry})
            .With(x => x.Total, orderTotal)
            .With(x => x.Items, items)
            .Create();

        return order;
    }
}