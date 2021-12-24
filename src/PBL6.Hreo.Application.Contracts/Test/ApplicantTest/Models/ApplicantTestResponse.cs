﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class ApplicantTestResponse : CreationAuditedEntityDto<Guid>
    {
        public Guid ApplicantId { get; set; }

        public Guid PostId { get; set; }

        public Guid TestId { get; set; }

        public double Result { get; set; }

        public PostResponse Post { get; set; }

        public TestResponse Test { get; set; }

        public UserInformationResponse Applicant { get; set; }

        public List<ApplicanTestQuestionResponse> ApplicantTestQuestions { get; set; }
    }
}
