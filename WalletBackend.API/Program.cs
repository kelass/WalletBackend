using WalletBackend.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddWalletIdentity();
builder.Services.AddRepositories();
builder.Services.AddManagers();
builder.Services.AddSchedule();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Services.UseMigrations();
app.Services.ActiveScheduler();
app.Run();
