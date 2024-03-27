using AnimeTV.DataContext;
using AnimeTV.Service.AnimeService;
using AnimeTV.Service.EpisodioService;
using AnimeTV.Service.UsuarioService;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolice", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddScoped<IEpisodioInterface, EpisodioService>();
builder.Services.AddScoped<IAnimeInterface, AnimeService>();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();

//Configurando banco de dados SQL Serve
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSQLSERVE"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolice");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
