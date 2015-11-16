using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  class Buff<T> : IAppliable<T> where T : IBuffable<T>
  {
    public Buff(Action<T> change)
    {
      _change = change;
    }
    private Action<T> _change { get; set; }

    public void Apply(T client)
    {
      _change(client);
    }
  }
}