using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PBL6.Hreo.Common.Enum
{
    public class Enum
    {
        public enum Language
        {
            [Description("Net")]
            NET = 0,

            [Description("Node JS")]
            NODE = 1,

            [Description("Java")]
            JAVA = 2,

            [Description("Php")]
            PHP = 3,

            [Description("Ruby")]
            RUBY = 4,

            [Description("React JS")]
            REACTJS = 5,

            [Description("Angular JS")]
            ANGULARJS = 6,
        }

        public enum Level
        {
            [Description("Intern")]
            INTERN = 0,

            [Description("Fresher")]
            FRESHER = 1,

            [Description("Junior")]
            JUNIOR = 2,

            [Description("Middle")]
            MIDDLE = 3,

            [Description("Senior")]
            SENIOR = 4,
        }

        public enum PostStatus
        {
            [Description("Available")]
            AVAILABLE = 0,

            [Description("Not Available")]
            UNAVAILABLE = 1,
        }

        public enum InvitationPostStatus
        {
            [Description("Available")]
            NOT_INVITED_YET = 0,

            [Description("Not Available")]
            WAITING = 1,

            [Description("Appept")]
            ACCEPT = 2,

            [Description("Decline")]
            DECLINE = 3,
        }

        public enum InterestedPostStatus
        {
            [Description("Interest")]
            INTERESTED = 0,

            [Description("Submit")]
            SUBMITTED = 1,
        }

        public enum ApplicationStatus
        {
            [Description("Open")]
            OPEN = 0,

            [Description("In progress test")]
            IN_PROGRESS_TEST = 1,

            [Description("Done")]
            DONE = 2,
        }
    }
}
