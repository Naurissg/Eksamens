using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class NepareizAtbJaut : MonoBehaviour
{
	public Text NepareizuJautText;

	private void Start()
	{
		string nepareizoJautajumu = PlayerPrefs.GetString("NepareizieAtbildesJautajumi");
		AtbilzuList NepareizieJaut = JsonUtility.FromJson<AtbilzuList>(nepareizoJautajumu);

		if (NepareizieJaut != null)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Nepareizi atbildētie jautājumi:\n");

			foreach (Jautajumi jautajums in NepareizieJaut.jautajumi)
			{
				sb.AppendLine(jautajums.Jautajums);
			}

			NepareizuJautText.text = sb.ToString();
		}
		else
		{
			NepareizuJautText.text = "Nav neviena nepareizi atbildēta jautājuma.";
		}
	}
}
