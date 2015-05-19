using System;
using System.Windows.Forms;
using Ozeki.Media.MediaHandlers;
using Ozeki.VoIP;
using Ozeki.VoIP.SDK;

namespace MyFirstSoftPhone_03
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

        public MainForm()
        {
            InitializeComponent();
        }


        private void InitializeSoftPhone()
        {
            try
            {
                softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
                InvokeGUIThread(() => { lb_Log.Items.Add("Softphone created!"); });

                softPhone.IncomingCall += new EventHandler<VoIPEventArgs<IPhoneCall>>(softPhone_inComingCall);

                SIPAccount sa = new SIPAccount(true, "1000", "1000", "1000", "1000", "192.168.115.103", 5060);
                InvokeGUIThread(() => { lb_Log.Items.Add("SIP account created!"); });

                phoneLine = softPhone.CreatePhoneLine(sa);
                phoneLine.RegistrationStateChanged += phoneLine_PhoneLineInformation;
                InvokeGUIThread(() => { lb_Log.Items.Add("Phoneline created."); });
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
                InvokeGUIThread(() => { lb_Log.Items.Add("Local IP error!"); });
            }
        }


        private void StartDevices()
        {
            if (microphone != null)
            {
                microphone.Start();
                InvokeGUIThread(() => { lb_Log.Items.Add("Microphone Started."); });
            }

            if (speaker != null)
            {
                speaker.Start();
                InvokeGUIThread(() => { lb_Log.Items.Add("Speaker Started."); });
            }
        }


        private void StopDevices()
        {
            if (microphone != null)
            {
                microphone.Stop();
                InvokeGUIThread(() => { lb_Log.Items.Add("Microphone Stopped."); });
            }

            if (speaker != null)
            {
                speaker.Stop();
                InvokeGUIThread(() => { lb_Log.Items.Add("Speaker Stopped."); });
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
            InvokeGUIThread(() => { lb_Log.Items.Add("Incoming call from: " + e.Item.DialInfo.ToString()); tb_Display.Text = "Ringing (" + e.Item.DialInfo.Dialed + ")"; });

            reDialNumber = e.Item.DialInfo.Dialed;
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
                        lb_Log.Items.Add("Registration succeeded - Online");
                    }
                    else
                    {
                        lb_Log.Items.Add("Not registered - Offline: " + phoneLineInformation.ToString());
                    }

                });
        }


        private void call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            InvokeGUIThread(() => { lb_Log.Items.Add("Callstate changed." + e.State.ToString()); tb_Display.Text = e.State.ToString(); });

            if (e.State == CallState.Answered)
            {
                btn_Hold.Enabled = true;
                btn_Hold.Text = "Hold";

                StartDevices();

                mediaReceiver.AttachToCall(call);
                mediaSender.AttachToCall(call);


                InvokeGUIThread(() => { lb_Log.Items.Add("Call started."); });
            }

            if (e.State == CallState.InCall)
            {
                btn_Hold.Enabled = true;
                btn_Hold.Text = "Hold";
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

                InvokeGUIThread(() => { lb_Log.Items.Add("Call ended."); tb_Display.Text = string.Empty; });
                
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


        private void buttonKeyPadButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (call != null) { return; }

            if (btn == null) return;

            tb_Display.Text += btn.Text.Trim();
        }


        private void btn_PickUp_Click(object sender, EventArgs e)
        {
            if (inComingCall)
            {
                inComingCall = false;
                call.Answer();

                InvokeGUIThread(() => { lb_Log.Items.Add("Call accepted."); });
                return;
            }

            if (call != null)
            {
                return;
            }

            if (phoneLineInformation != RegState.RegistrationSucceeded)
            {
                InvokeGUIThread(() => { lb_Log.Items.Add("Registratin Failed!"); tb_Display.Text = "OFFLINE";});
                return;
            }

            reDialNumber = tb_Display.Text;
            call = softPhone.CreateCallObject(phoneLine, tb_Display.Text);
            WireUpCallEvents();
            call.Start();   
        }

        private void btn_HangUp_Click(object sender, EventArgs e)
        {
            if (call != null)
            {
                if (inComingCall && call.CallState == CallState.Ringing)
                {
                    call.Reject();
                    InvokeGUIThread(() => { lb_Log.Items.Add("Call rejected."); });
                }
                else
                {
                    call.HangUp();
                    inComingCall = false;
                    InvokeGUIThread(() => { lb_Log.Items.Add("Call hanged up."); });
                }

                call = null;

            }

            tb_Display.Text = string.Empty;
        }

        private void btn_Redial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(reDialNumber))
                return;

            if (call != null)
                return;

            call = softPhone.CreateCallObject(phoneLine, reDialNumber);
            WireUpCallEvents();
            call.Start();
        }

        private void btn_Hold_Click(object sender, EventArgs e)
        {
            if (call == null)
                return;

            if (!localHeld)
            {
                call.Hold();
                btn_Hold.Text = "Unhold";
                localHeld = true;
            }
            else
            {
                btn_Hold.Text = "Hold";
                localHeld = false;
                call.Unhold();
            }
        }

        private void btn_Transfer_Click(object sender, EventArgs e)
        {
            string transferTo = "1001";

            if (call == null)
                return;

            if (string.IsNullOrEmpty(transferTo))
                return;

            call.BlindTransfer(transferTo);
            lb_Log.Items.Add("Transfering to:" + transferTo);
        }
    }
}
