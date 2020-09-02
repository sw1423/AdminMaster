using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminMaster.UI.Models
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}