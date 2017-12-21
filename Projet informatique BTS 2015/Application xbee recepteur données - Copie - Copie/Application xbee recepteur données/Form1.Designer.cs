namespace Application_xbee_recepteur_données
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.b_quitter = new System.Windows.Forms.Button();
            this.t_poids_max = new System.Windows.Forms.TextBox();
            this.t_poids_min = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.l_poids = new System.Windows.Forms.Label();
            this.l_temp = new System.Windows.Forms.Label();
            this.l_batterie = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.t_mail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.b_reglages = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.l_batteriealerte = new System.Windows.Forms.Label();
            this.l_poidsalerte = new System.Windows.Forms.Label();
            this.l_reception = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.b_testmail = new System.Windows.Forms.Button();
            this.b_testip = new System.Windows.Forms.Button();
            this.l_ip = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.t_ip4 = new System.Windows.Forms.TextBox();
            this.t_ip3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.l_reception2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.l_datetime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.l_mailmiss = new System.Windows.Forms.Label();
            this.l_ipmiss = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_quitter
            // 
            this.b_quitter.Location = new System.Drawing.Point(350, 165);
            this.b_quitter.Name = "b_quitter";
            this.b_quitter.Size = new System.Drawing.Size(83, 40);
            this.b_quitter.TabIndex = 0;
            this.b_quitter.Text = "Quitter";
            this.b_quitter.UseVisualStyleBackColor = true;
            this.b_quitter.Click += new System.EventHandler(this.b_quitter_Click);
            // 
            // t_poids_max
            // 
            this.t_poids_max.BackColor = System.Drawing.SystemColors.Window;
            this.t_poids_max.Location = new System.Drawing.Point(245, 60);
            this.t_poids_max.MaxLength = 2;
            this.t_poids_max.Name = "t_poids_max";
            this.t_poids_max.Size = new System.Drawing.Size(31, 20);
            this.t_poids_max.TabIndex = 5;
            this.t_poids_max.Text = "40";
            // 
            // t_poids_min
            // 
            this.t_poids_min.BackColor = System.Drawing.SystemColors.Window;
            this.t_poids_min.Location = new System.Drawing.Point(167, 60);
            this.t_poids_min.MaxLength = 2;
            this.t_poids_min.Name = "t_poids_min";
            this.t_poids_min.Size = new System.Drawing.Size(31, 20);
            this.t_poids_min.TabIndex = 6;
            this.t_poids_min.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "et";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Le poids doit être compris entre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Poids";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Température";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Batterie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Kg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "°C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(282, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Kg";
            // 
            // l_poids
            // 
            this.l_poids.AutoSize = true;
            this.l_poids.Location = new System.Drawing.Point(147, 29);
            this.l_poids.Name = "l_poids";
            this.l_poids.Size = new System.Drawing.Size(28, 13);
            this.l_poids.TabIndex = 21;
            this.l_poids.Text = "00,0";
            // 
            // l_temp
            // 
            this.l_temp.AutoSize = true;
            this.l_temp.Location = new System.Drawing.Point(147, 50);
            this.l_temp.Name = "l_temp";
            this.l_temp.Size = new System.Drawing.Size(28, 13);
            this.l_temp.TabIndex = 22;
            this.l_temp.Text = "00,0";
            // 
            // l_batterie
            // 
            this.l_batterie.AutoSize = true;
            this.l_batterie.Location = new System.Drawing.Point(147, 69);
            this.l_batterie.Name = "l_batterie";
            this.l_batterie.Size = new System.Drawing.Size(28, 13);
            this.l_batterie.TabIndex = 23;
            this.l_batterie.Text = "00,0";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // t_mail
            // 
            this.t_mail.BackColor = System.Drawing.SystemColors.Window;
            this.t_mail.Location = new System.Drawing.Point(92, 10);
            this.t_mail.Name = "t_mail";
            this.t_mail.Size = new System.Drawing.Size(210, 20);
            this.t_mail.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Adresse Email :";
            // 
            // b_reglages
            // 
            this.b_reglages.Location = new System.Drawing.Point(332, 60);
            this.b_reglages.Name = "b_reglages";
            this.b_reglages.Size = new System.Drawing.Size(100, 46);
            this.b_reglages.TabIndex = 28;
            this.b_reglages.Text = "Enregistrer les informations";
            this.b_reglages.UseVisualStyleBackColor = true;
            this.b_reglages.Click += new System.EventHandler(this.b_reglages_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(446, 139);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.l_ipmiss);
            this.tabPage1.Controls.Add(this.l_mailmiss);
            this.tabPage1.Controls.Add(this.l_batteriealerte);
            this.tabPage1.Controls.Add(this.l_poidsalerte);
            this.tabPage1.Controls.Add(this.l_reception);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.l_batterie);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.l_temp);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.l_poids);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(438, 113);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // l_batteriealerte
            // 
            this.l_batteriealerte.AutoSize = true;
            this.l_batteriealerte.ForeColor = System.Drawing.Color.Red;
            this.l_batteriealerte.Location = new System.Drawing.Point(0, 69);
            this.l_batteriealerte.Name = "l_batteriealerte";
            this.l_batteriealerte.Size = new System.Drawing.Size(43, 13);
            this.l_batteriealerte.TabIndex = 26;
            this.l_batteriealerte.Text = "FAIBLE";
            // 
            // l_poidsalerte
            // 
            this.l_poidsalerte.AutoSize = true;
            this.l_poidsalerte.ForeColor = System.Drawing.Color.Red;
            this.l_poidsalerte.Location = new System.Drawing.Point(0, 30);
            this.l_poidsalerte.Name = "l_poidsalerte";
            this.l_poidsalerte.Size = new System.Drawing.Size(70, 13);
            this.l_poidsalerte.TabIndex = 25;
            this.l_poidsalerte.Text = "TROP HAUT";
            // 
            // l_reception
            // 
            this.l_reception.AutoSize = true;
            this.l_reception.Location = new System.Drawing.Point(51, 97);
            this.l_reception.Name = "l_reception";
            this.l_reception.Size = new System.Drawing.Size(70, 13);
            this.l_reception.TabIndex = 24;
            this.l_reception.Text = "Mise à jour ...";
            this.l_reception.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.b_testmail);
            this.tabPage2.Controls.Add(this.b_testip);
            this.tabPage2.Controls.Add(this.l_ip);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.t_ip4);
            this.tabPage2.Controls.Add(this.t_ip3);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.t_mail);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.b_reglages);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.t_poids_min);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.t_poids_max);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(438, 113);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // b_testmail
            // 
            this.b_testmail.Location = new System.Drawing.Point(332, 10);
            this.b_testmail.Name = "b_testmail";
            this.b_testmail.Size = new System.Drawing.Size(100, 23);
            this.b_testmail.TabIndex = 39;
            this.b_testmail.Text = "Test Mail";
            this.b_testmail.UseVisualStyleBackColor = true;
            this.b_testmail.Click += new System.EventHandler(this.b_testmail_Click);
            // 
            // b_testip
            // 
            this.b_testip.Location = new System.Drawing.Point(332, 36);
            this.b_testip.Name = "b_testip";
            this.b_testip.Size = new System.Drawing.Size(100, 23);
            this.b_testip.TabIndex = 38;
            this.b_testip.Text = "Test Smartphone";
            this.b_testip.UseVisualStyleBackColor = true;
            this.b_testip.Click += new System.EventHandler(this.b_testip_Click);
            // 
            // l_ip
            // 
            this.l_ip.AutoSize = true;
            this.l_ip.Location = new System.Drawing.Point(89, 41);
            this.l_ip.Name = "l_ip";
            this.l_ip.Size = new System.Drawing.Size(58, 13);
            this.l_ip.TabIndex = 37;
            this.l_ip.Text = "192  .  168";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = ".";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(151, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = ".";
            // 
            // t_ip4
            // 
            this.t_ip4.Location = new System.Drawing.Point(245, 34);
            this.t_ip4.MaxLength = 3;
            this.t_ip4.Name = "t_ip4";
            this.t_ip4.Size = new System.Drawing.Size(30, 20);
            this.t_ip4.TabIndex = 33;
            // 
            // t_ip3
            // 
            this.t_ip3.Location = new System.Drawing.Point(168, 34);
            this.t_ip3.MaxLength = 3;
            this.t_ip3.Name = "t_ip3";
            this.t_ip3.Size = new System.Drawing.Size(30, 20);
            this.t_ip3.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Adresse IP :";
            // 
            // l_reception2
            // 
            this.l_reception2.AutoSize = true;
            this.l_reception2.BackColor = System.Drawing.Color.Red;
            this.l_reception2.ForeColor = System.Drawing.Color.White;
            this.l_reception2.Location = new System.Drawing.Point(11, 192);
            this.l_reception2.Name = "l_reception2";
            this.l_reception2.Size = new System.Drawing.Size(65, 13);
            this.l_reception2.TabIndex = 25;
            this.l_reception2.Text = "l_reception2";
            this.l_reception2.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // l_datetime
            // 
            this.l_datetime.AutoSize = true;
            this.l_datetime.Location = new System.Drawing.Point(129, 164);
            this.l_datetime.Name = "l_datetime";
            this.l_datetime.Size = new System.Drawing.Size(41, 13);
            this.l_datetime.TabIndex = 27;
            this.l_datetime.Text = "label12";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Dernière Mise à Jour :";
            // 
            // l_mailmiss
            // 
            this.l_mailmiss.AutoSize = true;
            this.l_mailmiss.ForeColor = System.Drawing.Color.Red;
            this.l_mailmiss.Location = new System.Drawing.Point(307, 27);
            this.l_mailmiss.Name = "l_mailmiss";
            this.l_mailmiss.Size = new System.Drawing.Size(125, 13);
            this.l_mailmiss.TabIndex = 27;
            this.l_mailmiss.Text = "Ajoutez une adresse Mail";
            // 
            // l_ipmiss
            // 
            this.l_ipmiss.AutoSize = true;
            this.l_ipmiss.ForeColor = System.Drawing.Color.Red;
            this.l_ipmiss.Location = new System.Drawing.Point(307, 50);
            this.l_ipmiss.Name = "l_ipmiss";
            this.l_ipmiss.Size = new System.Drawing.Size(116, 13);
            this.l_ipmiss.TabIndex = 28;
            this.l_ipmiss.Text = "Ajoutez une adresse IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(467, 217);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.l_datetime);
            this.Controls.Add(this.l_reception2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.b_quitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HonneyBee Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_quitter;
        private System.Windows.Forms.TextBox t_poids_max;
        private System.Windows.Forms.TextBox t_poids_min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label l_poids;
        private System.Windows.Forms.Label l_temp;
        private System.Windows.Forms.Label l_batterie;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox t_mail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button b_reglages;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label l_reception;
        private System.Windows.Forms.Label l_reception2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox t_ip4;
        private System.Windows.Forms.TextBox t_ip3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label l_ip;
        private System.Windows.Forms.Label l_batteriealerte;
        private System.Windows.Forms.Label l_poidsalerte;
        private System.Windows.Forms.Button b_testmail;
        private System.Windows.Forms.Button b_testip;
        private System.Windows.Forms.Label l_datetime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label l_ipmiss;
        private System.Windows.Forms.Label l_mailmiss;
    }
}

