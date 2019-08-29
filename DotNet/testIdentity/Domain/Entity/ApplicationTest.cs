using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ApplicationTest
    {
        [Key]
        public int Id { get; set; }
        public Application Application { get; set; }
        public Test Test { get; set; }
        public int Note { get; set; }
    }
}
