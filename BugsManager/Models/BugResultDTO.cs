using BugsManager.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BugsManager.Models
{
    public class BugResultDTO
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public string Project { get; set; }

        public DateTime CreationDate { get; set; }

        public static BugResultDTO Map(Bug entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            BugResultDTO dto = new BugResultDTO();
            try
            {
                dto.Id = entity.Id;
                dto.Description = entity.Description;
                dto.UserName = entity.User.Name;
                dto.Project = entity.Project.Name;
                dto.CreationDate = entity.CreationDate;
            }
            catch (Exception e)
            {
                string errMsg = String.Format("Error: {0} while mapping a Bug entity to Bug result DTO. Id: {1}.", e.Message, entity.Id);
                Console.WriteLine(errMsg);
            }

            return dto;
        }
    }
}