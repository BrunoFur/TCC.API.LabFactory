using TCC.API.LabFactory.Infra;
using TCC.API.LabFactory.Model;

namespace TCC.API.LabFactory.Repository
{
    public class CliforRepository
    {
        private readonly Conexao contexto = new Conexao();

        public void Adicionar(Clifor clifor)
        {
            try
            {
                // Verifica se os campos obrigatórios foram preenchidos
                if (string.IsNullOrEmpty(clifor.nome))
                {
                    throw new Exception("Favor fornecer o seu Nome");
                }
                else if (string.IsNullOrEmpty(clifor.tipo))
                {
                    throw new Exception("Favor fornecer o seu Tipo");
                }
                else if (string.IsNullOrEmpty(clifor.documento))
                {
                    throw new Exception("Favor fornecer o seu Documento");
                }
                else if (string.IsNullOrEmpty(clifor.telefone))
                {
                    throw new Exception("Favor fornecer o seu Telefone");
                }
                else if (clifor.enderecos.Count == 0) // Verifica se o cliente/fornecedor possui endereços
                {
                    throw new Exception("Favor fornecer ao menos um endereço");
                }

                contexto.Clifors.Add(clifor);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                contexto.Remove(clifor);
                throw new Exception(ex.Message);
            }           
        }

        public void Atualizar(Clifor clifor)
        {
            try
            {
                // Verifica se os campos obrigatórios foram preenchidos
                if (clifor.id == 0)
                {
                    throw new Exception("Favor fornecer o Clifor");
                }
                else if (string.IsNullOrEmpty(clifor.nome))
                {
                    throw new Exception("Favor fornecer o seu Nome");
                }
                else if (string.IsNullOrEmpty(clifor.tipo))
                {
                    throw new Exception("Favor fornecer o seu Tipo");
                }
                else if (string.IsNullOrEmpty(clifor.documento))
                {
                    throw new Exception("Favor fornecer o seu Documento");
                }
                else if (string.IsNullOrEmpty(clifor.telefone))
                {
                    throw new Exception("Favor fornecer o seu Telefone");
                }

                contexto.Clifors.Update(clifor);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   

        public void Excluir(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Favor fornecer o Clifor");
                }

                Clifor clifor = contexto.Clifors.Find(id);
                contexto.Clifors.Remove(clifor);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
        #endregion

        public int VerificaClifor(int id)
        {
            try
            {
                if (contexto.Clifors.Any(x => x.id == id))
                {
                    return id;
                }
                else
                {
                    throw new Exception("Clifor não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Clifor> Listar()
        {
            try
            {
                return contexto.Clifors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Clifor Buscar(int id)
        {
            try
            {
                return contexto.Clifors.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
