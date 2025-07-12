namespace CosmosDBDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            ButtonRefresh = new Button();
            ButtonCreate = new Button();
            ButtonClear = new Button();
            LabelCo2 = new Label();
            TextBoxCo2 = new TextBox();
            LabelHumidity = new Label();
            TextBoxHumidity = new TextBox();
            LabelTemperature = new Label();
            TextBoxTemperature = new TextBox();
            groupBox2 = new GroupBox();
            GridView = new DataGridView();
            DeviceNumber = new DataGridViewTextBoxColumn();
            Temperature = new DataGridViewTextBoxColumn();
            Humidity = new DataGridViewTextBoxColumn();
            Co2 = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ButtonRefresh);
            groupBox1.Controls.Add(ButtonCreate);
            groupBox1.Controls.Add(ButtonClear);
            groupBox1.Controls.Add(LabelCo2);
            groupBox1.Controls.Add(TextBoxCo2);
            groupBox1.Controls.Add(LabelHumidity);
            groupBox1.Controls.Add(TextBoxHumidity);
            groupBox1.Controls.Add(LabelTemperature);
            groupBox1.Controls.Add(TextBoxTemperature);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create record";
            // 
            // ButtonRefresh
            // 
            ButtonRefresh.Location = new Point(6, 397);
            ButtonRefresh.Name = "ButtonRefresh";
            ButtonRefresh.Size = new Size(75, 23);
            ButtonRefresh.TabIndex = 11;
            ButtonRefresh.Text = "Refresh";
            ButtonRefresh.UseVisualStyleBackColor = true;
            ButtonRefresh.Click += ButtonRefresh_Click;
            // 
            // ButtonCreate
            // 
            ButtonCreate.Location = new Point(168, 397);
            ButtonCreate.Name = "ButtonCreate";
            ButtonCreate.Size = new Size(75, 23);
            ButtonCreate.TabIndex = 10;
            ButtonCreate.Text = "Create";
            ButtonCreate.UseVisualStyleBackColor = true;
            ButtonCreate.Click += ButtonCreate_Click;
            // 
            // ButtonClear
            // 
            ButtonClear.Location = new Point(87, 397);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(75, 23);
            ButtonClear.TabIndex = 8;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            ButtonClear.Click += ButtonClear_Click;
            // 
            // LabelCo2
            // 
            LabelCo2.AutoSize = true;
            LabelCo2.Location = new Point(6, 107);
            LabelCo2.Name = "LabelCo2";
            LabelCo2.Size = new Size(28, 15);
            LabelCo2.TabIndex = 7;
            LabelCo2.Text = "Co2";
            // 
            // TextBoxCo2
            // 
            TextBoxCo2.Location = new Point(6, 125);
            TextBoxCo2.Name = "TextBoxCo2";
            TextBoxCo2.Size = new Size(237, 23);
            TextBoxCo2.TabIndex = 6;
            // 
            // LabelHumidity
            // 
            LabelHumidity.AutoSize = true;
            LabelHumidity.Location = new Point(6, 63);
            LabelHumidity.Name = "LabelHumidity";
            LabelHumidity.Size = new Size(57, 15);
            LabelHumidity.TabIndex = 5;
            LabelHumidity.Text = "Humidity";
            // 
            // TextBoxHumidity
            // 
            TextBoxHumidity.Location = new Point(6, 81);
            TextBoxHumidity.Name = "TextBoxHumidity";
            TextBoxHumidity.Size = new Size(237, 23);
            TextBoxHumidity.TabIndex = 4;
            // 
            // LabelTemperature
            // 
            LabelTemperature.AutoSize = true;
            LabelTemperature.Location = new Point(6, 19);
            LabelTemperature.Name = "LabelTemperature";
            LabelTemperature.Size = new Size(73, 15);
            LabelTemperature.TabIndex = 3;
            LabelTemperature.Text = "Temperature";
            // 
            // TextBoxTemperature
            // 
            TextBoxTemperature.Location = new Point(6, 37);
            TextBoxTemperature.Name = "TextBoxTemperature";
            TextBoxTemperature.Size = new Size(237, 23);
            TextBoxTemperature.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(GridView);
            groupBox2.Location = new Point(268, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(520, 426);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "View records";
            // 
            // GridView
            // 
            GridView.AllowUserToAddRows = false;
            GridView.AllowUserToDeleteRows = false;
            GridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridView.Columns.AddRange(new DataGridViewColumn[] { DeviceNumber, Temperature, Humidity, Co2 });
            GridView.Location = new Point(6, 22);
            GridView.Name = "GridView";
            GridView.ReadOnly = true;
            GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridView.Size = new Size(508, 398);
            GridView.TabIndex = 0;
            // 
            // DeviceNumber
            // 
            DeviceNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DeviceNumber.HeaderText = "Device Number";
            DeviceNumber.Name = "DeviceNumber";
            DeviceNumber.ReadOnly = true;
            // 
            // Temperature
            // 
            Temperature.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Temperature.HeaderText = "Temperature";
            Temperature.Name = "Temperature";
            Temperature.ReadOnly = true;
            // 
            // Humidity
            // 
            Humidity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Humidity.HeaderText = "Humidity";
            Humidity.Name = "Humidity";
            Humidity.ReadOnly = true;
            // 
            // Co2
            // 
            Co2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Co2.HeaderText = "Co2";
            Co2.Name = "Co2";
            Co2.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox TextBoxTemperature;
        private Button ButtonCreate;
        private Button ButtonClear;
        private Label LabelCo2;
        private TextBox TextBoxCo2;
        private Label LabelHumidity;
        private TextBox TextBoxHumidity;
        private Label LabelTemperature;
        private DataGridView GridView;
        private Button ButtonRefresh;
        private DataGridViewTextBoxColumn DeviceNumber;
        private DataGridViewTextBoxColumn Temperature;
        private DataGridViewTextBoxColumn Humidity;
        private DataGridViewTextBoxColumn Co2;
    }
}
