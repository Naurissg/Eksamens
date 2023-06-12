using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class PareizAtbJaut : MonoBehaviour
{
	public Text PareizJautTexts;

	private void Start()
	{
		string pareizoJautajumu = PlayerPrefs.GetString("PareiziAtbildetsJautajums");
		AtbilzuList pareiziJaut = JsonUtility.FromJson<AtbilzuList>(pareizoJautajumu);

		if (pareiziJaut != null)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Pareizi atbildētie jautājumi:\n");

			foreach (Jautajumi jautjaums in pareiziJaut.jautajumi)
			{
				sb.AppendLine(jautjaums.Jautajums);
			}

			PareizJautTexts.text = sb.ToString();
		}
		else
		{
			PareizJautTexts.text = "Nav neviena pareizi atbildēta jautājuma.";
		}

	}
}