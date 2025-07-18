namespace EllipticCurveCryptography
{
    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using Org.BouncyCastle.Asn1.GM;
    using Org.BouncyCastle.Asn1.Sec;
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.EC;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto.Signers;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Math.EC;
    using Org.BouncyCastle.Security;
    using ECPoint = Org.BouncyCastle.Math.EC.ECPoint;

    public partial class EllipticCurveCryptography : Form
    {
        public EllipticCurveCryptography()
        {
            InitializeComponent();
        }

        public class KeyPairs
        {
            public string? PrivateKey { get; set; } = string.Empty;
            public string? PublicKeyX { get; set; } = string.Empty;
            public string? PublicKeyY { get; set; } = string.Empty;
        }

        private KeyPairs? latestKeyPairs;

        public class Signature
        {
            public BigInteger? R { get; set; }
            public BigInteger? S { get; set; }
        }

        private Signature? latestSignature;

        private void EllipticCurveCryptography_Load(object sender, EventArgs e)
        {
            GbDigSign.Enabled = false;
        }

        public static KeyPairs GenerateKeyPair(string selectedCurve)
        {
            X9ECParameters curve = CustomNamedCurves.GetByName(selectedCurve);
            ECDomainParameters domainParams = new ECDomainParameters(
                curve.Curve, //selected curve
                curve.G, // generator point
                curve.N, // order of the curve
                curve.H // cofactor
            );

            var secureRandom = new SecureRandom();
            var keyGenParams = new ECKeyGenerationParameters(domainParams, secureRandom);
            var keyGenerator = new ECKeyPairGenerator();
            keyGenerator.Init(keyGenParams);

            AsymmetricCipherKeyPair keyPair = keyGenerator.GenerateKeyPair();

            ECPrivateKeyParameters privateKey = (ECPrivateKeyParameters)keyPair.Private;
            ECPublicKeyParameters publicKey = (ECPublicKeyParameters)keyPair.Public;
            ECPoint q = publicKey.Q.Normalize();

            return new KeyPairs
            {
                PrivateKey = privateKey.D.ToString(16),
                PublicKeyX = q.AffineXCoord.ToBigInteger().ToString(16),
                PublicKeyY = q.AffineYCoord.ToBigInteger().ToString(16),
            };
        }

        public static string GenerateComponent(string selectedCurve)
        {
            X9ECParameters curve = CustomNamedCurves.GetByName(selectedCurve);
            if (curve == null)
            {
                return "Curve not found.";
            }

            string components =
                $"Curve: \r\n{curve.Curve}\r\n\r\n"
                + $"Generator (G): \r\n{curve.G}\r\n\r\n"
                + $"Order (N): \r\n{curve.N}\r\n\r\n"
                + $"Cofactor (H): \r\n{curve.H}\r\n";

            return components;
        }

        public static (BigInteger r, BigInteger s) SignData(
            string curveName,
            byte[] message,
            BigInteger privateKeyD
        )
        {
            X9ECParameters curve = CustomNamedCurves.GetByName(curveName);
            if (curve == null)
                throw new ArgumentException("Curve isn't found");

            ECDomainParameters domainParams = new ECDomainParameters(
                curve.Curve,
                curve.G,
                curve.N,
                curve.H
            );
            ECPrivateKeyParameters privateKey = new ECPrivateKeyParameters(
                privateKeyD,
                domainParams
            );

            var signer = new ECDsaSigner();
            signer.Init(true, privateKey);

            var hash = message;
            var signature = signer.GenerateSignature(hash);

            return (r: signature[0], s: signature[1]);
        }

        public bool VerifySignature(string curveName, byte[] message)
        {
            X9ECParameters curve = CustomNamedCurves.GetByName(curveName);
            if (curve == null)
                throw new ArgumentException("Curve isn't found");

            ECDomainParameters domainParams = new ECDomainParameters(
                curve.Curve,
                curve.G,
                curve.N,
                curve.H
            );

            ECPoint q;
            if (
                !string.IsNullOrEmpty(latestKeyPairs?.PublicKeyX)
                && !string.IsNullOrEmpty(latestKeyPairs?.PublicKeyY)
            )
            {
                BigInteger x = new BigInteger(latestKeyPairs.PublicKeyX, 16);
                BigInteger y = new BigInteger(latestKeyPairs.PublicKeyY, 16);
                q = curve.Curve.CreatePoint(x, y);
            }
            else
            {
                throw new ArgumentException("Public keys not found");
            }

            ECPublicKeyParameters publicKey = new ECPublicKeyParameters(q, domainParams);

            var signer = new ECDsaSigner();
            signer.Init(false, publicKey);

            var hash = message;

            return signer.VerifySignature(hash, latestSignature?.R, latestSignature?.S);
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (CbCurve.SelectedItem == null)
            {
                MessageBox.Show("Please select an algorithm.");
                return;
            }
            string? selectedCurve = CbCurve.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCurve))
            {
                MessageBox.Show("Selected curve is invalid.");
                return;
            }

            try
            {
                KeyPairs keyPairResult = GenerateKeyPair(selectedCurve);
                string componentResult = GenerateComponent(selectedCurve);

                TxtComponents.AppendText(componentResult + Environment.NewLine);
                TxtPrivKey.Text = $"Private Key (d): {keyPairResult.PrivateKey}";
                TxtPubKey.Text =
                    $"Public Key X: {keyPairResult.PublicKeyX}\r\nPublic Key Y: {keyPairResult.PublicKeyY}";

                GbDigSign.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating key pair: {ex.Message}");
                return;
            }
        }

        private void BtnSign_Click(object sender, EventArgs e)
        {
            try
            {
                string message = TxtMessage.Text;
                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                string? selectedCurve = CbCurve.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedCurve))
                {
                    MessageBox.Show("Selected curve is invalid.");
                    return;
                }

                var (r, s) = SignData(
                    selectedCurve,
                    messageBytes,
                    new BigInteger(TxtPrivKey.Text.Split(':')[1].Trim(), 16)
                );

                latestSignature = new Signature() { R = r, S = s };

                TxtComponents.AppendText(
                    $"r: {latestSignature.R?.ToString(16)}\r\n\r\ns: {latestSignature.S?.ToString(16)}"
                        + Environment.NewLine
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error signing: {ex.Message}");
                return;
            }
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    latestSignature == null
                    || latestSignature.R == null
                    || latestSignature.S == null
                )
                {
                    MessageBox.Show("Signature belum ada, lakukan sign terlebih dahulu!");
                    return;
                }

                string message = TxtMessage.Text;
                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                string? selectedCurve = CbCurve.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedCurve))
                {
                    MessageBox.Show("Selected curve is invalid.");
                    return;
                }

                VerifySignature(selectedCurve, messageBytes);

                TxtComponents.AppendText(
                    $"r: {latestSignature.R?.ToString(16)}\r\n\r\ns: {latestSignature.S?.ToString(16)}"
                        + Environment.NewLine
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying: {ex.Message}");
            }
        }
    }
}
