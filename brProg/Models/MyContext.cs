using System.Configuration;
using System.Data.Entity;

namespace brProg.Models
{
    public class MyContext : DbContext
    {
        public MyContext() 
            : base(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Dia> Dia { get; set; }
        public DbSet<ResumoDiario> ResumoDiario { get; set; }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

    }
}