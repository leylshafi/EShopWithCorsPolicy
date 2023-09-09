using EShop.Application;
using EShop.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
 policy.WithOrigins("https://localhost:7176", "http://localhost:7176").AllowAnyHeader().AllowAnyMethod()
));
builder.Services.AddScoped<IConfigurationBuilder,ConfigurationBuilder>();
builder.Services.AddControllers();
builder.Services.AddPersistenceService();
builder.Services.AddApplicationServices();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(op =>
	{
		op.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("My first very strong key dofvihdfoivhdoivhdofisvhosihvoidhvodsihvosisydtucgsdihcsdhviu dsivuhsdivuhsiuvhi")),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(op =>
{
	op.AddSecurityDefinition("oauth", new OpenApiSecurityScheme
	{
		Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\")",
		In = ParameterLocation.Header,
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey
	});
	op.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
