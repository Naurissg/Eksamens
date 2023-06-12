using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class PareizAtbJaut : MonoBehaviour
{
	public Text PareizJautTexts;  // Teksta lauks, kurā tiks attēloti pareizi atbildētie jautājumi

	private void Start()
	{
		// Iegūst pareizi atbildēto jautājumu datus no spēlētāja.
		string pareizoJautajumu = PlayerPrefs.GetString("PareiziAtbildetsJautajums");
		AtbilzuList pareiziJaut = JsonUtility.FromJson<AtbilzuList>(pareizoJautajumu);

		if (pareiziJaut != null)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Pareizi atbildētie jautājumi:\n");

			foreach (Jautajumi jautjaums in pareiziJaut.jautajumi)
			{
				// Pārbauda katru pareizi atbildēto jautājumu un pievieno to teksta rindai
				sb.AppendLine(jautjaums.Jautajums);
			}

			// Attēlo tekstu ar pareizajiem jautājumiem
			PareizJautTexts.text = sb.ToString();
		}
		else
		{
			// Ja nav pareizu jautājumu, attēlo paziņojumu
			PareizJautTexts.text = "Nav neviena pareizi atbildēta jautājuma.";
		}

	}
}