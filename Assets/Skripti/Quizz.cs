using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Quizz : MonoBehaviour
{
	public Question[] Jautajums;
	public Text JautajumaText;
	public Button[] AtbildesPogas;
	public Image AtsauksmesAttels;
	public Text timerTexts;

	public Sprite PareizaBild;
	public Sprite NepareizaBilde;

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
			timerTexts.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		}
	}

	private void DisplayQuestion(int questionIndex)
	{
		JautajumaText.text = Jautajums[questionIndex].question;

		for (int i = 0; i < AtbildesPogas.Length; i++)
		{
			AtbildesPogas[i].GetComponentInChildren<Text>().text = Jautajums[questionIndex].answers[i];
		}
	}

	public void AnswerButtonClicked(int buttonIndex)
	{
		if (Jautajums[currentQuestionIndex].correctAnswerIndex == buttonIndex)
		{
			Debug.Log("Correct!");
			correctAnsweredQuestions.Add(Jautajums[currentQuestionIndex]);
			ShowFeedbackImage(PareizaBild);
		}
		else
		{
			Debug.Log("Wrong!");
			ShowFeedbackImage(NepareizaBilde);
		}

		currentQuestionIndex++;

		if (currentQuestionIndex >= Jautajums.Length)
		{
			QuizCompleted();
			return;
		}

		Invoke("DisplayNextQuestion", 2f);
	}

	private void DisplayNextQuestion()
	{
		AtsauksmesAttels.gameObject.SetActive(false);
		DisplayQuestion(currentQuestionIndex);
	}

	private void ShowFeedbackImage(Sprite image)
	{
		AtsauksmesAttels.sprite = image;
		AtsauksmesAttels.gameObject.SetActive(true);
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
