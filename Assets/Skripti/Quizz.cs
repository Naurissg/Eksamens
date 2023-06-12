using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Quizz : MonoBehaviour
{
	public Jautajumi[] Jautajums;  // Jautājumu masīvs
	public Text JautajumaText;   // Teksta lauks jautājuma attēlošanai
	public Button[] AtbildesPogas;   // Pogas atbilžu attēlošanai
	public Image AtsauksmesAttels;   // Attēls atsauksmes attēlošanai
	public Text timerTexts;   // Teksta lauks laika attēlošanai
	 
	public Sprite PareizaBild;  //attēls pareizai atbildei
	public Sprite NepareizaBilde;  //attēls nepareizai atbildei

	private int JautajumaIndex = 0;  // Pašreizējā jautājuma indekss
	private float Timeris = 0f;   // Laika mērītājs
	public bool quizPabeigts = false;  //Quizz pabeigšanas pārbaude
	private List<Jautajumi> pareizoAtbilzuJautajumi = new List<Jautajumi>(); // Pareizo atbilžu jautājumu saraksts
	private List<Jautajumi> nepareizoAtbilzuJautajumi = new List<Jautajumi>();  // Nepareizo atbilžu jautājumu saraksts


	private void Start()
	{
		ParaditJautajumu(JautajumaIndex);
	}

	private void Update()
	{
		if (!quizPabeigts)
		{
			Timeris += Time.deltaTime;  // Palielina laika mērītāju
			int minutes = Mathf.FloorToInt(Timeris / 60f);  // Aprēķina minūtes
			int seconds = Mathf.FloorToInt(Timeris % 60f);  // Aprēķina sekundes
			timerTexts.text = string.Format("{0:00}:{1:00}", minutes, seconds);   // Atjauno teksta lauku ar laika vērtībām
		}
	}

	private void ParaditJautajumu(int JautajumaIndex)
	{
		JautajumaText.text = Jautajums[JautajumaIndex].Jautajums;   // Iestata jautājuma tekstu

		for (int i = 0; i < AtbildesPogas.Length; i++)
		{
			AtbildesPogas[i].GetComponentInChildren<Text>().text = Jautajums[JautajumaIndex].Atbildes[i];   // Iestata atbilžu tekstu uz pogām
		}
	}

	public void AtbildesPogaNospiesta(int PoguIndex)
	{
		if (Jautajums[JautajumaIndex].pareizasAtbildesIndeks == PoguIndex)
		{
			Debug.Log("Pareizi!");
			pareizoAtbilzuJautajumi.Add(Jautajums[JautajumaIndex]);   // Pievieno pareizo atbilžu jautājumu sarakstam
			AtbildesBilde(PareizaBild);   // Attēlo pareizu atbilžu bildi
		}
		else
		{
			Debug.Log("Nepareizi!");
			nepareizoAtbilzuJautajumi.Add(Jautajums[JautajumaIndex]);  // Pievieno nepareizo atbilžu jautājumu sarakstam
			AtbildesBilde(NepareizaBilde);    // Attēlo nepareizu atbilžu bildi
		}

		JautajumaIndex++;

		if (JautajumaIndex >= Jautajums.Length)  
		{
			PabeigtQuiz();   // Parbauta vai visi jautajumi atbildeti lai pabeigtu Quizz
			return;
		}

		Invoke("ParadaNakamoJaut", 1f);  // Uzliek aizkaves laiku pirms parādās nākamais jautājums
	}

	private void ParadaNakamoJaut()
	{
		AtsauksmesAttels.gameObject.SetActive(false);  // Paslēpj atsauksmes attēlu
		ParaditJautajumu(JautajumaIndex);   // Parāda nākamo jautājumu
	}

	private void AtbildesBilde(Sprite image)
	{
		AtsauksmesAttels.sprite = image;   // Iestata atsauksmes attēlu
		AtsauksmesAttels.gameObject.SetActive(true);   // Parāda atsauksmes attēlu
	} 

	private void PabeigtQuiz()
	{
		quizPabeigts = true;   // Quizz ir pabeigts
		PlayerPrefs.SetFloat("BeiguLaiks", Timeris);  // Saglabā beigu laiku 

		// Saglabā pareizi atbildētos jautājumus
		string pareizoJautajumu = JsonUtility.ToJson(new AtbilzuList(pareizoAtbilzuJautajumi));
		PlayerPrefs.SetString("PareiziAtbildetsJautajums", pareizoJautajumu);

		// Saglabā nepareizi atbildētos jautājumus Player Preferences
		string nepareizoJautajumu = JsonUtility.ToJson(new AtbilzuList(nepareizoAtbilzuJautajumi));
		PlayerPrefs.SetString("NepareizieAtbildesJautajumi", nepareizoJautajumu);

		// Pāriet uz "Beigas" ainu
		SceneManager.LoadScene("Beigas");
	}
}

[System.Serializable]
public class Jautajumi
{
	public string Jautajums;  // Jautājuma teksts
	public string[] Atbildes;   // Atbilžu masīvs
	public int pareizasAtbildesIndeks;   // Pareizās atbildes indekss
}

[System.Serializable]
public class AtbilzuList
{
	public List<Jautajumi> jautajumi;   // Jautājumu saraksts

	public AtbilzuList(List<Jautajumi> jautajumuList)
	{
		jautajumi = jautajumuList;
	}
}
