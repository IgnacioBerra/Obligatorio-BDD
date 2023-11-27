using API;
using API.Data;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataInfo>(options =>
{
    options.UseSqlServer(connectionString);    
});

var hangfireConnectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config =>
    {
        config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(hangfireConnectionString);
    }
);

// Adding cache
builder.Services.AddSingleton<IRedisCache>(serviceProvider =>
{
    var distributedCache = serviceProvider.GetRequiredService<IDistributedCache>();
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    return new RedisCacheService(distributedCache, connectionString);
});
builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = builder.Configuration["RedisCacheUrl"]; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireServer();

app.UseHangfireDashboard(); // Optional: Use Hangfire dashboard for monitoring jobs

app.MapControllers();
// A las 3 am pega a la base de datos para saber que mails debe enviar
RecurringJob.AddOrUpdate("EmailRetriever", () => HangFireScheduler.getEmailsForNotification(connectionString),"0 3 * * *");
// A las 15:30 envía los mails
RecurringJob.AddOrUpdate("SendMails", () => HangFireScheduler.sendEmails(), "30 15 * * *");

app.Run();
