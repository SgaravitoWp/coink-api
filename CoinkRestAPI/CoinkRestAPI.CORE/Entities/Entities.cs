using System.ComponentModel.DataAnnotations;

namespace CoinkRestAPI.CORE.Entities
{
    public class User 
    {

        // Propiedad que representa el ID del usuario en DB 
        [Required]
        public string id { get; set; }

        // Numero de documento del usuario 
        [Required]
        public int user_id { get; set; }

        // Nombre del usuario
        [Required]
        public string name { get; set; }

        // Número de teléfono. 
        [Required]
        public string phone { get; set; }

        // Dirección del usuario. 
        [Required]
        public string address { get; set; }

        // ID del país 
        [Required]
        public string country_id { get; set; }

        // ID del departamento 
        [Required]
        public int state_id { get; set; }

        // ID del municipio 
        [Required]
        public int city_id { get; set; }

    }

    // Clase que representa un país
    public class Country
    {
        // ID del país 
        [Required]
        public string id { get; set; }

        // Nombre del país 
        [Required]
        public string name { get; set; }
    }

    // Clase que representa un departamento, heredando de StateGet
    public class State 
    {
        // ID del departamento 
        [Required]
        public int id { get; set; }

        // Nombre del departamento 
        [Required]
        public string name { get; set; }

        // ID del país. 
        [Required]
        public string country_id { get; set; }
    }

    // Clase que representa una municipio, heredando de CityGet
    public class City 
    {
        // ID del municipio (requerida)
        [Required]
        public int id { get; set; }

        // Nombre de la municipio 
        [Required]
        public string name { get; set; }

        // ID del departamento. 
        [Required]
        public int state_id { get; set; }
    }
}
