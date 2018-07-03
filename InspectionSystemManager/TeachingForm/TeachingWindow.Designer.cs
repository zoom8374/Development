namespace InspectionSystemManager
{
    partial class TeachingWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tabControlTeach = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInspectionAreaCopy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInspectionAreaSet = new System.Windows.Forms.Button();
            this.btnInspectionAreaDel = new System.Windows.Forms.Button();
            this.btnInspectionAreaAdd = new System.Windows.Forms.Button();
            this.gridViewArea = new System.Windows.Forms.DataGridView();
            this.gridAreaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAreaBenchMark = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridAreaEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridAreaNgNum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAlgorithmIndexMoveDown = new System.Windows.Forms.Button();
            this.btnAlgorithmIndexMoveUp = new System.Windows.Forms.Button();
            this.btnInspectionAlgoCopy = new System.Windows.Forms.Button();
            this.btnInspectionAlgoSet = new System.Windows.Forms.Button();
            this.gridViewAlgo = new System.Windows.Forms.DataGridView();
            this.gridAlgoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAlgoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAlgoBenchMark = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridAlgoEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnInspectionAlgoDel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInspectionAlgoAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.kpTeachDisplay = new KPDisplay.KPCogDisplayControl();
            this.panelTeaching = new CustomControl.PanelDoubleBuffer();
            this.gradientLabelTeaching = new CustomControl.GradientLabel();
            this.gradientLabel1 = new CustomControl.GradientLabel();
            this.tabControlTeach.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewArea)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAlgo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelTeaching.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.ForeColor = System.Drawing.Color.Gold;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1900, 30);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = " Recipe Teaching window";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(794, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(154, 35);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConfirm.Location = new System.Drawing.Point(634, 5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(154, 35);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // tabControlTeach
            // 
            this.tabControlTeach.Controls.Add(this.tabPage1);
            this.tabControlTeach.Controls.Add(this.tabPage2);
            this.tabControlTeach.Location = new System.Drawing.Point(947, 65);
            this.tabControlTeach.Name = "tabControlTeach";
            this.tabControlTeach.SelectedIndex = 0;
            this.tabControlTeach.Size = new System.Drawing.Size(952, 375);
            this.tabControlTeach.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(944, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inspection Area";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnInspectionAreaCopy);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnInspectionAreaSet);
            this.panel2.Controls.Add(this.btnInspectionAreaDel);
            this.panel2.Controls.Add(this.btnInspectionAreaAdd);
            this.panel2.Controls.Add(this.gridViewArea);
            this.panel2.Location = new System.Drawing.Point(0, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 406);
            this.panel2.TabIndex = 11;
            // 
            // btnInspectionAreaCopy
            // 
            this.btnInspectionAreaCopy.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAreaCopy.Location = new System.Drawing.Point(794, 103);
            this.btnInspectionAreaCopy.Name = "btnInspectionAreaCopy";
            this.btnInspectionAreaCopy.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAreaCopy.TabIndex = 8;
            this.btnInspectionAreaCopy.Text = "Inspection Area Copy";
            this.btnInspectionAreaCopy.UseVisualStyleBackColor = true;
            this.btnInspectionAreaCopy.Click += new System.EventHandler(this.btnInspectionAreaCopy_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(3, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 27);
            this.label6.TabIndex = 6;
            this.label6.Text = "Inspection Area";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInspectionAreaSet
            // 
            this.btnInspectionAreaSet.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAreaSet.Location = new System.Drawing.Point(794, 139);
            this.btnInspectionAreaSet.Name = "btnInspectionAreaSet";
            this.btnInspectionAreaSet.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAreaSet.TabIndex = 7;
            this.btnInspectionAreaSet.Text = "Inspection Area Set";
            this.btnInspectionAreaSet.UseVisualStyleBackColor = true;
            this.btnInspectionAreaSet.Click += new System.EventHandler(this.btnInspectionAreaSet_Click);
            // 
            // btnInspectionAreaDel
            // 
            this.btnInspectionAreaDel.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAreaDel.Location = new System.Drawing.Point(794, 67);
            this.btnInspectionAreaDel.Name = "btnInspectionAreaDel";
            this.btnInspectionAreaDel.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAreaDel.TabIndex = 2;
            this.btnInspectionAreaDel.Text = "Inspection Area -";
            this.btnInspectionAreaDel.UseVisualStyleBackColor = true;
            this.btnInspectionAreaDel.Click += new System.EventHandler(this.btnInspectionAreaDel_Click);
            // 
            // btnInspectionAreaAdd
            // 
            this.btnInspectionAreaAdd.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAreaAdd.Location = new System.Drawing.Point(794, 31);
            this.btnInspectionAreaAdd.Name = "btnInspectionAreaAdd";
            this.btnInspectionAreaAdd.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAreaAdd.TabIndex = 2;
            this.btnInspectionAreaAdd.Text = "Inspection Area +";
            this.btnInspectionAreaAdd.UseVisualStyleBackColor = true;
            this.btnInspectionAreaAdd.Click += new System.EventHandler(this.btnInspectionAreaAdd_Click);
            // 
            // gridViewArea
            // 
            this.gridViewArea.AllowUserToAddRows = false;
            this.gridViewArea.AllowUserToDeleteRows = false;
            this.gridViewArea.AllowUserToResizeColumns = false;
            this.gridViewArea.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridViewArea.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewArea.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("나눔바른고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewArea.ColumnHeadersHeight = 22;
            this.gridViewArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridAreaID,
            this.gridAreaName,
            this.gridAreaBenchMark,
            this.gridAreaEnable,
            this.gridAreaNgNum});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("나눔바른고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewArea.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridViewArea.EnableHeadersVisualStyles = false;
            this.gridViewArea.Location = new System.Drawing.Point(2, 31);
            this.gridViewArea.MultiSelect = false;
            this.gridViewArea.Name = "gridViewArea";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewArea.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridViewArea.RowHeadersVisible = false;
            this.gridViewArea.RowTemplate.Height = 23;
            this.gridViewArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewArea.Size = new System.Drawing.Size(785, 313);
            this.gridViewArea.TabIndex = 3;
            this.gridViewArea.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewArea_CellContentClick);
            this.gridViewArea.CurrentCellChanged += new System.EventHandler(this.gridViewArea_CurrentCellChanged);
            // 
            // gridAreaID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridAreaID.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridAreaID.HeaderText = "ID";
            this.gridAreaID.Name = "gridAreaID";
            this.gridAreaID.ReadOnly = true;
            this.gridAreaID.Width = 40;
            // 
            // gridAreaName
            // 
            this.gridAreaName.HeaderText = "Name";
            this.gridAreaName.Name = "gridAreaName";
            this.gridAreaName.ReadOnly = true;
            this.gridAreaName.Width = 400;
            // 
            // gridAreaBenchMark
            // 
            this.gridAreaBenchMark.HeaderText = "BenchMark";
            this.gridAreaBenchMark.Name = "gridAreaBenchMark";
            this.gridAreaBenchMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAreaBenchMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridAreaBenchMark.Width = 150;
            // 
            // gridAreaEnable
            // 
            this.gridAreaEnable.HeaderText = "Enable";
            this.gridAreaEnable.Name = "gridAreaEnable";
            this.gridAreaEnable.ReadOnly = true;
            this.gridAreaEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridAreaNgNum
            // 
            this.gridAreaNgNum.HeaderText = "Ng Area";
            this.gridAreaNgNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.gridAreaNgNum.Name = "gridAreaNgNum";
            this.gridAreaNgNum.Width = 85;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(944, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Algorithm Area";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAlgorithmIndexMoveDown);
            this.panel3.Controls.Add(this.btnAlgorithmIndexMoveUp);
            this.panel3.Controls.Add(this.btnInspectionAlgoCopy);
            this.panel3.Controls.Add(this.btnInspectionAlgoSet);
            this.panel3.Controls.Add(this.gridViewAlgo);
            this.panel3.Controls.Add(this.btnInspectionAlgoDel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnInspectionAlgoAdd);
            this.panel3.Location = new System.Drawing.Point(0, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(952, 406);
            this.panel3.TabIndex = 2;
            // 
            // btnAlgorithmIndexMoveDown
            // 
            this.btnAlgorithmIndexMoveDown.Location = new System.Drawing.Point(830, 175);
            this.btnAlgorithmIndexMoveDown.Name = "btnAlgorithmIndexMoveDown";
            this.btnAlgorithmIndexMoveDown.Size = new System.Drawing.Size(30, 30);
            this.btnAlgorithmIndexMoveDown.TabIndex = 11;
            this.btnAlgorithmIndexMoveDown.Text = "▼";
            this.btnAlgorithmIndexMoveDown.UseVisualStyleBackColor = true;
            // 
            // btnAlgorithmIndexMoveUp
            // 
            this.btnAlgorithmIndexMoveUp.Location = new System.Drawing.Point(794, 175);
            this.btnAlgorithmIndexMoveUp.Name = "btnAlgorithmIndexMoveUp";
            this.btnAlgorithmIndexMoveUp.Size = new System.Drawing.Size(30, 30);
            this.btnAlgorithmIndexMoveUp.TabIndex = 10;
            this.btnAlgorithmIndexMoveUp.Text = "▲";
            this.btnAlgorithmIndexMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnInspectionAlgoCopy
            // 
            this.btnInspectionAlgoCopy.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAlgoCopy.Location = new System.Drawing.Point(794, 103);
            this.btnInspectionAlgoCopy.Name = "btnInspectionAlgoCopy";
            this.btnInspectionAlgoCopy.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAlgoCopy.TabIndex = 9;
            this.btnInspectionAlgoCopy.Text = "Algorithm Copy";
            this.btnInspectionAlgoCopy.UseVisualStyleBackColor = true;
            this.btnInspectionAlgoCopy.Click += new System.EventHandler(this.btnInspectionAlgoCopy_Click);
            // 
            // btnInspectionAlgoSet
            // 
            this.btnInspectionAlgoSet.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAlgoSet.Location = new System.Drawing.Point(794, 139);
            this.btnInspectionAlgoSet.Name = "btnInspectionAlgoSet";
            this.btnInspectionAlgoSet.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAlgoSet.TabIndex = 8;
            this.btnInspectionAlgoSet.Text = "Algorithm Set";
            this.btnInspectionAlgoSet.UseVisualStyleBackColor = true;
            this.btnInspectionAlgoSet.Click += new System.EventHandler(this.btnInspectionAlgoSet_Click);
            // 
            // gridViewAlgo
            // 
            this.gridViewAlgo.AllowUserToAddRows = false;
            this.gridViewAlgo.AllowUserToDeleteRows = false;
            this.gridViewAlgo.AllowUserToResizeColumns = false;
            this.gridViewAlgo.AllowUserToResizeRows = false;
            this.gridViewAlgo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("나눔바른고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewAlgo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridViewAlgo.ColumnHeadersHeight = 22;
            this.gridViewAlgo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridViewAlgo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridAlgoID,
            this.gridAlgoName,
            this.gridAlgoBenchMark,
            this.gridAlgoEnable});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("나눔바른고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewAlgo.DefaultCellStyle = dataGridViewCellStyle7;
            this.gridViewAlgo.EnableHeadersVisualStyles = false;
            this.gridViewAlgo.Location = new System.Drawing.Point(2, 31);
            this.gridViewAlgo.MultiSelect = false;
            this.gridViewAlgo.Name = "gridViewAlgo";
            this.gridViewAlgo.RowHeadersVisible = false;
            this.gridViewAlgo.RowTemplate.Height = 23;
            this.gridViewAlgo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewAlgo.Size = new System.Drawing.Size(785, 313);
            this.gridViewAlgo.TabIndex = 3;
            this.gridViewAlgo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewAlgo_CellClick);
            this.gridViewAlgo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewAlgo_CellContentClick);
            this.gridViewAlgo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridViewAlgo_CellMouseDoubleClick);
            this.gridViewAlgo.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridViewAlgo_CellMouseDown);
            // 
            // gridAlgoID
            // 
            this.gridAlgoID.HeaderText = "ID";
            this.gridAlgoID.Name = "gridAlgoID";
            this.gridAlgoID.Width = 40;
            // 
            // gridAlgoName
            // 
            this.gridAlgoName.HeaderText = "Name";
            this.gridAlgoName.Name = "gridAlgoName";
            this.gridAlgoName.ReadOnly = true;
            this.gridAlgoName.Width = 400;
            // 
            // gridAlgoBenchMark
            // 
            this.gridAlgoBenchMark.HeaderText = "BenchMark";
            this.gridAlgoBenchMark.Name = "gridAlgoBenchMark";
            this.gridAlgoBenchMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAlgoBenchMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridAlgoBenchMark.Width = 150;
            // 
            // gridAlgoEnable
            // 
            this.gridAlgoEnable.HeaderText = "Enable";
            this.gridAlgoEnable.Name = "gridAlgoEnable";
            this.gridAlgoEnable.ReadOnly = true;
            // 
            // btnInspectionAlgoDel
            // 
            this.btnInspectionAlgoDel.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAlgoDel.Location = new System.Drawing.Point(794, 67);
            this.btnInspectionAlgoDel.Name = "btnInspectionAlgoDel";
            this.btnInspectionAlgoDel.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAlgoDel.TabIndex = 2;
            this.btnInspectionAlgoDel.Text = "Algorithm -";
            this.btnInspectionAlgoDel.UseVisualStyleBackColor = true;
            this.btnInspectionAlgoDel.Click += new System.EventHandler(this.btnInspectionAlgoDel_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Algorithm Area";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInspectionAlgoAdd
            // 
            this.btnInspectionAlgoAdd.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspectionAlgoAdd.Location = new System.Drawing.Point(794, 31);
            this.btnInspectionAlgoAdd.Name = "btnInspectionAlgoAdd";
            this.btnInspectionAlgoAdd.Size = new System.Drawing.Size(144, 30);
            this.btnInspectionAlgoAdd.TabIndex = 2;
            this.btnInspectionAlgoAdd.Text = "Algorithm +";
            this.btnInspectionAlgoAdd.UseVisualStyleBackColor = true;
            this.btnInspectionAlgoAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnInspectionAlgoAdd_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Location = new System.Drawing.Point(947, 867);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 46);
            this.panel1.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(474, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 35);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.White;
            this.labelStatus.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelStatus.ForeColor = System.Drawing.Color.Black;
            this.labelStatus.Location = new System.Drawing.Point(7, 5);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(461, 35);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "Status";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpTeachDisplay
            // 
            this.kpTeachDisplay.BackColor = System.Drawing.Color.White;
            this.kpTeachDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kpTeachDisplay.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.kpTeachDisplay.Location = new System.Drawing.Point(1, 31);
            this.kpTeachDisplay.Name = "kpTeachDisplay";
            this.kpTeachDisplay.Size = new System.Drawing.Size(940, 882);
            this.kpTeachDisplay.TabIndex = 9;
            this.kpTeachDisplay.UseStatusBar = true;
            // 
            // panelTeaching
            // 
            this.panelTeaching.BackColor = System.Drawing.Color.LightGray;
            this.panelTeaching.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTeaching.Controls.Add(this.gradientLabelTeaching);
            this.panelTeaching.Location = new System.Drawing.Point(947, 443);
            this.panelTeaching.Name = "panelTeaching";
            this.panelTeaching.Size = new System.Drawing.Size(953, 420);
            this.panelTeaching.TabIndex = 15;
            // 
            // gradientLabelTeaching
            // 
            this.gradientLabelTeaching.BackColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.ColorBottom = System.Drawing.Color.White;
            this.gradientLabelTeaching.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabelTeaching.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabelTeaching.ForeColor = System.Drawing.Color.White;
            this.gradientLabelTeaching.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabelTeaching.Location = new System.Drawing.Point(2, 0);
            this.gradientLabelTeaching.Name = "gradientLabelTeaching";
            this.gradientLabelTeaching.Size = new System.Drawing.Size(950, 30);
            this.gradientLabelTeaching.TabIndex = 19;
            this.gradientLabelTeaching.Text = " Teaching Window";
            this.gradientLabelTeaching.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.BackColor = System.Drawing.Color.White;
            this.gradientLabel1.ColorBottom = System.Drawing.Color.White;
            this.gradientLabel1.ColorTop = System.Drawing.Color.SteelBlue;
            this.gradientLabel1.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gradientLabel1.ForeColor = System.Drawing.Color.White;
            this.gradientLabel1.GradientDirection = CustomControl.GradientLabel.Direction.Vertical;
            this.gradientLabel1.Location = new System.Drawing.Point(947, 32);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(950, 30);
            this.gradientLabel1.TabIndex = 18;
            this.gradientLabel1.Text = " Inspection & Algorithm Area Setting Window";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TeachingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(1900, 918);
            this.ControlBox = false;
            this.Controls.Add(this.gradientLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlTeach);
            this.Controls.Add(this.panelTeaching);
            this.Controls.Add(this.kpTeachDisplay);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 149);
            this.Name = "TeachingWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TeachingWindow";
            this.tabControlTeach.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewArea)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAlgo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelTeaching.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private KPDisplay.KPCogDisplayControl kpTeachDisplay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private CustomControl.PanelDoubleBuffer panelTeaching;
        private System.Windows.Forms.TabControl tabControlTeach;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInspectionAreaCopy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInspectionAreaSet;
        private System.Windows.Forms.Button btnInspectionAreaDel;
        private System.Windows.Forms.Button btnInspectionAreaAdd;
        private System.Windows.Forms.DataGridView gridViewArea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAlgorithmIndexMoveDown;
        private System.Windows.Forms.Button btnAlgorithmIndexMoveUp;
        private System.Windows.Forms.Button btnInspectionAlgoCopy;
        private System.Windows.Forms.Button btnInspectionAlgoSet;
        private System.Windows.Forms.DataGridView gridViewAlgo;
        private System.Windows.Forms.Button btnInspectionAlgoDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInspectionAlgoAdd;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAlgoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAlgoName;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridAlgoBenchMark;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridAlgoEnable;
        private System.Windows.Forms.Button btnSave;
        private CustomControl.GradientLabel gradientLabel1;
        private CustomControl.GradientLabel gradientLabelTeaching;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAreaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAreaName;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridAreaBenchMark;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridAreaEnable;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridAreaNgNum;
    }
}