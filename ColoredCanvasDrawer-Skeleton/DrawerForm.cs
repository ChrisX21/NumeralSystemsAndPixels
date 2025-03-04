using System.Text.RegularExpressions;

namespace ColoredCanvasDrawer
{
    public partial class DrawerForm : Form
    {
        private const int CANVAS_WIDTH = 549;
        private const int CANVAS_HEIGHT = 416;
        private const int ZOOM_LEVEL = 2;

        private readonly Stack<DrawingCanvas> undoStack;

        private DrawingCanvas canvas;
        private bool isZoomed;

        public DrawerForm()
        {
            this.canvas = new DrawingCanvas(CANVAS_WIDTH, CANVAS_HEIGHT);
            this.undoStack = new Stack<DrawingCanvas>();
            this.isZoomed = false;

            this.InitializeComponent();

            this.pictureBoxCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
            this.panelPictureBox.AutoScroll = true;

            this.pictureBoxCanvas.Image = this.InitializeCanvas();

            this.comboBoxDrawMode.Text = "Pixel";
            this.textBoxColor.Text = "Black";
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

            string colorText = this.textBoxColor.Text;

            Color color = colorText.StartsWith('#')
                ? ColorTranslator.FromHtml(colorText)
                : Color.FromName(colorText);

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
            else if (selectedFigure == FigureType.DiagonalLine)
            {
                this.canvas.DrawDiagonalLine(startRow, startCol, endRow, endCol, color);
            }
            else if (selectedFigure == FigureType.Rectangle)
            {
                this.canvas.DrawRectangle(startRow, startCol, endRow, endCol, color);
            }
            else if (selectedFigure == FigureType.Triangle)
            {
                this.canvas.DrawTriangle(startRow, startCol, endRow, endCol, color);
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
            if (selectedFigure == FigureType.Rectangle
                || selectedFigure == FigureType.Triangle
                || selectedFigure == FigureType.DiagonalLine)
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

            this.canvas = this.undoStack.Pop();
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
            this.canvas.FillAllPixels();
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

            this.isZoomed = true;
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

            this.isZoomed = false;
        }

        private void ButtonColorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();

            dialog.AllowFullOpen = false;
            dialog.ShowHelp = true;
            dialog.Color = Color.Black;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxColor.Text = dialog.Color.GetColorName();
            }
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
            int height = this.isZoomed
                ? this.pictureBoxCanvas.Height / 2
                : this.pictureBoxCanvas.Height;

            int width = this.isZoomed
                ? this.pictureBoxCanvas.Width / 2
                : this.pictureBoxCanvas.Width;

            Bitmap screen = (Bitmap)pictureBoxCanvas.Image;

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Color color = canvas.GetPixel(row, col);

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
