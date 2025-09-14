namespace API_Encuesta_Movilidad_Laboral.Entities
{
    public class TipoTransporte
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Transporte> transportes { get; set; }
    }
}
