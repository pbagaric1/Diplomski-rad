using AutoMapper;
using Survey.Model;
using Survey.Model.Common;
using Survey.MVC_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MVC_WebApi.AutoMapperConfig
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AspNetUserView, IAspNetUserDomain>().ReverseMap();
            CreateMap<AspNetUserView, AspNetUserDomain>().ReverseMap();

            CreateMap<AspNetRoleView, IAspNetRoleDomain>().ReverseMap();
            CreateMap<AspNetRoleView, AspNetRoleDomain>().ReverseMap();
  
            CreateMap<AspNetUserClaimView, IAspNetUserClaimDomain>().ReverseMap();
            CreateMap<AspNetUserClaimView, AspNetUserClaimDomain>().ReverseMap();

            CreateMap<AspNetUserLoginView, IAspNetUserLoginDomain>().ReverseMap();
            CreateMap<AspNetUserLoginView, AspNetUserLoginDomain>().ReverseMap();

            CreateMap<AnswerView, IAnswerDomain>().ReverseMap();
            CreateMap<AnswerView, AnswerDomain>().ReverseMap();

            CreateMap<PollView, IPollDomain>().ReverseMap();
            CreateMap<PollView, PollDomain>().ReverseMap();

            CreateMap<PollTypeView, IPollTypeDomain>().ReverseMap();
            CreateMap<PollTypeView, PollTypeDomain>().ReverseMap();

            CreateMap<QuestionView, IQuestionDomain>().ReverseMap();
            CreateMap<QuestionView, QuestionDomain>().ReverseMap();

        }
    }
}