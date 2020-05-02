using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;
    private static readonly Queue<AudioSource> idleAudioSources = new Queue<AudioSource>(5);
    
    public AudioClip bgm;
    [Range(0f, 1f)]
    public float masterVolume = 1f;

    private AudioSource _source;

    private void Start() {
        instance = this;
        
        _source = gameObject.AddComponent<AudioSource>();
        _source.spatialBlend = 0;
        _source.loop = true;
        _source.volume = masterVolume;
        _source.clip = bgm;
        
        if (bgm) {
            _source.Play();
        }
        
        DontDestroyOnLoad(this);
    }

    public static void PlayAtPoint(AudioClip clip, Vector2 position, float volume = 1f) {
        AudioSource source = GetAudioSource();
        source.volume = volume * instance.masterVolume;
        source.clip = clip;
        source.transform.position = position;
        source.Play();
        instance.StartCoroutine(ExeRecycleCoroutine(source));
    }

    private static AudioSource GetAudioSource() {
        AudioSource source;
        if (idleAudioSources.Count > 0) {
            source = idleAudioSources.Dequeue();
            source.gameObject.SetActive(true);
        } else {
            GameObject gameObject = new GameObject("Public Audio Source");
            gameObject.transform.parent = instance.transform;
            source = gameObject.AddComponent<AudioSource>();
            source.spatialBlend = 0;
            source.loop = false;
        }

        return source;
    }
    
    private static IEnumerator ExeRecycleCoroutine(AudioSource source) {
        float time = source.clip.length;
        yield return new WaitForSeconds(time);
        source.Stop();
        source.gameObject.SetActive(false);
        idleAudioSources.Enqueue(source);
    }
}
