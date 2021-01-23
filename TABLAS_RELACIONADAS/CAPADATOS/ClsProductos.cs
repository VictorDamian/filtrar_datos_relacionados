using System.Data;
using System.Data.SqlClient;

namespace TABLAS_RELACIONADAS.CAPADATOS
{
    class ClsProductos
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;
        //ATRIBUTOS
        private int idprod;
        private int idCategoria;
        private int idMarca;
        private string descripcion;
        private double precio;
        //METODOS GET Y SET
        public int Idprod { get => idprod; set => idprod = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }

        public DataTable ListarCategorias()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarCategorias";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable ListarMarcas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarMarcas";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        public void InsertarProductos()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "AgregarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idcategoria", idCategoria);
            Comando.Parameters.AddWithValue("@idmarca", idMarca);
            Comando.Parameters.AddWithValue("@descrip", descripcion);
            Comando.Parameters.AddWithValue("@prec", precio);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EditarProducto()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "update PRODUCTOS set IDCATEGORIA=" + idCategoria + ",IDMARCA=" + idMarca + ",DESCRIPCION='" + descripcion + "',PRECIO=" + precio + " WHERE IDPROD=" + idprod;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
        public void EliminarProd()
        {
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "delete PRODUCTOS where IDPROD=" + idprod;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
        public DataTable ListarProductos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.AbrirConexion();
            Comando.CommandText = "ListarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
    }
}
