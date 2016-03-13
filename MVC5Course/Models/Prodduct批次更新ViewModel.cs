using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class Prodduct批次更新ViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, 9999, ErrorMessage = "單價，請輸入1~9999間數字")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "庫存，請輸入01~100間數字")]
        public Nullable<decimal> Stock { get; set; }
    }
}