using Microsoft.EntityFrameworkCore;

namespace AspNetCoreEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(connectionString: builder.Configuration["CONNECTION_STRING"] ?? builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            var dbContext = app.Services.GetService<Context>();

            dbContext.Database.Migrate();

            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User("reza", "noei", "reza@noei.com"));
                dbContext.SaveChanges();
            }

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
        }
    }
}