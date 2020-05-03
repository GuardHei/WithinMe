using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip bgm;

	private void Start() {
		DontDestroyOnLoad(this);
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.loop = true;
		source.spatialBlend = 0;
		source.clip = bgm;
		if (bgm) source.Play();
	}
}
