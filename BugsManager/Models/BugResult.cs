using BugsManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugsManager.Models
{
    public class BugResult
    {
        public List<BugResultDTO> bugs { get; set; }
    }
}