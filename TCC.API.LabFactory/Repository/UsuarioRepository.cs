using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using TCC.API.LabFactory.Infra;
using TCC.API.LabFactory.Model;

namespace TCC.API.LabFactory.Repository
{
    public class UsuarioRepository
    {
        private readonly Conexao contexto = new Conexao();

        #region CRUD (Adicionar, Atualizar, Excluir, Obter, ObterTodos)
        /// <summary>
        /// Realiza o cadastro de um novo usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <exception cref="Exception"></exception>
        public void Adicionar(Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.nome))
                {
                    throw new Exception("Favor fornecer o nome do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.email))
                {
                    throw new Exception("Favor fornecer o email do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.senha))
                {
                    throw new Exception("Favor fornecer a senha do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.documento))
                {
                    throw new Exception("Favor fornecer o documento do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.telefone))
                {
                    throw new Exception("Favor fornecer o telefone do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.tipoAcesso))
                {
                    throw new Exception("Favor fornecer o tipo de acesso do Usuário");
                }

                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza a atualização dos dados do usuário
        /// </summary>
        /// <param name="usuario"></param>
        public void Atualizar(Usuario usuario)
        {
            try
            {
                if (usuario.id == 0)
                {
                    throw new Exception("Favor fornecer o Código do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.nome))
                {
                    throw new Exception("Favor fornecer o nome do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.email))
                {
                    throw new Exception("Favor fornecer o email do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.senha))
                {
                    throw new Exception("Favor fornecer a senha do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.documento))
                {
                    throw new Exception("Favor fornecer o documento do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.telefone))
                {
                    throw new Exception("Favor fornecer o telefone do Usuário");
                }
                else if (string.IsNullOrEmpty(usuario.tipoAcesso))
                {
                    throw new Exception("Favor fornecer o tipo de acesso do Usuário");
                }

                contexto.Usuarios.Update(usuario);
                contexto.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Realiza a exclusão do usuário
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Favor fornecer o Código do Usuário");
                }

                var usuario = contexto.Usuarios.Find(id);
                contexto.Usuarios.Remove(usuario);
                contexto.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Realiza a busca de apenas um único usuário 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario Obter(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Favor fornecer o Código do Usuário");
                }

                return contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Realiza a busca de todos os usuários
        /// </summary>
        /// <returns></returns>
        public List<Usuario> ObterTodos()
        {
            try
            {
                return contexto.Usuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Carregamento de foto para Storage 
        public string CarregarFoto(IFormFile fotoForm, string entrada, int id)
        {
            try
            {
                if (fotoForm != null && fotoForm.Length > 0)
                {
                    var arquivo = Path.Combine("Storage/" + entrada, id == 0 ? ObterQuantidadeUsuarios().ToString() : id + ".png");

                    using (var arquivoStream = new FileStream(arquivo, FileMode.Create))
                    {
                        fotoForm.CopyTo(arquivoStream);
                    }

                    return arquivo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public int ObterQuantidadeUsuarios()
        {
            try
            {
                return contexto.Usuarios.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int VerificaUsuario(int id)
        {
            try
            {
                if (contexto.Usuarios.Any(x => x.id == id))
                {
                    return id;
                }
                else
                {
                    throw new Exception("Usuário " + id + " não encontrado");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
