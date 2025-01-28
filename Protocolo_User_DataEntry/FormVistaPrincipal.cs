using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using Protocolo_User_DataEntry.Model;
using Protocolo_User_DataEntry.Repository;
using ProtoculoSLF.Repository;
using ScrapKP.AAFControles;

namespace Protocolo_User_DataEntry
{
    public partial class FormVistaPrincipal : Form
    {
        public BaseRepository br = new BaseRepository();
        int orden = 0, codigo = 0, idop = 0, aConfeccionar = 0,idBobinaMadre=0;
        string sector = "",maquina="";
        List<ProtocoloItem> ensayos = new List<ProtocoloItem>();
        private List<ProtocoloItem> items = new List<ProtocoloItem>();
        Especificacion espAncho = new Especificacion();
        Especificacion espLargo = new Especificacion();
        public FormVistaPrincipal()
        {
            InitializeComponent();
            EsconderTab(tcPrincipal);
          
            sector = Program.argumentos[0];
            orden = Convert.ToInt32(Program.argumentos[1]);
            codigo = Convert.ToInt32(Program.argumentos[2]);
            maquina = Program.argumentos[3];
            idop = Convert.ToInt32(Program.argumentos[4]);
            aConfeccionar = Convert.ToInt32(Program.argumentos[5]);
            var muestreo = br.VerificarMuestreo(idop, aConfeccionar);
            lblEnsayosNecesarios.Text = muestreo.Realizadas + "/" + muestreo.Requeridas;

            lblTitulo.Text = "Ensayo para: " + orden + "/" + codigo;
            espAncho = br.GetFichaLogisticaConfeccionAncho(codigo);
            btnEspAncho.Text = espAncho.Medio + "±" + espAncho.Maximo;
            espLargo = br.GetFichaLogisticaConfeccionLargo(codigo);
            btnEspLargo.Text = espLargo.Medio + "±" + espLargo.Maximo;

            GenerarTablaItemsValor();
            GetItems();

            GenerarTablaProtocolosItem();
            GetEnsayosPorTurno();
        }
        private void GetEnsayosPorTurno()
        {
            //ensayos = br.GetEnsayos(idop.ToString(), "Produccion");
            //gcEnsayos.DataSource = ensayos;
            //gvEnsayos.ExpandAllGroups();

        }
        private void GetEnsayosPorTurnoAuditor()
        {
            //ensayos = br.GetEnsayos(idop.ToString(), "Auditor");
            //gcEnsayos.DataSource = ensayos;
            //gvEnsayos.ExpandAllGroups();

        }
        private void GetItems()
        {
            items = br.GetItems();
            gcItemsValor.DataSource = items;
        }

        private void EsconderTab(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
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

            gvEnsayos.Columns.AddRange(new GridColumn[] { cId, cNombre,cValor, cCreado, cTurno });
            gcEnsayos.DataSource = ensayos;

            GridColumnSortInfo[] sortInfo = {
                new GridColumnSortInfo(gvEnsayos.Columns["Turno"], ColumnSortOrder.Ascending),
                new GridColumnSortInfo(gvEnsayos.Columns["Id"], ColumnSortOrder.Ascending)
            };

            gvEnsayos.SortInfo.ClearAndAddRange(sortInfo, 1);
        }
        private void GenerarTablaItemsValor()
        {
            GridColumn cId = new GridColumn();
            cId.FieldName = "Id";
            cId.Caption = "";
            cId.UnboundDataType = typeof(int);
            cId.OptionsColumn.AllowEdit = false;

            GridColumn cNombre = new GridColumn();
            cNombre.FieldName = "Nombre";
            cNombre.Caption = "Nombre";
            cNombre.UnboundDataType = typeof(string);
            cNombre.Visible = true;
            cNombre.OptionsColumn.AllowEdit = false;

            GridColumn cMedida = new GridColumn();
            cMedida.FieldName = "Medida";
            cMedida.Caption = "Medida";
            cMedida.UnboundDataType = typeof(string);
            cMedida.Visible = true;
            cMedida.OptionsColumn.AllowEdit = false;

            GridColumn cValor = new GridColumn();
            cValor.FieldName = "Valor";
            cValor.Caption = "Valor";
            cValor.Visible = true;
            cValor.UnboundDataType = typeof(string);

            GridColumn cEspecificacion = new GridColumn();
            cEspecificacion.FieldName = "EspecificacionDato";
            cEspecificacion.Caption = "Especificación";
            cEspecificacion.Visible = true;
            cEspecificacion.UnboundDataType = typeof(string);
            cEspecificacion.OptionsColumn.AllowEdit = false;

            GridColumn cOrden = new GridColumn();
            cOrden.FieldName = "Orden";
            cOrden.Caption = "Pos°";
            cOrden.Visible = true;
            cOrden.UnboundDataType = typeof(int);
            cOrden.OptionsColumn.AllowEdit = false;

            gvItemsValor.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cValor, cEspecificacion, cOrden });
            gcItemsValor.DataSource = items;
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
            if (horaAhora >= new TimeSpan(00, 00, 00) && horaAhora < new TimeSpan(6, 59, 59))
            {
                turnoNombre = "TN";
            }
            return turnoNombre;
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
        private bool ValidarFormularioItems(string valorEnsayo, bool constante)
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
            else
            {
                if (!Utils.IsSoloSignoA(valorEnsayo))
                {
                    MessageBox.Show("Solo valores numericos, ok, no ok, guion(-)");
                    return false;
                }
            }

