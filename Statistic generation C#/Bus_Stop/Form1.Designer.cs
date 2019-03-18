namespace Bus_Stop
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_BusStop = new System.Windows.Forms.Button();
            this.ADTime = new System.Windows.Forms.Button();
            this.btn_LineStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_BusStop
            // 
            this.btn_BusStop.Location = new System.Drawing.Point(0, 0);
            this.btn_BusStop.Name = "btn_BusStop";
            this.btn_BusStop.Size = new System.Drawing.Size(75, 23);
            this.btn_BusStop.TabIndex = 2;
            // 
            // ADTime
            // 
            this.ADTime.Location = new System.Drawing.Point(79, 93);
            this.ADTime.Name = "ADTime";
            this.ADTime.Size = new System.Drawing.Size(129, 35);
            this.ADTime.TabIndex = 1;
            this.ADTime.Text = "每辆车的报站时间";
            this.ADTime.UseVisualStyleBackColor = true;
            this.ADTime.Click += new System.EventHandler(this.ADTime_Click);
            // 
            // btn_LineStop
            // 
            this.btn_LineStop.Location = new System.Drawing.Point(0, 0);
            this.btn_LineStop.Name = "btn_LineStop";
            this.btn_LineStop.Size = new System.Drawing.Size(75, 23);
            this.btn_LineStop.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btn_LineStop);
            this.Controls.Add(this.ADTime);
            this.Controls.Add(this.btn_BusStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bus_Stop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BusStop;
        private System.Windows.Forms.Button ADTime;
        private System.Windows.Forms.Button btn_LineStop;
    }
}

