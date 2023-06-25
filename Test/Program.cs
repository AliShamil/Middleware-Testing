using MyFirstAmazingWebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<HakunaMiddleware>();

app.MapWhen(context => context.Request.Path.StartsWithSegments("/time"), builder =>
{
    builder.UseMiddleware<TimeRestrictionMiddleware>();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
