using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

//自訂檢查函數
namespace MVC5Course.Models
{
    public class 必須包含一個空白字元Attribute : DataTypeAttribute
    {
        public 必須包含一個空白字元Attribute():base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string sz = (string)value;
            return sz.Contains(" ");
        } 
       
    }
}
