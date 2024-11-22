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
        List<AAFTextBox> textBoxes = new List<AAFTextBox>();
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
            var espAncho= br.GetFichaLogisticaConfeccionAncho(codigo);
            btnEspAncho.Text = espAncho.Medio + "±" + espAncho.Maximo;
            var espLargo = br.GetFichaLogisticaConfeccionLargo(codigo);
            btnEspLargo.Text = espLargo.Medio + "±" + espLargo.Maximo;

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
            string sqlInsertarProtocoloItem = "INSERT INTO formato_ensayo (op,id_protocolo_item,valor_ensayo,creado) VALUES ";
            string sqlInsertarProtocoloItem2 = "";
            var contador = 1;

            //if (codigoDatos.Disposicion == 1)
            //{

                //var tb = control.Controls.OfType<AAFTextBox>().FirstOrDefault(txt => txt.Name == "tbControl"+contador);
                if (!ValidarFormularioItems(tbAncho.Texts)) return;
                if (!ValidarFormularioItems(tbLargo.Texts)) return;

                var valorEnsayoAncho = Convert.ToDouble(tbAncho.Texts);
                var idProtocolo_item = br.GetIdProtocoloItem(18);
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{idProtocolo_item}','{valorEnsayoAncho}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'),";

                var valorEnsayoLargo = Convert.ToDouble(tbLargo.Texts);
                var idProtocoloItemLargo = br.GetIdProtocoloItem(19);
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{orden + "/" + codigo}','{idProtocoloItemLargo}','{valorEnsayoLargo}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'),";

                contador++;
            //}
            
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;
            contador = 1;
            if (br.InsertEnsayoLote(sqlInsertarProtocoloItem)) {
                tbAncho.Texts = "";
                tbLargo.Texts = "";
                MessageBox.Show("Ensayo agregado");
                Close();
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
