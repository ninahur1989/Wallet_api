using Microsoft.EntityFrameworkCore;
using Wallet_App.Data;
using Wallet_App.Data.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//builder.Services.AddDbContext<AppDbContext>(
//                 b => b.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDefaultConnectionString")));

builder.Services.AddDbContext<AppDbContext>(
                 b => b.UseNpgsql(builder.Configuration.GetConnectionString("PostgreDefaultConnectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPointsService, PointsService>();

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

AppDbInitializer.Seed(app);
app.Run();
