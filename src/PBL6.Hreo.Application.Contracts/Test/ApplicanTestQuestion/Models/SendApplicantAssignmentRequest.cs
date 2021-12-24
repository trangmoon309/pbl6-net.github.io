using System;
using System.Collections.Generic;
using System.Text;

namespace PBL6.Hreo.Models
{
    public class SendApplicantAssignmentRequest
    {
        public Guid ApplicantId { get; set; }

        public Guid PostId { get; set; }

        public Guid TestId { get; set; }

        public List<TestAssignmentRequest> TestAssignments { get; set; }
    }

    public class TestAssignmentRequest
    {
        public Guid TestQuestionId { get; set; }

        public int Choose { get; set; }
    }
}
