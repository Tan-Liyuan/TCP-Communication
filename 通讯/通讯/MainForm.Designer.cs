
namespace 通讯
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.infoList = new System.Windows.Forms.ListBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.isServer = new System.Windows.Forms.RadioButton();
            this.isClient = new System.Windows.Forms.RadioButton();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoList
            // 
            this.infoList.FormattingEnabled = true;
            this.infoList.ItemHeight = 12;
            this.infoList.Location = new System.Drawing.Point(9, 9);
            this.infoList.Margin = new System.Windows.Forms.Padding(2);
            this.infoList.Name = "infoList";
            this.infoList.Size = new System.Drawing.Size(303, 292);
            this.infoList.TabIndex = 0;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(327, 11);
            this.ipLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(23, 12);
            this.ipLabel.TabIndex = 1;
            this.ipLabel.Text = "IP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "端口:";
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(355, 9);
            this.ipBox.Margin = new System.Windows.Forms.Padding(2);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(138, 21);
            this.ipBox.TabIndex = 3;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(355, 31);
            this.portBox.Margin = new System.Windows.Forms.Padding(2);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(138, 21);
            this.portBox.TabIndex = 4;
            // 
            // isServer
            // 
            this.isServer.AutoSize = true;
            this.isServer.Checked = true;
            this.isServer.Location = new System.Drawing.Point(366, 55);
            this.isServer.Margin = new System.Windows.Forms.Padding(2);
            this.isServer.Name = "isServer";
            this.isServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.isServer.Size = new System.Drawing.Size(59, 16);
            this.isServer.TabIndex = 5;
            this.isServer.TabStop = true;
            this.isServer.Text = "服务器";
            this.isServer.UseVisualStyleBackColor = true;
            // 
            // isClient
            // 
            this.isClient.AutoSize = true;
            this.isClient.Location = new System.Drawing.Point(434, 55);
            this.isClient.Margin = new System.Windows.Forms.Padding(2);
            this.isClient.Name = "isClient";
            this.isClient.Size = new System.Drawing.Size(59, 16);
            this.isClient.TabIndex = 6;
            this.isClient.TabStop = true;
            this.isClient.Text = "客户端";
            this.isClient.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(317, 79);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(2);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(87, 20);
            this.CreateButton.TabIndex = 7;
            this.CreateButton.Text = "创建";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.Create_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(405, 79);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(87, 20);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "关闭";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.Close_Click);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(316, 229);
            this.TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(178, 21);
            this.TextBox.TabIndex = 9;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(316, 254);
            this.Send.Margin = new System.Windows.Forms.Padding(2);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(178, 20);
            this.Send.TabIndex = 10;
            this.Send.Text = "发送消息";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "模式:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 103);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 20);
            this.button1.TabIndex = 12;
            this.button1.Text = "UPnP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 278);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 20);
            this.button2.TabIndex = 13;
            this.button2.Text = "发送文件";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 309);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.isClient);
            this.Controls.Add(this.isServer);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.infoList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "通讯测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitProgram);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.RadioButton isServer;
        private System.Windows.Forms.RadioButton isClient;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox infoList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

