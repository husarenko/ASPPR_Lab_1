namespace Lab_1
{
    partial class ProtocolForm
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
            protocol_textBox = new TextBox();
            SuspendLayout();
            // 
            // protocol_textBox
            // 
            protocol_textBox.Location = new Point(12, 12);
            protocol_textBox.Multiline = true;
            protocol_textBox.Name = "protocol_textBox";
            protocol_textBox.ReadOnly = true;
            protocol_textBox.ScrollBars = ScrollBars.Vertical;
            protocol_textBox.Size = new Size(776, 426);
            protocol_textBox.TabIndex = 0;
            // 
            // ProtocolForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(protocol_textBox);
            Name = "ProtocolForm";
            Text = "протокол обчислень";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox protocol_textBox;
    }
}