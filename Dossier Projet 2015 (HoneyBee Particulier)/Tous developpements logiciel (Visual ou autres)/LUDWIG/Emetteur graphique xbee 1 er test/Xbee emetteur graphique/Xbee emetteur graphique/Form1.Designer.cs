namespace Xbee_emetteur_graphique
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
            this.l_connexion = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.b_envoi = new System.Windows.Forms.Button();
            this.b_quitter = new System.Windows.Forms.Button();
            this.b_ouvrir = new System.Windows.Forms.Button();
            this.b_connect = new System.Windows.Forms.Button();
            this.b_deconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_connexion
            // 
            this.l_connexion.AutoSize = true;
            this.l_connexion.Location = new System.Drawing.Point(12, 193);
            this.l_connexion.Name = "l_connexion";
            this.l_connexion.Size = new System.Drawing.Size(57, 13);
            this.l_connexion.TabIndex = 0;
            this.l_connexion.Text = "Connexion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 114);
            this.textBox1.TabIndex = 1;
            // 
            // b_envoi
            // 
            this.b_envoi.Location = new System.Drawing.Point(344, 114);
            this.b_envoi.Name = "b_envoi";
            this.b_envoi.Size = new System.Drawing.Size(66, 29);
            this.b_envoi.TabIndex = 2;
            this.b_envoi.Text = "Envoyer";
            this.b_envoi.UseVisualStyleBackColor = true;
            this.b_envoi.Click += new System.EventHandler(this.b_envoi_Click);
            // 
            // b_quitter
            // 
            this.b_quitter.Location = new System.Drawing.Point(344, 179);
            this.b_quitter.Name = "b_quitter";
            this.b_quitter.Size = new System.Drawing.Size(66, 27);
            this.b_quitter.TabIndex = 3;
            this.b_quitter.Text = "Quitter";
            this.b_quitter.UseVisualStyleBackColor = true;
            this.b_quitter.Click += new System.EventHandler(this.b_quitter_Click);
            // 
            // b_ouvrir
            // 
            this.b_ouvrir.Location = new System.Drawing.Point(344, 58);
            this.b_ouvrir.Name = "b_ouvrir";
            this.b_ouvrir.Size = new System.Drawing.Size(65, 50);
            this.b_ouvrir.TabIndex = 4;
            this.b_ouvrir.Text = "Ouvrir un fichier texte";
            this.b_ouvrir.UseVisualStyleBackColor = true;
            this.b_ouvrir.Click += new System.EventHandler(this.b_ouvrir_Click);
            // 
            // b_connect
            // 
            this.b_connect.Location = new System.Drawing.Point(335, 12);
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(75, 27);
            this.b_connect.TabIndex = 5;
            this.b_connect.Text = "Connexion";
            this.b_connect.UseVisualStyleBackColor = true;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // b_deconnect
            // 
            this.b_deconnect.Location = new System.Drawing.Point(330, 149);
            this.b_deconnect.Name = "b_deconnect";
            this.b_deconnect.Size = new System.Drawing.Size(80, 23);
            this.b_deconnect.TabIndex = 6;
            this.b_deconnect.Text = "Deconnexion";
            this.b_deconnect.UseVisualStyleBackColor = true;
            this.b_deconnect.Click += new System.EventHandler(this.b_deconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 215);
            this.Controls.Add(this.b_deconnect);
            this.Controls.Add(this.b_connect);
            this.Controls.Add(this.b_ouvrir);
            this.Controls.Add(this.b_quitter);
            this.Controls.Add(this.b_envoi);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.l_connexion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_connexion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button b_envoi;
        private System.Windows.Forms.Button b_quitter;
        private System.Windows.Forms.Button b_ouvrir;
        private System.Windows.Forms.Button b_connect;
        private System.Windows.Forms.Button b_deconnect;
    }
}

