using System.Text.RegularExpressions;

namespace CanvasDrawer
{
    public partial class DrawerForm : Form
    {
        private const int CANVAS_WIDTH = 544;
        private const int CANVAS_HEIGHT = 365;
        private const int ZOOM_LEVEL = 2;

        private readonly Stack<DrawingCanvas> undoStack;

        private DrawingCanvas canvas;

        public DrawerForm()
        {
            this.canvas = new DrawingCanvas(CANVAS_WIDTH, CANVAS_HEIGHT);
            this.undoStack = new Stack<DrawingCanvas>();

            this.InitializeComponent();

            this.pictureBoxCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
            this.panelPictureBox.AutoScroll = true;

            this.pictureBoxCanvas.Image = this.InitializeCanvas();

            this.comboBoxDrawMode.Text = "Pixel";
            this.comboBoxColor.Text = "Black";
            this.groupBoxCanvas.Text = $"Drawing Canvas: {CANVAS_WIDTH} x {CANVAS_HEIGHT}";

            this.numericUpDownStartRow.Maximum = this.pictureBoxCanvas.Height;
            this.numericUpDownEndRow.Maximum = this.pictureBoxCanvas.Height;
            this.numericUpDownStartColumn.Maximum = this.pictureBoxCanvas.Width;
            this.numericUpDownEndColumn.Maximum = this.pictureBoxCanvas.Width;
        }

        private void ButtonDrawObject_Click(object sender, EventArgs e)
        {
            int startCol = int.Parse(this.numericUpDownStartColumn.Text);
            int startRow = int.Parse(this.numericUpDownStartRow.Text);
            int endCol = int.Parse(this.numericUpDownEndColumn.Text);
            int endRow = int.Parse(this.numericUpDownEndRow.Text);
            CanvasColor color = this.comboBoxColor.Text == "Black"
                ? CanvasColor.Black
                : CanvasColor.White;

            this.undoStack.Push((DrawingCanvas)this.canvas.Clone());

            string figureAsString = this.comboBoxDrawMode.SelectedItem.ToString();

            FigureType selectedFigure = Enum.Parse<FigureType>(this.RemoveWhitespace(figureAsString));
            if (selectedFigure == FigureType.Pixel)
            {
                this.canvas.SetPixel(startRow, startCol, color);
            }
            else if (selectedFigure == FigureType.HorizontalLine)
            {
                this.canvas.DrawHorizontalLine(startRow, startCol, endCol, color);
            }
            else if (selectedFigure == FigureType.VerticalLine)
            {
                this.canvas.DrawVerticalLine(startCol, startRow, endRow, color);
            }
            else if (selectedFigure == FigureType.Rectangle)
            {
                this.canvas.DrawRectangle(startRow, startCol, endRow, endCol, color);
            }

            this.DisplayCanvas(this.canvas, this.pictureBoxCanvas);
        }

        private void Drawer_Load(object sender, EventArgs e)
        {
            this.numericUpDownStartColumn.Enabled = true;
            this.numericUpDownStartRow.Enabled = true;
            this.numericUpDownEndColumn.Enabled = false;
            this.numericUpDownEndRow.Enabled = false;
            this.buttonZoomIn.Enabled = true;
            this.buttonZoomOut.Enabled = false;
        }

        private void ComboBoxDrawMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.numericUpDownStartColumn.Enabled = true;
            this.numericUpDownStartRow.Enabled = true;

            string figureAsString = this.comboBoxDrawMode.SelectedItem.ToString();

            FigureType selectedFigure = Enum.Parse<FigureType>(this.RemoveWhitespace(figureAsString));
            if (selectedFigure == FigureType.HorizontalLine)
            {
                this.numericUpDownEndColumn.Enabled = true;
                this.numericUpDownEndRow.Enabled = false;
            }
            else if (selectedFigure == FigureType.VerticalLine)
            {
                this.numericUpDownEndColumn.Enabled = false;
                this.numericUpDownEndRow.Enabled = true;
            }
            if (selectedFigure == FigureType.Rectangle)
            {
                this.numericUpDownEndColumn.Enabled = true;
                this.numericUpDownEndRow.Enabled = true;
            }
            else if (selectedFigure == FigureType.Pixel)
            {
                this.numericUpDownEndColumn.Enabled = false;
                this.numericUpDownEndRow.Enabled = false;
            }
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            if (!this.undoStack.Any())
            {
                return;
            }

            DrawingCanvas previous = this.undoStack.Pop();
            this.canvas = previous;
            this.DisplayCanvas(this.canvas, this.pictureBoxCanvas);
        }

        private void ButtonInverse_Click(object sender, EventArgs e)
        {
            this.undoStack.Push((DrawingCanvas)this.canvas.Clone());
            this.canvas.InvertAllPixels();
            this.DisplayCanvas(this.canvas, this.pictureBoxCanvas);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.undoStack.Push((DrawingCanvas)this.canvas.Clone());
            this.canvas.FillAllPixels(CanvasColor.White);
            this.DisplayCanvas(this.canvas, this.pictureBoxCanvas);
        }

        private void ButtonZoomIn_Click(object sender, EventArgs e)
        {
            this.buttonZoomIn.Enabled = false;
            this.buttonZoomOut.Enabled = true;

            Image image = this.pictureBoxCanvas.Image;
            Size size = new Size(ZOOM_LEVEL, ZOOM_LEVEL);

            Bitmap bitmap = new Bitmap(
                image,
                image.Width * size.Width,
                image.Height * size.Height);

            this.pictureBoxCanvas.Image = bitmap;
        }

        private void ButtonZoomOut_Click(object sender, EventArgs e)
        {
            this.buttonZoomIn.Enabled = true;
            this.buttonZoomOut.Enabled = false;

            Image image = this.pictureBoxCanvas.Image;
            Size size = new Size(ZOOM_LEVEL, ZOOM_LEVEL);

            Bitmap bitmap = new Bitmap(
                image,
                image.Width / size.Width,
                image.Height / size.Height);

            this.pictureBoxCanvas.Image = bitmap;

            this.DisplayCanvas(this.canvas, this.pictureBoxCanvas);
        }

        private Bitmap InitializeCanvas()
        {
            Bitmap image = new Bitmap(CANVAS_WIDTH, CANVAS_HEIGHT);

            for (int col = 0; col < CANVAS_WIDTH; col++)
            {
                for (int row = 0; row < CANVAS_HEIGHT; row++)
                {
                    image.SetPixel(col, row, Color.White);
                }
            }

            return image;
        }

        private void DisplayCanvas(DrawingCanvas canvas, PictureBox pictureBoxCanvas)
        {
            Bitmap screen = (Bitmap)pictureBoxCanvas.Image;

            for (int row = 0; row < canvas.Height; row++)
            {
                for (int col = 0; col < canvas.Width; col++)
                {
                    CanvasColor pixelColor = this.canvas.GetPixel(row, col);
                    Color color = pixelColor == CanvasColor.Black
                        ? Color.Black
                        : Color.White;

                    screen.SetPixel(col, row, color);
                }
            }

            pictureBoxCanvas.Refresh();
        }

        private string RemoveWhitespace(string text)
        {
            return Regex.Replace(text, @"\s+", "");
        }
    }
}
