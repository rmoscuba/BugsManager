using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Project")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(128)]
        [Required]
        public string Name { get; set; }

        [StringLength(256)]
        public string Description  { get; set; }

    }
}
