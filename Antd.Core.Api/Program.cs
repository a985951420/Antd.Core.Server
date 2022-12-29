using Antd.Core.Dto.Extensions;



var builder = WebApplication.CreateBuilder(args);

AppSettingExtensions.Register(builder.Configuration);

builder.Services.AddRedis();
builder.Services.UrlLowerCase();
builder.Services.JsonCamelCase();
builder.Services.Cors();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorsAllow();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
