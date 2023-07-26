using FinancialTrackerApi.Context;
using FinancialTrackerApi.Controllers;
using FinancialTrackerApi.Services;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//Get config
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

//Get connection string from appsettings
var connectionStringBuilder = new NpgsqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("MyDbContext"));
connectionStringBuilder.Password = builder.Configuration["DbPassword"];
var connectionString = connectionStringBuilder.ConnectionString;

//Get db provider
var dbProvider = builder.Configuration.GetValue<string>("DbProvider");

//Add authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = builder.Configuration["Auth0:Audience"];
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Financial Tracker API", Version = "v1.0" });
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    options.CustomSchemaIds(x => x.FullName);
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id= "Bearer"
                }
            },
            new string[]{ }
        }
    });
});
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = Microsoft.AspNetCore.Mvc.ApiVersion.Default;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddSwaggerGenNewtonsoftSupport();

//Add db context
if (dbProvider == "Postgres")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString, opt =>
        {
            opt.MigrationsAssembly("FinancialTrackerApi.Postgres");
        });
    });
}
else if (dbProvider == "Mssql")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(connectionString, opt =>
        {
            opt.MigrationsAssembly("FinancialTrackerApi.Mssql");
        });
    });
}

//Add scoped services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IDebtService, DebtService>();
builder.Services.AddScoped<IExpenseService,  ExpenseService>();
builder.Services.AddScoped<IRecurringExpensesService, RecurringExpensesService>();
builder.Services.AddScoped<IRecurringIncomeService, RecurringIncomeService>();
builder.Services.AddScoped<INetWorthReportService, NetWorthReportService>();
builder.Services.AddScoped<IRecurringInvestmentService, RecurringInvestmentService>();

//Add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/v1/swagger.json", "V1.0");
        //options.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
        //options.ConfigObject.AdditionalItems.Add("theme", "agate");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
