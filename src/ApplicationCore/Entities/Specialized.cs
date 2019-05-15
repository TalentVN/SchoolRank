using System;
using System.Collections.Generic;
using System.Text;

namespace TalentVN.ApplicationCore.Entities
{
    public class Specialized : BaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
