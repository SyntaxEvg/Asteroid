using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
    internal interface ICollision
    {
        bool Collision(ICollision collision);
        Rectangle rectengle { get; }
    }
}
