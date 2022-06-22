using ApiCompetencia.Controllers;
using ApiCompetencia.Models;
using ApiCompetencia.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPUnitTesting
{
    public class ProyectoTesteo
    {
        private readonly TestController _controller;
        private readonly ITestService _service;

        public ProyectoTesteo()
        {
            //context = new AppDbContext();
            _service = new TestService();
            _controller = new TestController(_service);
        }

        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity()
        {
            var result = (OkObjectResult)_controller.Get();

            var test = Assert.IsType<List<Categoria_BD>>(result.Value);
            Assert.True(test.Count > 0);
        }

        [Fact]
        public void GetById_Ok()
        {
            int id = 2;

            var result = _controller.GetById(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Exists()
        {
            int id = 2;

            var result = (OkObjectResult)_controller.GetById(id);

            var test = Assert.IsType<Categoria_BD>(result?.Value);
            Assert.True(test!= null);
            Assert.Equal(test?.id, id);
        }

        [Fact]
        public void GetById_NotFound()
        {
            int id = 11;

            var result = _controller.GetById(id);

            var test = Assert.IsType<NotFoundResult>(result);
        }
    }
}