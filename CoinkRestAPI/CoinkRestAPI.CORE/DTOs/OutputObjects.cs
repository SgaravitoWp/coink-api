using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace CoinkRestAPI.CORE.DTOs
{
   
    
    // Clase que representa una respuesta de error
    public class ErrorResponse
    {
        // Propiedad que representa el tipo de error (opcional)
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? type { get; set; }

        // Propiedad que indica si la operación fue exitosa (opcional)
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? success { get; set; }

        // Propiedad que representa el título del error (obligatoria)
        [Required]
        public string title { get; set; }

        // Propiedad que representa los errores detallados (opcional)
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string[]>? errors { get; set; }

        // Propiedad que representa el ID de seguimiento (opcional)
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? traceId { get; set; }

        // Propiedad que representa el estado HTTP de la respuesta (obligatoria)
        [Required]
        public int status { get; set; }
    }

    public class SuccessResponse<T>
    {
        // Propiedad que indica si la operación fue exitosa (obligatoria)
        [Required]
        public bool success { get; set; }

        // Propiedad que representa un mensaje de éxito (obligatoria)
        [Required]
        public string message { get; set; }

        // Propiedad que contiene los datos de la respuesta (obligatoria)
        [Required]
        public IEnumerable<T> data { get; set; }

        // Propiedad que representa el código de estado HTTP de la respuesta (obligatoria)
        [Required]
        public int status_code { get; set; }
    }



}
