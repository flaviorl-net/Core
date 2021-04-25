# Core

Projeto possui interfaces para implementar os patterns repository, specification, service domain. Possui duas versões da interface IRepositoy.

## Installation

Utilize o pacote do nuget [Core.Domain](https://www.nuget.org/packages/Core.Domain) para instalar.

```nuget
Install-Package Core.Domain -Version 2.1.1
```
or
```nuget
dotnet add package Core.Domain --version 2.1.1
```

## Usage

#### Entity
```c#
using Core.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyName.ProductName.Domain.Entities
{
    public class CustomerEntity : Entity
    {
        [Key]
        public int ID { get; set; }
        
        //your client properties
        
        public override Core.Domain.ValidationResult IsValid()
        {
            var validation = new Validation.CustomerValidation();
            return validation.Validate(this);
        }
    }
}
```

#### Repository Interface
```c#
using Core.Domain;
using CompanyName.ProductName.Domain.Entities;

namespace CompanyName.ProductName.Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
    }
}
```

#### Service Domain Interface
```c#
using Core.Domain;
using CompanyName.ProductName.Domain.Entities;

namespace CompanyName.ProductName.Domain.Interfaces.Services
{
    public interface ICustomerService : IService<CustomerEntity>
    {
    }
}
```

#### Repository
```c#
using Core.Infra;
using CompanyName.ProductName.Domain.Entities;
using CompanyName.ProductName.Domain.Interfaces.Repository;
using CompanyName.ProductName.Infra.Data.Context;

namespace CompanyName.ProductName.Infra.Data.Repositories
{
    public class CustomerRepository : Repository<CustomerEntity, ProdDbContext>, ICustomerRepository
    {
        public CustomerRepository(ProdDbContext db) 
          : base(db) { }
    }
}
```

#### Service Domain
```c#
using Core.Domain;
using CompanyName.ProductName.Domain.Entities;
using CompanyName.ProductName.Domain.Interfaces.Repository;
using CompanyName.ProductName.Domain.Interfaces.Services;

namespace CompanyName.ProductName.Domain.Services
{
    public class CustomerService : Service<CustomerEntity>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
            : base(cadastroFormularioCampoRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
```

#### Validation Domain
```c#
using Core.Domain;
using Funcional.ProgramaIndustria.Domain.Entities;
using Funcional.ProgramaIndustria.Domain.Validation.Customer;

namespace Funcional.ProgramaIndustria.Domain.Validation
{
    public class CustomerValidation : FiscalBase<CustomerEntity>
    {
        public CustomerValidation()
        {
            var nameValidation = new NameValidation();

            base.AddRule("nameValidation", new Rule<CustomerEntity>(nameValidation, "Invalid customer name"));
        }
    }
}
```

#### Name Customer Validation
```c#
using Core.Domain;
using Funcional.ProgramaIndustria.Domain.Entities;

namespace Funcional.ProgramaIndustria.Domain.Validation.Customer
{
    public class ValidarNome : ISpecification<CustomerEntity>
    {
        public bool IsSatisfiedBy(CustomerEntity customerEntity)
        {
            //your validation
            return true;
        }
    }
}
```


## Licenses

MIT license.
