using System;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using System.IO;
using System.Runtime.InteropServices;
using AForge.Controls;

namespace Detector
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            this.ValidateDection();
            this.btnDetect.Enabled = false;
        }



        private static MotionDetector _motionDetector;
        private static float _motionAlarmLevel = 0.01f;
        private static bool _hasMotion;
        private static int _volgnr;
        private static string _path;
        VideoSourcePlayer videoSourcePlayer;
        private delegate void UpdateStatusDelegate();

        public void ValidateDection()
        {
            _path = Path.GetTempPath();

            Console.WriteLine("Motion Detector");

            Console.WriteLine("Detects motion in the integrated laptop webcam");

            Console.WriteLine("Threshold level: " + _motionAlarmLevel);

            _motionDetector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionAreaHighlighting());

            if (new FilterInfoCollection(FilterCategory.VideoInputDevice).Count > 0)
            {


                var videoDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice)[0];
                var videoCaptureDevice = new VideoCaptureDevice(videoDevice.MonikerString);
                videoSourcePlayer = new VideoSourcePlayer();
                videoSourcePlayer.NewFrame += VideoSourcePlayer_NewFrame;
                videoSourcePlayer.VideoSource = new AsyncVideoSource(videoCaptureDevice);
                videoSourcePlayer.Start();
            }
        }

        private  void VideoSourcePlayer_NewFrame(object sender, ref System.Drawing.Bitmap image)
        {
            var motionLevel = _motionDetector.ProcessFrame(image);

            if (motionLevel > _motionAlarmLevel)
            {
                if (_hasMotion) return;

                this.Invoke(new UpdateStatusDelegate(this.UpdateLabel));



                _volgnr++;
                _hasMotion = true;

                PowerHelper.ForceSystemAwake();
                PowerHelper.ResetSystemDefault();
            }
            else
            {
                if (_hasMotion)
                {
                    Console.WriteLine(DateTime.Now + ": Motion stopped. Motion level: " + motionLevel);
                }
                _hasMotion = false;
            }
        }

        public void UpdateLabel()
        {
           
            this.lblMotionTimeValue.Text = DateTime.Now.ToString("HH:mm");

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer.Stop();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            videoSourcePlayer.Stop();
            this.btnDetect.Enabled = true;
        }
    }

    public class PowerHelper
    {
        public static void ForceSystemAwake()
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS |
                                                  NativeMethods.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                                                  NativeMethods.EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                                                  NativeMethods.EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
        }

        public static void ResetSystemDefault()
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS);
        }
    }

    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001

            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
    }

}
