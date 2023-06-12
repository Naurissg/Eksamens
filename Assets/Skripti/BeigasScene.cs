using UnityEngine;
using UnityEngine.UI;

public class BeigasScene : MonoBehaviour
{
	public Text beiguLaiks;

	private void Start()
	{
		float beiguLaiksVērtība = PlayerPrefs.GetFloat("BeiguLaiks", 0f); // Retrieve the final time from player preferences
		ParādītBeiguLaiku(beiguLaiksVērtība);
	}

	private void ParādītBeiguLaiku(float time)
	{
		int minutes = Mathf.FloorToInt(time / 60);
		int seconds = Mathf.FloorToInt(time % 60);
		int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
		beiguLaiks.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
	}
}
