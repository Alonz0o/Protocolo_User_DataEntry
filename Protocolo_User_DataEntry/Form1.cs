using DevExpress.XtraEditors;
using Protocolo_User_DataEntry.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocolo_User_DataEntry
{
    public partial class Form1 : Form
    {
        public BaseRepository br = new BaseRepository();
        int numDeControl = 1;
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        private void rbUltimoSeleccionado_CheckedChanged(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Size = new Size(412, 182);
            if (rbUltimoSeleccionado.Checked) {
                tbOP.Texts = "1343606";
                switch (Program.argumentos[0])
                {
                    case "confeccion":
                        foreach (var i in br.GetItemsPorProceso("Confección", Convert.ToInt32(tbOP.Texts)))
                        {
                            ScrapKP.AAFControles.AAFTextBox textBox = new ScrapKP.AAFControles.AAFTextBox();
                            textBox.BackColor = Color.White;
                            textBox.BorderColor = Color.FromArgb(63, 81, 181);
                            textBox.BorderSize = 2;
                            textBox.Dock = DockStyle.Fill;
                            textBox.Font = new Font("Libre Franklin SemiBold", 10F, FontStyle.Bold);
                            textBox.ForeColor = SystemColors.GrayText;
                            textBox.Margin = new Padding(4);
                            textBox.Multiline = false;
                            textBox.Name = "tbControl" + numDeControl;
                            textBox.Padding = new Padding(19, 8, 8, 8);
                            textBox.SelectionStart = 0;
                            textBox.Size = new Size(457, 36);
                            textBox.UnderlinedStyle = true;

                            ProtoculoSLF.AAFControles.AAFBoton btnEsp = new ProtoculoSLF.AAFControles.AAFBoton();
                            btnEsp.BackColor = Color.Transparent;
                            btnEsp.BackgroundColor = Color.Transparent;
                            btnEsp.BorderColor = Color.FromArgb(63, 81, 181);
                            btnEsp.BorderRadius = 10;
                            btnEsp.BorderSize = 3;
                            btnEsp.FlatAppearance.BorderSize = 0;
                            btnEsp.FlatStyle = FlatStyle.Flat;
                            btnEsp.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
                            btnEsp.ForeColor = Color.FromArgb(63, 81, 181);
                            btnEsp.Location = new Point(298, 24);
                            btnEsp.Name = "btnEsp" + numDeControl;
                            btnEsp.Size = new Size(75, 30);
                            btnEsp.Text = i.Especificacion + i.Simbolo + i.EspecificacionMax;
                            btnEsp.TextColor = Color.FromArgb(63, 81, 181);

                            GroupControl groupControl = new GroupControl();
                            pnlContenedor.Controls.Add(groupControl);
                            groupControl.Appearance.BorderColor = Color.FromArgb(227, 242, 253);
                            groupControl.AppearanceCaption.Font = new Font("Libre Franklin SemiBold", 11F, FontStyle.Bold);
                            groupControl.Controls.Add(btnEsp);
                            groupControl.Controls.Add(textBox);
                            groupControl.Dock = DockStyle.Top;
                            groupControl.Margin = new Padding(0);
                            groupControl.Name = "gcControl" + numDeControl;
                            groupControl.Size = new Size(461, 61);
                            groupControl.Text = i.Nombre + " *";
                            Height = Height + groupControl.Height;
                        }
                        break;
                    default:
                        break;
                }
                groupControl1.SendToBack();
                panel1.SendToBack();
            }   
            tbOP.Visible = rbUltimoSeleccionado.Checked;
            lueOP.Visible = !rbUltimoSeleccionado.Checked;
        }

        private void rbEnProduccion_CheckedChanged(object sender, EventArgs e)
        {
            tbOP.Visible = rbUltimoSeleccionado.Checked;
            lueOP.Visible = !rbUltimoSeleccionado.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {

        }
    }
}
