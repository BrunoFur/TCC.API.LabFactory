using TCC.API.LabFactory.Infra;
using TCC.API.LabFactory.Model;

namespace TCC.API.LabFactory.Repository
{
    public class EnderecoRepository
    {
        private readonly Conexao contexto = new Conexao();
        
        public void Adicionar(Endereco endereco)
        {
            try
            {
                endereco.id = 0;

                if (endereco.cliforId == 0)
                {
                    throw new Exception("Favor fornecer o Código do Cliente/Fornecedor");
                }
                else if (string.IsNullOrEmpty(endereco.logradouro))
                {
                    throw new Exception("Favor fornecer o logradouro do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.numero))
                {
                    throw new Exception("Favor fornecer o número do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.bairro))
                {
                    throw new Exception("Favor fornecer o bairro do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.cidade))
                {
                    throw new Exception("Favor fornecer a cidade do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.estado))
                {
                    throw new Exception("Favor fornecer o estado do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.pais))
                {
                    throw new Exception("Favor fornecer o país do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.cep))
                {
                    throw new Exception("Favor fornecer o CEP do Endereço");
                }

                contexto.Enderecos.Add(endereco);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Endereco endereco)
        {
            try
            {
                if (endereco.id == 0)
                {
                    throw new Exception("Favor fornecer o Código do Endereço");
                }
                else if (endereco.cliforId == 0)
                {
                    throw new Exception("Favor fornecer o Código do Cliente/Fornecedor");
                }
                else if (string.IsNullOrEmpty(endereco.logradouro))
                {
                    throw new Exception("Favor fornecer o logradouro do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.numero))
                {
                    throw new Exception("Favor fornecer o número do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.bairro))
                {
                    throw new Exception("Favor fornecer o bairro do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.cidade))
                {
                    throw new Exception("Favor fornecer a cidade do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.estado))
                {
                    throw new Exception("Favor fornecer o estado do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.pais))
                {
                    throw new Exception("Favor fornecer o país do Endereço");
                }
                else if (string.IsNullOrEmpty(endereco.cep))
                {
                    throw new Exception("Favor fornecer o CEP do Endereço");
                }

                contexto.Enderecos.Update(endereco);
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
                    throw new Exception("Favor selecionar o Endereço para exclusão");
                }

                var endereco = contexto.Enderecos.Find(id);
                contexto.Enderecos.Remove(endereco);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Endereco> Listar(int idClifor)
        {
            try
            {
                return contexto.Enderecos.Where(x => x.cliforId == idClifor).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
