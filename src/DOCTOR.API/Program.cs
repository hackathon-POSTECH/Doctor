using DOCTOR.APPLICATION;
using DOCTOR.APPLICATION.doctor.CreateDoctor;
using DOCTOR.APPLICATION.Doctor.CreateDoctor;
using DOCTOR.APPLICATION.Doctor.GetAllDoctors;
using DOCTOR.APPLICATION.Doctor.VerifyDoctor;
using DOCTOR.INFRA.consumers;
using DOCTOR.INFRA.context;
using DOCTOR.INFRA.RabbitMq;
using DOCTOR.INFRA.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});


builder.Services.AddSingleton<ICreateChannelRabbitMql, CreateChannelRabbitMql>();
builder.Services.AddHostedService<CreateDoctorConsumer>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddTransient<IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>, CreateDoctorCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllDoctorsQuery,  IEnumerable<GetAllDoctorsResponse>>, GetAllDoctorsQueryHandler>();
builder.Services.AddTransient<IRequestHandler<VerifyDoctorQuery, ResultPattern<VerifyDoctorResponse>>, VerifyDoctorQueryHandler>();

builder.Services.AddDbContext<DOCTORCONTEXT>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0fasjdhksajhduiwqadskjhkSKJD")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Schedule API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Entre com o token JWT",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "DOCTOR V1"); });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
