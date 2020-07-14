using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.BL.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IDescriptionValidator _descriptionValidator;
        private readonly INameValidator _nameValidator;

        public ProductController(IProductService productService,
            IAuthorizationService authorizationService,
            IDescriptionValidator descriptionValidator,
            INameValidator nameValidator)
        {
            _productService = productService;
            _authorizationService = authorizationService;
            _descriptionValidator = descriptionValidator;
            _nameValidator = nameValidator;
        }

        [HttpPost]
        public async Task<ProductInsertResponse> UpsertAsync([FromBody] ProductInsertRequest request)
        {
            string authorizationHeader = HttpContext.Request.Headers["Authorization"];

            var authorizationResult = await _authorizationService.CheckAuthorizationAsync(authorizationHeader);

            if (authorizationResult.Authorized == false)
            {
                return new ProductInsertResponse
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Data = new InsertProductResponseData(),
                    Message = $"Unauthorized User error"
                };
            }

            var nameValidate = await _nameValidator.ValidateAsync(request.Name);

            var descriptionValidate = await _descriptionValidator.ValidateAsync(request.Description);

            if (!nameValidate || !descriptionValidate)
            {
                return new ProductInsertResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = new InsertProductResponseData(),
                    Message = $"Bad request error"
                };
            }  

            var product = await _productService.AddNewProduct(request.Name, request.Description);

            return new ProductInsertResponse()
            {
                Message = "Ok",
                Data = new InsertProductResponseData
                {
                    Description = product.Description,
                    Name = product.Name,
                    Id = product.Id
                },
                StatusCode = (int)HttpStatusCode.Created
            };

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductByIdResponse>> GetProductByIdAsync(long id)
        {
            var res = await _productService.GetProductForAllUsers(id);

            return new GetProductByIdResponse
            {
                Description = res.Description,
                ProductName = res.Name

            };
        }
    }
}