using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductModul.Models;

namespace ProductModul.Services
{
    public interface IProductService
    {
        IEnumerable<IProduct> FindAll();

        bool Delete(IProduct product);
    }
}
