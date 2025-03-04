namespace ColoredCanvasDrawer
{
    partial class DrawerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonInverseCanvas = new System.Windows.Forms.Button();
            this.buttonClearCanvas = new System.Windows.Forms.Button();
            this.groupBoxDrawObjects = new System.Windows.Forms.GroupBox();
            this.buttonColorPicker = new System.Windows.Forms.Button();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.numericUpDownEndRow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEndColumn = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartRow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartColumn = new System.Windows.Forms.NumericUpDown();
            this.labelEndRow = new System.Windows.Forms.Label();
            this.labelEndColumn = new System.Windows.Forms.Label();
            this.labelStartRow = new System.Windows.Forms.Label();
            this.labelStartColumn = new System.Windows.Forms.Label();
            this.comboBoxDrawMode = new System.Windows.Forms.ComboBox();
            this.labelDrawMode = new System.Windows.Forms.Label();
            this.buttonDrawObject = new System.Windows.Forms.Button();
            this.groupBoxCanvas = new System.Windows.Forms.GroupBox();
            this.panelPictureBox = new System.Windows.Forms.Panel();
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.groupBoxOperations = new System.Windows.Forms.GroupBox();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.groupBoxDrawObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartColumn)).BeginInit();
            this.groupBoxCanvas.SuspendLayout();
            this.panelPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            this.groupBoxOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(13, 20);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(238, 23);
            this.buttonUndo.TabIndex = 48;
            this.buttonUndo.Text = "⎌ Undo Last Operation";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // buttonInverseCanvas
            // 
            this.buttonInverseCanvas.Location = new System.Drawing.Point(139, 50);
            this.buttonInverseCanvas.Name = "buttonInverseCanvas";
            this.buttonInverseCanvas.Size = new System.Drawing.Size(112, 23);
            this.buttonInverseCanvas.TabIndex = 53;
            this.buttonInverseCanvas.Text = "Inverse Canvas";
            this.buttonInverseCanvas.UseVisualStyleBackColor = true;
            this.buttonInverseCanvas.Click += new System.EventHandler(this.ButtonInverse_Click);
            // 
            // buttonClearCanvas
            // 
            this.buttonClearCanvas.Location = new System.Drawing.Point(13, 50);
            this.buttonClearCanvas.Name = "buttonClearCanvas";
            this.buttonClearCanvas.Size = new System.Drawing.Size(112, 23);
            this.buttonClearCanvas.TabIndex = 55;
            this.buttonClearCanvas.Text = "Clear Canvas";
            this.buttonClearCanvas.UseVisualStyleBackColor = true;
            this.buttonClearCanvas.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // groupBoxDrawObjects
            // 
            this.groupBoxDrawObjects.Controls.Add(this.buttonColorPicker);
            this.groupBoxDrawObjects.Controls.Add(this.textBoxColor);
            this.groupBoxDrawObjects.Controls.Add(this.labelColor);
            this.groupBoxDrawObjects.Controls.Add(this.numericUpDownEndRow);
            this.groupBoxDrawObjects.Controls.Add(this.numericUpDownEndColumn);
            this.groupBoxDrawObjects.Controls.Add(this.numericUpDownStartRow);
            this.groupBoxDrawObjects.Controls.Add(this.numericUpDownStartColumn);
            this.groupBoxDrawObjects.Controls.Add(this.labelEndRow);
            this.groupBoxDrawObjects.Controls.Add(this.labelEndColumn);
            this.groupBoxDrawObjects.Controls.Add(this.labelStartRow);
            this.groupBoxDrawObjects.Controls.Add(this.labelStartColumn);
            this.groupBoxDrawObjects.Controls.Add(this.comboBoxDrawMode);
            this.groupBoxDrawObjects.Controls.Add(this.labelDrawMode);
            this.groupBoxDrawObjects.Controls.Add(this.buttonDrawObject);
            this.groupBoxDrawObjects.Location = new System.Drawing.Point(10, 9);
            this.groupBoxDrawObjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDrawObjects.Name = "groupBoxDrawObjects";
            this.groupBoxDrawObjects.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDrawObjects.Size = new System.Drawing.Size(269, 232);
            this.groupBoxDrawObjects.TabIndex = 56;
            this.groupBoxDrawObjects.TabStop = false;
            this.groupBoxDrawObjects.Text = "Draw Objects";
            // 
            // buttonColorPicker
            // 
            this.buttonColorPicker.Location = new System.Drawing.Point(171, 162);
            this.buttonColorPicker.Name = "buttonColorPicker";
            this.buttonColorPicker.Size = new System.Drawing.Size(85, 23);
            this.buttonColorPicker.TabIndex = 59;
            this.buttonColorPicker.Text = "Pick";
            this.buttonColorPicker.UseVisualStyleBackColor = true;
            this.buttonColorPicker.Click += new System.EventHandler(this.ButtonColorPicker_Click);
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(58, 162);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.ReadOnly = true;
            this.textBoxColor.Size = new System.Drawing.Size(107, 23);
            this.textBoxColor.TabIndex = 60;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(13, 166);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(39, 15);
            this.labelColor.TabIndex = 64;
            this.labelColor.Text = "Color:";
            // 
            // numericUpDownEndRow
            // 
            this.numericUpDownEndRow.Location = new System.Drawing.Point(13, 94);
            this.numericUpDownEndRow.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownEndRow.Name = "numericUpDownEndRow";
            this.numericUpDownEndRow.Size = new System.Drawing.Size(112, 23);
            this.numericUpDownEndRow.TabIndex = 63;
            this.numericUpDownEndRow.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownEndColumn
            // 
            this.numericUpDownEndColumn.Location = new System.Drawing.Point(144, 94);
            this.numericUpDownEndColumn.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownEndColumn.Name = "numericUpDownEndColumn";
            this.numericUpDownEndColumn.Size = new System.Drawing.Size(112, 23);
            this.numericUpDownEndColumn.TabIndex = 62;
            this.numericUpDownEndColumn.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownStartRow
            // 
            this.numericUpDownStartRow.Location = new System.Drawing.Point(13, 46);
            this.numericUpDownStartRow.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownStartRow.Name = "numericUpDownStartRow";
            this.numericUpDownStartRow.Size = new System.Drawing.Size(112, 23);
            this.numericUpDownStartRow.TabIndex = 61;
            this.numericUpDownStartRow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownStartColumn
            // 
            this.numericUpDownStartColumn.Location = new System.Drawing.Point(144, 47);
            this.numericUpDownStartColumn.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownStartColumn.Name = "numericUpDownStartColumn";
            this.numericUpDownStartColumn.Size = new System.Drawing.Size(112, 23);
            this.numericUpDownStartColumn.TabIndex = 60;
            this.numericUpDownStartColumn.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelEndRow
            // 
            this.labelEndRow.AutoSize = true;
            this.labelEndRow.Location = new System.Drawing.Point(13, 74);
            this.labelEndRow.Name = "labelEndRow";
            this.labelEndRow.Size = new System.Drawing.Size(56, 15);
            this.labelEndRow.TabIndex = 59;
            this.labelEndRow.Text = "End Row:";
            // 
            // labelEndColumn
            // 
            this.labelEndColumn.AutoSize = true;
            this.labelEndColumn.Location = new System.Drawing.Point(144, 75);
            this.labelEndColumn.Name = "labelEndColumn";
            this.labelEndColumn.Size = new System.Drawing.Size(76, 15);
            this.labelEndColumn.TabIndex = 58;
            this.labelEndColumn.Text = "End Column:";
            // 
            // labelStartRow
            // 
            this.labelStartRow.AutoSize = true;
            this.labelStartRow.Location = new System.Drawing.Point(13, 27);
            this.labelStartRow.Name = "labelStartRow";
            this.labelStartRow.Size = new System.Drawing.Size(60, 15);
            this.labelStartRow.TabIndex = 57;
            this.labelStartRow.Text = "Start Row:";
            // 
            // labelStartColumn
            // 
            this.labelStartColumn.AutoSize = true;
            this.labelStartColumn.Location = new System.Drawing.Point(144, 27);
            this.labelStartColumn.Name = "labelStartColumn";
            this.labelStartColumn.Size = new System.Drawing.Size(80, 15);
            this.labelStartColumn.TabIndex = 56;
            this.labelStartColumn.Text = "Start Column:";
            // 
            // comboBoxDrawMode
            // 
            this.comboBoxDrawMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrawMode.FormattingEnabled = true;
            this.comboBoxDrawMode.Items.AddRange(new object[] {
            "Pixel",
            "Horizontal Line",
            "Vertical Line",
            "Diagonal Line",
            "Rectangle",
            "Triangle"});
            this.comboBoxDrawMode.Location = new System.Drawing.Point(97, 129);
            this.comboBoxDrawMode.Name = "comboBoxDrawMode";
            this.comboBoxDrawMode.Size = new System.Drawing.Size(159, 23);
            this.comboBoxDrawMode.TabIndex = 55;
            this.comboBoxDrawMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDrawMode_SelectedIndexChanged);
            // 
            // labelDrawMode
            // 
            this.labelDrawMode.AutoSize = true;
            this.labelDrawMode.Location = new System.Drawing.Point(13, 132);
            this.labelDrawMode.Name = "labelDrawMode";
            this.labelDrawMode.Size = new System.Drawing.Size(71, 15);
            this.labelDrawMode.TabIndex = 54;
            this.labelDrawMode.Text = "Draw Mode:";
            // 
            // buttonDrawObject
            // 
            this.buttonDrawObject.Location = new System.Drawing.Point(171, 201);
            this.buttonDrawObject.Name = "buttonDrawObject";
            this.buttonDrawObject.Size = new System.Drawing.Size(85, 23);
            this.buttonDrawObject.TabIndex = 53;
            this.buttonDrawObject.Text = "Draw";
            this.buttonDrawObject.UseVisualStyleBackColor = true;
            this.buttonDrawObject.Click += new System.EventHandler(this.ButtonDrawObject_Click);
            // 
            // groupBoxCanvas
            // 
            this.groupBoxCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCanvas.Controls.Add(this.panelPictureBox);
            this.groupBoxCanvas.Location = new System.Drawing.Point(295, 9);
            this.groupBoxCanvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxCanvas.Name = "groupBoxCanvas";
            this.groupBoxCanvas.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxCanvas.Size = new System.Drawing.Size(505, 351);
            this.groupBoxCanvas.TabIndex = 57;
            this.groupBoxCanvas.TabStop = false;
            this.groupBoxCanvas.Text = "Drawing Canvas: 256 x 256";
            // 
            // panelPictureBox
            // 
            this.panelPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPictureBox.Controls.Add(this.pictureBoxCanvas);
            this.panelPictureBox.Location = new System.Drawing.Point(8, 24);
            this.panelPictureBox.Name = "panelPictureBox";
            this.panelPictureBox.Size = new System.Drawing.Size(490, 319);
            this.panelPictureBox.TabIndex = 66;
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.Location = new System.Drawing.Point(6, 4);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(480, 312);
            this.pictureBoxCanvas.TabIndex = 48;
            this.pictureBoxCanvas.TabStop = false;
            // 
            // groupBoxOperations
            // 
            this.groupBoxOperations.Controls.Add(this.buttonZoomOut);
            this.groupBoxOperations.Controls.Add(this.buttonZoomIn);
            this.groupBoxOperations.Controls.Add(this.buttonClearCanvas);
            this.groupBoxOperations.Controls.Add(this.buttonUndo);
            this.groupBoxOperations.Controls.Add(this.buttonInverseCanvas);
            this.groupBoxOperations.Location = new System.Drawing.Point(10, 250);
            this.groupBoxOperations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxOperations.Name = "groupBoxOperations";
            this.groupBoxOperations.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxOperations.Size = new System.Drawing.Size(269, 110);
            this.groupBoxOperations.TabIndex = 58;
            this.groupBoxOperations.TabStop = false;
            this.groupBoxOperations.Text = "Operations";
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Location = new System.Drawing.Point(139, 79);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(112, 23);
            this.buttonZoomOut.TabIndex = 60;
            this.buttonZoomOut.Text = "Zoom Out";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.ButtonZoomOut_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Location = new System.Drawing.Point(13, 79);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(112, 23);
            this.buttonZoomIn.TabIndex = 59;
            this.buttonZoomIn.Text = "Zoom In";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.ButtonZoomIn_Click);
            // 
            // DrawerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 373);
            this.Controls.Add(this.groupBoxOperations);
            this.Controls.Add(this.groupBoxCanvas);
            this.Controls.Add(this.groupBoxDrawObjects);
            this.Name = "DrawerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Canvas Drawer";
            this.Load += new System.EventHandler(this.Drawer_Load);
            this.groupBoxDrawObjects.ResumeLayout(false);
            this.groupBoxDrawObjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartColumn)).EndInit();
            this.groupBoxCanvas.ResumeLayout(false);
            this.panelPictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            this.groupBoxOperations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button buttonUndo;
        private Button buttonInverseCanvas;
        private Button buttonClearCanvas;
        private GroupBox groupBoxDrawObjects;
        private NumericUpDown numericUpDownEndRow;
        private NumericUpDown numericUpDownEndColumn;
        private NumericUpDown numericUpDownStartRow;
        private NumericUpDown numericUpDownStartColumn;
        private Label labelEndRow;
        private Label labelEndColumn;
        private Label labelStartRow;
        private Label labelStartColumn;
        private ComboBox comboBoxDrawMode;
        private Label labelDrawMode;
        private Button buttonDrawObject;
        private GroupBox groupBoxCanvas;
        private PictureBox pictureBoxCanvas;
        private GroupBox groupBoxOperations;
        private Label labelColor;
        private Button buttonZoomIn;
        private Panel panelPictureBox;
        private Button buttonZoomOut;
        private Button buttonColorPicker;
        private TextBox textBoxColor;
    }
}