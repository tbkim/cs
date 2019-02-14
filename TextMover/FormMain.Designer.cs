namespace TextMover
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMoveTxt = new System.Windows.Forms.Button();
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.txtBoxRecv = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnMoveTxt
            // 
            this.btnMoveTxt.Location = new System.Drawing.Point(27, 210);
            this.btnMoveTxt.Name = "btnMoveTxt";
            this.btnMoveTxt.Size = new System.Drawing.Size(113, 23);
            this.btnMoveTxt.TabIndex = 1;
            this.btnMoveTxt.Text = "문자 옮기기";
            this.btnMoveTxt.UseVisualStyleBackColor = true;
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Location = new System.Drawing.Point(27, 13);
            this.txtBoxSend.MaxLength = 5;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.Size = new System.Drawing.Size(100, 21);
            this.txtBoxSend.TabIndex = 0;
            // 
            // txtBoxRecv
            // 
            this.txtBoxRecv.Enabled = false;
            this.txtBoxRecv.Location = new System.Drawing.Point(160, 12);
            this.txtBoxRecv.MaxLength = 5;
            this.txtBoxRecv.Name = "txtBoxRecv";
            this.txtBoxRecv.Size = new System.Drawing.Size(100, 21);
            this.txtBoxRecv.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtBoxRecv);
            this.Controls.Add(this.txtBoxSend);
            this.Controls.Add(this.btnMoveTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Text Mover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMoveTxt;
        private System.Windows.Forms.TextBox txtBoxSend;
        private System.Windows.Forms.TextBox txtBoxRecv;
    }
}

