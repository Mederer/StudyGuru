using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StudyGuru.Api.Endpoints;
using StudyGuru.Application;
using StudyGuru.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

const string allowedOrigins = "AllowedOrigins";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

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
    options.Authority = "https://studyguruorg.b2clogin.com/studyguruorg.onmicrosoft.com/B2C_1_SignInSignUp/v2.0/";
    options.Audience = "53f95087-8c02-4dbc-a3ed-18ba01e77a8f";
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

app.Run();