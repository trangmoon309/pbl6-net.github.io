using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class SearchInvitePostRequest
    {
        public InvitationPostStatus? Status { get; set; }
        
        public Level? Level { get; set; }
    }
}
