namespace API_Encuesta_Movilidad_Laboral.Entities
{
    public class ComunaRes
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Usuario> usuarios { get; set; }
    }
}
