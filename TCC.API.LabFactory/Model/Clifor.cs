using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC.API.LabFactory.Model
{
    [Table("Clifor")]
    public class Clifor
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string apelido { get; set; }
        public string tipo { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string documento { get; set; }
        public string telefone { get; set; }
        public string? foto { get; set; }
        public List<Endereco> enderecos { get; set; }
    }
}
