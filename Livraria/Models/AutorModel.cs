using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class AutorModel
    {
                public AutorModel()
        {
            this.Livro = new HashSet<LivroModel>();
        }
        [Key]
        public int IdAutor { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<LivroModel> Livro { get; set; }
    }
}