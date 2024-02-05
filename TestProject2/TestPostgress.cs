using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Postgress;
using WebApi;


namespace TestProject2
{
    [TestClass]
    public class PostgreTest
    {

        [TestMethod]
        public void TestConecxionDB()
        {

            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
            Assert.AreEqual("este no es llarados fit", Con.ConsultaTest<UsuarioPostGress>(" select  * from usuario where email like '%emaile%'")[0].imagenusuario.cabezera);


        }
        [TestMethod]
        public void TestInsertDB()
        {

            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
            Con.InsertTest<UsuarioPostGress>("usuario", new UsuarioPostGress() { email = "emaile", imagenusuario = new imagen() { cabezera = "este no es llarados fit" } });
        }

        [TestMethod]
        public void TestConecxionDBEjercicioClase()
        {
            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
            Assert.AreEqual("Orbea", Con.ConsultaTest<inventario>("inventario", new inventario() { codigo = "1234" })[0].proveedor.nombreprov);

        }

        

    }
}
