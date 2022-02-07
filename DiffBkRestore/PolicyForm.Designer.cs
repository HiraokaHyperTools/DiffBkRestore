namespace DiffBkRestore {
    partial class PolicyForm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.gOverw = new System.Windows.Forms.GroupBox();
            this.rbOverw = new System.Windows.Forms.RadioButton();
            this.rbSkip = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbStop = new System.Windows.Forms.RadioButton();
            this.rbCont = new System.Windows.Forms.RadioButton();
            this.bOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statText = new System.Windows.Forms.Label();
            this.gOverw.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gOverw
            // 
            this.gOverw.Controls.Add(this.rbOverw);
            this.gOverw.Controls.Add(this.rbSkip);
            this.gOverw.Location = new System.Drawing.Point(12, 12);
            this.gOverw.Name = "gOverw";
            this.gOverw.Size = new System.Drawing.Size(226, 89);
            this.gOverw.TabIndex = 0;
            this.gOverw.TabStop = false;
            this.gOverw.Text = "同じファイルが存在する場合：";
            // 
            // rbOverw
            // 
            this.rbOverw.AutoSize = true;
            this.rbOverw.Checked = true;
            this.rbOverw.Location = new System.Drawing.Point(6, 40);
            this.rbOverw.Name = "rbOverw";
            this.rbOverw.Size = new System.Drawing.Size(153, 16);
            this.rbOverw.TabIndex = 1;
            this.rbOverw.TabStop = true;
            this.rbOverw.Text = "上書きします。確認なしで。";
            this.rbOverw.UseVisualStyleBackColor = true;
            // 
            // rbSkip
            // 
            this.rbSkip.AutoSize = true;
            this.rbSkip.Location = new System.Drawing.Point(6, 18);
            this.rbSkip.Name = "rbSkip";
            this.rbSkip.Size = new System.Drawing.Size(94, 16);
            this.rbSkip.TabIndex = 0;
            this.rbSkip.Text = "スキップします。";
            this.rbSkip.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbStop);
            this.groupBox1.Controls.Add(this.rbCont);
            this.groupBox1.Location = new System.Drawing.Point(12, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "エラーが発生した場合：";
            // 
            // rbStop
            // 
            this.rbStop.AutoSize = true;
            this.rbStop.Location = new System.Drawing.Point(6, 40);
            this.rbStop.Name = "rbStop";
            this.rbStop.Size = new System.Drawing.Size(83, 16);
            this.rbStop.TabIndex = 1;
            this.rbStop.Text = "中止します。";
            this.rbStop.UseVisualStyleBackColor = true;
            // 
            // rbCont
            // 
            this.rbCont.AutoSize = true;
            this.rbCont.Checked = true;
            this.rbCont.Location = new System.Drawing.Point(6, 18);
            this.rbCont.Name = "rbCont";
            this.rbCont.Size = new System.Drawing.Size(83, 16);
            this.rbCont.TabIndex = 0;
            this.rbCont.TabStop = true;
            this.rbCont.Text = "続行します。";
            this.rbCont.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(12, 275);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 2;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statText);
            this.groupBox2.Location = new System.Drawing.Point(12, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "概要";
            // 
            // statText
            // 
            this.statText.AutoSize = true;
            this.statText.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statText.Location = new System.Drawing.Point(6, 15);
            this.statText.Name = "statText";
            this.statText.Size = new System.Drawing.Size(23, 12);
            this.statText.TabIndex = 0;
            this.statText.Text = "...";
            // 
            // PolicyForm
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(255, 314);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gOverw);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolicyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PolicyForm";
            this.Load += new System.EventHandler(this.PolicyForm_Load);
            this.gOverw.ResumeLayout(false);
            this.gOverw.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gOverw;
        private System.Windows.Forms.RadioButton rbOverw;
        private System.Windows.Forms.RadioButton rbSkip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbStop;
        private System.Windows.Forms.RadioButton rbCont;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label statText;
    }
}