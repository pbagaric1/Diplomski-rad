using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Survey.DAL.Common;
using Survey.DAL.Models;
using Survey.Model.Common;
using Survey.Model;

namespace Survey.DependencyInjection.DIConfig
{
    public class BottomLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<ISurveyContext>().To<SurveyDatabaseContext>();

            Bind<IAspNetUserDomain>().To<AspNetUserDomain>();
            Bind<IAspNetRoleDomain>().To<AspNetRoleDomain>();
            Bind<IAspNetUserClaimDomain>().To<AspNetUserClaimDomain>();
            Bind<IAspNetUserLoginDomain>().To<AspNetUserLoginDomain>();
            Bind<IAnswerDomain>().To<AnswerDomain>();
            Bind<IQuestionDomain>().To<QuestionDomain>();
            Bind<IPollDomain>().To<PollDomain>();

        }
    }
}
