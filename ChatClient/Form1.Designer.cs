
namespace ChatClient
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
            this.connectButtom = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // connectButtom
            // 
            this.connectButtom.Location = new System.Drawing.Point(637, 105);
            this.connectButtom.Name = "connectButtom";
            this.connectButtom.Size = new System.Drawing.Size(151, 73);
            this.connectButtom.TabIndex = 0;
            this.connectButtom.Text = "Connect to chat";
            this.connectButtom.UseVisualStyleBackColor = true;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(637, 76);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(151, 23);
            this.name.TabIndex = 1;
            this.name.Text = "name";
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(638, 184);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(104, 23);
            this.ipBox.TabIndex = 2;
            this.ipBox.Text = "127.0.0.1";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(747, 184);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(41, 23);
            this.portBox.TabIndex = 3;
            this.portBox.Text = "6060";
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 379);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(620, 59);
            this.messageBox.TabIndex = 4;
            // 
            // sendMessage
            // 
            this.sendMessage.Location = new System.Drawing.Point(638, 379);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(150, 59);
            this.sendMessage.TabIndex = 6;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(619, 349);
            this.listBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.name);
            this.Controls.Add(this.connectButtom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButtom;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.ListBox listBox1;
    }
}

