using UnityEngine;
using UnityEngine.UI;

public class NepareizAtbJaut : MonoBehaviour
{
	public Text wrongQuestionsText;

	private void Start()
	{
		string wrongQuestionsJson = PlayerPrefs.GetString("WrongAnsweredQuestions");
		QuestionList wrongQuestions = JsonUtility.FromJson<QuestionList>(wrongQuestionsJson);

		if (wrongQuestions != null)
		{
			wrongQuestionsText.text = "Nepareizi atbildétie jautájumi:\n";

			foreach (Question question in wrongQuestions.questions)
			{
				wrongQuestionsText.text += "\n" + question.question;
			}
		}
		else
		{
			wrongQuestionsText.text = "Nav nevienu nepareizi atbildétu jautájumu.";
		}
	}
}
