using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _100grapejuice.Exceptions;

namespace _100grapejuice
{
  class DiceManager : IBuffable<DiceManager>
  {
    public DiceManager(List<Dice> dices, int seed)
    {
      Dices = new List<Dice>();
      _buffManager = new BuffManager<DiceManager>();
      _random = new Random(seed);
    }
    public List<Dice> Dices { get; set; }
    private BuffManager<DiceManager> _buffManager { get; set; }
    private Random _random { get; set; }

    public int Roll()
    {
      if (Dices.Count == 0)
      {
        throw new SelectionHasNoOptionsException();
      }
      return Dices.Aggregate(0, (seed, dice) => seed += dice.Roll());
    }

    public void NewDice(List<Range> ranges)
    {
      Dices.Add(new Dice(ranges, _random.Next()));
    }

    public void ClearDices()
    {
      Dices = new List<Dice>();
    }

    public void Buff(IAppliable<DiceManager> buff, Action<Action> End)
    {
      _buffManager.NewBuff(buff, End);
    }

    public DiceManager ApplyBuffs()
    {
      return _buffManager.ApplyBuffs(this);
    }
  }
}