using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApplication1.Properties;
using Microsoft.International.Converters.PinYinConverter;
using Microsoft.Win32;

namespace WindowsFormsApplication1
{
    public class MainForm : Form
    {
        private IContainer components;
        private ToolStrip toolStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private SplitContainer splitContainer2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 新用户ToolStripMenuItem;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem 添加新数据ToolStripMenuItem;
        private ToolStripButton CheckOutButton;
        private ToolStripButton CheckInButton;
        private ContextMenuStrip grid1Menu;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 显示新数据ToolStripMenuItem;
        private ToolStripMenuItem 显示全部数据ToolStripMenuItem;
        private ToolStripButton export;
        private SaveFileDialog saveFileDialog1;
        private ToolStripButton Import;
        private OpenFileDialog openFileDialog1;
        private ToolStripButton UpdateDatabase;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 刷新ToolStripMenuItem;
        private ToolStripMenuItem 恢复默认值ToolStripMenuItem;
        private ToolStripMenuItem 添加新数据ToolStripMenuItem1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripButton toolStripButton1;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton toolStripButton4;
        private ToolStripProgressBar toolStripProgressBar1;
        private DDataTable mCurTable;
        private long mCurUser;
        private TreeNode mCurTreeNode;
        private bool mNewDataMode;
        public string DataName;
        public bool DevMode = false;
        private BindingSource mCurBinding = new BindingSource();
        private ToolStripMenuItem 导出使用ToolStripMenuItem;
        private ToolStripMenuItem 导出服务器ToolStripMenuItem;
        private ToolStripMenuItem 导出客户端表格ToolStripMenuItem;
        private ToolStripMenuItem 导出全部ToolStripMenuItem;
        private ToolStripMenuItem 导出服务器代码使用的表格ToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private int mImportLineNum = 1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem 导出Lua表格ToolStripMenuItem;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripMenuItem 导出当前表格到客户端和服务器ToolStripMenuItem;
        private Dictionary<string, TreeNode> SearchNodes = new Dictionary<string, TreeNode>();

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("数据");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CheckOutButton = new System.Windows.Forms.ToolStripButton();
            this.CheckInButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.export = new System.Windows.Forms.ToolStripButton();
            this.Import = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.UpdateDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加新数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出使用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出客户端表格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出服务器代码使用的表格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出Lua表格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出当前表格到客户端和服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grid1Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示新数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示全部数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复默认值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加新数据ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grid1Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckOutButton,
            this.CheckInButton,
            this.toolStripButton5,
            this.export,
            this.Import,
            this.toolStripButton2,
            this.toolStripButton3,
            this.UpdateDatabase,
            this.toolStripButton6,
            this.toolStripButton1,
            this.toolStripTextBox1,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(986, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CheckOutButton
            // 
            this.CheckOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CheckOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckOutButton.Name = "CheckOutButton";
            this.CheckOutButton.Size = new System.Drawing.Size(36, 22);
            this.CheckOutButton.Text = "签出";
            this.CheckOutButton.Click += new System.EventHandler(this.CheckOutButton_Click);
            // 
            // CheckInButton
            // 
            this.CheckInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CheckInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckInButton.Name = "CheckInButton";
            this.CheckInButton.Size = new System.Drawing.Size(36, 22);
            this.CheckInButton.Text = "签入";
            this.CheckInButton.Click += new System.EventHandler(this.CheckInButton_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton5.Text = "导出";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // export
            // 
            this.export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(70, 22);
            this.export.Text = "导出UTF-8";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // Import
            // 
            this.Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(36, 22);
            this.Import.Text = "导入";
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton2.Text = "创建数据库";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton3.Text = "删除数据库";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // UpdateDatabase
            // 
            this.UpdateDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UpdateDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateDatabase.Name = "UpdateDatabase";
            this.UpdateDatabase.Size = new System.Drawing.Size(96, 22);
            this.UpdateDatabase.Text = "更新数据库结构";
            this.UpdateDatabase.Click += new System.EventHandler(this.UpdateDatabase_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton6.Text = "导出全部";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(94, 22);
            this.toolStripButton1.Text = "导出全部UTF-8";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyUp);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 22);
            this.toolStripButton4.Text = "搜";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加新数据ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 添加新数据ToolStripMenuItem
            // 
            this.添加新数据ToolStripMenuItem.Name = "添加新数据ToolStripMenuItem";
            this.添加新数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.添加新数据ToolStripMenuItem.Text = "添加新数据";
            this.添加新数据ToolStripMenuItem.Click += new System.EventHandler(this.添加新数据ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.导出使用ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新用户ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新用户ToolStripMenuItem
            // 
            this.新用户ToolStripMenuItem.Name = "新用户ToolStripMenuItem";
            this.新用户ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.新用户ToolStripMenuItem.Text = "新用户";
            this.新用户ToolStripMenuItem.Click += new System.EventHandler(this.新用户ToolStripMenuItem_Click);
            // 
            // 导出使用ToolStripMenuItem
            // 
            this.导出使用ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出服务器ToolStripMenuItem,
            this.导出客户端表格ToolStripMenuItem,
            this.导出全部ToolStripMenuItem,
            this.导出服务器代码使用的表格ToolStripMenuItem,
            this.导出Lua表格ToolStripMenuItem,
            this.导出当前表格到客户端和服务器ToolStripMenuItem});
            this.导出使用ToolStripMenuItem.Name = "导出使用ToolStripMenuItem";
            this.导出使用ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.导出使用ToolStripMenuItem.Text = "导出最终使用表格";
            // 
            // 导出服务器ToolStripMenuItem
            // 
            this.导出服务器ToolStripMenuItem.Name = "导出服务器ToolStripMenuItem";
            this.导出服务器ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.导出服务器ToolStripMenuItem.Text = "导出服务器表格";
            this.导出服务器ToolStripMenuItem.Click += new System.EventHandler(this.导出服务器ToolStripMenuItem_Click);
            // 
            // 导出客户端表格ToolStripMenuItem
            // 
            this.导出客户端表格ToolStripMenuItem.Name = "导出客户端表格ToolStripMenuItem";
            this.导出客户端表格ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.导出客户端表格ToolStripMenuItem.Text = "导出客户端表格";
            this.导出客户端表格ToolStripMenuItem.Click += new System.EventHandler(this.导出客户端表格ToolStripMenuItem_Click);
            // 
            // 导出全部ToolStripMenuItem
            // 
            this.导出全部ToolStripMenuItem.Name = "导出全部ToolStripMenuItem";
            this.导出全部ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.导出全部ToolStripMenuItem.Text = "导出全部";
            this.导出全部ToolStripMenuItem.Click += new System.EventHandler(this.导出全部ToolStripMenuItem_Click);
            // 
            // 导出服务器代码使用的表格ToolStripMenuItem
            // 
            this.导出服务器代码使用的表格ToolStripMenuItem.Name = "导出服务器代码使用的表格ToolStripMenuItem";
            this.导出服务器代码使用的表格ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.导出服务器代码使用的表格ToolStripMenuItem.Text = "导出服务器代码使用的表格";
            this.导出服务器代码使用的表格ToolStripMenuItem.Click += new System.EventHandler(this.导出服务器代码使用的表格ToolStripMenuItem_Click);
            // 
            // 导出Lua表格ToolStripMenuItem
            // 
            this.导出Lua表格ToolStripMenuItem.Name = "导出Lua表格ToolStripMenuItem";
            this.导出Lua表格ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.导出Lua表格ToolStripMenuItem.Text = "导出Lua表格";
            this.导出Lua表格ToolStripMenuItem.Click += new System.EventHandler(this.导出Lua表格ToolStripMenuItem_Click);
            // 
            // 导出当前表格到客户端和服务器ToolStripMenuItem
            // 
            this.导出当前表格到客户端和服务器ToolStripMenuItem.Name = "导出当前表格到客户端和服务器ToolStripMenuItem";
            this.导出当前表格到客户端和服务器ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.导出当前表格到客户端和服务器ToolStripMenuItem.Text = "导出当前表格到客户端和服务器";
            this.导出当前表格到客户端和服务器ToolStripMenuItem.Click += new System.EventHandler(this.导出当前表格到客户端和服务器ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(986, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(986, 448);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(145, 448);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AllowDrop = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip2;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 31);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "数据";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(139, 414);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer2.Size = new System.Drawing.Size(837, 448);
            this.splitContainer2.SplitterDistance = 633;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ContextMenuStrip = this.grid1Menu;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(633, 448);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // grid1Menu
            // 
            this.grid1Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.显示新数据ToolStripMenuItem,
            this.显示全部数据ToolStripMenuItem,
            this.恢复默认值ToolStripMenuItem,
            this.添加新数据ToolStripMenuItem1});
            this.grid1Menu.Name = "grid1Menu";
            this.grid1Menu.Size = new System.Drawing.Size(137, 114);
            this.grid1Menu.Opening += new System.ComponentModel.CancelEventHandler(this.grid1Menu_Opening);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 显示新数据ToolStripMenuItem
            // 
            this.显示新数据ToolStripMenuItem.Name = "显示新数据ToolStripMenuItem";
            this.显示新数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示新数据ToolStripMenuItem.Text = "显示新数据";
            this.显示新数据ToolStripMenuItem.Click += new System.EventHandler(this.显示新数据ToolStripMenuItem_Click);
            // 
            // 显示全部数据ToolStripMenuItem
            // 
            this.显示全部数据ToolStripMenuItem.Name = "显示全部数据ToolStripMenuItem";
            this.显示全部数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示全部数据ToolStripMenuItem.Text = "显示旧数据";
            this.显示全部数据ToolStripMenuItem.Click += new System.EventHandler(this.显示旧数据ToolStripMenuItem_Click);
            // 
            // 恢复默认值ToolStripMenuItem
            // 
            this.恢复默认值ToolStripMenuItem.Name = "恢复默认值ToolStripMenuItem";
            this.恢复默认值ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.恢复默认值ToolStripMenuItem.Text = "恢复默认值";
            this.恢复默认值ToolStripMenuItem.Click += new System.EventHandler(this.恢复默认值ToolStripMenuItem_Click);
            // 
            // 添加新数据ToolStripMenuItem1
            // 
            this.添加新数据ToolStripMenuItem1.Name = "添加新数据ToolStripMenuItem1";
            this.添加新数据ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.添加新数据ToolStripMenuItem1.Text = "添加新数据";
            this.添加新数据ToolStripMenuItem1.Click += new System.EventHandler(this.添加新数据ToolStripMenuItem1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(200, 448);
            this.dataGridView2.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(986, 520);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "数据编辑器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grid1Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public MainForm(bool dev)
        {
            this.InitializeComponent();
            DevMode = dev;

//             this.CheckOutButton.Image = (Image) componentResourceManager.GetObject("CheckOutButton.Image");
//             this.CheckInButton.Image = (Image) componentResourceManager.GetObject("CheckInButton.Image");
//             this.export.Image = (Image) componentResourceManager.GetObject("export.Image");
//             this.Import.Image = (Image) componentResourceManager.GetObject("Import.Image");
//             this.toolStripButton2.Image = (Image) componentResourceManager.GetObject("toolStripButton2.Image");
//             this.toolStripButton3.Image = (Image) componentResourceManager.GetObject("toolStripButton3.Image");
//             this.UpdateDatabase.Image = (Image) componentResourceManager.GetObject("UpdateDatabase.Image");
//             this.toolStripButton1.Image = (Image) componentResourceManager.GetObject("toolStripButton1.Image");
//             this.toolStripButton4.Image = (Image) componentResourceManager.GetObject("toolStripButton4.Image");
            base.AutoScaleMode = AutoScaleMode.Font;

            if (!DevMode)
            {
                toolStrip1.Visible = false;

                导出服务器ToolStripMenuItem.Enabled = false;
                导出客户端表格ToolStripMenuItem.Enabled = false;
                导出全部ToolStripMenuItem.Enabled = false;
                导出服务器代码使用的表格ToolStripMenuItem.Enabled = false;
                导出Lua表格ToolStripMenuItem.Enabled = false;
                新用户ToolStripMenuItem.Enabled = false;
            }

            this.mNewDataMode = false;
            this.mCurUser = Program.userid;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DoubleBuffered(true);
            dataGridView2.DoubleBuffered(true);

            List<string> list = new List<string>();
            foreach (KeyValuePair<string, DDataTable> current in Program.ddb.Table)
            {
                if (current.Value.Visibility && !list.Contains(current.Value.Catalog))
                {
                    list.Add(current.Value.Catalog);
                }
            }
            foreach (string current2 in list)
            {
                this.treeView1.Nodes.Add(current2, current2);
            }
            if (DevMode)
            {
                LoadAllTableInfo();
            }
            foreach (KeyValuePair<string, DDataTable> current3 in Program.ddb.Table)
            {
                //this.LoadTableInfo(current3.Value);
                if (current3.Value.Visibility)
                {
                    TreeNode node;
                    if (current3.Value.IsCheckedOut)
                    {
                        node = this.treeView1.Nodes[current3.Value.Catalog].Nodes.Add(current3.Key,
                            current3.Value.Alias + "(" + current3.Value.User + " CheckedOut)");
                        node.ToolTipText = current3.Value.Virtual + "/" + current3.Value.Name;
                    }
                    else
                    {
                        node = this.treeView1.Nodes[current3.Value.Catalog].Nodes.Add(current3.Key, current3.Value.Alias);
                        node.ToolTipText = current3.Value.Virtual + "/" + current3.Value.Name;
                    }

                    var py = GetFirstPinyin(current3.Value.Alias);
                    SearchNodes[py + "|" + current3.Value.Alias] = node;
                    SearchNodes[current3.Key + "|" + current3.Value.Alias] = node;
                }
            }

            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            if (textBox1.AutoCompleteCustomSource == null)
            {
                textBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            }
            textBox1.AutoCompleteCustomSource.Clear();
            textBox1.AutoCompleteCustomSource.AddRange(SearchNodes.Select(item => item.Key).ToArray());

            this.toolStripButton2.Enabled = false;
            this.toolStripButton3.Enabled = false;
            this.UpdateDatabase.Enabled = false;

            if (Program.modify_right)
            {
                this.toolStripButton2.Enabled = true;
                //this.toolStripButton3.Enabled = true;
                this.UpdateDatabase.Enabled = true;
                return;
            }
        }

        public static string GetFirstPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }

