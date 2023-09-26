using CustomIdentityUser.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices();

var app = builder.Build();
app.RegisterApplications();
app.Run();