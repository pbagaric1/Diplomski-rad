using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Survey.DAL.Common;
using Survey.DAL.Models;

namespace Survey.DependencyInjection.DIConfig
{
    public class BottomLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<ISurveyContext>().To<SurveyDatabaseContext>();

        }
    }
}
