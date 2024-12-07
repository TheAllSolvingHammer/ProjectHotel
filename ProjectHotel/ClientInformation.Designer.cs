namespace ProjectHotel
{
    partial class ClientInformation
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            clientToolStripMenuItem = new ToolStripMenuItem();
            roomToolStripMenuItem = new ToolStripMenuItem();
            reservationToolStripMenuItem = new ToolStripMenuItem();
            queryToolStripMenuItem = new ToolStripMenuItem();
            availableRoomsToolStripMenuItem = new ToolStripMenuItem();
            turnoverToolStripMenuItem = new ToolStripMenuItem();
            clientInformationToolStripMenuItem = new ToolStripMenuItem();
            graphicalExampleToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(51, 87);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(113, 36);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(218, 87);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(458, 195);
            dataGridView1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 18;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem, queryToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientToolStripMenuItem, roomToolStripMenuItem, reservationToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(180, 22);
            addToolStripMenuItem.Text = "Add";
            // 
            // clientToolStripMenuItem
            // 
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(180, 22);
            clientToolStripMenuItem.Text = "Client";
            clientToolStripMenuItem.Click += clientToolStripMenuItem_Click;
            // 
            // roomToolStripMenuItem
            // 
            roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            roomToolStripMenuItem.Size = new Size(180, 22);
            roomToolStripMenuItem.Text = "Room";
            roomToolStripMenuItem.Click += roomToolStripMenuItem_Click;
            // 
            // reservationToolStripMenuItem
            // 
            reservationToolStripMenuItem.Name = "reservationToolStripMenuItem";
            reservationToolStripMenuItem.Size = new Size(180, 22);
            reservationToolStripMenuItem.Text = "Reservation";
            reservationToolStripMenuItem.Click += reservationToolStripMenuItem_Click;
            // 
            // queryToolStripMenuItem
            // 
            queryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { availableRoomsToolStripMenuItem, turnoverToolStripMenuItem, clientInformationToolStripMenuItem, graphicalExampleToolStripMenuItem });
            queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            queryToolStripMenuItem.Size = new Size(180, 22);
            queryToolStripMenuItem.Text = "Query";
            // 
            // availableRoomsToolStripMenuItem
            // 
            availableRoomsToolStripMenuItem.Name = "availableRoomsToolStripMenuItem";
            availableRoomsToolStripMenuItem.Size = new Size(180, 22);
            availableRoomsToolStripMenuItem.Text = "Available rooms";
            availableRoomsToolStripMenuItem.Click += availableRoomsToolStripMenuItem_Click;
            // 
            // turnoverToolStripMenuItem
            // 
            turnoverToolStripMenuItem.Name = "turnoverToolStripMenuItem";
            turnoverToolStripMenuItem.Size = new Size(180, 22);
            turnoverToolStripMenuItem.Text = "Turnover";
            turnoverToolStripMenuItem.Click += turnoverToolStripMenuItem_Click;
            // 
            // clientInformationToolStripMenuItem
            // 
            clientInformationToolStripMenuItem.Name = "clientInformationToolStripMenuItem";
            clientInformationToolStripMenuItem.Size = new Size(172, 22);
            clientInformationToolStripMenuItem.Text = "Client Information";
            // 
            // graphicalExampleToolStripMenuItem
            // 
            graphicalExampleToolStripMenuItem.Name = "graphicalExampleToolStripMenuItem";
            graphicalExampleToolStripMenuItem.Size = new Size(180, 22);
            graphicalExampleToolStripMenuItem.Text = "Graphical Example";
            graphicalExampleToolStripMenuItem.Click += graphicalExampleToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(38, 20);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // ClientInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClientInformation";
            Text = "ClientInformation";
            Load += ClientInformation_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem clientToolStripMenuItem;
        private ToolStripMenuItem roomToolStripMenuItem;
        private ToolStripMenuItem reservationToolStripMenuItem;
        private ToolStripMenuItem queryToolStripMenuItem;
        private ToolStripMenuItem availableRoomsToolStripMenuItem;
        private ToolStripMenuItem turnoverToolStripMenuItem;
        private ToolStripMenuItem clientInformationToolStripMenuItem;
        private ToolStripMenuItem graphicalExampleToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}