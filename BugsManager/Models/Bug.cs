using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bug")]
    public class Bug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

    }
}
