using Microsoft.EntityFrameworkCore;
using NetEFCore.Core.Infrastructure.Data;
using NetEFCore.Core.Infrastructure.Repositories;
using NetEFCore.Core.Interfaces;
using NetEFCore.Core.Models;
using NetEFCore.Core.Service;

static void RunApp(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    ConfigureServices(builder);

    var app = builder.Build();

    Configure(app);

    app.Run();
}

static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite(builder.Configuration["DbConnectionString"]));

    builder.Services.AddScoped<IRepositoryBase<PessoaFisica>, PessoaFisicaRepository>();
    builder.Services.AddScoped<IRepositoryBase<PessoaJuridica>, PessoaJuridicaRepository>();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    builder.Services.AddScoped<IPessoaService<PessoaFisica>, PessoaFisicaService>();
}

static void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

RunApp(args);