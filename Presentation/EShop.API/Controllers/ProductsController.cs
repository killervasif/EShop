using EShop.Application.Features.Commands.Products.AddProduct;
using EShop.Application.Features.Commands.Products.DeleteProduct;
using EShop.Application.Features.Commands.Products.UpdateProduct;
using EShop.Application.Features.Queries.Products.GetAllProducts;
using EShop.Application.Features.Queries.Products.GetProductById;
using EShop.Application.Paginations;
using EShop.Application.Repositories.ProductRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetProductsQueryRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] GetProductByIdQueryRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await mediator.Send(request);
                    return StatusCode((int)HttpStatusCode.Created);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromQuery] UpdateProductCommandRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductCommandRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
