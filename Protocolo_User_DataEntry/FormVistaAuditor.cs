using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using FontAwesome.Sharp;
using Protocolo_User_DataEntry.Model;
using Protocolo_User_DataEntry.Repository;
using ProtoculoSLF;
using ProtoculoSLF.Repository;

namespace Protocolo_User_DataEntry
{
    public partial class FormVistaAuditor : Form
    {
        public static FormVistaAuditor instancia;
        public BaseRepository br = new BaseRepository();
        public string legajo = "";
        List<ProtocoloItem> ensayos = new List<ProtocoloItem>();
        OP opSeleccionada = new OP();
        private List<ProtocoloItem> items = new List<ProtocoloItem>();
        public Especificacion espAncho = new Especificacion();
        public Especificacion espLargo = new Especificacion();
        public Especificacion espEspesor = new Especificacion();

        private void lueMaquina_EditValueChanged(object sender, EventArgs e)
        {
            var ops = br.GetOps(lueMaquina.Text);
            if (ops.Count == 0)
            {
                MessageBox.Show("Esta maquina no tiene ordenes de produccion.");
                groupControl1.Enabled = false;
                groupControl4.Enabled = false;
                groupControl4.Text = "Objeto";
                lueOP.Properties.DataSource = ops;
                tbNumPaquete.Texts = "";
                gcItemsValor.DataSource = null;
            }
            else
            {
                lueOP.Properties.DataSource = ops;
                groupControl1.Enabled = true;
            }
        }
        private void lueOP_EditValueChanged(object sender, EventArgs e)
        {
            opSeleccionada = lueOP.GetSelectedDataRow() as OP;
            if (opSeleccionada == null)
            {
                MessageBox.Show("Debe ingresar OP.");
                return;
            }
            var ultimoProceso = br.GetCodigoUltimoProceso(opSeleccionada.Codigo);

            VerificarObjetoEnsayado(ultimoProceso);
          
            lblTitulo.Text = "Ensayo para: " + lueOP.Text;
            groupControl4.Enabled = true;
            espAncho = br.GetFichaTecnicaAnchoBolsa(opSeleccionada.Codigo, ultimoProceso);
            espLargo = br.GetFichaTecnicaLargoBolsa(opSeleccionada.Codigo, ultimoProceso);
            espEspesor = br.GetFichaTecnicaEspesorBolsa(opSeleccionada.Codigo, ultimoProceso);
            GetItems(lueMaquina.Text);


        }

        private void VerificarObjetoEnsayado(int ultimoProceso)
        {
            groupControl4.Text = ultimoProceso == 1 ? "Bobina Extrusión N°" :
                                 ultimoProceso == 2 ? "Bobina Impresión N°" :
                                 ultimoProceso == 3 ? "Bulto N°" :
                                 ultimoProceso == 4 ? "Bobina Rebobinado N°" :
                                 ultimoProceso == 5 ? "Caja N°" : "Otros";

        }

