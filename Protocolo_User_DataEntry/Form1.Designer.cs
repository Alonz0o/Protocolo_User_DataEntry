namespace Protocolo_User_DataEntry
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.aafPanel1 = new ProtoculoSLF.AAFPanel();
            this.tlpRealizados = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPendientes = new System.Windows.Forms.Panel();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAgregarEnsayo = new ProtoculoSLF.AAFControles.AAFBoton();
            this.btnCancelar = new ProtoculoSLF.AAFControles.AAFBoton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rbUltimoSeleccionado = new System.Windows.Forms.RadioButton();
            this.rbEnProduccion = new System.Windows.Forms.RadioButton();
            this.lueOP = new DevExpress.XtraEditors.LookUpEdit();
            this.tbOP = new ScrapKP.AAFControles.AAFTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.aafPanel1.SuspendLayout();
            this.tlpRealizados.SuspendLayout();
            this.pnlPendientes.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueOP.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // aafPanel1
            // 
            this.aafPanel1.Controls.Add(this.tlpRealizados);
            this.aafPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aafPanel1.Location = new System.Drawing.Point(0, 0);
            this.aafPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.aafPanel1.Name = "aafPanel1";
            this.aafPanel1.Size = new System.Drawing.Size(396, 331);
            this.aafPanel1.TabIndex = 0;
            // 
            // tlpRealizados
            // 
            this.tlpRealizados.BackColor = System.Drawing.Color.Transparent;
            this.tlpRealizados.ColumnCount = 2;
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRealizados.Controls.Add(this.pnlPendientes, 1, 0);
            this.tlpRealizados.Controls.Add(this.panel11, 0, 0);
            this.tlpRealizados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRealizados.Location = new System.Drawing.Point(0, 0);
            this.tlpRealizados.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tlpRealizados.Name = "tlpRealizados";
            this.tlpRealizados.RowCount = 1;
            this.tlpRealizados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRealizados.Size = new System.Drawing.Size(396, 331);
            this.tlpRealizados.TabIndex = 3;
            // 
            // pnlPendientes
            // 
            this.pnlPendientes.AutoScroll = true;
            this.pnlPendientes.BackColor = System.Drawing.Color.Transparent;
            this.pnlPendientes.Controls.Add(this.pnlContenedor);
            this.pnlPendientes.Controls.Add(this.tableLayoutPanel5);
            this.pnlPendientes.Controls.Add(this.groupControl1);
            this.pnlPendientes.Controls.Add(this.panel1);
            this.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendientes.Location = new System.Drawing.Point(16, 3);
            this.pnlPendientes.Name = "pnlPendientes";
            this.pnlPendientes.Size = new System.Drawing.Size(377, 325);
            this.pnlPendientes.TabIndex = 0;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.lueOP);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 130);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(377, 152);
            this.pnlContenedor.TabIndex = 79;
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
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 282);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(377, 43);
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
            this.btnAgregarEnsayo.Font = new System.Drawing.Font("Libre Franklin SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgregarEnsayo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnAgregarEnsayo.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarEnsayo.Name = "btnAgregarEnsayo";
            this.btnAgregarEnsayo.Size = new System.Drawing.Size(182, 37);
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
            this.btnCancelar.Font = new System.Drawing.Font("Libre Franklin SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.Location = new System.Drawing.Point(191, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(183, 37);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Libre Franklin SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Controls.Add(this.rbUltimoSeleccionado);
            this.groupControl1.Controls.Add(this.rbEnProduccion);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 30);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(377, 100);
            this.groupControl1.TabIndex = 78;
            this.groupControl1.Text = "OP *";
            // 
            // rbUltimoSeleccionado
            // 
            this.rbUltimoSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbUltimoSeleccionado.AutoSize = true;
            this.rbUltimoSeleccionado.BackColor = System.Drawing.Color.Transparent;
            this.rbUltimoSeleccionado.Font = new System.Drawing.Font("Libre Franklin SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.rbUltimoSeleccionado.Location = new System.Drawing.Point(113, 0);
            this.rbUltimoSeleccionado.Name = "rbUltimoSeleccionado";
            this.rbUltimoSeleccionado.Size = new System.Drawing.Size(142, 21);
            this.rbUltimoSeleccionado.TabIndex = 66;
            this.rbUltimoSeleccionado.TabStop = true;
            this.rbUltimoSeleccionado.Text = "Ultimo seleccionado";
            this.rbUltimoSeleccionado.UseVisualStyleBackColor = false;
            this.rbUltimoSeleccionado.CheckedChanged += new System.EventHandler(this.rbUltimoSeleccionado_CheckedChanged);
            // 
            // rbEnProduccion
            // 
            this.rbEnProduccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbEnProduccion.AutoSize = true;
            this.rbEnProduccion.BackColor = System.Drawing.Color.Transparent;
            this.rbEnProduccion.Font = new System.Drawing.Font("Libre Franklin SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.rbEnProduccion.Location = new System.Drawing.Point(261, 0);
            this.rbEnProduccion.Name = "rbEnProduccion";
            this.rbEnProduccion.Size = new System.Drawing.Size(108, 21);
            this.rbEnProduccion.TabIndex = 2;
            this.rbEnProduccion.TabStop = true;
            this.rbEnProduccion.Text = "En producción";
            this.rbEnProduccion.UseVisualStyleBackColor = false;
            this.rbEnProduccion.CheckedChanged += new System.EventHandler(this.rbEnProduccion_CheckedChanged);
            // 
            // lueOP
            // 
            this.lueOP.EditValue = "";
            this.lueOP.Location = new System.Drawing.Point(7, 98);
            this.lueOP.Name = "lueOP";
            this.lueOP.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lueOP.Properties.Appearance.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lueOP.Properties.Appearance.Options.UseFont = true;
            this.lueOP.Properties.Appearance.Options.UseForeColor = true;
            this.lueOP.Properties.AutoHeight = false;
            this.lueOP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOP.Properties.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lueOP.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueOP.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueOP.Size = new System.Drawing.Size(373, 36);
            this.lueOP.TabIndex = 64;
            this.lueOP.Visible = false;
            // 
            // tbOP
            // 
            this.tbOP.BackColor = System.Drawing.Color.White;
            this.tbOP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.tbOP.BorderFocusColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbOP.BorderSize = 2;
            this.tbOP.Font = new System.Drawing.Font("Libre Franklin SemiBold", 10F, System.Drawing.FontStyle.Bold);
            this.tbOP.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbOP.Location = new System.Drawing.Point(-28, 27);
            this.tbOP.Margin = new System.Windows.Forms.Padding(4);
            this.tbOP.Multiline = false;
            this.tbOP.Name = "tbOP";
            this.tbOP.Padding = new System.Windows.Forms.Padding(19, 8, 8, 8);
            this.tbOP.PasswordChar = false;
            this.tbOP.SelectionStart = 0;
            this.tbOP.Size = new System.Drawing.Size(233, 36);
            this.tbOP.TabIndex = 67;
            this.tbOP.Texts = "";
            this.tbOP.UnderlinedStyle = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 30);
            this.panel1.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Libre Franklin SemiBold", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Items para algo";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(7, 325);
            this.panel11.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 75);
            this.tableLayoutPanel1.TabIndex = 67;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Libre Franklin SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.tbOP);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(186, 75);
            this.groupControl2.TabIndex = 79;
            this.groupControl2.Text = "OP *";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 331);
            this.Controls.Add(this.aafPanel1);
            this.Font = new System.Drawing.Font("Libre Franklin SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SANLUFILM SA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.aafPanel1.ResumeLayout(false);
            this.tlpRealizados.ResumeLayout(false);
            this.pnlPendientes.ResumeLayout(false);
            this.pnlContenedor.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueOP.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ProtoculoSLF.AAFPanel aafPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpRealizados;
        private System.Windows.Forms.Panel pnlPendientes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private ProtoculoSLF.AAFControles.AAFBoton btnAgregarEnsayo;
        private ProtoculoSLF.AAFControles.AAFBoton btnCancelar;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lueOP;
        private System.Windows.Forms.RadioButton rbEnProduccion;
        private System.Windows.Forms.RadioButton rbUltimoSeleccionado;
        private ScrapKP.AAFControles.AAFTextBox tbOP;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}

