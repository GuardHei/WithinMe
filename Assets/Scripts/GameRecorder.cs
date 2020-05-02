using UnityEngine;

public class GameRecorder : MonoBehaviour {

	private static GameRecorder instance;
	private float _startTime;
	private float _endTime;

	public float RecordedTime => _endTime - _startTime;

	public int NumDeath {
		get;
		private set;
	}
	
	private void Start() {
		Application.targetFrameRate = 60;
		
		instance = this;
		
		DontDestroyOnLoad(this);
	}

	public static void StartTimer() {
		instance._startTime = Time.realtimeSinceStartup;
		Debug.Log("Start Timer");
	}

	public static void StopTimer() {
		instance._endTime = Time.realtimeSinceStartup;
		Debug.Log("Stop Timer");
	}

	public static void RecordDeath() {
		instance.NumDeath++;
		Debug.Log("Record Death " + instance.NumDeath);
	}

	public static void Reset() {
		instance._startTime = 0;
		instance._endTime = 0;
		instance.NumDeath = 0;
	}
}
