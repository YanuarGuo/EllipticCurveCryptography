namespace EllipticCurveCryptography
{
    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using Org.BouncyCastle.Asn1.GM;
    using Org.BouncyCastle.Asn1.Sec;
    using Org.BouncyCastle.Asn1.X9;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Agreement;
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
            public string? PrivateKey { get; set; }
            public string? PublicKeyX { get; set; }
            public string? PublicKeyY { get; set; }
        }

        private KeyPairs? latestKeyPairs;

        public class Signature
        {
            public BigInteger? R { get; set; }
            public BigInteger? s { get; set; }
        }

        private Signature? latestSignature;

        private void EllipticCurveCryptography_Load(object sender, EventArgs e)
        {
            GbDigSign.Enabled = false;
            GbHash.Enabled = false;
            GbAlgo.Enabled = false;
            CbAlgo.SelectedIndex = 0;
        }

        public static byte[] ComputeHash(string algorithm, byte[] data)
        {
            IDigest digest = DigestUtilities.GetDigest(algorithm);
            digest.Reset();
            digest.BlockUpdate(data, 0, data.Length);
            byte[] result = new byte[digest.GetDigestSize()];
            digest.DoFinal(result, 0);
            return result;
        }

        public static KeyPairs GenerateKeyPairDSA(string selectedCurve)
        {
            X9ECParameters curve = CustomNamedCurves.GetByName(selectedCurve);
            ECDomainParameters domainParams = new ECDomainParameters(
                curve.Curve,
                curve.G,
                curve.N,
                curve.H
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

        public static AsymmetricCipherKeyPair GenerateKeyPairDH(string curveName)
        {
            X9ECParameters curve = CustomNamedCurves.GetByName(curveName);
            ECDomainParameters domainParams = new ECDomainParameters(
                curve.Curve,
                curve.G,
                curve.N,
                curve.H
            );

            var keyGenParams = new ECKeyGenerationParameters(domainParams, new SecureRandom());
            var generator = new ECKeyPairGenerator();
            generator.Init(keyGenParams);

            return generator.GenerateKeyPair();
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

        public static BigInteger CalculateSharedSecret(
            AsymmetricKeyParameter privateKey,
            AsymmetricKeyParameter publicKey
        )
        {
            if (!(privateKey is ECPrivateKeyParameters))
                throw new ArgumentException("Private key invalid");
            if (!(publicKey is ECPublicKeyParameters))
                throw new ArgumentException("Public key invalid");

            var agreement = new ECDHBasicAgreement();
            agreement.Init(privateKey);
            return agreement.CalculateAgreement(publicKey);
        }

        public (BigInteger R, BigInteger s) SignData(
            string curveName,
            byte[] message,
            BigInteger privateKey
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
            ECPrivateKeyParameters privateKeyParams = new ECPrivateKeyParameters(
                privateKey,
                domainParams
            );

            var signer = new ECDsaSigner();
            signer.Init(true, privateKeyParams);

            string hashAlgorithm = CbHash.SelectedItem?.ToString() ?? "SHA-256";
            byte[] hash = ComputeHash(hashAlgorithm, message);

            var signature = signer.GenerateSignature(hash);
            return (R: signature[0], s: signature[1]);
        }

        public bool VerifySignature(string curveName, byte[] message, BigInteger R, BigInteger s)
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

            string hashAlgorithm = CbHash.SelectedItem?.ToString() ?? "SHA-256";
            byte[] hash = ComputeHash(hashAlgorithm, message);
            return signer.VerifySignature(hash, R, s);
        }

        public string GenerateSharedkey(string selectedCurve)
        {
            AsymmetricCipherKeyPair keyPairA = GenerateKeyPairDH(selectedCurve);
            AsymmetricCipherKeyPair keyPairB = GenerateKeyPairDH(selectedCurve);

            BigInteger sharedSecretA = CalculateSharedSecret(keyPairA.Private, keyPairB.Public);
            BigInteger sharedSecretB = CalculateSharedSecret(keyPairB.Private, keyPairA.Public);

            TxtPrivKey.Clear();
            TxtPubKey.Clear();

            TxtPrivKey.AppendText(
                $"Private Key 1: {((ECPrivateKeyParameters)keyPairA.Private).D.ToString(16)}\r\n"
                    + $"Private Key 2: {((ECPrivateKeyParameters)keyPairB.Private).D.ToString(16)}\r\n"
            );

            TxtPubKey.AppendText(
                $"Public Key X1: {((ECPublicKeyParameters)keyPairA.Public).Q.AffineXCoord.ToBigInteger().ToString(16)}\r\n"
                    + $"Public Key Y1: {((ECPublicKeyParameters)keyPairA.Public).Q.AffineYCoord.ToBigInteger().ToString(16)}\r\n\r\n"
                    + $"Public Key X2: {((ECPublicKeyParameters)keyPairB.Public).Q.AffineXCoord.ToBigInteger().ToString(16)}\r\n"
                    + $"Public Key Y2: {((ECPublicKeyParameters)keyPairB.Public).Q.AffineYCoord.ToBigInteger().ToString(16)}\r\n"
            );

            TxtComponents.AppendText(
                $"Shared Secret A: {sharedSecretA.ToString(16)}\r\n\r\n"
                    + $"Shared Secret B: {sharedSecretB.ToString(16)}\r\n"
            );

            if (sharedSecretA.Equals(sharedSecretB))
            {
                string sharedKey = sharedSecretA.ToString(16);
                TxtComponents.AppendText("\r\nShared Key Valid" + Environment.NewLine);
                return sharedKey;
            }
            else
            {
                throw new Exception("Shared keys do not match");
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            string? selectedCurve = CbCurve.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCurve))
            {
                MessageBox.Show("Selected curve is invalid.");
                return;
            }

            try
            {
                TxtPrivKey.Clear();
                TxtPubKey.Clear();

                KeyPairs keyPairResult = GenerateKeyPairDSA(selectedCurve);
                string componentResult = GenerateComponent(selectedCurve);

                latestKeyPairs = new KeyPairs()
                {
                    PublicKeyX = keyPairResult.PublicKeyX,
                    PublicKeyY = keyPairResult.PublicKeyY,
                    PrivateKey = keyPairResult.PrivateKey,
                };

                TxtComponents.AppendText(componentResult + Environment.NewLine);
                TxtPrivKey.Text = $"Private Key (d): {keyPairResult.PrivateKey}";
                TxtPubKey.Text =
                    $"Public Key X: {keyPairResult.PublicKeyX}\r\nPublic Key Y: {keyPairResult.PublicKeyY}";

                GbHash.Enabled = true;
                GbAlgo.Enabled = true;
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
                if (TxtMessage.Text == string.Empty)
                {
                    MessageBox.Show("Message is empty");
                    return;
                }
                string message = TxtMessage.Text;
                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                string? selectedCurve = CbCurve.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedCurve))
                {
                    MessageBox.Show("Selected curve is invalid");
                    return;
                }
                if (CbHash.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a hash algorithm");
                    return;
                }

                var (R, s) = SignData(
                    selectedCurve,
                    messageBytes,
                    new BigInteger(TxtPrivKey.Text.Split(':')[1].Trim(), 16)
                );

                latestSignature = new Signature() { R = R, s = s };

                TxtComponents.AppendText(
                    $"Signature (R,s):\r\n\r\nR: {latestSignature.R?.ToString(16)}\r\n\r\ns: {latestSignature.s?.ToString(16)}"
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
                    || latestSignature.s == null
                )
                {
                    MessageBox.Show("Signature is not found");
                    return;
                }

                if (CbHash.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a hash algorithm");
                    return;
                }

                string message = TxtMessage.Text;
                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                string? selectedCurve = CbCurve.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedCurve))
                {
                    MessageBox.Show("Selected curve is invalid");
                    return;
                }

                string rHex = TxtR.Text.Trim();
                string sHex = TxtS.Text.Trim();

                BigInteger R = new BigInteger(rHex, 16);
                BigInteger s = new BigInteger(sHex, 16);

                bool verified = VerifySignature(selectedCurve, messageBytes, R, s);
                if (verified)
                {
                    TxtComponents.AppendText("\r\nSignature is valid\r\n" + Environment.NewLine);
                }
                else
                {
                    TxtComponents.AppendText("\r\nSignature is invalid\r\n" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying: {ex.Message}");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                TxtComponents.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing: {ex.Message}");
            }
        }

        private void CbAlgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbAlgo.SelectedItem?.ToString() == "None")
            {
                GbDigSign.Enabled = false;
            }
            else if (CbAlgo.SelectedItem?.ToString() == "ECDSA")
            {
                GbDigSign.Enabled = true;
                GbSharedKey.Enabled = false;
            }
            else if (CbAlgo.SelectedItem?.ToString() == "ECDH")
            {
                GbDigSign.Enabled = false;
                GbSharedKey.Enabled = true;
            }
            else
            {
                GbDigSign.Enabled = false;
            }
        }

        private void BtnGenerateSharedKey_Click(object sender, EventArgs e)
        {
            try
            {
                string? selectedCurve = CbCurve.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedCurve))
                {
                    MessageBox.Show("Selected curve is invalid.");
                    return;
                }
                string sharedKey = GenerateSharedkey(selectedCurve);
                TxtSharedKey.Text = $"Shared Key: {sharedKey}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating shared key: {ex.Message}");
            }
        }
    }
}
