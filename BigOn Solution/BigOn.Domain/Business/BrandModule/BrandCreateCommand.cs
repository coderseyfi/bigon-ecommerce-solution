using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BrandModule
{
    public class BrandCreateCommand : IRequest<Brand>
    {
        public string Name { get; set; }
        public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Brand>
        {
            private readonly BigOnDbContext db;

            public BrandCreateCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }
           

            public async Task<Brand> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new Brand();
                model.Name = request.Name;

               await db.Brands.AddAsync(model, cancellationToken);
               await db.SaveChangesAsync(cancellationToken);

                return model;
            }
        }
    }
}
