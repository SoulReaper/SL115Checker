namespace SL115Checker
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbBranch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelToday = new System.Windows.Forms.Label();
            this.comboBranch = new System.Windows.Forms.ComboBox();
            this.comboInspector = new System.Windows.Forms.ComboBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxFiles = new System.Windows.Forms.GroupBox();
            this.lblBookCopied = new System.Windows.Forms.Label();
            this.lblOmegaCopied = new System.Windows.Forms.Label();
            this.lblBSRCopied = new System.Windows.Forms.Label();
            this.lblFinCopied = new System.Windows.Forms.Label();
            this.lblAssetCopied = new System.Windows.Forms.Label();
            this.lblOmegaExist = new System.Windows.Forms.Label();
            this.lblBSRExist = new System.Windows.Forms.Label();
            this.lblFinExist = new System.Windows.Forms.Label();
            this.lblBookExist = new System.Windows.Forms.Label();
            this.lblAssetExist = new System.Windows.Forms.Label();
            this.lblBookDif = new System.Windows.Forms.Label();
            this.lblFinDif = new System.Windows.Forms.Label();
            this.lblOmegaDif = new System.Windows.Forms.Label();
            this.lblAssetDif = new System.Windows.Forms.Label();
            this.lblOmegaDate = new System.Windows.Forms.Label();
            this.lblFinDate = new System.Windows.Forms.Label();
            this.lblBookDate = new System.Windows.Forms.Label();
            this.lblAssetDate = new System.Windows.Forms.Label();
            this.labelOmega = new System.Windows.Forms.Label();
            this.labelBSR = new System.Windows.Forms.Label();
            this.labelFin = new System.Windows.Forms.Label();
            this.labelBook = new System.Windows.Forms.Label();
            this.labelAsset = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelBSRPrevious = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.checkBoxBSR = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.labelCurrentBSR = new System.Windows.Forms.Label();
            this.btnNavigateTarget = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter branch code";
            // 
            // tbBranch
            // 
            this.tbBranch.Location = new System.Drawing.Point(16, 30);
            this.tbBranch.Name = "tbBranch";
            this.tbBranch.Size = new System.Drawing.Size(100, 20);
            this.tbBranch.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Today\'s date";
            // 
            // labelToday
            // 
            this.labelToday.AutoSize = true;
            this.labelToday.Location = new System.Drawing.Point(542, 86);
            this.labelToday.Name = "labelToday";
            this.labelToday.Size = new System.Drawing.Size(30, 13);
            this.labelToday.TabIndex = 4;
            this.labelToday.Text = "Date";
            // 
            // comboBranch
            // 
            this.comboBranch.CausesValidation = false;
            this.comboBranch.FormattingEnabled = true;
            this.comboBranch.Location = new System.Drawing.Point(135, 30);
            this.comboBranch.Name = "comboBranch";
            this.comboBranch.Size = new System.Drawing.Size(121, 21);
            this.comboBranch.TabIndex = 1;
            this.comboBranch.Text = "Select a branch type";
            this.comboBranch.SelectedIndexChanged += new System.EventHandler(this.comboBranch_SelectedIndexChanged);
            // 
            // comboInspector
            // 
            this.comboInspector.FormattingEnabled = true;
            this.comboInspector.Location = new System.Drawing.Point(274, 30);
            this.comboInspector.Name = "comboInspector";
            this.comboInspector.Size = new System.Drawing.Size(148, 21);
            this.comboInspector.TabIndex = 2;
            this.comboInspector.Text = "Select a control inspector";
            this.comboInspector.SelectedIndexChanged += new System.EventHandler(this.comboInspector_SelectedIndexChanged);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(16, 317);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(604, 187);
            this.textBoxStatus.TabIndex = 8;
            this.textBoxStatus.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select a branch type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Select a control inspector";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "BSR sent previously";
            // 
            // groupBoxFiles
            // 
            this.groupBoxFiles.Controls.Add(this.lblBookCopied);
            this.groupBoxFiles.Controls.Add(this.lblOmegaCopied);
            this.groupBoxFiles.Controls.Add(this.lblBSRCopied);
            this.groupBoxFiles.Controls.Add(this.lblFinCopied);
            this.groupBoxFiles.Controls.Add(this.lblAssetCopied);
            this.groupBoxFiles.Controls.Add(this.lblOmegaExist);
            this.groupBoxFiles.Controls.Add(this.lblBSRExist);
            this.groupBoxFiles.Controls.Add(this.lblFinExist);
            this.groupBoxFiles.Controls.Add(this.lblBookExist);
            this.groupBoxFiles.Controls.Add(this.lblAssetExist);
            this.groupBoxFiles.Controls.Add(this.lblBookDif);
            this.groupBoxFiles.Controls.Add(this.lblFinDif);
            this.groupBoxFiles.Controls.Add(this.lblOmegaDif);
            this.groupBoxFiles.Controls.Add(this.lblAssetDif);
            this.groupBoxFiles.Controls.Add(this.lblOmegaDate);
            this.groupBoxFiles.Controls.Add(this.lblFinDate);
            this.groupBoxFiles.Controls.Add(this.lblBookDate);
            this.groupBoxFiles.Controls.Add(this.lblAssetDate);
            this.groupBoxFiles.Controls.Add(this.labelOmega);
            this.groupBoxFiles.Controls.Add(this.labelBSR);
            this.groupBoxFiles.Controls.Add(this.labelFin);
            this.groupBoxFiles.Controls.Add(this.labelBook);
            this.groupBoxFiles.Controls.Add(this.labelAsset);
            this.groupBoxFiles.Controls.Add(this.label9);
            this.groupBoxFiles.Controls.Add(this.label8);
            this.groupBoxFiles.Controls.Add(this.label7);
            this.groupBoxFiles.Controls.Add(this.label3);
            this.groupBoxFiles.Location = new System.Drawing.Point(16, 67);
            this.groupBoxFiles.Name = "groupBoxFiles";
            this.groupBoxFiles.Size = new System.Drawing.Size(435, 195);
            this.groupBoxFiles.TabIndex = 14;
            this.groupBoxFiles.TabStop = false;
            this.groupBoxFiles.Text = "Files";
            // 
            // lblBookCopied
            // 
            this.lblBookCopied.Location = new System.Drawing.Point(359, 72);
            this.lblBookCopied.Name = "lblBookCopied";
            this.lblBookCopied.Size = new System.Drawing.Size(47, 14);
            this.lblBookCopied.TabIndex = 28;
            this.lblBookCopied.Text = "Yes";
            this.lblBookCopied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOmegaCopied
            // 
            this.lblOmegaCopied.Location = new System.Drawing.Point(359, 156);
            this.lblOmegaCopied.Name = "lblOmegaCopied";
            this.lblOmegaCopied.Size = new System.Drawing.Size(47, 14);
            this.lblOmegaCopied.TabIndex = 27;
            this.lblOmegaCopied.Text = "Yes";
            this.lblOmegaCopied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBSRCopied
            // 
            this.lblBSRCopied.Location = new System.Drawing.Point(359, 128);
            this.lblBSRCopied.Name = "lblBSRCopied";
            this.lblBSRCopied.Size = new System.Drawing.Size(47, 14);
            this.lblBSRCopied.TabIndex = 26;
            this.lblBSRCopied.Text = "Yes";
            this.lblBSRCopied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinCopied
            // 
            this.lblFinCopied.Location = new System.Drawing.Point(359, 100);
            this.lblFinCopied.Name = "lblFinCopied";
            this.lblFinCopied.Size = new System.Drawing.Size(47, 14);
            this.lblFinCopied.TabIndex = 25;
            this.lblFinCopied.Text = "Yes";
            this.lblFinCopied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssetCopied
            // 
            this.lblAssetCopied.Location = new System.Drawing.Point(359, 44);
            this.lblAssetCopied.Name = "lblAssetCopied";
            this.lblAssetCopied.Size = new System.Drawing.Size(47, 14);
            this.lblAssetCopied.TabIndex = 24;
            this.lblAssetCopied.Text = "Yes";
            this.lblAssetCopied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOmegaExist
            // 
            this.lblOmegaExist.Location = new System.Drawing.Point(287, 156);
            this.lblOmegaExist.Name = "lblOmegaExist";
            this.lblOmegaExist.Size = new System.Drawing.Size(47, 14);
            this.lblOmegaExist.TabIndex = 23;
            this.lblOmegaExist.Text = "Yes";
            this.lblOmegaExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBSRExist
            // 
            this.lblBSRExist.Location = new System.Drawing.Point(287, 128);
            this.lblBSRExist.Name = "lblBSRExist";
            this.lblBSRExist.Size = new System.Drawing.Size(47, 14);
            this.lblBSRExist.TabIndex = 22;
            this.lblBSRExist.Text = "Yes";
            this.lblBSRExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinExist
            // 
            this.lblFinExist.Location = new System.Drawing.Point(287, 100);
            this.lblFinExist.Name = "lblFinExist";
            this.lblFinExist.Size = new System.Drawing.Size(47, 14);
            this.lblFinExist.TabIndex = 21;
            this.lblFinExist.Text = "Yes";
            this.lblFinExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBookExist
            // 
            this.lblBookExist.Location = new System.Drawing.Point(287, 72);
            this.lblBookExist.Name = "lblBookExist";
            this.lblBookExist.Size = new System.Drawing.Size(47, 14);
            this.lblBookExist.TabIndex = 20;
            this.lblBookExist.Text = "Yes";
            this.lblBookExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssetExist
            // 
            this.lblAssetExist.Location = new System.Drawing.Point(287, 44);
            this.lblAssetExist.Name = "lblAssetExist";
            this.lblAssetExist.Size = new System.Drawing.Size(47, 14);
            this.lblAssetExist.TabIndex = 19;
            this.lblAssetExist.Text = "Yes";
            this.lblAssetExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBookDif
            // 
            this.lblBookDif.Location = new System.Drawing.Point(207, 72);
            this.lblBookDif.Name = "lblBookDif";
            this.lblBookDif.Size = new System.Drawing.Size(47, 14);
            this.lblBookDif.TabIndex = 18;
            this.lblBookDif.Text = "9999";
            this.lblBookDif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinDif
            // 
            this.lblFinDif.Location = new System.Drawing.Point(207, 100);
            this.lblFinDif.Name = "lblFinDif";
            this.lblFinDif.Size = new System.Drawing.Size(47, 14);
            this.lblFinDif.TabIndex = 17;
            this.lblFinDif.Text = "9999";
            this.lblFinDif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOmegaDif
            // 
            this.lblOmegaDif.Location = new System.Drawing.Point(207, 156);
            this.lblOmegaDif.Name = "lblOmegaDif";
            this.lblOmegaDif.Size = new System.Drawing.Size(47, 14);
            this.lblOmegaDif.TabIndex = 15;
            this.lblOmegaDif.Text = "9999";
            this.lblOmegaDif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssetDif
            // 
            this.lblAssetDif.Location = new System.Drawing.Point(207, 44);
            this.lblAssetDif.Name = "lblAssetDif";
            this.lblAssetDif.Size = new System.Drawing.Size(47, 14);
            this.lblAssetDif.TabIndex = 14;
            this.lblAssetDif.Text = "9999";
            this.lblAssetDif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOmegaDate
            // 
            this.lblOmegaDate.Location = new System.Drawing.Point(99, 156);
            this.lblOmegaDate.Name = "lblOmegaDate";
            this.lblOmegaDate.Size = new System.Drawing.Size(78, 14);
            this.lblOmegaDate.TabIndex = 13;
            this.lblOmegaDate.Text = "2010/09/14";
            this.lblOmegaDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFinDate
            // 
            this.lblFinDate.Location = new System.Drawing.Point(99, 100);
            this.lblFinDate.Name = "lblFinDate";
            this.lblFinDate.Size = new System.Drawing.Size(78, 14);
            this.lblFinDate.TabIndex = 11;
            this.lblFinDate.Text = "2010/09/14";
            this.lblFinDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBookDate
            // 
            this.lblBookDate.Location = new System.Drawing.Point(99, 72);
            this.lblBookDate.Name = "lblBookDate";
            this.lblBookDate.Size = new System.Drawing.Size(78, 14);
            this.lblBookDate.TabIndex = 10;
            this.lblBookDate.Text = "2010/09/14";
            this.lblBookDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAssetDate
            // 
            this.lblAssetDate.Location = new System.Drawing.Point(99, 44);
            this.lblAssetDate.Name = "lblAssetDate";
            this.lblAssetDate.Size = new System.Drawing.Size(78, 14);
            this.lblAssetDate.TabIndex = 9;
            this.lblAssetDate.Text = "2010/09/14";
            this.lblAssetDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOmega
            // 
            this.labelOmega.AutoSize = true;
            this.labelOmega.Location = new System.Drawing.Point(7, 157);
            this.labelOmega.Name = "labelOmega";
            this.labelOmega.Size = new System.Drawing.Size(74, 13);
            this.labelOmega.TabIndex = 8;
            this.labelOmega.Text = "Omega assets";
            // 
            // labelBSR
            // 
            this.labelBSR.AutoSize = true;
            this.labelBSR.Location = new System.Drawing.Point(7, 129);
            this.labelBSR.Name = "labelBSR";
            this.labelBSR.Size = new System.Drawing.Size(29, 13);
            this.labelBSR.TabIndex = 7;
            this.labelBSR.Text = "BSR";
            // 
            // labelFin
            // 
            this.labelFin.AutoSize = true;
            this.labelFin.Location = new System.Drawing.Point(7, 101);
            this.labelFin.Name = "labelFin";
            this.labelFin.Size = new System.Drawing.Size(54, 13);
            this.labelFin.TabIndex = 6;
            this.labelFin.Text = "Financials";
            // 
            // labelBook
            // 
            this.labelBook.AutoSize = true;
            this.labelBook.Location = new System.Drawing.Point(7, 73);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(56, 13);
            this.labelBook.TabIndex = 5;
            this.labelBook.Text = "Life books";
            // 
            // labelAsset
            // 
            this.labelAsset.AutoSize = true;
            this.labelAsset.Location = new System.Drawing.Point(7, 45);
            this.labelAsset.Name = "labelAsset";
            this.labelAsset.Size = new System.Drawing.Size(38, 13);
            this.labelAsset.TabIndex = 4;
            this.labelAsset.Text = "Assets";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(366, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Copied";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Exist";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Days difference";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(16, 277);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check files";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(118, 277);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy files";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(223, 277);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "New search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(323, 277);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelBSRPrevious
            // 
            this.labelBSRPrevious.AutoSize = true;
            this.labelBSRPrevious.Location = new System.Drawing.Point(567, 140);
            this.labelBSRPrevious.Name = "labelBSRPrevious";
            this.labelBSRPrevious.Size = new System.Drawing.Size(53, 13);
            this.labelBSRPrevious.TabIndex = 19;
            this.labelBSRPrevious.Text = "BSR date";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(459, 168);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 13);
            this.label35.TabIndex = 20;
            this.label35.Text = "Copy BSR";
            // 
            // checkBoxBSR
            // 
            this.checkBoxBSR.AutoSize = true;
            this.checkBoxBSR.Location = new System.Drawing.Point(521, 168);
            this.checkBoxBSR.Name = "checkBoxBSR";
            this.checkBoxBSR.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBSR.TabIndex = 3;
            this.checkBoxBSR.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(459, 112);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(66, 13);
            this.label36.TabIndex = 22;
            this.label36.Text = "Current BSR";
            // 
            // labelCurrentBSR
            // 
            this.labelCurrentBSR.AutoSize = true;
            this.labelCurrentBSR.Location = new System.Drawing.Point(542, 112);
            this.labelCurrentBSR.Name = "labelCurrentBSR";
            this.labelCurrentBSR.Size = new System.Drawing.Size(66, 13);
            this.labelCurrentBSR.TabIndex = 23;
            this.labelCurrentBSR.Text = "Current BSR";
            // 
            // btnNavigateTarget
            // 
            this.btnNavigateTarget.Location = new System.Drawing.Point(462, 214);
            this.btnNavigateTarget.Name = "btnNavigateTarget";
            this.btnNavigateTarget.Size = new System.Drawing.Size(146, 23);
            this.btnNavigateTarget.TabIndex = 24;
            this.btnNavigateTarget.Text = "Set a new target path";
            this.btnNavigateTarget.UseVisualStyleBackColor = true;
            this.btnNavigateTarget.Click += new System.EventHandler(this.btnNavigateTarget_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(636, 524);
            this.Controls.Add(this.btnNavigateTarget);
            this.Controls.Add(this.labelCurrentBSR);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.checkBoxBSR);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.labelBSRPrevious);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.groupBoxFiles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.comboInspector);
            this.Controls.Add(this.comboBranch);
            this.Controls.Add(this.labelToday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBranch);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SL115 Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxFiles.ResumeLayout(false);
            this.groupBoxFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelToday;
        private System.Windows.Forms.ComboBox comboBranch;
        private System.Windows.Forms.ComboBox comboInspector;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxFiles;
        private System.Windows.Forms.Label labelFin;
        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Label labelAsset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelOmega;
        private System.Windows.Forms.Label labelBSR;
        private System.Windows.Forms.Label lblAssetDate;
        private System.Windows.Forms.Label lblBookCopied;
        private System.Windows.Forms.Label lblOmegaCopied;
        private System.Windows.Forms.Label lblBSRCopied;
        private System.Windows.Forms.Label lblFinCopied;
        private System.Windows.Forms.Label lblAssetCopied;
        private System.Windows.Forms.Label lblOmegaExist;
        private System.Windows.Forms.Label lblBSRExist;
        private System.Windows.Forms.Label lblFinExist;
        private System.Windows.Forms.Label lblBookExist;
        private System.Windows.Forms.Label lblAssetExist;
        private System.Windows.Forms.Label lblBookDif;
        private System.Windows.Forms.Label lblFinDif;
        private System.Windows.Forms.Label lblOmegaDif;
        private System.Windows.Forms.Label lblAssetDif;
        private System.Windows.Forms.Label lblOmegaDate;
        private System.Windows.Forms.Label lblFinDate;
        private System.Windows.Forms.Label lblBookDate;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelBSRPrevious;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox checkBoxBSR;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label labelCurrentBSR;
        private System.Windows.Forms.Button btnNavigateTarget;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

