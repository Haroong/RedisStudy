using StackExchange.Redis;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(c =>
        {
            c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod()
                .AllowAnyHeader());
        });

        var redis = ConnectionMultiplexer.Connect("localhost:6379");
        services.AddSingleton<IConnectionMultiplexer>(redis);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}