    public static class SalarioApiExtensions
    {
        public static void MapSalarioApi(this WebApplication app)
        {
            var group = app.MapGroup("/funcionarios");

            group.MapGet("/", async (BancoDeDados db) =>
            {
                // Incluindo salários na consulta de funcionários
                return await db.Funcionarios.Include(f => f.Salario).ToListAsync();
            });

            group.MapPost("/", async (Funcionario funcionario, BancoDeDados db) =>
            {
                Console.WriteLine($"Funcionário: {funcionario.Nome}");

                // Salva o salário associado
                funcionario.Salario.CalcularSalario(); 
                db.Salarios.Add(funcionario.Salario);

                db.Funcionarios.Add(funcionario);
                await db.SaveChangesAsync();

                return Results.Created($"/funcionarios/{funcionario.Id}", funcionario);
            });

            
        }
    }