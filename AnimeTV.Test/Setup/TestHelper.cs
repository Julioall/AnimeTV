using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTV.Test.TestSetup
{
    public abstract class TestHelper : IDisposable
    {
        protected ServiceProvider ServiceProvider;

        protected TestHelper()
        {
            ServiceProvider = GetServiceCollection().BuildServiceProvider();
        }

        private IServiceCollection GetServiceCollection()
        {
            var servicos = new ServiceCollection();
            InjectionModule.BindService(servicos);
            return servicos;
        }

        public virtual void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
