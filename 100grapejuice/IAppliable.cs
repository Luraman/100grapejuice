using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  public interface IAppliable<T>
  {
    void Apply(T client);
  }
}
