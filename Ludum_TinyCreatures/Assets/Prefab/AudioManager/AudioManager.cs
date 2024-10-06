using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClip
{
    //List of AudioClip "Id"
    Music,
    Key,
    Wolf,
    Sheep,
    Door,
    Push,
    TitleMusic
}

public enum Sources
{
    //List of all AudioSource in your scene
    Music,
    Level,
    Title,
    Push
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
            case(Sources.Music):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Music)
                    {
                        foreach (AudioData data in AudioDatas)
                        {
                            if (data.Id == id)
                            {
                                sourceData.Source.Stop();
                                sourceData.Source.PlayOneShot(data.Clip);
                            }
                        }
                    }
                }
                break;
            case(Sources.Level):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Level)
                    {
                        foreach (AudioData data in AudioDatas)
                        {
                            if (data.Id == id)
                            {
                                sourceData.Source.Stop();
                                sourceData.Source.PlayOneShot(data.Clip);
                            }
                        }
                    }
                }
                break;
            case(Sources.Title):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Title)
                    {
                        foreach (AudioData data in AudioDatas)
                        {
                            if (data.Id == id)
                            {
                                sourceData.Source.Stop();
                                sourceData.Source.PlayOneShot(data.Clip);
                            }
                        }
                    }
                }
                break;
            case(Sources.Push):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Push)
                    {
                        foreach (AudioData data in AudioDatas)
                        {
                            if (data.Id == id)
                            {
                                sourceData.Source.Stop();
                                sourceData.Source.PlayOneShot(data.Clip);
                            }
                        }
                    }
                }
                break;
        }
    }

    public void StopSound(Sources sourcesID)
    {
        switch (sourcesID)
        {
            case(Sources.Music):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Music)
                    {
                        sourceData.Source.Stop();
                    }
                }
                break;
            case(Sources.Level):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Level)
                    {
                        sourceData.Source.Stop();
                    }
                }
                break;
            case(Sources.Title):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Title)
                    {
                        sourceData.Source.Stop();
                    }
                }
                break;
            case(Sources.Push):
                foreach (AudioSourceData sourceData in AudioSourcesDatas)
                {
                    if (sourceData.Id == Sources.Push)
                    {
                        sourceData.Source.Stop();
                    }
                }
                break;
        }
    }
}
