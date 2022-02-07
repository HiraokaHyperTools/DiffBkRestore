namespace DiffBkRestore {
    partial class RForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RForm));
            this.tstop = new System.Windows.Forms.ToolStrip();
            this.bOpenDirin = new System.Windows.Forms.ToolStripSplitButton();
            this.bOpenDirwith = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbVerify = new System.Windows.Forms.ToolStripDropDownButton();
            this.bVerifyCache = new System.Windows.Forms.ToolStripMenuItem();
            this.bVerifyCacheHash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bExcDir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bStat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bUsing = new System.Windows.Forms.ToolStripDropDownButton();
            this.bDeveloper = new System.Windows.Forms.ToolStripMenuItem();
            this.bAlphaFS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbFindPat = new System.Windows.Forms.ToolStripTextBox();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.sc = new System.Windows.Forms.SplitContainer();
            this.tvr = new System.Windows.Forms.TreeView();
            this.mTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mExposeDirs = new System.Windows.Forms.ToolStripMenuItem();
            this.mExposeDirsOrgPos = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lvr = new System.Windows.Forms.ListView();
            this.chrFn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chrCb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chrMt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mExposeFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mExposeFilesOrgPos = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tsf = new System.Windows.Forms.ToolStrip();
            this.bFindPat = new System.Windows.Forms.ToolStripButton();
            this.bSearchExcDir = new System.Windows.Forms.ToolStripButton();
            this.bUseRex = new System.Windows.Forms.ToolStripButton();
            this.hsc = new System.Windows.Forms.SplitContainer();
            this.lvres = new System.Windows.Forms.ListView();
            this.chfFn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chfCb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chfMt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chfDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mFindList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mExplodeFindSingleDir = new System.Windows.Forms.ToolStripMenuItem();
            this.mExplodeFindTree = new System.Windows.Forms.ToolStripMenuItem();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.llClose = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.fbdExp = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.tstop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.mTree.SuspendLayout();
            this.mList.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hsc)).BeginInit();
            this.hsc.Panel1.SuspendLayout();
            this.hsc.Panel2.SuspendLayout();
            this.hsc.SuspendLayout();
            this.mFindList.SuspendLayout();
            this.tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tstop
            // 
            this.tstop.Dock = System.Windows.Forms.DockStyle.None;
            this.tstop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOpenDirin,
            this.toolStripSeparator1,
            this.tsddbVerify,
            this.toolStripSeparator2,
            this.bExcDir,
            this.toolStripSeparator3,
            this.bStat,
            this.toolStripSeparator4,
            this.bUsing});
            this.tstop.Location = new System.Drawing.Point(3, 0);
            this.tstop.Name = "tstop";
            this.tstop.Size = new System.Drawing.Size(579, 25);
            this.tstop.TabIndex = 0;
            // 
            // bOpenDirin
            // 
            this.bOpenDirin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOpenDirwith});
            this.bOpenDirin.Image = global::DiffBkRestore.Properties.Resources.openHS;
            this.bOpenDirin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bOpenDirin.Name = "bOpenDirin";
            this.bOpenDirin.Size = new System.Drawing.Size(120, 22);
            this.bOpenDirin.Text = "バックアップを開く";
            this.bOpenDirin.ButtonClick += new System.EventHandler(this.bOpenDirin_ButtonClick);
            // 
            // bOpenDirwith
            // 
            this.bOpenDirwith.Name = "bOpenDirwith";
            this.bOpenDirwith.Size = new System.Drawing.Size(171, 22);
            this.bOpenDirwith.Text = "パスを入力して開く...";
            this.bOpenDirwith.Click += new System.EventHandler(this.bOpenDirwith_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsddbVerify
            // 
            this.tsddbVerify.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bVerifyCache,
            this.bVerifyCacheHash});
            this.tsddbVerify.Image = ((System.Drawing.Image)(resources.GetObject("tsddbVerify.Image")));
            this.tsddbVerify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbVerify.Name = "tsddbVerify";
            this.tsddbVerify.Size = new System.Drawing.Size(170, 22);
            this.tsddbVerify.Text = "バックアップをすべて検証する";
            // 
            // bVerifyCache
            // 
            this.bVerifyCache.Name = "bVerifyCache";
            this.bVerifyCache.Size = new System.Drawing.Size(347, 22);
            this.bVerifyCache.Text = "キャッシュファイルの存在を確認する";
            this.bVerifyCache.Click += new System.EventHandler(this.bVerifyCache_Click);
            // 
            // bVerifyCacheHash
            // 
            this.bVerifyCacheHash.Name = "bVerifyCacheHash";
            this.bVerifyCacheHash.Size = new System.Drawing.Size(347, 22);
            this.bVerifyCacheHash.Text = "キャッシュファイルの存在と、ハッシュ値の正当性を確認する";
            this.bVerifyCacheHash.Click += new System.EventHandler(this.bVerifyCache_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bExcDir
            // 
            this.bExcDir.CheckOnClick = true;
            this.bExcDir.Image = global::DiffBkRestore.Properties.Resources.Book_angleHS;
            this.bExcDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bExcDir.Name = "bExcDir";
            this.bExcDir.Size = new System.Drawing.Size(133, 22);
            this.bExcDir.Text = "フォルダを一覧から省く";
            this.bExcDir.Click += new System.EventHandler(this.bIncDir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bStat
            // 
            this.bStat.Image = global::DiffBkRestore.Properties.Resources.graphhs;
            this.bStat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bStat.Name = "bStat";
            this.bStat.Size = new System.Drawing.Size(51, 22);
            this.bStat.Text = "統計";
            this.bStat.Click += new System.EventHandler(this.bStat_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bUsing
            // 
            this.bUsing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bDeveloper,
            this.bAlphaFS});
            this.bUsing.Image = ((System.Drawing.Image)(resources.GetObject("bUsing.Image")));
            this.bUsing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUsing.Name = "bUsing";
            this.bUsing.Size = new System.Drawing.Size(69, 22);
            this.bUsing.Text = "About";
            // 
            // bDeveloper
            // 
            this.bDeveloper.Name = "bDeveloper";
            this.bDeveloper.Size = new System.Drawing.Size(382, 22);
            this.bDeveloper.Text = "DiffBkRestore developed by HIRAOKA HYPERS TOOLS, Inc.";
            this.bDeveloper.Click += new System.EventHandler(this.bDeveloper_Click);
            // 
            // bAlphaFS
            // 
            this.bAlphaFS.Name = "bAlphaFS";
            this.bAlphaFS.Size = new System.Drawing.Size(382, 22);
            this.bAlphaFS.Text = "- Using AlphaFS";
            this.bAlphaFS.Click += new System.EventHandler(this.bAlphaFS_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(164, 22);
            this.toolStripLabel1.Text = "ファイル・フォルダを検索(Alt+&F)：";
            // 
            // tbFindPat
            // 
            this.tbFindPat.Name = "tbFindPat";
            this.tbFindPat.Size = new System.Drawing.Size(200, 25);
            this.tbFindPat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFindPat_KeyDown);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "D");
            this.il.Images.SetKeyName(1, "F");
            this.il.Images.SetKeyName(2, "S");
            // 
            // sc
            // 
            this.sc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc.Location = new System.Drawing.Point(0, 0);
            this.sc.Name = "sc";
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.tvr);
            this.sc.Panel1.Controls.Add(this.label1);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.lvr);
            this.sc.Panel2.Controls.Add(this.label2);
            this.sc.Size = new System.Drawing.Size(739, 127);
            this.sc.SplitterDistance = 224;
            this.sc.SplitterWidth = 6;
            this.sc.TabIndex = 0;
            // 
            // tvr
            // 
            this.tvr.ContextMenuStrip = this.mTree;
            this.tvr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvr.FullRowSelect = true;
            this.tvr.HideSelection = false;
            this.tvr.ImageKey = "D";
            this.tvr.ImageList = this.il;
            this.tvr.Location = new System.Drawing.Point(0, 12);
            this.tvr.Name = "tvr";
            this.tvr.SelectedImageKey = "S";
            this.tvr.Size = new System.Drawing.Size(224, 115);
            this.tvr.TabIndex = 1;
            this.tvr.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvr_ItemDrag);
            this.tvr.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvr_AfterSelect);
            this.tvr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvr_KeyDown);
            // 
            // mTree
            // 
            this.mTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mExposeDirs,
            this.mExposeDirsOrgPos});
            this.mTree.Name = "mTree";
            this.mTree.Size = new System.Drawing.Size(184, 48);
            // 
            // mExposeDirs
            // 
            this.mExposeDirs.Name = "mExposeDirs";
            this.mExposeDirs.Size = new System.Drawing.Size(183, 22);
            this.mExposeDirs.Text = "復元する...";
            this.mExposeDirs.Click += new System.EventHandler(this.mExposeDirs_Click);
            // 
            // mExposeDirsOrgPos
            // 
            this.mExposeDirsOrgPos.Name = "mExposeDirsOrgPos";
            this.mExposeDirsOrgPos.Size = new System.Drawing.Size(183, 22);
            this.mExposeDirsOrgPos.Text = "復元する (元の場所)...";
            this.mExposeDirsOrgPos.Click += new System.EventHandler(this.mExposeDirs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "フォルダ一覧";
            // 
            // lvr
            // 
            this.lvr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chrFn,
            this.chrCb,
            this.chrMt});
            this.lvr.ContextMenuStrip = this.mList;
            this.lvr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvr.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lvr.FullRowSelect = true;
            this.lvr.GridLines = true;
            this.lvr.HideSelection = false;
            this.lvr.Location = new System.Drawing.Point(0, 12);
            this.lvr.Name = "lvr";
            this.lvr.Size = new System.Drawing.Size(509, 115);
            this.lvr.SmallImageList = this.il;
            this.lvr.TabIndex = 1;
            this.lvr.UseCompatibleStateImageBehavior = false;
            this.lvr.View = System.Windows.Forms.View.Details;
            this.lvr.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvfs_ColumnClick);
            this.lvr.ItemActivate += new System.EventHandler(this.lvr_ItemActivate);
            this.lvr.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvr_ItemDrag);
            this.lvr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvr_KeyDown);
            // 
            // chrFn
            // 
            this.chrFn.Text = "ファイル名称";
            this.chrFn.Width = 200;
            // 
            // chrCb
            // 
            this.chrCb.Text = "サイズ";
            this.chrCb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chrCb.Width = 100;
            // 
            // chrMt
            // 
            this.chrMt.Text = "更新日時";
            this.chrMt.Width = 150;
            // 
            // mList
            // 
            this.mList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mExposeFiles,
            this.mExposeFilesOrgPos});
            this.mList.Name = "mList";
            this.mList.Size = new System.Drawing.Size(184, 48);
            // 
            // mExposeFiles
            // 
            this.mExposeFiles.Name = "mExposeFiles";
            this.mExposeFiles.Size = new System.Drawing.Size(183, 22);
            this.mExposeFiles.Text = "復元する...";
            this.mExposeFiles.Click += new System.EventHandler(this.mExposeFiles_Click);
            // 
            // mExposeFilesOrgPos
            // 
            this.mExposeFilesOrgPos.Name = "mExposeFilesOrgPos";
            this.mExposeFilesOrgPos.Size = new System.Drawing.Size(183, 22);
            this.mExposeFilesOrgPos.Text = "復元する (元の場所)...";
            this.mExposeFilesOrgPos.Click += new System.EventHandler(this.mExposeFiles_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "ファイル一覧";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.tsf);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.hsc);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(739, 468);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(739, 518);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tstop);
            // 
            // tsf
            // 
            this.tsf.Dock = System.Windows.Forms.DockStyle.None;
            this.tsf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbFindPat,
            this.bFindPat,
            this.bSearchExcDir,
            this.bUseRex});
            this.tsf.Location = new System.Drawing.Point(3, 0);
            this.tsf.Name = "tsf";
            this.tsf.Size = new System.Drawing.Size(692, 25);
            this.tsf.TabIndex = 0;
            // 
            // bFindPat
            // 
            this.bFindPat.Image = global::DiffBkRestore.Properties.Resources.FindHS;
            this.bFindPat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bFindPat.Name = "bFindPat";
            this.bFindPat.Size = new System.Drawing.Size(78, 22);
            this.bFindPat.Text = "検索します";
            this.bFindPat.Click += new System.EventHandler(this.bFindPat_Click);
            // 
            // bSearchExcDir
            // 
            this.bSearchExcDir.CheckOnClick = true;
            this.bSearchExcDir.Image = global::DiffBkRestore.Properties.Resources.Book_openHS;
            this.bSearchExcDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSearchExcDir.Name = "bSearchExcDir";
            this.bSearchExcDir.Size = new System.Drawing.Size(111, 22);
            this.bSearchExcDir.Text = "フォルダを省きます";
            // 
            // bUseRex
            // 
            this.bUseRex.CheckOnClick = true;
            this.bUseRex.Image = global::DiffBkRestore.Properties.Resources.FunctionHS;
            this.bUseRex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUseRex.Name = "bUseRex";
            this.bUseRex.Size = new System.Drawing.Size(125, 22);
            this.bUseRex.Text = "正規表現を使います";
            // 
            // hsc
            // 
            this.hsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hsc.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.hsc.Location = new System.Drawing.Point(0, 0);
            this.hsc.Name = "hsc";
            this.hsc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // hsc.Panel1
            // 
            this.hsc.Panel1.Controls.Add(this.sc);
            // 
            // hsc.Panel2
            // 
            this.hsc.Panel2.Controls.Add(this.lvres);
            this.hsc.Panel2.Controls.Add(this.tlp);
            this.hsc.Size = new System.Drawing.Size(739, 468);
            this.hsc.SplitterDistance = 127;
            this.hsc.SplitterWidth = 6;
            this.hsc.TabIndex = 1;
            // 
            // lvres
            // 
            this.lvres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chfFn,
            this.chfCb,
            this.chfMt,
            this.chfDir});
            this.lvres.ContextMenuStrip = this.mFindList;
            this.lvres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvres.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
            this.lvres.FullRowSelect = true;
            this.lvres.GridLines = true;
            this.lvres.HideSelection = false;
            this.lvres.Location = new System.Drawing.Point(0, 12);
            this.lvres.Name = "lvres";
            this.lvres.Size = new System.Drawing.Size(739, 323);
            this.lvres.SmallImageList = this.il;
            this.lvres.TabIndex = 4;
            this.lvres.UseCompatibleStateImageBehavior = false;
            this.lvres.View = System.Windows.Forms.View.Details;
            this.lvres.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvres_ColumnClick);
            this.lvres.ItemActivate += new System.EventHandler(this.lvres_ItemActivate);
            this.lvres.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvres_ItemDrag);
            this.lvres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvres_KeyDown);
            // 
            // chfFn
            // 
            this.chfFn.Text = "ファイル名称";
            this.chfFn.Width = 200;
            // 
            // chfCb
            // 
            this.chfCb.Text = "サイズ";
            this.chfCb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chfCb.Width = 100;
            // 
            // chfMt
            // 
            this.chfMt.Text = "更新日時";
            this.chfMt.Width = 130;
            // 
            // chfDir
            // 
            this.chfDir.Text = "格納場所";
            this.chfDir.Width = 200;
            // 
            // mFindList
            // 
            this.mFindList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mExplodeFindSingleDir,
            this.mExplodeFindTree});
            this.mFindList.Name = "mFindList";
            this.mFindList.Size = new System.Drawing.Size(227, 48);
            // 
            // mExplodeFindSingleDir
            // 
            this.mExplodeFindSingleDir.Name = "mExplodeFindSingleDir";
            this.mExplodeFindSingleDir.Size = new System.Drawing.Size(226, 22);
            this.mExplodeFindSingleDir.Text = "復元する(一つのフォルダに)...";
            this.mExplodeFindSingleDir.Click += new System.EventHandler(this.mExplodeFindSingleDir_Click);
            // 
            // mExplodeFindTree
            // 
            this.mExplodeFindTree.Enabled = false;
            this.mExplodeFindTree.Name = "mExplodeFindTree";
            this.mExplodeFindTree.Size = new System.Drawing.Size(226, 22);
            this.mExplodeFindTree.Text = "復元する(フォルダ階層を復元)...";
            this.mExplodeFindTree.Click += new System.EventHandler(this.mExplodeFindSingleDir_Click);
            // 
            // tlp
            // 
            this.tlp.AutoSize = true;
            this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.Controls.Add(this.llClose, 1, 0);
            this.tlp.Controls.Add(this.label3, 0, 0);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.Size = new System.Drawing.Size(739, 12);
            this.tlp.TabIndex = 3;
            // 
            // llClose
            // 
            this.llClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llClose.AutoSize = true;
            this.llClose.Location = new System.Drawing.Point(693, 0);
            this.llClose.Name = "llClose";
            this.llClose.Size = new System.Drawing.Size(43, 12);
            this.llClose.TabIndex = 1;
            this.llClose.TabStop = true;
            this.llClose.Text = "(閉じる)";
            this.llClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llClose_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "検索結果";
            // 
            // fbdExp
            // 
            this.fbdExp.Description = "どこに復元しますか？";
            // 
            // ofdOpen
            // 
            this.ofdOpen.CheckFileExists = false;
            this.ofdOpen.FileName = "(DIR)";
            this.ofdOpen.Filter = "*.DiffBkSet;*.lst|*.DiffBkSet;*.lst";
            // 
            // RForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 518);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "RForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiffBk 復元プログラム Ver(*)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RForm_FormClosed);
            this.Load += new System.EventHandler(this.RForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.RForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.RForm_DragEnter);
            this.tstop.ResumeLayout(false);
            this.tstop.PerformLayout();
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel1.PerformLayout();
            this.sc.Panel2.ResumeLayout(false);
            this.sc.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).EndInit();
            this.sc.ResumeLayout(false);
            this.mTree.ResumeLayout(false);
            this.mList.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsf.ResumeLayout(false);
            this.tsf.PerformLayout();
            this.hsc.Panel1.ResumeLayout(false);
            this.hsc.Panel2.ResumeLayout(false);
            this.hsc.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hsc)).EndInit();
            this.hsc.ResumeLayout(false);
            this.mFindList.ResumeLayout(false);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tstop;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbFindPat;
        private System.Windows.Forms.ToolStripButton bFindPat;
        private System.Windows.Forms.ToolStripSplitButton bOpenDirin;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.SplitContainer sc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvr;
        private System.Windows.Forms.ListView lvr;
        private System.Windows.Forms.ColumnHeader chrFn;
        private System.Windows.Forms.ColumnHeader chrCb;
        private System.Windows.Forms.ColumnHeader chrMt;
        private System.Windows.Forms.ContextMenuStrip mTree;
        private System.Windows.Forms.ToolStripMenuItem mExposeDirs;
        private System.Windows.Forms.ContextMenuStrip mList;
        private System.Windows.Forms.ToolStripMenuItem mExposeFiles;
        private System.Windows.Forms.ToolStripMenuItem bOpenDirwith;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer hsc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.LinkLabel llClose;
        private System.Windows.Forms.ListView lvres;
        private System.Windows.Forms.ColumnHeader chfFn;
        private System.Windows.Forms.ColumnHeader chfCb;
        private System.Windows.Forms.ColumnHeader chfMt;
        private System.Windows.Forms.ColumnHeader chfDir;
        private System.Windows.Forms.ToolStrip tsf;
        private System.Windows.Forms.ContextMenuStrip mFindList;
        private System.Windows.Forms.ToolStripMenuItem mExplodeFindSingleDir;
        private System.Windows.Forms.ToolStripMenuItem mExplodeFindTree;
        private System.Windows.Forms.FolderBrowserDialog fbdExp;
        private System.Windows.Forms.ToolStripButton bUseRex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tsddbVerify;
        private System.Windows.Forms.ToolStripMenuItem bVerifyCache;
        private System.Windows.Forms.ToolStripMenuItem bVerifyCacheHash;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bExcDir;
        private System.Windows.Forms.ToolStripButton bSearchExcDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bStat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton bUsing;
        private System.Windows.Forms.ToolStripMenuItem bDeveloper;
        private System.Windows.Forms.ToolStripMenuItem bAlphaFS;
        private System.Windows.Forms.ToolStripMenuItem mExposeDirsOrgPos;
        private System.Windows.Forms.ToolStripMenuItem mExposeFilesOrgPos;
    }
}

