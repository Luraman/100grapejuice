using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  class Stat
  {
    public Stat(int _value)
    {
      value = _value;
      buffs = new List<StatBuff>();
      mod = 0;
    }

    private int value;
    private int mod;
    private List<StatBuff> buffs;

    public void Buff(int mod, Action<Action> onEnd)
    {
      buffs.Add(new StatBuff(this, mod, onEnd));
      calculateMod();
    }

    private void UnBuff(StatBuff buff)
    {
      buffs.Remove(buff);
      calculateMod();
    }

    public int Get()
    {
      return value + mod;
    }

    private void calculateMod()
    {
      mod = buffs.Aggregate(0, (seed, buff) => buff.Apply(seed));
    }

    private class StatBuff
    {
      public StatBuff(Stat statToBuff, int mod, Action<Action> endEventBinder)
      {
        Mod = mod;
        endEventBinder(() => statToBuff.UnBuff(this));
      }

      private int Mod;

      public int Apply(int seed)
      {
        return seed + Mod;
      }
    }
  }
}