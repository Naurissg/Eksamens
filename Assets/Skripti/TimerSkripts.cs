// TimerSkripts
using UnityEngine;
using UnityEngine.UI;


public class TimerSkripts : MonoBehaviour
{
	public Text timerTexts;   // Teksta lauks, kurā tiek attēlots laiks
	private float pagajisLaiks = 0f;  // Pagajusais laiks
	public Quizz quizz;   //Quizz objekts
	public Text beiguLaiks;  // Teksta lauks, kurā tiek attēlots laiks spēles beigās

	private void Start()
	{
		StartTimer();  // Sāk taimeri
	}

	private void Update()
	{
		if (!quizz.quizPabeigts)
		{
			pagajisLaiks += Time.deltaTime;  // Pievieno pagājušo laiku
			AtjauninatTimerUI(pagajisLaiks);  // Atjauno taimera interfeisu
		}
	}

	private void AtjauninatTimerUI(float pagajisLaiks)
	{
		int minutes = Mathf.FloorToInt(pagajisLaiks / 60);  // Minūtes
		int seconds = Mathf.FloorToInt(pagajisLaiks % 60);  // Sekundes
		int milliseconds = Mathf.FloorToInt((pagajisLaiks * 1000) % 1000);  // Milisekundes

		timerTexts.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds); // Atjaunina tekstu taimera interfeisā
		beiguLaiks.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);  // Atjaunina tekstu spēles beigu laika interfeisā
	}

	public void StartTimer()
	{
		pagajisLaiks = 0f;
	}
}
