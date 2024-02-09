namespace TCC.API.LabFactory.View
{
    public class CliforView
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string apelido { get; set; }
        public string tipo { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string documento { get; set; }
        public string telefone { get; set; }
        public string? foto { get; set; }
        public List<EnderecoView> enderecos { get; set; }   
    }
}
