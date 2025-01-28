namespace Protocolo_User_DataEntry
{
    partial class FormVistaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpRealizados = new System.Windows.Forms.TableLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnlPendientes = new System.Windows.Forms.Panel();
            this.gcEnsayos = new DevExpress.XtraGrid.GridControl();
            this.gvEnsayos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEnsayosNecesarios = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregarEnsayo = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnCancelar = new ProtoculoSLF.AAFControles.AAFBoton();
            this.tcPrincipal = new System.Windows.Forms.TabControl();
            this.tpProduccion = new System.Windows.Forms.TabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnErrorLargo = new FontAwesome.Sharp.IconButton();
            this.btnConvertirMMLargo = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnEspLargo = new ProtoculoSLF.AAFControles.AAFBoton();
            this.tbLargo = new ScrapKP.AAFControles.AAFTextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnErrorAncho = new FontAwesome.Sharp.IconButton();
            this.btnConvertirMMAncho = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnEspAncho = new ProtoculoSLF.AAFControles.AAFBoton();
            this.tbAncho = new ScrapKP.AAFControles.AAFTextBox();
            this.tpAuditor = new System.Windows.Forms.TabPage();
            this.gcItemsValor = new DevExpress.XtraGrid.GridControl();
            this.gvItemsValor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAuditor = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnProduccion = new ProtoculoSLF.AAFControles.AAFBoton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tlpRealizados.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEnsayos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnsayos)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tcPrincipal.SuspendLayout();
            this.tpProduccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tpAuditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemsValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemsValor)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRealizados
            // 
            this.tlpRealizados.BackColor = System.Drawing.Color.Transparent;
            this.tlpRealizados.ColumnCount = 2;
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRealizados.Controls.Add(this.panel11, 0, 0);
            this.tlpRealizados.Controls.Add(this.pnlPendientes, 1, 0);
            this.tlpRealizados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRealizados.Location = new System.Drawing.Point(0, 0);
            this.tlpRealizados.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpRealizados.Name = "tlpRealizados";
            this.tlpRealizados.RowCount = 1;
            this.tlpRealizados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 624F));
            this.tlpRealizados.Size = new System.Drawing.Size(421, 624);
            this.tlpRealizados.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(7, 618);
            this.panel11.TabIndex = 1;
            // 
            // pnlPendientes
            // 
            this.pnlPendientes.AutoScroll = true;
            this.pnlPendientes.BackColor = System.Drawing.Color.Transparent;
            this.pnlPendientes.Controls.Add(this.gcEnsayos);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel2);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel5);
            this.pnlPendientes.Controls.Add(this.tcPrincipal);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel1);
            this.pnlPendientes.Controls.Add(this.lblTitulo);
            this.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendientes.Location = new System.Drawing.Point(16, 3);
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Size = new System.Drawing.Size(402, 618);
            this.pnlPendientes.TabIndex = 0;
            // 
            // gcEnsayos
            // 
            this.gcEnsayos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEnsayos.Location = new System.Drawing.Point(0, 260);
            this.gcEnsayos.MainView = this.gvEnsayos;
            this.gcEnsayos.Name = "gcEnsayos";
            this.gcEnsayos.Size = new System.Drawing.Size(402, 315);
            this.gcEnsayos.TabIndex = 88;
            this.gcEnsayos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEnsayos});
            // 
            // gvEnsayos
            // 
            this.gvEnsayos.GridControl = this.gcEnsayos;
            this.gvEnsayos.Name = "gvEnsayos";
            this.gvEnsayos.OptionsView.ShowGroupPanel = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 218);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(402, 42);
            this.tableLayoutPanel2.TabIndex = 91;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEnsayosNecesarios);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(205, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 32);
            this.panel1.TabIndex = 91;
            // 
            // lblEnsayosNecesarios
            // 
            this.lblEnsayosNecesarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnsayosNecesarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblEnsayosNecesarios.Location = new System.Drawing.Point(0, 17);
            this.lblEnsayosNecesarios.Name = "lblEnsayosNecesarios";
            this.lblEnsayosNecesarios.Size = new System.Drawing.Size(192, 15);
            this.lblEnsayosNecesarios.TabIndex = 90;
            this.lblEnsayosNecesarios.Text = "100/100";
            this.lblEnsayosNecesarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 17);
            this.label1.TabIndex = 92;
            this.label1.Text = "Realizadas/Requeridas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btnAgregarEnsayo, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 575);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(402, 43);
            this.tableLayoutPanel5.TabIndex = 66;
            // 
            // btnAgregarEnsayo
            // 
            this.btnAgregarEnsayo.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarEnsayo.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAgregarEnsayo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarEnsayo.BorderRadius = 4;
            this.btnAgregarEnsayo.BorderSize = 3;
            this.btnAgregarEnsayo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarEnsayo.FlatAppearance.BorderSize = 0;
            this.btnAgregarEnsayo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEnsayo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgregarEnsayo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarEnsayo.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarEnsayo.Name = "btnAgregarEnsayo";
            this.btnAgregarEnsayo.Size = new System.Drawing.Size(195, 37);
            this.btnAgregarEnsayo.TabIndex = 1;
            this.btnAgregarEnsayo.Text = "Agregar";
            this.btnAgregarEnsayo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarEnsayo.UseVisualStyleBackColor = false;
            this.btnAgregarEnsayo.Click += new System.EventHandler(this.btnAgregarEnsayo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.BorderRadius = 4;
            this.btnCancelar.BorderSize = 3;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.Location = new System.Drawing.Point(204, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(195, 37);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tcPrincipal
            // 
            this.tcPrincipal.Controls.Add(this.tpProduccion);
            this.tcPrincipal.Controls.Add(this.tpAuditor);
            this.tcPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcPrincipal.Location = new System.Drawing.Point(0, 67);
            this.tcPrincipal.Name = "tcPrincipal";
            this.tcPrincipal.SelectedIndex = 0;
            this.tcPrincipal.Size = new System.Drawing.Size(402, 151);
            this.tcPrincipal.TabIndex = 87;
            // 
            // tpProduccion
            // 
            this.tpProduccion.Controls.Add(this.groupControl1);
            this.tpProduccion.Controls.Add(this.groupControl2);
            this.tpProduccion.Location = new System.Drawing.Point(4, 22);
            this.tpProduccion.Margin = new System.Windows.Forms.Padding(0);
            this.tpProduccion.Name = "tpProduccion";
            this.tpProduccion.Size = new System.Drawing.Size(394, 125);
            this.tpProduccion.TabIndex = 6;
            this.tpProduccion.Text = "PRODUCCION";
            this.tpProduccion.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnErrorLargo);
            this.groupControl1.Controls.Add(this.btnConvertirMMLargo);
            this.groupControl1.Controls.Add(this.btnEspLargo);
            this.groupControl1.Controls.Add(this.tbLargo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 61);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(394, 64);
            this.groupControl1.TabIndex = 83;
            this.groupControl1.Text = "Largo de bolsa *";
            // 
            // btnErrorLargo
            // 
            this.btnErrorLargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErrorLargo.BackColor = System.Drawing.Color.White;
            this.btnErrorLargo.BackgroundImage = global::Protocolo_User_DataEntry.Properties.Resources.cancel_16x16;
            this.btnErrorLargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnErrorLargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErrorLargo.FlatAppearance.BorderSize = 0;
            this.btnErrorLargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorLargo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnErrorLargo.IconColor = System.Drawing.SystemColors.Highlight;
            this.btnErrorLargo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnErrorLargo.IconSize = 20;
            this.btnErrorLargo.Location = new System.Drawing.Point(235, 31);
            this.btnErrorLargo.Name = "btnErrorLargo";
            this.btnErrorLargo.Size = new System.Drawing.Size(20, 20);
            this.btnErrorLargo.TabIndex = 83;
            this.btnErrorLargo.UseVisualStyleBackColor = false;
            this.btnErrorLargo.Visible = false;
            // 
            // btnConvertirMMLargo
            // 
            this.btnConvertirMMLargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertirMMLargo.BackColor = System.Drawing.Color.Transparent;
            this.btnConvertirMMLargo.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnConvertirMMLargo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnConvertirMMLargo.BorderRadius = 10;
            this.btnConvertirMMLargo.BorderSize = 3;
            this.btnConvertirMMLargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertirMMLargo.FlatAppearance.BorderSize = 0;
            this.btnConvertirMMLargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertirMMLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnConvertirMMLargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnConvertirMMLargo.Location = new System.Drawing.Point(261, 28);
            this.btnConvertirMMLargo.Name = "btnConvertirMMLargo";
            this.btnConvertirMMLargo.Size = new System.Drawing.Size(47, 23);
            this.btnConvertirMMLargo.TabIndex = 81;
            this.btnConvertirMMLargo.Text = "MM";
            this.btnConvertirMMLargo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnConvertirMMLargo.UseVisualStyleBackColor = false;
            // 
            // btnEspLargo
            // 
            this.btnEspLargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEspLargo.BackColor = System.Drawing.Color.Transparent;
            this.btnEspLargo.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnEspLargo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnEspLargo.BorderRadius = 10;
            this.btnEspLargo.BorderSize = 3;
            this.btnEspLargo.FlatAppearance.BorderSize = 0;
            this.btnEspLargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnEspLargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnEspLargo.Location = new System.Drawing.Point(314, 28);
            this.btnEspLargo.Name = "btnEspLargo";
            this.btnEspLargo.Size = new System.Drawing.Size(75, 23);
            this.btnEspLargo.TabIndex = 80;
            this.btnEspLargo.Text = "0 + 0";
            this.btnEspLargo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnEspLargo.UseVisualStyleBackColor = false;
            // 
            // tbLargo
            // 
            this.tbLargo.BackColor = System.Drawing.Color.White;
            this.tbLargo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbLargo.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbLargo.BorderSize = 2;
            this.tbLargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.tbLargo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbLargo.Location = new System.Drawing.Point(2, 23);
            this.tbLargo.Margin = new System.Windows.Forms.Padding(4);
            this.tbLargo.Multiline = false;
            this.tbLargo.Name = "tbLargo";
            this.tbLargo.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbLargo.PasswordChar = false;
            this.tbLargo.SelectionStart = 0;
            this.tbLargo.Size = new System.Drawing.Size(390, 34);
            this.tbLargo.TabIndex = 1;
            this.tbLargo.Texts = "";
            this.tbLargo.UnderlinedStyle = true;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.btnErrorAncho);
            this.groupControl2.Controls.Add(this.btnConvertirMMAncho);
            this.groupControl2.Controls.Add(this.btnEspAncho);
            this.groupControl2.Controls.Add(this.tbAncho);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(394, 61);
            this.groupControl2.TabIndex = 82;
            this.groupControl2.Text = "Ancho de bolsa *";
            // 
            // btnErrorAncho
            // 
            this.btnErrorAncho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnErrorAncho.BackColor = System.Drawing.Color.White;
            this.btnErrorAncho.BackgroundImage = global::Protocolo_User_DataEntry.Properties.Resources.cancel_16x16;
            this.btnErrorAncho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnErrorAncho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErrorAncho.FlatAppearance.BorderSize = 0;
            this.btnErrorAncho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorAncho.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnErrorAncho.IconColor = System.Drawing.SystemColors.Highlight;
            this.btnErrorAncho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnErrorAncho.IconSize = 20;
            this.btnErrorAncho.Location = new System.Drawing.Point(235, 31);
            this.btnErrorAncho.Name = "btnErrorAncho";
            this.btnErrorAncho.Size = new System.Drawing.Size(20, 20);
            this.btnErrorAncho.TabIndex = 82;
            this.btnErrorAncho.UseVisualStyleBackColor = false;
            this.btnErrorAncho.Visible = false;
            // 
            // btnConvertirMMAncho
            // 
            this.btnConvertirMMAncho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertirMMAncho.BackColor = System.Drawing.Color.Transparent;
            this.btnConvertirMMAncho.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnConvertirMMAncho.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnConvertirMMAncho.BorderRadius = 10;
            this.btnConvertirMMAncho.BorderSize = 3;
            this.btnConvertirMMAncho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertirMMAncho.FlatAppearance.BorderSize = 0;
            this.btnConvertirMMAncho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertirMMAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnConvertirMMAncho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnConvertirMMAncho.Location = new System.Drawing.Point(261, 28);
            this.btnConvertirMMAncho.Name = "btnConvertirMMAncho";
            this.btnConvertirMMAncho.Size = new System.Drawing.Size(47, 23);
            this.btnConvertirMMAncho.TabIndex = 81;
            this.btnConvertirMMAncho.Text = "MM";
            this.btnConvertirMMAncho.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnConvertirMMAncho.UseVisualStyleBackColor = false;
            // 
            // btnEspAncho
            // 
            this.btnEspAncho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEspAncho.BackColor = System.Drawing.Color.Transparent;
            this.btnEspAncho.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnEspAncho.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnEspAncho.BorderRadius = 10;
            this.btnEspAncho.BorderSize = 3;
            this.btnEspAncho.FlatAppearance.BorderSize = 0;
            this.btnEspAncho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnEspAncho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnEspAncho.Location = new System.Drawing.Point(314, 28);
            this.btnEspAncho.Name = "btnEspAncho";
            this.btnEspAncho.Size = new System.Drawing.Size(75, 23);
            this.btnEspAncho.TabIndex = 80;
            this.btnEspAncho.Text = "0 + 0";
            this.btnEspAncho.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnEspAncho.UseVisualStyleBackColor = false;
            // 
            // tbAncho
            // 
            this.tbAncho.BackColor = System.Drawing.Color.White;
            this.tbAncho.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbAncho.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbAncho.BorderSize = 2;
            this.tbAncho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.tbAncho.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbAncho.Location = new System.Drawing.Point(2, 23);
            this.tbAncho.Margin = new System.Windows.Forms.Padding(4);
            this.tbAncho.Multiline = false;
            this.tbAncho.Name = "tbAncho";
            this.tbAncho.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbAncho.PasswordChar = false;
            this.tbAncho.SelectionStart = 0;
            this.tbAncho.Size = new System.Drawing.Size(390, 34);
            this.tbAncho.TabIndex = 1;
            this.tbAncho.Texts = "";
            this.tbAncho.UnderlinedStyle = true;
            // 
            // tpAuditor
            // 
            this.tpAuditor.Controls.Add(this.gcItemsValor);
            this.tpAuditor.Location = new System.Drawing.Point(4, 22);
            this.tpAuditor.Name = "tpAuditor";
            this.tpAuditor.Size = new System.Drawing.Size(394, 125);
            this.tpAuditor.TabIndex = 7;
            this.tpAuditor.Text = "AUDITOR";
            this.tpAuditor.UseVisualStyleBackColor = true;
            // 
            // gcItemsValor
            // 
            this.gcItemsValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItemsValor.Location = new System.Drawing.Point(0, 0);
            this.gcItemsValor.MainView = this.gvItemsValor;
            this.gcItemsValor.Name = "gcItemsValor";
            this.gcItemsValor.Size = new System.Drawing.Size(394, 125);
            this.gcItemsValor.TabIndex = 89;
            this.gcItemsValor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItemsValor});
            // 
            // gvItemsValor
            // 
            this.gvItemsValor.GridControl = this.gcItemsValor;
            this.gvItemsValor.Name = "gvItemsValor";
            this.gvItemsValor.OptionsView.ShowGroupPanel = false;
            this.gvItemsValor.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvItemsValor_ValidatingEditor);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnAuditor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnProduccion, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 43);
            this.tableLayoutPanel1.TabIndex = 86;
            // 
            // btnAuditor
            // 
            this.btnAuditor.BackColor = System.Drawing.SystemColors.Window;
            this.btnAuditor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.btnAuditor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAuditor.BorderRadius = 0;
            this.btnAuditor.BorderSize = 3;
            this.btnAuditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAuditor.FlatAppearance.BorderSize = 0;
            this.btnAuditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAuditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAuditor.Location = new System.Drawing.Point(204, 3);
            this.btnAuditor.Name = "btnAuditor";
            this.btnAuditor.Size = new System.Drawing.Size(195, 37);
            this.btnAuditor.TabIndex = 2;
            this.btnAuditor.Text = "Auditoria";
            this.btnAuditor.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAuditor.UseVisualStyleBackColor = false;
            this.btnAuditor.Click += new System.EventHandler(this.btnAuditor_Click);
            // 
            // btnProduccion
            // 
            this.btnProduccion.BackColor = System.Drawing.SystemColors.Window;
            this.btnProduccion.BackgroundColor = System.Drawing.SystemColors.Window;
            this.btnProduccion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnProduccion.BorderRadius = 0;
            this.btnProduccion.BorderSize = 3;
            this.btnProduccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProduccion.FlatAppearance.BorderSize = 0;
            this.btnProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnProduccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnProduccion.Location = new System.Drawing.Point(3, 3);
            this.btnProduccion.Name = "btnProduccion";
            this.btnProduccion.Size = new System.Drawing.Size(195, 37);
            this.btnProduccion.TabIndex = 1;
            this.btnProduccion.Text = "Producción";
            this.btnProduccion.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnProduccion.UseVisualStyleBackColor = false;
            this.btnProduccion.Click += new System.EventHandler(this.btnProduccion_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(138, 24);
            this.lblTitulo.TabIndex = 89;
            this.lblTitulo.Text = "Ensayo para: ";
            // 
            // FormVistaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 624);
            this.Controls.Add(this.tlpRealizados);
            this.Name = "FormVistaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVistaPrincipal";
            this.tlpRealizados.ResumeLayout(false);
            this.pnlPendientes.ResumeLayout(false);
            this.pnlPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEnsayos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnsayos)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tcPrincipal.ResumeLayout(false);
            this.tpProduccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tpAuditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItemsValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemsValor)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRealizados;
        private System.Windows.Forms.Panel pnlPendientes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ProtoculoSLF.AAFControles.AAFBoton btnAgregarEnsayo;
        private ProtoculoSLF.AAFControles.AAFBoton btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ProtoculoSLF.AAFControles.AAFBoton btnAuditor;
        private ProtoculoSLF.AAFControles.AAFBoton btnProduccion;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TabControl tcPrincipal;
        private System.Windows.Forms.TabPage tpProduccion;
        private System.Windows.Forms.TabPage tpAuditor;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private FontAwesome.Sharp.IconButton btnErrorLargo;
        private ProtoculoSLF.AAFControles.AAFBoton btnConvertirMMLargo;
        private ProtoculoSLF.AAFControles.AAFBoton btnEspLargo;
        private ScrapKP.AAFControles.AAFTextBox tbLargo;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private FontAwesome.Sharp.IconButton btnErrorAncho;
        private ProtoculoSLF.AAFControles.AAFBoton btnConvertirMMAncho;
        private ProtoculoSLF.AAFControles.AAFBoton btnEspAncho;
        private ScrapKP.AAFControles.AAFTextBox tbAncho;
        private DevExpress.XtraGrid.GridControl gcEnsayos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEnsayos;
        private DevExpress.XtraGrid.GridControl gcItemsValor;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItemsValor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEnsayosNecesarios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}