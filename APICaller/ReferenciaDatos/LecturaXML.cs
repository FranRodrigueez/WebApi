using APICaller.ReferenciaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace APICaller
{
    public class LecturaXML
    {
        public void LeerXML_Nodes(string filepath) 
        { 
            string text = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                text += node.InnerText;
            }
            MessageBox.Show(text);
        }

        public Pizzeria? LecturaXML_Deserialize_Pizza(string filepath)
        {
            Pizzeria? i = null;
            var serializer = new XmlSerializer(typeof(Pizzeria));
            using (Stream reader = new FileStream(filepath, FileMode.Open))
            {
                //Call the serialize method to restore the object´s state.
                i = serializer.Deserialize(reader) as Pizzeria;
            }

            return i;

        }

        //public ItemsReaded? LecturaXML_Deserialize(string filepath)
        //{
        //    ItemsReaded? i = null;
        //    var serializer = new XmlSerializer(typeof(ItemsReaded));
        //    using (Stream reader = new FileStream(filepath, FileMode.Open))
        //    {
        //        //Call the serialize method to restore the object´s state.
        //        i = serializer.Deserialize(reader) as ItemsReaded;
        //    }

        //    return i;

        //}

        //public void LeerXML_Nodes_Pizza(string filepath)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(filepath);

        //    List<string> pizzasInfo = new List<string>();

        //    foreach (XmlNode pizzaNode in doc.SelectNodes("/pizzas/pizza"))
        //    {
        //        string nombrePizza = pizzaNode.Attributes["nombre"].Value;
        //        string precioPizza = pizzaNode.Attributes["precio"].Value;

        //        List<string> ingredientes = new List<string>();
        //        foreach (XmlNode ingredienteNode in pizzaNode.SelectNodes("ingrediente"))
        //        {
        //            string nombreIngrediente = ingredienteNode.Attributes["nombre"].Value;
        //            ingredientes.Add(nombreIngrediente);
        //        }

        //        // Formatear la información de la pizza
        //        string pizzaInfo = $"Nombre: {nombrePizza}, Precio: {precioPizza}, Ingredientes: {string.Join(", ", ingredientes)}";

        //        // Agregar la información al listado
        //        pizzasInfo.Add(pizzaInfo);
        //    }

        //    // Mostrar toda la información en un único MessageBox
        //    string mensajeFinal = string.Join("\n\n", pizzasInfo);
        //    MessageBox.Show(mensajeFinal, "Información de Pizzas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

    }
}
