    

    // Configuração do DbContext no Program.cs
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Configuração do DbContext para usar um banco de dados em memória
    builder.Services.AddDbContext<BancoDeDados>(options =>
        options.UseInMemoryDatabase("FuncionarioDb"));

    var app = builder.Build();
commit
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/", () => "API Funcionando");

    // Mapeamento das rotas da API
    app.MapSalarioApi();

    app.Run();