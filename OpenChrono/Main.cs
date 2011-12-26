using System;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

namespace OpenChrono
{
    public partial class Main : Form
    {
        public const string Version = "0.1 Beta";
        private const int NumSegments = 6;
        //public char[] CharArray = new char[NumSegments];

        public Main()
        {
            //
            // Splash code adapted from here:
            // http://www.developingfor.net/forms-20/quick-and-easy-splash-screen.html
            //
            const int minSplashTime = 3;
            var now = DateTime.Now.TimeOfDay;
            var killTime = now + new TimeSpan(0, 0, 0, minSplashTime);
            var splash = new Splash();
            while (DateTime.Now.TimeOfDay < killTime)
            {
                splash.Show();
                splash.Update();
            }
            InitializeComponent();
            //InitializeSettings();
            InitializeHW();
            splash.Close();
        }

        /// <summary>
        /// Start the Microphone Monitor.
        /// </summary>
        void InitializeHW()
        {
            //
            // Microphone-Read code based on NAudio based article by Mark Heath 
            // here: http://channel9.msdn.com/coding4fun/articles/NET-Voice-Recorder
            //
            var waveInDevices = WaveIn.DeviceCount;
            var devices = new string[waveInDevices];
            for (var waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++){
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                devices[waveInDevice] = "Device " + waveInDevice + ": " + deviceInfo.ProductName + ", " + deviceInfo.Channels + " channels";
            }
            var selectedDevice = 0;
            var waveIn = new WaveIn();
            waveIn.DeviceNumber = selectedDevice;
            waveIn.DataAvailable += WaveInDataAvailable;
            var sampleRate = 96000; // 96 kHz
            var channels = 1; // mono
            waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
            waveIn.StartRecording();
        }

        /// <summary>
        /// Convert the Raw audio bytestream into usable Float
        /// </summary>
        /// <param name="sender">Where the data came from</param>
        /// <param name="e">Data from microhone</param>
        void WaveInDataAvailable(object sender, WaveInEventArgs e)
        {
            for (var index = 0; index < e.BytesRecorded; index += 2)
            {
                var sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                var sample32 = sample / 32768f;

                ProcessSample(sample32);
            }
        }

        /// <summary>
        /// Do something useful with the Mic Spikes
        /// </summary>
        /// <param name="sample32">A useable mic level value</param>
        void ProcessSample(float sample32)
        {
            if (MicValue_Debug != null)
            {
                if (sample32 > 0.9)
                {
                    MicValue_Debug.Text = sample32.ToString();
                    ActiveForm.Update();
                }
            }
        }
    }
}
