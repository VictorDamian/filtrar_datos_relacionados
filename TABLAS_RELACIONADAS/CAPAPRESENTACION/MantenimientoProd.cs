using System;
using System.Windows.Forms;
using TABLAS_RELACIONADAS.CAPADATOS;

namespace TABLAS_RELACIONADAS.CAPAPRESENTACION
{
    public partial class MantenimientoProd : Form
    {
        ClsProductos objProdct = new ClsProductos();
        public string state = "Insert";
        public string idProduct;
        public MantenimientoProd()
        {
            InitializeComponent();
        }
        public void CategoryList()
        {
            ClsProductos objProd = new ClsProductos();
            CmbCategoria.DataSource = objProd.CategoryList();
            CmbCategoria.DisplayMember = "CATEGORIA";
            CmbCategoria.ValueMember = "IDCATE";
        }
        public void MarkList()
        {
            ClsProductos objProd = new ClsProductos();
            CmbMarca.DataSource = objProd.MarkList();
            CmbMarca.DisplayMember = "MARCA";
            CmbMarca.ValueMember = "IDMAR";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (state == "Insert")
            {
                objProdct.IdCategory = Convert.ToInt32(CmbCategoria.SelectedValue);
                objProdct.IdMark = Convert.ToInt32(CmbMarca.SelectedValue);
                objProdct.Description = txtDescripcion.Text;
                objProdct.Cost = Convert.ToDouble(txtPrecio.Text);
                objProdct.AddProduct();
                MessageBox.Show("Inserted correctly");
                this.Close();
            }
            else if (state == "Edit")
            {
                objProdct.IdProduct = Convert.ToInt32(idProduct);
                objProdct.IdCategory = Convert.ToInt32(CmbCategoria.SelectedValue);
                objProdct.IdMark = Convert.ToInt32(CmbMarca.SelectedValue);
                objProdct.Description = txtDescripcion.Text;
                objProdct.Cost = Convert.ToDouble(txtPrecio.Text);
                objProdct.EditProduct();
                MessageBox.Show("Edited correctly");
                this.Close();
            }
        }
    }
}
