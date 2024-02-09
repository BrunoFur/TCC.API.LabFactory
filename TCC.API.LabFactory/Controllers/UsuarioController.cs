using Microsoft.AspNetCore.Mvc;
using TCC.API.LabFactory.Model;
using TCC.API.LabFactory.Repository;
using TCC.API.LabFactory.View;

namespace TCC.API.LabFactory.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository UsuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        /// <summary>
        /// Realiza o cadastro de um novo usuário
        /// </summary>
        /// <param name="usuarioView"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar([FromBody] UsuarioView usuarioView)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    nome = usuarioView.nome,
                    email = usuarioView.email,
                    senha = usuarioView.senha,
                    documento = usuarioView.documento,
                    telefone = usuarioView.telefone,
                    tipoAcesso = usuarioView.tipoAcesso,
                    foto = UsuarioRepository.CarregarFoto(usuarioView.foto, "Usuario",0)
                };

                UsuarioRepository.Adicionar(usuario);

                return new OkObjectResult("Usuário " + usuario.nome + " cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] UsuarioView usuarioView)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    id = UsuarioRepository.VerificaUsuario(usuarioView.id),
                    nome = usuarioView.nome,
                    email = usuarioView.email,
                    senha = usuarioView.senha,
                    documento = usuarioView.documento,
                    telefone = usuarioView.telefone,
                    tipoAcesso = usuarioView.tipoAcesso,
                    foto = UsuarioRepository.CarregarFoto(usuarioView.foto, "Usuario", usuarioView.id)
                };

                UsuarioRepository.Atualizar(usuario);

                return new OkObjectResult("Usuário " + usuario.nome + " atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        /// <summary>
        /// Realiza a busca de todos os usuários cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return new OkObjectResult(UsuarioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadFoto(int id)
        {
            try
            {
                Usuario usuario = UsuarioRepository.Obter(id);

                var dataBytes = System.IO.File.ReadAllBytes(usuario.foto);

                return File(dataBytes, "image/jpeg");

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
