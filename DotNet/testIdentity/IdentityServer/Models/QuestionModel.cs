using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Models
{
    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }
        public String Subject { get; set; }
        public String choice1 { get; set; }
        public String choice2 { get; set; }
        public String choice3 { get; set; }
        public String ValidChoise { get; set; }
        public string TypeTest { get; set; }
        public int? TestId { get; set; }
        [ForeignKey("TestId")]
        public TestModel Test { get; set; }

        public IEnumerable<SelectListItem> TestL { get; set; }

    }
}