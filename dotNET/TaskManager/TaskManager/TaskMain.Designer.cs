namespace TaskManager
{
    partial class TaskMain
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
            this.mainListView = new System.Windows.Forms.ListView();
            this.ProcessId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumberInstances = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.servicesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.input_pid = new System.Windows.Forms.TextBox();
            this.input_pname = new System.Windows.Forms.TextBox();
            this.input_pmid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_memory = new System.Windows.Forms.Label();
            this.ProcessPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // mainListView
            // 
            this.mainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProcessId,
            this.ProcessName,
            this.NumberInstances,
            this.ProcessStatus,
            this.ProcessUsername,
            this.ProcessDescription,
            this.ProcessPath});
            this.mainListView.Location = new System.Drawing.Point(0, 0);
            this.mainListView.Name = "mainListView";
            this.mainListView.Size = new System.Drawing.Size(1200, 500);
            this.mainListView.TabIndex = 0;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.View = System.Windows.Forms.View.Details;
            this.mainListView.SelectedIndexChanged += new System.EventHandler(this.mainListView_SelectedIndexChanged);
            // 
            // ProcessId
            // 
            this.ProcessId.Text = "ID";
            this.ProcessId.Width = 40;
            // 
            // ProcessName
            // 
            this.ProcessName.Text = "Nombre del proceso";
            this.ProcessName.Width = 150;
            // 
            // NumberInstances
            // 
            this.NumberInstances.Text = "Instancias";
            this.NumberInstances.Width = 100;
            // 
            // ProcessStatus
            // 
            this.ProcessStatus.Text = "Estado";
            this.ProcessStatus.Width = 120;
            // 
            // ProcessUsername
            // 
            this.ProcessUsername.Text = "Usuario";
            this.ProcessUsername.Width = 100;
            // 
            // ProcessDescription
            // 
            this.ProcessDescription.Text = "Descripcion";
            this.ProcessDescription.Width = 100;
            // 
            // servicesListView
            // 
            this.servicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.servicesListView.Location = new System.Drawing.Point(0, 506);
            this.servicesListView.Name = "servicesListView";
            this.servicesListView.Size = new System.Drawing.Size(1200, 500);
            this.servicesListView.TabIndex = 1;
            this.servicesListView.UseCompatibleStateImageBehavior = false;
            this.servicesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre del servicio";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre completo del servicio";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tipo de inicio";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Estado";
            // 
            // input_pid
            // 
            this.input_pid.Location = new System.Drawing.Point(1226, 47);
            this.input_pid.Name = "input_pid";
            this.input_pid.Size = new System.Drawing.Size(136, 20);
            this.input_pid.TabIndex = 2;
            // 
            // input_pname
            // 
            this.input_pname.Location = new System.Drawing.Point(1226, 106);
            this.input_pname.Name = "input_pname";
            this.input_pname.Size = new System.Drawing.Size(136, 20);
            this.input_pname.TabIndex = 3;
            // 
            // input_pmid
            // 
            this.input_pmid.Location = new System.Drawing.Point(1226, 165);
            this.input_pmid.Name = "input_pmid";
            this.input_pmid.Size = new System.Drawing.Size(136, 20);
            this.input_pmid.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1226, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Matar proceso por ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1226, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lanzar proceso por nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1223, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Consumo de memoria del proceso por ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1363, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Matar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1363, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Lanzar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1363, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Memoria";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_memory
            // 
            this.txt_memory.AutoSize = true;
            this.txt_memory.Location = new System.Drawing.Point(1226, 200);
            this.txt_memory.Name = "txt_memory";
            this.txt_memory.Size = new System.Drawing.Size(0, 13);
            this.txt_memory.TabIndex = 11;
            // 
            // ProcessPath
            // 
            this.ProcessPath.Text = "Ruta";
            this.ProcessPath.Width = 600;
            // 
            // TaskMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 831);
            this.Controls.Add(this.txt_memory);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_pmid);
            this.Controls.Add(this.input_pname);
            this.Controls.Add(this.input_pid);
            this.Controls.Add(this.servicesListView);
            this.Controls.Add(this.mainListView);
            this.Name = "TaskMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.ColumnHeader ProcessId;
        private System.Windows.Forms.ColumnHeader ProcessName;
        private System.Windows.Forms.ColumnHeader NumberInstances;
        private System.Windows.Forms.ColumnHeader ProcessStatus;
        private System.Windows.Forms.ColumnHeader ProcessUsername;
        private System.Windows.Forms.ColumnHeader ProcessDescription;
        private System.Windows.Forms.ListView servicesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox input_pid;
        private System.Windows.Forms.TextBox input_pname;
        private System.Windows.Forms.TextBox input_pmid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label txt_memory;
        private System.Windows.Forms.ColumnHeader ProcessPath;
    }
}

