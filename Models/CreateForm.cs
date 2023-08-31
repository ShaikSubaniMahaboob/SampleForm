using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleForm.Models
{
    public class CreateForm
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter username")]
        public string Name { get; set; }
        public  String Gender { get; set; }
        public int Skills { get; set; }
        public string Description { get; set; }
        public string Isverify { get; set; }


    }
}
