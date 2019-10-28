using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODULE_UPDATE_INFO.Classes
{
    public class QRGenerator
    {

        private static QRGenerator instance;

        public static QRGenerator Instance
        {
            get
            {
                if (instance == null) return instance = new QRGenerator();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public void createQRCode(string code)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode cd = new QRCode(data);
            saveQR(cd.GetGraphic(5) as Image, code);
        }

        private void saveQR(Image image, string code)
        {
            image.Save(Application.StartupPath + "\\QRCode\\" + code + ".jpg");
        }
    }
}
