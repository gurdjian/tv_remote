using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SamsungRemoteLibrary;
using SamsungRemoteLibrary.Interfaces;
using SamsungRemoteLibrary.TvConnector;

namespace tv_remote
{
    public partial class Form1 : Form
    {
        class YourSettings : IRemoteControlIdentification, ITvSettings
        {
            // Change these properties 
            public string RemoteControlIp { get { return "192.168.1.65"; } }
            public string TvIp { get { return "192.168.1.68"; } }
            public int TvPortNumber { get { return 55000; } }
            public string RemoteControlMac { get { return "0C-89-10-CD-43-28"; } }
            public string AppName { get { return "Lenovo X1 remote"; } }

            public override string ToString()
            {
                return string.Format(
                        "Application name:{4}\nRemote control IP: {0}\nRemote control mac: {1}\nTv address: {2}:{3}\n",
                        RemoteControlIp, RemoteControlMac, TvIp, TvPortNumber, AppName);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        static void Sending(string send_key)
        {
            try
            {
                var yourSettings = new YourSettings();
                
                TcpClient client = new TcpClient();
                var result = client.BeginConnect(yourSettings.TvIp, yourSettings.TvPortNumber, null, null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

                if (!success)
                {
                    throw new Exception("Failed to connect.");
                }
                // we have connected
                client.EndConnect(result);

                if (client.Connected)
                {
                    var remote = new RemoteControl(new SamsungTvConnection(yourSettings, new SamsungBytesBuilder(yourSettings)));
                    remote.Push(send_key);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        } 

        private void buttonVolDown_Click(object sender, EventArgs e)
        {
            Sending("KEY_VOLDOWN");
        }

        private void buttonMute_Click(object sender, EventArgs e)
        {
            IVolumeButton v = new SamsungRemoteLibrary.Buttons.Volume.Mute();
            Sending(v.Code);
        }

        private void buttonVolUp_Click(object sender, EventArgs e)
        {
            IVolumeButton v = new SamsungRemoteLibrary.Buttons.Volume.VolumeUp();
            Sending(v.Code);
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            IPowerButton v = new SamsungRemoteLibrary.Buttons.Misc.PowerOff();
            Sending(v.Code);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.One();
            Sending(v.Code);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Two();
            Sending(v.Code);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Three();
            Sending(v.Code);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Four();
            Sending(v.Code);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Five();
            Sending(v.Code);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Six();
            Sending(v.Code);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Seven();
            Sending(v.Code);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Eight();
            Sending(v.Code);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Nine();
            Sending(v.Code);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Number.Zero();
            Sending(v.Code);
        }
        private void buttonSource_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Channel.Source();
            Sending(v.Code);
        }

        private void buttonChannelUp_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Channel.ChannelUp();
            Sending(v.Code);
        }

        private void buttonChannelDown_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Channel.ChannelDown();
            Sending(v.Code);
        }

        private void buttonChList_Click(object sender, EventArgs e)
        {
            IChannelButton v = new SamsungRemoteLibrary.Buttons.Channel.ChannelList();
            Sending(v.Code);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            INavigationButton v = new SamsungRemoteLibrary.Buttons.Navigation.Enter();
            Sending(v.Code);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            INavigationButton v = new SamsungRemoteLibrary.Buttons.Navigation.Exit();
            Sending(v.Code);
        }

        private void buttonNavigateDown_Click(object sender, EventArgs e)
        {
            INavigationButton v = new SamsungRemoteLibrary.Buttons.Navigation.NavigateDown();
            Sending(v.Code);
        }

        private void buttonNavigateLeft_Click(object sender, EventArgs e)
        {
            INavigationButton v = new SamsungRemoteLibrary.Buttons.Navigation.NavigateLeft();
            Sending(v.Code);
        }

        private void buttonNavigateUp_Click(object sender, EventArgs e)
        {
            //INavigationButton v = new SamsungRemoteLibrary.Buttons.Navigation.();
            Sending("KEY_UP");
        }

        private void buttonNavigateRight_Click(object sender, EventArgs e)
        {
            INavigationButton v = new SamsungRemoteLibrary.Buttons.Navigation.NavigateRight();
            Sending(v.Code);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            INavigationButton v = new SamsungRemoteLibrary.Buttons.Navigation.Return();
            Sending(v.Code);
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            IRecordingButton v = new SamsungRemoteLibrary.Buttons.Recording.Rewind();
            Sending(v.Code);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            IRecordingButton v = new SamsungRemoteLibrary.Buttons.Recording.Pause();
            Sending(v.Code);
        }

        private void buttonFF_Click(object sender, EventArgs e)
        {
            IRecordingButton v = new SamsungRemoteLibrary.Buttons.Recording.Forward();
            Sending(v.Code);
        }

        private void buttonRec_Click(object sender, EventArgs e)
        {
            IRecordingButton v = new SamsungRemoteLibrary.Buttons.Recording.Record();
            Sending(v.Code);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            IRecordingButton v = new SamsungRemoteLibrary.Buttons.Recording.Play();
            Sending(v.Code);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            IRecordingButton v = new SamsungRemoteLibrary.Buttons.Recording.Stop();
            Sending(v.Code);
        }

        private void buttonSmart_Click(object sender, EventArgs e)
        {
            IMenuButton v = new SamsungRemoteLibrary.Buttons.Menu.SmartHub();
            Sending(v.Code);
        }

        private void buttonTools_Click(object sender, EventArgs e)
        {
            IMenuButton v = new SamsungRemoteLibrary.Buttons.Menu.Tools();
            Sending(v.Code);
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            IMenuButton v = new SamsungRemoteLibrary.Buttons.Menu.Menu();
            Sending(v.Code);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            IMenuButton v = new SamsungRemoteLibrary.Buttons.Menu.Info();
            Sending(v.Code);
        }
    }
}
