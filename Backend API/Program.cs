using Microsoft.AspNetCore.Mvc;
using HotelWebAPI.Models;

namespace HotelWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();
            builder.Services.AddTransient<IHotelMenuComponent, HotelMenuComponent>();
            builder.Services.AddCors((options) =>
            {
                options.AddPolicy("myPolicy", (options) =>
                {
                    options.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseCors("myPolicy");

            // Configure the HTTP request pipeline.

            //app.UseAuthorization();


            app.MapGet("/Menu", ([FromServices] IHotelMenuComponent com) =>
            {
                return com.GetAllDishes();
            });



            app.MapGet("/Menu/{id}", (int id, IHotelMenuComponent com) =>
            {
                return com.FindDish(id);
            });



            app.MapPost("/Menu", (Hotel pb, IHotelMenuComponent com) =>
            {
                com.AddDish(pb);
            });

            app.MapPut("/Menu/{:id}", (Hotel pb, IHotelMenuComponent com) =>
            {
                com.UpdateDish(pb);
            });

            app.MapDelete("/Menu/{id}", (int id, IHotelMenuComponent com) =>
            {
                com.DeleteDish(id);
            });

            //app.MapControllers();

            app.Run();
        }
    }
}