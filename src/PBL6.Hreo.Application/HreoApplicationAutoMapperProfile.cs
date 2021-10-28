using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.ComponentModel;
using PBL6.Hreo.Models;
using PBL6.Hreo.Entities;
using FileService;

namespace PBL6.Hreo
{
    public class HreoApplicationAutoMapperProfile : Profile
    {
        public HreoApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Test, TestResponse>(MemberList.None)
                .ForMember(x => x.Language, y => y.MapFrom(y => y.Language.ToString()))
                .ForMember(x => x.Level, y => y.MapFrom(y => y.Level.ToString()));
            CreateMap<Test, TestWithQuestionResponse>(MemberList.None);

            CreateMap<TestRequest, Test>(MemberList.None)
                .ForMember(x => x.LimitTime, y => y.MapFrom(y => TimeSpan.FromMinutes(y.LimitTime)));
            CreateMap<TestWithQuestionRequest, Test>(MemberList.None)
                .ForMember(x => x.LimitTime, y => y.MapFrom(y => TimeSpan.FromMinutes(y.LimitTime)));

            CreateMap<TestWithQuestionRequest, TestRequest>(MemberList.None);

            CreateMap<TestQuestion, TestQuestionResponse>(MemberList.None);
            CreateMap<TestQuestionRequest, TestQuestion>(MemberList.None);

            CreateMap<Post, PostResponse>(MemberList.None)
                .ForMember(x => x.Language, y => y.MapFrom(y => y.Language.ToString()))
                .ForMember(x => x.Level, y => y.MapFrom(y => y.Level.ToString()))
                .ForMember(x => x.PostStatus, y => y.MapFrom(y => y.PostStatus.ToString()));

            CreateMap<PostRequest, Post>(MemberList.None);

            CreateMap<InvitationPost, InvitationPostResponse>(MemberList.None)
                .ForMember(x => x.InvitationPostStatus, y => y.MapFrom(y => y.InvitationPostStatus.ToString()));

            CreateMap<InvitationPostRequest, InvitationPost>(MemberList.None);

            CreateMap<InterestedPost, InterestedPostResponse>(MemberList.None)
                .ForMember(x => x.InterestedPostStatus, y => y.MapFrom(y => y.InterestedPostStatus.ToString()));

            CreateMap<InterestedPostRequest, InterestedPost>(MemberList.None);

            CreateMap<ApplicantPost, ApplicantPostResponse>(MemberList.None)
                .ForMember(x => x.ApplicantPostStatus, y => y.MapFrom(y => y.ApplicantPostStatus.ToString()));

            CreateMap<ApplicantPostRequest, ApplicantPost>(MemberList.None);
            CreateMap<SendTestToApplicationRequest, ApplicantPost>(MemberList.None);


            CreateMap<User, UserResponse>(MemberList.None)
                 .ForMember(x => x.Roles, map => map.MapFrom(p => p.UserRoles.Select(x => x.Role)));


            CreateMap<Role, RoleResponse>(MemberList.None);
            CreateMap<RoleRequest, Role>(MemberList.None);


            CreateMap<Company, CompanyResponse>(MemberList.None);
            CreateMap<CompanyRequest, Company>(MemberList.None);


            CreateMap<Branch, BranchResponse>(MemberList.None);
            CreateMap<BranchRequest, Branch>(MemberList.None);


            CreateMap<CompanyReview, CompanyReviewResponse>(MemberList.None);
            CreateMap<CompanyReviewRequest, CompanyReview>(MemberList.None);


            CreateMap<UserInformation, UserInformationResponse>(MemberList.None)
                .ForMember(x => x.Language, y => y.MapFrom(y => y.Language.ToString()))
                .ForMember(x => x.Level, y => y.MapFrom(y => y.Level.ToString()))
                .ForMember(x => x.Major, y => y.MapFrom(y => y.Major.ToString()));

            CreateMap<UserInformationRequest, UserInformation>(MemberList.None);

            // File
            CreateMap<FileInformation, FileInformationModel>(MemberList.None);
            CreateMap<CreateUpdateFileInformationDto, FileInformation>(MemberList.None);
        }
    }
}