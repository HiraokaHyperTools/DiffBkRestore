using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Collections;
using System.Threading;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;
using fs = Alphaleonis.Win32.Filesystem;

namespace DiffBkRestore
{
    public partial class RForm : Form, ISelPath
    {
        String dirYa;

        public RForm(String dirYa)
        {
            this.dirYa = dirYa;

            InitializeComponent();
        }

        private void bOpenDirwith_Click(object sender, EventArgs e)
        {
            String s = Interaction.InputBox("パス？", "", "", -1, -1);
            if (s == "")
                return;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを選択してください:";
            fbd.ShowNewFolderButton = false;
            fbd.SelectedPath = s.Trim();
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                String dirIn = fbd.SelectedPath;
                TryOpen(dirIn);
            }
        }

        String cacheDir = null;

        private void OpenIt(string cacheDir, string fpList)
        {
            using (LoadingForm lwip = LoadingForm.Create())
            using (WIP wip = WIP.Show(this))
            {
                tvr.Nodes.Clear();
                lvr.Items.Clear();
                root = new DLeaf(FEntry.Empty); // root.Clear();

                ReadList(fpList);

                this.cacheDir = cacheDir;
            }
        }

        DLeaf root = new DLeaf(FEntry.Empty);

        void ReadList(String fpList)
        {
            String curdir = null;
            foreach (String row in File.ReadAllLines(fpList, Encoding.UTF8))
            {
                try
                {
                    String[] cols = row.Split(' ');
                    if (cols[0] == "+" && cols.Length >= 5)
                    {
                        String fnCache = HttpUtility.UrlDecode(cols[2], Encoding.UTF8);
                        String fpCache = (curdir != null) ? Path.Combine(curdir, fnCache) : fnCache;

                        DLeaf curl = Alloc(fs.Path.GetDirectoryName(fpCache));

                        String fn = fs.Path.GetFileName(fnCache);

                        curl.dictFile[fn] = new FEntry(
                            cols[1],
                            Convert.ToInt64(cols[3]),
                            Convert.ToInt64(cols[4]),
                            (cols.Length > 5) ? Convert.ToInt32(cols[5]) : 0,
                            fn
                            );
                    }
                    if (cols[0] == "@" && cols.Length >= 2)
                    {
                        curdir = HttpUtility.UrlDecode(cols[1], Encoding.UTF8);
                        DLeaf curl = Alloc(curdir);
                        curl.fe.atts = (cols.Length >= 3) ? Convert.ToInt32(cols[2]) : 0;
                    }
                }
                catch (FormatException)
                {

                }
            }

            Walk(root, null);
        }

        void Walk(DLeaf curl, TreeNode tn)
        {
            if (tn != null)
                tn.Tag = curl;

            foreach (KeyValuePair<String, DLeaf> kv in curl.dictDir)
            {
                TreeNode tn2 = ((tn != null) ? tn.Nodes : tvr.Nodes).Add(kv.Key);
                tn2.Name = kv.Key;

                Walk(kv.Value, tn2);
            }
        }

