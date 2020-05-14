using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSchool_API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [NotMapped]
        public List<Aluno> Alunos { get; set; }
    }
}