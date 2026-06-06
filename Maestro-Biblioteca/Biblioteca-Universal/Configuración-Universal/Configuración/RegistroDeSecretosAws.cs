using System.Text.Json;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Maestro.Biblioteca.Universal.Configuración;

public static class RegistroDeSecretosAws
{
    public static async Task CargarSecretosAws(this IConfigurationManager configuración,
                                               IHostEnvironment ambiente)
    {
        if (!configuración.GetValue<bool>("AwsSecrets:Enabled"))
        {
            return;
        }

        string idDelSecreto = configuración["AwsSecrets:SecretId"]
            ?? throw new InvalidOperationException("AwsSecrets:SecretId es obligatorio cuando AwsSecrets:Enabled es true.");
        string región = configuración["AwsSecrets:Region"] ?? "us-east-1";

        using AmazonSecretsManagerClient cliente = new(RegionEndpoint.GetBySystemName(región));
        GetSecretValueResponse respuesta = await cliente.GetSecretValueAsync(new GetSecretValueRequest
        {
            SecretId = idDelSecreto
        });

        if (string.IsNullOrWhiteSpace(respuesta.SecretString))
        {
            throw new InvalidOperationException($"El secreto AWS '{idDelSecreto}' no contiene SecretString.");
        }

        Dictionary<string, string?> secretos = JsonSerializer.Deserialize<Dictionary<string, string?>>(
            respuesta.SecretString) ?? throw new InvalidOperationException($"El secreto AWS '{idDelSecreto}' no contiene JSON válido.");

        configuración.AddInMemoryCollection(secretos);
        configuración.ValidarSecretosRequeridos(ambiente);
    }

    public static string ObtenerClaveJwt(this IConfiguration configuración,
                                         IHostEnvironment ambiente)
    {
        string? claveJwt = configuración["Jwt:Clave"];
        if (!string.IsNullOrWhiteSpace(claveJwt))
        {
            return claveJwt;
        }

        if (!ambiente.IsDevelopment())
        {
            throw new InvalidOperationException(
                "Jwt:Clave es obligatoria. Configúrala en AWS Secrets Manager o Jwt__Clave.");
        }

        throw new InvalidOperationException(
            "Jwt:Clave es obligatoria. Configúrala en AWS Secrets Manager, user-secrets o Jwt__Clave.");
    }

    private static void ValidarSecretosRequeridos(this IConfiguration configuración,
                                                  IHostEnvironment ambiente)
    {
        if (ambiente.IsDevelopment())
        {
            return;
        }

        const string secretoRequerido = "MaestroBd";
        
        if (string.IsNullOrWhiteSpace(configuración.GetConnectionString(secretoRequerido)))
        {
            throw new InvalidOperationException($"ConnectionStrings:{secretoRequerido} es obligatoria fuera de desarrollo.");
        }

        configuración.ObtenerClaveJwt(ambiente);
    }
}
