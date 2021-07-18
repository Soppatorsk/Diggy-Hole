using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    System.Random rnd = new System.Random();

    int pr = 1;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
        }

        if (s.name == "rockHit")
        {
            int r = rnd.Next(3);
            if (pr == r)    //if same roll as previous, roll again. more variation
            {
                r = rnd.Next(3);
            }
            switch (r)
            {
                case 0:
                    s.pitch = 1;
                    break;
                case 1:
                    s.pitch = (float)1.18921; //Just for fun pitch intervals, minor triad. confine all game audio to one musical key? lol
                    break;
                case 2:
                    s.pitch = (float)1.33484;
                    break;
            }
            pr = r;
        }
        s.source.Play();
    }
}
