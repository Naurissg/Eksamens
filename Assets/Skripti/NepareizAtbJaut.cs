using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class NepareizAtbJaut : MonoBehaviour
{
	public Text NepareizuJautText;  // Teksta lauks, kurā tiks attēloti nepareizi atbildētie jautājumi.

	private void Start()
	{
		// Iegūst nepareizi atbildētos jautājumus no spēlētāja
		string nepareizoJautajumu = PlayerPrefs.GetString("NepareizieAtbildesJautajumi");
		AtbilzuList NepareizieJaut = JsonUtility.FromJson<AtbilzuList>(nepareizoJautajumu);

		if (NepareizieJaut != null)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Nepareizi atbildētie jautājumi:\n");

			// Pārbauda katru nepareizo jautājumu un pievieno to teksta rindai.
			foreach (Jautajumi jautajums in NepareizieJaut.jautajumi)
			{
				sb.AppendLine(jautajums.Jautajums);
			}

			// Attēlo tekstu ar nepareizajiem jautājumiem.
			NepareizuJautText.text = sb.ToString();
		}
		else
		{
			// Ja nav nepareizu jautājumu, attēlo paziņojumu.
			NepareizuJautText.text = "Nav neviena nepareizi atbildēta jautājuma.";
		}
	}
}
