using Microsoft.AspNetCore.Mvc;
using WebApi;

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

        //Insertar inventario

        //Create -> Post
        //Update -> Put
        //Insert(Crear) -> Post
        //Read -> Get
    }
}
