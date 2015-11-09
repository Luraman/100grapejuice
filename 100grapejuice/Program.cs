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

    static void Main(string[] args)
    {
      Character Luraman = new Character(5);

      Action DeathNote = () => Console.WriteLine("u r ded");

      Luraman.Dead += DeathNote;

      int _;
      Luraman.Damage(-2, out _);
      Luraman.Damage(5, out _);

      Console.ReadKey();
    }
  }
}
