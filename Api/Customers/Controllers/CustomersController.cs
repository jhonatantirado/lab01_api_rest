using Microsoft.AspNetCore.Mvc;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using EnterprisePatterns.Api.Customers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Assembler;
namespace EnterprisePatterns.Api.Controllers{
    [Route("v1/customers")]
    [ApiController]
    public class CustomersController: ControllerBase{
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerAssembler _customerAssembler;

        public CustomersController(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, CustomerAssembler customerAssembler){
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _customerAssembler = customerAssembler;
        }

        [HttpGet]
        public IActionResult Customers([FromQuery] int page = 0, [FromQuery] int size = 5){
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                List<Customer> customers = _customerRepository.GetList(page,size);
                _unitOfWork.Commit(uowStatus);
                List<CustomerDto> customersDto = _customerAssembler.toDtoList(customers);
                return StatusCode(StatusCodes.Status200OK, customersDto);
            } catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }

        }

    }

}