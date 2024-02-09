using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC.API.LabFactory.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string documento { get; set; }
        public string telefone { get; set; }
        public string? foto { get; set; }
        public string tipoAcesso { get; set; }
    }
}
