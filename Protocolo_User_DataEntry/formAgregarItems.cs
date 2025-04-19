using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Protocolo_User_DataEntry;
using Protocolo_User_DataEntry.Model;
using ProtoculoSLF.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProtoculoSLF
{
    public partial class formAgregarItems : Form
    {
        private List<ProtocoloItem> items = new List<ProtocoloItem>();
        private ProtocoloItem protocoloItemSeleccionado = new ProtocoloItem();
        public string confirmar = "";
        private List<Maquina> maquinas = new List<Maquina>();

        public formAgregarItems()
        {
            InitializeComponent();
        }
        private void formAgregarItems_Load(object sender, EventArgs e)
        {
            GenerarTablaItems();
            GetItems();
            List<Unidad> unidades = new List<Unidad> {
                new Unidad{ Nombre="Entero", Descripcion="n" },
                new Unidad{ Nombre="Decimal", Descripcion="d" },
                new Unidad{ Nombre="Milimetro", Descripcion="mm" },
                new Unidad{ Nombre="Kilogramo", Descripcion="kg" },
                new Unidad{ Nombre="KG/pulgada", Descripcion="kg/in" },
                new Unidad{ Nombre="Gramos", Descripcion="gr" },
                new Unidad{ Nombre="Micron", Descripcion="µm" },
                new Unidad{ Nombre="Porcentaje", Descripcion="%" },
                new Unidad{ Nombre="Pulgada", Descripcion="in" },
                new Unidad{ Nombre="Fuelle", Descripcion="f" },
                new Unidad{ Nombre="Sin Unidad", Descripcion="SU" },

            };
            List<Simbolo> simbolos = new List<Simbolo> {
                new Simbolo{ Caracter ="=",Significado="Igual a" },
                new Simbolo{ Caracter ="≠",Significado="Diferente de" },
                new Simbolo{ Caracter ="<",Significado="Menor que" },
                new Simbolo{ Caracter =">",Significado="Mayor que" },
                new Simbolo{ Caracter ="≤",Significado="Menor o igual a" },
                new Simbolo{ Caracter ="≥",Significado="Mayor o igual a" },
                new Simbolo{ Caracter ="±",Significado="Más o menos" },
                new Simbolo{ Caracter ="∓",Significado="Menos o más" },
                new Simbolo{ Caracter ="-",Significado="Entre A y B" },
                new Simbolo{ Caracter ="%",Significado="%" },

            };
            List<string> proceso = new List<string> {
                "Extrusión",
                "Impresión",
                "Confección",
                "Rebobinado",
                "Wicket"
            };
            lueItemSimbolos.Properties.DataSource = simbolos;
            lueItemUnidades.Properties.DataSource = unidades;
            maquinas = FormVistaAuditor.instancia.br.GetMaquinas();
            lueMaquinas.Properties.DataSource = maquinas;
            lueMaquinas.Properties.RefreshDataSource();
        }
        private void GetItems()
        {
            items = FormVistaAuditor.instancia.br.GetItems().OrderBy(e => e.Posicion).ToList();
            gcItems.DataSource = items;
        }
        private void cbCaracter_CheckedChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = !rbConstante.Checked;
            groupControl13.Visible = !rbConstante.Checked;
            gcSimbolo.Visible = !rbConstante.Checked;

        }

        private void GenerarTablaItems()
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

            GridColumn cMedida = new GridColumn();
            cMedida.FieldName = "Medida";
            cMedida.Caption = "Medida";
            cMedida.UnboundDataType = typeof(string);
            cMedida.Visible = true;
            cMedida.Width = 50;
            cMedida.OptionsColumn.AllowEdit = false;

            GridColumn cCertifica = new GridColumn();
            cCertifica.FieldName = "EsCertificadoSiNo";
            cCertifica.Caption = "Certifica";
            cCertifica.Visible = true;
            cCertifica.Width = 40;
            cCertifica.UnboundDataType = typeof(string);
            cCertifica.OptionsColumn.AllowEdit = false;

            GridColumn cSimbolo = new GridColumn();
            cSimbolo.FieldName = "Simbolo";
            cSimbolo.Caption = "SIM";
            cSimbolo.Width = 16;
            cSimbolo.Visible = true;
            cSimbolo.OptionsColumn.AllowEdit = false;

            GridColumn cPosicion = new GridColumn();
            cPosicion.FieldName = "Posicion";
            cPosicion.Caption = "POS";
            cPosicion.Width = 16;
            cPosicion.Visible = true;

            GridColumn cBorrar = new GridColumn();
            cBorrar.FieldName = "FNBorrar";
            cBorrar.Caption = " ";
            cBorrar.Width = 16;
            cBorrar.Visible = true;

            GridColumn cModificar = new GridColumn();
            cModificar.FieldName = "FNModificar";
            cModificar.Caption = " ";
            cModificar.Width = 16;
            cModificar.Visible = true;

            gvItems.Columns.AddRange(new GridColumn[] { cId, cNombre, cMedida, cCertifica, cSimbolo, cPosicion, cBorrar, cModificar });
            gcItems.DataSource = items;

            RepositoryItemButtonEdit botonBorrar = new RepositoryItemButtonEdit();
            botonBorrar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonBorrar.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonBorrar.Buttons[0].Image = Protocolo_User_DataEntry.Properties.Resources.clear_16x16;
            gcItems.RepositoryItems.Add(botonBorrar);
            gvItems.Columns["FNBorrar"].ColumnEdit = botonBorrar;

            botonBorrar.ButtonClick += (sender, e) =>
            {
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {
                    GridView gridView = gvItems;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;
                        var pi = gridView.GetRow(rowIndex) as ProtocoloItem;
                        if (pi != null)
                        {
                            protocoloItemSeleccionado.Id = pi.Id;
                            protocoloItemSeleccionado.Nombre = pi.Nombre;
                            confirmar = "DELETEITEM";
                            gcConfirmar.Visible = true;
                            gcConfirmar.Size = new Size(388, 137);
                            tlpNoti.Visible = true;
                            lblNombreVentana.Text = "Borrar ítem: " + protocoloItemSeleccionado.Nombre;
                            lblTitulo.Text = "Esta a punto de borrar un ítem";
                            lblMensaje.Text = "Esto afectara a todos los protocolos relacionados con dicho ítem";
                        }
                    }
                }
            };

            RepositoryItemButtonEdit botonModificar = new RepositoryItemButtonEdit();
            botonModificar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            botonModificar.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            botonModificar.Buttons[0].Image = Protocolo_User_DataEntry.Properties.Resources.editname_16x16;
            gcItems.RepositoryItems.Add(botonModificar);
            gvItems.Columns["FNModificar"].ColumnEdit = botonModificar;
            botonModificar.ButtonClick += (sender, e) =>
            {
                ButtonEdit buttonEdit = sender as ButtonEdit;
                if (buttonEdit != null && e.Button.Index == 0)
                {
                    GridView gridView = gvItems;
                    if (gridView != null)
                    {
                        int rowIndex = gridView.FocusedRowHandle;
                        var pi = gridView.GetRow(rowIndex) as ProtocoloItem;
                        if (pi != null)
                        {
                            confirmar = "UPDATEITEM";

                            List<string> listaItems = pi.Maquina.Split(',').ToList();
                            if (listaItems[0] != "")
                            {
                                lueMaquinas.Properties.RefreshDataSource();
                                foreach (var item in listaItems)
                                {
                                    var encontrado = lueMaquinas.Properties.Items.FirstOrDefault(m => m.Value.ToString() == item);
                                    if (encontrado != null) {
                                        encontrado.CheckState = CheckState.Checked;
                                    }
                                }

                            }
                            else
                            {
                                lueMaquinas.Properties.Items.OfType<CheckedListBoxItem>().ToList().ForEach(item => item.CheckState = CheckState.Unchecked);
                            }

                            if (pi.EsValor) rbValor.Checked = true;
                            if (pi.EsConstante) rbConstante.Checked = true;
                            else
                            {
                                rbValor.Checked = true;
                            }
                            btnAgregarItem.Text = "Modificar";
                            gcAgregarItem.Text = "  Modificar protocolo ítem";

                            protocoloItemSeleccionado = pi;

                            cbMantener.Visible = true;
                            gcAgregarItem.Visible = true;
                            tbNombre.Texts = protocoloItemSeleccionado.Nombre;
                            cbCertificado.Checked = protocoloItemSeleccionado.EsCertificado;
                            lueItemUnidades.ItemIndex = BuscarUnidadIndex(protocoloItemSeleccionado.Medida);
                            lueItemSimbolos.ItemIndex = BuscarSimboloIndex(protocoloItemSeleccionado.Simbolo);

                        }
                    }
                }
            };
        }
        private int BuscarUnidadIndex(string medida)
        {
            var dataSource = lueItemUnidades.Properties.DataSource as List<Unidad>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => medida == e.Nombre);
                return index != -1 ? index : 0;
            }
            return 0;
        }

        private int BuscarSimboloIndex(string simbolo)
        {
            var dataSource = lueItemSimbolos.Properties.DataSource as List<Simbolo>;
            if (dataSource != null)
            {
                var index = dataSource.FindIndex(e => simbolo == e.Caracter);
                return index != -1 ? index : 0;
            }
            return 0;
        }
        private void btnCerrarMin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrarConfirmar_Click(object sender, EventArgs e)
        {
            gcConfirmar.Visible = false;
            GetItems();
            gcConfirmar.Size = new Size(388, 73);
            tlpNoti.Visible = false;
        }

        private void btnCerrarAgregar_Click(object sender, EventArgs e)
        {
            gcAgregarItem.Visible = false;
            btnAgregarItem.Text = "Agregar";
        }

        private void btnMostrarAgregarItem_Click(object sender, EventArgs e)
        {
            LimpiarFormularioAgregarItem();
            cbMantener.Visible = false;
            cbMantener.Checked = false;
            gcAgregarItem.Visible = true;
        }

        private bool ValidarFormularioItems()
        {
            if (string.IsNullOrEmpty(tbNombre.Texts))
            {
                MostrarNotificacion("Debe introducir nombre de control");
                tbNombre.Focus();
                return false;
            }
            else piAgregar.Nombre = tbNombre.Texts;

            if (!rbConstante.Checked)
            {
                var lueSimboloA = lueItemSimbolos.GetSelectedDataRow() as Simbolo;
                if (lueSimboloA == null)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe seleccionar símbolo.");
                    noti.Show();
                    lueItemSimbolos.Focus();
                    return false;
                }
                else piAgregar.Simbolo = lueSimboloA.Caracter;
                var lueUnidadA = lueItemUnidades.GetSelectedDataRow() as Unidad;
                if (lueUnidadA == null)
                {
                    MostrarNotificacion("Debe seleccionar Unidad.");
                    lueItemUnidades.Focus();
                    return false;
                }
                else piAgregar.Medida = lueUnidadA.Nombre;

            }

            if (string.IsNullOrEmpty(lueMaquinas.Text))
            {
                formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "Debe seleccionar al menos un proceso.");
                noti.Show();
                lueMaquinas.Focus();
                return false;
            }

            return true;
        }
        private void MostrarNotificacion(string mensaje)
        {
            formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", mensaje);
            noti.Show();
        }

        ProtocoloItem piAgregar = new ProtocoloItem();

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {         
            var legajo = FormVistaAuditor.instancia.legajo;
            piAgregar = new ProtocoloItem();
            if (!ValidarFormularioItems()) return;
            piAgregar.EsCertificado = cbCertificado.Checked;
            piAgregar.EsConstante = rbConstante.Checked;
            if (legajo == "")
            {
                MessageBox.Show("Debe seleccionar Auditor para agregar o modificar item.");
                return;
            }

            piAgregar.Auditor = legajo;
            string maqSeleccionadas = string.Join(",", lueMaquinas.Properties.GetCheckedItems()
                                .ToString()
                                .Split(',')
                                .Select(item => item.Trim()));


            piAgregar.Maquina = maqSeleccionadas;

            if (confirmar == "UPDATEITEM")
            {
                gcAgregarItem.Visible = false;
                gcConfirmar.Size = new Size(388, 137);
                tlpNoti.Visible = true;
                lblNombreVentana.Text = "Modificar ítem: " + piAgregar.Nombre;
                lblTitulo.Text = "Esta a punto de modificar un ítem";
                lblMensaje.Text = "Esto afectara a todos los protocolos relacionados con dicho ítem";
                gcConfirmar.Visible = true;

            }
            else
            {
                if (FormVistaAuditor.instancia.br.AgregarItem(piAgregar))
                {
                    LimpiarFormularioAgregarItem();
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se agrego correctamente un nuevo item: " + piAgregar.Nombre);
                    GetItems();
                    noti.Show();
                }
            }

        }
        private void LimpiarFormularioAgregarItem()
        {
            gcAgregarItem.Text = "  Agregar protocolo ítem";
            tbNombre.Texts = string.Empty;
            lueItemUnidades.Text = string.Empty;
            lueItemSimbolos.Text = string.Empty;
            lueMaquinas.Text = string.Empty;
            cbCertificado.Checked = false;
            rbConstante.Checked = false;
        }

        private void btnConfirmarCambios_Click(object sender, EventArgs e)
        {
            if (confirmar == "UPDATEITEM")
            {
                piAgregar = new ProtocoloItem();
                if (!ValidarFormularioItems()) return;

                if (!FormVistaAuditor.instancia.br.GetNombreItemDuplicado(piAgregar.Nombre.Trim().ToLower()) && !cbMantener.Checked)
                {
                    formNotificacion noti = new formNotificacion("warning", "Recomendación", "Agregar Ítem", "El nombre de control esta en uso, seleccione 'Fijar nombre' si no desea modificar el nombre.");
                    noti.Show();
                    return;
                }

                piAgregar.EsCertificado = cbCertificado.Checked;
                piAgregar.EsConstante = rbConstante.Checked;
                piAgregar.Id = protocoloItemSeleccionado.Id;

                string maqSeleccionadas = string.Join(",", lueMaquinas.Properties.GetCheckedItems()
                                .ToString()
                                .Split(',')
                                .Select(item => item.Trim()));
                piAgregar.Maquina = maqSeleccionadas;

                if (FormVistaAuditor.instancia.br.UpdateItem("NO", piAgregar))
                {
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se modifico correctamente el ítem: " + protocoloItemSeleccionado.Nombre);
                    noti.Show();
                    gcConfirmar.Visible = false;
                    GetItems();
                    LimpiarFormularioAgregarItem();
                    
                }
            }

            if (confirmar == "DELETEITEM")
            {
                if (FormVistaAuditor.instancia.br.DeleteItem("NO", protocoloItemSeleccionado.Id))
                {
                    formNotificacion noti = new formNotificacion("success", "Información", "Acción realizada", "Se borro correctamente el ítem: " + protocoloItemSeleccionado.Nombre);
                    noti.Show();
                    gcConfirmar.Visible = false;
                    GetItems();
                }
            }
        }

        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            gcAgregarItem.Visible = true;
            gcConfirmar.Visible = false;
        }

        private void gvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridView view = sender as GridView;
                if (view != null && view.FocusedRowHandle >= 0)
                {
                    object editedValue = view.EditingValue ?? view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn);
                    if (string.IsNullOrEmpty(editedValue.ToString())) return;
                    if (!Utils.IsSoloNumerico(editedValue.ToString()))
                    {
                        MessageBox.Show("Solo numeros enteros");
                        return;
                    }
                    if (gvItems.FocusedColumn.FieldName == "Posicion")
                    {
                        var indexSeleccionado = Convert.ToInt32(editedValue);
                        GridView gridView = gvItems;
                        if (gridView != null)
                        {
                            int rowIndex = gridView.FocusedRowHandle;
                            var pi = gridView.GetRow(rowIndex) as ProtocoloItem;
                            if (pi != null)
                            {
                                protocoloItemSeleccionado.Id = pi.Id;
                                protocoloItemSeleccionado.Nombre = pi.Nombre;
                                if (FormVistaAuditor.instancia.br.CambiarPosicionItem(protocoloItemSeleccionado.Id, indexSeleccionado))
                                {
                                    GetItems();
                                }

                            }
                        }
                    }
                }
                e.Handled = true;
            }
        }

        string nombreItem = "";

        private void ActualizarEtiqueta()
        {

            var seleccionados = lueMaquinas.Properties.Items
                             .Cast<CheckedListBoxItem>()
                             .Where(x => x.CheckState == CheckState.Checked)
                             .Select(x => x.Value.ToString())
                             .ToList();

            HashSet<string> etiquetas = new HashSet<string>();

            foreach (var item in seleccionados)
            {
                string categoria = DetectarCategoria(item);
                if (categoria != "Desconocido")
                    etiquetas.Add(categoria);
            }

            label1.Text = string.Join(", ", etiquetas);

        }
        private string DetectarCategoria(string item)
        {
            if (item.StartsWith("Wick")) return "Wicket";
            if (item.StartsWith("valo")) return "Prueba";

            if (item == "Italiana" || item.StartsWith("Manual") || item.StartsWith("Poli") || item.StartsWith("Rappard")) return "Confeccion";
            if (int.TryParse(item, out _)) return "Extrusion";
            if (item.StartsWith("Rebobinadora")) return "Rebobinado";

            return "Desconocido";
        }

        private void lueMaquinas_Properties_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            foreach (CheckedListBoxItem item in lueMaquinas.Properties.Items)
            {
                var maquina = item.Value as Maquina;
                if (maquina != null)
                {
                    if (item.CheckState == CheckState.Checked) {
                        maquinas.FirstOrDefault(m => m.Nombre == maquina.Nombre).Seleccionado = true;
                    }
                }
            }
            var pp = 0;
            //ActualizarEtiqueta();
        }

        private void Properties_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lueMaquinas_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
