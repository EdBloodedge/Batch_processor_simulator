namespace Practica1
{
    partial class input_window
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtOpInput = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelProcesosInput = new System.Windows.Forms.Label();
            this.textBoxTimeMax = new System.Windows.Forms.TextBox();
            this.txtNameinput = new System.Windows.Forms.Label();
            this.textBoxOp = new System.Windows.Forms.TextBox();
            this.txtTimeMaxinput = new System.Windows.Forms.Label();
            this.textBoxProgrammerName = new System.Windows.Forms.TextBox();
            this.txtIdInput = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewPastProcesses = new System.Windows.Forms.ListView();
            this.groupBoxInProgress = new System.Windows.Forms.GroupBox();
            this._contLotesOutput = new System.Windows.Forms.Label();
            this._contLoteslbl = new System.Windows.Forms.Label();
            this.labelProgrammerName = new System.Windows.Forms.Label();
            this.labelOperation = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.processTimertxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timeTxt = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxInProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 450);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtOpInput);
            this.tabPage1.Controls.Add(this.textBoxId);
            this.tabPage1.Controls.Add(this.labelProcesosInput);
            this.tabPage1.Controls.Add(this.textBoxTimeMax);
            this.tabPage1.Controls.Add(this.txtNameinput);
            this.tabPage1.Controls.Add(this.textBoxOp);
            this.tabPage1.Controls.Add(this.txtTimeMaxinput);
            this.tabPage1.Controls.Add(this.textBoxProgrammerName);
            this.tabPage1.Controls.Add(this.txtIdInput);
            this.tabPage1.Controls.Add(this.AddBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingresa datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtOpInput
            // 
            this.txtOpInput.AutoSize = true;
            this.txtOpInput.Location = new System.Drawing.Point(21, 81);
            this.txtOpInput.Margin = new System.Windows.Forms.Padding(150);
            this.txtOpInput.Name = "txtOpInput";
            this.txtOpInput.Size = new System.Drawing.Size(131, 16);
            this.txtOpInput.TabIndex = 4;
            this.txtOpInput.Text = "Operacion a realizar:";
            // 
            // textBoxId
            // 
            this.textBoxId.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxId.Location = new System.Drawing.Point(198, 128);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(438, 22);
            this.textBoxId.TabIndex = 12;
            // 
            // labelProcesosInput
            // 
            this.labelProcesosInput.AutoSize = true;
            this.labelProcesosInput.Location = new System.Drawing.Point(139, 19);
            this.labelProcesosInput.Name = "labelProcesosInput";
            this.labelProcesosInput.Size = new System.Drawing.Size(68, 16);
            this.labelProcesosInput.TabIndex = 2;
            this.labelProcesosInput.Text = "Proceso 1";
            // 
            // textBoxTimeMax
            // 
            this.textBoxTimeMax.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxTimeMax.Location = new System.Drawing.Point(198, 103);
            this.textBoxTimeMax.Name = "textBoxTimeMax";
            this.textBoxTimeMax.Size = new System.Drawing.Size(438, 22);
            this.textBoxTimeMax.TabIndex = 11;
            // 
            // txtNameinput
            // 
            this.txtNameinput.AutoSize = true;
            this.txtNameinput.Location = new System.Drawing.Point(21, 56);
            this.txtNameinput.Margin = new System.Windows.Forms.Padding(150);
            this.txtNameinput.Name = "txtNameinput";
            this.txtNameinput.Size = new System.Drawing.Size(141, 16);
            this.txtNameinput.TabIndex = 3;
            this.txtNameinput.Text = "Nombre programador:";
            // 
            // textBoxOp
            // 
            this.textBoxOp.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxOp.Location = new System.Drawing.Point(198, 78);
            this.textBoxOp.Name = "textBoxOp";
            this.textBoxOp.Size = new System.Drawing.Size(438, 22);
            this.textBoxOp.TabIndex = 10;
            // 
            // txtTimeMaxinput
            // 
            this.txtTimeMaxinput.AutoSize = true;
            this.txtTimeMaxinput.Location = new System.Drawing.Point(21, 106);
            this.txtTimeMaxinput.Margin = new System.Windows.Forms.Padding(150);
            this.txtTimeMaxinput.Name = "txtTimeMaxinput";
            this.txtTimeMaxinput.Size = new System.Drawing.Size(166, 16);
            this.txtTimeMaxinput.TabIndex = 5;
            this.txtTimeMaxinput.Text = "Tiempo Maximo estimado:";
            // 
            // textBoxProgrammerName
            // 
            this.textBoxProgrammerName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxProgrammerName.Location = new System.Drawing.Point(198, 53);
            this.textBoxProgrammerName.Name = "textBoxProgrammerName";
            this.textBoxProgrammerName.Size = new System.Drawing.Size(438, 22);
            this.textBoxProgrammerName.TabIndex = 9;
            // 
            // txtIdInput
            // 
            this.txtIdInput.AutoSize = true;
            this.txtIdInput.Location = new System.Drawing.Point(21, 131);
            this.txtIdInput.Margin = new System.Windows.Forms.Padding(150);
            this.txtIdInput.Name = "txtIdInput";
            this.txtIdInput.Size = new System.Drawing.Size(139, 16);
            this.txtIdInput.TabIndex = 6;
            this.txtIdInput.Text = "Numero de programa:";
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AddBtn.Location = new System.Drawing.Point(223, 16);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 7;
            this.AddBtn.Text = "Add+";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.addBtn);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewPastProcesses);
            this.tabPage2.Controls.Add(this.groupBoxInProgress);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnStart);
            this.tabPage2.Controls.Add(this.timeTxt);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procesos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listViewPastProcesses
            // 
            this.listViewPastProcesses.HideSelection = false;
            this.listViewPastProcesses.Location = new System.Drawing.Point(489, 6);
            this.listViewPastProcesses.Name = "listViewPastProcesses";
            this.listViewPastProcesses.Size = new System.Drawing.Size(283, 368);
            this.listViewPastProcesses.TabIndex = 11;
            this.listViewPastProcesses.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxInProgress
            // 
            this.groupBoxInProgress.Controls.Add(this._contLotesOutput);
            this.groupBoxInProgress.Controls.Add(this._contLoteslbl);
            this.groupBoxInProgress.Controls.Add(this.labelProgrammerName);
            this.groupBoxInProgress.Controls.Add(this.labelOperation);
            this.groupBoxInProgress.Controls.Add(this.labelId);
            this.groupBoxInProgress.Controls.Add(this.label5);
            this.groupBoxInProgress.Controls.Add(this.label4);
            this.groupBoxInProgress.Controls.Add(this.label2);
            this.groupBoxInProgress.Controls.Add(this.label3);
            this.groupBoxInProgress.Controls.Add(this.processTimertxt);
            this.groupBoxInProgress.Location = new System.Drawing.Point(8, 193);
            this.groupBoxInProgress.Name = "groupBoxInProgress";
            this.groupBoxInProgress.Size = new System.Drawing.Size(365, 181);
            this.groupBoxInProgress.TabIndex = 10;
            this.groupBoxInProgress.TabStop = false;
            this.groupBoxInProgress.Text = "Proceso en ejecución";
            // 
            // _contLotesOutput
            // 
            this._contLotesOutput.AutoSize = true;
            this._contLotesOutput.Location = new System.Drawing.Point(160, 142);
            this._contLotesOutput.Name = "_contLotesOutput";
            this._contLotesOutput.Size = new System.Drawing.Size(14, 16);
            this._contLotesOutput.TabIndex = 15;
            this._contLotesOutput.Text = "0";
            // 
            // _contLoteslbl
            // 
            this._contLoteslbl.AutoSize = true;
            this._contLoteslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._contLoteslbl.Location = new System.Drawing.Point(17, 143);
            this._contLoteslbl.Name = "_contLoteslbl";
            this._contLoteslbl.Size = new System.Drawing.Size(117, 16);
            this._contLoteslbl.TabIndex = 14;
            this._contLoteslbl.Text = "Lotes restantes:";
            // 
            // labelProgrammerName
            // 
            this.labelProgrammerName.AutoSize = true;
            this.labelProgrammerName.Location = new System.Drawing.Point(147, 117);
            this.labelProgrammerName.Name = "labelProgrammerName";
            this.labelProgrammerName.Size = new System.Drawing.Size(0, 16);
            this.labelProgrammerName.TabIndex = 13;
            // 
            // labelOperation
            // 
            this.labelOperation.AutoSize = true;
            this.labelOperation.Location = new System.Drawing.Point(147, 86);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Size = new System.Drawing.Size(0, 16);
            this.labelOperation.TabIndex = 12;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(147, 57);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(0, 16);
            this.labelId.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Programador:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Operacion: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tiempo restante:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID Programa:";
            // 
            // processTimertxt
            // 
            this.processTimertxt.AutoSize = true;
            this.processTimertxt.Location = new System.Drawing.Point(157, 28);
            this.processTimertxt.Name = "processTimertxt";
            this.processTimertxt.Size = new System.Drawing.Size(55, 16);
            this.processTimertxt.TabIndex = 6;
            this.processTimertxt.Text = "00:00:00";
            this.processTimertxt.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tiempo Total:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(248, 380);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Empezar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.startBtn);
            // 
            // timeTxt
            // 
            this.timeTxt.AutoSize = true;
            this.timeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTxt.Location = new System.Drawing.Point(125, 377);
            this.timeTxt.Name = "timeTxt";
            this.timeTxt.Size = new System.Drawing.Size(80, 22);
            this.timeTxt.TabIndex = 4;
            this.timeTxt.Text = "00:00:00";
            this.timeTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.timeTxt.Click += new System.EventHandler(this.label6_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.DimGray;
            this.groupBox4.Location = new System.Drawing.Point(182, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(23, 169);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DimGray;
            this.groupBox3.Location = new System.Drawing.Point(132, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(23, 169);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(80, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(23, 169);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(28, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(23, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // input_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "input_window";
            this.Text = "Practica1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.input_window_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxInProgress.ResumeLayout(false);
            this.groupBoxInProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label txtOpInput;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelProcesosInput;
        private System.Windows.Forms.TextBox textBoxTimeMax;
        private System.Windows.Forms.Label txtNameinput;
        private System.Windows.Forms.TextBox textBoxOp;
        private System.Windows.Forms.Label txtTimeMaxinput;
        private System.Windows.Forms.TextBox textBoxProgrammerName;
        private System.Windows.Forms.Label txtIdInput;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;

        private System.Windows.Forms.Label timeTxt;
        private System.Windows.Forms.Label processTimertxt;
        private System.Windows.Forms.GroupBox groupBoxInProgress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProgrammerName;
        private System.Windows.Forms.Label labelOperation;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.ListView listViewPastProcesses;
        private System.Windows.Forms.Label _contLoteslbl;
        private System.Windows.Forms.Label _contLotesOutput;
    }
}

