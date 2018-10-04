using System;

namespace EnterprisePatterns.Api.Customers.Application.Dto
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber {get; set;}
        public bool IsActive {get; set;}

    }
}
