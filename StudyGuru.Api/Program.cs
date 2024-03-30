using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StudyGuru.Api.Endpoints;
using StudyGuru.Application;
using StudyGuru.Infrastructure;
using StudyGuru.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

const string allowedOrigins = "AllowedOrigins";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration.GetSection("Database")["ConnectionString"]!);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins, policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration.GetSection("Jwt")["Authority"];
    options.Audience = builder.Configuration.GetSection("Jwt")["Audience"];
    options.MapInboundClaims = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    };
});


builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StudyGuruDbContext>();
    // dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(allowedOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapFlashCardEndpoints();
app.MapTopicEndpoints();

app.Run();