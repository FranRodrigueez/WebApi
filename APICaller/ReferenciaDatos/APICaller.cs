using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace APICaller.ReferenciaDatos
{
    [XmlRoot("pizzas")]
    public class Pizzeria
    {
        [XmlElement("pizza")]

        public List<Pizza> Pizzas { get; set; }

    }

    public class Pizza
    {
        [XmlAttribute("nombre")]
        public String Nombre { get; set; }

        [XmlAttribute("precio")]
        public int Precio { get; set; }

        [XmlElement("ingrediente")]
        public List<Ingrediente> Ingredientes { get; set; }

    }

    public class Ingrediente
    {
        [XmlAttribute("nombre")]
        public String Nombre { get; set; }
    }


}
