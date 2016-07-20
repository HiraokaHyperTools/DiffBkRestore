namespace DiffBkRestore {
    partial class VerifyForm {
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
            this.components = new System.ComponentModel.Container();
            this.lWIP = new System.Windows.Forms.Label();
            this.pbWIP = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvF = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.lDone = new System.Windows.Forms.Label();
            this.llRep = new System.Windows.Forms.LinkLabel();
            this.lPos = new System.Windows.Forms.Label();
            this.chA = new System.Windows.Forms.ColumnHeader();
            this.chPlace = new System.Windows.Forms.ColumnHeader();
            this.chHashfp = new System.Windows.Forms.ColumnHeader();
            this.cmsF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mSel = new System.Windows.Forms.ToolStripMenuItem();
            this.mHash = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbWIP)).BeginInit();
            this.cmsF.SuspendLayout();
            this.SuspendLayout();
            // 
            // lWIP
            // 
            this.lWIP.AutoSize = true;
            this.lWIP.Location = new System.Drawing.Point(66, 9);
            this.lWIP.Name = "lWIP";
            this.lWIP.Size = new System.Drawing.Size(84, 12);
            this.lWIP.TabIndex = 0;
            this.lWIP.Text = "検査しています。";
            // 
            // pbWIP
            // 
            this.pbWIP.Image = global::DiffBkRestore.Properties.Resources.FINDFILE16;
            this.pbWIP.Location = new System.Drawing.Point(12, 9);
            this.pbWIP.Name = "pbWIP";
            this.pbWIP.Size = new System.Drawing.Size(48, 50);
            this.pbWIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWIP.TabIndex = 1;
            this.pbWIP.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "問題のあるエントリ：";
            // 
            // lvF
            // 
            this.lvF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvF.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chA,
            this.chPlace,
            this.chHashfp});
            this.lvF.ContextMenuStrip = this.cmsF;
            this.lvF.FullRowSelect = true;
            this.lvF.GridLines = true;
            this.lvF.Location = new System.Drawing.Point(12, 77);
            this.lvF.MultiSelect = false;
            this.lvF.Name = "lvF";
            this.lvF.Size = new System.Drawing.Size(528, 242);
            this.lvF.TabIndex = 3;
            this.lvF.UseCompatibleStateImageBehavior = false;
            this.lvF.View = System.Windows.Forms.View.Details;
            this.lvF.ItemActivate += new System.EventHandler(this.lvF_ItemActivate);
            // 
            // chName
            // 
            this.chName.Text = "ファイル名称";
            this.chName.Width = 150;
            // 
            // lDone
            // 
            this.lDone.AutoSize = true;
            this.lDone.Location = new System.Drawing.Point(66, 21);
            this.lDone.Name = "lDone";
            this.lDone.Size = new System.Drawing.Size(107, 12);
            this.lDone.TabIndex = 4;
            this.lDone.Text = "検査が完了しました。";
            this.lDone.Visible = false;
            // 
            // llRep
            // 
            this.llRep.AutoSize = true;
            this.llRep.Location = new System.Drawing.Point(179, 21);
            this.llRep.Name = "llRep";
            this.llRep.Size = new System.Drawing.Size(69, 12);
            this.llRep.TabIndex = 5;
            this.llRep.TabStop = true;
            this.llRep.Text = "問題の報告...";
            this.llRep.Visible = false;
            this.llRep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRep_LinkClicked);
            // 
            // lPos
            // 
            this.lPos.AutoSize = true;
            this.lPos.Location = new System.Drawing.Point(66, 33);
            this.lPos.Name = "lPos";
            this.lPos.Size = new System.Drawing.Size(11, 12);
            this.lPos.TabIndex = 6;
            this.lPos.Text = "...";
            // 
            // chA
            // 
            this.chA.Text = "どんな問題?";
            this.chA.Width = 80;
            // 
            // chPlace
            // 
            this.chPlace.Text = "場所";
            this.chPlace.Width = 200;
            // 
            // chHashfp
            // 
            this.chHashfp.Text = "ハッシュファイル";
            // 
            // cmsF
            // 
            this.cmsF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSel,
            this.mHash});
            this.cmsF.Name = "cmsF";
            this.cmsF.Size = new System.Drawing.Size(192, 48);
            // 
            // mSel
            // 
            this.mSel.Name = "mSel";
            this.mSel.Size = new System.Drawing.Size(191, 22);
            this.mSel.Text = "選択する";
            this.mSel.Click += new System.EventHandler(this.mSel_Click);
            // 
            // mHash
            // 
            this.mHash.Name = "mHash";
            this.mHash.Size = new System.Drawing.Size(191, 22);
            this.mHash.Text = "ハッシュファイルを参照する";
            this.mHash.Click += new System.EventHandler(this.mSel_Click);
            // 
            // VerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 331);
            this.Controls.Add(this.lPos);
            this.Controls.Add(this.llRep);
            this.Controls.Add(this.lDone);
            this.Controls.Add(this.lvF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbWIP);
            this.Controls.Add(this.lWIP);
            this.MinimumSize = new System.Drawing.Size(299, 172);
            this.Name = "VerifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerifyForm";
            this.Load += new System.EventHandler(this.VerifyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWIP)).EndInit();
            this.cmsF.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lWIP;
        private System.Windows.Forms.PictureBox pbWIP;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ListView lvF;
        private System.Windows.Forms.Label lDone;
        private System.Windows.Forms.LinkLabel llRep;
        private System.Windows.Forms.Label lPos;
        private System.Windows.Forms.ColumnHeader chA;
        internal System.Windows.Forms.ColumnHeader chPlace;
        internal System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chHashfp;
        private System.Windows.Forms.ContextMenuStrip cmsF;
        private System.Windows.Forms.ToolStripMenuItem mSel;
        private System.Windows.Forms.ToolStripMenuItem mHash;
    }
}