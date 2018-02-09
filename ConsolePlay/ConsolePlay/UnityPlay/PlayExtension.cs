using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Extension;
using Unity.Policy;

namespace ConsolePlay.UnityPlay
{
   public  class PlayExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Policies.SetDefault(typeof(IConstructorSelectorPolicy),new PlayCtorSelectorPolicy());
        }
    }
}
