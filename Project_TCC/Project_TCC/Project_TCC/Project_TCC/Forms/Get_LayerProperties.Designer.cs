namespace Project_TCC.Forms
{
    partial class Get_LayerProperties
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbo_T = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_Unit_major = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_rib_thickness = new System.Windows.Forms.Label();
            this.lbl_rib_width = new System.Windows.Forms.Label();
            this.lbl_width = new System.Windows.Forms.Label();
            this.pbo_rib_layer = new System.Windows.Forms.PictureBox();
            this.btn_Initialize = new System.Windows.Forms.Button();
            this.btn_RemoveLayer = new System.Windows.Forms.Button();
            this.btn_AddLayer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbo_rib_layer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrev.Location = new System.Drawing.Point(12, 617);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(65, 34);
            this.btnPrev.TabIndex = 36;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNext.Location = new System.Drawing.Point(1147, 621);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(68, 30);
            this.btnNext.TabIndex = 37;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(22, 361);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 21);
            this.label5.TabIndex = 51;
            this.label5.Text = "Properties by Layer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvInput
            // 
            this.dgvInput.AllowUserToAddRows = false;
            this.dgvInput.AllowUserToDeleteRows = false;
            this.dgvInput.AllowUserToResizeColumns = false;
            this.dgvInput.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInput.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInput.Location = new System.Drawing.Point(21, 386);
            this.dgvInput.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInput.MultiSelect = false;
            this.dgvInput.Name = "dgvInput";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInput.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvInput.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvInput.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgvInput.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvInput.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvInput.RowTemplate.Height = 23;
            this.dgvInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInput.Size = new System.Drawing.Size(1037, 224);
            this.dgvInput.TabIndex = 47;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbo_T);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lbl_Unit_major);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(21, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 169);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slab Dimension";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(174, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 76;
            this.label7.Text = "(mm)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbo_T
            // 
            this.tbo_T.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbo_T.Location = new System.Drawing.Point(130, 73);
            this.tbo_T.Margin = new System.Windows.Forms.Padding(1);
            this.tbo_T.Name = "tbo_T";
            this.tbo_T.Size = new System.Drawing.Size(39, 27);
            this.tbo_T.TabIndex = 75;
            this.tbo_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbo_T.TextChanged += new System.EventHandler(this.tbo_T_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(13, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "insulation(t):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(174, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 20);
            this.label19.TabIndex = 73;
            this.label19.Text = "(mm)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.Location = new System.Drawing.Point(130, 39);
            this.textBox3.Margin = new System.Windows.Forms.Padding(1);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(39, 27);
            this.textBox3.TabIndex = 72;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(13, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 20);
            this.label20.TabIndex = 71;
            this.label20.Text = "rib width :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Unit_major
            // 
            this.lbl_Unit_major.AutoSize = true;
            this.lbl_Unit_major.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Unit_major.Location = new System.Drawing.Point(689, 63);
            this.lbl_Unit_major.Name = "lbl_Unit_major";
            this.lbl_Unit_major.Size = new System.Drawing.Size(45, 20);
            this.lbl_Unit_major.TabIndex = 56;
            this.lbl_Unit_major.Text = "(mm)";
            this.lbl_Unit_major.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 50);
            this.label1.TabIndex = 53;
            this.label1.Text = "Construct a Slab";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(797, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 17);
            this.label16.TabIndex = 75;
            this.label16.Text = "h(t) :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(473, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 74;
            this.label9.Text = "rib width :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(813, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 73;
            this.label3.Text = "t :";
            // 
            // lbl_rib_thickness
            // 
            this.lbl_rib_thickness.AutoSize = true;
            this.lbl_rib_thickness.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_rib_thickness.Location = new System.Drawing.Point(790, 177);
            this.lbl_rib_thickness.Name = "lbl_rib_thickness";
            this.lbl_rib_thickness.Size = new System.Drawing.Size(66, 17);
            this.lbl_rib_thickness.TabIndex = 72;
            this.lbl_rib_thickness.Text = "Thickness";
            // 
            // lbl_rib_width
            // 
            this.lbl_rib_width.AutoSize = true;
            this.lbl_rib_width.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_rib_width.Location = new System.Drawing.Point(480, 82);
            this.lbl_rib_width.Name = "lbl_rib_width";
            this.lbl_rib_width.Size = new System.Drawing.Size(41, 17);
            this.lbl_rib_width.TabIndex = 71;
            this.lbl_rib_width.Text = "width";
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_width.Location = new System.Drawing.Point(517, 82);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(26, 17);
            this.lbl_width.TabIndex = 70;
            this.lbl_width.Text = "  : ";
            // 
            // pbo_rib_layer
            // 
            this.pbo_rib_layer.Image = global::Project_TCC.Properties.Resources.layerpropeties_pic;
            this.pbo_rib_layer.Location = new System.Drawing.Point(314, 77);
            this.pbo_rib_layer.Name = "pbo_rib_layer";
            this.pbo_rib_layer.Size = new System.Drawing.Size(493, 243);
            this.pbo_rib_layer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbo_rib_layer.TabIndex = 69;
            this.pbo_rib_layer.TabStop = false;
            // 
            // btn_Initialize
            // 
            this.btn_Initialize.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Initialize.Image = global::Project_TCC.Properties.Resources.initialize;
            this.btn_Initialize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Initialize.Location = new System.Drawing.Point(1079, 572);
            this.btn_Initialize.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Initialize.Name = "btn_Initialize";
            this.btn_Initialize.Size = new System.Drawing.Size(136, 35);
            this.btn_Initialize.TabIndex = 48;
            this.btn_Initialize.Text = "   Initialize";
            this.btn_Initialize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Initialize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Initialize.UseVisualStyleBackColor = true;
            // 
            // btn_RemoveLayer
            // 
            this.btn_RemoveLayer.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_RemoveLayer.Image = global::Project_TCC.Properties.Resources.remove;
            this.btn_RemoveLayer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_RemoveLayer.Location = new System.Drawing.Point(1079, 529);
            this.btn_RemoveLayer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RemoveLayer.Name = "btn_RemoveLayer";
            this.btn_RemoveLayer.Size = new System.Drawing.Size(136, 35);
            this.btn_RemoveLayer.TabIndex = 49;
            this.btn_RemoveLayer.Text = "   Remove layer";
            this.btn_RemoveLayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_RemoveLayer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_RemoveLayer.UseVisualStyleBackColor = true;
            // 
            // btn_AddLayer
            // 
            this.btn_AddLayer.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_AddLayer.Image = global::Project_TCC.Properties.Resources.add;
            this.btn_AddLayer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddLayer.Location = new System.Drawing.Point(1079, 486);
            this.btn_AddLayer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AddLayer.Name = "btn_AddLayer";
            this.btn_AddLayer.Size = new System.Drawing.Size(136, 35);
            this.btn_AddLayer.TabIndex = 50;
            this.btn_AddLayer.Text = "   Add layer";
            this.btn_AddLayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddLayer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddLayer.UseVisualStyleBackColor = true;
            // 
            // Get_LayerProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 653);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_rib_thickness);
            this.Controls.Add(this.lbl_rib_width);
            this.Controls.Add(this.lbl_width);
            this.Controls.Add(this.pbo_rib_layer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Initialize);
            this.Controls.Add(this.btn_RemoveLayer);
            this.Controls.Add(this.btn_AddLayer);
            this.Controls.Add(this.dgvInput);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Name = "Get_LayerProperties";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbo_rib_layer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Initialize;
        private System.Windows.Forms.Button btn_RemoveLayer;
        private System.Windows.Forms.Button btn_AddLayer;
        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_Unit_major;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbo_T;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_rib_thickness;
        private System.Windows.Forms.Label lbl_rib_width;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.PictureBox pbo_rib_layer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label20;
    }
}