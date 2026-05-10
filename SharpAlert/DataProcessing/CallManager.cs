using NAudio.Wave;
using SIPSorcery.Media;
using SIPSorcery.SIP;
using SIPSorcery.SIP.App;
using System;
using System.IO;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using static SharpAlertPluginBase.AlertContents;
using static SharpAlert.ProgramWorker.NotificationWorker;
using SharpAlert.ProgramWorker;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SharpAlert.DataProcessing
{
    internal static class CallManager
    {
        private static readonly List<AlertInfo> IncomingAlerts = [];

        public static void AlertCheckerLoop()
        {
            while (true)
            {
                lock (IncomingAlerts)
                {
                    if (IncomingAlerts.Count != 0)
                    {
                        AlertInfo alert = IncomingAlerts.First();
                        IncomingAlerts.Remove(alert);
                        MakeAlertCall(alert);
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public static void AddNewAlertToCallList(AlertInfo info)
        {
            lock (IncomingAlerts) IncomingAlerts.Add(info);
        }
        
        private static void MakeAlertCall(AlertInfo info)
        {
            try
            {
                string callTo = QuickSettings.Instance.PhoneIP;
                if (string.IsNullOrWhiteSpace(callTo)) return;
                //string callTo = "0@192.168.1.35";
                //string callTo = File.ReadAllLines($"{AssemblyDirectory}\\call.txt")[0];

                Notify.ShowNotification("Placing call now.",
                    "Alert Call",
                    ToolTipIcon.Info);

                using var sipTransport = new SIPTransport();
                using var userAgent = new SIPUserAgent(sipTransport, null);
                //var winAudioEndPoint = new WindowsAudioEndPoint(new AudioEncoder());
                //winAudioEndPoint.ToMediaEndPoints()
                using var voipMediaSession = new VoIPMediaSession();
                bool callResult = userAgent.Call(callTo, null, null, voipMediaSession, 12).Result;
                voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.None);

                if (callResult)
                {
                    Notify.ShowNotification("Call answered by phone.",
                        "Alert Call",
                        ToolTipIcon.Info);

                    static MemoryStream SpeakToMe(string speak)
                    {
                        SpeechSynthesizer ss = new();
                        using MemoryStream ms = new();

                        ss.SetOutputToWaveStream(ms);
                        ss.Speak(speak);
                        ms.Position = 0;

                        using WaveFileReader reader = new(ms);
                        var outFormat = new WaveFormat(16000, reader.WaveFormat.BitsPerSample, reader.WaveFormat.Channels);
                        using var resampler = new MediaFoundationResampler(reader, outFormat)
                        {
                            ResamplerQuality = 60
                        };

                        var rs = new MemoryStream();
                        WaveFileWriter.WriteWavFileToStream(rs, resampler);
                        rs.Position = 0;

                        ss.Dispose();

                        return rs;
                    }

                    object WaitObject = new();

                    userAgent.OnDtmfTone += (a, b) =>
                    {
                        switch (a)
                        {
                            case 1:
                                lock (WaitObject)
                                {
                                    voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.SineWave);
                                    Thread.Sleep(500);
                                    voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.None);
                                    voipMediaSession.AudioExtrasSource.SendAudioFromStream(
                                        SpeakToMe(info.AlertBodyText),
                                        SIPSorceryMedia.Abstractions.AudioSamplingRatesEnum.Rate16KHz
                                    ).Wait();
                                }
                                break;
                        }

                        userAgent.Hangup();
                    };

                    voipMediaSession.AudioExtrasSource.SetSource(AudioSourcesEnum.None);
                    voipMediaSession.AudioExtrasSource.SendAudioFromStream(
                        SpeakToMe($"EMERGENCY ALERT. {info.AlertEventType}. Press 1 to hear the alert text. Hang up or do nothing to ignore."),
                        SIPSorceryMedia.Abstractions.AudioSamplingRatesEnum.Rate16KHz
                    ).Wait();


                    Thread.Sleep(5000);
                    lock (WaitObject)
                    {
                        Thread.Sleep(500);
                        userAgent.Hangup();
                    }

                    Notify.ShowNotification("Call ended.",
                        "Alert Call",
                        ToolTipIcon.Info);
                }
                else
                {
                    Notify.ShowNotification("Call rejected or failed.",
                        "Alert Call",
                        ToolTipIcon.Info);
                }

                userAgent.Close();
                sipTransport.Shutdown();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Notify.ShowNotification($"Call error. {ex.Message}",
                    "Alert Call",
                    ToolTipIcon.Info);
            }
        }
    }
}
