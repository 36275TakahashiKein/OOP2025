namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btGoForward = new Button();
            btGoBack = new Button();
            cbUrl = new ComboBox();
            btFavorite = new Button();
            tbSource = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(697, 13);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(110, 44);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(14, 100);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(813, 214);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(14, 356);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(813, 268);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.SourceChanged += webView21_SourceChanged;
            // 
            // btGoForward
            // 
            btGoForward.Location = new Point(93, 13);
            btGoForward.Name = "btGoForward";
            btGoForward.Size = new Size(74, 40);
            btGoForward.TabIndex = 4;
            btGoForward.Text = "進む";
            btGoForward.UseVisualStyleBackColor = true;
            btGoForward.Click += btGoForward_Click;
            // 
            // btGoBack
            // 
            btGoBack.Location = new Point(12, 12);
            btGoBack.Name = "btGoBack";
            btGoBack.Size = new Size(75, 40);
            btGoBack.TabIndex = 5;
            btGoBack.Text = "戻る";
            btGoBack.UseVisualStyleBackColor = true;
            btGoBack.Click += btGoBack_Click;
            // 
            // cbUrl
            // 
            cbUrl.FormattingEnabled = true;
            cbUrl.Location = new Point(183, 23);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(431, 23);
            cbUrl.TabIndex = 6;
            // 
            // btFavorite
            // 
            btFavorite.Location = new Point(626, 14);
            btFavorite.Name = "btFavorite";
            btFavorite.Size = new Size(65, 36);
            btFavorite.TabIndex = 7;
            btFavorite.Text = "★";
            btFavorite.UseVisualStyleBackColor = true;
            btFavorite.Click += btFavorite_Click;
            // 
            // tbSource
            // 
            tbSource.Location = new Point(401, 66);
            tbSource.Name = "tbSource";
            tbSource.Size = new Size(264, 23);
            tbSource.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(199, 59);
            button1.Name = "button1";
            button1.Size = new Size(77, 35);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 636);
            Controls.Add(button1);
            Controls.Add(tbSource);
            Controls.Add(btFavorite);
            Controls.Add(cbUrl);
            Controls.Add(btGoBack);
            Controls.Add(btGoForward);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "RSSリーダー";
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btGoForward;
        private Button btGoBack;
        private ComboBox cbUrl;
        private Button btFavorite;
        private TextBox tbSource;
        private Button button1;
    }
}
