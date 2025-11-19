namespace TelloKeyControl
{
    partial class TelloKeyControl
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
            console = new RichTextBox();
            SuspendLayout();
            // 
            // console
            // 
            console.Location = new Point(482, 185);
            console.Name = "console";
            console.Size = new Size(150, 144);
            console.TabIndex = 0;
            console.Text = "";
            console.KeyDown += TelloKeyControl_KeyDown;
            console.KeyUp += TelloKeyControl_KeyUp;
            // 
            // TelloKeyControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(console);
            Name = "TelloKeyControl";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox console;
    }
}
