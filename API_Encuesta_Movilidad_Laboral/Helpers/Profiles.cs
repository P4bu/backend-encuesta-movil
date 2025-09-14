using API_Encuesta_Movilidad_Laboral.DTO.AccountDTO;
using API_Encuesta_Movilidad_Laboral.DTO.HomeDTO;
using API_Encuesta_Movilidad_Laboral.Entities;
using AutoMapper;

namespace API_Encuesta_Movilidad_Laboral.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<SitLaboral, SitLaboralDTO>();
            CreateMap<Modalidad, ModalidadDTO>();
            CreateMap<ComunaRes, ComunaResDTO>();
            CreateMap<ComunaTra, ComunaTraDTO>();
            CreateMap<TipoTransporte, TipoTransporteDTO>();
            CreateMap<Transporte, TransporteDTO>();
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
