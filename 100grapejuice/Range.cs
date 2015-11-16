using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  class Range
  {
    public Range(int beginning, int end)
    {
      if (beginning > end)
      {
        Min = end;
        Max = beginning;
      }
      else
      {
        Min = beginning;
        Max = end;
      }
    }

    public int Min {get; private set;}
    public int Max {get; private set;}
    public int Length
    {
      get { return Max - Min + 1; }
    }
  }
}