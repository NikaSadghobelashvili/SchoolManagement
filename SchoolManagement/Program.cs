using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Services;
using DTO;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddScoped<IStudentRepository, StudentRepository>();
    services.AddScoped<IClassroomRepository, ClassroomRepository>();

    services.AddScoped<StudentService>();
    services.AddScoped<ClassroomService>();
    services.Configure<ConsoleLifetimeOptions>(opts => opts.SuppressStatusMessages = true);

    services.AddDbContext<SchoolManagementDbContext>(x =>

    services.AddDbContext<SchoolManagementDbContext>(x =>
    x.UseSqlServer("server =.; database = SchoolManagement; integrated security = true; TrustServerCertificate = true")));
}).Build();
builder.Start();

var student1 = builder.Services.GetRequiredService<StudentService>();
var classRoom1 = builder.Services.GetRequiredService<ClassroomService>();

