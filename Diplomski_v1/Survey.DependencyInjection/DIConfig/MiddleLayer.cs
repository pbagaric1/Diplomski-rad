using Ninject.Modules;
using Survey.Repository;
using Survey.Repository.Common;
using Survey.Repository.Common.IGenericRepository;
using Survey.Repository.Common.IRepositories;
using Survey.Repository.GenericRepository;
using Survey.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DependencyInjection.DIConfig
{
    public class MiddleLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            Bind<IGenericRepository>().To<GenericRepository>();

            Bind<IAnswerRepository>().To<AnswerRepository>();
            Bind<IAspNetUserLoginRepository>().To<AspNetUserLoginRepository>();
            Bind<IAspNetUserRepository>().To<AspNetUserRepository>();
            Bind<IPollRepository>().To<PollRepository>();
            Bind<IPollTypeRepository>().To<PollTypeRepository>();
            Bind<IQuestionRepository>().To<QuestionRepository>();
        }
    }
}
