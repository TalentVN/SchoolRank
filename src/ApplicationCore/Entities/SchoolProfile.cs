using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TalentVN.ApplicationCore.Entities
{
    public class SchoolProfile : BaseEntity
    {
        public SchoolProfile()
        {
            Specializeds = new HashSet<Specialized>();
            EducationPrograms = new HashSet<EducationProgram>();
        }

        public string Id { get; set; }

        [Display(Name = "School Name")]
        public string Name { get; set; }

        public string Detail { get; set; }

        public string Localtion { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Specialized> Specializeds { get; set; }

        public virtual ICollection<EducationProgram> EducationPrograms { get; set; }
    }
}