        private void tbFindPat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Handled)
            {
                bFindPat.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        interface IPatternMatch
        {
            bool Test(String fp);
        }

        class PatternMatch
        {
            internal class Rex : IPatternMatch
            {
                Regex rex;

                public Rex(Regex rex)
                {
                    this.rex = rex;
                }

                public bool Test(String fp)
                {
                    return rex.IsMatch(fs.Path.GetFileName(fp));
                }
            }

            internal class Kws : IPatternMatch
            {
                String[] alkw;

                public Kws(String[] alkw)
                {
                    this.alkw = alkw;
                }

                public bool Test(String fp)
                {
                    String fn = fs.Path.GetFileName(fp);
                    int cnt = 0;
                    foreach (String kw in alkw)
                    {
                        if (!fn.ToLowerInvariant().Contains(kw.ToLowerInvariant()))
                            return false;
                        cnt++;
                    }
                    return cnt != 0;
                }
            }
        }

        private void FindIt(String kws, bool rex)
        {
            lvres.Items.Clear();

            IPatternMatch test;

            try
            {
                test = rex
                    ? (IPatternMatch)new PatternMatch.Rex(new Regex(kws, RegexOptions.IgnoreCase | RegexOptions.Singleline))
                    : (IPatternMatch)new PatternMatch.Kws(Regex.Replace(kws, "\\s+", " ").Trim().Split(' '));
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "検索に失敗しました：\n\n" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FindThem(tvr.Nodes, test);

            hsc.Panel2Collapsed = false;
        }

        private void FindThem(TreeNodeCollection tnc, IPatternMatch test)
        {
            foreach (TreeNode tn in tnc)
            {
                DLeaf curl = tn.Tag as DLeaf;
                if (curl != null)
                {
                    if (!bSearchExcDir.Checked)
                        foreach (KeyValuePair<String, DLeaf> kv in curl.dictDir)
                        {
                            if (test.Test(kv.Key))
                            {
                                DLeaf r = kv.Value;
                                ListViewItem lvi = new ListViewItem(r.fe.Name);
                                lvi.SubItems.Add("");
                                lvi.SubItems.Add("");
                                lvi.SubItems.Add(tn.FullPath);
                                lvi.ImageKey = "D";
                                lvi.Name = r.fe.Name;
                                lvi.Tag = r;

                                lvres.Items.Add(lvi);
                            }
                        }
                    if (true)
                        foreach (KeyValuePair<String, FEntry> kv in curl.dictFile)
                        {
                            if (test.Test(kv.Key))
                            {
                                FEntry r = kv.Value;
                                ListViewItem lvi = new ListViewItem(r.Name);
                                lvi.SubItems.Add(r.cb.ToString("#,##0"));
                                lvi.SubItems.Add(new DateTime(r.mt).ToLocalTime().ToString("yyyy/MM/dd HH:mm:ss"));
                                lvi.SubItems.Add(tn.FullPath);
                                lvi.ImageKey = "F";
                                lvi.Name = r.Name;
                                lvi.Tag = r;

                                lvres.Items.Add(lvi);
                            }
                        }
                }
                FindThem(tn.Nodes, test);
            }
        }

        private void bFindPat_Click(object sender, EventArgs e)
        {
            String kws = tbFindPat.Text;

            if (kws.Trim().Length < 1)
            {
                MessageBox.Show(this, "検索ボックスに入力してから、検索を実行してください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FindIt(kws, bUseRex.Checked);
        }

        class FPUt
        {
            public static string[] SplitPath(String dir)
            {
                return Regex.Replace(dir, "\\\\+", "\\").Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private void bOpenDirin_ButtonClick(object sender, EventArgs e)
        {
            ofdOpen.FileName = "(DIR)";

            if (ofdOpen.ShowDialog(this) == DialogResult.OK)
            {
                String fp = ofdOpen.FileName;
                if (File.Exists(fp) && TryOpen(fp))
                {

                }
                else
                {
                    String dirIn = fs.Path.GetDirectoryName(fp);
                    TryOpen(dirIn);
                }
            }
        }

        private void tvr_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = tvr.SelectedNode;
            if (tn == null) return;

            {
                DLeaf o = tn.Tag as DLeaf;
                if (o != null)
                {
                    Listup2(o, true);
                }
            }
        }

        void Listup2(DLeaf leaf, bool rel)
        {
            lvr.Items.Clear();

            if (!bExcDir.Checked)
                foreach (DLeaf r in leaf.dictDir.Values)
                {
                    ListViewItem lvi = new ListViewItem(r.fe.Name);
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                    lvi.ImageKey = "D";
                    lvi.Name = r.fe.Name;
                    lvi.Tag = r;

                    lvr.Items.Add(lvi);
                }

            if (true)
                foreach (FEntry r in leaf.dictFile.Values)
                {
                    ListViewItem lvi = new ListViewItem(r.Name);
                    lvi.SubItems.Add(r.cb.ToString("#,##0"));
                    lvi.SubItems.Add(new DateTime(r.mt).ToLocalTime().ToString("yyyy/MM/dd HH:mm:ss"));
                    lvi.ImageKey = "F";
                    lvi.Name = r.Name;
                    lvi.Tag = r;

                    lvr.Items.Add(lvi);
                }
        }

        void Listup(IEnumerable<FEntry> ents, bool rel)
        {
            lvr.Items.Clear();

            foreach (FEntry r in ents)
            {
                ListViewItem lvi = new ListViewItem(r.Name);
                lvi.SubItems.Add(r.cb.ToString("#,##0"));
                lvi.SubItems.Add(new DateTime(r.mt).ToLocalTime().ToString("yyyy/MM/dd HH:mm:ss"));
                lvi.ImageKey = "F";
                lvi.Name = r.Name;
                lvi.Tag = r;

                lvr.Items.Add(lvi);
            }
        }

        private void mExposeDirs_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvr.SelectedNode;
            if (tn == null)
            {
                MessageBox.Show(this, "取り出したいフォルダを先に選択してください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DLeaf curl = tn.Tag as DLeaf;
            if (curl == null) return;

            if (fbdExp.ShowDialog(this) == DialogResult.OK)
            {
                ExplodeAsync(new DLeaf[] { curl }, new FEntry[0], false, fbdExp.SelectedPath);
            }
        }

        private void ExplodeAsync(IList<DLeaf> dirsIn, IList<FEntry> filesIn, bool isSingleDir, String dirTo)
        {
            List<DLeaf> dirs = new List<DLeaf>(dirsIn); while (dirs.Remove(null)) { }
            List<FEntry> files = new List<FEntry>(filesIn); while (files.Remove(null)) { }

            PolicyForm polform = new PolicyForm();
            if (polform.ShowDialog() != DialogResult.OK) return;

            ExpForm form = new ExpForm();
            form.bwExp.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                ExplodeState state = new ExplodeState();
                Action<String> UpdateCb = delegate (String fp)
                {
                    if (form.bwExp.CancellationPending) throw new UserCancelException("キャンセルしました。");
                    ExpForm.Rep rep = new ExpForm.Rep();
                    rep.fp = fp;
                    rep.Cur = state.cntDir + state.cntFs;
                    rep.Max = state.maxDir + state.maxFs;
                    form.bwExp.ReportProgress(0, rep);
                };
                Action<FPErr> ErrCb = delegate (FPErr fpe)
                {
                    form.ReportError(fpe);
                };
                Exploder ex = new Exploder(cacheDir, polform.IfContinueOnError, polform.IfOverwrite, UpdateCb, ErrCb, state);
                foreach (DLeaf curl in dirs) ex.ExplodeThem2(curl, dirTo);
                state.maxDir = state.cntDir;
                state.maxFs = state.cntFs + files.Count;
                state.cntDir = state.cntFs = 0;
                state.explode = true;
                foreach (FEntry fe in files)
                {
                    String fpTo = Path.Combine(dirTo, NUt.Clean(fe.Name));

                    state.cntFs++;

                    ExpForm.Rep rep = new ExpForm.Rep();
                    rep.fp = fpTo;
                    rep.Cur = state.cntDir + state.cntFs;
                    rep.Max = state.maxDir + state.maxFs;
                    form.bwExp.ReportProgress(0, rep);

                    ex.ExplodeIt(fpTo, fe);
                }
                foreach (DLeaf curl in dirs)
                {
                    ex.ExplodeThem2(curl, dirTo);
                }
            };
            form.StartPosition = FormStartPosition.Manual;
            form.Left = Left + Width / 2 - form.Width / 2;
            form.Top = Top + Height / 2 - form.Height / 2;
            form.Show(this);
            form.bwExp.RunWorkerAsync();
            //MessageBox.Show(this, "完了しました。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        class ExplodeState
        {
            public bool explode = false;
            public int cntDir = 0, cntFs = 0;

            public int maxDir = 0, maxFs = 0;
        }

        class Exploder
        {
            string cacheDir;
            bool IfContinueOnError;
            bool IfOverwrite;
            Action<String> updateCb;
            Action<FPErr> errCb;
            ExplodeState state;

            public Exploder(string cacheDir, bool IfContinueOnError, bool IfOverwrite, Action<String> updateCb, Action<FPErr> errCb, ExplodeState state)
            {
                this.cacheDir = cacheDir;
                this.IfContinueOnError = IfContinueOnError;
                this.IfOverwrite = IfOverwrite;
                this.updateCb = updateCb;
                this.errCb = errCb;
                this.state = state;
            }

            public void ExplodeThem2(DLeaf curl, String parentDir)
            {
                String dir = Path.Combine(parentDir, NUt.Clean(curl.fe.Name));

                if (updateCb != null) updateCb(dir);

                if (state.explode)
                {
                    try
                    {
                        Directory.CreateDirectory(dir);
                        if (curl.fe.atts != 0)
                            File.SetAttributes(dir, (FileAttributes)curl.fe.atts);
                    }
                    catch (Exception err)
                    {
                        if (!IfContinueOnError) throw new ApplicationException("失敗しました。", err);
                        if (errCb != null) errCb(new FPErr(dir, err));
                    }
                }
                state.cntDir++;

                foreach (FEntry fe in curl.dictFile.Values)
                {
                    String fpTo = Path.Combine(dir, NUt.Clean(fe.Name));

                    if (state.explode)
                        ExplodeIt(fpTo, fe);
                    state.cntFs++;

                    if (updateCb != null) updateCb(fpTo);
                }
                foreach (KeyValuePair<String, DLeaf> kv in curl.dictDir)
                {
                    ExplodeThem2(kv.Value, dir);
                }
            }

            public void ExplodeThem(DLeaf curl, String parentDir)
            {
                String dir = Path.Combine(parentDir, NUt.Clean(curl.fe.Name));
                Directory.CreateDirectory(dir);

                foreach (FEntry fe in curl.dictFile.Values)
                {
                    String fpTo = Path.Combine(dir, NUt.Clean(fe.Name));

                    ExplodeIt(fpTo, fe);
                }
                foreach (KeyValuePair<String, DLeaf> kv in curl.dictDir)
                {
                    ExplodeThem(kv.Value, dir);
                }
            }

            public void ExplodeIt(String fp, FEntry r)
            {
                String fpFrm = GetCachefp(r.hash);
                String fpTo = fp;

                try
                {
                    Directory.CreateDirectory(fs.Path.GetDirectoryName(fpTo));
                    if (File.Exists(fpTo))
                    {
                        if (!IfOverwrite) return;

                        File.SetAttributes(fpTo, File.GetAttributes(fpTo) & ~(FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.System));
                    }
                    else
                    {
                        File.Copy(fpFrm, fpTo, true);
                        File.SetLastWriteTimeUtc(fpTo, new DateTime(r.mt));
                    }

                    FileAttributes atts = (FileAttributes)r.atts;
                    if (0 != atts)
                    {
                        File.SetAttributes(fpTo, atts);
                    }
                }
                catch (Exception err)
                {
                    if (!IfContinueOnError) throw new ApplicationException("失敗しました。", err);
                    if (errCb != null) errCb(new FPErr(fpTo, err));
                }
            }

            private string GetCachefp(String hash)
            {
                return Path.Combine(cacheDir, hash[0] + "\\" + hash[1] + "\\" + hash);
            }
        }

        class NUt
        {
            public static String Clean(String s)
            {
                if (s.Length == 2 && s[1] == ':' && char.IsLetter(s[0]))
                    return s.Substring(0, 1);

                return Regex.Replace(s, "[\\\\/\\*\\?\\|\\<\\>\"\\:]", "_");
            }
        }

        private void mExplodeFindSingleDir_Click(object sender, EventArgs e)
        {
            if (lvres.SelectedIndices.Count == 0)
            {
                MessageBox.Show(this, "取り出したいファイルを先に選択してください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool fSingleDir = (mExplodeFindSingleDir == sender);
            if (fbdExp.ShowDialog(this) == DialogResult.OK)
            {
                List<FEntry> files = new List<FEntry>();
                List<DLeaf> dirs = new List<DLeaf>();
                foreach (ListViewItem lvi in lvres.SelectedItems)
                {
                    files.Add(lvi.Tag as FEntry);
                    dirs.Add(lvi.Tag as DLeaf);
                }
                ExplodeAsync(dirs.ToArray(), files.ToArray(), fSingleDir, fbdExp.SelectedPath);
            }
        }

        private void mExposeFiles_Click(object sender, EventArgs e)
        {
            if (lvr.SelectedIndices.Count == 0)
            {
                MessageBox.Show(this, "取り出したいファイルを先に選択してください。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを選択してください:";
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                using (WIP wip = WIP.Show(this))
                {
                    List<FEntry> files = new List<FEntry>();
                    List<DLeaf> dirs = new List<DLeaf>();
                    foreach (ListViewItem lvi in lvr.SelectedItems)
                    {
                        files.Add(lvi.Tag as FEntry);
                        dirs.Add(lvi.Tag as DLeaf);
                    }
                    ExplodeAsync(dirs, files, false, fbd.SelectedPath);
                }
            }
        }

        private void RForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("(*)", new Version(Application.ProductVersion).ToString());

            hsc.Panel2Collapsed = true;

            if (dirYa != null)
            {
                TryOpen(dirYa);
            }
        }

        bool TryOpen(string dirYa)
        {
            if (File.Exists(dirYa))
            {
                if (String.Compare(fs.Path.GetExtension(dirYa), ".DiffBkSet", true) == 0)
                {
                    SelectSetAt(fs.Path.GetDirectoryName(dirYa));
                    return true;
                }
                else if (String.Compare(fs.Path.GetExtension(dirYa), ".lst", true) == 0)
                {
                    String cacheDir = Path.Combine(fs.Path.GetDirectoryName(dirYa), @"..\CACHE");
                    if (Directory.Exists(cacheDir))
                    {
                        OpenIt(cacheDir, dirYa);
                        return true;
                    }
                }
            }
            else if (Directory.Exists(dirYa))
            {
                if (Directory.Exists(Path.Combine(dirYa, "CACHE")) && Directory.Exists(Path.Combine(dirYa, "FDSET")))
                {
                    SelectSetAt(dirYa);
                    return true;
                }
            }
            return false;
        }

        void SelectSetAt(string dirYa)
        {
            using (SelSetForm form = new SelSetForm(Directory.GetFiles(Path.Combine(dirYa, "fdset"), "*.lst")))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    OpenIt(Path.Combine(dirYa, "cache"), form.SelectedFilePath);
                }
            }
        }

        DLeaf Alloc(String lastDir)
        {
            DLeaf curl = root;
            foreach (String point in (lastDir.Trim()).Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries))
            {
                DLeaf via;
                if (curl.dictDir.TryGetValue(point, out via))
                {
                    curl = via;
                }
                else
                {
                    curl = curl.dictDir[point] = new DLeaf(FEntry.TempDir(point));
                }
            }
            return curl;
        }

        private void llClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hsc.Panel2Collapsed = true;
        }

        class Sort
        {
            internal class Str : IComparer
            {
                int i;
                int ord;

                public Str(int i, bool asc) { this.i = i; ord = asc ? 1 : -1; }

                #region IComparer メンバ

                public int Compare(object xx, object yy)
                {
                    ListViewItem x = (ListViewItem)xx;
                    ListViewItem y = (ListViewItem)yy;
                    return x.SubItems[i].Text.CompareTo(y.SubItems[i].Text) * ord;
                }

                #endregion
            }

            internal class Mt : IComparer
            {
                int ord;

                public Mt(bool asc) { ord = asc ? 1 : -1; }

                #region IComparer メンバ

                public int Compare(object xx, object yy)
                {
                    ListViewItem vx = (ListViewItem)xx;
                    ListViewItem vy = (ListViewItem)yy;
                    bool fx = vx.Tag is FEntry;
                    bool fy = vy.Tag is FEntry;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    FEntry x = (FEntry)vx.Tag;
                    FEntry y = (FEntry)vy.Tag;
                    return x.mt.CompareTo(y.mt) * ord;
                }

                #endregion
            }

            internal class Cb : IComparer
            {
                int ord;

                public Cb(bool asc) { ord = asc ? 1 : -1; }

                #region IComparer メンバ

                public int Compare(object xx, object yy)
                {
                    ListViewItem vx = (ListViewItem)xx;
                    ListViewItem vy = (ListViewItem)yy;
                    bool fx = vx.Tag is FEntry;
                    bool fy = vy.Tag is FEntry;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    FEntry x = (FEntry)vx.Tag;
                    FEntry y = (FEntry)vy.Tag;
                    return x.cb.CompareTo(y.cb) * ord;
                }

                #endregion
            }
        }

        private void lvfs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool asc = 0 == (ModifierKeys & Keys.Shift);
            if (e.Column == chrFn.Index) lvr.ListViewItemSorter = new Sort.Str(e.Column, asc);
            if (e.Column == chrMt.Index) lvr.ListViewItemSorter = new Sort.Mt(!asc);
            if (e.Column == chrCb.Index) lvr.ListViewItemSorter = new Sort.Cb(asc);
        }

        private void lvres_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool asc = 0 == (ModifierKeys & Keys.Shift);
            if (e.Column == chfFn.Index || e.Column == chfDir.Index) lvres.ListViewItemSorter = new Sort.Str(e.Column, asc);
            if (e.Column == chfMt.Index) lvres.ListViewItemSorter = new Sort.Mt(!asc);
            if (e.Column == chfCb.Index) lvres.ListViewItemSorter = new Sort.Cb(asc);
        }

        private void lvres_ItemActivate(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvres.SelectedItems)
            {
                if (lvi.Tag is DLeaf)
                {
                    String path = lvi.SubItems[chfDir.Index].Text;
                    SelDir(path + "\\" + lvi.Text);
                }
                else
                {
                    String path = lvi.SubItems[chfDir.Index].Text;
                    SelPath(path, lvi.Text);
                }
                break;
            }
        }

        private void RForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect & (e.Data.GetDataPresent(DataFormats.FileDrop) ? (DragDropEffects.Copy | DragDropEffects.Link) : DragDropEffects.None);
        }

        private void RForm_DragDrop(object sender, DragEventArgs e)
        {
            String[] alIn = e.Data.GetData(DataFormats.FileDrop) as String[];
            if (alIn != null)
            {
                foreach (String fp in alIn)
                {
                    System.Threading.SynchronizationContext.Current.Post(delegate (object state)
                    {
                        TryOpen((String)state);
                    }, fp);
                    break;
                }
            }
        }

        int cntVerify = 0;

        private void bVerifyCache_Click(object sender2, EventArgs e2)
        {
            bool alsoHash = sender2 == bVerifyCacheHash;

            VerifyForm form = new VerifyForm();
            form.Show();

            SynchronizationContext Sync = SynchronizationContext.Current;

            DLeaf root = this.root;

            BackgroundWorker bwVerify = new BackgroundWorker();
            bwVerify.WorkerSupportsCancellation = true;

            bwVerify.DoWork += delegate
            {
                ++cntVerify;
                String cacheDir = this.cacheDir;
                Queue<KeyValuePair<string, DLeaf>> dirs = new Queue<KeyValuePair<string, DLeaf>>();
                dirs.Enqueue(new KeyValuePair<string, DLeaf>("", root));
                while (dirs.Count != 0)
                {
                    if (bwVerify.CancellationPending) throw new ApplicationException("中止しました");
                    KeyValuePair<string, DLeaf> kvCur = dirs.Dequeue();
                    DLeaf cur = kvCur.Value;
                    Sync.Send(delegate
                    {
                        form.SetHere(kvCur.Key);
                    }, null);
                    foreach (KeyValuePair<string, DLeaf> kvSub in cur.dictDir)
                        dirs.Enqueue(new KeyValuePair<string, DLeaf>((kvCur.Key + "\\" + kvSub.Key).TrimStart('\\'), kvSub.Value));
                    foreach (FEntry fe in cur.dictFile.Values)
                    {
                        String fphash = CFPUt.GetCachefp(cacheDir, fe.hash);
                        String key = (kvCur.Key + "\\" + fe.Name).TrimStart('\\');
                        if (File.Exists(fphash))
                        {
                            if (alsoHash)
                            {
                                using (SHA256 hash = SHA256Managed.Create())
                                {
                                    using (FileStream fs = File.OpenRead(fphash))
                                    {
                                        String s = "";
                                        foreach (byte b in hash.ComputeHash(fs))
                                        {
                                            s += b.ToString("x2");
                                        }
                                        if (String.Compare(s, fe.hash, true) == 0)
                                            continue;
                                        {
                                            Sync.Send(delegate
                                            {
                                                if (form.IsDisposed) return;
                                                ListViewItem lvi = new ListViewItem(fe.Name);
                                                lvi.SubItems.Add("改ざん");
                                                lvi.SubItems.Add(kvCur.Key);
                                                lvi.SubItems.Add(fphash);
                                                form.lvF.Items.Add(lvi);
                                            }, null);
                                            continue;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }

                        {
                            Sync.Send(delegate
                            {
                                if (form.IsDisposed) return;
                                ListViewItem lvi = new ListViewItem(fe.Name);
                                lvi.SubItems.Add("消去");
                                lvi.SubItems.Add(kvCur.Key);
                                lvi.SubItems.Add(fphash);
                                form.lvF.Items.Add(lvi);
                            }, null);
                            continue;
                        }
                    }
                }
            };

            form.Disposed += delegate
            {
                bwVerify.CancelAsync();
            };

            bwVerify.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                --cntVerify;
                form.SetDone(e.Error);
            };

            form.SP = this;

            bwVerify.RunWorkerAsync();
        }

        private void bwVerify_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        class CFPUt
        {
            internal static string GetCachefp(String cacheDir, String hash)
            {
                return Path.Combine(cacheDir, hash[0] + "\\" + hash[1] + "\\" + hash);
            }
        }

        #region ISelPath メンバ

        public void SelPath(string path, string fn)
        {
            TreeNode tn = null;
            foreach (String bit in path.Split('\\')) tn = ((tn == null) ? tvr.Nodes : tn.Nodes)[bit];
            if (tn == null) return;
            tvr.SelectedNode = tn;
            tn.EnsureVisible();
            tvr_AfterSelect(tvr, new TreeViewEventArgs(tn));
            ListViewItem lvi2 = lvr.Items[fn];
            if (lvi2 == null) return;
            lvi2.Selected = lvi2.Focused = true;
            lvi2.EnsureVisible();
        }

        #endregion

        public void SelDir(string path)
        {
            TreeNode tn = null;
            foreach (String bit in path.Split('\\')) tn = ((tn == null) ? tvr.Nodes : tn.Nodes)[bit];
            if (tn == null) return;
            tvr.SelectedNode = tn;
            tn.EnsureVisible();
            tvr_AfterSelect(tvr, new TreeViewEventArgs(tn));
        }

        VFCopy.SrcClass GetLvSrc(ListView sender)
        {
            VFCopy.SrcClass dataSrc = new VFCopy.SrcClass();

            using (AH ah = new AH())
                foreach (ListViewItem lvi in sender.SelectedItems)
                {
                    FEntry fe = lvi.Tag as FEntry;
                    if (fe != null)
                    {
                        String fpFrm = CFPUt.GetCachefp(cacheDir, fe.hash);
                        dataSrc.AddFile(fs.Path.GetFileName(fe.Name), new DateTime(fe.mt, DateTimeKind.Utc), fe.cb, new CopyOpenSt(fpFrm));
                    }
                    DLeaf curl = lvi.Tag as DLeaf;
                    if (curl != null)
                    {
                        AddWalk(dataSrc, curl, NUt.Clean(curl.fe.Name));
                    }
                }
            dataSrc.Make();
            dataSrc.SetAsyncMode(1);

            dataSrc.OnStartOperation += delegate { ++cntAsyncOp; };
            dataSrc.OnEndOperation += delegate { --cntAsyncOp; };
            return dataSrc;
        }

        private void lvr_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(GetLvSrc(lvr), DragDropEffects.Copy);
        }

        class CopySt : VFCopy.ISt
        {
            Stream si;

            public CopySt(Stream si) { this.si = si; }

            #region ISt メンバ

            public void CloseSt()
            {
                if (si != null)
                {
                    si.Dispose();
                    si = null;
                }
            }

            public void ReadAt(Int64 pos, IntPtr pv, UInt32 cb, out UInt32 pcbRead)
            {
                byte[] bin = new byte[Convert.ToInt32(cb)];
                int r = si.Read(bin, 0, bin.Length);
                pcbRead = Convert.ToUInt32(r);
                Marshal.Copy(bin, 0, pv, r);
            }

            #endregion
        }

        class CopyOpenSt : VFCopy.IOpenSt
        {
            String fpFrm;

            public CopyOpenSt(String fpFrm) { this.fpFrm = fpFrm; }

            #region IOpenSt メンバ

            public VFCopy.ISt OpenSt()
            {
                FileStream fs = File.OpenRead(fpFrm);
                return new CopySt(fs);
            }

            #endregion
        }

        VFCopy.SrcClass GetTvSrc(TreeNode tn)
        {
            VFCopy.SrcClass dataSrc = new VFCopy.SrcClass();
            if (tn != null)
            {
                DLeaf curl = tn.Tag as DLeaf;
                if (curl != null)
                {
                    AddWalk(dataSrc, curl, NUt.Clean(curl.fe.Name));

                    dataSrc.Make();
                    dataSrc.SetAsyncMode(1);
                }
            }
            dataSrc.OnStartOperation += delegate { ++cntAsyncOp; };
            dataSrc.OnEndOperation += delegate { --cntAsyncOp; };
            return dataSrc;
        }

        int cntAsyncOp = 0;

        private void tvr_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(GetTvSrc(e.Item as TreeNode ?? tvr.SelectedNode), DragDropEffects.Copy);
        }

        class AH : IDisposable
        {
            Cursor Prev;

            public AH()
            {
                Prev = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
            }

            #region IDisposable メンバ

            public void Dispose()
            {
                Cursor.Current = Prev;
            }

            #endregion
        }

        private void AddWalk(VFCopy.SrcClass dataSrc, DLeaf curl, String prefix)
        {
            foreach (FEntry fe in curl.dictFile.Values)
            {
                String fpFrm = CFPUt.GetCachefp(cacheDir, fe.hash);
                dataSrc.AddFile(Path.Combine(prefix, NUt.Clean(fs.Path.GetFileName(fe.Name))), new DateTime(fe.mt, DateTimeKind.Utc), fe.cb, new CopyOpenSt(fpFrm));
            }
            foreach (KeyValuePair<string, DLeaf> kv in curl.dictDir)
            {
                AddWalk(dataSrc, kv.Value, Path.Combine(prefix, NUt.Clean(fs.Path.GetFileName(kv.Key))));
            }
        }

        private void lvres_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(GetLvSrc(lvres), DragDropEffects.Copy);
        }

        private void tvr_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && e.Control && !e.Shift && e.KeyCode == Keys.C)
            {
                using (AH ah = new AH()) (LastClipboard = GetTvSrc(tvr.SelectedNode)).SetClipboard();
                e.Handled = true;
            }
        }

        private void lvr_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && e.Control && !e.Shift && e.KeyCode == Keys.C)
            {
                using (AH ah = new AH()) (LastClipboard = GetLvSrc(lvr)).SetClipboard();
                e.Handled = true;
            }
            if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Back)
            {
                TreeNode tn = tvr.SelectedNode;
                if (tn != null)
                {
                    tn = tn.Parent;
                    if (tn != null)
                    {
                        tvr.SelectedNode = tn;
                        return;
                    }
                }
            }
        }

        private void lvres_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && e.Control && !e.Shift && e.KeyCode == Keys.C)
            {
                using (AH ah = new AH()) (LastClipboard = GetLvSrc(lvres)).SetClipboard();
                e.Handled = true;
            }
        }

        VFCopy.SrcClass lastClipboard = null;

        VFCopy.SrcClass LastClipboard
        {
            get
            {
                return lastClipboard;
            }
            set
            {
                if (lastClipboard != null)
                    Marshal.ReleaseComObject(lastClipboard);
                lastClipboard = value;
            }
        }

        private void RForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (LastClipboard != null && LastClipboard.IsCurrentClipboard() != 0 && MessageBox.Show(this, "クリップボードに取り出し機能を設定しています。\n\n終了すると機能が停止します。\n\n本当に終了しますか。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                if (cntAsyncOp != 0 && MessageBox.Show(this, "取り出しが進行しています。\n\n終了すると機能が停止します。\n\n本当に終了しますか。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                if (cntVerify != 0 && MessageBox.Show(this, "検証作業をしています。\n\n終了すると検証を中止します。\n\n本当に終了しますか。", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void RForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastClipboard = null;
        }

        private void bIncDir_Click(object sender, EventArgs e)
        {
            tvr_AfterSelect(tvr, new TreeViewEventArgs(tvr.SelectedNode));
        }

        private void lvr_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem lvi = lvr.FocusedItem;
            if (lvi == null) return;
            DLeaf curl = lvi.Tag as DLeaf;
            if (curl != null)
            {
                TreeNode tn = tvr.SelectedNode;
                if (tn != null)
                {
                    TreeNode tnFound = tn.Nodes[curl.fe.Name];
                    if (tnFound != null)
                    {
                        tvr.SelectedNode = tnFound;
                        return;
                    }
                }
            }
        }

        class Rev64 : IComparer<Int64>
        {
            #region IComparer<long> メンバ

            public int Compare(long x, long y)
            {
                return y.CompareTo(x);
            }

            #endregion
        }

        private void bStat_Click(object sender, EventArgs e)
        {
            StringWriter wr = new StringWriter();
            SortedDictionary<string, Int64> dictext = new SortedDictionary<string, long>();
            SortedDictionary<Int64, object> dict = new SortedDictionary<long, object>(new Rev64());

            wr.WriteLine("－－－－－－－－－－フォルダ別");
            Int64 cb = Walks(root, wr, dictext, 0, dict);

            wr.WriteLine("－－－－－－－－－－最多");
            int x = 0;
            foreach (Int64 v in dict.Keys)
            {
                x++;
                wr.WriteLine("#{0} {1:#,##0}", x, v);
                if (x == 100) break;
            }

            wr.WriteLine("－－－－－－－－－－拡張子別");

            foreach (KeyValuePair<string, Int64> kv in dictext)
            {
                wr.WriteLine("{0}\t{1:#,##0}", kv.Key, kv.Value);
            }

            wr.WriteLine("－－－－－－－－－－全部");
            wr.WriteLine("{0:#,##0}", cb);

            Clipboard.SetText(wr.ToString());

            MessageBox.Show(this, "クリップボードにコピーしました。", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Int64 Walks(DLeaf root, StringWriter wr, SortedDictionary<string, long> dictext, int lv, SortedDictionary<long, object> dict)
        {
            Int64 cb = 0;
            foreach (KeyValuePair<String, FEntry> kv in root.dictFile)
            {
                String fext = fs.Path.GetExtension(kv.Key).ToLowerInvariant();
                Int64 v = 0;
                dictext.TryGetValue(fext, out v);
                v += kv.Value.cb;
                cb += kv.Value.cb;
                dictext[fext] = v;
            }
            dict[cb] = 0;

            wr.WriteLine("{0}{1} ({2:#,##0})", new String(' ', lv), root.fe.Name, cb);

            foreach (KeyValuePair<string, DLeaf> kv in root.dictDir)
            {
                cb += Walks(kv.Value, wr, dictext, lv + 1, dict);
            }

            return cb;
        }

        private void bDeveloper_Click(object sender, EventArgs e)
        {
            OpenUrl("https://github.com/HiraokaHyperTools/DiffBkRestore");
        }

        private void OpenUrl(string p)
        {
            try
            {
                Process.Start(p);
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "URL を開くことができませんでした。\n\n" + err, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bAlphaFS_Click(object sender, EventArgs e)
        {
            OpenUrl("http://alphafs.alphaleonis.com/");
        }
    }

    public class FEntry : IComparable<FEntry>
    {
        public String hash;
        public Int64 cb, mt;
        public int atts;
        public String fileName;

        public FEntry(String hash, Int64 cb, Int64 mt, int atts, String fileName)
        {
            this.hash = hash;
            this.cb = cb;
            this.mt = mt;
            this.atts = atts;
            this.fileName = fileName;
        }

        public String Name { get { return fileName; } }

        public static FEntry Empty
        {
            get
            {
                return new FEntry("", -1, 0, 0, "");
            }
        }

        public static FEntry TempDir(string point)
        {
            return new FEntry("", -1, 0, 0, point);
        }

        #region IComparable<FEntry> メンバ

        public int CompareTo(FEntry other)
        {
            int t;
            t = hash.CompareTo(other.hash); if (t != 0) return t;
            t = cb.CompareTo(other.cb); if (t != 0) return t;
            t = mt.CompareTo(other.mt); if (t != 0) return t;
            t = atts.CompareTo(other.atts); if (t != 0) return t;
            t = fileName.CompareTo(other.fileName); if (t != 0) return t;
            return 0;
        }

        #endregion
    }

    public class DLeaf
    {
        public SortedDictionary<String, DLeaf> dictDir = new SortedDictionary<String, DLeaf>(StringComparer.InvariantCultureIgnoreCase);
        public SortedDictionary<String, FEntry> dictFile = new SortedDictionary<String, FEntry>();

        public FEntry fe;

        public DLeaf(FEntry fe)
        {
            this.fe = fe;
        }

        public void Clear()
        {
            foreach (DLeaf o in dictDir.Values) o.Clear();
            dictDir.Clear();
            dictFile.Clear();
        }
    }

    public interface ISelPath
    {
        void SelPath(String dir, String fn);
    }

    public class UserCancelException : Exception
    {
        public UserCancelException(String s)
            : base(s)
        {

        }
    }

    public class FPErr
    {
        public String fp;
        public Exception err;

        public FPErr(String fp, Exception err)
        {
            this.fp = fp;
            this.err = err;
        }
    }
}
