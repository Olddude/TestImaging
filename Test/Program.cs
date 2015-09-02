using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static string savingPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\test.jpg";

        static void Main(string[] args)
        {
            GridOptions options = new GridOptions()
            {
                Columns = 5,
                Rows = 6,
                PaddingX = 10,
                PaddingY = 25
            };

            Grid grid = new Grid(20, 20, 1000, 1000, options);
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());
            grid.Add(new SimpleFrame());

            foreach(var c in grid.Cells)
            {
                Console.WriteLine(c.ToString());
            }

            Page p = new Page(1500, 1500, savingPath);
            p.Elements.Add(grid);
            p.Elements.Last().Move(100, 100);
            p.Create();
            Console.WriteLine("finished...");
        }
    }
}
