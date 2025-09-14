namespace API_Encuesta_Movilidad_Laboral.DTO.AccountDTO
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
