using UnityEngine;
using UnityEngine.UI;

public class PareizAtbJaut : MonoBehaviour
{
	public Text correctQuestionsText;

	private void Start()
	{
		string correctQuestionsJson = PlayerPrefs.GetString("CorrectAnsweredQuestions");
		QuestionList correctQuestions = JsonUtility.FromJson<QuestionList>(correctQuestionsJson);

		if (correctQuestions != null)
		{
			correctQuestionsText.text = "Pareizi atbildétie jautájumi:\n";

			foreach (Question question in correctQuestions.questions)
			{
				correctQuestionsText.text += "\n" + question.question;
			}
		}
		else
		{
			correctQuestionsText.text = "Nav pareizi atbildētu jautājumu.";
		}
	}
}
