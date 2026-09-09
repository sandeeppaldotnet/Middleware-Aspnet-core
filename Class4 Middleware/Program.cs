using Class4_Middleware.MIDDLEWARE;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<RequestLoggingMiddleware>();
app.Run();
app.MapControllers();


//app.Use(async (context, next) =>
//{
//    // Custom middleware logic before the next middleware
//    Console.WriteLine("Middleware 1: Before next middleware");
//   await next.Invoke();
//    // Custom middleware logic after the next middleware
//    Console.WriteLine("Middleware 1: After next middleware");
//});




//app.Use(async (context, next) =>
//{
//    // Custom middleware logic before the next middleware
//    Console.WriteLine(" Middleware 2: Before next middleware");
//    await next.Invoke();
//    // Custom middleware logic after the next middleware
//    Console.WriteLine("Middleware 2: After next middleware");
//});

//app.Map("/health", healthApp =>
//{
//    healthApp.Run(async context =>
//    {
//        await context.Response.WriteAsync("Healthy api is runninng.");
//    });
//});

app.Map("/welcome", welcome =>
{
    welcome.Run(async context =>
    {
        await context.Response.WriteAsJsonAsync("welcome api is runninng.");
    });
});


app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 1 - BEFORE");

    await next();

    Console.WriteLine("Middleware 1 - AFTER");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 2 - BEFORE");

    await next();

    Console.WriteLine("Middleware 2 - AFTER");
});

//app.Run(async context =>
//{
//    Console.WriteLine("Endpoint");

//    await context.Response.WriteAsync("Hello from DevStore");
//});


//app.Use(async (context, next) =>
//{
//    // Custom middleware logic before the next middleware
//    Console.WriteLine("Middleware 1");

//    await context.Response.WriteAsync("Pipeline Stopped");
//    //await next.Invoke();
//    // Custom middleware logic after the next middleware
//    //Console.WriteLine("Middleware 1: After next middleware");
//});




