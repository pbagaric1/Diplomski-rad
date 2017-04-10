using AutoMapper;
using Survey.DAL.Models;
using Survey.Model;
using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DependencyInjection.AutoMapperConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<AspNetUser, IAspNetUserDomain>().ReverseMap();
            CreateMap<AspNetUser, AspNetUserDomain>().ReverseMap();

            CreateMap<AspNetRole, IAspNetRoleDomain>().ReverseMap();
            CreateMap<AspNetRole, AspNetRoleDomain>().ReverseMap();

            CreateMap<AspNetUserClaim, IAspNetUserClaimDomain>().ReverseMap();
            CreateMap<AspNetUserClaim, AspNetUserClaimDomain>().ReverseMap();

            CreateMap<AspNetUserLogin, IAspNetUserLoginDomain>().ReverseMap();
            CreateMap<AspNetUserLogin, AspNetUserLoginDomain>().ReverseMap();

            CreateMap<Poll, IPollDomain>().ReverseMap();
            CreateMap<Poll, PollDomain>().ReverseMap();

            CreateMap<PollType, IPollTypeDomain>().ReverseMap();
            CreateMap<PollType, PollTypeDomain>().ReverseMap();

            CreateMap<Question, IQuestionDomain>().ReverseMap();
            CreateMap<Question, QuestionDomain>().ReverseMap();

            CreateMap<Answer, IAnswerDomain>().ReverseMap();
            CreateMap<Answer, AnswerDomain>().ReverseMap();
        }
    }
}
