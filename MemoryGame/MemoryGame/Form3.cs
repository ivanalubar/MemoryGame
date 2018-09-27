using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MemoryGame.Properties;

namespace MemoryGame
{
    public partial class Form3 : Form
    {
        public bool rezultat;
        public bool _allowClick = true;
        private PictureBox _firstGuess;
        private readonly Random _random = new Random();
        private readonly Timer _clickTimer = new Timer();
        int ticks = 50;
        readonly Timer timer = new Timer { Interval = 1000 };
        public Form3()
        {
            InitializeComponent();
            SetRandomImages();
            HideImages();
            StartGameTimer();
            _clickTimer.Interval = 1000;
            _clickTimer.Tick += _clickTimer_Tick;
        }
        private PictureBox[] PictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }
        private static IEnumerable<Image> Images
        {
            get
            {
                return new Image[]
                {
                    Resources.img1,
                    Resources.img2,
                    Resources.img3,
                    Resources.img4,
                    Resources.img5,
                    Resources.img6,
                    Resources.img7,
                    Resources.img8
                        
                };
            }

        }
        private void StartGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                ticks--;
                if (ticks == -1)
                {
                    timer.Stop();
                    MessageBox.Show("Times up.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rezultat = false;
                    ResetImages();
                    timer.Stop();
                    this.Close();
                    
                }
                var time = TimeSpan.FromSeconds(ticks);
                label1.Text = "00:" + time.ToString("ss");
            };
        }
        private void ResetImages()
        {
            foreach (var pic in PictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
            HideImages();
            SetRandomImages();
            ticks = 50;
            timer.Start();
        }
        private void HideImages()
        {
            foreach (var pic in PictureBoxes)
            {
                pic.Image = Resources.img0;
            }
        }
        private PictureBox GetFreeSlot()
        {
            int br;
            do
            {
                br = _random.Next(0, PictureBoxes.Count());
            }
            while (PictureBoxes[br].Tag != null);
            return PictureBoxes[br];
        }
        private void SetRandomImages()
        {
            foreach (var Image in Images)
            {
                GetFreeSlot().Tag = Image;
                GetFreeSlot().Tag = Image;
            }
        }


        private void _clickTimer_Tick(object sender, EventArgs e)
        {
            HideImages();
            _allowClick = true;
            _clickTimer.Stop();
        }


        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            if (!_allowClick) return;
            var pic = (PictureBox)sender;
            if (_firstGuess == null)
            {
                _firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;
            if (pic.Image == _firstGuess.Image && pic != _firstGuess)
            {
                pic.Visible = _firstGuess.Visible = false;
                {
                    _firstGuess = pic;
                }
                HideImages();
            }
            else
            {
                _allowClick = false;
                _clickTimer.Start();
            }
            _firstGuess = null;
            if (PictureBoxes.Any(p => p.Visible))
                return;
            MessageBox.Show("You won!!!!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            rezultat = true;
            timer.Stop();
            this.Close();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

    }
}