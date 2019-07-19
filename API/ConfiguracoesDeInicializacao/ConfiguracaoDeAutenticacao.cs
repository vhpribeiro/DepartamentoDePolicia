using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeAutenticacao
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secrekeysecrekeysecrekey"));
            services.AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwt =>
                {
                    jwt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidIssuer = configuration["Data:BearerAuthentication:UrlBase"],
                        IssuerSigningKey = signingKey,
                        ValidateAudience = false
                    };
                });
        }
    }
}