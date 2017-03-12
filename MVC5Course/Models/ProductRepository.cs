using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public Product Find(int? ProductId)
        {
            return this.All().FirstOrDefault(o=>o.ProductId == ProductId);
        }

        public override IQueryable<Product> All()
        {
            return base.All().Where(o=>o.Stock<500 && o.IsDeleted == false);
        }

        public  IQueryable<Product> All(bool IsShowAll)
        {
            if(IsShowAll)
                return base.All();
            else
                return this.All();
        }
        public override void Delete(Product entity)
        {
            entity.IsDeleted = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}