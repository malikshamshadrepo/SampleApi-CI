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
    public void DeleteProduct_ExistingId_ReturnsNoContent()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.DeleteProduct(1);

        // Assert
        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public void DeleteProduct_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.DeleteProduct(999);

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }
}