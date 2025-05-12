using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.DTO;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        List<ProductWithCategoryDto> IProductDal.GetProductsWithCategory()
        {
            var context = new AppDbContext();
            var values = context.Products.Select(x => new ProductWithCategoryDto()
            {
               Id = x.Id,
               ProductName = x.ProductName,
               ProductStock = x.ProductStock,
               Price = x.Price,
               Description = x.Description,
               CategoryName = x.Category.CategoryName
            }).ToList();
            return values;
        }
    }
}
