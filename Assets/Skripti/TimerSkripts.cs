// TimerSkripts
using UnityEngine;
using UnityEngine.UI;


public class TimerSkripts : MonoBehaviour
{
	public Text timerTexts;
	private float pagajisLaiks = 0f;
	public Quizz quizz;
	public Text beiguLaiks;

	private void Start()
	{
		StartTimer();
	}

	private void Update()
	{
		if (!quizz.quizPabeigts)
		{
			pagajisLaiks += Time.deltaTime;
			AtjauninatTimerUI(pagajisLaiks);
		}
	}

	private void AtjauninatTimerUI(float pagajisLaiks)
	{
		int minutes = Mathf.FloorToInt(pagajisLaiks / 60);
		int seconds = Mathf.FloorToInt(pagajisLaiks % 60);
		int milliseconds = Mathf.FloorToInt((pagajisLaiks * 1000) % 1000);

		timerTexts.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
		beiguLaiks.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
	}

	public void StartTimer()
	{
		pagajisLaiks = 0f;
	}
}
