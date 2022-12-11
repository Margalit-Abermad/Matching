using AppServices;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddAppServices();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//app.UseCors(options =>
//{
//    options.WithOrigins("http://localhost:4000").AllowAnyHeader().AllowAnyMethod();
//});

app.UseCors((builder)=>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});


app.MapControllers();

app.Run();
