using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

    public class AppDataBase : DbContext
    {
        // Define as tabelas (DbSets) que estarão no banco de dados
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Salario> Salarios { get; set; }

        // Configuração da conexão
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // Configuração de acesso ao banco de dados MySQL
            builder.UseMySQL("server=localhost;port=3306;database=svApi;user=root;password=Local1234");
        }

        // Opcional: Configurações adicionais de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de relacionamentos e chaves, se necessário
            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Salario)
                .WithOne()
                .HasForeignKey<Salario>(s => s.FuncionarioId);
        }
    }