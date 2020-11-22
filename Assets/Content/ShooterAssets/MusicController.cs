using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{

    public List<AudioClip> TrackList = new List<AudioClip>();
    public int TrackNumber = 0;
    AudioSource MusicSource;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource = GetComponent<AudioSource>();
        StartPlaying(TrackNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPlaying(int Track)
    {
        if (null == MusicSource) return;
        if (Track < 0 || Track >= TrackList.Count) return;

        MusicSource.clip = TrackList[Track];
        MusicSource.Play();
    }
}
