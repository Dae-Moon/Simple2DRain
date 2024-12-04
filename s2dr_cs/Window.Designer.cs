namespace s2dr_cs
{
    partial class Window
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
            panel_settings = new Panel();
            tb_thickness = new TextBox();
            label7 = new Label();
            tb_angle = new TextBox();
            label6 = new Label();
            tb_size = new TextBox();
            label5 = new Label();
            tb_speed = new TextBox();
            label4 = new Label();
            tb_amount = new TextBox();
            label3 = new Label();
            tb_color_alpha = new TextBox();
            label2 = new Label();
            btn_color_picker = new Button();
            pb_display = new PictureBox();
            label1 = new Label();
            panel_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_display).BeginInit();
            SuspendLayout();
            // 
            // panel_settings
            // 
            panel_settings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel_settings.BorderStyle = BorderStyle.FixedSingle;
            panel_settings.Controls.Add(tb_thickness);
            panel_settings.Controls.Add(label7);
            panel_settings.Controls.Add(tb_angle);
            panel_settings.Controls.Add(label6);
            panel_settings.Controls.Add(tb_size);
            panel_settings.Controls.Add(label5);
            panel_settings.Controls.Add(tb_speed);
            panel_settings.Controls.Add(label4);
            panel_settings.Controls.Add(tb_amount);
            panel_settings.Controls.Add(label3);
            panel_settings.Controls.Add(tb_color_alpha);
            panel_settings.Controls.Add(label2);
            panel_settings.Controls.Add(btn_color_picker);
            panel_settings.Location = new Point(12, 30);
            panel_settings.Name = "panel_settings";
            panel_settings.Size = new Size(140, 519);
            panel_settings.TabIndex = 0;
            // 
            // tb_thickness
            // 
            tb_thickness.Location = new Point(83, 177);
            tb_thickness.Name = "tb_thickness";
            tb_thickness.Size = new Size(34, 23);
            tb_thickness.TabIndex = 12;
            tb_thickness.Text = "1";
            tb_thickness.TextAlign = HorizontalAlignment.Center;
            tb_thickness.TextChanged += tb_thickness_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 180);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 11;
            label7.Text = "Thickness :";
            // 
            // tb_angle
            // 
            tb_angle.Location = new Point(83, 148);
            tb_angle.Name = "tb_angle";
            tb_angle.Size = new Size(34, 23);
            tb_angle.TabIndex = 10;
            tb_angle.Text = "90";
            tb_angle.TextAlign = HorizontalAlignment.Center;
            tb_angle.TextChanged += tb_angle_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 151);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 9;
            label6.Text = "Angle :";
            // 
            // tb_size
            // 
            tb_size.Location = new Point(83, 119);
            tb_size.Name = "tb_size";
            tb_size.Size = new Size(34, 23);
            tb_size.TabIndex = 8;
            tb_size.Text = "50";
            tb_size.TextAlign = HorizontalAlignment.Center;
            tb_size.TextChanged += tb_size_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 122);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 7;
            label5.Text = "Size :";
            // 
            // tb_speed
            // 
            tb_speed.Location = new Point(83, 90);
            tb_speed.Name = "tb_speed";
            tb_speed.Size = new Size(34, 23);
            tb_speed.TabIndex = 6;
            tb_speed.Text = "3";
            tb_speed.TextAlign = HorizontalAlignment.Center;
            tb_speed.TextChanged += tb_speed_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 93);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 5;
            label4.Text = "Speed :";
            // 
            // tb_amount
            // 
            tb_amount.Location = new Point(83, 61);
            tb_amount.Name = "tb_amount";
            tb_amount.Size = new Size(34, 23);
            tb_amount.TabIndex = 4;
            tb_amount.Text = "100";
            tb_amount.TextAlign = HorizontalAlignment.Center;
            tb_amount.TextChanged += tb_amount_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 64);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Amount :";
            // 
            // tb_color_alpha
            // 
            tb_color_alpha.Location = new Point(83, 32);
            tb_color_alpha.Name = "tb_color_alpha";
            tb_color_alpha.Size = new Size(34, 23);
            tb_color_alpha.TabIndex = 2;
            tb_color_alpha.Text = "255";
            tb_color_alpha.TextAlign = HorizontalAlignment.Center;
            tb_color_alpha.TextChanged += tb_color_alpha_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 35);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 1;
            label2.Text = "Color alpha :";
            // 
            // btn_color_picker
            // 
            btn_color_picker.Location = new Point(3, 3);
            btn_color_picker.Name = "btn_color_picker";
            btn_color_picker.Size = new Size(132, 23);
            btn_color_picker.TabIndex = 0;
            btn_color_picker.Text = "Color";
            btn_color_picker.UseVisualStyleBackColor = true;
            btn_color_picker.Click += btn_color_picker_Click;
            // 
            // pb_display
            // 
            pb_display.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pb_display.Location = new Point(158, 12);
            pb_display.Name = "pb_display";
            pb_display.Size = new Size(614, 537);
            pb_display.TabIndex = 1;
            pb_display.TabStop = false;
            pb_display.Paint += pb_display_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = "Settings";
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(label1);
            Controls.Add(pb_display);
            Controls.Add(panel_settings);
            Name = "Window";
            ShowIcon = false;
            Text = "Simple 2D Rain";
            panel_settings.ResumeLayout(false);
            panel_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_display).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel_settings;
        private PictureBox pb_display;
        private Label label1;
        private Button btn_color_picker;
        private TextBox tb_color_alpha;
        private Label label2;
        private TextBox tb_amount;
        private Label label3;
        private TextBox tb_speed;
        private Label label4;
        private TextBox tb_size;
        private Label label5;
        private TextBox tb_angle;
        private Label label6;
        private TextBox tb_thickness;
        private Label label7;
    }
}
