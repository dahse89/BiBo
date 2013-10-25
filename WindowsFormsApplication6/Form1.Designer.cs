namespace BiBo
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
          this.UserStatus = new System.Windows.Forms.Label();
          this.LoginAs = new System.Windows.Forms.Label();
          this.panel3 = new System.Windows.Forms.Panel();
          this.panel2 = new System.Windows.Forms.Panel();
          this.panel1 = new System.Windows.Forms.Panel();
          this.MainPanel = new System.Windows.Forms.Panel();
          this.userDetails = new System.Windows.Forms.GroupBox();
          this.userStatistic = new System.Windows.Forms.GroupBox();
          this.UserTablePanel = new System.Windows.Forms.GroupBox();
          this.userTableDataSet = new System.Windows.Forms.DataGridView();
          this.UserAddPanel = new System.Windows.Forms.GroupBox();
          this.userName = new System.Windows.Forms.Label();
          this.userStat = new System.Windows.Forms.Label();
          this.MainPanel.SuspendLayout();
          this.UserTablePanel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.userTableDataSet)).BeginInit();
          this.SuspendLayout();
          // 
          // UserStatus
          // 
          this.UserStatus.AutoSize = true;
          this.UserStatus.BackColor = System.Drawing.SystemColors.Window;
          this.UserStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.UserStatus.Location = new System.Drawing.Point(21, 51);
          this.UserStatus.Name = "UserStatus";
          this.UserStatus.Size = new System.Drawing.Size(52, 13);
          this.UserStatus.ForeColor = System.Drawing.Color.Black;
          this.UserStatus.TabIndex = 1;
          this.UserStatus.Text = "Status: ";
          // 
          // LoginAs
          // 
          this.LoginAs.AutoSize = true;
          this.LoginAs.BackColor = System.Drawing.SystemColors.Window;
          this.LoginAs.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.LoginAs.ForeColor = System.Drawing.Color.Black;
          this.LoginAs.Location = new System.Drawing.Point(21, 32);
          this.LoginAs.Name = "LoginAs";
          this.LoginAs.Size = new System.Drawing.Size(95, 13);
          this.LoginAs.TabIndex = 0;
          this.LoginAs.Text = "eingeloggt als: ";
          // 
          // panel3
          // 
          this.panel3.BackgroundImage = global::BiBo.Properties.Resources.icon2;
          this.panel3.Location = new System.Drawing.Point(286, 18);
          this.panel3.Name = "panel3";
          this.panel3.Size = new System.Drawing.Size(60, 53);
          this.panel3.TabIndex = 2;
          // 
          // panel2
          // 
          this.panel2.BackgroundImage = global::BiBo.Properties.Resources.user2;
          this.panel2.Location = new System.Drawing.Point(221, 19);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(60, 65);
          this.panel2.TabIndex = 2;
          // 
          // panel1
          // 
          this.panel1.BackgroundImage = global::BiBo.Properties.Resources.icon2;
          this.panel1.Location = new System.Drawing.Point(352, 18);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(60, 53);
          this.panel1.TabIndex = 2;
          // 
          // MainPanel
          // 
          this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
          this.MainPanel.Controls.Add(this.userDetails);
          this.MainPanel.Controls.Add(this.userStatistic);
          this.MainPanel.Controls.Add(this.UserTablePanel);
          this.MainPanel.Controls.Add(this.UserAddPanel);
          this.MainPanel.Location = new System.Drawing.Point(220, 77);
          this.MainPanel.Name = "MainPanel";
          this.MainPanel.Size = new System.Drawing.Size(815, 356);
          this.MainPanel.TabIndex = 3;
          // 
          // userDetails
          // 
          this.userDetails.Location = new System.Drawing.Point(603, 173);
          this.userDetails.Name = "userDetails";
          this.userDetails.Size = new System.Drawing.Size(200, 100);
          this.userDetails.TabIndex = 3;
          this.userDetails.TabStop = false;
          this.userDetails.Text = "Kunden Details";
          this.userDetails.ForeColor = System.Drawing.Color.Black;
          // 
          // userStatistic
          // 
          this.userStatistic.Location = new System.Drawing.Point(598, 13);
          this.userStatistic.Name = "userStatistic";
          this.userStatistic.Size = new System.Drawing.Size(200, 100);
          this.userStatistic.TabIndex = 2;
          this.userStatistic.TabStop = false;
          this.userStatistic.Text = "Statistic";
          this.userStatistic.ForeColor = System.Drawing.Color.Black;
          // 
          // UserTablePanel
          // 
          this.UserTablePanel.Controls.Add(this.userTableDataSet);
          this.UserTablePanel.Location = new System.Drawing.Point(12, 164);
          this.UserTablePanel.Name = "UserTablePanel";
          this.UserTablePanel.Size = new System.Drawing.Size(562, 181);
          this.UserTablePanel.TabIndex = 1;
          this.UserTablePanel.TabStop = false;
          this.UserTablePanel.Text = "Kunden";
          this.UserTablePanel.ForeColor = System.Drawing.Color.Black;
          // 
          // userTableDataSet
          // 
          this.userTableDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.userTableDataSet.Location = new System.Drawing.Point(6, 19);
          this.userTableDataSet.Name = "userTableDataSet";
          this.userTableDataSet.Size = new System.Drawing.Size(443, 150);
          this.userTableDataSet.TabIndex = 0;
          // 
          // UserAddPanel
          // 
          this.UserAddPanel.Location = new System.Drawing.Point(12, 13);
          this.UserAddPanel.Name = "UserAddPanel";
          this.UserAddPanel.Size = new System.Drawing.Size(579, 144);
          this.UserAddPanel.TabIndex = 0;
          this.UserAddPanel.TabStop = false;
          this.UserAddPanel.Text = "Kunde hinzufügen";
          this.UserAddPanel.ForeColor = System.Drawing.Color.Black;
          // 
          // userName
          // 
          this.userName.AutoSize = true;
          this.userName.BackColor = System.Drawing.SystemColors.Window;
          this.userName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.userName.Location = new System.Drawing.Point(106, 32);
          this.userName.Margin = new System.Windows.Forms.Padding(0);
          this.userName.Name = "userName";
          this.userName.ForeColor = System.Drawing.Color.Black;
          this.userName.Size = new System.Drawing.Size(11, 13);
          this.userName.TabIndex = 0;
          this.userName.Text = " ";
          // 
          // userStat
          // 
          this.userStat.AutoSize = true;
          this.userStat.BackColor = System.Drawing.SystemColors.Window;
          this.userStat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.userStat.Location = new System.Drawing.Point(64, 51);
          this.userStat.Name = "userStat";
          this.userStat.Size = new System.Drawing.Size(11, 13);
          this.userStat.ForeColor = System.Drawing.Color.Black;
          this.userStat.TabIndex = 1;
          this.userStat.Text = " ";
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackgroundImage = global::BiBo.Properties.Resources.bibibg2;
          this.ClientSize = new System.Drawing.Size(1035, 434);
          this.Controls.Add(this.MainPanel);
          this.Controls.Add(this.userStat);
          this.Controls.Add(this.UserStatus);
          this.Controls.Add(this.userName);
          this.Controls.Add(this.LoginAs);
          this.Controls.Add(this.panel1);
          this.Controls.Add(this.panel3);
          this.Controls.Add(this.panel2);
          this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
          this.Name = "Form1";
          this.Text = "Form1";
          this.Resize += new System.EventHandler(this.Form1_Resize);
          this.MainPanel.ResumeLayout(false);
          this.UserTablePanel.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.userTableDataSet)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LoginAs;
        private System.Windows.Forms.Label UserStatus;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label userStat;
        private System.Windows.Forms.GroupBox UserAddPanel;
        private System.Windows.Forms.GroupBox UserTablePanel;
        private System.Windows.Forms.GroupBox userDetails;
        private System.Windows.Forms.GroupBox userStatistic;
        private System.Windows.Forms.DataGridView userTableDataSet;

    }
}

