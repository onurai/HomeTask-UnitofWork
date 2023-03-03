using FluentValidation.AspNetCore;
using FluentValidation;
using HomeTaskTo03._04.Data.Context;
using HomeTaskTo03._04.Repository;
using HomeTaskTo03._04.Services.Implementation;
using HomeTaskTo03._04.Services.Interfaces;
using HomeTaskTo03._04.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Serilog;
using HomeTaskTo03._04.Dto;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
       System.IO.Path.Combine("C:\\Users\\HP\\Desktop\\Back-End\\ASP.NET CORELogFiles", "Application", "diagnostics.txt"),
       rollingInterval: RollingInterval.Day,
       fileSizeLimitBytes: 10 * 1024 * 1024,
       retainedFileCountLimit: 2,
       rollOnFileSizeLimit: true,
       shared: true,
       flushToDiskInterval: TimeSpan.FromSeconds(1))
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(); // <-- Add this line

    builder.Services.AddControllers().AddFluentValidation();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultServer")));

    builder.Services.AddScoped<IPostService, PostService>();
    builder.Services.AddScoped<IPostRepository, PostRepository>();
    builder.Services.AddScoped<IBlogService, BlogService>();
    builder.Services.AddScoped<IBlogRepository, BlogRepository>();

    builder.Services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

    builder.Services.AddScoped<IValidator<BlogDto>, BlogValidator>();
    builder.Services.AddScoped<IValidator<PostDto>, PostValidator>();

    var app = builder.Build();

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
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
