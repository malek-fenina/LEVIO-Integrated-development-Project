using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Term
    {
        public int termId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date_Fin { get; set; }

        public List<Note> Notes { get; set; }
    }
}