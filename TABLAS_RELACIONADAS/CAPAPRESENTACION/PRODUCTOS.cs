using System;
using System.Windows.Forms;
using TABLAS_RELACIONADAS.CAPADATOS;

namespace TABLAS_RELACIONADAS.CAPAPRESENTACION
{
    public partial class PRODUCTOS : Form
    {
        public PRODUCTOS()
        {
            InitializeComponent();
        }
        ClsProductos objproducto = new ClsProductos();
        string Operacion = "";
        string idprod;
        private void PRODUCTOS_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarMarcas();
            ListarProductos();
        }
        private void ListarCategorias() {
            ClsProductos objProd = new ClsProductos();
            CmbCategoria.DataSource = objProd.ListarCategorias();
            CmbCategoria.DisplayMember = "CATEGORIA";
            CmbCategoria.ValueMember = "IDCATEG";
        }
        private void ListarMarcas()
        {
            ClsProductos objProd = new ClsProductos();
            CmbMarca.DataSource = objProd.ListarMarcas();
            CmbMarca.DisplayMember = "MARCA";
            CmbMarca.ValueMember = "IDMARCA";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(Operacion == "Insertar")
            {
                objproducto.IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                objproducto.IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto.Descripcion = txtDescripcion.Text;
                objproducto.Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto.InsertarProductos();
                MessageBox.Show("Se inserto correctamente");
            }else if(Operacion == "Editar")
            {
                objproducto.IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                objproducto.IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto.Descripcion = txtDescripcion.Text;
                objproducto.Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto.Idprod = Convert.ToInt32(idprod);
                objproducto.EditarProducto();
                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");
            }
            ListarProductos();
            LimpiarCampos();
        }
        private void ListarProductos() {
            ClsProductos objprod = new ClsProductos();
            dataGridView1.DataSource = objprod.ListarProductos();
        }
        private void LimpiarCampos()
        {
            txtDescripcion.Clear();
            txtPrecio.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                CmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                CmbMarca.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                idprod = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void btnEditarF2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MantenimientoProd fmr = new MantenimientoProd();
                fmr.Operacion = "Editar";
                fmr.ListarMarcas();
                fmr.ListarCategorias();
                fmr.idprod = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                fmr.CmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                fmr.CmbMarca.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                fmr.txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                fmr.txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                fmr.ShowDialog();
                ListarProductos();
            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MantenimientoProd frm = new MantenimientoProd();
            frm.Operacion = "Insertar";
            frm.ListarCategorias();
            frm.ListarMarcas();
            frm.ShowDialog();
            ListarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objproducto.Idprod = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                objproducto.EliminarProd();
                MessageBox.Show("Se elimino satisfactoriamente");
                ListarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }
    }
}
