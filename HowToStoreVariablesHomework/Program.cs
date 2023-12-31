using HowToStoreVariablesHomework.Constants;
using HowToStoreVariablesHomework.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddSingleton(builder.Configuration.GetSection("Img").Get<ImgConstants>());
var adminConstant = builder.Configuration.GetSection("ADMIN")?.Get<AdminConstant>();
if (adminConstant != null)
{
    builder.Services.AddSingleton(adminConstant);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/ping");

app.Run();
