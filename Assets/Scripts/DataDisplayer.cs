using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplayer : MonoBehaviour {

	public Text timeText;
	public Text deathText;

	private void Start() {
		GameRecorder.StopTimer();
		float time = GameRecorder.instance.timeStop - GameRecorder.instance.timeStart;
		int min = (int) time / 60;
		int sec = (int) time % 60;
		Debug.Log(time);
		timeText.text = "Time: " + min + ":" + sec;
		deathText.text = "Deaths: " + GameRecorder.instance.NumDeath;
	}
}
