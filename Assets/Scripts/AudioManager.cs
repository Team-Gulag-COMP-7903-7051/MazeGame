using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Audio[] _audioArray;
    public static AudioManager Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }

        foreach (Audio audio in _audioArray) {
            audio.Source = gameObject.AddComponent<AudioSource>();
            audio.Source.clip = audio.Clip;
            audio.Source.volume = audio.Volume;
        }
    }

    public void Play(string name) {
        Audio audio = GetAudio(name);
        audio.Source.Play();
    }

    public void Stop(string name) {
        Audio audio = GetAudio(name);
        audio.Source.Stop();
    }

    public bool IsPlaying(string name) {
        Audio audio = GetAudio(name);
        return audio.Source.isPlaying;
    }

    private Audio GetAudio(string name) {
        Audio audio = Array.Find(_audioArray, audio => audio.Name == name);

        if(audio == null) {
            throw new ArgumentException("GetAudio in AudioManager could not find \"" + name + "\"");
        }

        return audio;
    }
}
