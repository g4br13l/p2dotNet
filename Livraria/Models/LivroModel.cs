using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class LivroModel
    {   
        public LivroModel()
        {
            this.Autor = new HashSet<AutorModel>();
        }
        [Key]
        [Display( Name="Código" )]
        public int IdLivro { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        public Nullable<decimal> Preco { get; set; }
        [Display(Name = "Data Publicação")]
        public Nullable<System.DateTime> DataPublicacao { get; set; }
        [Display(Name = "Autores")]
        public virtual ICollection<AutorModel> Autor { get; set; }
    }
}
  
