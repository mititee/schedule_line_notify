using LineNotification.Adapters.Models;
using LineNotification.Models.Interface;
using LineNotification.Models.Job;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

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

IMessageJob messageJob = new MessageJobV1(new SendMessageV1(),new ServerConfig(app.Configuration));
messageJob.IsTest= true;


app.Run();


