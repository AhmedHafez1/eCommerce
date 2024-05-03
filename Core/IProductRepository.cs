﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IProductRepository
    {
        Task<Product?> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
