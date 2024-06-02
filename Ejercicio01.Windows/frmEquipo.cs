using Ejercicio01.Datos;
using Ejercicio01.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio01.Windows
{
    public partial class frmEquipo : Form
    {
        private Equipo? equipo;
        public frmEquipo()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                equipo = new Equipo(txtEquipo.Text, (int)nudCantidad.Value);
                btnCrear.Enabled = false;
                btnAgregarJugador.Enabled = true;
                txtEquipo.Enabled = false;
                nudCantidad.Enabled = false;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            return valido;
        }

        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            frmJugadorAE frm = new frmJugadorAE() { Text = "Agregar Jugador" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Jugador? jugador = frm.GetJugador();
            if (jugador is null) return;
            if (equipo is not null)
            {
                if (equipo + jugador)
                {
                    var r = new DataGridViewRow();
                    r.CreateCells(dgvDatos);
                    Setearfila(r, jugador);
                    Agregarfila(r);
                }

            }
        }

        private void Setearfila(DataGridViewRow r, Jugador jugador)
        {
            r.Cells[colJugador.Index].Value = jugador.MostrarDatos();
        }

        private void Agregarfila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
    }
}
