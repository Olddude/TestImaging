using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SimpleFrame : VisualElement
    {
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(Color.Black, 2.0f), Region);
        }
    }
}
