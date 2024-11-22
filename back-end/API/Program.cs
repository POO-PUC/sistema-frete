using Servico;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();

// Configurar políticas de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Registrar seus serviços com o contêiner de DI
builder.Services.AddScoped<ServicoEstado>();
builder.Services.AddScoped<ServicoCidade>();
builder.Services.AddScoped<ServicoCliente>();
builder.Services.AddScoped<ServicoPessoaFisica>();
builder.Services.AddScoped<ServicoPessoaJuridica>();
builder.Services.AddScoped<ServicoFuncionario>();
builder.Services.AddScoped<ServicoFrete>();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar a política de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
