using System;

using Unity.Builder;
using Unity.Policy;

namespace ConsolePlay.UnityPlay
{
   public class PlayResolverPolicy : IDependencyResolverPolicy
   {
       private readonly Type m_type;

       public PlayResolverPolicy(Type myType)
       {
           m_type = myType;
       }


       public object Resolve(IBuilderContext context)
       {
           return new MyLog(m_type);
       }
   }
}
