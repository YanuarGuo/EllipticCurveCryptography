namespace EllipticCurveCryptography
{
    partial class EllipticCurveCryptography
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
            CbCurve = new ComboBox();
            BtnGenerate = new Button();
            groupBox1 = new GroupBox();
            TxtPrivKey = new TextBox();
            TxtPubKey = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TxtComponents = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            CbAlgo = new ComboBox();
            BtnSign = new Button();
            BtnVerify = new Button();
            TxtMessage = new TextBox();
            label4 = new Label();
            GbDigSign = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            GbDigSign.SuspendLayout();
            SuspendLayout();
            // 
            // CbCurve
            // 
            CbCurve.DropDownStyle = ComboBoxStyle.DropDownList;
            CbCurve.FormattingEnabled = true;
            CbCurve.Items.AddRange(new object[] { "secp128r1", "secp160k1", "secp160r1", "secp160r2", "secp192k1", "secp192r1", "secp224k1", "secp224r1", "secp256k1", "secp256r1", "secp384r1", "secp521r1", "sect113r1", "sect113r2", "sect131r1", "sect131r2", "sect163k1", "sect163r1", "sect163r2", "sect193r1", "sect193r2", "sect233k1", "sect233r1", "sect239k1", "sect283k1", "sect283r1", "sect409k1", "sect409r1", "sect571k1", "sect571r1", "sm2p256v1", "B-163", "B-233", "B-283", "B-409", "B-571", "K-163", "K-233", "K-283", "K-409", "K-571", "P-192", "P-224", "P-256", "P-384", "P-521" });
            CbCurve.Location = new Point(6, 22);
            CbCurve.Name = "CbCurve";
            CbCurve.Size = new Size(322, 23);
            CbCurve.TabIndex = 0;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Location = new Point(590, 295);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(96, 23);
            BtnGenerate.TabIndex = 4;
            BtnGenerate.Text = "Generate Key";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CbCurve);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(334, 61);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Curve";
            // 
            // TxtPrivKey
            // 
            TxtPrivKey.Location = new Point(12, 106);
            TxtPrivKey.Multiline = true;
            TxtPrivKey.Name = "TxtPrivKey";
            TxtPrivKey.ScrollBars = ScrollBars.Vertical;
            TxtPrivKey.Size = new Size(334, 181);
            TxtPrivKey.TabIndex = 2;
            // 
            // TxtPubKey
            // 
            TxtPubKey.Location = new Point(352, 106);
            TxtPubKey.Multiline = true;
            TxtPubKey.Name = "TxtPubKey";
            TxtPubKey.ScrollBars = ScrollBars.Vertical;
            TxtPubKey.Size = new Size(334, 181);
            TxtPubKey.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 88);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 6;
            label1.Text = "Private Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(624, 88);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 7;
            label2.Text = "Public Key";
            // 
            // TxtComponents
            // 
            TxtComponents.Location = new Point(12, 487);
            TxtComponents.Multiline = true;
            TxtComponents.Name = "TxtComponents";
            TxtComponents.ScrollBars = ScrollBars.Vertical;
            TxtComponents.Size = new Size(674, 161);
            TxtComponents.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 469);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 9;
            label3.Text = "Components";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(CbAlgo);
            groupBox2.Location = new Point(352, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(334, 61);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Select Algorithm";
            // 
            // CbAlgo
            // 
            CbAlgo.DropDownStyle = ComboBoxStyle.DropDownList;
            CbAlgo.FormattingEnabled = true;
            CbAlgo.Items.AddRange(new object[] { "ECDSA (Elliptic Curve Digital Signature Algorithm)", "ECDH (Elliptic Curve Diffie-Hellman)", "ECMQV (Elliptic Curve Menezes–Qu–Vanstone)", "EdDSA (Edwards-curve Digital Signature Algorithm)", "None" });
            CbAlgo.Location = new Point(6, 22);
            CbAlgo.Name = "CbAlgo";
            CbAlgo.Size = new Size(322, 23);
            CbAlgo.TabIndex = 1;
            // 
            // BtnSign
            // 
            BtnSign.Location = new Point(572, 95);
            BtnSign.Name = "BtnSign";
            BtnSign.Size = new Size(96, 23);
            BtnSign.TabIndex = 8;
            BtnSign.Text = "Signature";
            BtnSign.UseVisualStyleBackColor = true;
            BtnSign.Click += BtnSign_Click;
            // 
            // BtnVerify
            // 
            BtnVerify.Location = new Point(470, 95);
            BtnVerify.Name = "BtnVerify";
            BtnVerify.Size = new Size(96, 23);
            BtnVerify.TabIndex = 7;
            BtnVerify.Text = "Verify";
            BtnVerify.UseVisualStyleBackColor = true;
            BtnVerify.Click += BtnVerify_Click;
            // 
            // TxtMessage
            // 
            TxtMessage.Location = new Point(6, 40);
            TxtMessage.Multiline = true;
            TxtMessage.Name = "TxtMessage";
            TxtMessage.Size = new Size(662, 46);
            TxtMessage.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 22);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 13;
            label4.Text = "Message";
            // 
            // GbDigSign
            // 
            GbDigSign.Controls.Add(TxtMessage);
            GbDigSign.Controls.Add(label4);
            GbDigSign.Controls.Add(BtnSign);
            GbDigSign.Controls.Add(BtnVerify);
            GbDigSign.Location = new Point(12, 322);
            GbDigSign.Name = "GbDigSign";
            GbDigSign.Size = new Size(674, 131);
            GbDigSign.TabIndex = 14;
            GbDigSign.TabStop = false;
            GbDigSign.Text = "Digital Signature";
            // 
            // EllipticCurveCryptography
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 660);
            Controls.Add(GbDigSign);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(TxtComponents);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtPubKey);
            Controls.Add(TxtPrivKey);
            Controls.Add(groupBox1);
            Controls.Add(BtnGenerate);
            Name = "EllipticCurveCryptography";
            Text = "EllipticCurveCryptography";
            Load += EllipticCurveCryptography_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            GbDigSign.ResumeLayout(false);
            GbDigSign.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CbCurve;
        private Button BtnGenerate;
        private GroupBox groupBox1;
        private TextBox TxtPrivKey;
        private TextBox TxtPubKey;
        private Label label1;
        private Label label2;
        private TextBox TxtComponents;
        private Label label3;
        private GroupBox groupBox2;
        private ComboBox CbAlgo;
        private Button BtnSign;
        private Button BtnVerify;
        private TextBox TxtMessage;
        private Label label4;
        private GroupBox GbDigSign;
    }
}
