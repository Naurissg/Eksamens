using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Quizz : MonoBehaviour
{
	public Question[] questions;
	public Text questionText;
	public Button[] answerButtons;
	public Image feedbackImage;
	public Text timerText;

	public Sprite correctImage;
	public Sprite incorrectImage;

	private int currentQuestionIndex = 0;
	private float timer = 0f;
	public bool quizCompleted = false;
	private List<Question> correctAnsweredQuestions = new List<Question>();

	private void Start()
	{
		DisplayQuestion(currentQuestionIndex);
	}

	private void Update()
	{
		if (!quizCompleted)
		{
			timer += Time.deltaTime;
			int minutes = Mathf.FloorToInt(timer / 60f);
			int seconds = Mathf.FloorToInt(timer % 60f);
			timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		}
	}

	private void DisplayQuestion(int questionIndex)
	{
		questionText.text = questions[questionIndex].question;

		for (int i = 0; i < answerButtons.Length; i++)
		{
			answerButtons[i].GetComponentInChildren<Text>().text = questions[questionIndex].answers[i];
		}
	}

	public void AnswerButtonClicked(int buttonIndex)
	{
		if (questions[currentQuestionIndex].correctAnswerIndex == buttonIndex)
		{
			Debug.Log("Correct!");
			correctAnsweredQuestions.Add(questions[currentQuestionIndex]);
			ShowFeedbackImage(correctImage);
		}
		else
		{
			Debug.Log("Wrong!");
			ShowFeedbackImage(incorrectImage);
		}

		currentQuestionIndex++;

		if (currentQuestionIndex >= questions.Length)
		{
			QuizCompleted();
			return;
		}

		Invoke("DisplayNextQuestion", 2f);
	}

	private void DisplayNextQuestion()
	{
		feedbackImage.gameObject.SetActive(false);
		DisplayQuestion(currentQuestionIndex);
	}

	private void ShowFeedbackImage(Sprite image)
	{
		feedbackImage.sprite = image;
		feedbackImage.gameObject.SetActive(true);
	}

	private void QuizCompleted()
	{
		quizCompleted = true;
		PlayerPrefs.SetFloat("FinalTime", timer);

		// Save the correct answered questions to player preferences
		string correctQuestionsJson = JsonUtility.ToJson(new QuestionList(correctAnsweredQuestions));
		PlayerPrefs.SetString("CorrectAnsweredQuestions", correctQuestionsJson);

		SceneManager.LoadScene("Beigas");
	}
}

[System.Serializable]
public class Question
{
	public string question;
	public string[] answers;
	public int correctAnswerIndex;
}

[System.Serializable]
public class QuestionList
{
	public List<Question> questions;

	public QuestionList(List<Question> questionList)
	{
		questions = questionList;
	}
}
