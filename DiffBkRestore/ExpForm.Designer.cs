namespace DiffBkRestore {
    partial class ExpForm {
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
            this.lPos = new System.Windows.Forms.Label();
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.bwExp = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.lve = new System.Windows.Forms.ListView();
            this.chfp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lPos
            // 
            this.lPos.AutoSize = true;
            this.lPos.Location = new System.Drawing.Point(12, 9);
            this.lPos.Name = "lPos";
            this.lPos.Size = new System.Drawing.Size(11, 12);
            this.lPos.TabIndex = 0;
            this.lPos.Text = "...";
            // 
            // pbTotal
            // 
            this.pbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTotal.Location = new System.Drawing.Point(12, 53);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(620, 23);
            this.pbTotal.TabIndex = 1;
            // 
            // bwExp
            // 
            this.bwExp.WorkerReportsProgress = true;
            this.bwExp.WorkerSupportsCancellation = true;
            this.bwExp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwExp_ProgressChanged);
            this.bwExp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwExp_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "問題：";
            // 
            // lve
            // 
            this.lve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lve.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfp,
            this.chMes});
            this.lve.FullRowSelect = true;
            this.lve.GridLines = true;
            this.lve.HideSelection = false;
            this.lve.Location = new System.Drawing.Point(12, 110);
            this.lve.MultiSelect = false;
            this.lve.Name = "lve";
            this.lve.Size = new System.Drawing.Size(620, 161);
            this.lve.TabIndex = 3;
            this.lve.UseCompatibleStateImageBehavior = false;
            this.lve.View = System.Windows.Forms.View.Details;
            // 
            // chfp
            // 
            this.chfp.Text = "ファイルパス";
            this.chfp.Width = 200;
            // 
            // chMes
            // 
            this.chMes.Text = "メッセージ";
            this.chMes.Width = 200;
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bStop.Location = new System.Drawing.Point(557, 24);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 4;
            this.bStop.Text = "中止";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // ExpForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(644, 281);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.lve);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTotal);
            this.Controls.Add(this.lPos);
            this.MinimumSize = new System.Drawing.Size(480, 265);
            this.Name = "ExpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "復元中...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExpForm_FormClosing);
            this.Load += new System.EventHandler(this.ExpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lPos;
        private System.Windows.Forms.ProgressBar pbTotal;
        internal System.ComponentModel.BackgroundWorker bwExp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lve;
        private System.Windows.Forms.ColumnHeader chfp;
        private System.Windows.Forms.ColumnHeader chMes;
        private System.Windows.Forms.Button bStop;

    }
}