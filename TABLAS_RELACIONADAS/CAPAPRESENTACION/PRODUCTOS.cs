﻿using System;
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
            objproducto.InsertarProductos(
                Convert.ToInt32(CmbCategoria.SelectedValue),
                Convert.ToInt32(CmbMarca.SelectedValue),
                txtDescripcion.Text,
                Convert.ToDouble(txtPrecio.Text)
                );
            MessageBox.Show("Se inserto correctamente");
            ListarProductos();
        }
        private void ListarProductos() {
            ClsProductos objprod = new ClsProductos();
            dataGridView1.DataSource = objprod.ListarProductos();
        }
    }
}
