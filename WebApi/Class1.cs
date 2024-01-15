using System.Data;
using System.Data.SqlClient;

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

    }
}