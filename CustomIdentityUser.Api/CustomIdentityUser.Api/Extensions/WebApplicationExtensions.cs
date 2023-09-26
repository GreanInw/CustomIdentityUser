namespace CustomIdentityUser.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication RegisterApplications(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
