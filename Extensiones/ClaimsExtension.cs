using System.Security.Claims;

namespace Sistema_de_Facturacion_Electronica.Extensiones
{
    public static class ClaimsExtension
    {
        public static string GetGivenName(this ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            return claim?.Value ?? string.Empty;
        }
    }
}
