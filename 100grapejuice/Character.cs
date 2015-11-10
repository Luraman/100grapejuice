using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  class Character
  {
    public Character(int maxHealth, int power, int defence, int evasion, int revival)
    {
      Power = new Stat(power);
      Defence = new Stat(defence);
      Evasion = new Stat(evasion);
      Revival = new Stat(revival);

      Health = new Bar(maxHealth, true);
      Health.Depleted += () => Dead();
    }

    public Bar Health { get; private set; }
    public Stat Power { get; private set; }
    public Stat Defence { get; private set; }
    public Stat Evasion { get; private set; }
    public Stat Revival { get; private set; }

    public event Action Dead;

    public void TakeDamage(int amount, out int overkill)
    {
      {
        Health.Change(-amount, out overkill);
      }
    }
  }
}
