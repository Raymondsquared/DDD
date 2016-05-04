using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public class NinjectHelper
    {
        public void CustomBind<TInterface, TAbstractOrInterface, TInjectedInto>(string name = "")
        {

            var kernel = new StandardKernel();

            var types =
                Assembly.GetAssembly(typeof(TInterface))
                    .GetTypes()
                    .Where
                    (
                        t =>
                            t.IsClass &&
                            !t.IsAbstract &&
                            !t.IsInterface &&
                            (
                                (typeof(TAbstractOrInterface).IsAbstract && t.IsSubclassOf(typeof(TAbstractOrInterface))) ||
                                (typeof(TAbstractOrInterface).IsInterface && (t.GetInterfaces().Contains(typeof(TAbstractOrInterface))))
                            )
                    );

            foreach (Type type in types)
            {
                if (string.IsNullOrEmpty(name))
                {
                    kernel.Bind<TInterface>()
                        .To(type)
                        .WhenInjectedInto<TInjectedInto>();
                }
                else
                {
                    kernel.Bind<TInterface>()
                        .To(type)
                        .WhenInjectedInto<TInjectedInto>()
                        .Named(name);
                }
            }
        }
    }
}
