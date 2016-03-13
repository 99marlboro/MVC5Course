namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IProduct
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        //[RegularExpression(@"\w\w\d{8}", ErrorMessage = "請輸入發票號碼")]
        //[必須包含一個空白字元(ErrorMessage = "必須包含一個空白字元")]
        public string ProductName { get; set; }
        [Range(1, 99999, ErrorMessage = "價格請介於1~99999間")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        [Range(0, 99999, ErrorMessage = "庫存量不可大於99999")]
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
