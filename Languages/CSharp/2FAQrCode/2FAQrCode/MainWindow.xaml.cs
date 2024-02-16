using OtpNet;
using QRCoder;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _2FAQrCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly QRCodeGenerator qrGenerator = new QRCodeGenerator();
        const int DEFAULT_STEP = 30;

        public MainWindow()
        {
            InitializeComponent();

            Label.Focus();
            Label.Text = "one";
            Issuer.Text = "two";
            Secret.Text = Base32Encoding.ToString(KeyGeneration.GenerateRandomKey(20));
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Label.Text != "" && Issuer.Text != "" && Secret.Text != "")
            {
                var qrCodeUri = $"otpauth://totp/{Uri.EscapeDataString(Label.Text)}?secret={Secret.Text}&issuer={Uri.EscapeDataString(Issuer.Text)}";

                using (var qrCodeData = qrGenerator.CreateQrCode(qrCodeUri, QRCodeGenerator.ECCLevel.Q))
                {
                    using (var qrCode = new QRCode(qrCodeData))
                    {
                        var qrCodeImage = qrCode.GetGraphic(20);

                        using (var memory = new MemoryStream())
                        {
                            qrCodeImage.Save(memory, ImageFormat.Bmp);
                            memory.Position = 0;
                            var bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.StreamSource = memory;
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.EndInit();
                            QrCode.Source = bitmapImage;
                        }
                    }
                }
                QrCode.ToolTip = qrCodeUri;
            }
        }

        private void VerifyCode_Click(object sender, RoutedEventArgs e)
        {
            var totp = new Totp(Base32Encoding.ToBytes(Secret.Text));

            var isValidTotpCode = totp.VerifyTotp(Code.Text, out long timeStepMatched, new VerificationWindow(previous: 1, future: 1));

            var now = DateTime.UtcNow;
            var step = Math.Floor((now - new DateTime(1970, 1, 1)).TotalSeconds / DEFAULT_STEP);

            TotpCode1.Content = $"{totp.ComputeTotp(now.AddSeconds(-DEFAULT_STEP))}{Environment.NewLine}({step - 1})";
            TotpCode2.Content = $"{totp.ComputeTotp(now)}{Environment.NewLine}({step})";
            TotpCode3.Content = $"{totp.ComputeTotp(now.AddSeconds(DEFAULT_STEP))}{Environment.NewLine}({step + 1})";

            foreach (var label in new Label[] { TotpCode1, TotpCode2, TotpCode3 })
                label.BorderBrush = Brushes.White;

            if (isValidTotpCode)
            {
                if (Code.Text == TotpCode1.Content.ToString())
                    TotpCode1.BorderBrush = Brushes.Green;
                else if (Code.Text == TotpCode2.Content.ToString())
                    TotpCode2.BorderBrush = Brushes.Green;
                else if (Code.Text == TotpCode3.Content.ToString())
                    TotpCode3.BorderBrush = Brushes.Green;

                MessageBox.Show($"Valid TOTP Code (step: {timeStepMatched})!");
            }
            else
                MessageBox.Show("Invalid TOTP Code");
        }
    }
}
