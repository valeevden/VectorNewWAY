namespace VectorNewWAY

{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackPenWidth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.colorPalete = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this._anglesNumber = new System.Windows.Forms.NumericUpDown();
            this.radioButtonPaintMode = new System.Windows.Forms.RadioButton();
            this.radioButtonMoveMode = new System.Windows.Forms.RadioButton();
            this.radioButtonRotate = new System.Windows.Forms.RadioButton();
            this.radioButtonScale = new System.Windows.Forms.RadioButton();
            this.radioButtonPeak = new System.Windows.Forms.RadioButton();
            this.FILL = new System.Windows.Forms.RadioButton();
            this.colorPicker = new System.Windows.Forms.RadioButton();
            this.uploadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.NanglesFigure = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.Line2D = new System.Windows.Forms.Button();
            this.FigureND = new System.Windows.Forms.Button();
            this.IsoscelesTriangle = new System.Windows.Forms.Button();
            this.RectTriangleButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.Ellipse = new System.Windows.Forms.Button();
            this.Circle_2d = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Rectangle_2d = new System.Windows.Forms.Button();
            this.LineND = new System.Windows.Forms.Button();
            this.Brush = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackPenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._anglesNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackPenWidth
            // 
            this.trackPenWidth.BackColor = System.Drawing.Color.DimGray;
            this.trackPenWidth.Location = new System.Drawing.Point(774, 32);
            this.trackPenWidth.Maximum = 30;
            this.trackPenWidth.Minimum = 1;
            this.trackPenWidth.Name = "trackPenWidth";
            this.trackPenWidth.Size = new System.Drawing.Size(303, 56);
            this.trackPenWidth.TabIndex = 25;
            this.trackPenWidth.Value = 6;
            this.trackPenWidth.Scroll += new System.EventHandler(this.trackPenWidth_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(709, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Color";
            // 
            // colorPalete
            // 
            this.colorPalete.BackColor = System.Drawing.Color.Red;
            this.colorPalete.Location = new System.Drawing.Point(709, 32);
            this.colorPalete.Name = "colorPalete";
            this.colorPalete.Size = new System.Drawing.Size(59, 56);
            this.colorPalete.TabIndex = 27;
            this.colorPalete.Click += new System.EventHandler(this.colorPalete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(774, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Size";
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.Red;
            // 
            // _anglesNumber
            // 
            this._anglesNumber.Location = new System.Drawing.Point(153, 524);
            this._anglesNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._anglesNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._anglesNumber.Name = "_anglesNumber";
            this._anglesNumber.Size = new System.Drawing.Size(70, 22);
            this._anglesNumber.TabIndex = 29;
            this._anglesNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._anglesNumber.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._anglesNumber.ValueChanged += new System.EventHandler(this._anglesNumber_ValueChanged);
            // 
            // radioButtonPaintMode
            // 
            this.radioButtonPaintMode.AutoSize = true;
            this.radioButtonPaintMode.Checked = true;
            this.radioButtonPaintMode.Location = new System.Drawing.Point(432, 32);
            this.radioButtonPaintMode.Name = "radioButtonPaintMode";
            this.radioButtonPaintMode.Size = new System.Drawing.Size(69, 21);
            this.radioButtonPaintMode.TabIndex = 33;
            this.radioButtonPaintMode.TabStop = true;
            this.radioButtonPaintMode.Text = "PAINT";
            this.radioButtonPaintMode.UseVisualStyleBackColor = true;
            this.radioButtonPaintMode.CheckedChanged += new System.EventHandler(this.radioButtonPaintMode_CheckedChanged);
            // 
            // radioButtonMoveMode
            // 
            this.radioButtonMoveMode.AutoSize = true;
            this.radioButtonMoveMode.Location = new System.Drawing.Point(432, 56);
            this.radioButtonMoveMode.Name = "radioButtonMoveMode";
            this.radioButtonMoveMode.Size = new System.Drawing.Size(69, 21);
            this.radioButtonMoveMode.TabIndex = 34;
            this.radioButtonMoveMode.Text = "MOVE";
            this.radioButtonMoveMode.UseVisualStyleBackColor = true;
            this.radioButtonMoveMode.CheckedChanged += new System.EventHandler(this.radioButtonMoveMode_CheckedChanged);
            // 
            // radioButtonRotate
            // 
            this.radioButtonRotate.AutoSize = true;
            this.radioButtonRotate.Location = new System.Drawing.Point(432, 80);
            this.radioButtonRotate.Name = "radioButtonRotate";
            this.radioButtonRotate.Size = new System.Drawing.Size(86, 21);
            this.radioButtonRotate.TabIndex = 35;
            this.radioButtonRotate.Text = "ROTATE";
            this.radioButtonRotate.UseVisualStyleBackColor = true;
            this.radioButtonRotate.CheckedChanged += new System.EventHandler(this.radioButtonRotate_CheckedChanged);
            // 
            // radioButtonScale
            // 
            this.radioButtonScale.AutoSize = true;
            this.radioButtonScale.Location = new System.Drawing.Point(535, 80);
            this.radioButtonScale.Name = "radioButtonScale";
            this.radioButtonScale.Size = new System.Drawing.Size(73, 21);
            this.radioButtonScale.TabIndex = 36;
            this.radioButtonScale.TabStop = true;
            this.radioButtonScale.Text = "SCALE";
            this.radioButtonScale.UseVisualStyleBackColor = true;
            this.radioButtonScale.CheckedChanged += new System.EventHandler(this.radioButtonScale_CheckedChanged);
            // 
            // radioButtonPeak
            // 
            this.radioButtonPeak.AutoSize = true;
            this.radioButtonPeak.Location = new System.Drawing.Point(535, 32);
            this.radioButtonPeak.Name = "radioButtonPeak";
            this.radioButtonPeak.Size = new System.Drawing.Size(93, 21);
            this.radioButtonPeak.TabIndex = 37;
            this.radioButtonPeak.TabStop = true;
            this.radioButtonPeak.Text = "ADD peak";
            this.radioButtonPeak.UseVisualStyleBackColor = true;
            this.radioButtonPeak.CheckedChanged += new System.EventHandler(this.radioButtonPeak_CheckedChanged);
            // 
            // FILL
            // 
            this.FILL.AutoSize = true;
            this.FILL.Location = new System.Drawing.Point(535, 56);
            this.FILL.Name = "FILL";
            this.FILL.Size = new System.Drawing.Size(56, 21);
            this.FILL.TabIndex = 38;
            this.FILL.TabStop = true;
            this.FILL.Text = "FILL";
            this.FILL.UseVisualStyleBackColor = true;
            this.FILL.CheckedChanged += new System.EventHandler(this.FILL_CheckedChanged);
            // 
            // colorPicker
            // 
            this.colorPicker.AutoSize = true;
            this.colorPicker.Location = new System.Drawing.Point(704, 94);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(105, 21);
            this.colorPicker.TabIndex = 39;
            this.colorPicker.TabStop = true;
            this.colorPicker.Text = "Color Picker";
            this.colorPicker.UseVisualStyleBackColor = true;
            this.colorPicker.CheckedChanged += new System.EventHandler(this.colorPicker_CheckedChanged);
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.White;
            this.uploadButton.Image = global::VectorNewWAY.Properties.Resources.upload;
            this.uploadButton.Location = new System.Drawing.Point(299, 573);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(4);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(90, 70);
            this.uploadButton.TabIndex = 32;
            this.uploadButton.Text = "Upload";
            this.uploadButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.Image = global::VectorNewWAY.Properties.Resources.diskette;
            this.saveButton.Location = new System.Drawing.Point(299, 495);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 70);
            this.saveButton.TabIndex = 31;
            this.saveButton.Text = "Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // NanglesFigure
            // 
            this.NanglesFigure.BackColor = System.Drawing.Color.White;
            this.NanglesFigure.Image = global::VectorNewWAY.Properties.Resources.hexagon;
            this.NanglesFigure.Location = new System.Drawing.Point(75, 499);
            this.NanglesFigure.Margin = new System.Windows.Forms.Padding(4);
            this.NanglesFigure.Name = "NanglesFigure";
            this.NanglesFigure.Size = new System.Drawing.Size(70, 70);
            this.NanglesFigure.TabIndex = 30;
            this.NanglesFigure.UseVisualStyleBackColor = false;
            this.NanglesFigure.Click += new System.EventHandler(this.NanglesFigure_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.White;
            this.button23.Image = global::VectorNewWAY.Properties.Resources.garbage;
            this.button23.Location = new System.Drawing.Point(75, 13);
            this.button23.Margin = new System.Windows.Forms.Padding(4);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(148, 80);
            this.button23.TabIndex = 24;
            this.button23.Text = "Clear";
            this.button23.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // Line2D
            // 
            this.Line2D.BackColor = System.Drawing.Color.White;
            this.Line2D.Image = global::VectorNewWAY.Properties.Resources.diagonal_line;
            this.Line2D.Location = new System.Drawing.Point(153, 109);
            this.Line2D.Margin = new System.Windows.Forms.Padding(4);
            this.Line2D.Name = "Line2D";
            this.Line2D.Size = new System.Drawing.Size(70, 70);
            this.Line2D.TabIndex = 12;
            this.Line2D.UseVisualStyleBackColor = false;
            this.Line2D.Click += new System.EventHandler(this.Line2D_Click);
            // 
            // FigureND
            // 
            this.FigureND.BackColor = System.Drawing.Color.White;
            this.FigureND.Image = global::VectorNewWAY.Properties.Resources.shapepolygon_120487;
            this.FigureND.Location = new System.Drawing.Point(75, 421);
            this.FigureND.Margin = new System.Windows.Forms.Padding(4);
            this.FigureND.Name = "FigureND";
            this.FigureND.Size = new System.Drawing.Size(70, 70);
            this.FigureND.TabIndex = 10;
            this.FigureND.UseVisualStyleBackColor = false;
            this.FigureND.Click += new System.EventHandler(this.FigureND_Click);
            // 
            // IsoscelesTriangle
            // 
            this.IsoscelesTriangle.BackColor = System.Drawing.Color.White;
            this.IsoscelesTriangle.Image = global::VectorNewWAY.Properties.Resources.plain_triangle;
            this.IsoscelesTriangle.Location = new System.Drawing.Point(75, 343);
            this.IsoscelesTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.IsoscelesTriangle.Name = "IsoscelesTriangle";
            this.IsoscelesTriangle.Size = new System.Drawing.Size(70, 70);
            this.IsoscelesTriangle.TabIndex = 9;
            this.IsoscelesTriangle.UseVisualStyleBackColor = false;
            this.IsoscelesTriangle.Click += new System.EventHandler(this.IsoscelesTriangle_Click);
            // 
            // RectTriangleButton
            // 
            this.RectTriangleButton.BackColor = System.Drawing.Color.White;
            this.RectTriangleButton.Image = global::VectorNewWAY.Properties.Resources.trigonometry;
            this.RectTriangleButton.Location = new System.Drawing.Point(153, 421);
            this.RectTriangleButton.Margin = new System.Windows.Forms.Padding(4);
            this.RectTriangleButton.Name = "RectTriangleButton";
            this.RectTriangleButton.Size = new System.Drawing.Size(70, 70);
            this.RectTriangleButton.TabIndex = 8;
            this.RectTriangleButton.UseVisualStyleBackColor = false;
            this.RectTriangleButton.Click += new System.EventHandler(this.RectTriangleButton_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Image = global::VectorNewWAY.Properties.Resources.triangle_cherished_4071;
            this.button7.Location = new System.Drawing.Point(75, 577);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 70);
            this.button7.TabIndex = 7;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Triangle3D_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.BackColor = System.Drawing.Color.White;
            this.Ellipse.Image = global::VectorNewWAY.Properties.Resources.ellipse;
            this.Ellipse.Location = new System.Drawing.Point(153, 343);
            this.Ellipse.Margin = new System.Windows.Forms.Padding(4);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(70, 70);
            this.Ellipse.TabIndex = 6;
            this.Ellipse.UseVisualStyleBackColor = false;
            this.Ellipse.Click += new System.EventHandler(this.Ellipse_Click);
            // 
            // Circle_2d
            // 
            this.Circle_2d.BackColor = System.Drawing.Color.White;
            this.Circle_2d.Image = global::VectorNewWAY.Properties.Resources.dry_clean;
            this.Circle_2d.Location = new System.Drawing.Point(75, 265);
            this.Circle_2d.Margin = new System.Windows.Forms.Padding(4);
            this.Circle_2d.Name = "Circle_2d";
            this.Circle_2d.Size = new System.Drawing.Size(70, 70);
            this.Circle_2d.TabIndex = 5;
            this.Circle_2d.UseVisualStyleBackColor = false;
            this.Circle_2d.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Square
            // 
            this.Square.BackColor = System.Drawing.Color.White;
            this.Square.Image = global::VectorNewWAY.Properties.Resources.square;
            this.Square.Location = new System.Drawing.Point(75, 187);
            this.Square.Margin = new System.Windows.Forms.Padding(4);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(70, 70);
            this.Square.TabIndex = 4;
            this.Square.UseVisualStyleBackColor = false;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Rectangle_2d
            // 
            this.Rectangle_2d.BackColor = System.Drawing.Color.White;
            this.Rectangle_2d.Image = global::VectorNewWAY.Properties.Resources.rectangle;
            this.Rectangle_2d.Location = new System.Drawing.Point(153, 265);
            this.Rectangle_2d.Margin = new System.Windows.Forms.Padding(4);
            this.Rectangle_2d.Name = "Rectangle_2d";
            this.Rectangle_2d.Size = new System.Drawing.Size(70, 70);
            this.Rectangle_2d.TabIndex = 3;
            this.Rectangle_2d.UseVisualStyleBackColor = false;
            this.Rectangle_2d.Click += new System.EventHandler(this.Rectangle_2d_Click);
            // 
            // LineND
            // 
            this.LineND.BackColor = System.Drawing.Color.White;
            this.LineND.Image = global::VectorNewWAY.Properties.Resources.graph;
            this.LineND.Location = new System.Drawing.Point(153, 187);
            this.LineND.Margin = new System.Windows.Forms.Padding(4);
            this.LineND.Name = "LineND";
            this.LineND.Size = new System.Drawing.Size(70, 70);
            this.LineND.TabIndex = 2;
            this.LineND.UseVisualStyleBackColor = false;
            this.LineND.Click += new System.EventHandler(this.LineND_Click);
            // 
            // Brush
            // 
            this.Brush.BackColor = System.Drawing.Color.White;
            this.Brush.Image = global::VectorNewWAY.Properties.Resources.paint_brush__2_;
            this.Brush.Location = new System.Drawing.Point(75, 109);
            this.Brush.Margin = new System.Windows.Forms.Padding(4);
            this.Brush.Name = "Brush";
            this.Brush.Size = new System.Drawing.Size(70, 70);
            this.Brush.TabIndex = 1;
            this.Brush.UseVisualStyleBackColor = false;
            this.Brush.Click += new System.EventHandler(this.Brush_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(429, 120);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(649, 515);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1095, 650);
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.FILL);
            this.Controls.Add(this.radioButtonPeak);
            this.Controls.Add(this.radioButtonScale);
            this.Controls.Add(this.radioButtonRotate);
            this.Controls.Add(this.radioButtonMoveMode);
            this.Controls.Add(this.radioButtonPaintMode);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.NanglesFigure);
            this.Controls.Add(this._anglesNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorPalete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackPenWidth);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.Line2D);
            this.Controls.Add(this.FigureND);
            this.Controls.Add(this.IsoscelesTriangle);
            this.Controls.Add(this.RectTriangleButton);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Ellipse);
            this.Controls.Add(this.Circle_2d);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.Rectangle_2d);
            this.Controls.Add(this.LineND);
            this.Controls.Add(this.Brush);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackPenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._anglesNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Brush;
        private System.Windows.Forms.Button LineND;
        private System.Windows.Forms.Button Rectangle_2d;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Circle_2d;
        private System.Windows.Forms.Button Ellipse;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button RectTriangleButton;
        private System.Windows.Forms.Button IsoscelesTriangle;
        private System.Windows.Forms.Button FigureND;
        private System.Windows.Forms.Button Line2D;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.TrackBar trackPenWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label colorPalete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown _anglesNumber;
        private System.Windows.Forms.Button NanglesFigure;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.RadioButton radioButtonPaintMode;
        private System.Windows.Forms.RadioButton radioButtonMoveMode;
        private System.Windows.Forms.RadioButton radioButtonRotate;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButtonScale;
        private System.Windows.Forms.RadioButton radioButtonPeak;
        private System.Windows.Forms.RadioButton FILL;
        private System.Windows.Forms.RadioButton colorPicker;
    }
}

