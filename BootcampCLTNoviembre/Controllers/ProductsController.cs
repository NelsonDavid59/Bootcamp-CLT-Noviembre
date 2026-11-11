using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using BootcampCLTNoviembre.Entities;
using BootcampCLTNoviembre.Services;
using BootcampCLTNoviembre.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BootcampCLTNoviembre.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        private static int _nextId = 2;

        [HttpGet]
        [ProducesResponseType<IEnumerable<ProductDTO>>(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<ProductDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDTO> GetById(int id)
        {
            var product = _productService.GetById(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        [ProducesResponseType<ProductDTO>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductDTO> Create(ProductDTO product)
        {
            try
            {
                var savedProduct = _productService.Save(product);
                return savedProduct;
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
