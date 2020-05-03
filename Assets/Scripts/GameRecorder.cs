using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRecorder : MonoBehaviour {
	
	public static GameRecorder instance;

	public int NumDeath {
		get;
		private set;
	}

	public float timeStart;
	public float timeStop;

	private void Start() {
		DontDestroyOnLoad(this);
		instance = this;
		Application.targetFrameRate = 60;
	}

	public static void StartTimer() => instance.timeStart = Time.realtimeSinceStartup;

	public static void StopTimer() => instance.timeStop = Time.realtimeSinceStartup;

	public static void RecordDeath() => instance.NumDeath += 1;

	public static void Reset() {
		instance.timeStart = 0;
		instance.timeStop = 0;
		instance.NumDeath = 0;
	}
}
