using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Login {
    public partial class addfuncionario : Form {
        public addfuncionario() {
            InitializeComponent();

            txt_nome.Enabled = false;
            txt_telefone.Enabled = false;
            txt_cpf.Enabled = false;
            txt_email.Enabled = false;
            txt_endereco.Enabled = false;
            txt_numero.Enabled = false;
            txt_bairro.Enabled = false;
            txt_rg.Enabled = false;
            txt_cpf.Enabled = false;
            txt_celular.Enabled = false;
            txt_pesquisa.Enabled = false;
        }

        SqlConnection Sqlcon = null;
        private string strcon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog = login; Data Source = DESKTOP-V5GM7SL\MSSQLSERVER01";
        private string strsql = string.Empty;

        private void btn_adicionar_Click(object sender, EventArgs e) {

            txt_nome.Enabled = true;
            txt_telefone.Enabled = true;
            txt_cpf.Enabled = true;
            txt_email.Enabled = true;
            txt_endereco.Enabled = true;
            txt_numero.Enabled = true;
            txt_bairro.Enabled = true;
            txt_rg.Enabled = true;
            txt_cpf.Enabled = true;
            txt_celular.Enabled = true;
            txt_pesquisa.Enabled = true;
        }

        private void btn_salvar_Click(object sender, EventArgs e) {
            strsql = "insert  into cadastro (Nome, Telefone, Celular, Email, Endereço, Numero, Bairro, RG, CPF) values (@Nome, @Telefone,@Celular,@Email,@Endereco,@Numero,@Bairro,@RG,@CPF)";

            Sqlcon = new SqlConnection(strcon);
            SqlCommand comando = new SqlCommand(strsql, Sqlcon);

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txt_telefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = txt_celular.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txt_endereco.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txt_numero.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txt_bairro.Text;
            comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = txt_rg.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = txt_cpf.Text;

            try {

                Sqlcon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro Efetuado Com Sucesso");
            }

            catch(Exception ex) {

                MessageBox.Show(ex.Message);
            }
            finally {

                Sqlcon.Close();

            }

            txt_pesquisa.Enabled = true;

            txt_nome.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
            txt_numero.Clear();
            txt_bairro.Clear();
            txt_rg.Clear();
            txt_cpf.Clear();
        }

        private void btn_buscar_Click(object sender, EventArgs e) {

            strsql = "select * from cadastro where nome = @pesquisa";

            Sqlcon = new SqlConnection(strcon);
            SqlCommand comando = new SqlCommand(strsql, Sqlcon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txt_pesquisa.Text;

            try {

                if (txt_pesquisa.Text == string.Empty) {
                    MessageBox.Show("Você não digitou um nome!");
                }
                Sqlcon.Open();

                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false) {

                    throw new Exception("Este nome não está cadastrado!");

                }
                dr.Read();

                txt_nome.Text = Convert.ToString(dr["Nome"]);
                txt_telefone.Text = Convert.ToString(dr["Telefone"]);
                txt_celular.Text = Convert.ToString(dr["Celular"]);
                txt_email.Text = Convert.ToString(dr["Email"]);
                txt_endereco.Text = Convert.ToString(dr["Endereço"]);
                txt_numero.Text = Convert.ToString(dr["Numero"]);
                txt_bairro.Text = Convert.ToString(dr["Bairro"]);
                txt_rg.Text = Convert.ToString(dr["RG"]);
                txt_cpf.Text = Convert.ToString(dr["CPF"]);

            }
            catch(Exception ex) {

                MessageBox.Show(ex.Message);

            }

            finally {
                Sqlcon.Close();
            }
            txt_pesquisa.Clear();

        }

        private void btn_editar_Click(object sender, EventArgs e) {

            strsql = "update cadastro set Nome = @Nome, Telefone = @Telefone, Email = @Email, Endereço = @Endereco, Numero = @Numero, RG = @RG,CPF = @CPF ";

            Sqlcon = new SqlConnection(strcon);
            SqlCommand comando = new SqlCommand(strsql, Sqlcon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txt_pesquisa.Text;

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txt_telefone.Text;
            comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value = txt_celular.Text;
            comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txt_endereco.Text;
            comando.Parameters.Add("@Numero", SqlDbType.VarChar).Value = txt_numero.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txt_bairro.Text;
            comando.Parameters.Add("@RG", SqlDbType.VarChar).Value = txt_rg.Text;
            comando.Parameters.Add("@CPF", SqlDbType.VarChar).Value = txt_cpf.Text;

            try {

                Sqlcon.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro alterado com sucesso!!");
            }

            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
            finally {
                Sqlcon.Close();
            }


            txt_nome.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
            txt_numero.Clear();
            txt_bairro.Clear();
            txt_rg.Clear();
            txt_cpf.Clear();
            
        }

        private void btn_excluir_Click(object sender, EventArgs e) {

            strsql = "delete from cadastro where Nome = @Nome";
            Sqlcon = new SqlConnection(strcon);
            SqlCommand comando = new SqlCommand(strsql, Sqlcon); 

            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txt_nome.Text;


            try {
                Sqlcon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Exclusão feita com sucesso!!");
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            finally {
                Sqlcon.Close();
            }

            txt_nome.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
            txt_numero.Clear();
            txt_bairro.Clear();
            txt_rg.Clear();
            txt_cpf.Clear();

        }
    }
}
