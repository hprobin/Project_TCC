namespace Project_TCC
{
    partial class SelectForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbo_rib_slab = new System.Windows.Forms.PictureBox();
            this.pbo_flat_slab = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbo_rib_slab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbo_flat_slab)).BeginInit();
            this.SuspendLayout();
            // 
            // pbo_rib_slab
            // 
            this.pbo_rib_slab.Image = global::Project_TCC.Properties.Resources.ribslab;
            this.pbo_rib_slab.Location = new System.Drawing.Point(553, 80);
            this.pbo_rib_slab.Name = "pbo_rib_slab";
            this.pbo_rib_slab.Size = new System.Drawing.Size(500, 500);
            this.pbo_rib_slab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbo_rib_slab.TabIndex = 4;
            this.pbo_rib_slab.TabStop = false;
            // 
            // pbo_flat_slab
            // 
            this.pbo_flat_slab.Image = global::Project_TCC.Properties.Resources.flatslab;
            this.pbo_flat_slab.Location = new System.Drawing.Point(31, 80);
            this.pbo_flat_slab.Name = "pbo_flat_slab";
            this.pbo_flat_slab.Size = new System.Drawing.Size(500, 500);
            this.pbo_flat_slab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbo_flat_slab.TabIndex = 5;
            this.pbo_flat_slab.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 50);
            this.label1.TabIndex = 15;
            this.label1.Text = "Choose a Slab Design";
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrev.Location = new System.Drawing.Point(31, 615);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(65, 34);
            this.btnPrev.TabIndex = 79;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.ChangeForm);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbo_rib_slab);
            this.Controls.Add(this.pbo_flat_slab);
            this.Name = "SelectForm";
            this.Text = "Project_TCC";
            ((System.ComponentModel.ISupportInitialize)(this.pbo_rib_slab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbo_flat_slab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbo_rib_slab;
        private System.Windows.Forms.PictureBox pbo_flat_slab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrev;
    }
}

