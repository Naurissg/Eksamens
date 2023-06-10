// TimerSkripts.cs
using UnityEngine;
using UnityEngine.UI;

public class TimerSkripts : MonoBehaviour
{
	public Text timerText;
	private float elapsedTime = 0f;
	public Quizz quizz;
	public Text finalTime;

	private void Start()
	{
		StartTimer();
	}

	private void Update()
	{
		if (!quizz.quizCompleted)
		{
			elapsedTime += Time.deltaTime;
			UpdateTimerUI(elapsedTime);
		}
	}

	private void UpdateTimerUI(float elapsedTime)
	{
		int minutes = Mathf.FloorToInt(elapsedTime / 60);
		int seconds = Mathf.FloorToInt(elapsedTime % 60);
		int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

		timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
		finalTime.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
	}

	public void StartTimer()
	{
		elapsedTime = 0f;
	}
}
