using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Facturacion_Electronica.Dtos.Usuario;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Modelos;
//using System.Reflection.Metadata.Ecma335;

namespace Sistema_de_Facturacion_Electronica.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class ControladorUsuario : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signManager;
        private readonly IGenerarToken _token;

        public ControladorUsuario(UserManager<Usuario> userManager,SignInManager<Usuario> signManager,IGenerarToken token) 
        {
            _userManager = userManager;
            _signManager = signManager;
            _token = token;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> PostRegistro([FromBody] RegistroUsuario NodoRegistro) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var UsuarioRegistro = new Usuario()
                {
                    Email = NodoRegistro.Email,
                    UserName = NodoRegistro.Username,
                };

                var Registro = await _userManager.CreateAsync(UsuarioRegistro,NodoRegistro.Contraseña);
                if (Registro.Succeeded)
                {
                    var AsignacionRol = await _userManager.AddToRoleAsync(UsuarioRegistro, "USER");
                    if (AsignacionRol.Succeeded)
                    {
                        return Ok(new UsuarioAutenticado
                        {
                            Email = UsuarioRegistro.Email,
                            Username = UsuarioRegistro.UserName,
                            Token = _token.GenerarToken(UsuarioRegistro, "User")
                        });
                    }
                    else
                    {
                        return StatusCode(500,"Error al intentar asignar un Rol al usuario");
                    }
                }
                else 
                {
                    return StatusCode(500,"Error al intentar registrar al nuevo usuario");
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error interno del servidor {ex.Message}");
            }            
        }

        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginUsuario NodoLogin)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var Usuario = await _userManager.Users.FirstOrDefaultAsync(m => m.UserName == NodoLogin.Username.ToLower());
            if(Usuario == null) return NotFound("Este Usuario no se encuentra registrado");
            var LoginUsuario = await _signManager.CheckPasswordSignInAsync(Usuario,NodoLogin.Contraseña,false);
            if (LoginUsuario.Succeeded)
            {
                var Rol = (await _userManager.GetRolesAsync(Usuario)).FirstOrDefault();
                return Ok(new UsuarioAutenticado
                {
                    Email = Usuario.Email!,
                    Username = Usuario.UserName!,
                    Token = _token.GenerarToken(Usuario, Rol!),
                });
            }
            else 
            {
                return StatusCode(401,"Usuario o Contraseñas Incorrectas");
            }
        }
    }
}
