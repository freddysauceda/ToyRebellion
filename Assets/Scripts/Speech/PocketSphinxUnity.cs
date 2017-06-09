using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PocketSphinxUnity : MonoBehaviour {
        static float lastRecognized;
        static bool running;
        static bool initialized;

        public enum SearchModel
        {
            jsgf,
            kws
        }
        public enum AudioDevice
        {
            File,
            Mic
        }
    
        static AudioDevice audioDevice = AudioDevice.Mic;
        static string hmm;
        static string lm;
        static string dict;
        static string jsgf;
        static string kws;

        public void Awake()
        {
            string path = "C:/Users/ahawker/Downloads/pocketsphinx-master/pocketsphinx-master/"; // Application.dataPath
            hmm = path + "model/en-us/en-us";
            lm = path + "model/en-us/en-us.lm.bin";
            dict = path + "model/en-us/cmudict-en-us.dict";
            jsgf = path + "/Resources/UnitySphinx/model/en-us/animals.gram";
            kws = path + "/Resources/UnitySphinx/model/en-us/keyphrase.list";
        print(SpeechDllWrapper.Test());

            Init(audioDevice, hmm, lm, dict, jsgf, kws);
        }

        public void Init(AudioDevice audioDevice, string hmm, string lm, string dict, string jsgf, string kws)
        {
            int audioInt = 0;

            StringBuilder hmmSB = new StringBuilder(hmm.Length);
            StringBuilder lmSB = new StringBuilder(lm.Length);
            StringBuilder dictSB = new StringBuilder(dict.Length);
            StringBuilder jsgfSB = new StringBuilder(jsgf.Length);
            StringBuilder kwsSB = new StringBuilder(kws.Length);

            hmmSB.Append(hmm);
            lmSB.Append(lm);
            dictSB.Append(dict);
            jsgfSB.Append(jsgf);
            kwsSB.Append(kws);

        print("TEST");
            int errcode = SpeechDllWrapper.Init(audioInt, 0,
                hmmSB, lmSB, dictSB, jsgfSB, kwsSB);
            if (errcode != 0)
            {
                Debug.LogError("Pocketsphinx recognizer object failed to initialize.");
                if (errcode == -20)
                    Debug.LogError("Config failed to initialize properly.");
                else if (errcode == -21)
                    Debug.LogError("Check that all your dictionary, grammar, and acoustic model paths are correct.");
                else if (errcode == -31)
                    Debug.LogError("Failed to open mic device.");
                else if (errcode == -32)
                    Debug.LogError("Failed to start recording through mic.");
                else if (errcode == -33)
                    Debug.LogError("Failed to start utterance.");
                else if (errcode == -61)
                    Debug.LogWarning("Pocketsphinx recognizer object was not initialized properly. Failed to set kws file.");
                else if (errcode == -62)
                    Debug.LogWarning("Failed to set kws file. Ensure the path is valid.");
                else if (errcode == -71)
                    Debug.LogWarning("Pocketsphinx recognizer object was not initialized properly. Failed to set jsgf file.");
                else if (errcode == -72)
                    Debug.LogWarning("Failed to set jsgf file. Ensure the path is valid.");
                else
                    Debug.LogWarning("Some other problem happened");
                return;
            }
            initialized = true;
            //StartCoroutine("Recognize");
        }

        IEnumerator Recognize()
        {
            while (true)
            {
                yield return null;
                if (running && Time.time - lastRecognized >= 0.1f)
                {
                    lastRecognized = Time.time;
                    //SpeechDllWrapper.Read_Mic();
                    //int len = SpeechDllWrapper.GetLength();
                    //print(len);    
                //int score = SpeechDllWrapper.GetScore();
                    //print("DATA: " + " _ " + score);
                    //SpeechDllWrapper.Dequeue_String(sb, len);
                }
            }
        }

        /*
        public static string DequeueString()
        {
            int strlen = SphinxPlugin.Request_Buffer_Length();
            // Not sure what the buffer size difference is between
            // char * and StringBuilder, so just add 10 more bytes
            strlen += 10;
            StringBuilder str = new StringBuilder(strlen);
            if (strlen > 0)
            {
                SphinxPlugin.Dequeue_String(str, strlen);
            }

            return str.ToString();
        }*/
}
