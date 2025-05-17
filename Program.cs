using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// 1. Error-handling middleware first
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 2. Authentication middleware next
app.UseMiddleware<TokenValidationMiddleware>();

// 3. Logging middleware last
app.UseMiddleware<LoggingMiddleware>();

app.Run();
