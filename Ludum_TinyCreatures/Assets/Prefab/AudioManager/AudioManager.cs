using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClip
{
    //List of AudioClip "Id"
    Exemple
}

public enum Sources
{
    //List of all AudioSource in your scene
    Exemple
}

public class AudioManager : MonoBehaviour
{
    [Serializable]
    private struct AudioData
    {
        public SoundClip Id;
        public AudioClip Clip;
    }
    [Serializable]
    private struct AudioSourceData
    {
        public Sources Id;
        public AudioSource Source;
    }
    
    private static AudioManager instance;
    public static AudioManager Instance {  get { return instance; } }
    
    
    [SerializeField] private List<AudioData> AudioDatas = new List<AudioData>();
    [SerializeField] private List<AudioSourceData> AudioSourcesDatas = new List<AudioSourceData>();
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public void PlaySound(SoundClip id, Sources sourceID)
    {
        //Use AudioManager.Instance.PlaySound(SoundClip ID, Sources ID) where you want to start a sound;
        //If you add a Source copy/paste a case in the switch and replace "Exemple" by your Sources ID;
        switch (sourceID)
        {
            case(Sources.Exemple):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Exemple)
                    {
                        foreach (AudioData data in AudioDatas)
                        {
                            sourceData.Source.PlayOneShot(data.Clip);
                        }
                    }
                }
                break;
        }
    }
}
