using System;
using System.Windows.Forms;
using TABLAS_RELACIONADAS.CAPADATOS;

namespace TABLAS_RELACIONADAS.CAPAPRESENTACION
{
    public partial class PRODUCTOS : Form
    {
        ClsProductos objProduct = new ClsProductos();
        string state = "Insert";
        string idProduct;
        public PRODUCTOS()
        {
            InitializeComponent();
        }
        
        private void PRODUCTOS_Load(object sender, EventArgs e)
        {
            CategoryList();
            MarkList();
            ProductList();
        }
        private void CategoryList() {
            ClsProductos category = new ClsProductos();
            cmbCategory.DataSource = category.CategoryList();
            cmbCategory.DisplayMember = "CATEGORIA";
            cmbCategory.ValueMember = "IDCATE";
        }
        private void MarkList()
        {
            ClsProductos mark = new ClsProductos();
            cmbMark.DataSource = mark.MarkList();
            cmbMark.DisplayMember = "MARCA";
            cmbMark.ValueMember = "IDMAR";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(state == "Insert")
            {
                objProduct.IdCategory = Convert.ToInt32(cmbCategory.SelectedValue);
                objProduct.IdMark = Convert.ToInt32(cmbMark.SelectedValue);
                objProduct.Description = txtDescripcion.Text;
                objProduct.Cost = Convert.ToDouble(txtPrecio.Text);
                objProduct.AddProduct();
                MessageBox.Show("Inserted correctly");
            }else if(state == "Edit")
            {
                objProduct.IdProduct = Convert.ToInt32(idProduct);
                objProduct.IdCategory = Convert.ToInt32(cmbCategory.SelectedValue);
                objProduct.IdMark = Convert.ToInt32(cmbMark.SelectedValue);
                objProduct.Description = txtDescripcion.Text;
                objProduct.Cost = Convert.ToDouble(txtPrecio.Text);
                objProduct.EditProduct();
                state = "Insert";
                MessageBox.Show("Edited correctly");
            }
            ProductList();
            CleanFields();
        }
        private void ProductList() {
            ClsProductos products = new ClsProductos();
            dataGridView1.DataSource = products.ProductList();
        }
        private void CleanFields()
        {
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cmbCategory.ResetText();
            cmbMark.ResetText();
            state = "insert";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                state = "Edit";
                cmbCategory.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                cmbMark.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                idProduct = dataGridView1.CurrentRow.Cells["IDPROD"].Value.ToString();
            }
            else
                MessageBox.Show("You must select a row");
        }

        private void btnEditarF2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MantenimientoProd formSupport = new MantenimientoProd();
                formSupport.state = "Edit";
                formSupport.MarkList();
                formSupport.CategoryList();
                formSupport.idProduct = dataGridView1.CurrentRow.Cells["IDPROD"].Value.ToString();
                formSupport.CmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                formSupport.CmbMarca.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                formSupport.txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                formSupport.txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                formSupport.ShowDialog();
                ProductList();
            }
            else
                MessageBox.Show("You must select a row");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MantenimientoProd frm = new MantenimientoProd();
            frm.state = "Insert";
            frm.CategoryList();
            frm.MarkList();
            frm.ShowDialog();
            ProductList();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objProduct.IdProduct = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                objProduct.RemoveProduct();
                MessageBox.Show("Deleted correctly");
                ProductList();
            }
            else
                MessageBox.Show("You must select a row");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanFields();
        }
    }
}
