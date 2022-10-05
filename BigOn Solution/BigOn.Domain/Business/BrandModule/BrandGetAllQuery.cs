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
  public class BrandGetAllQuery : IRequest<List<Brand>>
    {

        public class BrandGetAllQueryHandler : IRequestHandler<BrandGetAllQuery, List<Brand>>
        {
            private readonly BigOnDbContext db;

            public BrandGetAllQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Brand>> Handle(BrandGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Brands.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data; //async yazmasag task qaytarmali olacagdiq
                //ikisi birden ishliyir oz cavabini gozleyir
            }
        }
    }
}
