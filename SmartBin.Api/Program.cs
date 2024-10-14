
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .WithOrigins("localhost", "https://sawacofinal-4.vercel.app", "http://localhost:3003", "http://localhost:3004", "http://localhost:3005", "http://localhost:3006", "http://localhost:3007", "http://localhost:3008", "http://localhost:3009", "http://localhost:3010")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SmartBin.Api"))
);

builder.Services.AddHostedService<ScadaHost>();
builder.Services.Configure<MqttOptions>(builder.Configuration.GetSection("MqttOptions"));
builder.Services.AddSingleton<ManagedMqttClient>();
builder.Services.AddSingleton<MqttBuffer>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPointChangeService, PointChangeService>();
builder.Services.AddScoped<IPointChangeRepository, PointChangeRepository>();
builder.Services.AddScoped<IBinService, BinService>();
builder.Services.AddScoped<IBinRepository, BinRepository>();
builder.Services.AddScoped<IBinUnitService, BinUnitService>();
builder.Services.AddScoped<IBinUnitRepository, BinUnitRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddAutoMapper(typeof(ModelToViewModelProfile));
builder.Services.AddAutoMapper(typeof(ViewModelToModelProfile));

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<NotificationHub>("/NotificationHub");
app.MapControllers();

app.Run();