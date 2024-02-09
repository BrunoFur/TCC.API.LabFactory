using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC.API.LabFactory.Model
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Clifor")]
        public int cliforId { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string cep { get; set; }
    }
}
