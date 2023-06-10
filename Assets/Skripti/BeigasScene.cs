using UnityEngine;
using UnityEngine.UI;

public class BeigasScene : MonoBehaviour
{
	public Text finalTime;

	private void Start()
	{
		float finalTimeValue = PlayerPrefs.GetFloat("FinalTime", 0f); // Retrieve the final time from player preferences
		DisplayFinalTime(finalTimeValue);
	}

	private void DisplayFinalTime(float time)
	{
		int minutes = Mathf.FloorToInt(time / 60);
		int seconds = Mathf.FloorToInt(time % 60);
		int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
		finalTime.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
	}
}
