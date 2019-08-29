using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityServer.Models
{
    public class TestModel
    {
        //public enum TypeTest { Technical, Francais }
        [Key]
        public int Id { get; set; }
        public String TypeTest { get; set; }
        //public TypeTest typetest { get; set; }
        public String Version { get; set; }
        public List<QuestionModel> ListQuestion { get; set; }
        // public List<ApplicationTest> ListApllication { get; set; }
    }
}