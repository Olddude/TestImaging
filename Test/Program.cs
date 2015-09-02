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
            Grid grid = new Grid(20, 20, 1000, 1000, new GridOptions { Columns = 5, Rows = 5, PaddingX = 10, PaddingY = 10 });
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
            p.Create();

            Console.ReadKey();
        }
    }
}
