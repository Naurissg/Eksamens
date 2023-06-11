using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class PareizAtbJaut : MonoBehaviour
{
	public Text correctQuestionsText;

	private void Start()
	{
		string correctQuestionsJson = PlayerPrefs.GetString("CorrectAnsweredQuestions");
		QuestionList correctQuestions = JsonUtility.FromJson<QuestionList>(correctQuestionsJson);

		if (correctQuestions != null)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Pareizi atbildētie jautājumi:");

			foreach (Question question in correctQuestions.questions)
			{
				sb.AppendLine(question.question);
			}

			correctQuestionsText.text = sb.ToString();
		}
		else
		{
			correctQuestionsText.text = "Nav neviena pareizi atbildēta jautājuma.";
		}
	}
}
