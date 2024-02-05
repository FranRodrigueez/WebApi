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
- HTTP GET requests and is responsible for retrieving information from the inventory.
- HTTP PUT requests and is used to update information in the inventory.
- HTTP POST requests and is responsible for creating new items in the inventory.
- HTTP DELETE requests and is used to delete items from the inventory.

### UserController.cs

This class, UserController, is a controller in an ASP.NET Core Web API.

- The methods (GetDatosUsuario, ActualizarUsuario, CrearUsuario, BorrarUsuario) interact with a class named Class1 to perform various operations on the inventory data.
- The class is configured as an API controller with routing information specified.
- Dependency injection is used to inject a logger (ILogger<UserController>) into the controller.

```csharp
﻿using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Postgress;
using WebApiEjemplo.Clases;

namespace WebApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "DatosUsuario")]
        public IList<Users> GetDatosUsuario(string usu, string password)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);
            IList<Users> us = class1.GetUsers(new Users() { Usuario = usu, pass = password });

            return us;
        }



        [HttpPut(Name = "ActualizarUsuario")]
        public void ActualizarUsuario(UserIgnore us, string correo)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);

            Users user = new Users
            {
                Usuario = us.Usuario,
                pass = us.pass,
                email = correo,
                Administrador = us.Administrador,
                Manager = us.Manager,
                idNegocio = us.idNegocio,
                validated = us.validated,
            };

            class1.GetUpdate(user);
        }

        [HttpPost(Name = "CrearUsuario")]
        public void CrearUsuario(UserIgnore usuario)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);
            Users us = new Users
            {
                Usuario = usuario.Usuario, 
                pass = usuario.pass, 
                email = usuario.email, 
                Administrador = usuario.Administrador, 
                idNegocio = usuario.idNegocio, 
                Manager = usuario.Manager, 
                validated = usuario.validated 
            };

            class1.GetCreate(us);

            Mail mail = new Mail();
            mail.send(us);
        }

        [HttpDelete(Name = "BorrarUsuario")]
        public void BorrarUsuario(string correo)
        {
            Class1 class1 = new Class1();
            //class1.connect(true);
            Users usuario = new Users { email = correo};

            class1.GetDelete(usuario);
        }

        //Create -> Post
        //Update -> Put
        //Insert(Crear) -> Post
        //Read -> Get
    }
}
```

- HTTP GET requests and is responsible for retrieving information from the user.
- HTTP PUT requests and is used to update information in the user.
- HTTP POST requests and is responsible for creating new items in the user.
- HTTP DELETE requests and is used to delete items from the user.

### WeatherForeCastController.cs

WeatherForeCastController is a class that comes by default when creating the app.

```csharp
using Microsoft.AspNetCore.Mvc;

namespace WebApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
```
### MiControladorWebSocket.cs

- MiControladorDeWebSockets facilitates bidirectional communication between the server and the client through WebSocket, handles various types of messages, and demonstrates the ability to continuously send data from the server to the client.
- This controller has not been implemented in the API yet

```csharp
﻿using System.Net.WebSockets;
using System.Text;


namespace WebApiEjemplo.Controllers
{
    public class MiControladorDeWebSockets
    {
        private readonly RequestDelegate _next;

        public MiControladorDeWebSockets(RequestDelegate next)
        {
            _next = next;
        }
        public bool EndSocket;
        public async Task Invoke(HttpContext context)
        {
            // Si no es una petición socket, no procesarla por este controlador
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);
                return;
            }

            // Es una petición socket, ver que nos mandan
            var ct = context.RequestAborted;
            using (var socket = await context.WebSockets.AcceptWebSocketAsync()) //aceptamos la llamada de WS
            {
                while (!EndSocket)
                {
                    var mensaje = await ReceiveStringAsync(socket, ct);   //await de recepción 
                    if (mensaje == null) return; //si el mensaje esta vacio cierra conexion

                    // Vamos a inventar dos tipos de mensajes:
                    // 1. Mensajes simples: sólo llega una cadena de texto
                    // 2. Mensajes compuestos: requerimos parámetros. Separaremos el mensaje de los parámetros con #

                    // Procesado de mensajes simples
                    switch (mensaje.ToLower())
                    {
                        case "hola":
                            await SendStringAsync(socket, "Hola como estás, bienvenido", ct);
                            break;

                        case "adios":
                            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Desconectado", ct);
                            EndSocket = true;
                            break;
                        case "churro":
                            await SendchurroAsync(socket, ct);
                            break;

                        default:
                            await SendStringAsync(socket, "Lo siento, pero no entiendo ese mensaje", ct);
                            break;
                    }

                    // Procesado de mensajes con parámetros
                    if (mensaje.Contains('#'))
                    {
                        string[] mensajeCompuesto = mensaje.ToLower().Split('#');
                        switch (mensajeCompuesto[0])
                        {
                            case "hola":
                                await SendStringAsync(socket, "Hola usuario " + mensajeCompuesto[1], ct);
                                break;

                            default:
                                await SendStringAsync(socket, "Lo siento, pero no entiendo ese mensaje", ct);
                                break;
                        }

                    }


                }
            }
            return;
        }

        private static async Task<string> ReceiveStringAsync(WebSocket socket, CancellationToken ct = default)
        {
            // Se recibe un mensaje que debe ser descodificado
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await socket.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                    throw new Exception("Mensaje inesperado");

                // Codificar como UTF8
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        private static Task SendStringAsync(WebSocket socket, string data, CancellationToken ct = default)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }
        private static async Task SendchurroAsync(WebSocket socket, CancellationToken ct = default)
        {
            // monitorización de variables

            for (int i = 0; i < 100; i++)
            {
                string data = "Number: " + new Random().Next();
                var buffer = Encoding.UTF8.GetBytes(data);
                var segment = new ArraySegment<byte>(buffer);
                socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
            }



        }



    }
}
```


