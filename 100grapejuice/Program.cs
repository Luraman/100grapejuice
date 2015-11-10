using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  class Program
  {
    public static void CallEvent(Action _event)
    {
      if (_event != null)
      {
        _event();
      }
    }

    private static void Main(string[] args)
    {
      Character Luraman = new Character(5, 2, -1, -1, 5);

      Console.WriteLine(Luraman.Power.Get());

      Luraman.Power.Buff(3, _event => Luraman.Dead += _event);

      Console.WriteLine(Luraman.Power.Get());

      Action DeathNote = () => Console.WriteLine("u r ded");

      Luraman.Dead += DeathNote;

      int _;
      Luraman.TakeDamage(6, out _);

      Console.WriteLine(Luraman.Power.Get());

      Console.ReadKey();
    }
  }
}