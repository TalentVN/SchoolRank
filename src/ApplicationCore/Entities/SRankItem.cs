using System;
using System.Collections.Generic;
using System.Text;

namespace TalentVN.ApplicationCore.Entities
{
    public class SRankItem: BaseEntity
    {
        public string Id { get; set; }

        public int Rank { get; set; }

        public string SchoolProfileId { get; set; }

        public SchoolProfile SchoolProfile { get; set; }

        public string SRankId { get; set; }

        public SRank SRank { get; set; }
    }
}
