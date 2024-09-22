    using Microsoft.EntityFrameworkCore;
    
    public class BancoDeDados : DbContext
    {
        // Define as tabelas (DbSets) que estarão no banco de dados
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Salario> Salarios { get; set; }

        public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }