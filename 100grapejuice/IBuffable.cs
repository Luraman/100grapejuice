using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventLinker = System.Action<System.Action>;

namespace _100grapejuice
{
  public interface IBuffable<T>
  {
    void Buff(IAppliable<T> buff, EventLinker End);
    T ApplyBuffs();
  }
}
