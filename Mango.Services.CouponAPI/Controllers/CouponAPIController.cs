﻿using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    //[Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto { get; set; }
        private IMapper _mapper { get; set; }
        public CouponAPIController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Coupon> objList = _db.Coupons.ToList();                
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList); ;               
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
                Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                _responseDto.Result = _mapper.Map<CouponDto>(obj);                 
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto Get(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First( u => u.CouponCode.ToLower() == code.ToLower());               
                _responseDto.Result = _mapper.Map<CouponDto>(obj);
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
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);
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
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);
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
                Coupon obj = _db.Coupons.First(u=>u.CouponId == id);
                _db.Coupons.Remove(obj);
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
