using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick
{
    public interface ISubscribe
    {
        void SubscribeHandler(bool subscribe, IKeyboardMouseEvents KMEvents);
    }
}
