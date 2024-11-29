using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemAPI.Context;
using SchoolManagementSystemAPI.Interface;
using SchoolManagementSystemAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IClass,ClassService>();
builder.Services.AddScoped<IStudent,StudentService>();
builder.Services.AddScoped<ISubject,SubjectService>();
builder.Services.AddScoped<ITeacher,TeacherService>();
builder.Services.AddScoped<IUser,UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDBLocalConnection")),ServiceLifetime.Singleton);

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
