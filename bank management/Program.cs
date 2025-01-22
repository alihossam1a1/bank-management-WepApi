using bank_management.data;
using bank_management.repo.account;
using bank_management.repo.branch;
using bank_management.repo.customer;
using bank_management.repo.employee;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>
(x => x.UseSqlServer(builder.Configuration.GetConnectionString("mydata")));

builder.Services.AddScoped<Iaccountrepo, accountrepo>();
builder.Services.AddScoped<Ibranchrepo, branchrepo>();
builder.Services.AddScoped<Icustomer,customerrepo >();
builder.Services.AddScoped<Iemployeerepo, employeerepo>();



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
