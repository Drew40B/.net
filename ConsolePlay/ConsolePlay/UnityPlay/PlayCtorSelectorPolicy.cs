using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Unity.ObjectBuilder.BuildPlan.Selection;
using Unity.Policy;

namespace ConsolePlay.UnityPlay
{
  public   class PlayCtorSelectorPolicy : DefaultUnityConstructorSelectorPolicy
    {
        protected override IDependencyResolverPolicy CreateResolver(ParameterInfo parameter)
        {
            return parameter.ParameterType == typeof(MyLog)
                ? new PlayResolverPolicy(parameter.Member.DeclaringType)
                : base.CreateResolver(parameter);
        }
    }
}
