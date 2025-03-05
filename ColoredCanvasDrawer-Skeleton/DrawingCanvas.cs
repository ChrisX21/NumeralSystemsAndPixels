namespace ColoredCanvasDrawer
{
    public class DrawingCanvas : ICloneable
    {
        private byte[][] pixels;

        public DrawingCanvas(int width, int height)
        {
            if (width < 32 || width > 1024)
            {
                throw new ArgumentException("Invalid width! Width should be in range [32 ... 1024].");
            }

            if (height < 32 || height > 1024)
            {
                throw new ArgumentException("Invalid height! Height should be in range [32 ... 1024].");
            }

            int widthColor = width * 3;
            this.pixels = new byte[height][];
            for (int row = 0; row < height; row++)
            {
                this.pixels[row] = new byte[widthColor];
            }

            this.FillAllPixels();
        }

        public int Height => this.pixels.Length;

        public int Width => this.pixels[0].Length;

        public void FillAllPixels()
        {
            byte mask = 0;
            mask = (byte)~mask;

            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    this.pixels[row][col] = mask;
                }
            }
        }

        public void InvertAllPixels()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    this.pixels[row][col] = (byte)~this.pixels[row][col];
                }
            }
        }

        public Color GetPixel(int row, int col)
        {
            CheckBounds(row, col);

            int pixelIndex = col * 3;
            byte red = this.pixels[row][pixelIndex];
            byte green = this.pixels[row][pixelIndex + 1];
            byte blue = this.pixels[row][pixelIndex + 2];

            return Color.FromArgb(red, green, blue);
        }

        public void SetPixel(int row, int col, Color color)
        {
            CheckBounds(row, col);

            int pixelIndex = col * 3;
            this.pixels[row][pixelIndex] = color.R;
            this.pixels[row][pixelIndex + 1] = color.G;
            this.pixels[row][pixelIndex + 2] = color.B;
        }

        public void DrawHorizontalLine(int row, int startCol, int endCol, Color color)
        {
            for (int col = startCol; col < endCol; col++)
            {
                this.SetPixel(row, col, color);
            }
        }

        public void DrawVerticalLine(int col, int startRow, int endRow, Color color)
        {
            for (int row = startRow; row < endRow; row++)
            {
                this.SetPixel(row, col, color);
            }
        }

        public void DrawDiagonalLine(int startCol, int startRow, int endCol, int endRow, Color color)
        {
            int dx = Math.Abs(endCol - startCol);
            int dy = Math.Abs(endRow - startRow);

            if (dy <= dx)
            {
                if (startCol > endCol)
                {
                    PlotLineLow(endCol, endRow, startCol, startRow, color);
                }
                else
                {
                    PlotLineLow(startCol, startRow, endCol, endRow, color);
                }
            }
            else
            {
                if (startRow > endRow)
                {
                    PlotLineHigh(endCol, endRow, startCol, startRow, color);
                }
                else
                {
                    PlotLineHigh(startCol, startRow, endCol, endRow, color);
                }
            }
        }


        public void DrawRectangle(int startRow, int startCol, int endRow, int endCol, Color color)
        {
            this.DrawHorizontalLine(startRow, startCol, endCol, color);
            this.DrawHorizontalLine(endRow, startCol, endCol, color);
            this.DrawVerticalLine(startCol, startRow, endRow, color);
            this.DrawVerticalLine(endCol, startRow, endRow, color);
        }

        public void DrawTriangle(int startRow, int startCol, int endRow, int endCol, Color color)
        {
            int midRow = (startRow + endRow) / 2;
            int midCol = (startCol + endCol) / 2;

            DrawDiagonalLine(startCol, startRow, midCol, endRow, color);
            DrawDiagonalLine(midCol, endRow, endCol, startRow, color);
            DrawDiagonalLine(endCol, startRow, startCol, startRow, color);
        }



        private void PlotLineLow(int startCol, int startRow, int endCol, int endRow, Color color)
        {
            int dx = endCol - startCol;
            int dy = endRow - startRow;
            int yi = 1;

            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }

            int D = 2 * dy - dx;
            int y = startRow;

            for (int x = startCol; x <= endCol; x++)
            {
                SetPixel(y, x, color);
                if (D > 0)
                {
                    y += yi;
                    D -= 2 * dx;
                }
                D += 2 * dy;
            }
        }


        private void PlotLineHigh(int startCol, int startRow, int endCol, int endRow, Color color)
        {
            int dx = endCol - startCol;
            int dy = endRow - startRow;
            int xi = 1;

            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }

            int D = 2 * dx - dy;
            int x = startCol;

            for (int y = startRow; y <= endRow; y++)
            {
                SetPixel(y, x, color);
                if (D > 0)
                {
                    x += xi;
                    D -= 2 * dy;
                }
                D += 2 * dx;
            }
        }



        private void CheckBounds(int height, int width)
        {
            int maxWidth = this.Width * 3 - 1;
            if (width < 0 || width > maxWidth)
            {
                throw new ArgumentException($"Invalid width! Width should be in range [0 ... {maxWidth}].");
            }

            int maxHeight = this.Height - 1;
            if (height < 0 || height > maxHeight)
            {
                throw new ArgumentException($"Invalid height! Height should be in range [0 ... {maxHeight}].");
            }
        }

        public object Clone()
        {
            DrawingCanvas clone = new DrawingCanvas(this.Width / 3, this.Height);

            for (int row = 0; row < this.Height; row++)
            {
                Array.Copy(this.pixels[row], clone.pixels[row], this.pixels[row].Length);
            }

            return clone;
        }
    }
}
