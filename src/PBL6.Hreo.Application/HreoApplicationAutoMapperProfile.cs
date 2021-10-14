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
        }
    }
}