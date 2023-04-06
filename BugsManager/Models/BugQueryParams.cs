using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BugQueryParams
    {
        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
