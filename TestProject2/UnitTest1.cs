using WebApi;

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

    }
}