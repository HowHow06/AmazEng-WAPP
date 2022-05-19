using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazEng_WAPP.Models
{
    public class AdminRole
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Permission { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }

        public bool HasPermission(string permission)
        {
            var permissions = JObject.Parse(this.Permission);
            return (bool)permissions[permission];
        }
        public bool HasManageAdminsPermission()
        {
            return HasPermission("ManageAdmins");
        }
    }


}