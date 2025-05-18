using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
var app = builder.Build();
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//using System;
//using System.Collections.Generic;
//using System.Threading;

//namespace MicroSim
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //HexCodes hexCodes = new HexCodes();
//            //hexCodes.takeOpCodes();
//            //hexCodes.showCodes();
//            //Decode dc = new Decode(hexCodes.codeHistory);
//            //dc.operation();
//            //hexCodes.showCodes();
//        }
//    }
//}
