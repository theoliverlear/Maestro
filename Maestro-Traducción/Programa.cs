using Microsoft.Extensions.Hosting;

HostApplicationBuilderSettings configuración = new()
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
};
HostApplicationBuilder constructor = Host.CreateApplicationBuilder(configuración);
IHost app = constructor.Build();
await app.RunAsync();
