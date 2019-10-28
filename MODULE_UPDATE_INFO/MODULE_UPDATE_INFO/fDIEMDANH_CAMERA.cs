using AForge.Video;
using AForge.Video.DirectShow;
using DTODLL;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using static MODULE_UPDATE_INFO.fTHONGTIN;

namespace MODULE_UPDATE_INFO
{
    //public partial class fDIEMDANH_CAMERA : Form
    //{

    //    public fDIEMDANH_CAMERA()
    //    {
    //        InitializeComponent();
    //        loadData();
    //    }
    //    public static resultHash rHash;
    //    public static void mothodHasing(resultHash sender)
    //    {
    //        rHash = sender;
    //    }
    //    public fDIEMDANH_CAMERA(resultHash sender)
    //    {
    //        InitializeComponent();
    //        loadData();
    //    }
    //    #region Properties

    //    private FilterInfoCollection capturedev;
    //    private VideoCaptureDevice finalframe;

    //    #endregion

    //    #region Methods
    //    private void loadData()
    //    {
    //        capturedev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
    //        foreach (FilterInfo item in capturedev)
    //        {
    //            cbbCamera.Items.Add(item.Name);
    //        }


    //    }
    //    #endregion

    //    private void fDIEMDANH_CAMERA_Load(object sender, EventArgs e)
    //    {
    //        cbbMaDaiHoi.DataSource = BUS.daiHoiBUS.Instance.getDsDH();
    //        cbbMaDaiHoi.DisplayMember = "MASODH";
    //        //cbbMaDaiHoi.ValueMember = "Value";
    //        cbbMaDaiHoi.DropDownStyle = ComboBoxStyle.DropDownList;
    //    }

    //    private void cbbMaDaiHoi_SelectedValueChanged(object sender, EventArgs e)
    //    {
    //        if (cbbMaDaiHoi.SelectedText.ToString() != String.Empty)
    //        {
    //            var data = BUS.daiHoiBUS.Instance.getDAIHOI(new Guid(cbbMaDaiHoi.SelectedText.ToString()));
    //            if (data != null)
    //            {
    //                tbChuDe.Text = data.CHUDE;
    //                tbNhiemKy.Text = data.NHIEMKY;
    //                if (String.Empty == data.NGAY.ToString())
    //                {
    //                    data.NGAY = null;
    //                }
    //                else
    //                {

    //                    DateTime temp = (DateTime)data.NGAY;
    //                    data.NGAY = new DateTime(temp.Year, temp.Month, temp.Day);
    //                }
    //                tbNgay.Text = data.NGAY.ToString();
    //            }
    //        }

    //    }

    //    Guid idDH;

    //    private void btnStart_Click(object sender, EventArgs e)
    //    {
    //        if (finalframe != null && finalframe.IsRunning)
    //        {
    //            finalframe.Stop();
    //        }

    //        finalframe = new VideoCaptureDevice(capturedev[cbbCamera.SelectedIndex].MonikerString);
    //        finalframe.NewFrame += NewFrame;
    //        finalframe.Start();
    //        timer1.Enabled = true;
    //        timer1.Start();
    //    }

    //    private void NewFrame(object sender, NewFrameEventArgs eventArgs)
    //    {
    //        Bitmap video = (Bitmap)eventArgs.Frame.Clone();
    //        ptbCamera.Image = video;
    //    }

    //    private void timer1_Tick(object sender, EventArgs e)
    //    {

    //        BarcodeReader reader = new BarcodeReader
    //        {
    //            AutoRotate = true,
    //            TryInverted = true,
    //            Options = new ZXing.Common.DecodingOptions
    //            {
    //                TryHarder = true
    //            }
    //        };

    //        Result result;
    //        if (ptbCamera.Image != null)
    //        {
    //            try
    //            {
    //                result = reader.Decode((Bitmap)ptbCamera.Image);
    //                string decoded = result.ToString().Trim();
    //                if (decoded != null)
    //                {
    //                    string hashing = decoded;
    //                    DOANVIEN dv = BUS.doanVienBUS.Instance.getByHashing(hashing);
    //                    if (dv != null)
    //                    {
    //                        tbCMND.Text = dv.CMND;
    //                        tbFirstName.Text = dv.HOLOT;
    //                        tbLastName.Text = dv.TEN;
    //                        cbIsMale.Checked = cbIsMale.Checked = dv.NAM == false ? false : true;
    //                        cbbDomicile.Text = dv.NGUYENQUAN;
    //                        cbbNation.Text = dv.DANTOC;
    //                        cbbReligion.Text = dv.TONGIAO;
    //                        tbSpecialize.Text = dv.CMNV;
    //                        tbPolitic.Text = dv.LLCT;
    //                        DateTime dateDoan = dv.NGAYVAODOAN == null ? DateTime.Now : dv.NGAYVAODOAN.Value;
    //                        tbUnionistIn.Text = dateDoan.ToString("dd/M/yyyy");
    //                        DateTime dateDang = dv.NGAYVAODANG == null ? DateTime.Now : dv.NGAYVAODANG.Value;
    //                        tbLeaguerIn.Text = dateDang.ToString("dd/M/yyyy");
    //                        displayImage(ptbAvatar, dv.CMND);
    //                        BUS.chiTietDaiHoiBUS.Instance.setStatus(dv.MASODV, idDH);
    //                        rHash(dv.HASHING);
    //                        timer1.Stop();
    //                        timer2.Start();
    //                    }
    //                }
    //            }
    //            catch (Exception)
    //            {
    //            }
    //        }

