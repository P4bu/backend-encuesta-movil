using API_Encuesta_Movilidad_Laboral.DTO.AccountDTO;
using API_Encuesta_Movilidad_Laboral.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Encuesta_Movilidad_Laboral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccountController(UserManager<Usuario> userManager, 
            IConfiguration configuration, 
            SignInManager<Usuario> signInManager,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register(UserRegister userRegister)
        {
            var user = new Usuario
            {
                UserName = userRegister.Correo,
                Email = userRegister.Correo,
                nombres = userRegister.Nombres,
                apellidos = userRegister.Apellidos,
                rut = userRegister.Run,
                comunaResId = userRegister.IdComunaRes,
                fecha_nac = userRegister.FecNac,
                sitLaboralId = userRegister.IdSitLaboral,
                modalidadId = userRegister.IdModalidad,
                comunaTraId = userRegister.IdComunaTra,
                estadoId = userRegister.IdEstado
                
            };
            var result = await _userManager.CreateAsync(user, userRegister.Contraseña);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(UserLogin userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Correo, userLogin.Contraseña, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var claims = HttpContext.User.Claims;
                return BuildToken(userLogin);
            }
            else
            {
                return BadRequest("Login Incorrecto");
            }
        }

        [HttpGet("user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult User()
        {
            var response = new UserInfo();
            var emailClaim = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "correo");
            var correo = emailClaim.Value;
            response.Correo = correo;
            response.Ok = true;
            return Ok(response);
        }

        [HttpGet("getSitLaboral")]
        public async Task<List<SitLaboralDTO>> getSitLaboral()
        {
            var entities = await _context.SitLaborales.ToListAsync();
            var dtos = new List<SitLaboralDTO>();
            dtos = _mapper.Map<List<SitLaboralDTO>>(entities);
            return dtos;
        }

        [HttpGet("getModalidades")]
        public async Task<List<ModalidadDTO>> getModalidades()
        {
            var entities = await _context.Modalidades.ToListAsync();
            var dtos = new List<ModalidadDTO>();
            dtos = _mapper.Map<List<ModalidadDTO>>(entities);
            return dtos;
        }

        [HttpGet("getComunasRes")]
        public async Task<List<ComunaResDTO>> getComunasRes()
        {
            var entities = await _context.ComunasRes.ToListAsync();
            var dtos = new List<ComunaResDTO>();
            dtos = _mapper.Map<List<ComunaResDTO>>(entities);
            return dtos;
        }

        [HttpGet("getComunasTra")]
        public async Task<List<ComunaTraDTO>> getComunasTra()
        {
            var entities = await _context.ComunasTrab.ToListAsync();
            var dtos = new List<ComunaTraDTO>();
            dtos = _mapper.Map<List<ComunaTraDTO>>(entities);
            return dtos;
        }
        [HttpGet]
        public async Task<bool> esValido (UserLogin userLogin) 
        {
            var entityUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Correo);
            return entityUser.estadoId == 1 ? true : false ;
        }
        private AuthenticationResponse BuildToken(UserRegister userRegister)
        {
            var claims = new List<Claim>()
            {
                new Claim("correo", userRegister.Correo)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtkey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(1);
            var securityToken = new JwtSecurityToken
                (
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds
                );
            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };

        }

        private AuthenticationResponse BuildToken(UserLogin userLogin)
        {
            var claims = new List<Claim>()
            {
                new Claim("correo", userLogin.Correo)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtkey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(1);
            var securityToken = new JwtSecurityToken
                (
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds
                );
            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };

        }

    }

}

