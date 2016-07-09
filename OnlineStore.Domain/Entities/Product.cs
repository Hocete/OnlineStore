using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineStore.Domain.Entities
{
    public class Product
    {
       
        public int ProductID { get; set; }
        [Required(ErrorMessage ="请输入商品名称")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "请输入商品描述")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage="请输入价格")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "请输入类别")]
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMineType { get; set; }
    }
}
