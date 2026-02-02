using ExaminationSystem.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {


        var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(ExaminationSystem.Helper.MappingHelper).Assembly);
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<ExaminationSystem.Filters.GlobalErrorHandlerMiddleware>();
            builder.Services.AddScoped<ExaminationSystem.Filters.TransactionMiddleware>();

            var key = Encoding.ASCII.GetBytes(Constants.SecretKey);
            builder.Services.AddAuthentication(opt=>opt.DefaultAuthenticateScheme =Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                        ValidIssuer = "ExaminationSystem_Issuer",
                        ValidAudience = "Front_ExaminationSystem",

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                });

            builder.Services.AddAuthorization();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExaminationDB;Integrated Security=True;TrustServerCertificate=True";

            builder.Services.AddDbContext<ExaminationSystem.Data.Context>(options =>
                options.UseSqlServer(connectionString)
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                       .EnableSensitiveDataLogging(true)
            );

            var app = builder.Build();      

            app.UseAuthentication();
            app.UseAuthorization(); 
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExaminationSystem.Filters.GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<ExaminationSystem.Filters.TransactionMiddleware>();
            
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
