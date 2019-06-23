using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Utilitarios
{
    public class Repositorio
    {
        //para cep
        public static string uf { get; set; }
        public static string cidade { get; set; }
        public static string bairro { get; set; }
        public static string tipologradouro { get; set; }
        public static string logradouro { get; set; }
        public static string msgcep { get; set; }

        //para previsao
        public static string data1 { get; set; }
        public static string data2 { get; set; }
        public static string data3 { get; set; }
        public static string data4 { get; set; }
        public static string data5 { get; set; }
        public static string data6 { get; set; }

        public static string max1 { get; set; }
        public static string max2 { get; set; }
        public static string max3 { get; set; }
        public static string max4 { get; set; }
        public static string max5 { get; set; }
        public static string max6 { get; set; }

        public static string min1 { get; set; }
        public static string min2 { get; set; }
        public static string min3 { get; set; }
        public static string min4 { get; set; }
        public static string min5 { get; set; }
        public static string min6 { get; set; }

        public static string pic1 { get; set; }
        public static string pic2 { get; set; }
        public static string pic3 { get; set; }
        public static string pic4 { get; set; }
        public static string pic5 { get; set; }
        public static string pic6 { get; set; }

        public static string picIUV1 { get; set; }
        public static string picIUV2 { get; set; }
        public static string picIUV3 { get; set; }
        public static string picIUV4 { get; set; }
        public static string picIUV5 { get; set; }
        public static string picIUV6 { get; set; }


        public static bool ValidarCPF(string vCPF)//parametro será a textbox onde o usuario irá digitar o cpf
        {
            bool valor;//variavel para retorno (true/false)
            int[] CPF = new int[11];
            vCPF = vCPF.Replace(".", "").Replace(",", "").Replace("/", "").Replace("-", "");
            if (vCPF.Length != 11 || vCPF == "00000000000" || vCPF == "11111111111" || vCPF == "22222222222" || vCPF == "33333333333" || vCPF == "44444444444" || vCPF == "55555555555" || vCPF == "66666666666" || vCPF == "77777777777" || vCPF == "88888888888" || vCPF == "99999999999")
            {
                return false;
            }
            else
            {
                for (int i = 0; i < 11; i++)
                {
                    CPF[i] = int.Parse(vCPF.Substring(i, 1));//preenchendo o cpf digitado pelo usuario; utilizando o Substring para "fatiar" o cpf digitado 
                }

                //primeiro dígito
                int soma = CPF[0] * 10 + CPF[1] * 9 + CPF[2] * 8 + CPF[3] * 7 + CPF[4] * 6 + CPF[5] * 5 + CPF[6] * 4 + CPF[7] * 3 + CPF[8] * 2; //efetuando o cálculo
                int dig1 = soma % 11;//pegando o resto da divisão
                if (dig1 < 2)
                {
                    dig1 = 0;
                }
                else
                {
                    dig1 = 11 - dig1;
                }
                //segundo dígito
                soma = CPF[0] * 11 + CPF[1] * 10 + CPF[2] * 9 + CPF[3] * 8 + CPF[4] * 7 + CPF[5] * 6 + CPF[6] * 5 + CPF[7] * 4 + CPF[8] * 3 + dig1 * 2; // efetuando o cálculo
                int dig2 = soma % 11;//pegando o resto da divisão
                if (dig2 < 2)
                {
                    dig2 = 0;
                }
                else
                {
                    dig2 = 11 - dig2;
                }

                if (CPF[9] == dig1 && CPF[10] == dig2)//verificar se o digito encontrado é o mesmo que o digito informado pelo usuário
                {
                    valor = true; // se sim retorna true               
                }
                else
                {
                    valor = false; //se não retorna false
                }
                return valor;//retornando o valor já preenchido true/false
            }
        }

        public static bool ValidarCNPJ(string vCNPJ)//este é o parâmetro, o qual  será digitado pelo usuário, ou seja a textbox
        {
            bool valor; //para saber se o cnpj é verdadeiro ou falso
            int[] CNPJ = new int[14];
            vCNPJ = vCNPJ.Replace(".", "").Replace(",", "").Replace("/", "").Replace("-", "");
            if (vCNPJ.Length != 14 || vCNPJ == "00000000000000" || vCNPJ == "11111111111111" || vCNPJ == "22222222222222" || vCNPJ == "33333333333333" || vCNPJ == "44444444444444" || vCNPJ == "55555555555555" || vCNPJ == "66666666666666" || vCNPJ == "77777777777777" || vCNPJ == "88888888888888" || vCNPJ == "99999999999999")
            {
                return false;
            }
            else
            {
                for (int i = 0; i < 14; i++) //cadastrando os numeros do cnpj no vetor separadamente pelo substring
                {
                    CNPJ[i] = int.Parse(vCNPJ.Substring(i, 1));
                }

                //pegando o primeiro dígito

                int soma = CNPJ[0] * 5 + CNPJ[1] * 4 + CNPJ[2] * 3 + CNPJ[3] * 2 + CNPJ[4] * 9 + CNPJ[5] * 8 + CNPJ[6] * 7 + CNPJ[7] * 6 + CNPJ[8] * 5 + CNPJ[9] * 4 + CNPJ[10] * 3 + CNPJ[11] * 2; //fazendo o cálculo
                int dig1 = soma % 11; //pegando o resto da divisão
                if (dig1 < 2)
                {
                    dig1 = 0;
                }
                else
                {
                    dig1 = 11 - dig1;
                }
                //pegando o segundo dígito

                soma = CNPJ[0] * 6 + CNPJ[1] * 5 + CNPJ[2] * 4 + CNPJ[3] * 3 + CNPJ[4] * 2 + CNPJ[5] * 9 + CNPJ[6] * 8 + CNPJ[7] * 7 + CNPJ[8] * 6 + CNPJ[9] * 5 + CNPJ[10] * 4 + CNPJ[11] * 3 + dig1 * 2; // fazendo o cálculo
                int dig2 = soma % 11; // resto da divisão
                if (dig2 < 2)
                {
                    dig2 = 0;
                }
                else
                {
                    dig2 = 11 - dig2;
                }

                if (CNPJ[12] == dig1 && CNPJ[13] == dig2) // verifica se o digito encontrado é igual ao digitado
                {
                    valor = true; //caso seja igual retorna true
                }
                else
                {
                    valor = false; //caso não seja igual retorna 
                }
                return valor;//retorna o valor já preenchido (true ou false)
            }
        }

        public static bool ValidarEmail(string email)
        {
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]
                                {1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return Regex.IsMatch(email, pattern);
        } //valida email

        public static string EnviarEmail(string smtp, string emailusuario, string senhausuario, string emailpara, string titulo, string msg, List<string> anexo, bool ishtml)
        {
            SmtpClient servico = new SmtpClient();//protocolo padrão para envio de e-mail
            servico.Host = smtp;
            try
            {
                servico.Port = 587;//define a porta pela qual o e-mail fará o acesso
                servico.Credentials = new NetworkCredential(emailusuario, senhausuario);//pega as credenciais para acesso ao email
                MailMessage mensagem = new MailMessage(emailusuario, emailpara);//adicionando na mensagem de email o remetente e o destinarário
                mensagem.Subject = titulo;//título da mensagem
                mensagem.Body = msg;//corpo da mensagem
                if (ishtml == true)
                {
                    mensagem.IsBodyHtml = true;
                }
                if (anexo.Count >= 1)
                {
                    // Existe anexo, add ao CORPO da msg
                    int i = 0;
                    while (i < anexo.Count)
                    {
                        mensagem.Attachments.Add(new Attachment(anexo[i].ToString()));
                        i++;
                    }
                }
                servico.EnableSsl = true; // precisa para enviar
                servico.Send(mensagem);//envio
                return "E-mail enviado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro ao enviar e-mail: " + ex;
            }
        }

        public static void BuscarCEP(string CEP)
        {
            try
            {
                string _resultado;

                //Cria um DataSet  baseado no retorno do XML  
                DataSet ds = new DataSet();
                //http://cep.republicavirtual.com.br/web_cep.php?cep=07830350&formato=xml
                ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-", "").Trim() + "&formato=xml");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                        switch (_resultado)
                        {
                            case "1":
                                uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                                cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                                tipologradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();
                                logradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                                msgcep = "CEP completo";
                                break;
                            case "2":
                                uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                                cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                bairro = "";
                                tipologradouro = "";
                                logradouro = "";
                                msgcep = "CEP  único";
                                break;
                            default:
                                uf = "";
                                cidade = "";
                                bairro = "";
                                tipologradouro = "";
                                logradouro = "";
                                msgcep = "CEP não  encontrado";
                                break;
                        }
                    }
                }
            }
            catch
            {
                logradouro = "";
                tipologradouro = "";
                uf = "";
                bairro = "";
                cidade = "";
                msgcep = "CEP não encontrado";
            }
        }

        public static void LimparCampos(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Clear();
                    //ctrl.Text = "";
                }

                if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)(ctrl)).Clear();
                    //ctrl.Text = "";
                }
                LimparCampos(ctrl.Controls);
            }
        }

        public static void BuscarPrevisao(string cidade)
        {
            try
            {
                cidade = cidade.Replace("ã", "a").Replace("á", "a").Replace("é", "e").Replace("ê", "e").Replace("í", "i").Replace("ó", "o").Replace("ô", "o").Replace("ú", "u").Replace("Ã", "A").Replace("À", "A").Replace("É", "E").Replace("Ê", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ô", "O").Replace("Ú", "U");
                string cod = "";
                DataSet ds = new DataSet();
                ds.ReadXml("http://servicos.cptec.inpe.br/XML/listaCidades?city=" + cidade);
                if (ds != null)
                {
                    cod = ds.Tables[0].Rows[0]["id"].ToString().Trim();
                }

                //data em portugues
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;


                //preenchendo informaçoes
                DataSet ds1 = new DataSet();
                ds1.ReadXml("http://servicos.cptec.inpe.br/XML/cidade/7dias/" + cod + "/previsao.xml");

                // pega todas as data de dia no gridview e passa para os label's 
                data1 = dtfi.GetDayName(DateTime.Parse(ds1.Tables[1].Rows[0]["dia"].ToString().Trim()).DayOfWeek).ToString();
                data2 = dtfi.GetDayName(DateTime.Parse(ds1.Tables[1].Rows[1]["dia"].ToString().Trim()).DayOfWeek).ToString();
                data3 = dtfi.GetDayName(DateTime.Parse(ds1.Tables[1].Rows[2]["dia"].ToString().Trim()).DayOfWeek).ToString();
                data4 = dtfi.GetDayName(DateTime.Parse(ds1.Tables[1].Rows[3]["dia"].ToString().Trim()).DayOfWeek).ToString();
                data5 = dtfi.GetDayName(DateTime.Parse(ds1.Tables[1].Rows[4]["dia"].ToString().Trim()).DayOfWeek).ToString();
                data6 = dtfi.GetDayName(DateTime.Parse(ds1.Tables[1].Rows[5]["dia"].ToString().Trim()).DayOfWeek).ToString();
                // pega todos as 4 temperaturas maxima dos dias seguintes e passa para label's
                max1 = ds1.Tables[1].Rows[0]["maxima"].ToString().Trim() + "ºC";
                max2 = ds1.Tables[1].Rows[1]["maxima"].ToString().Trim() + "ºC";
                max3 = ds1.Tables[1].Rows[2]["maxima"].ToString().Trim() + "ºC";
                max4 = ds1.Tables[1].Rows[3]["maxima"].ToString().Trim() + "ºC";
                max5 = ds1.Tables[1].Rows[4]["maxima"].ToString().Trim() + "ºC";
                max6 = ds1.Tables[1].Rows[5]["maxima"].ToString().Trim() + "ºC";
                // pega todos as 4 temperaturas manima dos dias seguintes e passa para label's
                min1 = ds1.Tables[1].Rows[0]["minima"].ToString() + "ºC";
                min2 = ds1.Tables[1].Rows[1]["minima"].ToString() + "ºC";
                min3 = ds1.Tables[1].Rows[2]["minima"].ToString() + "ºC";
                min4 = ds1.Tables[1].Rows[3]["minima"].ToString() + "ºC";
                min5 = ds1.Tables[1].Rows[4]["minima"].ToString() + "ºC";
                min6 = ds1.Tables[1].Rows[5]["minima"].ToString() + "ºC";
                // encurta as urls de imagens Codições do clima da CPTEC 
                string urlimageCond = "http://img0.cptec.inpe.br/~rgrafico/icones_principais/tempo/menor/min_";
                // carrega todas imagens de acordo com ordem, de Codições do clima da CPTEC
                pic1 = urlimageCond + ds1.Tables[1].Rows[0]["tempo"].ToString() + ".gif";
                pic2 = urlimageCond + ds1.Tables[1].Rows[1]["tempo"].ToString() + ".gif";
                pic3 = urlimageCond + ds1.Tables[1].Rows[2]["tempo"].ToString() + ".gif";
                pic4 = urlimageCond + ds1.Tables[1].Rows[3]["tempo"].ToString() + ".gif";
                pic5 = urlimageCond + ds1.Tables[1].Rows[4]["tempo"].ToString() + ".gif";
                pic6 = urlimageCond + ds1.Tables[1].Rows[5]["tempo"].ToString() + ".gif";
                // encurta as urls de IUV de acordo com ordem da CPTEC 
                string urlimageIUV = "http://img0.cptec.inpe.br/~rgrafico/icones_principais/uv/menor/uv_";
                // carrega todas imagens de UV da CPTEC
                picIUV1 = urlimageIUV + ds1.Tables[1].Rows[0]["iuv"].ToString() + ".gif";
                picIUV2 = urlimageIUV + ds1.Tables[1].Rows[1]["iuv"].ToString() + ".gif";
                picIUV3 = urlimageIUV + ds1.Tables[1].Rows[2]["iuv"].ToString() + ".gif";
                picIUV4 = urlimageIUV + ds1.Tables[1].Rows[3]["iuv"].ToString() + ".gif";
                picIUV5 = urlimageIUV + ds1.Tables[1].Rows[4]["iuv"].ToString() + ".gif";
                picIUV6 = urlimageIUV + ds1.Tables[1].Rows[5]["iuv"].ToString() + ".gif";
            }
            catch
            {
                data1 = "";
                data2 = "";
                data3 = "";
                data4 = "";
                data5 = "";
                data6 = "";

                max1 = "";
                max2 = "";
                max3 = "";
                max4 = "";
                max5 = "";
                max6 = "";

                min1 = "";
                min2 = "";
                min3 = "";
                min4 = "";
                min5 = "";
                min6 = "";

                pic1 = "";
                pic2 = "";
                pic3 = "";
                pic4 = "";
                pic5 = "";
                pic6 = "";

                picIUV1 = "";
                picIUV2 = "";
                picIUV3 = "";
                picIUV4 = "";
                picIUV5 = "";
                picIUV6 = "";

            }
        }

    }
}