        public static void createColumns(DDataTable table, DataGridView dv)
        {
            foreach (KeyValuePair<string, DColumn> current in table.Columns)
            {
                var codeName = "Code: " + current.Value.CodeName + Environment.NewLine;
                if (current.Value.Type == ColumnTypes.Enum)
                {
                    DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
                    dataGridViewComboBoxColumn.HeaderText = current.Value.Alias;
                    dataGridViewComboBoxColumn.DataPropertyName = current.Value.Name;
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("key", typeof (int));
                    dataTable.Columns.Add("value", typeof (string));
                    string[] array = current.Value.Value.Split(new char[]
                    {
                        ','
                    });
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = -1;
                    dataRow[1] = "无选择(-1)";
                    dataTable.Rows.Add(dataRow);
                    for (int i = 0; i < array.Length; i++)
                    {
                        DataRow dataRow2 = dataTable.NewRow();
                        dataRow2[0] = i;
                        dataRow2[1] = array[i];
                        dataTable.Rows.Add(dataRow2);
                    }
                    dataGridViewComboBoxColumn.DisplayMember = "value";
                    dataGridViewComboBoxColumn.ValueMember = "key";
                    dataGridViewComboBoxColumn.DataSource = dataTable;
                    if (current.Value.Desc != null)
                    {
                        dataGridViewComboBoxColumn.ToolTipText = codeName + current.Value.Desc;
                    }
                    else
                    {
                        dataGridViewComboBoxColumn.ToolTipText = codeName + current.Value.Alias;
                    }
                    dataGridViewComboBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dv.Columns.Add(dataGridViewComboBoxColumn);
                }
                else
                {
                    DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                    dataGridViewTextBoxColumn.HeaderText = current.Value.Alias;
                    dataGridViewTextBoxColumn.DataPropertyName = current.Value.Name;
                    if (current.Value.Desc != null)
                    {
                        dataGridViewTextBoxColumn.ToolTipText = codeName + current.Value.Desc;
                    }
                    else
                    {
                        dataGridViewTextBoxColumn.ToolTipText = codeName + current.Value.Alias;
                    }
                    switch (current.Value.Type)
                    {
                        case ColumnTypes.Refid:
                            dataGridViewTextBoxColumn.HeaderCell.ToolTipText = codeName + current.Value.Table;
                            break;
                        case ColumnTypes.String:
                            dataGridViewTextBoxColumn.HeaderCell.ToolTipText = codeName + "最大长度: " +
                                                                               current.Value.Length.ToString();
                            break;
                        case ColumnTypes.Integer:
                            dataGridViewTextBoxColumn.HeaderCell.ToolTipText = codeName + "范围: " +
                                                                               current.Value.Range.ToString();
                            break;
                        case ColumnTypes.Long:
                            dataGridViewTextBoxColumn.HeaderCell.ToolTipText = codeName + "范围: " +
                                                                               current.Value.Range.ToString();
                            break;
                        case ColumnTypes.Float:
                            dataGridViewTextBoxColumn.HeaderCell.ToolTipText = codeName + "范围: " +
                                                                               current.Value.Range.ToString();
                            break;
                    }
                    dv.Columns.Add(dataGridViewTextBoxColumn);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!DevMode)
            {
                if (this.mCurTreeNode != null)
                {
                    this.mCurTreeNode.BackColor = this.mCurTreeNode.Parent.BackColor;
                    this.mCurTreeNode.ForeColor = this.mCurTreeNode.Parent.ForeColor;
                }
                DDataTable dDataTable = Program.ddb.Table[e.Node.Name];
                this.mCurTable = dDataTable;
                this.mCurBinding.CancelEdit();
                this.mCurBinding.DataSource = null;
                this.mCurTable.LoadDataFromFile();
                this.dataGridView1.Columns.Clear();
                MainForm.createColumns(dDataTable, this.dataGridView1);
                this.mCurBinding.DataSource = dDataTable.DataTable.DefaultView;
                this.dataGridView1.DataSource = this.mCurBinding;
                this.mCurTreeNode = e.Node;
                this.mCurTreeNode.BackColor = Color.DarkBlue;
                this.mCurTreeNode.ForeColor = Color.White;
                if (this.mCurTable.IsCheckedOut)
                {
                    this.mCurTreeNode.Text = this.mCurTable.Alias + "(" + this.mCurTable.User + " CheckedOut)";
                }
                else
                {
                    this.mCurTreeNode.Text = this.mCurTable.Alias;
                }
            }
            else
            {
                this.mNewDataMode = false;
                if (this.mCurTreeNode != null)
                {
                    this.mCurTreeNode.BackColor = this.mCurTreeNode.Parent.BackColor;
                    this.mCurTreeNode.ForeColor = this.mCurTreeNode.Parent.ForeColor;
                }
                if (Program.ddb.Table.ContainsKey(e.Node.Name))
                {
                    DDataTable dDataTable = Program.ddb.Table[e.Node.Name];
                    this.mCurTable = dDataTable;
                    this.mCurBinding.CancelEdit();
                    this.mCurBinding.DataSource = null;
                    this.mCurTable.LoadData();
                    this.dataGridView1.Columns.Clear();
                    MainForm.createColumns(dDataTable, this.dataGridView1);
                    this.mCurBinding.DataSource = dDataTable.DataTable.DefaultView;
                    this.dataGridView1.DataSource = this.mCurBinding;
                    this.LoadTableInfo(dDataTable);
                    this.mCurTreeNode = e.Node;
                    this.mCurTreeNode.BackColor = Color.DarkBlue;
                    this.mCurTreeNode.ForeColor = Color.White;
                    if (this.mCurTable.IsCheckedOut)
                    {
                        this.mCurTreeNode.Text = this.mCurTable.Alias + "(" + this.mCurTable.User + " CheckedOut)";
                    }
                    else
                    {
                        this.mCurTreeNode.Text = this.mCurTable.Alias;
                    }
                    this.UpdateRightGrid();
                    this.updateButtonState();
                }
            }
        }

        private void updateButtonState()
        {
            if (this.mCurTable.IsCheckedOut)
            {
                this.CheckOutButton.Enabled = false;
                this.CheckInButton.Enabled = true;
                return;
            }
            this.CheckOutButton.Enabled = true;
            this.CheckInButton.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("创建数据库?", "DataEditor", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    odbcConnection.Open();
                    foreach (KeyValuePair<string, DDataTable> current in Program.ddb.Table)
                    {
                        var commandText = "select count(*) from DataStatus where TableName='" + current.Key + "'";
                        odbcCommand.CommandText = commandText;
                        long count = (long) odbcCommand.ExecuteScalar();

                        // 表格存在
                        if (count != 0)
                        {
                            continue;
                        }

                        commandText =
                            "INSERT INTO DataStatus (TableName, IsCheckedOut, CheckOutUserId, FilePosition) VALUES (N'" +
                            current.Key.ToLower() + "', 0, 1, N'Public')";
                        odbcCommand.CommandText = commandText;
                        odbcCommand.ExecuteNonQuery();

                        commandText = "select max(TableId) from DataStatus";
                        odbcCommand.CommandText = commandText;
                        long id = (long) odbcCommand.ExecuteScalar();
                        current.Value.Id = id;

                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("create table ").Append(current.Key).Append("(");
                        int num = current.Value.Columns.Count;
                        foreach (KeyValuePair<string, DColumn> current2 in current.Value.Columns)
                        {
                            stringBuilder.Append(Converter.ToDbName(current2.Key)).Append(" ");
                            SqlDbType sqlDbType = Converter.ToDbType(current2.Value.Type);
                            if (sqlDbType == SqlDbType.NVarChar)
                            {
                                stringBuilder.Append(sqlDbType.ToString())
                                    .Append("(")
                                    .Append(current2.Value.Length*2)
                                    .Append(")");
                            }
                            else if (sqlDbType == SqlDbType.VarChar)
                            {
                                stringBuilder.Append(sqlDbType.ToString()).Append("(").Append(512).Append(")");
                            }
                            else if (sqlDbType == SqlDbType.Float)
                            {
                                stringBuilder.Append("DOUBLE");
                            }
                            else
                            {
                                stringBuilder.Append(sqlDbType);
                            }
                            if (num > 0)
                            {
                                stringBuilder.Append(",");
                            }
                            num--;
                        }
                        if (current.Value.Key != null)
                        {
                            stringBuilder.Append("constraint ").Append(current.Key + "_pk").Append(" primary key (");
                            for (int i = 0; i < current.Value.Key.Columns.Count; i++)
                            {
                                stringBuilder.Append(current.Value.Key.Columns[i].Name);
                                if (i + 1 != current.Value.Key.Columns.Count)
                                {
                                    stringBuilder.Append(",");
                                }
                            }
                            stringBuilder.Append(")");
                        }
                        stringBuilder.Append(")");
                        try
                        {
                            odbcCommand.CommandText = stringBuilder.ToString();
                            odbcCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.IndexOf("already exists") < 0)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除数据库?", "DataEditor", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    odbcConnection.Open();
                    foreach (KeyValuePair<string, DDataTable> current in Program.ddb.Table)
                    {
                        try
                        {
                            odbcCommand.CommandText = "drop table " + current.Key;
                            odbcCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void 添加新数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                return;
            }
            if (!this.mCurTable.IsCheckedOut)
            {
                MessageBox.Show("请先签出后再修改！");
                return;
            }
            NewData newData = new NewData();
            newData.StartPosition = FormStartPosition.Manual;
            newData.Location = Cursor.Position;
            if (newData.ShowDialog() == DialogResult.OK)
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    odbcConnection.Open();
                    string cmdText = string.Concat(new string[]
                    {
                        "INSERT INTO DataItem (TemplateName, DataTableId, DataState, CreateUserId) VALUES (N'",
                        newData.TemplateName,
                        "', ",
                        this.mCurTable.Id.ToString(),
                        ", 1,",
                        this.mCurUser.ToString(),
                        ")"
                    });
                    OdbcCommand odbcCommand = new OdbcCommand(cmdText, odbcConnection);
                    odbcCommand.ExecuteNonQuery();
                    cmdText = "select max(DataItemId) from DataItem";
                    odbcCommand = new OdbcCommand(cmdText, odbcConnection);
                    long arg_F4_0 = (long) odbcCommand.ExecuteScalar();
                }
                this.UpdateRightGrid();
            }
        }

        private void UpdateRightGrid()
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                return;
            }
            DataTable dataTable = new DataTable();
            using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
            {
                using (
                    OdbcDataAdapter odbcDataAdapter =
                        new OdbcDataAdapter(
                            "select User.UserName, DataItem.Time, DataItem.Comment from User, DataItem where (User.UserId=DataItem.UserId and DataItem.DataTableId=" +
                            this.mCurTable.Id.ToString() + ") order by DataItem.Time desc;",
                            odbcConnection))
                {
                    using (new OdbcCommandBuilder(odbcDataAdapter))
                    {
                        dataTable.Clear();
                        odbcConnection.Open();
                        odbcDataAdapter.Fill(dataTable);
                    }
                }
            }
            this.dataGridView2.DataSource = dataTable;
        }

