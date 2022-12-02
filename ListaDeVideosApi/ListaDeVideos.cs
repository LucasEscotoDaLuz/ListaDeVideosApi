using System.ComponentModel.DataAnnotations;

namespace ListaDeVideosApi
{
    public class ListaDeVideos
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Categoria de preenchimento obrigatório.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Título de preenchimento obrigatório.")]
        public string Titulo{ get; set; } = string.Empty;

        [Range(1, 600, ErrorMessage = "Campo Duracao de preenchimento obrigatório.")]
        public int Duracao { get; set; } 

        [Required(ErrorMessage = "Campo Url de preenchimento obrigatório.")]
        public string Url { get; set; } = string.Empty;
    }
}