        private void EsconderTab(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

      
        public FormVistaAuditor()
        {
            InitializeComponent();
            instancia = this;
            GenerarTablaItemsValor();
            GenerarTablaProtocolosItem();
            lueMaquina.Properties.DataSource = br.GetMaquinas().OrderBy(e => e.Nombre);
            lueLegAuditor.Properties.DataSource = br.GetAuditores();
            EsconderTab(tcItemDatos);
            List<string> turnos = new List<string> {
                "F",
                "A",
                "B",
                "C",
                "D",
                "E",
                "LARGADA",
            };

            lueTurno.Properties.DataSource = turnos;
         
        }
        private int BuscarUnidadIndex(string medida)
        {
            var dataSource = lueTurno.Properties.DataSource as List<string>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => medida == e);
                return index != -1 ? index : 0;
            }
            return 0;
        }
        private int BuscarMaquinaIndex(string maquina)
        {
            var dataSource = lueMaquina.Properties.DataSource as List<Maquina>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => maquina == e.Nombre);
                return index != -1 ? index : 0;
            }
            return 0;
        }
        private void GridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void GridView1_DragDrop(object sender, DragEventArgs e)
        {
            var ooo = items;
            var data = (ProtocoloItem)e.Data.GetData(typeof(ProtocoloItem));

            Point pt = gvItemsValor.GridControl.PointToClient(new Point(e.X, e.Y));
            int destinoIndex = gvItemsValor.CalcHitInfo(pt).RowHandle;
            if (destinoIndex >= 0)
            {
                int origenIndex = gvItemsValor.FocusedRowHandle;

                var item = items[origenIndex];
                if (br.CambiarPosicionItem(item.Id, destinoIndex))
                {
                    items.RemoveAt(origenIndex);
                    items.Insert(destinoIndex, item);
                    if (origenIndex != destinoIndex)
                    {
                        data.Posicion = destinoIndex;
                        gvItemsValor.RefreshData();
                        gvItemsValor.FocusedRowHandle = destinoIndex;
                    }
                }

            }
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

            gvItemsValor.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cValor, cEspecificacion });
            gcItemsValor.DataSource = items;
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

            GridColumn cLegajo = new GridColumn();
            cLegajo.FieldName = "Legajo";
            cLegajo.Caption = "Leg N°";
            cLegajo.UnboundDataType = typeof(int);
            cLegajo.OptionsColumn.AllowEdit = false;
            cLegajo.Visible = true;

            GridColumn cNumPaquete = new GridColumn();
            cNumPaquete.FieldName = "PaqueteNum";
            cNumPaquete.Caption = "Paquete N°";
            cNumPaquete.UnboundDataType = typeof(int);
            cNumPaquete.OptionsColumn.AllowEdit = false;
            cNumPaquete.Visible = true;

            gvEnsayos.Columns.AddRange(new GridColumn[] { cId, cNombre, cLegajo, cValor, cCreado, cTurno, cNumPaquete });
            gcEnsayos.DataSource = ensayos;
            gvEnsayos.Columns["Creado"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            GridColumnSortInfo[] sortInfo = {
                new GridColumnSortInfo(gvEnsayos.Columns["Turno"], ColumnSortOrder.Ascending),
                new GridColumnSortInfo(gvEnsayos.Columns["Paquete"], ColumnSortOrder.Descending)
            };

            gvEnsayos.SortInfo.ClearAndAddRange(sortInfo, 1);
        }
        private void GetItems(string maquina)
        {
            items = br.GetItemsPorMaquina(maquina,"auditoria").OrderBy(e => e.Posicion).ToList();
            gcItemsValor.DataSource = items;
            gvItemsValor.BestFitColumns();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            tcItemDatos.SelectedTab = tpDatos;
            GetEnsayosPorPaquete(opSeleccionada.CantProduccion, false);
        }

        private void btnVerItems_Click(object sender, EventArgs e)
        {
            tcItemDatos.SelectedTab = tpItems;

        }

        private void GetEnsayosPorTurno(int op)
        {
            ensayos = br.GetEnsayos(op.ToString(), "Produccion");
            gcEnsayos.DataSource = ensayos;
            gvEnsayos.ExpandAllGroups();

        }
        private void GetEnsayosPorPaquete(int op, bool esPorPaquete)
        {
            if (esPorPaquete)
            {
                var numPaquete = tbNumPaquete.Texts;
                if (!Utils.IsSoloNumerico(numPaquete))
                {
                    if (numPaquete == "0") MessageBox.Show("El numero de paquete no puede ser 0.");
                    MessageBox.Show("Debe ingresar numero de paquete.");
                }
                ensayos = br.GetEnsayosPorPaqueteAuditoria(op.ToString(), Convert.ToInt32(numPaquete), 1);

            }
            else
            {
                ensayos = br.GetEnsayosPorPaqueteAuditoria(op.ToString(), 0, 0);
            }

            gcEnsayos.DataSource = ensayos;
            gvEnsayos.ExpandAllGroups();

        }

        private void btnAgregarEnsayo_Click(object sender, EventArgs e)
        {
            var ensayo = new ProtocoloItem();
            ensayo.Turno = lueTurno.Text;
            ensayo.OP = opSeleccionada.CantProduccion.ToString();

            //VERIFICAR SIMBOLO
            var lueAuditorA = lueLegAuditor.GetSelectedDataRow() as Usuario;
            if (lueAuditorA == null)
            {
                MessageBox.Show("Debe seleccionar auditor.");
                return;
            }
            //VERIFICAR PAQUETE       
            ensayo.Legajo = lueAuditorA.Legajo;

            if (!Utils.IsSoloNumerico(tbNumPaquete.Texts))
            {
                MessageBox.Show("Debe ingresar numero de paquete.");
                return;
            }

            ensayo.PaqueteNum = Convert.ToInt32(tbNumPaquete.Texts);

            ensayo.Legajo = lueAuditorA.Legajo;
            List<ItemValor> valores = new List<ItemValor>();
            for (int i = 0; i < gvItemsValor.RowCount; i++)
            {
                var idSeleccionado = (int)gvItemsValor.GetRowCellValue(i, "Id");
                var item = items.FirstOrDefault(d => d.Id == idSeleccionado);
                if (item.Valor != null)
                {
                    if (item.Valor == "0") continue;
                    item.Valor = item.Valor.Replace(',', '.');

                    if (item.EsConstante || item.Medida == "Fuelle")
                    {
                        item.ValorConstante = item.Valor.ToString();
                        item.Valor = "0";

                    }
                    else item.ValorConstante = "0";
                    valores.Add(new ItemValor { Valor = item.Valor, ValorConstante = item.ValorConstante, IdItem = item.Id, IdBobinaMadre = 0 });
                };
            }
            if (valores.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un valor de ensayo.");
                return;
            }
            if (br.InsertEnsayoLoteAuditor(valores, ensayo))
            {
                MessageBox.Show("Ensayo agregado correctamente");
                for (int i = 0; i < gvItemsValor.RowCount; i++)
                {
                    gvItemsValor.SetRowCellValue(i, "Valor", "");
                }
                gvItemsValor.FocusedRowHandle = 0;

            }
        }
        private string GetTurno()
        {
            var turnoNombre = "";
            TimeSpan horaAhora = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            if (horaAhora >= new TimeSpan(03, 00, 00) && horaAhora < new TimeSpan(6, 59, 59))
            {
                turnoNombre = "F";
            }
            if (horaAhora >= new TimeSpan(07, 00, 00) && horaAhora < new TimeSpan(10, 59, 59))
            {
                turnoNombre = "A";
            }
            if (horaAhora >= new TimeSpan(11, 00, 00) && horaAhora < new TimeSpan(14, 59, 59))
            {
                turnoNombre = "B";
            }
            if (horaAhora >= new TimeSpan(15, 00, 00) && horaAhora < new TimeSpan(18, 59, 59))
            {
                turnoNombre = "C";
            }
            if (horaAhora >= new TimeSpan(19, 00, 00) && horaAhora < new TimeSpan(22, 59, 59))
            {
                turnoNombre = "D";
            }
            if (horaAhora >= new TimeSpan(23, 00, 00) && horaAhora < new TimeSpan(02, 59, 59))
            {
                turnoNombre = "E";
            }
            return turnoNombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvItemsValor_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var focus = (ProtocoloItem)gvItemsValor.GetFocusedRow();
            if (view.FocusedColumn.FieldName == "Valor")
            {
                string valor = e.Value?.ToString();
                if (valor.Contains("."))
                {
                    valor = valor.Replace('.', ',');
                    e.Value = valor.Replace('.', ',');
                }

                if (!focus.EsConstante)
                {
                    if (focus.Medida == "Milimetro" || focus.Medida == "Entero")
                    {
                        if (!Utils.IsSoloNumerico(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Solo numeros enteros.";
                        }
                    }
                    else if (focus.Medida == "Gramos")
                    {
                        if (!Utils.IsSoloNumODecimal(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Solo numeros enteros o decimales.";
                        }
                    }
                    else if (focus.Medida == "Fuelle")
                    {
                        if (!Utils.IsSoloNumOP(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Este valor es de fuelle, acepta 2 valores en formato a/b.";
                        }
                    }
                }
                else
                {
                    if (focus.Medida == "Caracter")
                    {
                        if (!Utils.IsSoloSignoA(valor))
                        {
                            e.Valid = false;
                            e.ErrorText = "Este valor es constante y solo permite (ok), (no ok) y (-).";
                        }
                    }

                }
            }
        }

        private void btnVerPorPaquete_Click(object sender, EventArgs e)
        {
            var numPaquete = tbNumPaquete.Texts;
            if (!Utils.IsSoloNumerico(numPaquete))
            {
                if (numPaquete == "0") MessageBox.Show("El numero de paquete no puede ser 0.");
                MessageBox.Show("Debe ingresar numero de paquete.");
            }
            else
            {
                GetEnsayosPorPaquete(opSeleccionada.CantProduccion, true);
                tcItemDatos.SelectedTab = tpDatos;

            }
        }

        private void FormVistaAuditor_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            lueTurno.ItemIndex = BuscarUnidadIndex(GetTurno());
            lueTurno.Refresh();
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            formAgregarItems form = new formAgregarItems();
            Point locationOnScreen = btnAgregarItem.PointToScreen(Point.Empty);
            form.Location = new Point(locationOnScreen.X, locationOnScreen.Y + btnAgregarItem.Height + 5);
            form.Show();
        }

        private void lueLegAuditor_EditValueChanged(object sender, EventArgs e)
        {
            //VERIFICAR SIMBOLO
            var lueAuditorA = lueLegAuditor.GetSelectedDataRow() as Usuario;
            if (lueAuditorA == null)
            {
                MessageBox.Show("Debe seleccionar auditor.");
                return;
            }

            legajo = lueAuditorA.Legajo.ToString();
        }

        private void ibtnHabilitarOP_Click(object sender, EventArgs e)
        {
            if (ibtnHabilitarOP.IconChar == IconChar.ToggleOff)
            {
                ibtnHabilitarOP.IconChar = IconChar.ToggleOn;

                tableLayoutPanel3.ColumnStyles[0].Width = 100F;
                tableLayoutPanel3.ColumnStyles[1].Width = 0F;



            }
            else
            {
                ibtnHabilitarOP.IconChar = IconChar.ToggleOff;
                tableLayoutPanel3.ColumnStyles[0].Width = 0F;
                tableLayoutPanel3.ColumnStyles[1].Width = 100F;

            }
        }

        private void btnBuscarOP_Click(object sender, EventArgs e)
        {
            if (!Utils.IsSoloOP(tbOP.Texts))
            { 
                MessageBox.Show("Debe ingresar OP.");
                return;
            }

            var idOrden = Convert.ToInt32(tbOP.Texts.Split('/')[0]);
            var idCodigo = Convert.ToInt32(tbOP.Texts.Split('/')[1]);
            opSeleccionada = br.GetOp(idOrden, idCodigo);

            var ultimoProceso = br.GetCodigoUltimoProceso(opSeleccionada.Codigo);

            VerificarObjetoEnsayado(ultimoProceso);

            if (opSeleccionada.CantProduccion == 0) {
                MessageBox.Show("No se encontra OP.");
                return;
            }
           
            var paquetes = br.GetPaquetesPorOP(opSeleccionada.CantProduccion);
            lblTitulo.Text = "Ensayo para: " + opSeleccionada.Orden +"/"+ opSeleccionada.Codigo;
            groupControl4.Enabled = true;
            espAncho = br.GetFichaTecnicaAnchoBolsa(opSeleccionada.Codigo, ultimoProceso);
            espLargo = br.GetFichaTecnicaLargoBolsa(opSeleccionada.Codigo, ultimoProceso);
            espEspesor = br.GetFichaTecnicaEspesorBolsa(opSeleccionada.Codigo, ultimoProceso);
            GetItems(lueMaquina.Text);
        }
    }
}
