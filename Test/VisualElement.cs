using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class VisualElement : IVisualElement
    {
        private IList<IVisualElement> _children;
        private IVisualElement _parent;
        private int _x;
        private int _y;
        private int _width;
        private int _height;

        protected VisualElement() { }

        protected VisualElement(int width, int height)
        {
            _width = width;
            _height = height;
        }

        protected VisualElement(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public IList<IVisualElement> Children
        {
            get 
            { 
                if(_children == null)
                {
                    _children = new List<IVisualElement>();
                }
                return _children;
            }
        }

        public IVisualElement Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public Point Location
        {
            get { return new Point(X, Y); }
        }

        public Size Size
        {
            get { return new Size(Width, Height); }
        }

        public Rectangle Region
        {
            get { return new Rectangle(Location, Size); }
        }

        public virtual void Move(int x, int y)
        {
            if (Parent != null)
            {
                _x = Parent.X + x;
                _y = Parent.Y + y;
            }
            foreach (IVisualElement child in Children)
            {
                child.Translate(x, y);
            }
        }

        public virtual void Translate(int x, int y)
        {
            _x += x;
            _y += y;
            foreach (IVisualElement child in Children)
            {
                child.Translate(x, y);
            }
        }

        public virtual void Dispose()
        {
            foreach (IVisualElement child in Children)
            {
                if (child != null)
                {
                    child.Dispose();
                }
            }
        }

        public abstract void Draw(Graphics graphics);

        public virtual void Add(IVisualElement child)
        {
            if(!Children.Contains(child))
            {
                child.Parent = this;
                Children.Add(child);
            }
        }

        public virtual void Remove(IVisualElement child)
        {
            if (Children.Contains(child))
            {
                child.Parent = null;
                Children.Remove(child);
                child.Dispose();
            }
        }

        //TODO!!!
        public virtual void Resize(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}
