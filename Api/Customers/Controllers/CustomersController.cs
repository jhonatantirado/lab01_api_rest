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
using EnterprisePatterns.Api.Users;
using EnterprisePatterns.Api.Projects;
using EnterprisePatterns.Api.Users.Domain.Repository;
using EnterprisePatterns.Api.Projects.Domain.Repository;
using Common.Application;

namespace EnterprisePatterns.Api.Controllers
{
    [Route("v1/customers")]
    [ApiController]
    public class CustomersController: ControllerBase{
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly CustomerAssembler _customerAssembler;

        public CustomersController(IUnitOfWork unitOfWork, 
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            CustomerAssembler customerAssembler)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
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

        [Route("signup")]
        [HttpPost]
        public IActionResult Create([FromBody] SignUpDto signUpDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();

                Customer customer = new Customer();
                customer.OrganizationName = signUpDto.OrganizationName;
                notification = customer.validateForSave();

                if(notification.hasErrors())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, notification.ToString());
                }

                _customerRepository.Create(customer);

                User user = new User();
                user.Username = signUpDto.Username;
                user.Password = signUpDto.Password;
                user.RoleId = (long) Role.Owner;
                user.Customer = customer;
                _userRepository.Create(user);

                Project project = new Project();
                project.ProjectName = signUpDto.ProjectName;
                project.Customer = customer;
                project.Budget = signUpDto.Budget;
                project.CurrencyId = (long) Currency.EUR;
                _projectRepository.Create(project);

                _unitOfWork.Commit(uowStatus);
                return StatusCode(StatusCodes.Status201Created, new ApiStringResponseDto("Customer, user and project created!"));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));

            }
        }

    }

    public enum Role
    {
        Owner = 1,
        Supervisor = 2 ,
        Assistant = 3,

    }

    public enum Currency
    {
        PEN = 1,
        USD = 2,
        EUR = 3,

    }

}