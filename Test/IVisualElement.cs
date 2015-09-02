using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IVisualElement : IDisposable
    {
        IVisualElement Parent { get; set; }
        IList<IVisualElement> Children { get; }

        int X { get; }
        int Y { get; }
        int Width { get; }
        int Height { get; }
        Point Location { get; }
        Size Size { get; }
        Rectangle Region { get; }

        void Add(IVisualElement child);
        void Remove(IVisualElement child);

        void Move(int x, int y);
        void Translate(int x, int y);
        void Resize(int width, int height);

        void Draw(Graphics graphics);
    }
}
