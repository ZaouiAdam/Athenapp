using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpeditionHelper_SOL.Models
{
    public class User
    {
        [Required(ErrorMessageResourceType = typeof(ExpeditionHelper_SOL.Resources.Models.User), ErrorMessageResourceName = "LoginRequired")]
        [Display(Name = "LoginName", ResourceType = typeof(ExpeditionHelper_SOL.Resources.Models.User))]
        public string login { get; set; }

        [Required(ErrorMessageResourceType = typeof(ExpeditionHelper_SOL.Resources.Models.User), ErrorMessageResourceName = "PasswordRequired")]
        [Display(Name = "PasswordName", ResourceType = typeof(ExpeditionHelper_SOL.Resources.Models.User))]
        public string password { get; set; }
    }
}