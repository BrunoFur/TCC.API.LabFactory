using Microsoft.EntityFrameworkCore;
using TCC.API.LabFactory.Model;

namespace TCC.API.LabFactory.Infra
{
    public class Conexao : DbContext
    {

        //public required string BancoDeDados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clifor> Clifors { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=labfactory.cdoiyq82i1cb.sa-east-1.rds.amazonaws.com;Initial Catalog=Homologacao_LabFactory;Persist Security Info=False;User Id=admin;Password=S%7u?A2D1b;TrustServerCertificate=True"
                   , options => options.UseRelationalNulls().UseNetTopologySuite().UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
    }
}
