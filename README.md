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
    public class ClienteEntity : Entity
    {
        [Key]
        public int ID { get; set; }
        
        //your client properties
        
        public override Core.Domain.ValidationResult IsValid()
        {
            return new Core.Domain.ValidationResult();
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
    public interface IClienteRepository : IRepository<ClienteEntity>
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
    public interface IClienteService : IService<ClienteEntity>
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
    public class ClienteRepository : Repository<ClienteEntity, ProdDbContext>, IClienteRepository
    {
        public ClienteRepository(ProdDbContext db) 
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
    public class ClienteService : Service<ClienteEntity>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
            : base(cadastroFormularioCampoRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
```

## Licenses

MIT license.
