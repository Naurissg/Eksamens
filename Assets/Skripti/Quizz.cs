// TimerSkripts
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Quizz : MonoBehaviour
{
	public Jautajumi[] Jautajums;
	public Text JautajumaText;
	public Button[] AtbildesPogas;
	public Image AtsauksmesAttels;
	public Text timerTexts;

	public Sprite PareizaBild;
	public Sprite NepareizaBilde;

	private int JautajumaIndex = 0;
	private float Timeris = 0f;
	public bool quizPabeigts = false;
	private List<Jautajumi> pareizoAtbilzuJautajumi = new List<Jautajumi>();
	private List<Jautajumi> nepareizoAtbilzuJautajumi = new List<Jautajumi>();

	private void Start()
	{
		ParaditJautajumu(JautajumaIndex);
	}

	private void Update()
	{
		if (!quizPabeigts)
		{
			Timeris += Time.deltaTime;
			int minutes = Mathf.FloorToInt(Timeris / 60f);
			int seconds = Mathf.FloorToInt(Timeris % 60f);
			timerTexts.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		}
	}

	private void ParaditJautajumu(int JautajumaIndex)
	{
		JautajumaText.text = Jautajums[JautajumaIndex].Jautajums;

		for (int i = 0; i < AtbildesPogas.Length; i++)
		{
			AtbildesPogas[i].GetComponentInChildren<Text>().text = Jautajums[JautajumaIndex].Atbildes[i];
		}
	}

	public void AtbildesPogaNospiesta(int PoguIndex)
	{
		if (Jautajums[JautajumaIndex].pareizasAtbildesIndeks == PoguIndex)
		{
			Debug.Log("Pareizi!");
			pareizoAtbilzuJautajumi.Add(Jautajums[JautajumaIndex]);
			AtbildesBilde(PareizaBild);
		}
		else
		{
			Debug.Log("Nepareizi!");
			nepareizoAtbilzuJautajumi.Add(Jautajums[JautajumaIndex]);
			AtbildesBilde(NepareizaBilde);
		}

		JautajumaIndex++;

		if (JautajumaIndex >= Jautajums.Length)
		{
			PabeigtQuiz();
			return;
		}

		Invoke("ParadaNakamoJaut", 2f);
	}

	private void ParadaNakamoJaut()
	{
		AtsauksmesAttels.gameObject.SetActive(false);
		ParaditJautajumu(JautajumaIndex);
	}

	private void AtbildesBilde(Sprite image)
	{
		AtsauksmesAttels.sprite = image;
		AtsauksmesAttels.gameObject.SetActive(true);
	}

	private void PabeigtQuiz()
	{
		quizPabeigts = true;
		PlayerPrefs.SetFloat("BeiguLaiks", Timeris);

		// Save the correct answered questions to player preferences
		string pareizoJautajumu = JsonUtility.ToJson(new AtbilzuList(pareizoAtbilzuJautajumi));
		PlayerPrefs.SetString("PareiziAtbildetsJautajums", pareizoJautajumu);

		string nepareizoJautajumu = JsonUtility.ToJson(new AtbilzuList(nepareizoAtbilzuJautajumi));
		PlayerPrefs.SetString("NepareizieAtbildesJautajumi", nepareizoJautajumu);


		SceneManager.LoadScene("Beigas");
	}
}

[System.Serializable]
public class Jautajumi
{
	public string Jautajums;
	public string[] Atbildes;
	public int pareizasAtbildesIndeks;
}

[System.Serializable]
public class AtbilzuList
{
	public List<Jautajumi> jautajumi;

	public AtbilzuList(List<Jautajumi> jautajumuList)
	{
		jautajumi = jautajumuList;
	}
}
