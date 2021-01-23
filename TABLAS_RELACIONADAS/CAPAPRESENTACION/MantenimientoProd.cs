using System;
using System.Windows.Forms;
using TABLAS_RELACIONADAS.CAPADATOS;

namespace TABLAS_RELACIONADAS.CAPAPRESENTACION
{
    public partial class MantenimientoProd : Form
    {
        public MantenimientoProd()
        {
            InitializeComponent();
        }
        ClsProductos objproducto = new ClsProductos();
        public string Operacion = "Insertar";
        public string idprod;
        public void ListarCategorias()
        {
            ClsProductos objProd = new ClsProductos();
            CmbCategoria.DataSource = objProd.ListarCategorias();
            CmbCategoria.DisplayMember = "CATEGORIA";
            CmbCategoria.ValueMember = "IDCATEG";
        }
        public void ListarMarcas()
        {
            ClsProductos objProd = new ClsProductos();
            CmbMarca.DataSource = objProd.ListarMarcas();
            CmbMarca.DisplayMember = "MARCA";
            CmbMarca.ValueMember = "IDMARCA";
        }
        private void MantenimientoProd_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objproducto.IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                objproducto.IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto.Descripcion = txtDescripcion.Text;
                objproducto.Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto.InsertarProductos();
                MessageBox.Show("Se inserto correctamente");
                this.Close();
            }
            else if (Operacion == "Editar")
            {
                objproducto.IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                objproducto.IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto.Descripcion = txtDescripcion.Text;
                objproducto.Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto.Idprod = Convert.ToInt32(idprod);
                objproducto.EditarProducto();
                MessageBox.Show("Se edito correctamente");
                this.Close();
            }
        }
    }
}
