using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Movies.api.Auth;
using Movies.api.DbContexts;
using Movies.api.Services;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddScoped<IJwtUtils, JwtUtils>();
    builder.Services.AddScoped<IMovieService, MovieService>();
    builder.Services.AddScoped<IDirectorService, DirectorService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddDbContext<MoviesContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
    app.Run();
}

