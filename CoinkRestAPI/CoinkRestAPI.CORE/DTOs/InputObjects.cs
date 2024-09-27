using System.ComponentModel.DataAnnotations;

namespace CoinkRestAPI.CORE.DTOs
{
    /// <summary>
    /// Clase que valida una petición GET de departamentos.
    /// </summary>
    public class StateGet
    {
        /// <summary>
        /// ID del país requerido.
        /// </summary>
        [Required(ErrorMessage = "El ID del país es requerido.")]
        public string country_id { get; set; }
    }

    /// <summary>
    /// Clase que valida una petición GET de municipios.
    /// </summary>
    public class CityGet
    {
        /// <summary>
        /// ID del departamento requerido.
        /// </summary>
        [Required(ErrorMessage = "El ID del departamento es requerido.")]
        public int state_id { get; set; }
    }

    /// <summary>
    /// Clase que valida una petición POST para crear un usuario.
    /// </summary>
    public class UserPost
    {
        /// <summary>
        /// ID del usuario requerido, debe contener entre 6 y 12 dígitos.
        /// </summary>
        [Required(ErrorMessage = "El ID del usuario es requerido.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El ID del usuario solo puede contener dígitos.")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "El ID del usuario debe tener entre 6 y 12 dígitos.")]
        public string user_id { get; set; }

        /// <summary>
        /// Nombre del usuario requerido, con una longitud máxima de 100 caracteres.
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string name { get; set; }

        /// <summary>
        /// Número de teléfono requerido, debe contener entre 10 y 15 dígitos.
        /// </summary>
        [Required(ErrorMessage = "El número de teléfono es requerido.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de teléfono solo puede contener dígitos.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "El número de teléfono debe tener entre 10 y 15 dígitos.")]
        public string phone { get; set; }

        /// <summary>
        /// Dirección requerida, con una longitud máxima de 255 caracteres.
        /// </summary>
        [Required(ErrorMessage = "La dirección es requerida.")]
        [StringLength(255, ErrorMessage = "La dirección no puede exceder los 255 caracteres.")]
        public string address { get; set; }

        /// <summary>
        /// ID del país requerido, debe tener exactamente 3 caracteres.
        /// </summary>
        [Required(ErrorMessage = "El ID del país es requerido.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El ID del país debe tener exactamente 3 caracteres.")]
        public string country_id { get; set; }

        /// <summary>
        /// ID del departamento requerido.
        /// </summary>
        [Required(ErrorMessage = "El ID del departamento es requerido.")]
        public int state_id { get; set; }

        /// <summary>
        /// ID del municipio requerido.
        /// </summary>
        [Required(ErrorMessage = "El ID del municipio es requerido.")]
        public int city_id { get; set; }
    }
}