using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class NepareizAtbJaut : MonoBehaviour
{
	public Text wrongQuestionsText;

	private void Start()
	{
		string wrongQuestionsJson = PlayerPrefs.GetString("WrongAnsweredQuestions");
		QuestionList wrongQuestions = JsonUtility.FromJson<QuestionList>(wrongQuestionsJson);

		if (wrongQuestions != null)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Nepareizi atbildētie jautājumi:");

			foreach (Question question in wrongQuestions.questions)
			{
				sb.AppendLine(question.question);
			}

			wrongQuestionsText.text = sb.ToString();
		}
		else
		{
			wrongQuestionsText.text = "Nav neviena nepareizi atbildēta jautājuma.";
		}
	}
}
