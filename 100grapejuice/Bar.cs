using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  public class Bar
  {
    public Bar(int _max, bool full)
    {
      Max = _max;
      if (full) {
        Current = Max;
      }
      else
      {
        Current = 0;
      }
    }

    public event Action Filled;
    public event Action Depleted;

    public int Current { get; private set; }
    public int Max { get; private set; }

    public bool IsFull()
    {
      return Current == Max;
    }

    public bool IsEmpty()
    {
      return Current == 0;
    }

    public void Fill() {
      Current = Max;
      Program.CallEvent(Filled);
    }

    public void Empty()
    {
      Current = 0;
      Program.CallEvent(Depleted);
    }

    public void Change(int amount, out int walled)
    {
      {
        Current += amount;
        wall(out walled);
      }
    }

    public void Set(int amount, out int walled)
    {
      Current = amount;
      wall(out walled);
    }

    private void wall(out int walled)
    {
      if (Current <= 0)
      {
        walled = Current;
        Empty();
      }
      else if (Current >= Max)
      {
        walled = Current;
        Fill();
      }
      else
      {
        walled = 0;
      }
    }
  }
}
