using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductModul.Models;

namespace ProductModul.Services
{
    public sealed class ProductService : IProductService
    {
        private List<IProduct> _products = new List<IProduct>
            {
                new Product{Id = 0, Name = "Product A", Description = "That is product A."},
                new Product{Id = 1, Name = "Product B", Description = "That is product B."},
                new Product{Id = 2, Name = "Product C", Description = "That is product C."},
                new Product{Id = 3, Name = "Product D", Description = "That is product D."},
                new Product{Id = 4, Name = "Product E", Description = "That is product E."},
                new Product{Id = 5, Name = "Product F", Description = "That is product F."},
                new Product{Id = 6, Name = "Product G", Description = "That is product G."},
                new Product{Id = 7, Name = "Product H", Description = "That is product H."},
                new Product{Id = 8, Name = "Product I", Description = "That is product I."},
                new Product{Id = 9, Name = "Product J", Description = "That is product J."},
                new Product{Id = 10, Name = "Product K", Description = "That is product K."}
            };

        public IEnumerable<IProduct> FindAll()
        {
            return _products;
        }

        public bool Delete(IProduct product)
        {
            if (product == null)
                throw new ArgumentNullException("product");
            _products.RemoveAll(p => p.Id.Equals(product.Id));
            return true;
        }
    }
}
