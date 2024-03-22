using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundClip[] sounds;
    public AudioSource music;
    int musicNum;

    public GalaxyTracks[] galaxyTracks;

    [System.Serializable]
    public class GalaxyTracks
    {
        public AudioClip[] musicClips;
    }

    void Awake()
    {

        foreach (SoundClip sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.Clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

    }
    void Start()
    {
        musicNum = UnityEngine.Random.Range(0, 4);
        music.clip = galaxyTracks[0].musicClips[musicNum];
        music.Play();
    }
    void Update()
    {
        if (!music.isPlaying)
        {
            musicNum += 1;
            if (musicNum >= 4)
            {
                musicNum = 0;
            }
            music.Play();
        }
    }
    public void Play(string name)
    {
        SoundClip s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not Found!");
            return;
        }
        s.source.Play();
    }
}
