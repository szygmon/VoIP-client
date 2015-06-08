using System;
using System.Windows.Forms;
using Ozeki.Media.MediaHandlers;
using Ozeki.VoIP;
using Ozeki.VoIP.SDK;
using System.Collections.Generic;

namespace VoIPclient
{
    public partial class MainForm : Form
    {

        private ISoftPhone softPhone;
        private IPhoneLine phoneLine;
        private RegState phoneLineInformation;
        private IPhoneCall call;
        private Microphone microphone = Microphone.GetDefaultDevice();
        private Speaker speaker = Speaker.GetDefaultDevice();
        MediaConnector connector = new MediaConnector();
        PhoneCallAudioSender mediaSender = new PhoneCallAudioSender();
        PhoneCallAudioReceiver mediaReceiver = new PhoneCallAudioReceiver();

        private bool inComingCall;
        private string reDialNumber;
        private bool localHeld;
        private string username;
        private string pass;
        private string server;

        System.Media.SoundPlayer player;
        private LoginForm lf;

        public MainForm(string server, string username, string pass, LoginForm lf)
        {
            InitializeComponent();
            this.username = username;
            this.pass = pass;
            this.server = server;
            this.lf = lf;
            player = new System.Media.SoundPlayer(@"dzwonek.wav");
        }

        private void InitializeSoftPhone()
        {
            try
            {
                softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
                //InvokeGUIThread(() => { lb_Log.Items.Add("Softphone created!"); });

                softPhone.IncomingCall += new EventHandler<VoIPEventArgs<IPhoneCall>>(softPhone_inComingCall);

                SIPAccount sa = new SIPAccount(true, username, username, username, pass, server, 5060);
                //InvokeGUIThread(() => { lb_Log.Items.Add("SIP account created!"); });

                phoneLine = softPhone.CreatePhoneLine(sa);
                phoneLine.RegistrationStateChanged += phoneLine_PhoneLineInformation;
                //InvokeGUIThread(() => { lb_Log.Items.Add("Phoneline created."); });
                softPhone.RegisterPhoneLine(phoneLine);

                tb_Display.Text = string.Empty;
                lbl_NumberToDial.Text = sa.RegisterName;

                inComingCall = false;
                reDialNumber = string.Empty;
                localHeld = false;

                ConnectMedia();
            }
            catch (Exception ex)
            {
                this.Hide();
                this.lf.setInfo("Błędne dane logowania!");
                this.lf.Show();
                /*InvokeGUIThread(() => { 
                    lb_Log.Items.Add("Local IP error!");
                    tb_Display.Text = "Błędne dane logowania - uruchom ponownie program";
                    
                });*/
            }
        }

        private void StartDevices()
        {
            if (microphone != null)
            {
                microphone.Start();
                //InvokeGUIThread(() => { lb_Log.Items.Add("Microphone Started."); });
            }

            if (speaker != null)
            {
                speaker.Start();
                //InvokeGUIThread(() => { lb_Log.Items.Add("Speaker Started."); });
            }
        }


        private void StopDevices()
        {
            if (microphone != null)
            {
                microphone.Stop();
                //InvokeGUIThread(() => { lb_Log.Items.Add("Microphone Stopped."); });
            }

            if (speaker != null)
            {
                speaker.Stop();
                //InvokeGUIThread(() => { lb_Log.Items.Add("Speaker Stopped."); });
            }
        }

        private void ConnectMedia()
        {
            if (microphone != null)
            {
                connector.Connect(microphone, mediaSender);
            }

            if (speaker != null)
            {
                connector.Connect(mediaReceiver, speaker);
            }
        }

        private void DisconnectMedia()
        {
            if (microphone != null)
            {
                connector.Disconnect(microphone, mediaSender);
            }

            if (speaker != null)
            {
                connector.Disconnect(mediaReceiver, speaker);
            }
        }

        private void InvokeGUIThread(Action action)
        {
            Invoke(action);
        }


        private void softPhone_inComingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
            InvokeGUIThread(() =>
            {
                tb_Display.Text = "Dzwoni " + e.Item.DialInfo.CallerDisplay.ToString();
                btn_PickUp.Text = "Odbierz";
                player.PlayLooping();
                //lb_Log.Items.Add(e.Item.DialInfo.SIPCallerID.ToString());
            });

            call = e.Item;
            WireUpCallEvents();
            inComingCall = true;
        }

        private void phoneLine_PhoneLineInformation(object sender, RegistrationStateChangedArgs e)
        {
            phoneLineInformation = e.State;

            InvokeGUIThread(() =>
                {
                    if (phoneLineInformation == RegState.RegistrationSucceeded)
                    {
                        //lb_Log.Items.Add("Registration succeeded - Online");
                        /** lista znajomych **/
                        System.Net.Sockets.TcpClient tcpclnt = new System.Net.Sockets.TcpClient();
                        tcpclnt.Connect(server, 8888);

                        System.Net.Sockets.NetworkStream nts = tcpclnt.GetStream();
                        System.IO.StreamReader strread = new System.IO.StreamReader(nts);
                        System.IO.StreamWriter strwrite = new System.IO.StreamWriter(nts);

                        strwrite.WriteLine(username + "@");
                        strwrite.Flush();

                        string output;
                        while (true)
                        {
                            output = strread.ReadLine();
                            if (output != null)
                                lbx_friends.Items.Add(output);
                            else
                            {
                                strwrite.Close();
                                strread.Close();
                                nts.Close();
                                tcpclnt.Close();
                                break;
                            }
                        }
                        /** koniec listy **/
                    }
                    else
                    {
                        //lb_Log.Items.Add("Not registered - Offline: " + phoneLineInformation.ToString());
                        if (phoneLineInformation.ToString() == "Error")
                        {
                            this.Hide();
                            this.lf.setInfo("Błędne dane!");
                            this.lf.Show();
                        }
                    }
                });
        }


