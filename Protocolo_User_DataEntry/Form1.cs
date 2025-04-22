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
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;

namespace Protocolo_User_DataEntry
{
    public partial class Form1 : Form
    {
        public BaseRepository br = new BaseRepository();
        int numDeControl = 1;
        int orden = 0, codigo = 0, idProtocolo = 0;
        string sector = "";
        Codigo codigoDatos = new Codigo();
        List<AAFTextBox> textBoxes = new List<AAFTextBox>();
        List<ProtocoloItem> ensayos = new List<ProtocoloItem>();
        Especificacion espAncho = new Especificacion();
        Especificacion espLargo = new Especificacion();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sector = Program.argumentos[0];
            orden = Convert.ToInt32(Program.argumentos[1]);
            codigo = Convert.ToInt32(Program.argumentos[2]);
            codigoDatos = br.GetDatosDelCodigo(codigo);
            lblTitulo.Text = "Ensayo para: " + orden + "/" + codigo;
            //espAncho= br.GetFichaTecnicaConfeccionAncho(codigo);
            btnEspAncho.Text = espAncho.Medio + "±" + espAncho.Maximo;
            //espLargo = br.GetFichaTecnicaLargoBolsa(codigo);
            btnEspLargo.Text = espLargo.Medio + "±" + espLargo.Maximo;
            GenerarTablaProtocolosItem();
            GetEnsayosPorTurno();

        }
        private void GenerarTablaProtocolosItem()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "Item";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cNombre = new GridColumn();
            cNombre.FieldName = "Nombre";
            cNombre.Caption = "Nombre";
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            GridColumn cValor = new GridColumn();
            cValor.FieldName = "Valor";
            cValor.Caption = "Valor";
            cValor.UnboundDataType = typeof(double);
            cValor.Visible = true;
            cValor.OptionsColumn.AllowEdit = false;

            GridColumn cCreado = new GridColumn();
            cCreado.FieldName = "Creado";
            cCreado.Caption = "Creado";
            cCreado.Visible = true;
            cCreado.UnboundDataType = typeof(DateTime);
            cCreado.OptionsColumn.AllowEdit = false;

            GridColumn cTurno = new GridColumn();
            cTurno.FieldName = "Turno";
            cTurno.Caption = "Turno";
            cTurno.Visible = true;
            cTurno.UnboundDataType = typeof(string);
            cTurno.OptionsColumn.AllowEdit = false;

            gvEnsayos.Columns.AddRange(new GridColumn[] { cId, cNombre, cCreado, cTurno });
            gcEnsayos.DataSource = ensayos;

            GridColumnSortInfo[] sortInfo = {
                new GridColumnSortInfo(gvEnsayos.Columns["Turno"], ColumnSortOrder.Ascending),
                new GridColumnSortInfo(gvEnsayos.Columns["Id"], ColumnSortOrder.Ascending)
            };

