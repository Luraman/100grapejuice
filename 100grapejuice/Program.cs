using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  class Program
  {
    private static void Main(string[] args)
    {
      DiceManager dices = new DiceManager(new List<Dice>(){}, new Random().Next());
      Buff<DiceManager> AddD10 = new Buff<DiceManager>((client) => { client.NewDice(new List<Range>() { new Range(1, 6) }); });

      for (int i = 0; i < 10; i++)
      {
        dices.Buff(AddD10, (client) => { });
      }
      DiceManager buffeddices = dices.ApplyBuffs();
      for (int i = 0; i < 100; i++)
      {
        Console.Write(String.Format("{0} ", buffeddices.Roll()));
      }


      Console.ReadKey();
    }
  }
}