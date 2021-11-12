using System.Data;
using System.Data.SqlClient;

namespace TABLAS_RELACIONADAS.CAPADATOS
{
    class ClsProductos
    {
        private ConexionBD _conn = new ConexionBD();
        private SqlCommand _command = new SqlCommand();
        private SqlDataReader _reader;
        //ATTRIBUTES
        private int _idProduct;
        private int _idCategory;
        private int _idMark;
        private string _description;
        private double _cost;

        //GET AND SET
        public int IdProduct { get => _idProduct; set => _idProduct = value; }
        public int IdCategory { get => _idCategory; set => _idCategory = value; }
        public int IdMark { get => _idMark; set => _idMark = value; }
        public string Description { get => _description; set => _description = value; }
        public double Cost { get => _cost; set => _cost = value; }

        public DataTable CategoryList()
        {
            DataTable table = new DataTable();
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = "LISTACATEGORIAS";
            _command.CommandType = CommandType.StoredProcedure;
            _reader = _command.ExecuteReader();
            table.Load(_reader);
            _reader.Close();
            _conn.CloseConnection();
            return table;
        }
        public DataTable MarkList()
        {
            DataTable table = new DataTable();
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = "LISTAMARCAS";
            _command.CommandType = CommandType.StoredProcedure;
            _reader = _command.ExecuteReader();
            table.Load(_reader);
            _reader.Close();
            _conn.CloseConnection();
            return table;
        }
        public void AddProduct()
        {
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = "AGREGARPRODUC";
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@IDCATE", _idCategory);
            _command.Parameters.AddWithValue("@IDMAR", _idMark);
            _command.Parameters.AddWithValue("@DESC", _description);
            _command.Parameters.AddWithValue("@PRECIO", _cost);
            _command.ExecuteNonQuery();
            _command.Parameters.Clear();
        }
        public void EditProduct()
        {
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = "UPDATE PRODUCTOS SET IDCATE=" + _idCategory + ",IDMAR=" + _idMark + ",DESCRIPCION='" + _description + "',PRECIO=" + _cost + " WHERE IDPROD=" + _idProduct;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();
            _conn.CloseConnection();
        }
        public void RemoveProduct()
        {
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = "DELETE PRODUCTOS WHERE IDPROD=" + _idProduct;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();
            _conn.CloseConnection();
        }
        public DataTable ProductList()
        {
            DataTable table = new DataTable();
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = "LISTAPRODUC";
            _command.CommandType = CommandType.StoredProcedure;
            _reader = _command.ExecuteReader();
            table.Load(_reader);
            _reader.Close();
            _conn.CloseConnection();
            return table;
        }
    }
}
