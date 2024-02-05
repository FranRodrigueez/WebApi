using WebApi;
using WebApi.Postgress;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        //Test Select
        [TestMethod]
        public void TestMethod1()
        {
            Class1 test = new Class1();
            test.connect(true);
            test.TestDB();
            test.GetUsers(new Users() { Usuario = "Fran", pass = "1234" });

        }

        //Test Create
        [TestMethod]
        public void TestMethod2()
        {
            Class1 test = new Class1();
            test.connect(true);
            test.TestDB();
            test.GetCreate(new Users() { Usuario = "Jesús Canueto", pass = "1234", email = "j.cesjuanpablosegundocadiz@gmail.com", Administrador = 1, Manager = 1, idNegocio = 1, validated = 1 });
            Assert.AreEqual(test.GetUsers(new Users() { Usuario = "Jesús Canueto", pass = "1234" })[0].email, "j.cesjuanpablosegundocadiz@gmail.com");
        }

        //Test Update
        [TestMethod]
        public void TestMethod3()
        {
            Class1 test = new Class1();
            test.connect(true);
            test.TestDB();
            test.GetUpdate(new Users() { Usuario = "Fran Rodríguez", pass = "12345", Administrador = 1, email = "f.rodriguez@cesjuanpablosegundocadiz.es", Manager = 1, idNegocio = 1, validated = 1 });
            Assert.AreEqual(test.GetUsers(new Users() { Usuario = "Fran Rodríguez", pass = "12345" })[0].email, "f.rodriguez@cesjuanpablosegundocadiz.es");
        }

        //Test Delete
        [TestMethod]
        public void TestMethod4()
        {
            Class1 test = new Class1();
            test.connect(true);

            test.GetDelete(new Users { email = "j.cesjuanpablosegundocadiz@gmail.com" });

        }

        [TestMethod]
        public void TestDBSelectFunction()
        {
            //Requisitos de la actividad:
            //Realizar la consulta con parametros de entrada en formato clase(InventarioSQL),
            //tener como resultado la lista de los inventarios que coincidan con los filtros definidos en el test
            Class1 t = new Class1();
            t.connect(true);
            Assert.AreEqual("Orbea", t.ConsultaTest<InventarioSQL>("InventarioSQL", new InventarioSQL() { codigo = "1234" })[0].nombre);

        }

        //Test Select para InventarioSQL
        [TestMethod]
        public void TestSelectInventario()
        {
            Class1 test = new Class1();
            test.connect(true);
            test.TestDB();
            test.GetInventario(new InventarioSQL() { nombre = "Fran"});

        }

        //Test Create
       [TestMethod]
        public void TestInsertInventario()
        {
            Class1 test = new Class1();
            test.connect(true);
            test.TestDB();
            test.InventarioCreate(new InventarioSQL() { codigo = "12345", nombre = "Israel", proveedor = "Pablo Ruso"});
        }
       
    }
}