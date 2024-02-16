using CaseCrud.Domain.Entities;
using CaseCrud.Domain.Interfaces;
using CaseCRUD.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CaseCRUD.Tests
{
    public class PessoaFisicaControllerTests
    {
        [Fact]
        public async Task GetPessoasFisicas_ShouldReturnOk()
        {
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.GetPessoasFisicas())
                       .ReturnsAsync(new List<PessoaFisica> { new PessoaFisica() });

            var controller = new PessoaFisicaController(mockService.Object);

            var result = await controller.GetPessoasFisicas();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<PessoaFisica>>(okResult.Value);
            Assert.Single(model);
        }

        [Fact]
        public async Task GetPessoaFisicaById_WithValidId_ShouldReturnOk()
        {
            var id = 1;
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.GetPessoaFisicaById(id))
                       .ReturnsAsync(new PessoaFisica { Id = id });

            var controller = new PessoaFisicaController(mockService.Object);

            var result = await controller.GetPessoaFisicaById(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<PessoaFisica>(okResult.Value);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task GetPessoaFisicaById_WithInvalidId_ShouldReturnNotFound()
        {
            var id = 1;
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.GetPessoaFisicaById(id))
                       .ReturnsAsync((PessoaFisica)null);

            var controller = new PessoaFisicaController(mockService.Object);

            var result = await controller.GetPessoaFisicaById(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddPessoaFisica_WithValidModel_ShouldReturnCreatedAtAction()
        {
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.AddPessoaFisica(It.IsAny<PessoaFisica>()))
                       .ReturnsAsync(1);

            var controller = new PessoaFisicaController(mockService.Object);
            var pessoa = new PessoaFisica();

            var result = await controller.AddPessoaFisica(pessoa);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(controller.GetPessoaFisicaById), createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task UpdatePessoaFisica_WithValidModel_ShouldReturnNoContent()
        {
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.UpdatePessoaFisica(It.IsAny<PessoaFisica>()))
                       .ReturnsAsync(true);

            var controller = new PessoaFisicaController(mockService.Object);
            var pessoa = new PessoaFisica { Id = 1 };

            var result = await controller.UpdatePessoaFisica(1, pessoa);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdatePessoaFisica_WithInvalidModel_ShouldReturnNotFound()
        {
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.UpdatePessoaFisica(It.IsAny<PessoaFisica>()))
                       .ReturnsAsync(false);

            var controller = new PessoaFisicaController(mockService.Object);
            var pessoa = new PessoaFisica { Id = 1 };


            var result = await controller.UpdatePessoaFisica(1, pessoa);


            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeletePessoaFisica_WithValidId_ShouldReturnNoContent()
        {
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.DeletePessoaFisica(It.IsAny<int>()))
                       .ReturnsAsync(true);

            var controller = new PessoaFisicaController(mockService.Object);

            var result = await controller.DeletePessoaFisica(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeletePessoaFisica_WithInvalidId_ShouldReturnNotFound()
        {
            var mockService = new Mock<IPessoaFisicaService>();
            mockService.Setup(service => service.DeletePessoaFisica(It.IsAny<int>()))
                       .ReturnsAsync(false);

            var controller = new PessoaFisicaController(mockService.Object);

            var result = await controller.DeletePessoaFisica(1);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
