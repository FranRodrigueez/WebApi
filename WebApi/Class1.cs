using Npgsql;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using WebApi.Postgress;

namespace WebApi
{
    public class Class1
    {
        public static SqlConnection? connection { get; set; }

        public void connect()
        {
            connection = new SqlConnection();

            connection.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DatosApi;Data Source=Fran";
            connection.Open();
        }

        public DataSet TestDB()
        {
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("select * from TablaUsuario", connection);

            adapter.Fill(dt);
            return dt;
        }

        public void connect(bool auth)
        {
            connection = new SqlConnection();

            connection.ConnectionString = "user ID = sa; Password = 1234;Persist Security Info=False;Initial Catalog=DatosApi;Data Source=Fran";
            connection.Open();
        }

        public DataSet queryGenericStored(string query, List<KeyValuePair<string, dynamic>> parameters = null) 
        {
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Clear();

            foreach(KeyValuePair<string, dynamic> param in parameters)
            {
                AddParameter(ref adapter, param);
            }

            adapter.Fill(dt);
            return dt;
        }

        private void AddParameter(ref SqlDataAdapter sel, KeyValuePair<string, dynamic> val)
        {
            if(val.Value != null)
            {
                sel.SelectCommand.Parameters.AddWithValue(val.Key, val.Value);
            }     
        }

        public IList<Users> GetUsers(Users user_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@Usuario", user_to_search.Usuario));
            userparam.Add(new KeyValuePair<string, dynamic>("@pass", user_to_search.pass));
            userparam.Add(new KeyValuePair<string, dynamic>("@email", user_to_search.email));
            userparam.Add(new KeyValuePair<string, dynamic>("@idUser", user_to_search.idUser));
            userparam.Add(new KeyValuePair<string, dynamic>("@Administrador", user_to_search.Administrador));
            userparam.Add(new KeyValuePair<string, dynamic>("@Manager", user_to_search.Manager));
            userparam.Add(new KeyValuePair<string, dynamic>("@IdNegocio", user_to_search.idNegocio));
            userparam.Add(new KeyValuePair<string, dynamic>("@validate", user_to_search.validated));

            DataSet ds = queryGenericStored("svp_TablaUsuario_select", userparam);
            IList<Users> item = ds.Tables[0].AsEnumerable().Select(row =>
            new Users
            {
                Usuario = row.Field<string?>("Usuario"),
                pass = row.Field<string?>("pass"),
                email = row.Field<string>("email"),
                idUser = row.Field<int?>("idUser"),
                Administrador = row.Field<int?>("Administrador"),
                Manager = row.Field<int?>("Manager"),
                idNegocio = row.Field<int?>("idNegocio"),
                validated = row.Field<int?>("Validated"),

            }).ToList();
            return item;
        }

        public void GetCreate(Users user_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@Usuario", user_to_search.Usuario));
            userparam.Add(new KeyValuePair<string, dynamic>("@pass", user_to_search.pass));
            userparam.Add(new KeyValuePair<string, dynamic>("@email", user_to_search.email));
            userparam.Add(new KeyValuePair<string, dynamic>("@Administrador", user_to_search.Administrador));
            userparam.Add(new KeyValuePair<string, dynamic>("@Manager", user_to_search.Manager));
            userparam.Add(new KeyValuePair<string, dynamic>("@ideNegocio", user_to_search.idNegocio));
            userparam.Add(new KeyValuePair<string, dynamic>("@validated", user_to_search.validated));

            queryGenericStored("svp_TablaUsuario_create", userparam);
           
        }

        public void GetUpdate(Users user_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@Usuario", user_to_search.Usuario));
            userparam.Add(new KeyValuePair<string, dynamic>("@pass", user_to_search.pass));
            userparam.Add(new KeyValuePair<string, dynamic>("@Administrador", user_to_search.Administrador));
            userparam.Add(new KeyValuePair<string, dynamic>("@email", user_to_search.email));
            userparam.Add(new KeyValuePair<string, dynamic>("@Manager", user_to_search.Manager));
            userparam.Add(new KeyValuePair<string, dynamic>("@idNegocio", user_to_search.idNegocio));
            userparam.Add(new KeyValuePair<string, dynamic>("@validated", user_to_search.validated));

            queryGenericStored("svp_TablaUsuario_update", userparam);
        }

