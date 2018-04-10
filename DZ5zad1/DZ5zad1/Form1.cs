using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ5zad1
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;
        private bool button_Instrument;
        
        public Form1()
        {
            InitializeComponent();
            FillDriveNodes();
            this.toolStrip1.Visible = false;
            this.panel3_treevyu.Visible = false;
            this.treeView1_Directory.Visible = false;
            this.pictureBox2_save.Visible = false;
            this.richTextBox1.Location=new Point(106,32);
            this.richTextBox1.Size=new Size(733,397);
            this.otmenit_ToolStripMenuItem.Enabled = false;
            this.otmen_otmen_ToolStripMenuItem.Enabled = false;
            this.Undo_ToolStripMenuItem.Enabled = false;
            this.richTextBox1.ReadOnly = true;
            this.Save_ToolStripMenuItem.Enabled = false;
            this.Save_As_ToolStripMenuItem.Enabled = false;
            this.Undo_ToolStripMenuItem.Enabled = false;
            this.Cut_ToolStripMenuItem.Enabled = false;
            this.Copy_ToolStripMenuItem.Enabled = false;
            this.Paste_ToolStripMenuItem.Enabled = false;
            this.Del_ToolStripMenuItem.Enabled = false;
            this.Select_all_ToolStripMenuItem.Enabled = false;
            this.Font_ToolStripMenuItem.Enabled = false;
            this.virez_ToolStripMenuItem.Enabled = false;
            this.kopir_ToolStripMenuItem.Enabled = false;
            this.vstavit_ToolStripMenuItem.Enabled = false;
            this.otstup_oolStripMenuItem.Enabled = false;
            this.markirovka_ToolStripMenuItem.Enabled = false;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_Instrument = false;
            this.richTextBox1.AllowDrop = true;
            this.bunifuImageButton1_instrument.Click += BunifuImageButton1_instrument_Click;
            this.bunifuImageButton2_open.Click += BunifuImageButton2_open_Click;
            this.bunifuImageButton2_Exit.Click += BunifuImageButton2_Exit_Click;
            this.treeView1_Directory.BeforeSelect += TreeView1_Directory_BeforeSelect;
            this.richTextBox1.DragEnter += RichTextBox1_DragEnter;
            this.richTextBox1.DragDrop += RichTextBox1_DragDrop;
            this.treeView1_Directory.ItemDrag += TreeView1_Directory_ItemDrag;
            this.timer1.Tick += Timer1_Tick;

            this.Create_ToolStripMenuItem.Click += Create_ToolStripMenuItem_Click;
            this.toolStripButton3_Sozdat_new.Click+= Create_ToolStripMenuItem_Click;
            this.Open_ToolStripMenuItem.Click += Open_ToolStripMenuItem_Click;
            this.toolStripButton1_otkrit.Click+= Open_ToolStripMenuItem_Click;
            this.Save_ToolStripMenuItem.Click += Save_ToolStripMenuItem_Click;
            this.toolStripButton2_sohranit.Click+= Save_ToolStripMenuItem_Click;
            this.Save_As_ToolStripMenuItem.Click += Save_As_ToolStripMenuItem_Click;

            this.Undo_ToolStripMenuItem.Click += Undo_ToolStripMenuItem_Click;
            this.toolStripButton7_otmena.Click+= Undo_ToolStripMenuItem_Click;
            this.otmenit_ToolStripMenuItem.Click+= Undo_ToolStripMenuItem_Click;
            this.Cut_ToolStripMenuItem.Click += Cut_ToolStripMenuItem_Click;
            this.toolStripButton5_virezat.Click+= Cut_ToolStripMenuItem_Click;
            this.virez_ToolStripMenuItem.Click+= Cut_ToolStripMenuItem_Click;
            this.Copy_ToolStripMenuItem.Click += Copy_ToolStripMenuItem_Click;
            this.toolStripButton4_Cope.Click+= Copy_ToolStripMenuItem_Click;
            this.kopir_ToolStripMenuItem.Click+= Copy_ToolStripMenuItem_Click;
            this.Paste_ToolStripMenuItem.Click += Paste_ToolStripMenuItem_Click;
            this.vstavit_ToolStripMenuItem.Click+= Paste_ToolStripMenuItem_Click;
            this.toolStripButton6_Cut.Click+= Paste_ToolStripMenuItem_Click;
            this.Del_ToolStripMenuItem.Click += Del_ToolStripMenuItem_Click;
            this.Select_all_ToolStripMenuItem.Click += Select_all_ToolStripMenuItem_Click;

            this.Font_ToolStripMenuItem.Click += Font_ToolStripMenuItem_Click;
            this.toolStripButton_Font.Click+= Font_ToolStripMenuItem_Click;
            this.Bacgraund_ToolStripMenuItem.Click += Bacgraund_ToolStripMenuItem_Click;
            this.toolStripButton1_left.Click += ToolStripButton1_left_Click;
            this.toolStripButton2_center.Click += ToolStripButton2_center_Click;
            this.richTextBox1.TextChanged += RichTextBox1_TextChanged;
            this.toolStripButton3_right.Click += ToolStripButton3_right_Click;
            this.toolStripButton2_picture.Click += ToolStripButton2_picture_Click;
            this.otstup_oolStripMenuItem.Click += Otstup_oolStripMenuItem_Click;
            this.markirovka_ToolStripMenuItem.Click += Markirovka_ToolStripMenuItem_Click;
            this.otmen_otmen_ToolStripMenuItem.Click += Otmen_otmen_ToolStripMenuItem_Click;
        }

        private void Otmen_otmen_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Redo();
        }

        private void Markirovka_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionBullet = true;
        }

        private void Otstup_oolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionIndent = 15;
        }

        private void ToolStripButton2_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog img=new OpenFileDialog();
            img.Filter = "PNG(*.png)|*.png|JPG(*.jpg)|*.jpg|All(*.*)|*.*";
            if (img.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image foto = Image.FromFile(img.FileName);
                    Clipboard.Clear();
                    Clipboard.SetImage(foto);
                    richTextBox1.Paste();
                    Clipboard.Clear();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Выбран не верный формат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToolStripButton3_right_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                richTextBox1.Cut();
                richTextBox1.Paste();
            }
            else
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.otmenit_ToolStripMenuItem.Enabled = this.richTextBox1.CanUndo;
            this.otmen_otmen_ToolStripMenuItem.Enabled = this.richTextBox1.CanRedo;
            this.Undo_ToolStripMenuItem.Enabled = this.richTextBox1.CanUndo;
        }

        private void ToolStripButton2_center_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.Cut();
                richTextBox1.Paste(); 
            }
            else
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void ToolStripButton1_left_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                richTextBox1.Cut();
                richTextBox1.Paste();
            }
            else
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void Bacgraund_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog BackColor=new ColorDialog();
            BackColor.Color = this.richTextBox1.BackColor;
            if (BackColor.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.BackColor = BackColor.Color;
            }
        }

        private void Font_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = richTextBox1.SelectionFont;
            dlg.Color = richTextBox1.SelectionColor;
            dlg.ShowColor = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = dlg.Color;
                richTextBox1.SelectionFont = dlg.Font;
            }
        }

        private void Select_all_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectAll();
        }

        private void Del_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectedText = "";
        }

        private void Paste_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void Copy_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void Cut_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Cut();
        }

        private void Undo_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Undo();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer_Stop();
        }

        private void Save_As_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile=new SaveFileDialog();
            saveFile.Filter= "TXT file (*.txt)|*.txt|RTF file(*.rtf)|*.rtf|All file(*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (saveFile.FileName.EndsWith("rtf"))
                    {
                        this.richTextBox1.SaveFile(saveFile.FileName,RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        this.richTextBox1.SaveFile(saveFile.FileName,RichTextBoxStreamType.PlainText);
                    }

                    this.pictureBox2_save.Visible = true;
                    this.timer1.Start();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Что то пошло не так!", "Оповещение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void Save_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile.FileName != "")
            {
                if (openFile.FileName.EndsWith("rtf"))
                {
                    this.richTextBox1.SaveFile(openFile.FileName,RichTextBoxStreamType.RichText);
                }
                else
                {
                    this.richTextBox1.SaveFile(openFile.FileName,RichTextBoxStreamType.PlainText);
                }
                this.pictureBox2_save.Visible = true;
                this.timer1.Start();
            }
        }

        private void Timer_Stop()
        {
            this.pictureBox2_save.Visible = false;
            this.timer1.Stop();
        }
        private void Open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter= "TXT file (*.txt)|*.txt|RTF file(*.rtf)|*.rtf|All file(*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.FileName.EndsWith("rtf"))
                {
                    this.richTextBox1.LoadFile(openFile.FileName,RichTextBoxStreamType.RichText);
                }
                else
                {
                    using ( StreamReader reader = new StreamReader(openFile.FileName, Encoding.Default))
                    {
                        richTextBox1.Text = reader.ReadToEnd();
                    }
                }
                this.richTextBox1.ReadOnly = false;
                this.Save_ToolStripMenuItem.Enabled = true;
                this.Save_As_ToolStripMenuItem.Enabled = true;
                this.Undo_ToolStripMenuItem.Enabled = true;
                this.Cut_ToolStripMenuItem.Enabled = true;
                this.Copy_ToolStripMenuItem.Enabled = true;
                this.Paste_ToolStripMenuItem.Enabled = true;
                this.Del_ToolStripMenuItem.Enabled = true;
                this.Select_all_ToolStripMenuItem.Enabled = true;
                this.Font_ToolStripMenuItem.Enabled = true;
                this.virez_ToolStripMenuItem.Enabled = true;
                this.kopir_ToolStripMenuItem.Enabled = true;
                this.vstavit_ToolStripMenuItem.Enabled = true;
                this.otstup_oolStripMenuItem.Enabled = true;
                this.markirovka_ToolStripMenuItem.Enabled = true;
                this.label2_put.Text = openFile.FileName;
            }
            
        }

        private void Create_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
             openFile = new OpenFileDialog();
             saveFile = new SaveFileDialog();
            saveFile.Filter = "TXT file (*.txt)|*.txt|RTF file(*.rtf)|*.rtf|All file(*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(saveFile.FileName))
                {
                    this.richTextBox1.Clear();
                    openFile.FileName = saveFile.FileName;
                    if (openFile.FileName.EndsWith("rtf"))
                    {
                        richTextBox1.SaveFile(openFile.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        FileStream file = File.Create(saveFile.FileName);
                        file.Close();
                    }
                    this.richTextBox1.ReadOnly = false;
                    this.Save_ToolStripMenuItem.Enabled = true;
                    this.Save_As_ToolStripMenuItem.Enabled = true;
                    this.Undo_ToolStripMenuItem.Enabled = true;
                    this.Cut_ToolStripMenuItem.Enabled = true;
                    this.Copy_ToolStripMenuItem.Enabled = true;
                    this.Paste_ToolStripMenuItem.Enabled = true;
                    this.Del_ToolStripMenuItem.Enabled = true;
                    this.Select_all_ToolStripMenuItem.Enabled = true;
                    this.Font_ToolStripMenuItem.Enabled = true;
                    this.virez_ToolStripMenuItem.Enabled = true;
                    this.kopir_ToolStripMenuItem.Enabled = true;
                    this.vstavit_ToolStripMenuItem.Enabled = true;
                    this.otstup_oolStripMenuItem.Enabled = true;
                    this.markirovka_ToolStripMenuItem.Enabled = true;
                    this.label2_put.Text = openFile.FileName;
                }
                else
                {
                    MessageBox.Show("Фаил с таким именем уже существует!", "Оповишение", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    openFile = null;
                    saveFile = null;
                }
            }
        }

        private void TreeView1_Directory_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.richTextBox1.ReadOnly = false;
            TreeNode tr = (TreeNode)e.Item;
            DoDragDrop(tr.FullPath, DragDropEffects.Copy| DragDropEffects.Move);
            try
            {
                if (openFile.FileName.EndsWith("rtf"))
                {
                    richTextBox1.LoadFile(openFile.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    using (StreamReader reader = new StreamReader(openFile.FileName, Encoding.Default))
                    {
                        richTextBox1.Text = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Выберите фаил или фаил поврежден!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.label2_put.Text = "Editor";
                openFile = null;
            }
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string name = e.Data.GetData(DataFormats.Text).ToString();
            this.richTextBox1.Clear();
            try
            {
                openFile = new OpenFileDialog();
                openFile.FileName = name;
                this.label2_put.Text = name;
                this.Save_ToolStripMenuItem.Enabled = true;
                this.Save_As_ToolStripMenuItem.Enabled = true;
                this.Undo_ToolStripMenuItem.Enabled = true;
                this.Cut_ToolStripMenuItem.Enabled = true;
                this.Copy_ToolStripMenuItem.Enabled = true;
                this.Paste_ToolStripMenuItem.Enabled = true;
                this.Del_ToolStripMenuItem.Enabled = true;
                this.Select_all_ToolStripMenuItem.Enabled = true;
                this.Font_ToolStripMenuItem.Enabled = true;
                this.virez_ToolStripMenuItem.Enabled = true;
                this.kopir_ToolStripMenuItem.Enabled = true;
                this.vstavit_ToolStripMenuItem.Enabled = true;
                this.otstup_oolStripMenuItem.Enabled = true;
                this.markirovka_ToolStripMenuItem.Enabled = true;

            }
            catch (Exception exception)
            {
                MessageBox.Show("Выберите фаил или фаил поврежден!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.label2_put.Text = "Editor";
                openFile = null;
            }
        }

        private void RichTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TreeView1_Directory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            string[] files;

            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }

                    files = Directory.GetFiles(e.Node.FullPath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(files[i]));
                        e.Node.Nodes.Add(fileNode);
                    }
                }

            }
            catch (Exception)
            {
                
            }

        }
        
        private void BunifuImageButton2_Exit_Click(object sender, EventArgs e)
        {
            this.bunifuTransition2.HideSync(this.treeView1_Directory);
            this.bunifuTransition1.HideSync(this.panel3_treevyu);
            this.panel3_button_open.Visible = true;
            this.richTextBox1.Location = new Point(106, 32);
            this.richTextBox1.Size = new Size(733, 397);
        }

        private void BunifuImageButton2_open_Click(object sender, EventArgs e)
        {
            this.panel3_button_open.Visible = false;
            this.richTextBox1.Location = new Point(361, 32);
            this.richTextBox1.Size = new Size(543, 397);
            this.bunifuTransition1.ShowSync(this.panel3_treevyu);
            this.bunifuTransition2.ShowSync(this.treeView1_Directory);
        }

        private void BunifuImageButton1_instrument_Click(object sender, EventArgs e)
        {
            if (!button_Instrument)
            {
                Bitmap imegBitmap=new Bitmap(String.Format(@"..\..\image\{0}.png",4));
                this.bunifuImageButton1_instrument.Image = imegBitmap;
                this.bunifuTransition1.ShowSync(this.toolStrip1);
                button_Instrument = true;
            }
            else
            {
                Bitmap imegBitmap = new Bitmap(String.Format(@"..\..\image\{0}.png", 5));
                this.bunifuImageButton1_instrument.Image = imegBitmap;
                this.bunifuTransition1.HideSync(this.toolStrip1);
                button_Instrument = false;
            }
        }

        private void bunifuImageButton1_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    FillTreeNode(driveNode, drive.Name);
                    this.treeView1_Directory.Nodes.Add(driveNode);
                }
            }
            catch (Exception)
            {
                
            }
        }
        private void FillTreeNode(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    driveNode.Nodes.Add(dirNode);
                }

                string[] fill = Directory.GetFiles(path);
                foreach (string f in fill)
                {
                    TreeNode dirNode = new TreeNode(new DirectoryInfo(f).Name);
                    driveNode.Nodes.Add(dirNode);
                }
            }
            catch (Exception)
            {
               
            }
        }


        
    }
}
