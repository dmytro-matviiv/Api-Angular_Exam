using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_927.API_Angular.Helper;
using Project_927.DataAccess;
using Project_927.DTO.Market;
using Project_927.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_927.API_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : ControllerBase
    {
        EFContext _context;

        public AdminPanelController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IQueryable<ProductDTO> GetProducts()
        {
            var data = _context.Products.Select(t => new ProductDTO
            {
                 Id = t.Id,
                 Color=t.Color,
                 Details=t.Details,
                 Name=t.Name,
                 Price=t.Price,
                 Size =t.Size,
                 URL_Image=t.URL_Image
            });

            return data;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResultDTO addProduct([FromBody] AddProductDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.getErrorsByModelState(ModelState)
                };
            }

            _context.Products.Add(new Product
            {
                Color = model.Color,
                Details = model.Details,
                Name = model.Name,
                Price = model.Price,
                Size = model.Size,
                URL_Image = model.URL_Image
            });

            _context.SaveChanges();

            return new ResultDTO
            {
                Code = 200,
                Message = "Success!"
            };
        }
    }
}
