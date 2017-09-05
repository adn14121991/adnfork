using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//importando la libreria
using Clase_Videos;
namespace Aplica_Videos
{
    public partial class Frmvideos : Form
    {
        //Se genera un objeto objvideo de tipo Clase: Clase_Videos
        Clase_Videos.Clsvideo objvideo = new Clase_Videos.Clsvideo();
        //se declara una variable buscacodigo de tipo string
        //para la busqueda de videos
        string buscacodigo = "";
        //Se Genera el metodo de listado de videos
        //Variables para los codigos capturados
        string ycodformato, ycodgenero, ycodidioma, ycodpais;
        //Se genera un metodo para la busqueda de videos
        private void BusquedaVideos()
        {
            buscacodigo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Codigo Del Video","Pulse Clic En Aceptar");
            //El Codigo Si Existe
            if (objvideo.MostrarCodigo(buscacodigo).Tables["selcodigo"].Rows.Count - 1 >= 0)
            {
                VideoEncontrado();
                MessageBox.Show("Codigo De Video Encontrado", "Pulse Clic En Aceptar");
                btnactualizar.Enabled = true;
                ActivarObjetos();
                txtcodigo.Enabled = false;
                btncancelar.Enabled = true;
                txtvideo.Focus();
            }
            else
            {
                LimpiarObjetos();
                DesactivarObjetos();
                MessageBox.Show("Codigo De Video No Encontrado", "Pulse Clic En Aceptar");
                btncancelar.Enabled = false;
                btnactualizar.Enabled = false;
                btnbuscar.Focus();
            }
        }
        private void VideoEncontrado()
        {
            txtcodigo.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][0].ToString();
            txtvideo.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][1].ToString();
            txtprecio.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][2].ToString();
            txtduracion.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][3].ToString();
            txtstock.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][4].ToString();
            cboformato.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][5].ToString();
            cbogenero.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][6].ToString();
            cboidioma.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][7].ToString();
            cbopais.Text = objvideo.BusquedaVideos(buscacodigo).Tables["buscavideos"].Rows[0][8].ToString();
        }
        private void ListadoVideos()
        {
            dgvlista.DataSource = objvideo.ListaVideos().Tables["listavideos"];
        }
        private void anchocolumnas()
        {
            var x = dgvlista;
               x.Columns[0].Width=80;
               x.Columns[1].Width = 300;
               x.Columns[2].Width = 100;
               x.Columns[3].Width = 150;
               x.Columns[4].Width = 100;
               x.Columns[5].Width = 150;
               x.Columns[6].Width = 150;
               x.Columns[7].Width = 150;
               x.Columns[8].Width = 150;
        }
        private void DesactivarObjetos()
        {
            txtcodigo.Enabled = false;
            txtvideo.Enabled = false;
            txtprecio.Enabled = false;
            txtduracion.Enabled = false;
            txtstock.Enabled = false;
            cboformato.Enabled = false;
            cbogenero.Enabled = false;
            cboidioma.Enabled = false;
            cbopais.Enabled = false;
        }
        private void ActivarObjetos()
        {
            txtcodigo.Enabled = true;
            txtvideo.Enabled = true;
            txtprecio.Enabled = true;
            txtduracion.Enabled = true;
            txtstock.Enabled = true;
            cboformato.Enabled = true;
            cbogenero.Enabled = true;
            cboidioma.Enabled = true;
            cbopais.Enabled = true;
        }
        private void LimpiarObjetos()
        {
            txtcodigo.Text = "";
            txtvideo.Text = "";
            txtprecio.Text = "";
            txtduracion.Text = "";
            txtstock.Text = "";
            cboformato.SelectedIndex = 0;
            cbogenero.SelectedIndex = 0;
            cboidioma.SelectedIndex = 0;
            cbopais.SelectedIndex = 0;
        }
        private void ListadoFormato()
        {
            cboformato.DataSource = objvideo.ListaFormato().Tables["listaformato"];
            //Lo que se muestra en el combobox
            cboformato.DisplayMember = "NOM_FORMATO";
            //El valor interno del elemento seleccionado
            cboformato.ValueMember = "COD_FORMATO";
           
        }
        private void ListadoGenero()
        {
            cbogenero.DataSource = objvideo.ListaGenero().Tables["listagenero"];
            //Lo que se muestra en el combobox
            cbogenero.DisplayMember = "NOM_GENERO";
            //El valor interno del elemento seleccionado
            cbogenero.ValueMember = "COD_GENERO";
        }
        private void ListadoIdioma()
        {
            cboidioma.DataSource = objvideo.ListaIdioma().Tables["listaidioma"];
            //Lo que se muestra en el combobox
            cboidioma.DisplayMember = "NOM_IDIOMA";
            //El valor interno del elemento seleccionado
            cboidioma.ValueMember = "COD_IDIOMA";
        }
        private void ListadoPais()
        {
            cbopais.DataSource = objvideo.ListaPais().Tables["listapais"];
            //Lo que se muestra en el combobox
            cbopais.DisplayMember = "NOM_PAIS";
            //El valor interno del elemento seleccionado
            cbopais.ValueMember = "COD_PAIS";
        }
        public Frmvideos()
        {
            InitializeComponent();
        }
        private void Frmvideos_Load(object sender, EventArgs e)
        {
            //Utilizando Al metodo ListadoVideos
            ListadoVideos();
            //Utilizando el metodo anchocolumnas
            anchocolumnas();
            //Utilizando el metodo DesactivarObjetos
            DesactivarObjetos();
            //Utilizando el metodo ListadoFormato
            ListadoFormato();
            //Utilizando el metodo ListadoGenero
            ListadoGenero();
            //Utilizando el metodo ListadoIdioma
            ListadoIdioma();
            //Utilizando el metodo ListadoPais
            ListadoPais();
        }

        private void cboformato_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Con el metodo SelectedValue se captura el codigo
            //del elemento seleccionado
            ycodformato = cboformato.SelectedValue.ToString();
            //MessageBox.Show(ycodformato);
            //Demo
            //int numformato = cboformato.SelectedIndex;
            //MessageBox.Show(numformato.ToString());
        }

        private void cbogenero_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Capturando el codigo del genero seleccionado
            //y se almacena hacia la variable ycodgenero
            ycodgenero = cbogenero.SelectedValue.ToString();
        }

        private void cboidioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ycodidioma = cboidioma.SelectedValue.ToString();
        }

        private void cbopais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ycodpais = cbopais.SelectedValue.ToString();
        }
        private void ActualizarVideos()
        {
            string mcodigo = txtcodigo.Text.ToUpper();
            string mvideo = txtvideo.Text.ToUpper();
            decimal mprecio = Decimal.Parse(txtprecio.Text);
            string mduracion = txtduracion.Text.ToUpper();
            int mstock = int.Parse(txtstock.Text);
            objvideo.ActualizarVideos(mcodigo, mvideo, mprecio, mduracion, mstock, ycodformato, ycodgenero, ycodidioma, ycodpais);
            ListadoVideos();
            MessageBox.Show("Video Actualizado", "Pulse Clic En Aceptar");
            LimpiarObjetos();
            DesactivarObjetos();
            btnnuevo.Enabled = true;
            btncancelar.Enabled = false;
            btngrabar.Enabled = false;
            btnnuevo.Focus();
        }
        private void GrabarVideos()
        {
             if (objvideo.MostrarCodigo(txtcodigo.Text.ToUpper()).Tables["selcodigo"].Rows.Count - 1 >= 0)
            {
                DetalleVideo();
                DesactivarObjetos();
                MessageBox.Show("Codigo Del Video Ya Registrado", "Pulse Clic En Aceptar");
                ActivarObjetos();
                LimpiarObjetos();
                DesactivarObjetos();
                btnnuevo.Enabled = true;
                btncancelar.Enabled = false;
                btngrabar.Enabled = false;
                btnnuevo.Focus();
            }
            else
            {
                string mcodigo = txtcodigo.Text.ToUpper();
                string mvideo = txtvideo.Text.ToUpper();
                decimal mprecio = Decimal.Parse(txtprecio.Text);
                string mduracion = txtduracion.Text.ToUpper();
                int mstock = int.Parse(txtstock.Text);
                objvideo.IngresoVideos(mcodigo, mvideo, mprecio, mduracion, mstock, ycodformato, ycodgenero, ycodidioma, ycodpais);
                ListadoVideos();
                MessageBox.Show("Video Registrado", "Pulse Clic En Aceptar");
                LimpiarObjetos();
                DesactivarObjetos();
                btnnuevo.Enabled = true;
                btncancelar.Enabled = false;
                btngrabar.Enabled = false;
                btnnuevo.Focus();
            }
        }
        private void DetalleVideo()
        {
            txtcodigo.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][0].ToString();
            txtvideo.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][1].ToString();
            txtprecio.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][2].ToString();
            txtduracion.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][3].ToString();
            txtstock.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][4].ToString();
            cboformato.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][5].ToString();
            cbogenero.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][6].ToString();
            cboidioma.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][7].ToString();
            cbopais.Text = objvideo.BusquedaVideos(txtcodigo.Text.ToUpper()).Tables["buscavideos"].Rows[0][8].ToString();
        }
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            ActivarObjetos();
            btnnuevo.Enabled = false;
            btncancelar.Enabled = true;
            btngrabar.Enabled = true;
            txtcodigo.Focus();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
            DesactivarObjetos();
            ListadoVideos();
            btnnuevo.Enabled = true;
            btncancelar.Enabled = false;
            btngrabar.Enabled = false;
            btnactualizar.Enabled = false;
            btnnuevo.Focus();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            GrabarVideos();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            BusquedaVideos();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            ActualizarVideos();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
