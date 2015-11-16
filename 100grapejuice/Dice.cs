using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _100grapejuice.Exceptions;

namespace _100grapejuice
{
  class Dice
  {
    public Dice(List<Range> ranges, int seed)
    {
      _ranges = ranges;
      _random = new Random(seed);
    }

    private List<Range> _ranges { get; set; }
    private Random _random { get; set; }

    public int Roll()
    {
      int possibleOutcomes = 0;
      foreach (Range range in _ranges) {
        possibleOutcomes += range.Length;
      }
      if (possibleOutcomes == 0)
      {
        throw new SelectionHasNoOptionsException();
      }
      int pivot = _random.Next(possibleOutcomes);
      Range chosenRange = _ranges.SkipWhile((range) => (pivot -= range.Length) >= 0).First();
      return _random.Next(chosenRange.Min, chosenRange.Max + 1);
    }
  }
}