    //    }
    //    private void displayImage(PictureBox pictureBox, string cmnd)
    //    {
    //        try
    //        {
    //            string f = Application.StartupPath + "\\" + "Images\\" + cmnd + ".jpg";
    //            Image File = Image.FromFile(f);
    //            pictureBox.BackgroundImage = File;
    //        }
    //        catch (Exception)
    //        {
    //        }

    //    }
    //    private void fDIEMDANH_CAMERA_FormClosing(object sender, FormClosingEventArgs e)
    //    {
    //        if (finalframe != null)
    //        {
    //            if (finalframe.IsRunning == true)
    //            {
    //                finalframe.Stop();
    //            }
    //        }
    //    }
    //    private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
    //    {
    //        try
    //        {
    //            ptbCamera.Image = (Bitmap)eventArgs.Frame.Clone();

    //        }
    //        catch (Exception)
    //        {
    //        }
    //    }

    //    private void timer2_Tick(object sender, EventArgs e)
    //    {
    //        timer1.Start();
    //        timer2.Stop();
    //    }

    //    private void cbbMaDaiHoi_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)sender;
    //        int selectedIndex = cmb.SelectedIndex;
    //        DAIHOI selectedValue = (DAIHOI)cmb.SelectedValue;

    //        idDH = selectedValue.MASODH;
    //        if (selectedValue.MASODH.ToString() != String.Empty)
    //        {
    //            var data = BUS.daiHoiBUS.Instance.getDAIHOI(selectedValue.MASODH);
    //            if (data != null)
    //            {
    //                tbChuDe.Text = data.CHUDE;
    //                tbNhiemKy.Text = data.NHIEMKY;
    //                if (String.Empty == data.NGAY.ToString())
    //                {
    //                    data.NGAY = null;
    //                }
    //                else
    //                {

    //                    DateTime temp = (DateTime)data.NGAY;
    //                    data.NGAY = new DateTime(temp.Year, temp.Month, temp.Day);
    //                }

    //                tbNgay.Text = data.NGAY.ToString();
    //            }
    //        }
    //    }

    //    private void cbbCamera_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        finalframe = new VideoCaptureDevice(capturedev[cbbCamera.SelectedIndex].MonikerString);
    //        finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
    //        finalframe.Start();
    //        timer1.Enabled = true;
    //        timer1.Start();
    //    }
    //}
    public partial class fDIEMDANH_CAMERA : Form
    {
        private static fDIEMDANH_CAMERA instance;
        public fDIEMDANH_CAMERA()
        {
            InitializeComponent();
            loadData();
        }
        public static resultHash rHash;
        public static void mothodHasing(resultHash sender)
        {
            rHash = sender;
        }
        public fDIEMDANH_CAMERA(resultHash sender)
        {
            InitializeComponent();
            loadData();
        }
        #region Properties

        private FilterInfoCollection capturedev;
        private VideoCaptureDevice finalframe;

        #endregion

