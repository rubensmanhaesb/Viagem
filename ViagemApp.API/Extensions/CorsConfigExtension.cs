namespace ViagemApp.API.Extensions
{
    public static class CorsConfigExtension
    {
        #region Atributos
        // Define o nome padrão da política de CORS
        private static string _name = "DefaultPolicy";
        // Define uma lista de origens permitidas para a política de CORS
        private static string[] _origins = {
            "http://localhost:5155"
        };

        #endregion

        /// <summary>
        /// Método de extensão para adicionar a configuração de CORS ao container de serviços.
        /// Este método define uma política de CORS com o nome especificado em <see cref="_name"/>,
        /// permitindo que a API aceite requisições apenas das origens especificadas em <see cref="_origins"/>.
        /// A política também permite qualquer método HTTP (GET, POST, etc.) e qualquer cabeçalho.
        /// </summary>
        /// <param name="services">A coleção de serviços a ser configurada.</param>
        /// <returns>O próprio <see cref="IServiceCollection"/> com a configuração de CORS adicionada.</returns>
        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            // Adiciona o serviço de CORS com a política definida
            services.AddCors(options =>
            {
                // Adiciona uma política de CORS com o nome definido em `_name`
                options.AddPolicy(_name, policy =>
                {
                    // Configura a política para permitir apenas requisições de origens específicas, permitindo qualquer método HTTP e qualquer cabeçalho
                    policy.WithOrigins(_origins).AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;
        }

        /// <summary>
        /// Método de extensão para <see cref="IApplicationBuilder"/>, que aplica a configuração de CORS
        /// no pipeline de middleware da aplicação.
        /// Este método garante que as políticas de CORS definidas sejam aplicadas às requisições HTTP recebidas pela aplicação.
        /// </summary>
        /// <param name="app">
        /// Uma instância de <see cref="IApplicationBuilder"/>, que representa o pipeline de configuração
        /// do middleware para a aplicação. Ele permite adicionar, configurar e organizar middlewares
        /// que processam as requisições HTTP.
        /// </param>
        /// <returns>O próprio <see cref="IApplicationBuilder"/> com a configuração de CORS aplicada.</returns>

        public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
        {
            // Aplica a política de CORS configurada usando o nome definido em `_name`
            app.UseCors(_name);
            return app;
        }
    }
}
