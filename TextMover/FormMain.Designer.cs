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
            this.components = new System.ComponentModel.Container();
            this.btnMoveTxt = new System.Windows.Forms.Button();
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.txtBoxRecv = new System.Windows.Forms.TextBox();
            this.timerDelay = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.listViewLog = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMoveTxt
            // 
            this.btnMoveTxt.Location = new System.Drawing.Point(257, 100);
            this.btnMoveTxt.Name = "btnMoveTxt";
            this.btnMoveTxt.Size = new System.Drawing.Size(233, 23);
            this.btnMoveTxt.TabIndex = 2;
            this.btnMoveTxt.Text = "문자 옮기기";
            this.btnMoveTxt.UseVisualStyleBackColor = true;
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Location = new System.Drawing.Point(257, 17);
            this.txtBoxSend.MaxLength = 5;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.Size = new System.Drawing.Size(100, 21);
            this.txtBoxSend.TabIndex = 0;
            // 
            // txtBoxRecv
            // 
            this.txtBoxRecv.Enabled = false;
            this.txtBoxRecv.Location = new System.Drawing.Point(390, 16);
            this.txtBoxRecv.MaxLength = 5;
            this.txtBoxRecv.Name = "txtBoxRecv";
            this.txtBoxRecv.Size = new System.Drawing.Size(100, 21);
            this.txtBoxRecv.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "실행 지연 시간";
            // 
            // numericUpDownTimeDelay
            // 
            this.numericUpDownTimeDelay.Location = new System.Drawing.Point(390, 57);
            this.numericUpDownTimeDelay.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTimeDelay.Name = "numericUpDownTimeDelay";
            this.numericUpDownTimeDelay.Size = new System.Drawing.Size(100, 21);
            this.numericUpDownTimeDelay.TabIndex = 1;
            // 
            // listViewLog
            // 
            this.listViewLog.Location = new System.Drawing.Point(27, 146);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(463, 97);
            this.listViewLog.TabIndex = 5;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 275);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.numericUpDownTimeDelay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxRecv);
            this.Controls.Add(this.txtBoxSend);
            this.Controls.Add(this.btnMoveTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Text Mover";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMoveTxt;
        private System.Windows.Forms.TextBox txtBoxSend;
        private System.Windows.Forms.TextBox txtBoxRecv;
        private System.Windows.Forms.Timer timerDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeDelay;
        private System.Windows.Forms.ListView listViewLog;
    }
}

