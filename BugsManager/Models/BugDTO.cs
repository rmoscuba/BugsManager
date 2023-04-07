using BugsManager.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BugsManager.Models
{
    public class BugDTO
    {
        [Required]
        public Guid Project { get; set; }

        [Required]
        public Guid User { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public static BugDTO Map(Bug entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            BugDTO dto = new BugDTO();
            try
            {
                dto.User = entity.UserId;
                dto.Project = entity.ProjectId;
                dto.Description = entity.Description;
            }
            catch (Exception e)
            {
                string errMsg = String.Format("Error: {0} while mapping a Bug entity to DTO. Id: {1}.", e.Message, entity.Id);
                Console.WriteLine(errMsg);
            }

            return dto;
        }

        public static Bug Map(BugDTO entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            Bug bug = new Bug();
            try
            {
                bug.UserId = entity.User;
                bug.ProjectId = entity.Project;
                bug.Description = entity.Description;
            }
            catch (Exception e)
            {
                string errMsg = String.Format("Error: {0} while mapping a DTO to a Bug.", e.Message);
                Console.WriteLine(errMsg);
            }

            return bug;
        }
    }
}