using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using WebApplication1.Controllers;
using WebApplication1.Domain;
using Xunit;

namespace Books.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public async void Get_Success()
        {
            //Arrange
            var books = new Book[]
            {
                new Book(),
                new Book()
            };

            Mock<IBooksRepository> repositoryMock = new Mock<IBooksRepository>();
            repositoryMock.Setup(x => x.GetBooks()).ReturnsAsync(books);
            Mock<IBookFactory> factoryMock = new Mock<IBookFactory>();
            Mock<ILogger<BooksController>> loggerMock = new Mock<ILogger<BooksController>>();

            var booksController = new BooksController(
                repositoryMock.Object,
                factoryMock.Object,
                loggerMock.Object);

            //Act
            var result = await booksController.Get();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultAsArray = Assert.IsType<Book[]>(okResult.Value);
            Assert.Equal(2, resultAsArray.Length);
        }

        [Fact]
        public async void Get_ReturnsEmptyArray_RepositoryReturnsNull()
        {
            //Arrange
            Mock<IBooksRepository> repositoryMock = new Mock<IBooksRepository>();
            repositoryMock.Setup(x => x.GetBooks()).ReturnsAsync(null as Book[]);
            Mock<IBookFactory> factoryMock = new Mock<IBookFactory>();
            Mock<ILogger<BooksController>> loggerMock = new Mock<ILogger<BooksController>>();

            var booksController = new BooksController(
                repositoryMock.Object,
                factoryMock.Object,
                loggerMock.Object);

            //Act
            var result = await booksController.Get();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultAsArray = Assert.IsType<Book[]>(okResult.Value);
            Assert.Equal(0, resultAsArray.Length);
        }

        [Fact]
        public async void Get_Returns500StatusCode_RepositoryThrows()
        {
            //Arrange
            Mock<IBooksRepository> repositoryMock = new Mock<IBooksRepository>();
            repositoryMock.Setup(x => x.GetBooks()).ThrowsAsync(new Exception("Big exception"));
            Mock<IBookFactory> factoryMock = new Mock<IBookFactory>();
            Mock<ILogger<BooksController>> loggerMock = new Mock<ILogger<BooksController>>();

            var booksController = new BooksController(
                repositoryMock.Object,
                factoryMock.Object,
                loggerMock.Object);

            //Act
            var result = await booksController.Get();

            //Assert
            var scResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, scResult.StatusCode);
            Assert.Equal("Îøèáêà", scResult.Value);
            //loggerMock.Verify(x => x.LogError(It.IsAny<string>()));
        }
    }
}
