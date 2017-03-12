using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Validations
{
    public class 不能出現WWWW字母Attribute : DataTypeAttribute
    {
        public 不能出現WWWW字母Attribute():base(DataType.Text)
        {
            this.ErrorMessage = "不能出現WWWW字母";
        }

        public override bool IsValid(object value)
        {
            string svalue = Convert.ToString(value);
            if (svalue.Contains("WWWW"))
            {
                return false;
            }
            return true;
        }
    }
}