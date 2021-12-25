
namespace BitOperatorTest
{
    partial class frmBitOperation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnXOR = new System.Windows.Forms.Button();
            this.txtHex1 = new System.Windows.Forms.TextBox();
            this.txtHex2 = new System.Windows.Forms.TextBox();
            this.txtDec1 = new System.Windows.Forms.TextBox();
            this.txtBin1 = new System.Windows.Forms.TextBox();
            this.txtBin2 = new System.Windows.Forms.TextBox();
            this.txtDec2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAND = new System.Windows.Forms.Button();
            this.btnOR = new System.Windows.Forms.Button();
            this.btnRshift = new System.Windows.Forms.Button();
            this.btnLshift = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 260);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(519, 232);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 22);
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("D2Coding", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtResult.Location = new System.Drawing.Point(6, 20);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(608, 206);
            this.txtResult.TabIndex = 99;
            this.txtResult.TabStop = false;
            // 
            // btnXOR
            // 
            this.btnXOR.Location = new System.Drawing.Point(519, 403);
            this.btnXOR.Name = "btnXOR";
            this.btnXOR.Size = new System.Drawing.Size(113, 35);
            this.btnXOR.TabIndex = 3;
            this.btnXOR.Text = "XOR(^)";
            this.btnXOR.UseVisualStyleBackColor = true;
            this.btnXOR.Click += new System.EventHandler(this.btnXOR_Click);
            // 
            // txtHex1
            // 
            this.txtHex1.Font = new System.Drawing.Font("D2Coding", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtHex1.Location = new System.Drawing.Point(83, 290);
            this.txtHex1.Name = "txtHex1";
            this.txtHex1.Size = new System.Drawing.Size(100, 26);
            this.txtHex1.TabIndex = 1;
            this.txtHex1.Text = "0X0001";
            this.txtHex1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHex1_KeyDown);
            // 
            // txtHex2
            // 
            this.txtHex2.Font = new System.Drawing.Font("D2Coding", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtHex2.Location = new System.Drawing.Point(83, 343);
            this.txtHex2.Name = "txtHex2";
            this.txtHex2.Size = new System.Drawing.Size(100, 26);
            this.txtHex2.TabIndex = 2;
            this.txtHex2.Text = "0X0001";
            this.txtHex2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHex2_KeyDown);
            // 
            // txtDec1
            // 
            this.txtDec1.Font = new System.Drawing.Font("D2Coding", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDec1.Location = new System.Drawing.Point(189, 290);
            this.txtDec1.Name = "txtDec1";
            this.txtDec1.Size = new System.Drawing.Size(82, 26);
            this.txtDec1.TabIndex = 50;
            this.txtDec1.TabStop = false;
            this.txtDec1.Text = "1";
            this.txtDec1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDec1_KeyDown);
            // 
            // txtBin1
            // 
            this.txtBin1.Font = new System.Drawing.Font("D2Coding", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBin1.Location = new System.Drawing.Point(277, 290);
            this.txtBin1.Name = "txtBin1";
            this.txtBin1.Size = new System.Drawing.Size(163, 26);
            this.txtBin1.TabIndex = 51;
            this.txtBin1.TabStop = false;
            this.txtBin1.Text = "0000 0000 0000 0001";
            this.txtBin1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBin1_KeyDown);
            this.txtBin1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBin1_KeyPress);
            // 
            // txtBin2
            // 
            this.txtBin2.Font = new System.Drawing.Font("D2Coding", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBin2.Location = new System.Drawing.Point(277, 343);
            this.txtBin2.Name = "txtBin2";
            this.txtBin2.Size = new System.Drawing.Size(163, 26);
            this.txtBin2.TabIndex = 10;
            this.txtBin2.TabStop = false;
            this.txtBin2.Text = "0000 0000 0000 0001";
            this.txtBin2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBin2_KeyDown);
            this.txtBin2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBin2_KeyPress);
            // 
            // txtDec2
            // 
            this.txtDec2.Font = new System.Drawing.Font("D2Coding", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDec2.Location = new System.Drawing.Point(189, 343);
            this.txtDec2.Name = "txtDec2";
            this.txtDec2.Size = new System.Drawing.Size(82, 26);
            this.txtDec2.TabIndex = 60;
            this.txtDec2.TabStop = false;
            this.txtDec2.Text = "1";
            this.txtDec2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDec2_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 101;
            this.label1.Text = "피연산자1 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 101;
            this.label2.Text = "Decimal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 101;
            this.label3.Text = "Binary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 101;
            this.label4.Text = "Hexadecimal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 12);
            this.label5.TabIndex = 101;
            this.label5.Text = "Decimal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 101;
            this.label6.Text = "Binary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 12);
            this.label7.TabIndex = 101;
            this.label7.Text = "피연산자2 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 12);
            this.label8.TabIndex = 101;
            this.label8.Text = "Hexadecimal";
            // 
            // btnAND
            // 
            this.btnAND.Location = new System.Drawing.Point(400, 403);
            this.btnAND.Name = "btnAND";
            this.btnAND.Size = new System.Drawing.Size(113, 35);
            this.btnAND.TabIndex = 3;
            this.btnAND.Text = "AND(&&)";
            this.btnAND.UseVisualStyleBackColor = true;
            this.btnAND.Click += new System.EventHandler(this.btnAND_Click);
            // 
            // btnOR
            // 
            this.btnOR.Location = new System.Drawing.Point(281, 403);
            this.btnOR.Name = "btnOR";
            this.btnOR.Size = new System.Drawing.Size(113, 35);
            this.btnOR.TabIndex = 3;
            this.btnOR.Text = "OR(|)";
            this.btnOR.UseVisualStyleBackColor = true;
            this.btnOR.Click += new System.EventHandler(this.btnOR_Click);
            // 
            // btnRshift
            // 
            this.btnRshift.Location = new System.Drawing.Point(162, 403);
            this.btnRshift.Name = "btnRshift";
            this.btnRshift.Size = new System.Drawing.Size(113, 35);
            this.btnRshift.TabIndex = 3;
            this.btnRshift.Text = "Shift Right(>>)";
            this.btnRshift.UseVisualStyleBackColor = true;
            this.btnRshift.Click += new System.EventHandler(this.btnRshift_Click);
            // 
            // btnLshift
            // 
            this.btnLshift.Location = new System.Drawing.Point(43, 403);
            this.btnLshift.Name = "btnLshift";
            this.btnLshift.Size = new System.Drawing.Size(113, 35);
            this.btnLshift.TabIndex = 3;
            this.btnLshift.Text = "Shift Left(<<)";
            this.btnLshift.UseVisualStyleBackColor = true;
            this.btnLshift.Click += new System.EventHandler(this.btnLshift_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(519, 362);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(113, 35);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmBitOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHex2);
            this.Controls.Add(this.txtBin2);
            this.Controls.Add(this.txtBin1);
            this.Controls.Add(this.txtDec2);
            this.Controls.Add(this.txtDec1);
            this.Controls.Add(this.txtHex1);
            this.Controls.Add(this.btnLshift);
            this.Controls.Add(this.btnRshift);
            this.Controls.Add(this.btnOR);
            this.Controls.Add(this.btnAND);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnXOR);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBitOperation";
            this.Text = "BitOperation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnXOR;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtHex1;
        private System.Windows.Forms.TextBox txtHex2;
        private System.Windows.Forms.TextBox txtDec1;
        private System.Windows.Forms.TextBox txtBin1;
        private System.Windows.Forms.TextBox txtBin2;
        private System.Windows.Forms.TextBox txtDec2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAND;
        private System.Windows.Forms.Button btnOR;
        private System.Windows.Forms.Button btnRshift;
        private System.Windows.Forms.Button btnLshift;
        private System.Windows.Forms.Button btnTest;
    }
}

