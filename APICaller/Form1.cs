
using APICaller.ReferenciaDatos;

namespace APICaller
{
    public partial class Form1 : Form
    {
        ConfigReader Config { get; set; }
        LecturaXML lectura { get; set; }
        public Form1()
        {
            InitializeComponent();
            Config = new ConfigReader();
            lectura = new LecturaXML();
            label1.Text = "Lista de Pizzas";
            Pizzeria pizzas = lectura.LecturaXML_Deserialize_Pizza(Config.ficheroPizza);
            TreeNode arbol = new TreeNode("Pizzas");
            treeView1.Nodes.Add(arbol);

            foreach(var pizza in pizzas.Pizzas)
            {
                TreeNode pizzaNode = new TreeNode(pizza.Nombre + " -- Precio: " + pizza.Precio.ToString());
                
                foreach(var ingrediente in pizza.Ingredientes)
                {
                    TreeNode ingredientesNode = new TreeNode(ingrediente.Nombre);
                    pizzaNode.Nodes.Add(ingredientesNode);
                }

                treeView1.Nodes[0].Nodes.Add(pizzaNode);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new LecturaXML().LeerXML_Nodes_Pizza(Config.ficheroPizza);
            //new LecturaXML().LecturaXML_DeserializePizza(Config.ficheroPizza);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