            gvEnsayos.SortInfo.ClearAndAddRange(sortInfo, 1);
        }
        private void GetEnsayosPorTurno()
        {
            ensayos = br.GetEnsayos(orden + "/" + codigo,"Produccion");
            gcEnsayos.DataSource = ensayos;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbAncho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                tbLargo.Focus();
            }
        }

        private void tbLargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregarEnsayo.Focus();
            }
        }
        void CrearComponentesPorSector(string sector, int codigo)
        {
            var items = br.GetItemsPorProceso("Confección", codigo);
            items.Remove(items.FirstOrDefault(e => e.Nombre == "Ancho de Bolsa"));
            items.Remove(items.FirstOrDefault(e => e.Nombre == "Largo de Bolsa"));

            switch (sector)
            {
                case "confeccion":
                    foreach (var i in items)
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
                        textBox.KeyDown += new KeyEventHandler(tbControl_KeyDown);
                        textBox.Tag = i.Id+","+i.EsConstante;
                        textBoxes.Add(textBox);

                        ProtoculoSLF.AAFControles.AAFBoton btnMed = new ProtoculoSLF.AAFControles.AAFBoton();
                        btnMed.Location = new Point(67, 28);
                        btnMed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
                        btnMed.Size = new Size(47, 23);
                        btnMed.Text = i.Medida == "Milimetro" ? "MM" : "N";
                        btnMed.TextColor = Color.FromArgb(63, 81, 181);

                        ProtoculoSLF.AAFControles.AAFBoton btnEsp = new ProtoculoSLF.AAFControles.AAFBoton();
                        btnEsp.Location = new Point(120, 28);
                        btnEsp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        btnEsp.BackColor = Color.Transparent;
                        btnEsp.BackgroundColor = Color.Transparent;
                        btnEsp.BorderColor = Color.FromArgb(63, 81, 181);
                        btnEsp.BorderRadius = 10;
                        btnEsp.BorderSize = 3;
                        btnEsp.Cursor = Cursors.Hand;
                        btnEsp.FlatAppearance.BorderSize = 0;
                        btnEsp.FlatStyle = FlatStyle.Flat;
                        btnEsp.Font = new Font("Libre Franklin SemiBold", 8F, FontStyle.Bold);
                        btnEsp.ForeColor = Color.FromArgb(63, 81, 181);
                        btnEsp.Name = "btnEsp" + numDeControl;
                        btnEsp.Size = new Size(75, 23);
                        btnEsp.Text = i.Especificacion + i.Simbolo + i.EspecificacionMax;
                        btnEsp.TextColor = Color.FromArgb(63, 81, 181);
                        btnEsp.UseVisualStyleBackColor = false;

                        GroupControl groupControl = new GroupControl();
                        groupControl.Appearance.BorderColor = Color.FromArgb(227, 242, 253);
                        groupControl.AppearanceCaption.Font = new Font("Libre Franklin SemiBold", 11F, FontStyle.Bold);
                        groupControl.Appearance.Options.UseBorderColor = true;
                        groupControl.AppearanceCaption.Options.UseFont = true;
                        groupControl.Controls.Add(btnMed);
                        groupControl.Controls.Add(btnEsp);
                        groupControl.Controls.Add(textBox);
                        groupControl.Dock = DockStyle.Top;
                        groupControl.Margin = new Padding(0);
                        groupControl.Location = new Point(0, 61);
                        groupControl.Name = "gcControl" + numDeControl;
                        groupControl.Size = new Size(392, 61);
                        groupControl.Text = i.Nombre + " *";
                        Height = Height + groupControl.Height;
                        pnlContenedor.Controls.Add(groupControl);     
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
                        textBox.Tag = i.Id;

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
            //pnlContenedor.SendToBack();
            //tableLayoutPanel2.Visible = true;
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
        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {
            string turno = GetTurno();

            string sqlInsertarProtocoloItem = "INSERT INTO formato_ensayo (op,id_item,valor_ensayo,creado,turno,correcto) VALUES ";
            string sqlInsertarProtocoloItem2 = "";
            if (!ValidarFormularioItems(tbAncho.Texts, false)) return;
            if (!ValidarFormularioItems(tbLargo.Texts, false)) return;

            // Calcular los límites de la tolerancia
            if (!ValidarTolerancia(tbAncho, espAncho.Medio, espAncho.Maximo))
            {
                btnErrorAncho.BackColor = Color.LightCoral;
                btnErrorAncho.Visible = true;              
                return;
            }
            else {
                btnErrorAncho.BackColor = Color.LightGreen;
                btnErrorAncho.Visible = false; 
            }
            if (!ValidarTolerancia(tbLargo, espLargo.Medio, espLargo.Maximo))
            {
                btnErrorLargo.BackColor = Color.LightCoral;
                btnErrorLargo.Visible = true;
                return;
            }
            else {
                btnErrorLargo.BackColor = Color.LightGreen;
                btnErrorLargo.Visible = false;
            }

            var valorEnsayoAncho = Convert.ToDouble(tbAncho.Texts);
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{9}','{valorEnsayoAncho}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{turno}','0'),";

            var valorEnsayoLargo = Convert.ToDouble(tbLargo.Texts);
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{7}','{valorEnsayoLargo}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{turno}','0'),";

            //VERVER
            var contador = 1;
            foreach (Control control in pnlContenedor.Controls)
            {
                if (codigoDatos.Disposicion == 1) {
                    
                    var tb = control.Controls.OfType<AAFTextBox>().FirstOrDefault(txt => txt.Name == "tbControl"+contador);
                    var tag = tb.Tag.ToString();
                    var idItem = Convert.ToInt32(tag.Split(',')[0]);
                    var constante = Convert.ToBoolean(tag.Split(',')[1]);
                    if (!ValidarFormularioItems(tb.Texts, constante)) return;
                    var valorEnsayo = "";
                    var valorConstane = "";
                    valorEnsayo = !constante ? tb.Texts : "0";
                    valorConstane = constante ? tb.Texts : "0";

                    sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{idItem}','{valorEnsayo}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{turno}','{valorConstane}'),";

                    contador++;
                }
            }
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            contador = 1;
            //if (br.InsertEnsayoLote(sqlInsertarProtocoloItem)) {
            //    tbAncho.Texts = "";
            //    tbLargo.Texts = "";                
            //    foreach (Control control in pnlContenedor.Controls)
            //    {
            //        control.Controls.OfType<AAFTextBox>().FirstOrDefault(txt => txt.Name == "tbControl" + contador).Texts = "";
            //        contador++;

            //    }
            //    MessageBox.Show("Ensayo agregado correctamente");
            //    Close();
            //}
        }

        private bool ValidarTolerancia(AAFTextBox tb, double toleranciaMed, double toleranciaMax)
        {
            var valorIngresado = toleranciaMed;
            var valorReferencia = Convert.ToDouble(tb.Texts);

            double limiteInferior = valorIngresado - toleranciaMax * 20;
            double limiteSuperior = valorIngresado + toleranciaMax * 20;
            if (valorReferencia >= limiteInferior && valorReferencia <= limiteSuperior)
            {
                tb.BackColor = Color.LightGreen;
                return true;
            }
            else
            {
                tb.BackColor = Color.LightCoral;
                return false;
            }
        }

        private void btnConvertirMMAncho_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioItems(tbAncho.Texts, false)) return;
            var convertirMM = Convert.ToDouble(tbAncho.Texts)*10;
            tbAncho.Texts = convertirMM.ToString();
        }

        private void btnConvertirMMLargo_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioItems(tbLargo.Texts, false)) return;
            var convertirMM = Convert.ToDouble(tbLargo.Texts) * 10;
            tbLargo.Texts = convertirMM.ToString();
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            Size = new Size(427, 538);
        }

        private void btnAuditor_Click(object sender, EventArgs e)
        {
            pnlContenedor.Controls.Clear();
            CrearComponentesPorSector(sector, codigo);
        }

        private string GetTurno()
        {
            var turnoNombre = "";
            TimeSpan horaAhora = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            if (horaAhora >= new TimeSpan(7, 00, 00) && horaAhora < new TimeSpan(14, 59, 59))
            {
                turnoNombre = "TM";
            }
            if (horaAhora >= new TimeSpan(15, 00, 00) && horaAhora < new TimeSpan(23, 59, 59))
            {
                turnoNombre = "TT";
            }
            if (horaAhora >= new TimeSpan(00, 00, 00) && horaAhora < new TimeSpan(7, 59, 59))
            {
                turnoNombre = "TN";
            }
            return turnoNombre;
        }

        private bool ValidarFormularioItems(string valorEnsayo,bool constante)
        {
            if (valorEnsayo.Contains(".")) valorEnsayo = valorEnsayo.Replace('.', ','); ;
            if (!constante)
            {
                if (!Utils.IsSoloNumODecimal(valorEnsayo))
                {
                    MessageBox.Show("Solo numeros decimales");
                    return false;
                }
            }
            else {
                if (!Utils.IsSoloSignoA(valorEnsayo))
                {
                    MessageBox.Show("Solo valores numericos, ok, no ok, guion(-)");
                    return false;
                }
            }
           
            return true;
        }
    }
}
