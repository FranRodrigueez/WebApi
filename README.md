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

Contenido de UserIgnore.cs.

## Controllers

### InventarioControllers.cs

Contenido de InventarioControllers.cs.

### MiControladorWebSocket.cs

Contenido de MiControladorWebSocket.cs.

### UserController.cs

Contenido de UserController.cs.

### WeatherForeCastController.cs

Contenido de WeatherForeCastController.cs.

## Program.cs

Contenido de Program.cs.

