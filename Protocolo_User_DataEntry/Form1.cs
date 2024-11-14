using DevExpress.XtraEditors;
using IniParser.Model;
using IniParser;
using Protocolo_User_DataEntry.Model;
using Protocolo_User_DataEntry.Repository;
using ProtoculoSLF.Repository;
using ScrapKP.AAFControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Protocolo_User_DataEntry
{
    public partial class Form1 : Form
    {
        public BaseRepository br = new BaseRepository();
        int numDeControl = 1;
        int orden = 0, codigo = 0, idProtocolo = 0;
        string sector = "";
        Codigo codigoDatos = new Codigo();
        string archivoINI = Directory.GetCurrentDirectory() + @"\config.ini";
        List<AAFTextBox> textBoxes = new List<AAFTextBox>();
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(archivoINI)) File.Create(archivoINI).Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sector = Program.argumentos[0];
            orden = Convert.ToInt32(Program.argumentos[1]);
            codigo = Convert.ToInt32(Program.argumentos[2]);
            codigoDatos = br.GetDatosDelCodigo(codigo);
            lblTitulo.Text = "Ensayo para: " + orden + "/" + codigo;
            CrearComponentesPorSector(sector,codigo);
            lueMaquina.Properties.DataSource = br.GetMaquinasConfeccion();
        }
        private string LeerConfigUltimaOP()
        {
            var op = "";
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(archivoINI);
            op = data["UltimaOP"]["OP"];
            return op;
        }
        private void GuardarUltimaOP(string op)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(archivoINI);
            data["UltimaOP"]["OP"] = op;
            parser.WriteFile(archivoINI, data);
        }

        void CrearComponentesPorSector(string sector,int codigo) {
            switch (sector)
            {
                case "confeccion":
                    foreach (var i in br.GetItemsPorProceso("Confección", codigo))
                    {
                        AAFTextBox textBox = new AAFTextBox();
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
                        textBox.Tag = i.IdProtocoloItem;
                        textBox.KeyDown += new KeyEventHandler(tbControl_KeyDown);
                        textBoxes.Add(textBox);

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
                        btnEsp.Name = "btnEsp" + numDeControl;
                        btnEsp.Size = new Size(75, 30);
                        btnEsp.Text = i.Especificacion + i.Simbolo + i.EspecificacionMax;
                        btnEsp.TextColor = Color.FromArgb(63, 81, 181);
                        btnEsp.Dock = DockStyle.Right;

                        ProtoculoSLF.AAFControles.AAFBoton btnMed = new ProtoculoSLF.AAFControles.AAFBoton();
                        btnMed.BackColor = Color.Transparent;
                        btnMed.BackgroundColor = Color.Transparent;
                        btnMed.BorderColor = Color.FromArgb(63, 81, 181);
                        btnMed.BorderRadius = 10;
                        btnMed.BorderSize = 3;
                        btnMed.FlatAppearance.BorderSize = 0;
                        btnMed.FlatStyle = FlatStyle.Flat;
                        btnMed.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
                        btnMed.ForeColor = Color.FromArgb(63, 81, 181);
                        btnMed.Name = "btnMed" + numDeControl;
                        btnMed.Size = new Size(47, 36);
                        btnMed.Text = i.Medida == "Milimetro" ? "MM" : "N";
                        btnMed.TextColor = Color.FromArgb(63, 81, 181);
                        btnMed.Dock = DockStyle.Right;

                        GroupControl groupControl = new GroupControl();
                        pnlContenedor.Controls.Add(groupControl);
                        groupControl.Appearance.BorderColor = Color.FromArgb(227, 242, 253);
                        groupControl.AppearanceCaption.Font = new Font("Libre Franklin SemiBold", 11F, FontStyle.Bold);
                        groupControl.Controls.Add(btnMed);
                        groupControl.Controls.Add(btnEsp);
                        groupControl.Controls.Add(textBox);
                        groupControl.Dock = DockStyle.Top;
                        groupControl.Margin = new Padding(0);
                        groupControl.Name = "gcControl" + numDeControl;
                        groupControl.Size = new Size(461, 61);
                        groupControl.Text = i.Nombre + " *";
                        Height = Height + groupControl.Height;
                        tableLayoutPanel2.Visible = true;
                        numDeControl++;                        
                    }
                    break;
                case "extrusion":
                    foreach (var i in br.GetItemsPorProceso("Extrusión", codigo))
                    {
                        AAFTextBox textBox = new AAFTextBox();
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
                        textBox.Tag = i.IdProtocoloItem;

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
                        btnEsp.Name = "btnEsp" + numDeControl;
                        btnEsp.Size = new Size(75, 30);
                        btnEsp.Text = i.Especificacion + i.Simbolo + i.EspecificacionMax;
                        btnEsp.TextColor = Color.FromArgb(63, 81, 181);
                        btnEsp.Dock = DockStyle.Right;

                        ProtoculoSLF.AAFControles.AAFBoton btnMed = new ProtoculoSLF.AAFControles.AAFBoton();
                        btnMed.BackColor = Color.Transparent;
                        btnMed.BackgroundColor = Color.Transparent;
                        btnMed.BorderColor = Color.FromArgb(63, 81, 181);
                        btnMed.BorderRadius = 10;
                        btnMed.BorderSize = 3;
                        btnMed.FlatAppearance.BorderSize = 0;
                        btnMed.FlatStyle = FlatStyle.Flat;
                        btnMed.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
                        btnMed.ForeColor = Color.FromArgb(63, 81, 181);
                        btnMed.Name = "btnMed" + numDeControl;
                        btnMed.Size = new Size(47, 36);
                        btnMed.Text = i.Medida == "Milimetro" ? "MM" : "N";
                        btnMed.TextColor = Color.FromArgb(63, 81, 181);
                        btnMed.Dock = DockStyle.Right;

                        GroupControl groupControl = new GroupControl();
                        pnlContenedor.Controls.Add(groupControl);
                        groupControl.Appearance.BorderColor = Color.FromArgb(227, 242, 253);
                        groupControl.AppearanceCaption.Font = new Font("Libre Franklin SemiBold", 11F, FontStyle.Bold);
                        groupControl.Controls.Add(btnMed);
                        groupControl.Controls.Add(btnEsp);
                        groupControl.Controls.Add(textBox);
                        groupControl.Dock = DockStyle.Top;
                        groupControl.Margin = new Padding(0);
                        groupControl.Name = "gcControl" + numDeControl;
                        groupControl.Size = new Size(461, 61);
                        groupControl.Text = i.Nombre + " *";
                        Size = new Size(450, 255);
                    }
                    break;
                default:
                    break;
            }
            numDeControl = 1;
        }
        int contadorTB = 0;
        private void tbControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (contadorTB < textBoxes.Count - 1)
                {
                    textBoxes[contadorTB].Focus();
                    contadorTB++;
                }
                else
                {
                    btnAgregarEnsayo.Focus();
                    contadorTB = 0;
                }

            }

        }

        private void rbUltimoSeleccionado_CheckedChanged(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Size = new Size(427, 377);
            if (rbUltimoSeleccionado.Checked) {
                var op = LeerConfigUltimaOP();
                tbOP.Texts = op;
                if (!Utils.IsSoloNumOP(op)) return;             
                CrearComponentesPorSector(sector, Convert.ToInt32(op.Split('/')[1]));
                lblTitulo.Text = "Ensayo para: " + op;

            }

            groupControl2.Visible = rbUltimoSeleccionado.Checked;
            groupControl6.Visible = !rbUltimoSeleccionado.Checked;
        }

        private void rbEnProduccion_CheckedChanged(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Size = new Size(427, 377);
            groupControl2.Visible = rbUltimoSeleccionado.Checked;
            groupControl6.Visible = !rbUltimoSeleccionado.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!Utils.IsSoloNumOP(tbOP.Texts))
                {
                    MessageBox.Show("Solo numeros separados por (/), ejemplo 0120/1993");
                    return;
                }
                GuardarUltimaOP(tbOP.Texts);
                int codigo = Convert.ToInt32(tbOP.Texts.Split('/')[1]);
                pnlContenedor.Controls.Clear();
                Size = new Size(427, 377);
                CrearComponentesPorSector(sector,codigo);
                if (pnlContenedor.Controls.Count > 0) {
                    BuscarPrimerTextBox(pnlContenedor).Focus();
                }

            }
        }
        private AAFTextBox BuscarPrimerTextBox(Control panel)
        {
            foreach (Control control in panel.Controls)
            {
                // Si es TextBox, lo retorna inmediatamente
                if (control is AAFTextBox textBox)
                {
                    return textBox;
                }

                // Si el control tiene hijos (es un panel anidado), busca recursivamente
                if (control.HasChildren)
                {
                    AAFTextBox encontrado = BuscarPrimerTextBox(control);
                    if (encontrado != null)
                    {
                        return encontrado;
                    }
                }
            }

            // Retorna null si no encuentra ningún TextBox
            return null;
        }
        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {
            string sqlInsertarProtocoloItem = "INSERT INTO formato_ensayo (op,id_protocolo_item,valor_ensayo,creado) VALUES ";
            string sqlInsertarProtocoloItem2 = "";
            var contador = 1;
            foreach (Control control in pnlContenedor.Controls)
            {
                if (codigoDatos.Disposicion == 1) {
                    
                    var tb = control.Controls.OfType<AAFTextBox>().FirstOrDefault(txt => txt.Name == "tbControl"+contador);
                    if (!ValidarFormularioItems(tb.Texts)) return;
                    var valorEnsayo = Convert.ToDouble(tb.Texts);

                    var idProtocolo_item = Convert.ToInt32(tb.Tag);
                    sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{idProtocolo_item}','{valorEnsayo}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'),";

                    contador++;
                }
            }
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            contador = 1;
            if (br.InsertEnsayoLote(sqlInsertarProtocoloItem)) {
                foreach (Control control in pnlContenedor.Controls)
                {
                    control.Controls.OfType<AAFTextBox>().FirstOrDefault(txt => txt.Name == "tbControl" + contador).Texts = "";
                    contador++;

                }
                MessageBox.Show("Ensayo agregado correctamente");
            }

        }

        private bool ValidarFormularioItems(string valorEnsayo)
        {

            if (valorEnsayo.Contains(".")) valorEnsayo = valorEnsayo.Replace('.', ','); ;

            if (!Utils.IsSoloNumODecimal(valorEnsayo))
            {
                MessageBox.Show("Solo numeros decimales");
                return false;
            }
            return true;
        }
    }
}
