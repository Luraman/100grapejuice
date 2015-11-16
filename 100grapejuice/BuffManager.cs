using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventLinker = System.Action<System.Action>;

namespace _100grapejuice
{
  class BuffManager<T> where T : IBuffable<T>
  {
    public BuffManager()
    {
      _buffs = new List<IAppliable<T>>();
    }

    private List<IAppliable<T>> _buffs;

    public void NewBuff(IAppliable<T> buff, EventLinker End)
    {
      _buffs.Add(buff);
      End(() => _buffs.Remove(buff));
    }

    public T ApplyBuffs(T client)
    {
      T clientcopy = client; //Needs to make a new copy D:
      _buffs.ForEach((buff) => buff.Apply(clientcopy));
      return clientcopy;
    }
  }
}