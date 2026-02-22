using Microsoft.EntityFrameworkCore;
using Sistema_de_Facturacion_Electronica.Data;

namespace Sistema_de_Facturacion_Electronica.Middlewares
{
    public class RegistroSesion 
    {
        private readonly RequestDelegate _sesion;

        public RegistroSesion(RequestDelegate sesion) 
        {
            _sesion = sesion;
        }

        public async Task InvokeAsync(HttpContext ContextHttp, Contexto DbContext) 
        {
            if (ContextHttp.User.Identity.IsAuthenticated)
            {
                var Usuario = ContextHttp.User.Identity.Name;
                await DbContext.Database.ExecuteSqlRawAsync("EXEC sp_set_session_context @key=N'UsuarioApp', @value={0}",Usuario);
            }

            await _sesion(ContextHttp);
        }
    }
}
