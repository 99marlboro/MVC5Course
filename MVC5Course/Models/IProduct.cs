using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5Course.Models
{
    public interface IProduct
    {
        bool? Active { get; set; }
        decimal? Price { get; set; }
        int ProductId { get; set; }
        string ProductName { get; set; }
        decimal? Stock { get; set; }
    }
}

