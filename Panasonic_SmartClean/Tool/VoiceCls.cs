using System;
using System.Media;
using System.Windows.Forms;
using System.IO;

namespace Panasonic_SmartClean
{
    public class VoiceCls
    {

        public static void Speak(string strFileName)
        {
            try
            {
                String strFile = Application.StartupPath + "\\Wav\\" + strFileName + ".wav";
                if (!File.Exists(strFile))
                {
                    return;
                }
                //SoundPlayer soundplayer = new SoundPlayer();
                //soundplayer.SoundLocation = strFile;
                //soundplayer.PlayLooping();
                SpeechLib.SpVoiceClass pp = new SpeechLib.SpVoiceClass();
                SpeechLib.SpFileStreamClass spFs = new SpeechLib.SpFileStreamClass();
                spFs.Open(strFile, SpeechLib.SpeechStreamFileMode.SSFMOpenForRead, true);
                SpeechLib.ISpeechBaseStream Istream = spFs as SpeechLib.ISpeechBaseStream;
                pp.SpeakStream(Istream, SpeechLib.SpeechVoiceSpeakFlags.SVSFIsFilename);
                spFs.Close();
            }
            catch { }
        }
        
    }
}
