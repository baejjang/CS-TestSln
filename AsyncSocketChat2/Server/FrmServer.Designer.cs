namespace Server
{
    partial class FrmServer
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnSvrClose = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stsLvlSvr = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsLvlSvrState = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "수신된 메시지";
            // 
            // btnSvrClose
            // 
            this.btnSvrClose.Location = new System.Drawing.Point(351, 12);
            this.btnSvrClose.Name = "btnSvrClose";
            this.btnSvrClose.Size = new System.Drawing.Size(103, 37);
            this.btnSvrClose.TabIndex = 1;
            this.btnSvrClose.Text = "서버종료";
            this.btnSvrClose.UseVisualStyleBackColor = true;
            this.btnSvrClose.Click += new System.EventHandler(this.btnSvrClose_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 55);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(442, 395);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsLvlSvr,
            this.stsLvlSvrState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(466, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stsLvlSvr
            // 
            this.stsLvlSvr.Name = "stsLvlSvr";
            this.stsLvlSvr.Size = new System.Drawing.Size(62, 17);
            this.stsLvlSvr.Text = "서버상태 :";
            // 
            // stsLvlSvrState
            // 
            this.stsLvlSvrState.Name = "stsLvlSvrState";
            this.stsLvlSvrState.Size = new System.Drawing.Size(0, 17);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 493);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSvrClose);
            this.Controls.Add(this.label1);
            this.Name = "FrmServer";
            this.Text = "서버";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServer_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSvrClose;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stsLvlSvr;
        private System.Windows.Forms.ToolStripStatusLabel stsLvlSvrState;
    }
}

