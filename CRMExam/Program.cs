


using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication().AddCookie("Cookies", opts =>
{
    opts.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    opts.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    opts.Events.OnRedirectToAccessDenied = (context) =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<ContactService>();
builder.Services.AddTransient<SaleService>();
builder.Services.AddTransient<LeadService>();

builder.Services.AddScoped<GlobalExceptionHandling>();


builder.Services.AddAutoMapper(typeof(Program).Assembly);

   


var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandling>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();


app.Use((HttpContext context, RequestDelegate next) =>
{
    return next(context);
});


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
