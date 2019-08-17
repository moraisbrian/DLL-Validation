using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UtilizandoDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VALIDAR CPF
            if (Utilitarios.Repositorio.ValidarCPF(txtCPF.Text))
                lblValidaCPF.Text = "CPF válido";
            else
                lblValidaCPF.Text = "CPF inválido";

            //VALIDAR CNPJ
            if (Utilitarios.Repositorio.ValidarCNPJ(txtCNPJ.Text))
                lblValidaCNPJ.Text = "CNPJ válido";
            else
                lblValidaCNPJ.Text = "CNPJ inválido";

            //VALIDAR EMAIL
            if (Utilitarios.Repositorio.ValidarEmail(txtEMAIL.Text))
                lblValidaEmail.Text = "Email válido";
            else
                lblValidaEmail.Text = "Email inválido";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utilitarios.Repositorio.LimparCampos(this.Controls);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Utilitarios.Repositorio.BuscarCEP(txtCEP.Text);
            txtLogradouro.Text = Utilitarios.Repositorio.logradouro;
            txtBairro.Text = Utilitarios.Repositorio.bairro;
            txtCidade.Text = Utilitarios.Repositorio.cidade;
            txtEstado.Text = Utilitarios.Repositorio.uf;
            txtTipo.Text = Utilitarios.Repositorio.tipologradouro;
            lblMsg.Text = Utilitarios.Repositorio.msgcep; //mensagem
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Utilitarios.Repositorio.BuscarPrevisao(txtCidade.Text);
            lbldata1.Text = Utilitarios.Repositorio.data1;
            lbldata2.Text = Utilitarios.Repositorio.data2;
            lbldata3.Text = Utilitarios.Repositorio.data3;
            lbldata4.Text = Utilitarios.Repositorio.data4;
            lbldata5.Text = Utilitarios.Repositorio.data5;
            lbldata6.Text = Utilitarios.Repositorio.data6;

            lblmax1.Text = Utilitarios.Repositorio.max1;
            lblmax2.Text = Utilitarios.Repositorio.max2;
            lblmax3.Text = Utilitarios.Repositorio.max3;
            lblmax4.Text = Utilitarios.Repositorio.max4;
            lblmax5.Text = Utilitarios.Repositorio.max5;
            lblmax6.Text = Utilitarios.Repositorio.max6;

            lblmin1.Text = Utilitarios.Repositorio.min1;
            lblmin2.Text = Utilitarios.Repositorio.min2;
            lblmin3.Text = Utilitarios.Repositorio.min3;
            lblmin4.Text = Utilitarios.Repositorio.min4;
            lblmin5.Text = Utilitarios.Repositorio.min5;
            lblmin6.Text = Utilitarios.Repositorio.min6;

            pic1.ImageLocation = Utilitarios.Repositorio.pic1;
            pic2.ImageLocation = Utilitarios.Repositorio.pic2;
            pic3.ImageLocation = Utilitarios.Repositorio.pic3;
            pic4.ImageLocation = Utilitarios.Repositorio.pic4;
            pic5.ImageLocation = Utilitarios.Repositorio.pic5;
            pic6.ImageLocation = Utilitarios.Repositorio.pic6;

            picIUV1.ImageLocation = Utilitarios.Repositorio.picIUV1;
            picIUV2.ImageLocation = Utilitarios.Repositorio.picIUV2;
            picIUV3.ImageLocation = Utilitarios.Repositorio.picIUV3;
            picIUV4.ImageLocation = Utilitarios.Repositorio.picIUV4;
            picIUV5.ImageLocation = Utilitarios.Repositorio.picIUV5;
            picIUV6.ImageLocation = Utilitarios.Repositorio.picIUV6;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //botão adicionar
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lstAnexo.Items.Add(openFileDialog1.FileName);//add item
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //botão excluir
            lstAnexo.Items.Remove(lstAnexo.SelectedItem);//remover item
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //pegar o smtp correto
            string smtp = "";
            if (cmbSMTP.Text == "GMAIL")
                smtp = "smtp.gmail.com";
            else if (cmbSMTP.Text == "OUTLOOK")
                smtp = "smtp.live.com";
            else
                smtp = "smtp.mail.yahoo.com.br";

            //pegar os anexos
            List<string> anexo = new List<string>();
            for (int i = 0; i < lstAnexo.Items.Count; i++)
            {
                anexo.Add(lstAnexo.Items[i].ToString());
            }
            //enviar Email
            Utilitarios.Repositorio.EnviarEmail(smtp, txtDe.Text, txtSenha.Text, txtPara.Text, txtTitulo.Text, txtMensagem.Text, anexo, false);

            MessageBox.Show("Email enviado com sucesso!");
        }
    }
}
