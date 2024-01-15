using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiEjemplo
{
    public class UserIgnore
    {
        [JsonIgnore]
        public int? idUser { get; set; }

        public string Usuario { get; set; }

        public string pass { get; set; }

        public string email { get; set; }

        public int? Administrador { get; set; }

        public int? Manager { get; set; }

        public int? idNegocio { get; set; }

        public int? validated { get; set; }
    }
}
