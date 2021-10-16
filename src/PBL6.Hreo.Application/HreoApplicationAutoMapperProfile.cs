using AutoMapper;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;

namespace PBL6.Hreo
{
    public class HreoApplicationAutoMapperProfile : Profile
    {
        public HreoApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */


            CreateMap<Test, TestResponse>(MemberList.None);
            CreateMap<TestRequest, Test>(MemberList.None);

            CreateMap<TestQuestion, TestQuestionResponse>(MemberList.None);
            CreateMap<TestQuestionRequest, TestQuestion>(MemberList.None);

            CreateMap<Post, PostResponse>(MemberList.None);
            CreateMap<PostRequest, Post>(MemberList.None);

            CreateMap<InvitationPost, InvitationPostResponse>(MemberList.None);
            CreateMap<InvitationPostRequest, InvitationPost>(MemberList.None);

            CreateMap<InterestedPost, InterestedPostResponse>(MemberList.None);
            CreateMap<InterestedPostRequest, InterestedPost>(MemberList.None);

            CreateMap<ApplicantPost, ApplicantPostResponse>(MemberList.None);
            CreateMap<ApplicantPostRequest, ApplicantPost>(MemberList.None);

        }
    }
}