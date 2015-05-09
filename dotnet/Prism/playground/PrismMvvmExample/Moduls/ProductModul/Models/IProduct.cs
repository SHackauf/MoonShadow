using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrismCore.Models;

namespace ProductModul.Models
{
    public interface IProduct : IBaseModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
