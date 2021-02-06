
namespace Client
{
    partial class Form1
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
            this.connectButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.ListBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(614, 135);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(174, 43);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(614, 356);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(174, 54);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chat
            // 
            this.chat.FormattingEnabled = true;
            this.chat.ItemHeight = 15;
            this.chat.Location = new System.Drawing.Point(12, 107);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(596, 274);
            this.chat.TabIndex = 2;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(614, 106);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(174, 23);
            this.nameBox.TabIndex = 3;
            this.nameBox.Text = "name";
            this.nameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.connectButton_KeyDown);
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(614, 184);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(115, 23);
            this.ipBox.TabIndex = 4;
            this.ipBox.Text = "127.0.0.1";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(735, 184);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(53, 23);
            this.portBox.TabIndex = 5;
            this.portBox.Text = "6060";
            // 
            // messageBox
            // 
            this.messageBox.Enabled = false;
            this.messageBox.Location = new System.Drawing.Point(12, 387);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(596, 23);
            this.messageBox.TabIndex = 6;
            this.messageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(799, 421);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox chat;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox messageBox;
    }
}

