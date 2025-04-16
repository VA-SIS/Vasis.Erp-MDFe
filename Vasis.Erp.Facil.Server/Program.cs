using Vasis.Erp.Facil.Data;
using Vasis.Erp.Facil.Server.Components;
using Microsoft.EntityFrameworkCore;
using Vasis.Erp.Facil.Services.Cadastros;
using Vasis.Erp.Facil.Services;
using Vasis.Erp.Facil.Server.Interfaces.Cadastros;
using Vasis.Erp.Facil.Server.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(EmpresaProfile)); // AutoMapper

//builder.Services.AddScoped<IEmpresaService, EmpresaService>(); // Injeção do serviço


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<EmpresaService>();
//builder.Services.AddScoped<PessoaService>();
//builder.Services.AddScoped<TransportadoraService>();
//builder.Services.AddScoped<VeiculoService>();
//builder.Services.AddScoped<MotoristaService>();

//builder.Services.AddScoped<IVeiculoService, VeiculoService>();
//builder.Services.AddScoped<IMotoristaService, MotoristaService>();
//builder.Services.AddScoped<IVeiculoService, VeiculoService>();
//builder.Services.AddScoped<IPessoaService, PessoaService>();
//builder.Services.AddScoped<ITransportadoraService, TransportadoraService>();


var app = builder.Build();


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy
            .WithOrigins("https://localhost:5037") // porta do Blazor Client
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



app.UseCors("PermitirFrontend");



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
