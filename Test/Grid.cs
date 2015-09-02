using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public struct GridOptions
    {
        public int Rows;
        public int Columns;
        public int PaddingX;
        public int PaddingY;
    }

    public class Grid : VisualElement
    {
        private GridOptions _options;
        private IList<Rectangle> _cells;

        public Grid(int x, int y, int width, int height, GridOptions options)
            :base(x, y, width, height)
        {
            _options = options;
            _cells = CalculateCells(width, height, _options);
        }

        public IList<Rectangle> Cells
        {
            get { return _cells; }
        }

        protected IList<Rectangle> CalculateCells(int width, int height, GridOptions options)
        {
            List<Rectangle> cells = new List<Rectangle>();

            int cellCount = options.Rows * options.Columns;

            int cellWidth = (Width - ((options.Rows + 1) * options.PaddingX)) / options.Rows;
            int cellHeight = (Height - ((options.Columns + 1) * options.PaddingY)) / options.Columns;

            int pX = options.PaddingX;
            int pY = options.PaddingY;

            for (int v = 0; v < options.Columns; v++)
            {
                for (int u = 0; u < options.Rows; u++)
                {
                    Rectangle cell = new Rectangle(pX, pY, cellWidth, cellHeight);
                    cells.Add(cell);
                    pX += cellWidth + options.PaddingX;
                }
                pX = options.PaddingX;
                pY += cellHeight + options.PaddingY;
            }
            return cells;
        }

        public override void Draw(Graphics graphics)
        {
            foreach(var c in Children)
            {
                if (c != null)
                {
                    c.Draw(graphics);
                }
            }
        }

        public override void Add(IVisualElement child)
        {
            base.Add(child);
            Rectangle cell = _cells[Children.Count - 1];
            Children.Last().Move(cell.X, cell.Y);
            Children.Last().Resize(cell.Width, cell.Height);
        }
    }
}
