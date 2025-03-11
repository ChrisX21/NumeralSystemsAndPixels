namespace FileCanvasDrawer
{
    public class DrawingCanvas : ICloneable
    {
        private byte[][] pixels;

        public DrawingCanvas(int width, int height, byte[][] pixels = null)
        {
            if (pixels == null)
            {
                this.EnsureCorrectDimensions(height, width);

                int widthColor = width * 3;
                this.pixels = new byte[height][];
                for (int row = 0; row < height; row++)
                {
                    this.pixels[row] = new byte[widthColor];
                }

                this.FillAllPixels();
            }
            else
            {
                this.EnsureCorrectDimensions(pixels.Length, pixels[0].Length / 3);
                this.pixels = pixels;
            }
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
            this.CheckBounds(row, col);

            int pixelOffset = col * 3;

            byte red = this.pixels[row][pixelOffset];
            byte green = this.pixels[row][pixelOffset + 1];
            byte blue = this.pixels[row][pixelOffset + 2];

            return Color.FromArgb(red, green, blue);
        }

        public void SetPixel(int row, int col, Color color)
        {
            this.CheckBounds(row, col);

            int pixelOffset = col * 3;

            this.pixels[row][pixelOffset] = color.R;
            this.pixels[row][pixelOffset + 1] = color.G;
            this.pixels[row][pixelOffset + 2] = color.B;
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
            if (Math.Abs(endRow - startRow) < Math.Abs(endCol - startCol))
            {
                if (startCol > endCol)
                {
                    this.PlotLineLow(endCol, endRow, startCol, startRow, color);
                }
                else
                {
                    this.PlotLineLow(startCol, startRow, endCol, endRow, color);
                }
            }
            else
            {
                if (startRow > endRow)
                {
                    this.PlotLineHigh(endCol, endRow, startCol, startRow, color);
                }
                else
                {
                    this.PlotLineHigh(startCol, startRow, endCol, endRow, color);
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

        public void DrawTriangle(int startRow, int startCol, int endRow, 
            int endCol, Color color)
        {
            this.DrawHorizontalLine(startRow, startCol, endCol, color);
            this.DrawVerticalLine(startCol, startRow, endRow, color);
            this.DrawDiagonalLine(endRow, startCol, startRow, endCol, color);
        }

        public void SaveCanvasToFile(string path)
        {
            throw new NotImplementedException();
        }

        public DrawingCanvas LoadCanvasFromFile(string path)
        {
            throw new NotImplementedException();
        }

        private void PlotLineLow(int startCol, int startRow, int endCol, 
            int endRow, Color color)
        {
            int destinationCol = endCol - startCol;
            int destinationRow = endRow - startRow;

            int rowIterator = 1;
            if (destinationRow < 0)
            {
                rowIterator = -1;
                destinationRow = -destinationRow;
            }

            int difference = 2 * destinationRow - destinationCol;
            int row = startRow;

            for (int col = startCol; col < endCol; col++)
            {
                this.SetPixel(row, col, color);
                if (difference > 0)
                {
                    row += rowIterator;
                    difference += 2 * (destinationRow - destinationCol);
                }
                else
                {
                    difference += 2 * destinationRow;
                }
            }
        }

        private void PlotLineHigh(int startCol, int startRow, int endCol, 
            int endRow, Color color)
        {
            int destinationRow = endRow - startRow;
            int destinationCol = endCol - startCol;

            int colIterator = 1;
            if (destinationCol < 0)
            {
                colIterator = -1;
                destinationCol = -destinationCol;
            }

            int difference = 2 * destinationCol - destinationRow;
            int col = startCol;

            for (int row = startRow; row < endRow; row++)
            {
                this.SetPixel(row, col, color);
                if (difference > 0)
                {
                    col += colIterator;
                    difference += 2 * (destinationCol - destinationRow);
                }
                else
                {
                    difference += 2 * destinationCol;
                }
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

        private void EnsureCorrectDimensions(int height, int width)
        {
            if (width < 32 || width > 1024)
            {
                throw new ArgumentException("Invalid width! Width should be in range [32 ... 1024].");
            }

            if (height < 32 || height > 1024)
            {
                throw new ArgumentException("Invalid height! Height should be in range [32 ... 1024].");
            }
        }

        public byte GetRowCol(int row, int col)
        {
            return this.pixels[row][col];
        }

        public object Clone()
        {
            DrawingCanvas clone = new DrawingCanvas(this.Width / 3, this.Height);

            for (int row = 0; row < this.pixels.Length; row++)
            {
                Array.Copy(this.pixels[row], clone.pixels[row], this.pixels[row].Length);
            }

            return clone;
        }
    }
}
