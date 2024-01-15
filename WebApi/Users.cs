using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApi
{
    public class Users : responseBase
    {
        [Key]
        public int? idUser { get; set; }

        public string? Usuario { get; set; }

        public string? pass { get; set; }

        public string email { get; set; }

        public int? Administrador { get; set; }

        public int? Manager { get; set; }

        public int? idNegocio { get; set; }

        public int? validated { get; set; }

    }
}
