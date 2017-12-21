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
            this.b_alert = new System.Windows.Forms.Button();
            this.b_connect = new System.Windows.Forms.Button();
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
            this.b_lire = new System.Windows.Forms.Button();
            this.l_poids = new System.Windows.Forms.Label();
            this.l_temp = new System.Windows.Forms.Label();
            this.l_batterie = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.l_etapes = new System.Windows.Forms.Label();
            this.t_mail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.b_mail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_quitter
            // 
            this.b_quitter.Location = new System.Drawing.Point(451, 169);
            this.b_quitter.Name = "b_quitter";
            this.b_quitter.Size = new System.Drawing.Size(83, 40);
            this.b_quitter.TabIndex = 0;
            this.b_quitter.Text = "Quitter";
            this.b_quitter.UseVisualStyleBackColor = true;
            this.b_quitter.Click += new System.EventHandler(this.b_quitter_Click);
            // 
            // b_alert
            // 
            this.b_alert.Location = new System.Drawing.Point(451, 63);
            this.b_alert.Name = "b_alert";
            this.b_alert.Size = new System.Drawing.Size(83, 40);
            this.b_alert.TabIndex = 1;
            this.b_alert.Text = "Appliquer";
            this.b_alert.UseVisualStyleBackColor = true;
            this.b_alert.Click += new System.EventHandler(this.b_alert_Click);
            // 
            // b_connect
            // 
            this.b_connect.Location = new System.Drawing.Point(451, 119);
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(83, 44);
            this.b_connect.TabIndex = 3;
            this.b_connect.Text = "Connexion";
            this.b_connect.UseVisualStyleBackColor = true;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // t_poids_max
            // 
            this.t_poids_max.Location = new System.Drawing.Point(388, 63);
            this.t_poids_max.Name = "t_poids_max";
            this.t_poids_max.Size = new System.Drawing.Size(31, 20);
            this.t_poids_max.TabIndex = 5;
            this.t_poids_max.Text = "40";
            // 
            // t_poids_min
            // 
            this.t_poids_min.Location = new System.Drawing.Point(329, 64);
            this.t_poids_min.Name = "t_poids_min";
            this.t_poids_min.Size = new System.Drawing.Size(31, 20);
            this.t_poids_min.TabIndex = 6;
            this.t_poids_min.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "et";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "doit être compris entre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Poids";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Température";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Batterie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Kg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "°C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(425, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Kg";
            // 
            // b_lire
            // 
            this.b_lire.Location = new System.Drawing.Point(215, 148);
            this.b_lire.Name = "b_lire";
            this.b_lire.Size = new System.Drawing.Size(222, 61);
            this.b_lire.TabIndex = 20;
            this.b_lire.Text = "Lancer la lecture";
            this.b_lire.UseVisualStyleBackColor = true;
            this.b_lire.Click += new System.EventHandler(this.b_lire_Click);
            // 
            // l_poids
            // 
            this.l_poids.AutoSize = true;
            this.l_poids.Location = new System.Drawing.Point(123, 65);
            this.l_poids.Name = "l_poids";
            this.l_poids.Size = new System.Drawing.Size(19, 13);
            this.l_poids.TabIndex = 21;
            this.l_poids.Text = "35";
            // 
            // l_temp
            // 
            this.l_temp.AutoSize = true;
            this.l_temp.Location = new System.Drawing.Point(123, 111);
            this.l_temp.Name = "l_temp";
            this.l_temp.Size = new System.Drawing.Size(19, 13);
            this.l_temp.TabIndex = 22;
            this.l_temp.Text = "10";
            // 
            // l_batterie
            // 
            this.l_batterie.AutoSize = true;
            this.l_batterie.Location = new System.Drawing.Point(123, 157);
            this.l_batterie.Name = "l_batterie";
            this.l_batterie.Size = new System.Drawing.Size(19, 13);
            this.l_batterie.TabIndex = 23;
            this.l_batterie.Text = "50";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(215, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(222, 23);
            this.progressBar1.TabIndex = 24;
            // 
            // l_etapes
            // 
            this.l_etapes.AutoSize = true;
            this.l_etapes.Location = new System.Drawing.Point(212, 99);
            this.l_etapes.Name = "l_etapes";
            this.l_etapes.Size = new System.Drawing.Size(142, 13);
            this.l_etapes.TabIndex = 25;
            this.l_etapes.Text = "Progression du paramétrage:";
            // 
            // t_mail
            // 
            this.t_mail.Location = new System.Drawing.Point(115, 12);
            this.t_mail.Name = "t_mail";
            this.t_mail.Size = new System.Drawing.Size(330, 20);
            this.t_mail.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Adresse Email :";
            // 
            // b_mail
            // 
            this.b_mail.Location = new System.Drawing.Point(451, 10);
            this.b_mail.Name = "b_mail";
            this.b_mail.Size = new System.Drawing.Size(83, 23);
            this.b_mail.TabIndex = 28;
            this.b_mail.Text = "Enregistrer";
            this.b_mail.UseVisualStyleBackColor = true;
            this.b_mail.Click += new System.EventHandler(this.b_mail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 224);
            this.Controls.Add(this.b_mail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.t_mail);
            this.Controls.Add(this.l_etapes);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.l_batterie);
            this.Controls.Add(this.l_temp);
            this.Controls.Add(this.l_poids);
            this.Controls.Add(this.b_lire);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_poids_min);
            this.Controls.Add(this.t_poids_max);
            this.Controls.Add(this.b_connect);
            this.Controls.Add(this.b_alert);
            this.Controls.Add(this.b_quitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "HonneyBee Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_quitter;
        private System.Windows.Forms.Button b_alert;
        private System.Windows.Forms.Button b_connect;
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
        private System.Windows.Forms.Button b_lire;
        private System.Windows.Forms.Label l_poids;
        private System.Windows.Forms.Label l_temp;
        private System.Windows.Forms.Label l_batterie;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label l_etapes;
        private System.Windows.Forms.TextBox t_mail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button b_mail;
    }
}

