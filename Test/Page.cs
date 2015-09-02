using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Page
    {
        private int _width;
        private int _height;
        private string _savingFullName;
        private IList<IVisualElement> _elements;

        public Page(int width, int height, string savingFullName)
        {
            _width = width;
            _height = height;
            _savingFullName = savingFullName;
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public string SavingFullName
        {
            get { return _savingFullName; }
        }

        public IList<IVisualElement> Elements
        {
            get 
            { 
                if(_elements == null)
                {
                    _elements = new List<IVisualElement>();
                }
                return _elements; 
            }
            set { _elements = value; }
        }

        public void Create()
        {
            using(Bitmap bitmap = new Bitmap(Width, Height))
            {
                using(Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Width, Height));
                    //...
                    foreach(IVisualElement ve in Elements)
                    {
                        if(ve != null)
                        {
                            ve.Draw(graphics);
                        }
                    }
                }
                bitmap.Save(SavingFullName, ImageFormat.Jpeg);
            }
        }
    }
}
