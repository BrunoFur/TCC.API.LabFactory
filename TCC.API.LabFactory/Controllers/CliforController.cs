using Microsoft.AspNetCore.Mvc;
using TCC.API.LabFactory.Model;
using TCC.API.LabFactory.Repository;
using TCC.API.LabFactory.View;

namespace TCC.API.LabFactory.Controllers
{
    [ApiController]
    [Route("api/clifor")]
    public class CliforController : Controller
    {
        private readonly CliforRepository CliforRepository;

        public CliforController(CliforRepository cliforRepository)
        {
            CliforRepository = cliforRepository ?? throw new ArgumentNullException(nameof(cliforRepository));
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CliforView cliforView)
        {
            try
            {
                Clifor clifor = new Clifor
                {
                    nome = cliforView.nome,
                    apelido = cliforView.apelido,
                    tipo = cliforView.tipo,
                    email = cliforView.email,
                    senha = cliforView.senha,
                    documento = cliforView.documento,
                    telefone = cliforView.telefone,
                    foto = "",//CliforRepository.CarregarFoto(cliforView.foto.ToString(), "Clifor", 0),
                    enderecos = cliforView.enderecos.Select(e => new Endereco
                    {
                        logradouro = e.logradouro,
                        numero = e.numero,
                        complemento = e.complemento,
                        bairro = e.bairro,
                        cidade = e.cidade,
                        estado = e.estado,
                        cep = e.cep,
                        pais = e.pais,
                    }).ToList()
                };

                CliforRepository.Adicionar(clifor);

                return new OkObjectResult("Clifor " + clifor.nome + " cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] CliforView cliforView)
        {
            try
            {
                Clifor clifor = new Clifor
                {
                    id = CliforRepository.VerificaClifor(cliforView.id),
                    nome = cliforView.nome,
                    apelido = cliforView.apelido,
                    tipo = cliforView.tipo,
                    email = cliforView.email,
                    senha = cliforView.senha,
                    documento = cliforView.documento,
                    telefone = cliforView.telefone,
                    foto = "",//CliforRepository.CarregarFoto(cliforView.foto, "Clifor", cliforView.id),
                    enderecos = cliforView.enderecos.Select(e => new Endereco
                    {
                        id = e.id,
                        logradouro = e.logradouro,
                        numero = e.numero,
                        complemento = e.complemento,
                        bairro = e.bairro,
                        cidade = e.cidade,
                        estado = e.estado,
                        cep = e.cep
                    }).ToList()
                };

                CliforRepository.Atualizar(clifor);

                return new OkObjectResult("Clifor " + clifor.nome + " atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                CliforRepository.Excluir(id);

                return new OkObjectResult("Clifor excluído com sucesso");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarClifor(int id)
        {
            try
            {
                return new OkObjectResult(CliforRepository.Buscar(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
