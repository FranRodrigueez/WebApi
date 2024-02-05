WEBApiEjemplo
=================

[WEBApiExample](https://github.com/FranRodrigueez/WebApi) is an API created by FranRodriguez for the second-year Data Access subject in the Multiplatform Application Development course.

Table of contents
=================

- [Clases](#clases)
  - [InventarioIgnore.cs](#inventarioignorecs)
  - [UserIgnore.cs](#userignorecs)
- [Controllers](#controllers)
  - [InventarioControllers.cs](#inventariocontrollerscs)
  - [MiControladorWebSocket.cs](#micontroladorwebsocketcs)
  - [UserController.cs](#usercontrollercs)
  - [WeatherForeCastController.cs](#weatherforecastcontrollercs)
- [Program.cs](#programcs)

## Clases

### InventarioIgnore.cs

InventarioIgnore.cs is a class within the WebApiEjemplo.Clases namespace. This class represents a part of your inventory system.

```csharp
using System.Text.Json.Serialization;

namespace WebApiEjemplo.Clases
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
```
- id: An optional integer representing the ID of the inventory item. The [JsonIgnore] attribute is used to exclude this property from JSON serialization, implying that it should not be exposed externally.
- codigo: A string representing the code of the inventory item.
- nombre: A string representing the name of the inventory item.
- proveedor: A string representing the supplier of the inventory item.

This class is designed to model inventory items within your API, and the [JsonIgnore] attribute suggests that the ID property should not be included when converting the object to JSON, possibly for security or privacy reasons.

### UserIgnore.cs

UserIgnore.cs is another class within the WebApiEjemplo.Clases namespace. This class represents user information.

```csharp
﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiEjemplo.Clases
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
```

- idUser: An optional integer representing the ID of the user. The [JsonIgnore] attribute is used to exclude this property from JSON serialization, implying that it should not be exposed externally.
- Usuario: A string representing the username of the user.
- pass: A string representing the password of the user.
- email: A string representing the email of the user.
- Administrador: An optional integer indicating whether the user is an administrator.
- Manager: An optional integer indicating whether the user is a manager.
- idNegocio: An optional integer representing the ID of the business associated with the user.
- validated: An optional integer indicating whether the user is validated.

This class is designed to model user information within your API, and the [JsonIgnore] attribute suggests that sensitive information, such as the user ID, should not be included when converting the object to JSON, possibly for security or privacy reasons.

## Controllers

### InventarioControllers.cs

This class, InventarioController, is a controller in an ASP.NET Core Web API.

- The methods (GetIntventario, ActualizarInventario, CrearInventario, BorrarUsuario) interact with a class named Class1 to perform various operations on the inventory data.
- The class is configured as an API controller with routing information specified.
- Dependency injection is used to inject a logger (ILogger<InventarioController>) into the controller.

```csharp
﻿using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Postgress;
using WebApiEjemplo.Clases;

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
```
-  HTTP GET requests and is responsible for retrieving information from the inventory.
- HTTP PUT requests and is used to update information in the inventory.
- HTTP POST requests and is responsible for creating new items in the inventory.
- HTTP DELETE requests and is used to delete items from the inventory.
### MiControladorWebSocket.cs

Contenido de MiControladorWebSocket.cs.

### UserController.cs

Contenido de UserController.cs.

### WeatherForeCastController.cs

Contenido de WeatherForeCastController.cs.

## Program.cs

Contenido de Program.cs.

