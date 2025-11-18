namespace KeyTest
{
    partial class KeyTest
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
            console.Location = new Point(274, 0);
            console.Name = "console";
            console.Size = new Size(381, 438);
            console.TabIndex = 0;
            console.Text = "";
            console.KeyDown += KeyTest_KeyDown;
            console.KeyUp += KeyTest_KeyUp;
            // 
            // KeyTest
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(console);
            Name = "KeyTest";
            Text = "Form1";
            KeyDown += KeyTest_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox console;
    }
}
