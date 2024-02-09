namespace TCC.API.LabFactory.View
{
    public class UsuarioView
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string documento { get; set; }
        public string telefone { get; set; }
        public IFormFile foto { get; set; }
        public string tipoAcesso { get; set; }
    }
}
