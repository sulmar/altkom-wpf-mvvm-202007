namespace Altkom.WPFMVVM.WindowsFormsApp
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
            this.bHelloWorld = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bHelloWorld
            // 
            this.bHelloWorld.Location = new System.Drawing.Point(163, 130);
            this.bHelloWorld.Name = "bHelloWorld";
            this.bHelloWorld.Size = new System.Drawing.Size(170, 65);
            this.bHelloWorld.TabIndex = 0;
            this.bHelloWorld.Text = "Hello World!";
            this.bHelloWorld.UseVisualStyleBackColor = true;
            this.bHelloWorld.Click += new System.EventHandler(this.bHelloWorld_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bHelloWorld);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bHelloWorld;
        private System.Windows.Forms.Button button1;
    }
}

