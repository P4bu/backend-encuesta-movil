using API_Encuesta_Movilidad_Laboral.DTO.HomeDTO;
using API_Encuesta_Movilidad_Laboral.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;

namespace API_Encuesta_Movilidad_Laboral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(UserManager<Usuario> userManager,
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

        [HttpGet("getUsuario")]
        public async Task<ActionResult> getUsuario()
        {
            var correo = User.Claims.FirstOrDefault(claim => claim.Type == "correo").Value;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == correo);
            var userDTO = new UsuarioDTO();
            userDTO = _mapper.Map<UsuarioDTO>(user);
            var userId = new { id = userDTO.Id };

            return Ok(userId);
        }

        [HttpGet("getTipoTransportes")]
        public async Task<List<TipoTransporteDTO>> GetTipoTransportes()
        {
            var entities = await _context.TiposTransportes.ToListAsync();
            var dtos = new List<TipoTransporteDTO>();
            dtos = _mapper.Map<List<TipoTransporteDTO>>(entities);
            return dtos;
        }

        [HttpGet("getTransportes")]
        public async Task<List<TransporteDTO>> GetTransportes()
        {
            var entities = await _context.Transportes.ToListAsync();
            var dtos = new List<TransporteDTO>();
            dtos = _mapper.Map<List<TransporteDTO>>(entities);
            return dtos;
        }

        [HttpPost("submitEncuesta")]
        public async Task<ActionResult> submitEncuesta(EncuestaDTO encuestaDTO)
        {
            var entity = new Encuesta
            {
                idUsuario = encuestaDTO.idUsuario,
                transporteId = encuestaDTO.idTransporte,
                km_recorrido = encuestaDTO.km_recorrido,
                minutos_recorrido = encuestaDTO.minutos_recorrido,
                dias_trabajo = encuestaDTO.dias_trabajo
            };

            var userEncuesta = await _context.Encuestas.AnyAsync(x => x.idUsuario == encuestaDTO.idUsuario);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == encuestaDTO.idUsuario);
            user.esCompartido = encuestaDTO.esCompartido;

            if (userEncuesta)
            {
                return BadRequest("Ya se realizo una encuesta");
            }
            else
            {
            _context.Encuestas.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
            }
        }
    }
}
