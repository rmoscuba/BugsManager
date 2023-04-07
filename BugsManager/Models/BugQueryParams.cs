using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Models
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class BugQueryParams
    {
 
        [FromQuery(Name = "project_id")]
        public Guid? ProjectId { get; set; }

        [FromQuery(Name = "user_id")]
        public Guid? UserId { get; set; }

        [FromQuery(Name = "start_date")]
        public DateTime? StartDate { get; set; }

        [FromQuery(Name = "end_date")]
        public DateTime? EndDate { get; set; }
    }
}
