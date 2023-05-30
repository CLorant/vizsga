
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using USZO_EB.Models;

namespace USZO_EB
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // AddControllers-hez hozzáadva az AddJsonOptions

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<UszoebContext>(); // AddDbContext hogy ne kelljen újradeklarálni a contextet
            
            builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); }); // Cors minden engedélyezése

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Cors használata

            app.Run();

            /*
            1. létrehozol egy asp.net core web api .NET 7.0 projektet

            2. Tools -> nuget package manager -> for solution

            3. Csomagok:
                microsoft.entityframeworkcore
                microsoft.entityframeworkcore.tools
                mysql.entityframeworkcore

            4. package manager consoleba:
                Scaffold-DbContext "server=localhost;database=ADATBÁZIS NEVE;user=root;password=;sslmode=none;" mysql.entityframeworkcore -outputdir Models –f
            */
        }
    }
}