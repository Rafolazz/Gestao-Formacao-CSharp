using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GestaoFormacao;
using Dapper;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace GestaoFormacao
{
    public class DataAccess
    {
        public List<Models.User> SerchUser(string nome)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.User>("dbo.SelectPorUtilizador @nome", new { nome = nome }).ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.User> SerchNonEmployees(string nome)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.User>("dbo.SelectUtilizadoresNaoFuncionarios @nome", new { nome = nome }).ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.Funcionario> SerchEmployee(string nome)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Funcionario>("dbo.SelectFuncionarioPorNome @nome", new { nome = nome }).ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.Modulos> SearchModule(string nome)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Modulos>("dbo.SelectPorModulo @nome", new { nome = nome }).ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void UpdateUser(int id, string nome, string email, string palavrapasse, string permissao, int ativo, int funcionario)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    List<Models.User> user = new List<Models.User>();
                    connection.Execute("dbo.UpdateUtilizador  @id, @nome, @email, @palavrapasse, @permissao, @ativo, @funcionario", new { id = id, nome = nome, Email = email, palavrapasse = palavrapasse, permissao = permissao, ativo = ativo, funcionario = funcionario });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<Models.User> GetUsers()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.User>("dbo.SelectUtilizadores").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.Modulos> GetModules()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Modulos>("dbo.SelectModuloInfo").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.User> GetEmployees()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.User>("dbo.SelectFuncionarios").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.Funcionario> GetEmployee()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Funcionario>("dbo.SelectFuncionario").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.tipo_formacao> GetTipoFormacao()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.tipo_formacao>("dbo.SelectTipoFormacao").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.tipo_modulo> GetTipoModulo()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.tipo_modulo>("dbo.SelectTipoModulo").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.Avaliacao> GetAvaliacao()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Avaliacao>("dbo.SelectTipoAvaliacao").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.User> GetUsersPerm(string nome)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.User>("dbo.SelectUtilizadorPerm @nome", new { nome = nome }).ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.User> spLogin(string nome)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
            {
                try
                {
                    var output = connection.Query<Models.User>("dbo.IniciarSessao @nome", new { nome = nome }).ToList();
                    return output;
                }
                catch
                {
                    return new List<Models.User>();
                }
            }
        }
        public void InsertUser(string nome, string email, string palavrapasse, int permissao)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    List<Models.User> user = new List<Models.User>();

                    user.Add(new Models.User { nome = nome, email = email, palavrapasse = palavrapasse, permissao = permissao});

                    connection.Execute("dbo.CriarConta @nome, @Email, @palavrapasse, @permissao", user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertPercurso(string nome, string descricao, int competencia, string jsonmod)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    List<Models.User> user = new List<Models.User>();

                    connection.Execute("dbo.CriarPercurso @nome, @descricao, @competencia, @jsonmod", new { nome, descricao, competencia, jsonmod });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertModule(string nome, string descricao, int horas, DateTime? data_max, int tipo_formacao, int tipo_modulo, string url, int avaliacao)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    List<Models.Modulos> mod = new List<Models.Modulos>();

                    mod.Add(new Models.Modulos { nome = nome, descricao = descricao, horas = horas, data_max = data_max, tipo_formacao = tipo_formacao, tipo_modulo = tipo_modulo, url = url, tipo_avaliacao = avaliacao });

                    connection.Execute("dbo.InsertModulo @nome, @descricao, @horas, @data_max, @tipo_formacao, @tipo_modulo, @url, @tipo_avaliacao", mod);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Models.User GetUserById(int id)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.QueryFirstOrDefault<Models.User>("dbo.SelectUtilizadorPorID @id", new { id = id });
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void UpdateUserPermission(int id, int permissao, int ativo)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    connection.Execute("dbo.UpdateUtilizadorPermissao @id, @permissao, @ativo", new { id, permissao, ativo });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public bool checkEmail(string email)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    email = email.ToLower();
                    connection.Execute("dbo.Email @Email ", new { Email = email });
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<Models.Modulos> GetModuleNames()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Modulos>("dbo.SelectModuloNomes").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Models.Modulos> GetModuleInfo()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Modulos>("dbo.SelectModuloInfo").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.Level> GetLevels()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Level>("dbo.SelectCompetencia").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<Models.Modulos> SearchModules(string nome)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Modulos>("dbo.ProcurarModulo @nome", new { nome }).ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void AdicionarFuncionario(int id, string departamento)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    connection.Execute("dbo.AdicionarFuncionario @id, @departamento", new { id, departamento });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Models.Path> GetPercurso()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DefaultConnection")))
                {
                    var output = connection.Query<Models.Path>("dbo.SelectPercurso").ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
