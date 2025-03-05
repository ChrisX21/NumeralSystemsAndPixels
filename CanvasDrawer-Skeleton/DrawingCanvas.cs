namespace CanvasDrawer
{
    public class DrawingCanvas : ICloneable
    {
        private uint[][] pixels;

        public DrawingCanvas(int width, int height)
        {
            if (width < 32 || width > 1024 || width % 32 != 0)
            {
                throw new ArgumentException("Invalid width! Width should be in range [32 ... 1024] and should be divisible by 32.");
            }

            if (height < 32 || height > 1024)
            {
                throw new ArgumentException("Invalid height! Height should be in range [32 ... 1024].");
            }

            // Allocate the pixels in the image
            int widthInts = width / 32;
            this.pixels = new uint[height][];
            for (int row = 0; row < height; row++)
            {
                this.pixels[row] = new uint[widthInts];
            }

            // Uncomment when implemented
            this.FillAllPixels(CanvasColor.White);
        }

        public int Width => this.pixels[0].Length * 32;

        public int Height => this.pixels.Length;

        public int RowCount => this.pixels.Length;

        public int ColCount => this.pixels[0].Length;

        public void FillAllPixels(CanvasColor color)
        {
            uint mask = (color == CanvasColor.Black) ? 0 : uint.MaxValue;
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int col = 0; col < this.ColCount; col++)
                {
                    this.pixels[row][col] = mask;
                }
            }
        }

        public void InvertAllPixels()
        {
            for (int row = 0; row < this.RowCount; row++)
            {
                for (int col = 0; col < this.ColCount; col++)
                {
                    this.pixels[row][col] = ~this.pixels[row][col];
                }
            }
        }

        public CanvasColor GetPixel(int row, int col)
        {
            CheckBounds(row, col);

            int bitIndex = col % 32;
            int intIndex = col / 32;
            uint bitValue = (this.pixels[row][intIndex] >> bitIndex) & 1;

            return (bitValue == 1) ? CanvasColor.White : CanvasColor.Black;
        }

        public void SetPixel(int row, int col, CanvasColor color)
        {
            CheckBounds(row, col);

            int bitIndex = col % 32;
            int intIndex = col / 32;
            uint mask = (uint)(1 << bitIndex);

            if (color == CanvasColor.White)
            {
                this.pixels[row][intIndex] |= mask;
            }
            else
            {
                this.pixels[row][intIndex] &= ~mask;
            }
        }

        public void DrawHorizontalLine(int row, int startCol, int endCol, CanvasColor color)
        {
            CheckBounds(row, startCol);
            CheckBounds(row, endCol);

            if (startCol > endCol)
            {
                throw new ArgumentException("startCol should be less than or equal to endCol");
            }

            for (int col = startCol; col <= endCol; col++)
            {
                SetPixel(row, col, color);
            }
        }


        public void DrawVerticalLine(int col, int startRow, int endRow, CanvasColor color)
        {
            CheckBounds(startRow, col);
            CheckBounds(endRow, col);

            if (startRow > endRow)
            {
                throw new ArgumentException("startRow should be less than or equal to endRow.");
            }

            for (int row = startRow; row <= endRow; row++)
            {
                SetPixel(row, col, color);
            }
        }


        public void DrawRectangle(int startRow, int startCol, int endRow, int endCol, CanvasColor color)
        {
            CheckBounds(startRow, startCol);
            CheckBounds(endRow, endCol);

            if (startRow > endRow)
            {
                throw new ArgumentException("startRow should be less than or equal to endRow.");
            }

            if (startCol > endCol)
            {
                throw new ArgumentException("startCol should be less than or equal to endCol.");
            }

            DrawHorizontalLine(startRow, startCol, endCol, color);
            DrawHorizontalLine(endRow, startCol, endCol, color);
            DrawVerticalLine(startCol, startRow, endRow, color);
            DrawVerticalLine(endCol, startRow, endRow, color);

        }



        private void CheckBounds(int height, int width)
        {
            int maxWidth = this.Width - 1;
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
            DrawingCanvas clone = new DrawingCanvas(this.Width, this.Height);

            for (int row = 0; row < this.RowCount; row++)
            {
                Array.Copy(this.pixels[row], clone.pixels[row], this.pixels[row].Length);
            }

            return clone;
        }
    }
}
