using System;
using System.Collections.Generic;
using System.Text;

namespace TalentVN.ApplicationCore.Entities
{
    public class SRank: BaseEntity
    {
        public SRank()
        {
            SchoolRankItems = new HashSet<SRankItem>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<SRankItem> SchoolRankItems { get; set; }
    }
}
