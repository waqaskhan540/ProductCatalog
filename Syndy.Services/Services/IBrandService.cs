using Syndy.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Syndy.Services.Services
{
    public interface IBrandService
    {
        List<ProductDto> GetProductsByBrand(int brandId);
        
    }
}
