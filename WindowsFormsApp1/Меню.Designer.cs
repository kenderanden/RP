namespace WindowsFormsApp1
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenClients = new System.Windows.Forms.Button();
            this.buttonOpenAgents = new System.Windows.Forms.Button();
            this.buttonOpenRealEstates = new System.Windows.Forms.Button();
            this.buttonOpenDemands = new System.Windows.Forms.Button();
            this.buttonOpenSupplies = new System.Windows.Forms.Button();
            this.buttonOpenDeals = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenClients
            // 
            this.buttonOpenClients.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenClients.Location = new System.Drawing.Point(4, 182);
            this.buttonOpenClients.Name = "buttonOpenClients";
            this.buttonOpenClients.Size = new System.Drawing.Size(271, 48);
            this.buttonOpenClients.TabIndex = 1;
            this.buttonOpenClients.Text = "Клиент";
            this.buttonOpenClients.UseVisualStyleBackColor = false;
            this.buttonOpenClients.Click += new System.EventHandler(this.buttonOpenClients_Click);
            // 
            // buttonOpenAgents
            // 
            this.buttonOpenAgents.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenAgents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpenAgents.Location = new System.Drawing.Point(4, 245);
            this.buttonOpenAgents.Name = "buttonOpenAgents";
            this.buttonOpenAgents.Size = new System.Drawing.Size(271, 48);
            this.buttonOpenAgents.TabIndex = 2;
            this.buttonOpenAgents.Text = "Риелторы";
            this.buttonOpenAgents.UseVisualStyleBackColor = false;
            // 
            // buttonOpenRealEstates
            // 
            this.buttonOpenRealEstates.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenRealEstates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenRealEstates.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenRealEstates.Location = new System.Drawing.Point(4, 308);
            this.buttonOpenRealEstates.Name = "buttonOpenRealEstates";
            this.buttonOpenRealEstates.Size = new System.Drawing.Size(271, 49);
            this.buttonOpenRealEstates.TabIndex = 3;
            this.buttonOpenRealEstates.Text = "Объекты недвижимости";
            this.buttonOpenRealEstates.UseVisualStyleBackColor = false;
            // 
            // buttonOpenDemands
            // 
            this.buttonOpenDemands.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenDemands.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDemands.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpenDemands.Location = new System.Drawing.Point(4, 373);
            this.buttonOpenDemands.Name = "buttonOpenDemands";
            this.buttonOpenDemands.Size = new System.Drawing.Size(271, 48);
            this.buttonOpenDemands.TabIndex = 4;
            this.buttonOpenDemands.Text = "Предложения";
            this.buttonOpenDemands.UseVisualStyleBackColor = false;
            // 
            // buttonOpenSupplies
            // 
            this.buttonOpenSupplies.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenSupplies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenSupplies.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpenSupplies.Location = new System.Drawing.Point(4, 438);
            this.buttonOpenSupplies.Name = "buttonOpenSupplies";
            this.buttonOpenSupplies.Size = new System.Drawing.Size(271, 48);
            this.buttonOpenSupplies.TabIndex = 5;
            this.buttonOpenSupplies.Text = "Потребности";
            this.buttonOpenSupplies.UseVisualStyleBackColor = false;
            // 
            // buttonOpenDeals
            // 
            this.buttonOpenDeals.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenDeals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDeals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonOpenDeals.Location = new System.Drawing.Point(4, 501);
            this.buttonOpenDeals.Name = "buttonOpenDeals";
            this.buttonOpenDeals.Size = new System.Drawing.Size(271, 48);
            this.buttonOpenDeals.TabIndex = 6;
            this.buttonOpenDeals.Text = "Сделки";
            this.buttonOpenDeals.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(4, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 101);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(279, 552);
            this.Controls.Add(this.buttonOpenDeals);
            this.Controls.Add(this.buttonOpenSupplies);
            this.Controls.Add(this.buttonOpenDemands);
            this.Controls.Add(this.buttonOpenRealEstates);
            this.Controls.Add(this.buttonOpenAgents);
            this.Controls.Add(this.buttonOpenClients);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Esoft";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonOpenClients;
        private System.Windows.Forms.Button buttonOpenAgents;
        private System.Windows.Forms.Button buttonOpenRealEstates;
        private System.Windows.Forms.Button buttonOpenDemands;
        private System.Windows.Forms.Button buttonOpenSupplies;
        private System.Windows.Forms.Button buttonOpenDeals;
    }
}

