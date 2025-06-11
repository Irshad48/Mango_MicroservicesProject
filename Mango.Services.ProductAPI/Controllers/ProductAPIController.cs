using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto { get; set; }
        private IMapper _mapper { get; set; }
        public ProductAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            if (_responseDto == null)
                _responseDto = new ResponseDto();
           
        }

        [HttpGet]
        public ResponseDto Get() {
            try
            {
                IEnumerable<Product> objList = _db.Products.ToList();                
                _responseDto.Result = _mapper.Map<IEnumerable<ProductDto>>(objList); ;               
            }
            catch (Exception ex) { 
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product obj = _db.Products.First(u=>u.ProductId==id);
                _responseDto.Result = _mapper.Map<ProductDto>(obj);                 
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public ResponseDto Get(string name)
        {
            try
            {
                Product obj = _db.Products.First( u => u.Name.ToLower() == name.ToLower());               
                _responseDto.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductDto productDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(productDto);
                _db.Products.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto productDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(productDto);
                _db.Products.Update(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product obj = _db.Products.First(u=>u.ProductId == id);
                _db.Products.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
    }
}
