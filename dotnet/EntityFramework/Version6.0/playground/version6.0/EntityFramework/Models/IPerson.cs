using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWpfCore.Models;

namespace EntityFramework.Models
{
    public interface IPerson : IModelBase
    {
        int Id { get; set; }
        string Firstname { get; set; }
        string Lastname{ get; set; }
        string Street { get; set; }
        string Zip { get; set; }
        string City { get; set; }
        string Country { get; set; }
    }
}
