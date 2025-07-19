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
            GbCurve = new GroupBox();
            TxtPrivKey = new TextBox();
            TxtPubKey = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TxtComponents = new TextBox();
            label3 = new Label();
            GbAlgo = new GroupBox();
            CbAlgo = new ComboBox();
            BtnSign = new Button();
            BtnVerify = new Button();
            TxtMessage = new TextBox();
            label4 = new Label();
            GbDigSign = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            TxtS = new TextBox();
            TxtR = new TextBox();
            GbHash = new GroupBox();
            CbHash = new ComboBox();
            GbSharedKey = new GroupBox();
            BtnGenerateSharedKey = new Button();
            TxtSharedKey = new TextBox();
            BtnClear = new Button();
            GbCurve.SuspendLayout();
            GbAlgo.SuspendLayout();
            GbDigSign.SuspendLayout();
            GbHash.SuspendLayout();
            GbSharedKey.SuspendLayout();
            SuspendLayout();
            // 
            // CbCurve
            // 
            CbCurve.DropDownStyle = ComboBoxStyle.DropDownList;
            CbCurve.FormattingEnabled = true;
            CbCurve.Items.AddRange(new object[] { "secp128r1", "secp160k1", "secp160r1", "secp160r2", "secp192k1", "secp192r1", "secp224k1", "secp224r1", "secp256k1", "secp256r1", "secp384r1", "secp521r1", "sect113r1", "sect113r2", "sect131r1", "sect131r2", "sect163k1", "sect163r1", "sect163r2", "sect193r1", "sect193r2", "sect233k1", "sect233r1", "sect239k1", "sect283k1", "sect283r1", "sect409k1", "sect409r1", "sect571k1", "sect571r1", "sm2p256v1", "B-163", "B-233", "B-283", "B-409", "B-571", "K-163", "K-233", "K-283", "K-409", "K-571", "P-192", "P-224", "P-256", "P-384", "P-521" });
            CbCurve.Location = new Point(6, 22);
            CbCurve.Name = "CbCurve";
            CbCurve.Size = new Size(209, 23);
            CbCurve.TabIndex = 0;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Location = new Point(570, 295);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(116, 23);
            BtnGenerate.TabIndex = 4;
            BtnGenerate.Text = "Generate Key Pair";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // GbCurve
            // 
            GbCurve.Controls.Add(CbCurve);
            GbCurve.Location = new Point(12, 12);
            GbCurve.Name = "GbCurve";
            GbCurve.Size = new Size(221, 61);
            GbCurve.TabIndex = 3;
            GbCurve.TabStop = false;
            GbCurve.Text = "Select Curve";
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
            TxtPubKey.Size = new Size(335, 181);
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
            TxtComponents.BorderStyle = BorderStyle.None;
            TxtComponents.Location = new Point(692, 28);
            TxtComponents.Multiline = true;
            TxtComponents.Name = "TxtComponents";
            TxtComponents.ScrollBars = ScrollBars.Vertical;
            TxtComponents.Size = new Size(429, 649);
            TxtComponents.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(692, 12);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 9;
            label3.Text = "Components";
            // 
            // GbAlgo
            // 
            GbAlgo.Controls.Add(CbAlgo);
            GbAlgo.Location = new Point(466, 12);
            GbAlgo.Name = "GbAlgo";
            GbAlgo.Size = new Size(221, 61);
            GbAlgo.TabIndex = 4;
            GbAlgo.TabStop = false;
            GbAlgo.Text = "Select Algorithm";
            // 
            // CbAlgo
            // 
            CbAlgo.DropDownStyle = ComboBoxStyle.DropDownList;
            CbAlgo.FormattingEnabled = true;
            CbAlgo.Items.AddRange(new object[] { "None", "ECDSA", "ECDH" });
            CbAlgo.Location = new Point(6, 22);
            CbAlgo.Name = "CbAlgo";
            CbAlgo.Size = new Size(209, 23);
            CbAlgo.TabIndex = 1;
            CbAlgo.SelectedIndexChanged += CbAlgo_SelectedIndexChanged;
            // 
            // BtnSign
            // 
            BtnSign.Location = new Point(573, 123);
            BtnSign.Name = "BtnSign";
            BtnSign.Size = new Size(96, 23);
            BtnSign.TabIndex = 8;
            BtnSign.Text = "Signature";
            BtnSign.UseVisualStyleBackColor = true;
            BtnSign.Click += BtnSign_Click;
            // 
            // BtnVerify
            // 
            BtnVerify.Location = new Point(573, 229);
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
            TxtMessage.ScrollBars = ScrollBars.Vertical;
            TxtMessage.Size = new Size(662, 77);
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
            GbDigSign.Controls.Add(label6);
            GbDigSign.Controls.Add(label5);
            GbDigSign.Controls.Add(TxtS);
            GbDigSign.Controls.Add(TxtR);
            GbDigSign.Controls.Add(TxtMessage);
            GbDigSign.Controls.Add(label4);
            GbDigSign.Controls.Add(BtnSign);
            GbDigSign.Controls.Add(BtnVerify);
            GbDigSign.Location = new Point(12, 322);
            GbDigSign.Name = "GbDigSign";
            GbDigSign.Size = new Size(674, 266);
            GbDigSign.TabIndex = 14;
            GbDigSign.TabStop = false;
            GbDigSign.Text = "Digital Signature";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(340, 156);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 17;
            label6.Text = "s";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 156);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 16;
            label5.Text = "R";
            // 
            // TxtS
            // 
            TxtS.Location = new Point(340, 174);
            TxtS.Multiline = true;
            TxtS.Name = "TxtS";
            TxtS.Size = new Size(328, 46);
            TxtS.TabIndex = 15;
            // 
            // TxtR
            // 
            TxtR.Location = new Point(6, 174);
            TxtR.Multiline = true;
            TxtR.Name = "TxtR";
            TxtR.Size = new Size(328, 46);
            TxtR.TabIndex = 14;
            // 
            // GbHash
            // 
            GbHash.Controls.Add(CbHash);
            GbHash.Location = new Point(239, 12);
            GbHash.Name = "GbHash";
            GbHash.Size = new Size(221, 61);
            GbHash.TabIndex = 5;
            GbHash.TabStop = false;
            GbHash.Text = "Select Hash";
            // 
            // CbHash
            // 
            CbHash.DropDownStyle = ComboBoxStyle.DropDownList;
            CbHash.FormattingEnabled = true;
            CbHash.Items.AddRange(new object[] { "MD5", "SHA1", "SHA256", "SHA384", "SHA512" });
            CbHash.Location = new Point(6, 22);
            CbHash.Name = "CbHash";
            CbHash.Size = new Size(209, 23);
            CbHash.TabIndex = 1;
            // 
            // GbSharedKey
            // 
            GbSharedKey.Controls.Add(BtnGenerateSharedKey);
            GbSharedKey.Controls.Add(TxtSharedKey);
            GbSharedKey.Location = new Point(12, 594);
            GbSharedKey.Name = "GbSharedKey";
            GbSharedKey.Size = new Size(674, 115);
            GbSharedKey.TabIndex = 15;
            GbSharedKey.TabStop = false;
            GbSharedKey.Text = "Shared Key";
            // 
            // BtnGenerateSharedKey
            // 
            BtnGenerateSharedKey.Location = new Point(536, 78);
            BtnGenerateSharedKey.Name = "BtnGenerateSharedKey";
            BtnGenerateSharedKey.Size = new Size(132, 23);
            BtnGenerateSharedKey.TabIndex = 8;
            BtnGenerateSharedKey.Text = "Generate Shared Key";
            BtnGenerateSharedKey.UseVisualStyleBackColor = true;
            BtnGenerateSharedKey.Click += BtnGenerateSharedKey_Click;
            // 
            // TxtSharedKey
            // 
            TxtSharedKey.Location = new Point(6, 23);
            TxtSharedKey.Multiline = true;
            TxtSharedKey.Name = "TxtSharedKey";
            TxtSharedKey.Size = new Size(662, 46);
            TxtSharedKey.TabIndex = 7;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(1046, 686);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(75, 23);
            BtnClear.TabIndex = 16;
            BtnClear.Text = "Clear Log";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // EllipticCurveCryptography
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 721);
            Controls.Add(BtnClear);
            Controls.Add(GbSharedKey);
            Controls.Add(GbHash);
            Controls.Add(GbDigSign);
            Controls.Add(GbAlgo);
            Controls.Add(label3);
            Controls.Add(TxtComponents);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtPubKey);
            Controls.Add(TxtPrivKey);
            Controls.Add(GbCurve);
            Controls.Add(BtnGenerate);
            Name = "EllipticCurveCryptography";
            Text = "EllipticCurveCryptography";
            Load += EllipticCurveCryptography_Load;
            GbCurve.ResumeLayout(false);
            GbAlgo.ResumeLayout(false);
            GbDigSign.ResumeLayout(false);
            GbDigSign.PerformLayout();
            GbHash.ResumeLayout(false);
            GbSharedKey.ResumeLayout(false);
            GbSharedKey.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CbCurve;
        private Button BtnGenerate;
        private GroupBox GbCurve;
        private TextBox TxtPrivKey;
        private TextBox TxtPubKey;
        private Label label1;
        private Label label2;
        private TextBox TxtComponents;
        private Label label3;
        private GroupBox GbAlgo;
        private ComboBox CbAlgo;
        private Button BtnSign;
        private Button BtnVerify;
        private TextBox TxtMessage;
        private Label label4;
        private GroupBox GbDigSign;
        private GroupBox GbHash;
        private ComboBox CbHash;
        private Label label6;
        private Label label5;
        private TextBox TxtS;
        private TextBox TxtR;
        private GroupBox GbSharedKey;
        private Button BtnGenerateSharedKey;
        private TextBox TxtSharedKey;
        private Button BtnClear;
    }
}