        private void call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            InvokeGUIThread(() =>
            {
                //lb_Log.Items.Add("Callstate changed." + e.State.ToString());
            });

            if (e.State == CallState.Answered)
            {
                StartDevices();

                mediaReceiver.AttachToCall(call);
                mediaSender.AttachToCall(call);

                InvokeGUIThread(() =>
                {
                    //lb_Log.Items.Add("Call started.");
                    tb_Display.Text = "W trakcie połączenia...";
                    player.Stop();
                });

            }

            if (e.State == CallState.InCall)
            {
                StartDevices();
            }

            if (e.State.IsCallEnded() == true)
            {
                localHeld = false;

                StopDevices();

                mediaReceiver.Detach();
                mediaSender.Detach();

                WireDownCallEvents();

                call = null;

                InvokeGUIThread(() =>
                {
                    //lb_Log.Items.Add("Call ended.");
                    tb_Display.Text = "Połączenie zakończone";
                    btn_PickUp.Text = "Zadzwoń";
                });

                player.Stop();
                inComingCall = false;
            }

            if (e.State == CallState.LocalHeld)
            {
                StopDevices();
            }
        }

        private void WireUpCallEvents()
        {
            call.CallStateChanged += (call_CallStateChanged);
        }

        private void WireDownCallEvents()
        {
            call.CallStateChanged -= (call_CallStateChanged);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeSoftPhone();
        }

        private void btn_PickUp_Click(object sender, EventArgs e)
        {
            if (inComingCall)
            {
                inComingCall = false;
                call.Answer();

                InvokeGUIThread(() =>
                {
                    //lb_Log.Items.Add("Call accepted.");
                });
                return;
            }

            if (call != null)
            {
                return;
            }

            if (phoneLineInformation != RegState.RegistrationSucceeded)
            {
                InvokeGUIThread(() =>
                {
                    //lb_Log.Items.Add("Registratin Failed!");
                    tb_Display.Text = "Jesteś OFFLINE";
                });
                return;
            }

            if (tb_Display.Text == username)
            {
                InvokeGUIThread(() =>
                {
                    tb_Display.Text = "Nie możesz dzwonić do siebie!";
                });
                return;
            }

            reDialNumber = tb_Display.Text;
            call = softPhone.CreateCallObject(phoneLine, tb_Display.Text);
            WireUpCallEvents();
            call.Start();
            InvokeGUIThread(() =>
            {
                tb_Display.Text = "Dzwonię...";
            });
        }

        private void btn_HangUp_Click(object sender, EventArgs e)
        {
            if (call != null)
            {
                if (inComingCall && call.CallState == CallState.Ringing)
                {
                    call.Reject();
                    InvokeGUIThread(() =>
                    {
                        //lb_Log.Items.Add("Call rejected.");
                        player.Stop();
                    });
                }
                else
                {
                    call.HangUp();
                    inComingCall = false;
                    InvokeGUIThread(() =>
                    {
                        //lb_Log.Items.Add("Call hanged up.");
                        player.Stop();
                    });
                }

                call = null;

            }

            tb_Display.Text = string.Empty;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveFriendsList();
            Application.Exit();
        }


        private void btn_logout_Click(object sender, EventArgs e)
        {
            saveFriendsList();
            lf.Show();
            this.Hide();
        }

        private void tb_Display_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tb_Display_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_PickUp_Click(sender, e);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbx_friends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbx_friends.SelectedItems.Count != 0)
            {
                string curItem = lbx_friends.SelectedItem.ToString();
                tb_Display.Text = curItem;
            }
        }

        private void btn_addFriend_Click(object sender, EventArgs e)
        {
            int index = lbx_friends.FindString(tb_Display.Text);
            if (index == -1)
                lbx_friends.Items.Add(tb_Display.Text);
        }

        private void btn_remFriend_Click(object sender, EventArgs e)
        {
            while (lbx_friends.SelectedItems.Count != 0)
            {
                lbx_friends.Items.Remove(lbx_friends.SelectedItems[0]);
            }
        }
        private void saveFriendsList()
        {
            try
            {
                System.Net.Sockets.TcpClient tcpclnt = new System.Net.Sockets.TcpClient();
                tcpclnt.Connect(server, 8888);

                System.Net.Sockets.NetworkStream nts = tcpclnt.GetStream();
                System.IO.StreamReader strread = new System.IO.StreamReader(nts);
                System.IO.StreamWriter strwrite = new System.IO.StreamWriter(nts);

                List<string> lines = new List<string>();
                lines.Add("save@" + username);
                foreach (var item in lbx_friends.Items)
                {
                    lines.Add(item.ToString());
                }
                int ile = lines.Count;
                string[] text = new string[ile];
                for (int i = 0; i < ile; i++)
                {
                    text[i] = lines[i];
                }

                foreach (var s in text)
                {
                    strwrite.WriteLine(s);
                    strwrite.Flush();
                }
                strwrite.Close();
                strread.Close();
                nts.Close();
                tcpclnt.Close();
            }
            catch (Exception ee)
            {
                
            }
        }
    }
}
