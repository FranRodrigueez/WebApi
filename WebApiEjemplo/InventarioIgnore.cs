using System.Text.Json.Serialization;

namespace WebApiEjemplo
{
    public class InventarioIgnore
    {

        [JsonIgnore]
        public int? id { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string proveedor { get; set; }
    }
}
