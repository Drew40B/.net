using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity;

namespace ConsolePlay.UnityPlay
{
  public   class UnityPlay : IPlayable
    {
        public bool Play()
        {
            //based upon http://stackoverflow.com/questions/6846342/how-to-inject-log4net-ilog-implementations-using-unity-2-0

            var container = new UnityContainer();
            container.AddNewExtension<PlayExtension>();

            container.RegisterType<MyClass>();

            var my = container.Resolve<MyClass>();
            my.WriteLog();

            return true;
        }
    }
}
