using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Models
{
    public class GrupoModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
