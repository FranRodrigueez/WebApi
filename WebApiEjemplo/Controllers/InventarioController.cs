using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Postgress;

namespace WebApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly ILogger<InventarioController> _logger;

        public InventarioController(ILogger<InventarioController> logger)
        {
            _logger = logger;
        }

        //Insertar inventario
        [HttpGet(Name = "InsertarInventario")]
        public IList<InventarioSQL> GetIntventario(string nom)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);
            IList<InventarioSQL> us = class1.GetInventario(new InventarioSQL() { nombre = nom, });

            return us;
        }

        //Actualizar inventario
        [HttpPut(Name = "ActualizarInventario")]
        public void ActualizarInventario(InventarioSQL inv, string cod)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);

            InventarioSQL inventario = new InventarioSQL
            {
                nombre = inv.nombre,
                codigo = inv.codigo,
                proveedor = inv.proveedor,
            };

            class1.UpdateInventario(inventario);
        }

        //Crear inventario
        [HttpPost(Name = "CrearInventario")]
        public void CrearInventario(InventarioIgnore inventario)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);
            InventarioSQL inv = new InventarioSQL
            {
                codigo = inventario.codigo,
                nombre = inventario.nombre,
                proveedor = inventario.proveedor,
            };

            class1.InventarioCreate(inv);
        }

        //Borrar inventario
        [HttpDelete(Name = "BorrarInventario")]
        public void BorrarUsuario(string cod)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);
            InventarioSQL invent = new InventarioSQL { codigo = cod };

            class1.DeleteInventario(invent);
        }
    }
}
