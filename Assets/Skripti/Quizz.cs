using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quizz : MonoBehaviour
{
	public Question[] questions; // Array to store all the questions
	public Text questionText; // Reference to the question text component
	public Button[] answerButtons; // Array to store the answer buttons
	public Image feedbackImage; // Reference to the image component for feedback

	public Sprite correctImage; // Sprite for correct answer feedback
	public Sprite incorrectImage; // Sprite for incorrect answer feedback

	private int currentQuestionIndex = 0; // Index of the current question
	private TimerSkripts timerScript; // Reference to the TimerSkripts script

	private void Start()
	{
		timerScript = FindObjectOfType<TimerSkripts>(); // Find the TimerSkripts script in the scene
		DisplayQuestion(currentQuestionIndex); // Display the first question
	}

	private void DisplayQuestion(int questionIndex)
	{
		// Update the question text
		questionText.text = questions[questionIndex].question;

		// Loop through the answer buttons and set their text
		for (int i = 0; i < answerButtons.Length; i++)
		{
			answerButtons[i].GetComponentInChildren<Text>().text = questions[questionIndex].answers[i];
		}
	}

	public void AnswerButtonClicked(int buttonIndex)
	{
		// Check if the selected answer is correct
		if (questions[currentQuestionIndex].correctAnswerIndex == buttonIndex)
		{
			// Answer is correct
			Debug.Log("Correct!");

			// Show the correct answer image
			ShowFeedbackImage(correctImage);
		}
		else
		{
			// Answer is wrong
			Debug.Log("Wrong!");

			// Show the incorrect answer image
			ShowFeedbackImage(incorrectImage);
		}

		// Move to the next question
		currentQuestionIndex++;

		// Check if all questions have been answered
		if (currentQuestionIndex >= questions.Length)
		{
			Debug.Log("Quiz completed!");

			// Call the QuizCompleted method in TimerSkripts script to stop the timer
			timerScript.QuizCompleted();

			// Transition to a different scene (change "Beigas" to the name of your scene)
			SceneManager.LoadScene("Beigas");
			return;
		}

		// Display the next question after a delay
		Invoke("DisplayNextQuestion", 2f);
	}

	private void DisplayNextQuestion()
	{
		// Hide the feedback image
		feedbackImage.gameObject.SetActive(false);

		// Display the next question
		DisplayQuestion(currentQuestionIndex);
	}

	private void ShowFeedbackImage(Sprite image)
	{
		// Set the feedback image sprite
		feedbackImage.sprite = image;

		// Show the feedback image
		feedbackImage.gameObject.SetActive(true);
	}
}

[System.Serializable]
public class Question
{
	public string question; // The question
	public string[] answers; // Array of possible answers
	public int correctAnswerIndex; // Index of the correct answer
}
