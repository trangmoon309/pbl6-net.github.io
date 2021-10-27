using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class TestWithQuestionRequest
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public Language Language { get; set; }

        public Level Level { get; set; }

        // Số phút
        public int LimitTime { get; set; }

        public List<TestQuestionRequest> TestQuestions { get; set; }
    }
}
