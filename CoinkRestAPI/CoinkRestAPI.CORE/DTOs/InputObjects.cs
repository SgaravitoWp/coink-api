using System.ComponentModel.DataAnnotations;
namespace CoinkRestAPI.CORE.DTOs
{

        // Clase que valida una peticion GET de departamentos. 
        public class StateGet
        {
            // ID del país requerido
            [Required(ErrorMessage = "The country ID is required.")]
            public string country_id { get; set; }
        }

        // Clase que valida una peticion GET de municipios. 
        public class CityGet
        {
            // ID del departamento requerido. 
            [Required(ErrorMessage = "The department ID is required.")]
            public int state_id { get; set; }
        }

        // Clase que valida una peticion POST de para crear un usuario. 
        public class UserPost
        {

            [Required(ErrorMessage = "The user id is required.")]
            public int user_id { get; set; }
            // Nombre del usuario requerido, con una longitud máxima de 100 caracteres
            [Required(ErrorMessage = "The name is required.")]
            [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
            public string name { get; set; }

            // Número de teléfono requerido, con una longitud máxima de 20 caracteres
            [Required(ErrorMessage = "The phone number is required.")]
            [RegularExpression(@"^\d+$", ErrorMessage = "The phone number can only contain digits.")]
            [StringLength(20, ErrorMessage = "The phone number must be between 10 and 15 digits.")]
            public string phone { get; set; }

            // Dirección requerida, con una longitud máxima de 255 caracteres
            [Required(ErrorMessage = "The address is required.")]
            [StringLength(255, ErrorMessage = "The address cannot exceed 255 characters.")]
            public string address { get; set; }

            // ID del país requerido, con una longitud de 3 caracteres
            [Required(ErrorMessage = "The country ID is required.")]
            [StringLength(3, ErrorMessage = "The country ID must be 3 characters long.")]
            public string country_id { get; set; }

            // ID del departamento requerido
            [Required(ErrorMessage = "The department ID is required.")]
            public int state_id { get; set; }

            // ID del municipio requerido
            [Required(ErrorMessage = "The city ID is required.")]
            public int city_id { get; set; }
        }
    

}
