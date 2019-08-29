using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public String Subject { get; set; }
        public String choice1 { get; set; }
        public String choice2 { get; set; }
        public String choice3 { get; set; }
        public String ValidChoise { get; set; }

        public int? TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }

    }
}
