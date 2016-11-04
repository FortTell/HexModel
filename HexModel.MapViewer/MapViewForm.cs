using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HexModel.Generators;

namespace HexModel.MapViewer
{
    public partial class MapViewForm : Form
    {
        int diameter = 30;
        
        public MapViewForm()
        {
            InitializeComponent();
            
            Size = new Size(500, 520);

            DoubleBuffered = true;

            var mapSizeBox = new ComboBox();

            for (var size = 4; size < 20; ++size)
                mapSizeBox.Items.Add(2*size);

            mapSizeBox.SelectedIndex = 3;

            var generateButton = new Button { Text = "Generate!", Location = new Point(150, 0) };

            Map map = null;

            var gen = new HommMapGenerator(new DiagonalMazeGenerator());

            generateButton.Click += (s, e) =>
            {
                var mapSize = (int)mapSizeBox.SelectedItem;
                map = gen.GenerateMap(mapSize);
                this.Invalidate();
            };

            Controls.Add(mapSizeBox);
            Controls.Add(generateButton);

            Paint += (s, e) => {
                if (map != null)
                    foreach (var tile in map)
                        DrawTile(tile, e.Graphics);
            };
        }

        private void DrawTile(Tile cell, Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var brush = new SolidBrush(GetColor(cell.tileObject));
            var dy = cell.location.X % 2 * diameter / 2;
            g.FillEllipse(brush, (cell.location.X+1) * diameter, (1 + cell.location.Y) * diameter + dy, diameter, diameter);
        }

        private Color GetColor(TileObject obj)
        {
            if (obj == null)
                return Color.LightGray;
            if (obj is Impassable)
                return Color.DarkSlateBlue;

            return Color.Pink;
        }
    }
}
