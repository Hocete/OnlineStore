using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="请输入姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage ="请输入详细地址")]
        [Display(Name= "详细地址1")]
        public string Line1 { get; set; }
        [Display(Name = "详细地址2")]
        public string Line2 { get; set; }
        [Display(Name = "详细地址3")]
        public string Line3 { get; set; }
        [Required(ErrorMessage ="请输入城市")]
        [Display(Name = "城市")]
        public string City { get; set; }
        [Required(ErrorMessage = "请输入地区名称")]
        [Display(Name = "地区")]
        public string State { get; set; }
        [Display(Name = "省份")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "请输入国家名称")]
        [Display(Name = "国家")]
        public string Country { get; set; }
        [Display(Name = "礼盒包装")]
        public bool GiftWrap { get; set; }
    }
}
