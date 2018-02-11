namespace DX3rdChatPaletteCreatorv3
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.urlArea = new System.Windows.Forms.TextBox();
            this.urlAccessButton = new System.Windows.Forms.Button();
            this.labelNameValue = new System.Windows.Forms.Label();
            this.getDataButton = new System.Windows.Forms.Button();
            this.dataGettingProgress = new System.Windows.Forms.ProgressBar();
            this.testlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser.Location = new System.Drawing.Point(0, 25);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(250, 416);
            this.webBrowser.TabIndex = 0;
            // 
            // urlArea
            // 
            this.urlArea.Location = new System.Drawing.Point(0, 0);
            this.urlArea.Name = "urlArea";
            this.urlArea.Size = new System.Drawing.Size(549, 19);
            this.urlArea.TabIndex = 1;
            // 
            // urlAccessButton
            // 
            this.urlAccessButton.Location = new System.Drawing.Point(549, 0);
            this.urlAccessButton.Name = "urlAccessButton";
            this.urlAccessButton.Size = new System.Drawing.Size(75, 23);
            this.urlAccessButton.TabIndex = 2;
            this.urlAccessButton.Text = "アクセス";
            this.urlAccessButton.UseVisualStyleBackColor = true;
            this.urlAccessButton.Click += new System.EventHandler(this.urlAccessButton_Click);
            // 
            // labelNameValue
            // 
            this.labelNameValue.AutoSize = true;
            this.labelNameValue.Location = new System.Drawing.Point(256, 51);
            this.labelNameValue.Name = "labelNameValue";
            this.labelNameValue.Size = new System.Drawing.Size(147, 12);
            this.labelNameValue.TabIndex = 3;
            this.labelNameValue.Text = "ここにメッセージが表示されます";
            // 
            // getDataButton
            // 
            this.getDataButton.Location = new System.Drawing.Point(549, 25);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(75, 23);
            this.getDataButton.TabIndex = 4;
            this.getDataButton.Text = "生成";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // dataGettingProgress
            // 
            this.dataGettingProgress.Location = new System.Drawing.Point(256, 25);
            this.dataGettingProgress.Name = "dataGettingProgress";
            this.dataGettingProgress.Size = new System.Drawing.Size(287, 23);
            this.dataGettingProgress.TabIndex = 5;
            // 
            // testlabel
            // 
            this.testlabel.AutoSize = true;
            this.testlabel.Location = new System.Drawing.Point(256, 229);
            this.testlabel.Name = "testlabel";
            this.testlabel.Size = new System.Drawing.Size(156, 12);
            this.testlabel.TabIndex = 6;
            this.testlabel.Text = "ゆくゆくはここにオプションが出ます";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.testlabel);
            this.Controls.Add(this.dataGettingProgress);
            this.Controls.Add(this.getDataButton);
            this.Controls.Add(this.labelNameValue);
            this.Controls.Add(this.urlAccessButton);
            this.Controls.Add(this.urlArea);
            this.Controls.Add(this.webBrowser);
            this.Name = "Form1";
            this.Text = "ダブルクロス3rdEdition チャットパレットを作りやすくするやつr3 (v1.0)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox urlArea;
        private System.Windows.Forms.Button urlAccessButton;
        private System.Windows.Forms.Label labelNameValue;
        private System.Windows.Forms.Button getDataButton;
        private System.Windows.Forms.ProgressBar dataGettingProgress;
        private System.Windows.Forms.Label testlabel;
    }
}