            return true;
        }

        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {
            var ensayo = new ProtocoloItem();
            ensayo.Turno = GetTurno();
            ensayo.OP = idop.ToString();
          

            if (tcPrincipal.SelectedTab == tpProduccion)
            {         
                if (!ValidarFormularioItems(tbAncho.Texts, false)) return;
                if (!ValidarFormularioItems(tbLargo.Texts, false)) return;

                //calcular los limites tolerancia
                if (!ValidarTolerancia(tbAncho, espAncho.Medio, espAncho.Maximo))
                {
                    btnErrorAncho.BackColor = Color.LightCoral;
                    btnErrorAncho.Visible = true;
                    return;
                }
                else
                {
                    btnErrorAncho.BackColor = Color.LightGreen;
                    btnErrorAncho.Visible = false;
                }
                if (!ValidarTolerancia(tbLargo, espLargo.Medio, espLargo.Maximo))
                {
                    btnErrorLargo.BackColor = Color.LightCoral;
                    btnErrorLargo.Visible = true;
                    return;
                }
                else
                {
                    btnErrorLargo.BackColor = Color.LightGreen;
                    btnErrorLargo.Visible = false;
                }

                List<ItemValor> valores = new List<ItemValor> {
                new ItemValor{ Valor=Convert.ToDouble(tbAncho.Texts), ValorConstante="0",IdItem=9,IdBobinaMadre=idBobinaMadre },
                new ItemValor{ Valor=Convert.ToDouble(tbLargo.Texts), ValorConstante="0",IdItem=7,IdBobinaMadre=idBobinaMadre },
            };

                if (br.InsertEnsayoLote(valores, ensayo))
                {
                    tbAncho.Texts = "";
                    tbLargo.Texts = "";
                    MessageBox.Show("Ensayo agregado correctamente");
                    Close();
                }
            }
            else {

                //for (int i = 0; i < gvItemsValor.RowCount; i++)
                //{
                //    var idSeleccionado = (int)gvItemsValor.GetRowCellValue(i, "Id");
                //    var item = items.FirstOrDefault(d => d.Id == idSeleccionado);
                //    if (item.EsConstante) { 
                //        item.ValorConstante = item.Valor.ToString();
                //        item.Valor = "0";
                //    }
                //    else item.ValorConstante = "0";

                //    sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{idop}','{item.Id}','{item.Valor}','{item.ValorConstante}'),";
                    
                //}
                //sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
                //sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
                //if (br.InsertEnsayoLote(sqlInsertarProtocoloItem, ensayo))
                //{
                //    tbAncho.Texts = "";
                //    tbLargo.Texts = "";
                //    MessageBox.Show("Ensayo agregado correctamente");
                //    Close();
                //}
            }
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpProduccion;
            GetEnsayosPorTurno();
        }

        private void btnAuditor_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpAuditor;
            GetEnsayosPorTurnoAuditor();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
