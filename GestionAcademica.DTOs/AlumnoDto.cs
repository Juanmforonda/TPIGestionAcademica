namespace GestionAcademica.DTOs
{
    public class AlumnoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Legajo { get;  set; }
        public string Email { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
