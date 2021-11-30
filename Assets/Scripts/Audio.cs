using UnityEngine;

[System.Serializable]
public class Audio {
    public string Name;
    public AudioClip Clip;
    [Range(0, 1)] public float Volume;

    private AudioSource _audioSource;

    public AudioSource Source {
        get { return _audioSource; }
        set { _audioSource = value; }
    }
}
