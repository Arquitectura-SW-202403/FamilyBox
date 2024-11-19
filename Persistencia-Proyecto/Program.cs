using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Persistencia.Data;
using Persistencia.Interface;
using Persistencia.Repository;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

Console.WriteLine(Environment.GetEnvironmentVariable("MYSQL_URI"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(Environment.GetEnvironmentVariable("MYSQL_URI")!)
);


builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IInstalacionRepository, InstalacionRepository>();
builder.Services.AddScoped<ISedeRepository, SedeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<INotificacionRepository, NotificacionRepository>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IProgramaDepRepository, ProgramaDepRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configura el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
     app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.Run();