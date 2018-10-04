﻿using EnterprisePatterns.Api.Customers;
using System.Collections.Generic;
namespace EnterprisePatterns.Api.Customers.Domain.Repository
{
    public interface ICustomerRepository
    {
            List<Customer> GetList(
            int page = 0,
            int pageSize = 5);
    }
}
