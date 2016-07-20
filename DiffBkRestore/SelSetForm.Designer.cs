namespace DiffBkRestore {
    partial class SelSetForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvset = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chMt = new System.Windows.Forms.ColumnHeader();
            this.bOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "復元したいバックアップセットを選択してください：";
            // 
            // lvset
            // 
            this.lvset.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chMt});
            this.lvset.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lvset.FullRowSelect = true;
            this.lvset.GridLines = true;
            this.lvset.Location = new System.Drawing.Point(12, 24);
            this.lvset.MultiSelect = false;
            this.lvset.Name = "lvset";
            this.lvset.Size = new System.Drawing.Size(458, 188);
            this.lvset.TabIndex = 1;
            this.lvset.UseCompatibleStateImageBehavior = false;
            this.lvset.View = System.Windows.Forms.View.Details;
            this.lvset.ItemActivate += new System.EventHandler(this.lvset_ItemActivate);
            this.lvset.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvset_ColumnClick);
            // 
            // chName
            // 
            this.chName.Text = "セット名称";
            this.chName.Width = 250;
            // 
            // chMt
            // 
            this.chMt.Text = "更新日時";
            this.chMt.Width = 160;
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(12, 218);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(128, 37);
            this.bOpen.TabIndex = 2;
            this.bOpen.Text = "開く";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // SelSetForm
            // 
            this.AcceptButton = this.bOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 274);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.lvset);
            this.Controls.Add(this.label1);
            this.Name = "SelSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "バックアップセットの選択";
            this.Load += new System.EventHandler(this.SelSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvset;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chMt;
    }
}