using DevExpress.XtraEditors;
using ScrapKP.AAFControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Protocolo_User_DataEntry
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        AAFTextBox textBox = new AAFTextBox();
        void CrearComponentesPorSector(string sector, int codigo)
        {
        //    switch (sector)
        //    {
        //        case "confeccion":
        //            foreach (var i in br.GetItemsPorProceso("Confección", codigo))
        //            {
        //                AAFTextBox textBox = new AAFTextBox();
        //                textBox.BackColor = Color.White;
        //                textBox.BorderColor = Color.FromArgb(63, 81, 181);
        //                textBox.BorderSize = 2;
        //                textBox.Dock = DockStyle.Fill;
        //                textBox.Font = new Font("Libre Franklin SemiBold", 10F, FontStyle.Bold);
        //                textBox.ForeColor = SystemColors.GrayText;
        //                textBox.Margin = new Padding(4);
        //                textBox.Multiline = false;
        //                textBox.Name = "tbControl" + numDeControl;
        //                textBox.Padding = new Padding(19, 8, 8, 8);
        //                textBox.SelectionStart = 0;
        //                textBox.Size = new Size(457, 36);
        //                textBox.UnderlinedStyle = true;
        //                textBox.Tag = i.IdProtocoloItem;
        //                textBox.KeyDown += new KeyEventHandler(tbControl_KeyDown);
        //                textBoxes.Add(textBox);

        //                ProtoculoSLF.AAFControles.AAFBoton btnEsp = new ProtoculoSLF.AAFControles.AAFBoton();
        //                btnEsp.BackColor = Color.Transparent;
        //                btnEsp.BackgroundColor = Color.Transparent;
        //                btnEsp.BorderColor = Color.FromArgb(63, 81, 181);
        //                btnEsp.BorderRadius = 10;
        //                btnEsp.BorderSize = 3;
        //                btnEsp.FlatAppearance.BorderSize = 0;
        //                btnEsp.FlatStyle = FlatStyle.Flat;
        //                btnEsp.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
        //                btnEsp.ForeColor = Color.FromArgb(63, 81, 181);
        //                btnEsp.Name = "btnEsp" + numDeControl;
        //                btnEsp.Size = new Size(75, 30);
        //                btnEsp.Text = i.Especificacion + i.Simbolo + i.EspecificacionMax;
        //                btnEsp.TextColor = Color.FromArgb(63, 81, 181);
        //                btnEsp.Dock = DockStyle.Right;

        //                ProtoculoSLF.AAFControles.AAFBoton btnMed = new ProtoculoSLF.AAFControles.AAFBoton();
        //                btnMed.BackColor = Color.Transparent;
        //                btnMed.BackgroundColor = Color.Transparent;
        //                btnMed.BorderColor = Color.FromArgb(63, 81, 181);
        //                btnMed.BorderRadius = 10;
        //                btnMed.BorderSize = 3;
        //                btnMed.FlatAppearance.BorderSize = 0;
        //                btnMed.FlatStyle = FlatStyle.Flat;
        //                btnMed.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
        //                btnMed.ForeColor = Color.FromArgb(63, 81, 181);
        //                btnMed.Name = "btnMed" + numDeControl;
        //                btnMed.Size = new Size(47, 36);
        //                btnMed.Text = i.Medida == "Milimetro" ? "MM" : "N";
        //                btnMed.TextColor = Color.FromArgb(63, 81, 181);
        //                btnMed.Dock = DockStyle.Right;

        //                GroupControl groupControl = new GroupControl();
        //                pnlContenedor.Controls.Add(groupControl);
        //                groupControl.Appearance.BorderColor = Color.FromArgb(227, 242, 253);
        //                groupControl.AppearanceCaption.Font = new Font("Libre Franklin SemiBold", 11F, FontStyle.Bold);
        //                groupControl.Controls.Add(btnMed);
        //                groupControl.Controls.Add(btnEsp);
        //                groupControl.Controls.Add(textBox);
        //                groupControl.Dock = DockStyle.Top;
        //                groupControl.Margin = new Padding(0);
        //                groupControl.Name = "gcControl" + numDeControl;
        //                groupControl.Size = new Size(461, 61);
        //                groupControl.Text = i.Nombre + " *";
        //                Height = Height + groupControl.Height;
        //                tableLayoutPanel2.Visible = true;
        //                numDeControl++;
        //            }
        //            break;
        //        case "extrusion":
        //            foreach (var i in br.GetItemsPorProceso("Extrusión", codigo))
        //            {
        //                AAFTextBox textBox = new AAFTextBox();
        //                textBox.BackColor = Color.White;
        //                textBox.BorderColor = Color.FromArgb(63, 81, 181);
        //                textBox.BorderSize = 2;
        //                textBox.Dock = DockStyle.Fill;
        //                textBox.Font = new Font("Libre Franklin SemiBold", 10F, FontStyle.Bold);
        //                textBox.ForeColor = SystemColors.GrayText;
        //                textBox.Margin = new Padding(4);
        //                textBox.Multiline = false;
        //                textBox.Name = "tbControl" + numDeControl;
        //                textBox.Padding = new Padding(19, 8, 8, 8);
        //                textBox.SelectionStart = 0;
        //                textBox.Size = new Size(457, 36);
        //                textBox.UnderlinedStyle = true;
        //                textBox.Tag = i.IdProtocoloItem;

        //                ProtoculoSLF.AAFControles.AAFBoton btnEsp = new ProtoculoSLF.AAFControles.AAFBoton();
        //                btnEsp.BackColor = Color.Transparent;
        //                btnEsp.BackgroundColor = Color.Transparent;
        //                btnEsp.BorderColor = Color.FromArgb(63, 81, 181);
        //                btnEsp.BorderRadius = 10;
        //                btnEsp.BorderSize = 3;
        //                btnEsp.FlatAppearance.BorderSize = 0;
        //                btnEsp.FlatStyle = FlatStyle.Flat;
        //                btnEsp.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
        //                btnEsp.ForeColor = Color.FromArgb(63, 81, 181);
        //                btnEsp.Name = "btnEsp" + numDeControl;
        //                btnEsp.Size = new Size(75, 30);
        //                btnEsp.Text = i.Especificacion + i.Simbolo + i.EspecificacionMax;
        //                btnEsp.TextColor = Color.FromArgb(63, 81, 181);
        //                btnEsp.Dock = DockStyle.Right;

        //                ProtoculoSLF.AAFControles.AAFBoton btnMed = new ProtoculoSLF.AAFControles.AAFBoton();
        //                btnMed.BackColor = Color.Transparent;
        //                btnMed.BackgroundColor = Color.Transparent;
        //                btnMed.BorderColor = Color.FromArgb(63, 81, 181);
        //                btnMed.BorderRadius = 10;
        //                btnMed.BorderSize = 3;
        //                btnMed.FlatAppearance.BorderSize = 0;
        //                btnMed.FlatStyle = FlatStyle.Flat;
        //                btnMed.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
        //                btnMed.ForeColor = Color.FromArgb(63, 81, 181);
        //                btnMed.Name = "btnMed" + numDeControl;
        //                btnMed.Size = new Size(47, 36);
        //                btnMed.Text = i.Medida == "Milimetro" ? "MM" : "N";
        //                btnMed.TextColor = Color.FromArgb(63, 81, 181);
        //                btnMed.Dock = DockStyle.Right;

        //                GroupControl groupControl = new GroupControl();
        //                pnlContenedor.Controls.Add(groupControl);
        //                groupControl.Appearance.BorderColor = Color.FromArgb(227, 242, 253);
        //                groupControl.AppearanceCaption.Font = new Font("Libre Franklin SemiBold", 11F, FontStyle.Bold);
        //                groupControl.Controls.Add(btnMed);
        //                groupControl.Controls.Add(btnEsp);
        //                groupControl.Controls.Add(textBox);
        //                groupControl.Dock = DockStyle.Top;
        //                groupControl.Margin = new Padding(0);
        //                groupControl.Name = "gcControl" + numDeControl;
        //                groupControl.Size = new Size(461, 61);
        //                groupControl.Text = i.Nombre + " *";
        //                Size = new Size(450, 255);
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    numDeControl = 1;
        }
    }
}
