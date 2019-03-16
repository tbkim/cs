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
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.btnClearView = new System.Windows.Forms.Button();
            this.comboBoxThreadType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMoveTxt
            // 
            this.btnMoveTxt.Location = new System.Drawing.Point(27, 105);
            this.btnMoveTxt.Name = "btnMoveTxt";
            this.btnMoveTxt.Size = new System.Drawing.Size(233, 23);
            this.btnMoveTxt.TabIndex = 2;
            this.btnMoveTxt.Text = "문자 옮기기";
            this.btnMoveTxt.UseVisualStyleBackColor = true;
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Location = new System.Drawing.Point(27, 22);
            this.txtBoxSend.MaxLength = 5;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.Size = new System.Drawing.Size(100, 21);
            this.txtBoxSend.TabIndex = 0;
            // 
            // txtBoxRecv
            // 
            this.txtBoxRecv.Enabled = false;
            this.txtBoxRecv.Location = new System.Drawing.Point(160, 21);
            this.txtBoxRecv.MaxLength = 5;
            this.txtBoxRecv.Name = "txtBoxRecv";
            this.txtBoxRecv.Size = new System.Drawing.Size(100, 21);
            this.txtBoxRecv.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "실행 지연 시간";
            // 
            // numericUpDownTimeDelay
            // 
            this.numericUpDownTimeDelay.Location = new System.Drawing.Point(160, 62);
            this.numericUpDownTimeDelay.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTimeDelay.Name = "numericUpDownTimeDelay";
            this.numericUpDownTimeDelay.Size = new System.Drawing.Size(100, 21);
            this.numericUpDownTimeDelay.TabIndex = 1;
            // 
            // listViewInfo
            // 
            this.listViewInfo.FullRowSelect = true;
            this.listViewInfo.Location = new System.Drawing.Point(27, 148);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(407, 163);
            this.listViewInfo.TabIndex = 3;
            this.listViewInfo.UseCompatibleStateImageBehavior = false;
            // 
            // btnClearView
            // 
            this.btnClearView.Location = new System.Drawing.Point(313, 105);
            this.btnClearView.Name = "btnClearView";
            this.btnClearView.Size = new System.Drawing.Size(121, 23);
            this.btnClearView.TabIndex = 4;
            this.btnClearView.Text = "리스트 지우기";
            this.btnClearView.UseVisualStyleBackColor = true;
            // 
            // comboBoxThreadType
            // 
            this.comboBoxThreadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThreadType.FormattingEnabled = true;
            this.comboBoxThreadType.Location = new System.Drawing.Point(313, 64);
            this.comboBoxThreadType.Name = "comboBoxThreadType";
            this.comboBoxThreadType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxThreadType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "타이머타입";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 341);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxThreadType);
            this.Controls.Add(this.btnClearView);
            this.Controls.Add(this.listViewInfo);
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
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.Button btnClearView;
        private System.Windows.Forms.ComboBox comboBoxThreadType;
        private System.Windows.Forms.Label label2;
    }
}

