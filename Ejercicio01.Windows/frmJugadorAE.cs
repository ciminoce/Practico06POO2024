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
    public partial class frmJugadorAE : Form
    {
        private Jugador? jugador;
        public frmJugadorAE()
        {
            InitializeComponent();
        }

        public Jugador? GetJugador()
        {
            return jugador;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                int dni=int.Parse(txtDni.Text);
                jugador = new Jugador(dni, txtNombre.Text);
                DialogResult=DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            return true;
        }
    }
}
