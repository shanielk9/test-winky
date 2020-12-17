namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.moviesGB = new System.Windows.Forms.GroupBox();
            this.dataGridViewMovie = new System.Windows.Forms.DataGridView();
            this.wishlisttitle = new System.Windows.Forms.Label();
            this.wishlistdesc1 = new System.Windows.Forms.Label();
            this.wishlistdesc2 = new System.Windows.Forms.Label();
            this.checkedListBoxWishBox = new System.Windows.Forms.CheckedListBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.moviesGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // moviesGB
            // 
            this.moviesGB.Controls.Add(this.dataGridViewMovie);
            this.moviesGB.Location = new System.Drawing.Point(14, 15);
            this.moviesGB.Name = "moviesGB";
            this.moviesGB.Size = new System.Drawing.Size(570, 431);
            this.moviesGB.TabIndex = 0;
            this.moviesGB.TabStop = false;
            this.moviesGB.Text = "Top Apple Movies:";
            // 
            // dataGridViewMovie
            // 
            this.dataGridViewMovie.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridViewMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovie.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewMovie.Name = "dataGridViewMovie";
            this.dataGridViewMovie.RowTemplate.Height = 24;
            this.dataGridViewMovie.Size = new System.Drawing.Size(558, 402);
            this.dataGridViewMovie.TabIndex = 0;
            this.dataGridViewMovie.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMovie_CellContentDoubleClick);
            // 
            // wishlisttitle
            // 
            this.wishlisttitle.AutoSize = true;
            this.wishlisttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.wishlisttitle.Location = new System.Drawing.Point(584, 36);
            this.wishlisttitle.Name = "wishlisttitle";
            this.wishlisttitle.Size = new System.Drawing.Size(212, 24);
            this.wishlisttitle.TabIndex = 1;
            this.wishlisttitle.Text = "Wish list from movies:";
            // 
            // wishlistdesc1
            // 
            this.wishlistdesc1.AutoSize = true;
            this.wishlistdesc1.Location = new System.Drawing.Point(613, 68);
            this.wishlistdesc1.Name = "wishlistdesc1";
            this.wishlistdesc1.Size = new System.Drawing.Size(157, 17);
            this.wishlistdesc1.TabIndex = 2;
            this.wishlistdesc1.Text = "to add movie to wish list";
            // 
            // wishlistdesc2
            // 
            this.wishlistdesc2.AutoSize = true;
            this.wishlistdesc2.Location = new System.Drawing.Point(599, 85);
            this.wishlistdesc2.Name = "wishlistdesc2";
            this.wishlistdesc2.Size = new System.Drawing.Size(193, 17);
            this.wishlistdesc2.TabIndex = 3;
            this.wishlistdesc2.Text = "double click on it in movie list!";
            // 
            // checkedListBoxWishBox
            // 
            this.checkedListBoxWishBox.FormattingEnabled = true;
            this.checkedListBoxWishBox.Location = new System.Drawing.Point(599, 123);
            this.checkedListBoxWishBox.Name = "checkedListBoxWishBox";
            this.checkedListBoxWishBox.Size = new System.Drawing.Size(193, 259);
            this.checkedListBoxWishBox.TabIndex = 5;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(595, 388);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(193, 23);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "Remove From Wish List";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 450);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.checkedListBoxWishBox);
            this.Controls.Add(this.wishlistdesc2);
            this.Controls.Add(this.wishlistdesc1);
            this.Controls.Add(this.wishlisttitle);
            this.Controls.Add(this.moviesGB);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.moviesGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox moviesGB;
        private System.Windows.Forms.DataGridView dataGridViewMovie;
        private System.Windows.Forms.Label wishlisttitle;
        private System.Windows.Forms.Label wishlistdesc1;
        private System.Windows.Forms.Label wishlistdesc2;
        private System.Windows.Forms.CheckedListBox checkedListBoxWishBox;
        private System.Windows.Forms.Button buttonRemove;
    }
}