        #region Methods
        private void loadData()
        {
            capturedev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in capturedev)
            {
                cbbCamera.Items.Add(item.Name);
            }


        }
        #endregion
        public static fDIEMDANH_CAMERA Instance
        {
            get
            {
                if (instance == null) return instance = new fDIEMDANH_CAMERA();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private void fDIEMDANH_CAMERA_Load(object sender, EventArgs e)
        {
            cbbMaDaiHoi.DataSource = BUS.daiHoiBUS.Instance.getDsDH();
            cbbMaDaiHoi.DisplayMember = "MASODH";
            //cbbMaDaiHoi.ValueMember = "Value";
            cbbMaDaiHoi.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbbMaDaiHoi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbMaDaiHoi.SelectedText.ToString() != String.Empty)
            {
                var data = BUS.daiHoiBUS.Instance.getDAIHOI(new Guid(cbbMaDaiHoi.SelectedText.ToString()));
                if (data != null)
                {
                    tbChuDe.Text = data.CHUDE;
                    tbNhiemKy.Text = data.NHIEMKY;
                    if (String.Empty == data.NGAY.ToString())
                    {
                        data.NGAY = null;
                    }
                    else
                    {

                        DateTime temp = (DateTime)data.NGAY;
                        data.NGAY = new DateTime(temp.Year, temp.Month, temp.Day);
                    }
                    tbNgay.Text = data.NGAY.ToString();
                }
            }

        }

        Guid idDH;
        private void cbbMaDaiHoi_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            DAIHOI selectedValue = (DAIHOI)cmb.SelectedValue;

            idDH = selectedValue.MASODH;
            if (selectedValue.MASODH.ToString() != String.Empty)
            {
                var data = BUS.daiHoiBUS.Instance.getDAIHOI(selectedValue.MASODH);
                if (data != null)
                {
                    tbChuDe.Text = data.CHUDE;
                    tbNhiemKy.Text = data.NHIEMKY;
                    if (String.Empty == data.NGAY.ToString())
                    {
                        data.NGAY = null;
                    }
                    else
                    {

                        DateTime temp = (DateTime)data.NGAY;
                        data.NGAY = new DateTime(temp.Year, temp.Month, temp.Day);
                    }
                    tbNgay.Text = data.NGAY.ToString();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (finalframe != null && finalframe.IsRunning)
            {
                finalframe.Stop();
            }

            finalframe = new VideoCaptureDevice(capturedev[cbbCamera.SelectedIndex].MonikerString);
            finalframe.NewFrame += NewFrame;
            finalframe.Start();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            ptbCamera.Image = video;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true
                }
            };

            Result result;
            if (ptbCamera.Image != null)
            {
                try
                {
                    result = reader.Decode((Bitmap)ptbCamera.Image);
                    string decoded = result.ToString().Trim();
                    if (decoded != null)
                    {
                        string hashing = decoded;
                        DOANVIEN dv = BUS.doanVienBUS.Instance.getByHashing(hashing);
                        if (dv != null)
                        {
                            tbCMND.Text = dv.CMND;
                            tbFirstName.Text = dv.HOLOT;
                            tbLastName.Text = dv.TEN;
                            cbIsMale.Checked = cbIsMale.Checked = dv.NAM == false ? false : true;
                            cbbDomicile.Text = dv.NGUYENQUAN;
                            cbbNation.Text = dv.DANTOC;
                            cbbReligion.Text = dv.TONGIAO;
                            tbSpecialize.Text = dv.CMNV;
                            tbPolitic.Text = dv.LLCT;
                            DateTime dateDoan = dv.NGAYVAODOAN == null ? DateTime.Now : dv.NGAYVAODOAN.Value;
                            tbUnionistIn.Text = dateDoan.ToString("dd/M/yyyy");
                            DateTime dateDang = dv.NGAYVAODANG == null ? DateTime.Now : dv.NGAYVAODANG.Value;
                            tbLeaguerIn.Text = dateDang.ToString("dd/M/yyyy");
                            displayImage(ptbAvatar, dv.CMND);
                            BUS.chiTietDaiHoiBUS.Instance.setStatus(dv.MASODV, idDH);
                            rHash(dv.HASHING);
                            timer1.Stop();
                            timer2.Start();
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

        }
        private void displayImage(PictureBox pictureBox, string cmnd)
        {
            try
            {
                string f = Application.StartupPath + "\\" + "Images\\" + cmnd + ".jpg";
                Image File = Image.FromFile(f);
                pictureBox.BackgroundImage = File;
            }
            catch (Exception)
            {
            }

        }
        private void fDIEMDANH_CAMERA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalframe != null)
            {
                if (finalframe.IsRunning == true)
                {
                    finalframe.Stop();
                }
            }
        }
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                ptbCamera.Image = (Bitmap)eventArgs.Frame.Clone();

            }
            catch (Exception)
            {
            }
        }
        private void cbbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalframe = new VideoCaptureDevice(capturedev[cbbCamera.SelectedIndex].MonikerString);
            finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            finalframe.Start();
            timer1.Enabled = true;
            timer1.Start();
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true
                }
            };

            Result result;
            if (ptbCamera.Image != null)
            {
                try
                {
                    result = reader.Decode((Bitmap)ptbCamera.Image);
                    string decoded = result.ToString().Trim();
                    if (decoded != null)
                    {
                        string hashing = decoded;
                        DOANVIEN dv = BUS.doanVienBUS.Instance.getByHashing(hashing);
                        if (dv != null)
                        {
                            tbCMND.Text = dv.CMND;
                            tbFirstName.Text = dv.HOLOT;
                            tbLastName.Text = dv.TEN;
                            cbIsMale.Checked = cbIsMale.Checked = dv.NAM == false ? false : true;
                            cbbDomicile.Text = dv.NGUYENQUAN;
                            cbbNation.Text = dv.DANTOC;
                            cbbReligion.Text = dv.TONGIAO;
                            tbSpecialize.Text = dv.CMNV;
                            tbPolitic.Text = dv.LLCT;
                            DateTime dateDoan = dv.NGAYVAODOAN == null ? DateTime.Now : dv.NGAYVAODOAN.Value;
                            tbUnionistIn.Text = dateDoan.ToString("dd/M/yyyy");
                            DateTime dateDang = dv.NGAYVAODANG == null ? DateTime.Now : dv.NGAYVAODANG.Value;
                            tbLeaguerIn.Text = dateDang.ToString("dd/M/yyyy");
                            displayImage(ptbAvatar, dv.CMND);
                            BUS.chiTietDaiHoiBUS.Instance.setStatus(dv.MASODV, idDH);
                            rHash(dv.HASHING);
                            timer1.Stop();
                            timer2.Start();
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Stop();
        }
    }

}
