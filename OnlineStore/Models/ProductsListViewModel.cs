using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
