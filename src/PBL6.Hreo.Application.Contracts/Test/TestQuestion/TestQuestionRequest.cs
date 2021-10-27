using System;
using System.Collections.Generic;
using System.Text;

namespace PBL6.Hreo.Models
{
    public class TestQuestionRequest
    {
        public Guid TestId { get; set; }

        public int OrderIndex { get; set; }

        public string Content { get; set; }

        public string Answers { get; set; }

        public int Result { get; set; }
    }
}
