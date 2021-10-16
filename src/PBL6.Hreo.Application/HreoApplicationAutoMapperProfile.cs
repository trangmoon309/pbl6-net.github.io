using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.ComponentModel;
using PBL6.Hreo.Models;
using PBL6.Hreo.Entities;

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


            CreateMap<User, UserResponse>(MemberList.None)
                 .ForMember(x => x.Roles, map => map.MapFrom(p => p.UserRoles.Select(x => x.Role)));


            CreateMap<Role, RoleResponse>(MemberList.None);
            CreateMap<RoleRequest, Role>(MemberList.None);
        }
    }
}