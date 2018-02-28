using Ninject.Modules;
using Survey.Service;
using Survey.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DependencyInjection.DIConfig
{
    public class TopLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnswerService>().To<AnswerService>();
            Bind<IAspNetUserLoginService>().To<AspNetUserLoginService>();
            Bind<IAspNetUserService>().To<AspNetUserService>();
            Bind<IAspNetRoleService>().To<AspNetRoleService>();
            Bind<IPollService>().To<PollService>();
            Bind<IQuestionService>().To<QuestionService>();
        }
    }
}