        public void GetDelete(Users user_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@email", user_to_search.email));
            
            queryGenericStored("svp_TablaUsuario_delete", userparam);
        }


        //Consultar en InventarioSQL
        public List<T> ConsultaTest<T>(string sql, T DatosFiltro) where T : new()
        {
            string consulta = string.Format("Select * from {0}", sql);

            Type tin = DatosFiltro.GetType();
            PropertyInfo[] propcons = tin.GetProperties();

            string wherecondition = string.Format(" where ");


            foreach (var itemprop in propcons)
            {

                var objreaded = itemprop.GetValue(DatosFiltro);
                if (objreaded != null)
                {
                    if (itemprop.PropertyType == Type.GetType("System.String"))
                    {
                        wherecondition = string.Format("{0}  {1} = '{2}'", wherecondition, itemprop.Name, objreaded);
                    }
                    else
                    {
                        wherecondition = string.Format("{0}  {1} = '{2}'", itemprop.Name, objreaded);
                    }
                }
            }
            wherecondition = wherecondition.Substring(0, wherecondition.Length - "and".Length);
 
            using var command = new SqlCommand(consulta,connection);
            using var reader = command.ExecuteReader();
            List<T> result = new List<T>();

            while (reader.Read())
            {
                T DatoInterno = new T();
                Type t = DatoInterno.GetType();
                PropertyInfo[] prop = t.GetProperties();
                int count = 0;
                foreach (var itemprop in prop)
                {

                    var tipon = reader.GetFieldType(count);
                    Type o = itemprop.PropertyType;
                    MethodInfo method = reader.GetType().GetMethod("GetFieldValue")
                             .MakeGenericMethod(new Type[] { o });
                    object? r = method.Invoke(reader, new object[] { count });


                    itemprop.SetValue(DatoInterno, r);


                    count++;
                }
                result.Add(DatoInterno);
            }
            return result;
        }

        //Seleccionar en InventarioSQL
        public IList<InventarioSQL> GetInventario(InventarioSQL inventario_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@nombre", inventario_to_search.nombre));
            userparam.Add(new KeyValuePair<string, dynamic>("@codigo", inventario_to_search.codigo));
            userparam.Add(new KeyValuePair<string, dynamic>("@proveedor", inventario_to_search.proveedor));
            
            DataSet ds = queryGenericStored("svp_InventarioSQL_select", userparam);
            IList<InventarioSQL> item = ds.Tables[0].AsEnumerable().Select(row =>
            new InventarioSQL
            {
                nombre = row.Field<string?>("nombre"),
                codigo = row.Field<string?>("codigo"),
                proveedor = row.Field<string>("proveedor"),

            }).ToList();
            return item;
        }
        //Crear en InventarioSQL
        public void InventarioCreate(InventarioSQL inventario_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@codigo", inventario_to_search.codigo));
            userparam.Add(new KeyValuePair<string, dynamic>("@nombre", inventario_to_search.nombre));
            userparam.Add(new KeyValuePair<string, dynamic>("@proveedor", inventario_to_search.proveedor));

            queryGenericStored("svp_InventarioSQL_create", userparam);
        }

        //Actualizar InventarioSQL
        public void UpdateInventario(InventarioSQL inventario_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@codigo", inventario_to_search.codigo));
            userparam.Add(new KeyValuePair<string, dynamic>("@nombre", inventario_to_search.nombre));
            userparam.Add(new KeyValuePair<string, dynamic>("@proveedor", inventario_to_search.proveedor));

            queryGenericStored("svp_InventarioSQL_update", userparam);
        }

        //Borrar InventarioSQL
        public void DeleteInventario(InventarioSQL inventario_to_search)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@codigo", inventario_to_search.codigo));

            queryGenericStored("svp_InventarioSQL_delete", userparam);
        }
    }
}