        private void LoadAllTableInfo()
        {
            try
            {
                using (var odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    odbcConnection.Open();
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    string commandText =
                        "select DataStatus.TableName, DataStatus.TableId, DataStatus.IsCheckedOut, User.UserName from DataStatus, User where (User.UserId=DataStatus.CheckOutUserId)";

                    odbcCommand.CommandText = commandText;
                    OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();

                    Dictionary<string, DDataTable> dt = new Dictionary<string, DDataTable>();
                    foreach (var t in Program.ddb.Table)
                    {
                        dt.Add(t.Key.ToLower(), t.Value);
                    }

                    int c = 0;
                    while (odbcDataReader.Read())
                    {
                        c++;
                        DDataTable table;
                        if (dt.TryGetValue(odbcDataReader.GetString(0).ToLower(), out table))
                        {
                            table.Id = odbcDataReader.GetInt64(1);
                            table.IsCheckedOut = odbcDataReader.GetBoolean(2);
                            table.User = odbcDataReader.GetString(3);

                            foreach (KeyValuePair<string, DColumn> current in table.Columns)
                            {
                                if (current.Value.Type == ColumnTypes.Refid && current.Value.Table == "sys_id_template")
                                {
                                    table.SysIdColumn = current.Value;
                                }
                            }
                        }
                    }
                    odbcDataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTableInfo(DDataTable table)
        {
            try
            {
                using (var odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    odbcConnection.Open();
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    string commandText =
                        "select DataStatus.TableId, DataStatus.IsCheckedOut, User.UserName from DataStatus, User where (DataStatus.TableName=N'" +
                        table.Name +
                        "') and (User.UserId=DataStatus.CheckOutUserId)";
                    odbcCommand.CommandText = commandText;
                    OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
                    if (odbcDataReader.Read())
                    {
                        table.Id = odbcDataReader.GetInt64(0);
                        table.IsCheckedOut = odbcDataReader.GetBoolean(1);
                        table.User = odbcDataReader.GetString(2);
                        odbcDataReader.Close();
                    }
                    else
                    {
                        odbcDataReader.Close();
                    }

                    foreach (KeyValuePair<string, DColumn> current in table.Columns)
                    {
                        if (current.Value.Type == ColumnTypes.Refid && current.Value.Table == "sys_id_template")
                        {
                            table.SysIdColumn = current.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTable(DDataTable table)
        {
            if (table != null)
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    odbcConnection.Open();
                    StringBuilder sb = new StringBuilder();

                    sb.Append("修改了Id");
                    foreach (object current in table.DataTable.Rows)
                    {
                        DataRow dataRow = (DataRow) current;
                        if (dataRow.RowState != DataRowState.Unchanged)
                        {
                            sb.Append(",");
                            sb.Append(dataRow[0]);
                        }
                    }
                    var comment = sb.ToString();
                    string commandText = "INSERT INTO DataItem(Comment, DataTableId, Time, UserId) VALUES(N'" + comment.Substring(0, Math.Min(120, comment.Length)) + "', " + table.Id + ", NOW(), " + mCurUser + ")";
                    odbcCommand.CommandText = commandText;
                    odbcCommand.ExecuteNonQuery();
                }
                using (OdbcConnection odbcConnection2 = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    using (
                        OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter("select * from " + table.Name,
                            odbcConnection2))
                    {
                        using (OdbcCommandBuilder odbcCommandBuilder = new OdbcCommandBuilder())
                        {
                            odbcCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                            odbcCommandBuilder.SetAllValues = false;
                            odbcCommandBuilder.DataAdapter = odbcDataAdapter;
                            odbcDataAdapter.AcceptChangesDuringUpdate = false;
                            odbcDataAdapter.RowUpdating += (o, e) =>
                            {
                                e.Status = UpdateStatus.Continue;
                            };
                            try
                            {
                                odbcConnection2.Open();
                                odbcDataAdapter.Update(table.DataTable);
                                table.DataTable.AcceptChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                    }
                }
                this.UpdateRightGrid();
            }
        }

        private void CheckInButton_Click(object sender, EventArgs e)
        {
            if (!this.IsCheckInValid())
            {
                MessageBox.Show("数据表无法被签入！");
                return;
            }
            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    string commandText = "UPDATE DataStatus SET IsCheckedOut = 0 WHERE (TableId = " +
                                         this.mCurTable.Id.ToString() + ")";
                    odbcCommand.CommandText = commandText;
                    odbcConnection.Open();
                    odbcCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.mCurTable.IsCheckedOut = false;
            if (this.mCurTable.IsCheckedOut)
            {
                this.mCurTreeNode.Text = this.mCurTable.Alias + "(" + this.mCurTable.User + " CheckedOut)";
            }
            else
            {
                this.mCurTreeNode.Text = this.mCurTable.Alias;
            }
            this.updateButtonState();
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            if (!this.IsCheckOutValid())
            {
                MessageBox.Show("数据表无法被签出！");
                return;
            }
            using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
            {
                OdbcCommand odbcCommand = new OdbcCommand();
                odbcCommand.Connection = odbcConnection;
                string commandText = string.Concat(new object[]
                {
                    "UPDATE DataStatus SET IsCheckedOut = 1, CheckOutUserId = ",
                    this.mCurUser,
                    " WHERE (TableId = ",
                    this.mCurTable.Id.ToString(),
                    ")"
                });
                odbcCommand.CommandText = commandText;
                odbcConnection.Open();
                odbcCommand.ExecuteNonQuery();
            }
            this.mCurTable.IsCheckedOut = true;
            this.mCurTable.User = Program.user_name;
            if (this.mCurTable.IsCheckedOut)
            {
                this.mCurTreeNode.Text = this.mCurTable.Alias + "(" + Program.user_name + " CheckedOut)";
            }
            else
            {
                this.mCurTreeNode.Text = this.mCurTable.Alias;
            }
            this.treeView1_AfterSelect(this.treeView1, new TreeViewEventArgs(this.treeView1.SelectedNode));
            this.updateButtonState();
        }

        private bool IsCheckInValid()
        {
            bool result = false;
            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    string commandText = "SELECT IsCheckedOut, CheckOutUserId FROM DataStatus WHERE (TableId = " +
                                         this.mCurTable.Id.ToString() + ")";
                    odbcCommand.CommandText = commandText;
                    odbcConnection.Open();
                    OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
                    odbcDataReader.Read();
                    if (odbcDataReader.GetInt16(0) != 0 && odbcDataReader.GetInt64(1) == this.mCurUser)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        private bool IsCheckOutValid()
        {
            bool result = false;
            try
            {
                using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
                {
                    OdbcCommand odbcCommand = new OdbcCommand();
                    odbcCommand.Connection = odbcConnection;
                    string commandText = "SELECT IsCheckedOut, CheckOutUserId FROM DataStatus WHERE (TableId = " +
                                         this.mCurTable.Id.ToString() + ")";
                    odbcCommand.CommandText = commandText;
                    odbcConnection.Open();
                    OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
                    odbcDataReader.Read();
                    if ((int) odbcDataReader["IsCheckedOut"] != 1)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                return;
            }
            if (!this.mCurTable.IsCheckedOut)
            {
                MessageBox.Show("请先签出数据表");
                return;
            }
            if (this.mCurTable.User.Trim() != Program.user_name.Trim())
            {
                MessageBox.Show("此表已经被其他用户签出");
                return;
            }
            try
            {
                this.mCurBinding.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (this.mNewDataMode)
            {
                DataTable dataTable = (DataTable) this.mCurBinding.DataSource;
                if (dataTable != null)
                {
                    foreach (object current in dataTable.Rows)
                    {
                        if (((DataRow) current).RowState != DataRowState.Unchanged)
                        {
                            this.mCurTable.DataTable.Rows.Add(((DataRow) current).ItemArray);
                        }
                    }
                }
            }
            DataTable changes = this.mCurTable.DataTable.GetChanges(DataRowState.Modified);
            DataTable changes2 = this.mCurTable.DataTable.GetChanges(DataRowState.Added);
            if (changes != null || changes2 != null)
            {
                if (new DataViewer
                {
                    Title = "数据被修改，是否保存？",
                    BKColor = Color.Red,
                    ModifiedTable = changes,
                    AddedTable = changes2,
                    StartPosition = FormStartPosition.Manual,
                    Location = Cursor.Position,
                    DTable = this.mCurTable
                }.ShowDialog() == DialogResult.OK)
                {
                    this.SaveTable(this.mCurTable);
                    if (this.mNewDataMode)
                    {
                        DataTable dataTable2 = (DataTable) this.mCurBinding.DataSource;
                        for (int i = 0; i < dataTable2.Rows.Count; i++)
                        {
                            if (dataTable2.Rows[i].RowState != DataRowState.Unchanged)
                            {
                                dataTable2.Rows.RemoveAt(i);
                            }
                        }
                        dataTable2.AcceptChanges();
                        return;
                    }
                }
                else if (this.mNewDataMode)
                {
                    this.mCurTable.DataTable.RejectChanges();
                }
            }
        }

        private void 显示新数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                return;
            }
            this.mCurTable.DataTable.RejectChanges();
            DataTable dataTable = this.mCurTable.DataTable.Clone();
            using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
            {
                odbcConnection.Open();
                string cmdText = "Select DataItemId from DataItem where (DataTableId=" + this.mCurTable.Id.ToString() +
                                 ") and (DataState=1)";
                OdbcCommand odbcCommand = new OdbcCommand(cmdText, odbcConnection);
                OdbcDataReader odbcDataReader = odbcCommand.ExecuteReader();
                while (odbcDataReader.Read())
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[this.mCurTable.SysIdColumn.Name] = odbcDataReader.GetInt64(0);
                    dataTable.Rows.Add(dataRow);
                }
            }
            dataTable.AcceptChanges();
            this.mCurBinding.DataSource = dataTable;
            this.mNewDataMode = true;
        }

        private void 显示旧数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                return;
            }
            this.mCurBinding.DataSource = this.mCurTable.DataTable;
            this.mNewDataMode = false;
        }

        private void export_Click(object sender, EventArgs e)
        {
           Export(true);
        }

        private void Export(bool utf8)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                return;
            }
            Encoding encoding = Encoding.UTF8;

            if (!utf8)
            {
                encoding = Encoding.Default;
            }

            this.saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            this.saveFileDialog1.SupportMultiDottedExtensions = false;
            this.saveFileDialog1.FileName = this.mCurTable.Name;
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextWriter textWriter = null;
                if (File.Exists(this.saveFileDialog1.FileName))
                {
                    FileAttributes attributes = File.GetAttributes(this.saveFileDialog1.FileName);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly &&
                        MessageBox.Show("去掉写保护继续保存？", "DataEditor", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        File.SetAttributes(this.saveFileDialog1.FileName, attributes & ~FileAttributes.ReadOnly);
                    }
                }
                try
                {
                    textWriter = new StreamWriter(this.saveFileDialog1.FileName, false, encoding);
                }
                catch (Exception)
                {
                    MessageBox.Show("文件无法保存!");
                    return;
                }
                string name = this.mCurTable.Key.Columns[0].Name;
                this.mCurTable.DataTable.DefaultView.Sort = name + " ASC";
                DataTable dataTable = this.mCurTable.DataTable.DefaultView.ToTable();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    try
                    {
                        textWriter.Write(Converter.PortedType(dataTable.Columns[i].DataType));
                        if (i + 1 < dataTable.Columns.Count)
                        {
                            textWriter.Write("\t");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export table " + dataTable.TableName + " error" + ex.ToString());
                    }

                }
                textWriter.WriteLine();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    textWriter.Write(this.mCurTable.Columns[dataTable.Columns[j].ColumnName].Alias);
                    if (j + 1 < dataTable.Columns.Count)
                    {
                        textWriter.Write("\t");
                    }
                }
                textWriter.WriteLine();
                textWriter.Write("#" + this.mCurTable.Name);
                for (int k = 0; k < dataTable.Columns.Count; k++)
                {
                    if (k + 1 < dataTable.Columns.Count)
                    {
                        textWriter.Write("\t");
                    }
                }
                textWriter.WriteLine();
                foreach (object current in dataTable.Rows)
                {
                    for (int l = 0; l < ((DataRow)current).ItemArray.Length; l++)
                    {
                        textWriter.Write(((DataRow)current).ItemArray[l]);
                        if (l + 1 < ((DataRow)current).ItemArray.Length)
                        {
                            textWriter.Write("\t");
                        }
                    }
                    textWriter.WriteLine();
                }
                textWriter.Close();
            }
        }


        private string Skip_Comment(StreamReader st)
        {
            string text = st.ReadLine();
            this.mImportLineNum++;
            while (text != null && (text[0] == '#' || text[0] == '\t'))
            {
                text = st.ReadLine();
                this.mImportLineNum++;
            }
            return text;
        }

        public System.Text.Encoding GetFileEncodeType(string filename)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open,
                System.IO.FileAccess.Read))
            using (System.IO.BinaryReader br = new System.IO.BinaryReader(fs))
            {
                Byte[] buffer = br.ReadBytes(2);
                if (buffer[0] >= 0xEF)
                {
                    if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                    {
                        return System.Text.Encoding.UTF8;
                    }
                    else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                    {
                        return System.Text.Encoding.BigEndianUnicode;
                    }
                    else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                    {
                        return System.Text.Encoding.Unicode;
                    }
                    else
                    {
                        return System.Text.Encoding.Default;
                    }
                }
                else
                {
                    return System.Text.Encoding.Default;
                }
            }
        }


        private void Import_Click(object sender, EventArgs e)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                return;
            }
            this.openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            this.openFileDialog1.SupportMultiDottedExtensions = false;
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = Encoding.Default;
                StreamReader streamReader = null;
                try
                {
                    File.Copy(this.openFileDialog1.FileName, this.openFileDialog1.FileName + ".tmp", true);
                    FileAttributes attributes = File.GetAttributes(this.openFileDialog1.FileName + ".tmp");
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        File.SetAttributes(this.openFileDialog1.FileName + ".tmp", attributes & ~FileAttributes.ReadOnly);
                    }

                    encoding = GetFileEncodeType(this.openFileDialog1.FileName);

                    Stream stream = File.OpenRead(this.openFileDialog1.FileName + ".tmp");
                    streamReader = new StreamReader(stream, encoding);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件无法打开! " + ex.Message);
                    File.Delete(this.openFileDialog1.FileName + ".tmp");
                    return;
                }
                this.mImportLineNum = 0;
                mCurTable.ImportedIds.Clear();
                DataTable dataTable = this.mCurTable.DataTable.Clone();
                dataTable.TableName = this.mCurTable.Name;
                dataTable.ColumnChanged += new DataColumnChangeEventHandler(this.dt_ColumnChanged);

                // 先读一遍表，把id整理出来
                {
                    this.Skip_Comment(streamReader);
                    this.Skip_Comment(streamReader);
                    string text1 = this.Skip_Comment(streamReader);
                    while (text1 != null)
                    {
                        string[] array3 = text1.Split(new char[]
                        {
                            '\t'
                        });

                        if (array3.Length <= 0)
                        {
                            MessageBox.Show("数据格式不正确，有的列没有id");
                            return;
                        }

                        try
                        {
                            mCurTable.ImportedIds.Add(long.Parse(array3[0]));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("current line:" + (mImportLineNum - 3) + " id " + array3[0] + ex.ToString());
                            mCurTable.ImportedIds.Clear();
                            return;
                        }

                        text1 = this.Skip_Comment(streamReader);
                    }

                    streamReader.Close();
                }

                streamReader = new StreamReader(this.openFileDialog1.FileName + ".tmp", encoding);
                this.mImportLineNum = 0;
                this.Skip_Comment(streamReader);
                this.Skip_Comment(streamReader);
                string text = streamReader.ReadLine();
                this.mImportLineNum++;
                string text2 = text.Substring(1);
                if (text2.Trim() != this.mCurTable.Name)
                {
                    streamReader.Close();
                    MessageBox.Show("数据和当前表不一致，请检查后再导入！");
                    File.Delete(this.openFileDialog1.FileName + ".tmp");
                }
                else
                {
                    text = this.Skip_Comment(streamReader);
                    this.toolStripProgressBar1.Value = 0;
                    int count = this.mCurTable.Columns.Count;
                    double num = 70.0/(double) count;
                    double num2 = 0.0;
                    List<string> list = new List<string>();
                    foreach (KeyValuePair<string, DColumn> current in this.mCurTable.Columns)
                    {
                        if (current.Value.Type == ColumnTypes.Refid)
                        {
                            string[] array = current.Value.Table.Split(new char[]
                            {
                                ','
                            });
                            string[] array2 = array;
                            string table_str;
                            for (int i = 0; i < array2.Length; i++)
                            {
                                table_str = array2[i];
                                if (Program.ddb.Table.ContainsKey(table_str))
                                {
                                    if (!list.Exists((string k) => table_str == k))
                                    {
                                        Program.ddb.Table[table_str].LoadData();
                                        list.Add(table_str);
                                        num2 += num;
                                        this.toolStripProgressBar1.Increment((int) Math.Ceiling(num2));
                                    }
                                }
                            }
                        }
                    }
                    this.toolStripProgressBar1.Value = 70;
                    while (text != null)
                    {
                        string[] array3 = text.Split(new char[]
                        {
                            '\t'
                        });
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = 0; j < array3.Length; j++)
                        {
                            if (array3[j].Length == 0)
                            {
                                array3[j] = this.mCurTable.Columns[dataTable.Columns[j].ColumnName].DefaultValue;
                            }

                            array3[j] = array3[j].Trim(new char[]
                            {
                                '"'
                            });
                        }
                        try
                        {
                            dataRow.ItemArray = array3;
                            dataTable.Rows.Add(dataRow);
                        }
                        catch (Exception ex2)
                        {
                            streamReader.Close();
                            MessageBox.Show(string.Concat(new object[]
                            {
                                ex2.Message,
                                "第 ",
                                this.mImportLineNum - 3,
                                "行"
                            }));
                            mCurTable.ImportedIds.Clear();
                            return;
                        }
                        text = this.Skip_Comment(streamReader);
                    }
                    streamReader.Close();
                    this.toolStripProgressBar1.Value = 80;
                    StringBuilder stringBuilder = new StringBuilder();
                    if (dataTable.HasErrors)
                    {
                        DataRow[] errors = dataTable.GetErrors();
                        for (int k2 = 0; k2 < errors.Length; k2++)
                        {
                            DataRow dataRow2 = errors[k2];
                            stringBuilder.Append(dataRow2.RowError);
                        }
                        Messages messages = new Messages();
                        messages.AddMessage(stringBuilder.ToString());
                        messages.ShowDialog();
                        File.Delete(this.openFileDialog1.FileName + ".tmp");
                        mCurTable.ImportedIds.Clear();
                        return;
                    }
                    this.mCurBinding.SuspendBinding();
                    this.toolStripProgressBar1.Value = 90;
                    streamReader = new StreamReader(this.openFileDialog1.FileName + ".tmp", encoding);
                    this.mImportLineNum = 0;
                    this.Skip_Comment(streamReader);
                    this.Skip_Comment(streamReader);
                    streamReader.ReadLine();
                    for (text = this.Skip_Comment(streamReader); text != null; text = this.Skip_Comment(streamReader))
                    {
                        string[] array4 = text.Split(new char[]
                        {
                            '\t'
                        });
                        DataRow dataRow3 = this.mCurTable.DataTable.NewRow();
                        for (int l = 0; l < array4.Length; l++)
                        {
                            if (array4[l].Length == 0)
                            {
                                array4[l] = this.mCurTable.Columns[dataTable.Columns[l].ColumnName].DefaultValue;
                            }

                            array4[l] = array4[l].Trim(new char[]
                            {
                                '"'
                            });
                        }
                        dataRow3.ItemArray = array4;
                        string text3 = "";
                        for (int m = 0; m < this.mCurTable.Key.Columns.Count; m++)
                        {
                            string str;
                            if (this.mCurTable.Key.Columns[m].Type == ColumnTypes.String)
                            {
                                str = "'" + dataRow3[this.mCurTable.Key.Columns[m].Name] + "'";
                            }
                            else
                            {
                                str = dataRow3[this.mCurTable.Key.Columns[m].Name].ToString();
                            }
                            text3 = text3 + this.mCurTable.Key.Columns[m].Name + "=" + str;
                            if (m + 1 < this.mCurTable.Key.Columns.Count)
                            {
                                text3 += " and ";
                            }
                        }
                        DataRow[] array5 = this.mCurTable.DataTable.Select(text3);
                        if (array5.Length == 1)
                        {
                            bool flag = false;
                            for (int n = 0; n < this.mCurTable.DataTable.Columns.Count; n++)
                            {
                                if (array5[0].ItemArray[n].ToString().Trim() != array4[n].Trim())
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                array5[0].ItemArray = dataRow3.ItemArray;
                                array5[0].EndEdit();
                                this.mCurBinding.EndEdit();
                            }
                        }
                        else
                        {
                            if (array5.Length != 0)
                            {
                                this.mCurTable.DataTable.RejectChanges();
                                MessageBox.Show("数据有误,无法导入！");
                                break;
                            }
                            this.mCurTable.DataTable.Rows.Add(dataRow3);
                            if (dataRow3.RowState == DataRowState.Unchanged)
                            {
                                dataRow3.SetAdded();
                            }
                            else
                            {
                                dataRow3.AcceptChanges();
                                dataRow3.SetAdded();
                            }
                        }
                    }
                    streamReader.Close();
                    this.mCurBinding.ResumeBinding();
                    File.Delete(this.openFileDialog1.FileName + ".tmp");
                    this.toolStripProgressBar1.Value = 100;
                    mCurTable.ImportedIds.Clear();
                    return;
                }
                return;
            }
        }

        private void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DColumn dColumn = this.mCurTable.Columns[e.Column.ColumnName];
            switch (dColumn.Type)
            {
                case ColumnTypes.Enum:
                {
                    string[] array = dColumn.Value.Split(new char[]
                    {
                        ','
                    });
                    if (Convert.ToInt32(e.ProposedValue.ToString()) >= array.Length ||
                        Convert.ToInt32(e.ProposedValue.ToString()) < -1)
                    {
                        DataRow expr_95 = e.Row;
                        object rowError = expr_95.RowError;
                        expr_95.RowError = string.Concat(new object[]
                        {
                            rowError,
                            "\n第",
                            this.mImportLineNum - 3,
                            "行，第",
                            (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                            "列 enum 超出限制！",
							"\n",
							dColumn.Alias
                        });
                        return;
                    }
                    break;
                }
                case ColumnTypes.Refid:
                {
                    bool flag = false;
                    if (Convert.ToInt64(e.ProposedValue.ToString()) == -1L)
                    {
                        flag = true;
                    }
                    else
                    {
                        string[] array = dColumn.Table.Split(new char[]
                        {
                            ','
                        });
                        string[] array2 = array;
                        for (int i = 0; i < array2.Length; i++)
                        {
                            string key = array2[i];
                            if (Program.ddb.Table.ContainsKey(key))
                            {
                                if (Program.ddb.Table[key].Key.Columns.Count != 1)
                                {
                                    DataRow expr_193 = e.Row;
                                    object rowError2 = expr_193.RowError;
                                    expr_193.RowError = string.Concat(new object[]
                                    {
                                        rowError2,
                                        "\n第",
                                        this.mImportLineNum - 3,
                                        "行，第",
                                        (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                                        "列 多重索引无法解析！",
										"\n",
										dColumn.Alias
                                    });
                                }
                                else
                                {
                                    flag = Program.ddb.Table[key].ContainsId(Convert.ToInt64(e.ProposedValue));
                                    if (flag)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (key == ((DataTable) sender).TableName)
                                        {
                                            flag = Program.ddb.Table[key].ImportedIds.Contains(Convert.ToInt64(e.ProposedValue));
                                        }

                                        if(flag)
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    if (!flag)
                    {
                        DataRow expr_24C = e.Row;
                        object rowError3 = expr_24C.RowError;
                        expr_24C.RowError = string.Concat(new object[]
                        {
                            rowError3,
                            "\n第",
                            this.mImportLineNum - 3,
                            "行，第",
                            (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                            "列 索引无效！",
							"\n",
							dColumn.Alias
                        });
                        return;
                    }
                    break;
                }
                case ColumnTypes.String:
                    if (e.ProposedValue.ToString().Length > dColumn.Length)
                    {
                        DataRow expr_2E4 = e.Row;
                        object rowError4 = expr_2E4.RowError;
                        expr_2E4.RowError = string.Concat(new object[]
                        {
                            rowError4,
                            "\n第",
                            this.mImportLineNum - 3,
                            "行，第",
                            (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                            "列 字符串超长！"
                        });
                        return;
                    }
                    break;
                case ColumnTypes.Integer:
                    if ((double) Convert.ToInt64(e.ProposedValue.ToString()) < dColumn.Range.LowerBound ||
                        (double) Convert.ToInt64(e.ProposedValue.ToString()) > dColumn.Range.UpperBound)
                    {
                        DataRow expr_3A0 = e.Row;
                        object rowError5 = expr_3A0.RowError;
                        expr_3A0.RowError = string.Concat(new object[]
                        {
                            rowError5,
                            "\n第",
                            this.mImportLineNum - 3,
                            "行，第",
                            (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                            "列 整数超出范围！",
							"\n",
							dColumn.Alias,
							"[",
							dColumn.Range.LowerBound,
							"~",
							dColumn.Range.UpperBound,
							"]",
                        });
                        return;
                    }
                    break;
                case ColumnTypes.Long:
                    if ((double) Convert.ToInt64(e.ProposedValue.ToString()) < dColumn.Range.LowerBound ||
                        (double) Convert.ToInt64(e.ProposedValue.ToString()) > dColumn.Range.UpperBound)
                    {
                        DataRow expr_45C = e.Row;
                        object rowError6 = expr_45C.RowError;
                        expr_45C.RowError = string.Concat(new object[]
                        {
                            rowError6,
                            "\n第",
                            this.mImportLineNum - 3,
                            "行，第",
                            (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                            "列 数字超出范围！",
							"\n",
							dColumn.Alias,
							"[",
							dColumn.Range.LowerBound,
							"~",
							dColumn.Range.UpperBound,
							"]"
                        });
                        return;
                    }
                    break;
                case ColumnTypes.Float:
                    if ((double) Convert.ToSingle(e.ProposedValue.ToString()) < dColumn.Range.LowerBound ||
                        (double) Convert.ToSingle(e.ProposedValue.ToString()) > dColumn.Range.UpperBound)
                    {
                        DataRow expr_518 = e.Row;
                        object rowError7 = expr_518.RowError;
                        expr_518.RowError = string.Concat(new object[]
                        {
                            rowError7,
                            "\n第",
                            this.mImportLineNum - 3,
                            "行，第",
                            (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                            "列 数字超出范围！",
							"\n",
							dColumn.Alias,
							"[",
							dColumn.Range.LowerBound,
							"~",
							dColumn.Range.UpperBound,
							"]"
                        });
                        return;
                    }
                    e.ProposedValue = ((int)(Convert.ToSingle(e.ProposedValue.ToString())) * 100) / 100.0f;
                    break;
                case ColumnTypes.Set:
                {
                    string[] array = dColumn.Value.Split(new char[]
                    {
                        ','
                    });
                    if (Convert.ToInt64(e.ProposedValue.ToString()) >= (long) Math.Pow(2.0, (double) array.Length) ||
                        Convert.ToInt64(e.ProposedValue.ToString()) < -1L)
                    {
                        DataRow expr_5EA = e.Row;
                        object rowError8 = expr_5EA.RowError;
                        expr_5EA.RowError = string.Concat(new object[]
                        {
                            rowError8,
                            "\n第",
                            this.mImportLineNum - 3,
                            "行，第",
                            (e.Column.Table.Columns.IndexOf(e.Column) + 1).ToString(),
                            "列 集合非法！",
							"\n",
							dColumn.Alias
                        });
                    }
                    break;
                }
                default:
                    return;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                e.Cancel = true;
                return;
            }
            if (this.mCurTable.IsCheckedOut && Program.modify_right && this.mCurTable.SysIdColumn != null)
            {
                this.contextMenuStrip1.Items[0].Enabled = true;
                return;
            }
            this.contextMenuStrip1.Items[0].Enabled = false;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DColumn dColumn = this.mCurTable.Columns[this.mCurTable.DataTable.Columns[e.ColumnIndex].ColumnName];
            switch (dColumn.Type)
            {
                case ColumnTypes.Enum:
                case ColumnTypes.String:
                case ColumnTypes.Integer:
                case ColumnTypes.Long:
                case ColumnTypes.Float:
                    break;
                case ColumnTypes.Refid:
                {
                    DataViewer dataViewer = new DataViewer();
                    dataViewer.Title = "请选择数据：";
                    dataViewer.BKColor = Color.Blue;
                    dataViewer.OKButtonEnabled = false;
                    string[] array = dColumn.Table.Split(new char[]
                    {
                        ','
                    });
                    List<long> list = new List<long>();
                    string[] array2 = array;
                    for (int i = 0; i < array2.Length; i++)
                    {
                        string text = array2[i];
                        try
                        {
                            list.Add(Program.ddb.Table[text].Id);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(text + "表不存在，无法索引！");
                            e.Cancel = true;
                            return;
                        }
                    }
                    bool flag = false;
                    DataTable dataTable = new DataTable();
                    if (this.mCurTable.SysIdColumn != null)
                    {
                        using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString)
                            )
                        {
                            odbcConnection.Open();
                            string text2 = "Select DataItemId, TemplateName from DataItem where (DataState=0) and";
                            for (int j = 0; j < list.Count; j++)
                            {
                                text2 = text2 + "(DataTableId=" + list[j].ToString() + ")";
                                if (j + 1 < list.Count)
                                {
                                    text2 += " or ";
                                }
                            }
                            OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(text2, odbcConnection);
                            odbcDataAdapter.Fill(dataTable);
                            goto IL_3A9;
                        }
                    }
                    if (array.Length == 1)
                    {
                        if (DevMode)
                        {
                            using (
                                OdbcConnection odbcConnection2 =
                                    new OdbcConnection(Settings.Default.testConnectionString))
                            {
                                odbcConnection2.Open();
                                string selectCommandText = string.Concat(new string[]
                                {
                                    "Select * from ",
                                    array[0],
                                    " order by ",
                                    Program.ddb.Table[array[0]].Key.Columns[0].Name,
                                    " asc"
                                });
                                OdbcDataAdapter odbcDataAdapter2 = new OdbcDataAdapter(selectCommandText,
                                    odbcConnection2);
                                odbcDataAdapter2.Fill(dataTable);
                            }
                            dataViewer.DTable = Program.ddb.Table[array[0]];
                            dataViewer.Text = dataViewer.DTable.Alias;
                        }
                        else
                        {
                            dataViewer.DTable = Program.ddb.Table[array[0]];
                            dataViewer.DTable.LoadDataFromFile();
                            dataTable = dataViewer.DTable.DataTable;
                            dataViewer.Text = dataViewer.DTable.Alias;
                        }
                    }
                    else
                    {
                        SelectTable selectTable = new SelectTable();
                        string[] array3 = array;
                        for (int k = 0; k < array3.Length; k++)
                        {
                            string key = array3[k];
                            selectTable.Items.Add(Program.ddb.Table[key].Alias);
                        }
                        selectTable.StartPosition = FormStartPosition.Manual;
                        selectTable.Location = Cursor.Position;
                        if (selectTable.ShowDialog() == DialogResult.OK && selectTable.Selected >= 0)
                        {
                            if (DevMode)
                            {
                                using (
                                    OdbcConnection odbcConnection3 =
                                        new OdbcConnection(Settings.Default.testConnectionString))
                                {
                                    odbcConnection3.Open();
                                    string selectCommandText2 = string.Concat(new string[]
                                {
                                    "Select * from ",
                                    array[selectTable.Selected],
                                    " order by ",
                                    Program.ddb.Table[array[selectTable.Selected]].Key.Columns[0].Name,
                                    " asc"
                                });
                                    OdbcDataAdapter odbcDataAdapter3 = new OdbcDataAdapter(selectCommandText2,
                                        odbcConnection3);
                                    odbcDataAdapter3.Fill(dataTable);
                                }
                                dataViewer.DTable = Program.ddb.Table[array[selectTable.Selected]];
                                dataViewer.Text = dataViewer.DTable.Alias;
                            }
                            else
                            {
                                dataViewer.DTable = Program.ddb.Table[array[selectTable.Selected]];
                                dataViewer.DTable.LoadDataFromFile();
                                dataTable = dataViewer.DTable.DataTable;
                                dataViewer.Text = dataViewer.DTable.Alias;
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    IL_3A9:
                    if (!flag)
                    {
                        dataViewer.ModifiedTable = dataTable;
                        dataViewer.StartPosition = FormStartPosition.Manual;
                        dataViewer.Location = Cursor.Position;
                        if (dataViewer.ShowDialog() == DialogResult.Yes)
                        {
                            try
                            {
                                if (this.mCurTable.Columns[dColumn.Name].Type == ColumnTypes.Integer)
                                {
                                    ((DataRowView) this.dataGridView1.CurrentRow.DataBoundItem).Row[dColumn.Name] =
                                        Convert.ToInt64(dataViewer.SelectedId);
                                }
                                else if (this.mCurTable.Columns[dColumn.Name].Type == ColumnTypes.Long ||
                                         this.mCurTable.Columns[dColumn.Name].Type == ColumnTypes.Refid)
                                {
                                    ((DataRowView) this.dataGridView1.CurrentRow.DataBoundItem).Row[dColumn.Name] =
                                        dataViewer.SelectedId;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    e.Cancel = true;
                    return;
                }
                case ColumnTypes.Set:
                {
                    string[] array4 = dColumn.Value.Split(new char[]
                    {
                        ','
                    });
                    long value = (long) ((DataRowView) this.dataGridView1.CurrentRow.DataBoundItem).Row[dColumn.Name];
                    BitArray bitArray = new BitArray(BitConverter.GetBytes(value));
                    SetView setView = new SetView();
                    for (int l = 0; l < array4.Length; l++)
                    {
                        setView.Choices.Add(array4[l]);
                        setView.Choosed.Add(bitArray[l]);
                    }
                    this.dataGridView1.CurrentCell.GetContentBounds(e.RowIndex);
                    setView.StartPosition = FormStartPosition.Manual;
                    setView.Position = Cursor.Position;
                    if (setView.ShowDialog() == DialogResult.OK)
                    {
                        bitArray.SetAll(false);
                        for (int m = 0; m < array4.Length; m++)
                        {
                            bitArray.Set(m, setView.Choosed[m]);
                        }
                        byte[] array5 = new byte[8];
                        bitArray.CopyTo(array5, 0);
                        ((DataRowView) this.dataGridView1.CurrentRow.DataBoundItem).Row[dColumn.Name] =
                            BitConverter.ToInt64(array5, 0);
                    }
                    e.Cancel = true;
                    break;
                }
                default:
                    return;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DColumn dColumn = this.mCurTable.Columns[this.mCurTable.DataTable.Columns[e.ColumnIndex].ColumnName];
            switch (dColumn.Type)
            {
                case ColumnTypes.Enum:
                case ColumnTypes.Refid:
                case ColumnTypes.Set:
                    return;
                case ColumnTypes.String:
                    if (e.FormattedValue.ToString().Length > dColumn.Length)
                    {
                        MessageBox.Show("字符串太长！");
                        e.Cancel = true;
                        return;
                    }
                    return;
                case ColumnTypes.Integer:
                    try
                    {
                        double num = Convert.ToDouble(e.FormattedValue);
                        if (num < dColumn.Range.LowerBound || num > dColumn.Range.UpperBound)
                        {
                            MessageBox.Show(string.Concat(new string[]
                            {
                                "数字超出范围！",
                                dColumn.Alias,
                                "列 ",
                                (e.RowIndex + 1).ToString(),
                                "行！"
                            }));
                            e.Cancel = true;
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        e.Cancel = true;
                        return;
                    }
                    break;
                case ColumnTypes.Long:
                    break;
                case ColumnTypes.Float:
                    try
                    {
                        double num3 = Convert.ToDouble(e.FormattedValue);
                        if (num3 < dColumn.Range.LowerBound || num3 > dColumn.Range.UpperBound)
                        {
                            MessageBox.Show(string.Concat(new string[]
                            {
                                "数字超出范围！",
                                dColumn.Alias,
                                "列 ",
                                (e.RowIndex + 1).ToString(),
                                "行！"
                            }));
                            e.Cancel = true;
                        }
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.Message);
                        e.Cancel = true;
                    }
                    break;
                default:
                    return;
            }
            try
            {
                double num2 = Convert.ToDouble(e.FormattedValue);
                if (num2 < dColumn.Range.LowerBound || num2 > dColumn.Range.UpperBound)
                {
                    MessageBox.Show(string.Concat(new string[]
                    {
                        "数字超出范围！",
                        dColumn.Alias,
                        "列 ",
                        (e.RowIndex + 1).ToString(),
                        "行！"
                    }));
                    e.Cancel = true;
                }
                return;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
                e.Cancel = true;
                return;
            }

        }

        private void UpdateDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("更新数据库?", "DataEditor", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            DDB dDB = new DDB();
            XmlReader xmlReader = XmlReader.Create("test.xml", null,
                new XmlParserContext(null, null, null, XmlSpace.Default, Encoding.UTF8));
            dDB.ReadXml(xmlReader);
            xmlReader.Close();
            using (OdbcConnection odbcConnection = new OdbcConnection(Settings.Default.testConnectionString))
            {
                odbcConnection.Open();
                foreach (KeyValuePair<string, DDataTable> current in dDB.Table)
                {
                    DataTable dataTable = new DataTable();
                    using (
                        OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter("select * from " + current.Value.Name,
                            odbcConnection))
                    {
                        odbcDataAdapter.Fill(dataTable);
                    }
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if (!current.Value.Columns.ContainsKey(dataTable.Columns[i].ColumnName))
                        {
                            string cmdText = "alter table " + current.Key + " drop column " +
                                             dataTable.Columns[i].ColumnName;
                            OdbcCommand odbcCommand = new OdbcCommand(cmdText, odbcConnection);
                            try
                            {
                                odbcCommand.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                    }
                    foreach (KeyValuePair<string, DColumn> current2 in current.Value.Columns)
                    {
                        if (!dataTable.Columns.Contains(current2.Key))
                        {
                            string text = string.Concat(new string[]
                            {
                                "alter table ",
                                current.Key,
                                " add column ",
                                current2.Key,
                                " "
                            });
                            if (current2.Value.Type == ColumnTypes.String)
                            {
                                string text2 = text;
                                text = string.Concat(new string[]
                                {
                                    text2,
                                    Converter.ToDbType(current2.Value.Type).ToString(),
                                    "(",
                                    (current2.Value.Length*2).ToString(),
                                    ")"
                                });
                            }
                            else if (current2.Value.Type == ColumnTypes.Set)
                            {
                                text = text + Converter.ToDbType(current2.Value.Type).ToString();
                            }
                            else
                            {
                                text += Converter.ToDbType(current2.Value.Type).ToString();
                            }
                            if (current2.Value.DefaultValue != null)
                            {
                                if (current2.Value.DefaultValue.ToString().Length == 0)
                                {
                                    text += " default \"\"";
                                }
                                else
                                {
                                    if (current2.Value.Type == ColumnTypes.String)
                                        text = text + " default '" + current2.Value.DefaultValue.ToString() + "'";
                                    else
                                        text = text + " default " + current2.Value.DefaultValue.ToString();
                                }
                            }
                            else
                            {
                                text += " default 0";
                            }
                            OdbcCommand odbcCommand2 = new OdbcCommand(text, odbcConnection);
                            try
                            {
                                odbcCommand2.ExecuteNonQuery();
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.Message);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void grid1Menu_Opening(object sender, CancelEventArgs e)
        {
            if (this.mCurTable == null)
            {
                MessageBox.Show("请先选择数据表");
                e.Cancel = true;
                return;
            }
            if (this.mCurTable.SysIdColumn == null)
            {
                this.grid1Menu.Items[1].Enabled = false;
            }
            else
            {
                this.grid1Menu.Items[1].Enabled = true;
            }
            if (Program.modify_right)
            {
                this.grid1Menu.Items[0].Enabled = true;
            }
            else
            {
                this.grid1Menu.Items[0].Enabled = false;
            }
            if (this.dataGridView1.CurrentCell == null ||
                this.mCurTable.Columns[this.dataGridView1.CurrentCell.OwningColumn.DataPropertyName].DefaultValue ==
                null)
            {
                this.grid1Menu.Items[3].Enabled = false;
                return;
            }
            this.grid1Menu.Items[3].Enabled = true;
        }

        private void 新用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.add_user_right)
            {
                AddUser addUser = new AddUser();
                if (addUser.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("创建用户成功");
                }
            }
        }

        private void 恢复默认值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mCurTable != null)
            {
                try
                {
                    if (
                        this.mCurTable.Columns[this.dataGridView1.CurrentCell.OwningColumn.DataPropertyName]
                            .DefaultValue != null)
                    {
                        ((DataRowView) this.mCurBinding.Current).Row[
                            this.dataGridView1.CurrentCell.OwningColumn.DataPropertyName] =
                            this.mCurTable.Columns[this.dataGridView1.CurrentCell.OwningColumn.DataPropertyName]
                                .DefaultValue;
                        this.mCurBinding.EndEdit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 添加新数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataRowView dataRowView = (DataRowView) this.mCurBinding.AddNew();
            PrimaryKey primaryKey = new PrimaryKey();
            primaryKey.StartPosition = FormStartPosition.Manual;
            primaryKey.Location = Cursor.Position;
            foreach (DColumn current in this.mCurTable.Key.Columns)
            {
                primaryKey.Keys.Add(current.Alias);
            }
            if (primaryKey.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    object[] array = new object[dataRowView.Row.ItemArray.Length];
                    dataRowView.Row.ItemArray.CopyTo(array, 0);
                    for (int i = 0; i < primaryKey.Values.Count; i++)
                    {
                        int num = 0;
                        foreach (KeyValuePair<string, DColumn> current2 in this.mCurTable.Columns)
                        {
                            if (primaryKey.Keys[i] == current2.Value.Alias)
                            {
                                break;
                            }
                            num++;
                        }
                        array[num] = primaryKey.Values[i];
                    }
                    dataRowView.Row.ItemArray = array;
                    dataRowView.Row.EndEdit();
                    this.mCurBinding.EndEdit();
                    dataRowView.Row.AcceptChanges();
                    dataRowView.Row.SetAdded();
                    this.mCurBinding.EndEdit();
                    return;
                }
                catch (Exception ex)
                {
                    this.mCurBinding.CancelEdit();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            this.mCurBinding.CancelEdit();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mCurTreeNode == null)
            {
                return;
            }
            this.LoadTableInfo(this.mCurTable);
            if (this.mCurTable.IsCheckedOut)
            {
                this.mCurTreeNode.Text = this.mCurTable.Alias + "(" + this.mCurTable.User + " CheckedOut)";
                return;
            }
            this.mCurTreeNode.Text = this.mCurTable.Alias;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell != null)
            {
                this.toolStripStatusLabel1.Text = (this.dataGridView1.CurrentCell.ColumnIndex + 1).ToString() + "列" +
                                                  (this.dataGridView1.CurrentCell.RowIndex + 1).ToString() + "行";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExportAll(true);
        }

        private void ExportAll(bool utf8)
        {
            string str = "";
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software;
            software = key.OpenSubKey("software\\DataEditor\\" + DataName, true);
            if (software == null)
            {
                software = key.CreateSubKey("software\\DataEditor\\" + DataName);
            }
            var path = software.GetValue("LastExportedPath");
            if (path != null)
            {
                folderBrowserDialog1.SelectedPath = path.ToString();
            }
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                str = this.folderBrowserDialog1.SelectedPath;
                if (str != path)
                {
                    software.SetValue("LastExportedPath", str);
                }
                int num = 0;
                DDataTable dDataTable = this.mCurTable;
                foreach (KeyValuePair<string, DDataTable> current in Program.ddb.Table)
                {
                    this.mCurTable = current.Value;
                    this.mCurTable.LoadData();
                    string text = str + "\\" + this.mCurTable.Virtual;
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    string text2 = text + "\\" + this.mCurTable.Name + ".txt";
                    TextWriter textWriter = null;
                    if (File.Exists(text2))
                    {
                        FileAttributes attributes = File.GetAttributes(text2);
                        if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly &&
                            MessageBox.Show(text2 + "去掉写保护继续保存？", "DataEditor", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            File.SetAttributes(text2, attributes & ~FileAttributes.ReadOnly);
                        }
                    }
                    try
                    {
                        textWriter = new StreamWriter(text2, false, utf8 ? Encoding.UTF8 : Encoding.Default);
                    }
                    catch (Exception ex)
                    {
                        textWriter.Close();
                        MessageBox.Show("文件无法保存!" + ex.Message);
                        continue;
                    }
                    for (int i = 0; i < this.mCurTable.DataTable.Columns.Count; i++)
                    {
                        try
                        {
                            textWriter.Write(Converter.PortedType(this.mCurTable.DataTable.Columns[i].DataType));
                            if (i + 1 < this.mCurTable.DataTable.Columns.Count)
                            {
                                textWriter.Write("\t");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Export table " + mCurTable.Name + " error" + ex.ToString());
                        }
                    }
                    textWriter.WriteLine();
                    for (int j = 0; j < this.mCurTable.DataTable.Columns.Count; j++)
                    {
                        textWriter.Write(
                            this.mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].Alias);
                        if (j + 1 < this.mCurTable.DataTable.Columns.Count)
                        {
                            textWriter.Write("\t");
                        }
                    }
                    textWriter.WriteLine();
                    textWriter.Write("#" + this.mCurTable.Name);
                    textWriter.WriteLine();
                    foreach (object current2 in this.mCurTable.DataTable.Rows)
                    {
                        for (int k = 0; k < ((DataRow) current2).ItemArray.Length; k++)
                        {
                            textWriter.Write(((DataRow) current2).ItemArray[k]);
                            if (k + 1 < ((DataRow) current2).ItemArray.Length)
                            {
                                textWriter.Write("\t");
                            }
                        }
                        textWriter.WriteLine();
                    }
                    textWriter.Close();
                    num++;
                }
                MessageBox.Show("导出完成，共导出：" + num.ToString() + "个文件");
                this.mCurTable = dDataTable;
                key.Close();
                return;
            }
            key.Close();
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (this.mCurTable.Columns[this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName].Type ==
                    ColumnTypes.String)
                {
                    ToolStripTextBox expr_3C = this.toolStripTextBox1;
                    expr_3C.Text +=
                        this.mCurTable.Columns[this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName].Name;
                    ToolStripTextBox expr_82 = this.toolStripTextBox1;
                    expr_82.Text += " like '**'";
                    this.toolStripTextBox1.Focus();
                    this.toolStripTextBox1.Select(this.toolStripTextBox1.Text.Length - 2, 0);
                }
                else
                {
                    ToolStripTextBox expr_C8 = this.toolStripTextBox1;
                    expr_C8.Text +=
                        this.mCurTable.Columns[this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName].Name;
                    this.toolStripTextBox1.Focus();
                    this.toolStripTextBox1.Select(this.toolStripTextBox1.Text.Length, 0);
                }

                toolStripStatusLabel2.Text = this.dataGridView1.Columns[e.ColumnIndex].ToolTipText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                this.mCurTable.DataTable.DefaultView.RowFilter = this.toolStripTextBox1.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.toolStripButton4_Click(null, null);
            }
        }

        private void 导出服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var str = string.Empty;
            if (sender != null)
            {
                str = sender as string;
            }

            if (string.IsNullOrEmpty(str)|| sender == null)
            {
                str = Path.Combine(Directory.GetCurrentDirectory(), "../../Server/Tables");
            }

            int num = 0;
            DDataTable dDataTable = this.mCurTable;
            foreach (KeyValuePair<string, DDataTable> current in Program.ddb.Table)
            {
                if (!current.Value.ToServer)
                {
                    continue;
                }

                this.mCurTable = current.Value;
                this.mCurTable.LoadData();
                string text = str;
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string text2 = text + "\\" + this.mCurTable.Name + ".txt";
                TextWriter textWriter = null;
                if (File.Exists(text2))
                {
                    FileAttributes attributes = File.GetAttributes(text2);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly &&
                        MessageBox.Show(text2 + "去掉写保护继续保存？", "DataEditor", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        File.SetAttributes(text2, attributes & ~FileAttributes.ReadOnly);
                    }
                }
                try
                {
                    textWriter = new StreamWriter(text2, false, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    textWriter.Close();
                    MessageBox.Show("文件无法保存!" + ex.Message);
                    continue;
                }
                var firstColumn = true;
                for (int i = 0; i < this.mCurTable.DataTable.Columns.Count; i++)
                {
                    try
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[i].ColumnName].ToServer)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(Converter.PortedType(this.mCurTable.DataTable.Columns[i].DataType));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export table " + mCurTable.Name + " error" + ex.ToString());
                    }
                }
                textWriter.WriteLine(); 
                firstColumn = true;
                for (int j = 0; j < this.mCurTable.DataTable.Columns.Count; j++)
                {
                    if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].ToServer)
                    {
                        continue;
                    }

                    if (!firstColumn)
                    {
                        textWriter.Write("\t");
                    }
                    else
                    {
                        firstColumn = false;
                    }
                    textWriter.Write(this.mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].Alias);
                }
                textWriter.WriteLine();
                foreach (object current2 in this.mCurTable.DataTable.Rows)
                {
                    firstColumn = true;
                    for (int k = 0; k < ((DataRow) current2).ItemArray.Length; k++)
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[k].ColumnName].ToServer)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(((DataRow) current2).ItemArray[k]);
                    }
                    textWriter.WriteLine();
                }
                textWriter.Close();
                num++;
            }
            MessageBox.Show("导出完成，共导出：" + num.ToString() + "个文件到服务器");
            this.mCurTable = dDataTable;
            return;
        }

        private void 导出客户端表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var str = Path.Combine(Directory.GetCurrentDirectory(), "../../Client/Assets/Res/Table");
            int num = 0;
            DDataTable dDataTable = this.mCurTable;
            foreach (KeyValuePair<string, DDataTable> current in Program.ddb.Table)
            {
                if (!current.Value.ToClient)
                {
                    continue;
                }

                this.mCurTable = current.Value;
                this.mCurTable.LoadData();
                string text = str;
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string text2 = text + "\\" + this.mCurTable.Name + ".txt";
                TextWriter textWriter = null;
                if (File.Exists(text2))
                {
                    FileAttributes attributes = File.GetAttributes(text2);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly &&
                        MessageBox.Show(text2 + "去掉写保护继续保存？", "DataEditor", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        File.SetAttributes(text2, attributes & ~FileAttributes.ReadOnly);
                    }
                }
                try
                {
                    textWriter = new StreamWriter(text2, false, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    textWriter.Close();
                    MessageBox.Show("文件无法保存!" + ex.Message);
                    continue;
                }
                var firstColumn = true;
                for (int i = 0; i < this.mCurTable.DataTable.Columns.Count; i++)
                {
                    try
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[i].ColumnName].ToClient)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(Converter.PortedType(this.mCurTable.DataTable.Columns[i].DataType));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export table " + mCurTable.Name + " error" + ex.ToString());
                    }
                }
                textWriter.WriteLine();
                firstColumn = true;
                for (int j = 0; j < this.mCurTable.DataTable.Columns.Count; j++)
                {
                    if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].ToClient)
                    {
                        continue;
                    }

                    if (!firstColumn)
                    {
                        textWriter.Write("\t");
                    }
                    else
                    {
                        firstColumn = false;
                    }
                    if (Login.CodeTitle)
                    {
                        textWriter.Write(this.mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].CodeName);
                    }
                    else
                    {
                        textWriter.Write(this.mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].Alias);
                    }
                }
                textWriter.WriteLine();
                foreach (object current2 in this.mCurTable.DataTable.Rows)
                {
                    firstColumn = true;
                    for (int k = 0; k < ((DataRow) current2).ItemArray.Length; k++)
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[k].ColumnName].ToClient)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(((DataRow) current2).ItemArray[k]);
                    }
                    textWriter.WriteLine();
                }
                textWriter.Close();
                num++;
            }
            MessageBox.Show("导出完成，共导出：" + num.ToString() + "个文件到客户端");
            this.mCurTable = dDataTable;
            return;
        }

        private void 导出全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            导出客户端表格ToolStripMenuItem_Click(null, null);
            导出服务器ToolStripMenuItem_Click(null, null);
        }

        private void 导出服务器代码使用的表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "";
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software;
            software = key.OpenSubKey("software\\DataEditor\\" + DataName, true);
            if (software == null)
            {
                software = key.CreateSubKey("software\\DataEditor\\" + DataName);
            }
            var path = software.GetValue("LastServerExportedPath");
            if (path != null)
            {
                folderBrowserDialog1.SelectedPath = path.ToString();
            }

            if (FolderBrowserLauncher.ShowFolderBrowser(folderBrowserDialog1) == DialogResult.OK)
            {
                str = this.folderBrowserDialog1.SelectedPath;
                if (str != path)
                {
                    software.SetValue("LastServerExportedPath", str);
                }
                导出服务器ToolStripMenuItem_Click(folderBrowserDialog1.SelectedPath, null);
            }
            key.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TreeNode value;
            if (SearchNodes.TryGetValue(textBox1.Text, out value))
            {
                treeView1.SelectedNode = value;
            }
        }

        private void 导出Lua表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var str = Path.Combine(Directory.GetCurrentDirectory(), "../../Client/Assets/Lua/DataTable.lua");
            int num = 0;
            string text = str;
            TextWriter textWriter = new StreamWriter(text, false, Encoding.UTF8);

            textWriter.WriteLine("DataTable = DataTable or {}");
            textWriter.WriteLine("do");

            textWriter.WriteLine("    local function InitRecordMeta(meta)");
            textWriter.WriteLine("        meta.__index = function(t, k)");
            textWriter.WriteLine("            local column = meta[k]");
            textWriter.WriteLine("            if type(column) == 'number' then");
            textWriter.WriteLine("                return t[column]");
            textWriter.WriteLine("            else");
            textWriter.WriteLine("                local ccc = {}");
            textWriter.WriteLine("                setmetatable(ccc, {__index = function(c, k)");
            textWriter.WriteLine("                    if k == 'Length' then");
            textWriter.WriteLine("                        return column.Count");
            textWriter.WriteLine("                    end");
            textWriter.WriteLine("                    local subColumn = column[k + 100000000]");
            textWriter.WriteLine("                    if type(subColumn) == 'number' then");
            textWriter.WriteLine("                        return t[subColumn]");
            textWriter.WriteLine("                    else");
            textWriter.WriteLine("                        local cc = {}");
            textWriter.WriteLine("                        setmetatable(cc, {__index = function(c, k)");
            textWriter.WriteLine("                            local idx = subColumn[k + 100000000]");
            textWriter.WriteLine("                            return t[idx]");
            textWriter.WriteLine("                        end})");
            textWriter.WriteLine("                        return cc");
            textWriter.WriteLine("                    end");
            textWriter.WriteLine("                end})");
            textWriter.WriteLine("                return ccc");
            textWriter.WriteLine("            end");
            textWriter.WriteLine("        end");
            textWriter.WriteLine("    end");

            textWriter.WriteLine("");
            textWriter.WriteLine("    local Table = {}");
            textWriter.WriteLine("");

            DDataTable dDataTable = this.mCurTable;
            foreach (KeyValuePair<string, DDataTable> current in Program.ddb.Table)
            {
                if (!current.Value.ToClient)
                {
                    continue;
                }
                textWriter.WriteLine("    local m" + current.Key + "Meta = {}");
                int columnIndex = 1;
                HashSet<string> generated = new HashSet<string>();
                foreach (var column in current.Value.Columns)
                {
                    if (!column.Value.ToClient)
                    {
                        continue;
                    }

                    if (column.Value.CodeName.Contains("[0][0]"))
                    {
                        var name = column.Value.CodeName.Substring(0, column.Value.CodeName.Length - 6);
                        if (!generated.Contains(name))
                        {
                            textWriter.WriteLine("    m" + current.Key + "Meta." + name + " = {}");
                            generated.Add(name);
                        }
                    }
                    if (column.Value.CodeName.Contains("[0]"))
                    {
                        var name = column.Value.CodeName.Substring(0, column.Value.CodeName.Length - 3);

                        name = Regex.Replace(name, "[\\d+]", match =>
                        {
                            return (int.Parse(match.Groups[0].Captures[0].Value) + 100000000).ToString();
                        });

                        if (!generated.Contains(name))
                        {
                            var c = 0;
                            var reg = "^" + name + @"\[[0-9]+\]$";
                            foreach (var col in current.Value.Columns)
                            {
                                if (Regex.IsMatch(col.Value.CodeName, reg))
                                {
                                    c++;
                                }
                            }

                            textWriter.WriteLine("    m" + current.Key + "Meta." + name + " = {Count = " + c + "}");
                            generated.Add(name);
                        }
                    }

                    var s = Regex.Replace(column.Value.CodeName, "\\[(\\d+)\\]", match =>
                    {
                        return "[" + (int.Parse(match.Groups[1].Captures[0].Value) + 100000000) + "]";
                    });

                    textWriter.WriteLine("    m" + current.Key + "Meta." + s + " = " + columnIndex);
                    columnIndex++;
                }
                textWriter.WriteLine("    InitRecordMeta(m" + current.Key + "Meta)");

                textWriter.WriteLine("    local m" + current.Key + " = {");

                this.mCurTable = current.Value;
                this.mCurTable.LoadData();

                foreach (object current2 in this.mCurTable.DataTable.Rows)
                {
                    bool firstColumn = true;
                    for (int k = 0; k < ((DataRow)current2).ItemArray.Length; k++)
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[k].ColumnName].ToClient)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write(",");
                        }
                        else
                        {
                            firstColumn = false;
                            textWriter.Write("        [" + ((DataRow)current2).ItemArray[k] + "] = {");
                        }

                        if (((DataRow)current2).ItemArray[k].GetType() == typeof(string))
                        {
                            textWriter.Write("'");
                        }
                        textWriter.Write(((DataRow)current2).ItemArray[k]);
                        if (((DataRow)current2).ItemArray[k].GetType() == typeof(string))
                        {
                            textWriter.Write("'");
                        }
                    }
                    textWriter.WriteLine("},");
                }

                textWriter.WriteLine("    }");

                textWriter.WriteLine("    for _,v in pairs(m" + current.Key + ") do");
                textWriter.WriteLine("        setmetatable(v, m" + current.Key + "Meta)");
                textWriter.WriteLine("    end");


                textWriter.WriteLine("    function Table.Get" + current.Key + "(idx)");
                textWriter.WriteLine("        return m" + current.Key + "[idx]");
                textWriter.WriteLine("    end");

                num++;
            }

            textWriter.WriteLine("	DataTable.Table = Table");
            textWriter.WriteLine("end");

            textWriter.Close();

            MessageBox.Show("导出完成，共导出：" + num.ToString() + "个文件到客户端");
            this.mCurTable = dDataTable;
            return;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Export(false);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ExportAll(false);
        }

        private void 导出当前表格到客户端和服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var str = Path.Combine(Directory.GetCurrentDirectory(), "../../Client/Assets/Res/Table");

            if (mCurTable.ToClient)
            {
                if (DevMode)
                {
                    this.mCurTable.LoadData();
                }
                string text = str;
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string text2 = text + "\\" + this.mCurTable.Name + ".txt";
                TextWriter textWriter = null;
                if (File.Exists(text2))
                {
                    FileAttributes attributes = File.GetAttributes(text2);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly &&
                        MessageBox.Show(text2 + "去掉写保护继续保存？", "DataEditor", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        File.SetAttributes(text2, attributes & ~FileAttributes.ReadOnly);
                    }
                }
                try
                {
                    textWriter = new StreamWriter(text2, false, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    textWriter.Close();
                    MessageBox.Show("客户端文件无法保存!" + ex.Message);
                    return;
                }
                var firstColumn = true;
                for (int i = 0; i < this.mCurTable.DataTable.Columns.Count; i++)
                {
                    try
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[i].ColumnName].ToClient)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(Converter.PortedType(this.mCurTable.DataTable.Columns[i].DataType));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export table " + mCurTable.Name + " error" + ex.ToString());
                    }
                }
                textWriter.WriteLine();
                firstColumn = true;
                for (int j = 0; j < this.mCurTable.DataTable.Columns.Count; j++)
                {
                    if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].ToClient)
                    {
                        continue;
                    }

                    if (!firstColumn)
                    {
                        textWriter.Write("\t");
                    }
                    else
                    {
                        firstColumn = false;
                    }
                    if (Login.CodeTitle)
                    {
                        textWriter.Write(this.mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].CodeName);
                    }
                    else
                    {
                        textWriter.Write(this.mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].Alias);
                    }
                }
                textWriter.WriteLine();
                foreach (object current2 in this.mCurTable.DataTable.Rows)
                {
                    firstColumn = true;
                    for (int k = 0; k < ((DataRow) current2).ItemArray.Length; k++)
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[k].ColumnName].ToClient)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(((DataRow) current2).ItemArray[k]);
                    }
                    textWriter.WriteLine();
                }
                textWriter.Close();
            }


            str = Path.Combine(Directory.GetCurrentDirectory(), "../../Server/Tables");
            if (mCurTable.ToServer)
            {
                if(DevMode)
                    this.mCurTable.LoadData();
                string text = str;
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string text2 = text + "\\" + this.mCurTable.Name + ".txt";
                TextWriter textWriter = null;
                if (File.Exists(text2))
                {
                    FileAttributes attributes = File.GetAttributes(text2);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly &&
                        MessageBox.Show(text2 + "去掉写保护继续保存？", "DataEditor", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        File.SetAttributes(text2, attributes & ~FileAttributes.ReadOnly);
                    }
                }
                try
                {
                    textWriter = new StreamWriter(text2, false, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    textWriter.Close();
                    MessageBox.Show("服务器文件无法保存!" + ex.Message);
                    return;
                }
                var firstColumn = true;
                for (int i = 0; i < this.mCurTable.DataTable.Columns.Count; i++)
                {
                    try
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[i].ColumnName].ToServer)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(Converter.PortedType(this.mCurTable.DataTable.Columns[i].DataType));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export table " + mCurTable.Name + " error" + ex.ToString());
                    }
                }
                textWriter.WriteLine();
                firstColumn = true;
                for (int j = 0; j < this.mCurTable.DataTable.Columns.Count; j++)
                {
                    if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].ToServer)
                    {
                        continue;
                    }

                    if (!firstColumn)
                    {
                        textWriter.Write("\t");
                    }
                    else
                    {
                        firstColumn = false;
                    }
                    textWriter.Write(this.mCurTable.Columns[this.mCurTable.DataTable.Columns[j].ColumnName].Alias);
                }
                textWriter.WriteLine();
                foreach (object current2 in this.mCurTable.DataTable.Rows)
                {
                    firstColumn = true;
                    for (int k = 0; k < ((DataRow)current2).ItemArray.Length; k++)
                    {
                        if (!mCurTable.Columns[this.mCurTable.DataTable.Columns[k].ColumnName].ToServer)
                        {
                            continue;
                        }

                        if (!firstColumn)
                        {
                            textWriter.Write("\t");
                        }
                        else
                        {
                            firstColumn = false;
                        }
                        textWriter.Write(((DataRow)current2).ItemArray[k]);
                    }
                    textWriter.WriteLine();
                }
                textWriter.Close();
            }

            MessageBox.Show("导出完成");

            return;
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }

    public static class FolderBrowserLauncher
    {
        /// <summary>
        /// Using title text to look for the top level dialog window is fragile.
        /// In particular, this will fail in non-English applications.
        /// </summary>
        static string _topLevelSearchString = "浏览文件夹";

        /// <summary>
        /// These should be more robust.  We find the correct child controls in the dialog
        /// by using the GetDlgItem method, rather than the FindWindow(Ex) method,
        /// because the dialog item IDs should be constant.
        /// </summary>
        const int _dlgItemBrowseControl = 0;
        const int _dlgItemTreeView = 100;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Some of the messages that the Tree View control will respond to
        /// </summary>
        private const int TV_FIRST = 0x1100;
        private const int TVM_SELECTITEM = (TV_FIRST + 11);
        private const int TVM_GETNEXTITEM = (TV_FIRST + 10);
        private const int TVM_GETITEM = (TV_FIRST + 12);
        private const int TVM_ENSUREVISIBLE = (TV_FIRST + 20);

        /// <summary>
        /// Constants used to identity specific items in the Tree View control
        /// </summary>
        private const int TVGN_ROOT = 0x0;
        private const int TVGN_NEXT = 0x1;
        private const int TVGN_CHILD = 0x4;
        private const int TVGN_FIRSTVISIBLE = 0x5;
        private const int TVGN_NEXTVISIBLE = 0x6;
        private const int TVGN_CARET = 0x9;


        /// <summary>
        /// Calling this method is identical to calling the ShowDialog method of the provided
        /// FolderBrowserDialog, except that an attempt will be made to scroll the Tree View
        /// to make the currently selected folder visible in the dialog window.
        /// </summary>
        /// <param name="dlg"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static DialogResult ShowFolderBrowser(FolderBrowserDialog dlg, IWin32Window parent = null)
        {
            if (string.Compare(System.Globalization.CultureInfo.InstalledUICulture.Name, "zh-CN", StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                _topLevelSearchString = "浏览文件夹";
            }
            else if (string.Compare(System.Globalization.CultureInfo.InstalledUICulture.Name, "en-US", StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                _topLevelSearchString = "Browse For Folder";
            }
            

            DialogResult result = DialogResult.Cancel;
            int retries = 10;

            using (Timer t = new Timer())
            {
                t.Tick += (s, a) =>
                {
                    if (retries > 0)
                    {
                        --retries;
                        IntPtr hwndDlg = FindWindow((string)null, _topLevelSearchString);
                        if (hwndDlg != IntPtr.Zero)
                        {
                            IntPtr hwndFolderCtrl = GetDlgItem(hwndDlg, _dlgItemBrowseControl);
                            if (hwndFolderCtrl != IntPtr.Zero)
                            {
                                IntPtr hwndTV = GetDlgItem(hwndFolderCtrl, _dlgItemTreeView);

                                if (hwndTV != IntPtr.Zero)
                                {
                                    IntPtr item = SendMessage(hwndTV, (uint)TVM_GETNEXTITEM, new IntPtr(TVGN_CARET), IntPtr.Zero);
                                    if (item != IntPtr.Zero)
                                    {
                                        SendMessage(hwndTV, TVM_ENSUREVISIBLE, IntPtr.Zero, item);
                                        retries = 0;
                                        t.Stop();
                                    }
                                }
                            }
                        }
                    }

                    else
                    {
                        //
                        //  We failed to find the Tree View control.
                        //
                        //  As a fall back (and this is an UberUgly hack), we will send
                        //  some fake keystrokes to the application in an attempt to force
                        //  the Tree View to scroll to the selected item.
                        //
                        t.Stop();
                        SendKeys.Send("{TAB}{TAB}{DOWN}{DOWN}{UP}{UP}");
                    }
                };

                t.Interval = 10;
                t.Start();

                result = dlg.ShowDialog(parent);
            }

            return result;
        }
    }
}
