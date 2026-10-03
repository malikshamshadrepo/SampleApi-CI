using Microsoft.AspNetCore.Mvc;
using SampleApi.Controllers;
using SampleApi.Models;

namespace SimpleApi.Tests;

public class ProductsControllerTests
{
    [Test]
    public void GetProducts_ReturnsOkResult()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.GetProducts();

        // Assert
        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetProduct_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.GetProduct(1);

        // Assert
        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetProduct_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.GetProduct(999);

        // Assert
        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void GetProduct_ExistingId_ReturnsCorrectProduct()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.GetProduct(1);

        // Assert
        var okResult = result.Result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);

        var product = okResult!.Value as Product;

        Assert.That(product, Is.Not.Null);
        Assert.That(product!.Id, Is.EqualTo(1));
        Assert.That(product.Name, Is.EqualTo("Laptop"));
        Assert.That(product.Price, Is.EqualTo(75000));
    }
}