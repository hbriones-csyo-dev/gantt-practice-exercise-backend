using gantt_practice_exercise_backend.context;
using gantt_practice_exercise_backend.repository;
using gantt_practice_exercise_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



const string policyName = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


//Configure our services
ConfigureServices(builder.Services);

var app = builder.Build();

app.UseCors(policyName);


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


void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ClickHouseContext>();

    // Services
    services.AddScoped<IProjectTaskService, ProjectTaskService>();
    services.AddScoped<IProjectTaskLinkService, ProjectTaskLinkService>();

    // Repository
    services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
    services.AddScoped<IProjectTaskLinkRepository, ProjectTaskLinkRepository>();
}