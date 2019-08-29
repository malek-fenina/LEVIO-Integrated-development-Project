using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    //public enum TypeTest { Technical, Francais }
    public class Test
    {
    [Key]
    public int Id { get; set; }
    public String TypeTest { get; set; }
    //public TypeTest TypeTest { get; set; }
    public String Version { get; set; }
    public List<Question> ListQuestion { get; set; }
    //public List<ApplicationTest> ListApllication { get; set; }
    }
}
