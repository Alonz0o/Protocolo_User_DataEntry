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
            espAncho= br.GetFichaLogisticaConfeccionAncho(codigo);
            btnEspAncho.Text = espAncho.Medio + "±" + espAncho.Maximo;
            espLargo = br.GetFichaLogisticaConfeccionLargo(codigo);
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
            ensayos = br.GetEnsayos(orden + "/" + codigo);
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

        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {
            string turno = GetTurno();

            string sqlInsertarProtocoloItem = "INSERT INTO formato_ensayo (op,id_item,valor_ensayo,creado,turno) VALUES ";
            string sqlInsertarProtocoloItem2 = "";
            if (!ValidarFormularioItems(tbAncho.Texts)) return;
            if (!ValidarFormularioItems(tbLargo.Texts)) return;

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
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{9}','{valorEnsayoAncho}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{turno}'),";

            var valorEnsayoLargo = Convert.ToDouble(tbLargo.Texts);
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{7}','{valorEnsayoLargo}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{turno}'),";

            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
           
            if (br.InsertEnsayoLote(sqlInsertarProtocoloItem))
            {
                tbAncho.Texts = "";
                tbLargo.Texts = "";
                MessageBox.Show("Ensayo agregado");
                Close();
            }

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
            if (!ValidarFormularioItems(tbAncho.Texts)) return;
            var convertirMM = Convert.ToDouble(tbAncho.Texts)*10;
            tbAncho.Texts = convertirMM.ToString();
        }

        private void btnConvertirMMLargo_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioItems(tbLargo.Texts)) return;
            var convertirMM = Convert.ToDouble(tbLargo.Texts) * 10;
            tbLargo.Texts = convertirMM.ToString();
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            Size = new Size(427, 514);
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
