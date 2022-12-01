using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    [Table ("Todo")]
    public class Todo
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [Column("Prazo")]
        [Display(Name = "Prazo")]
        public DateTime Prazo { get; set; }
    }
}
