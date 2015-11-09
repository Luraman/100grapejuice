using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100grapejuice
{
  class Character
  {
    public Character(int maxHealth)
    {
      Health = new Bar(maxHealth, true);
      Health.Depleted += () => Dead();
    }

    public Bar Health { get; private set; }

    public event Action Dead;

    public void Damage(int amount, out int walled)
    {
      {
        Health.Change(-amount, out walled);
      }
    }
  }
}
