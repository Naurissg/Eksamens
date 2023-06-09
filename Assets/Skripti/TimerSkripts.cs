using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSkripts : MonoBehaviour
{
	public Text timerText; // Reference to the text component to display the timer
	private float timer = 0f; // The timer value
	private bool quizCompleted = false; // Flag to track if the quiz is completed

	private void Update()
	{
		if (!quizCompleted)
		{
			// Update the timer value
			timer += Time.deltaTime;

			// Calculate minutes, seconds, and milliseconds
			int minutes = Mathf.FloorToInt(timer / 60f);
			int seconds = Mathf.FloorToInt(timer % 60f);
			int milliseconds = Mathf.FloorToInt((timer * 1000) % 1000);

			// Update the timer text
			timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
		}
	}

	public void QuizCompleted()
	{
		quizCompleted = true;
		SceneManager.LoadScene("Beigas"); // Transition to the "Beigas" scene (replace with your scene name)
		PlayerPrefs.SetFloat("FinalTime", timer); // Store the final time in player preferences for accessing in the "Beigas" scene
	}
}
