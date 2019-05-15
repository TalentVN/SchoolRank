using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TalentVN.ApplicationCore.Entities
{
    public class Article: BaseEntity
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public string PostedBy { get; set; }

        public DateTime CreatedDate { get; } = DateTime.UtcNow;
    }
}
