using UnityEngine;
using UnityEngine.UI;

public class BeigasScene : MonoBehaviour
{
	public Text beiguLaiks; // Teksta lauks, kurā tiks attēlots beigu laiks

	private void Start()
	{
		float beiguLaiksVērtība = PlayerPrefs.GetFloat("BeiguLaiks", 0f); // Iegūst beigu laika vērtību no spēlētāja
		ParādītBeiguLaiku(beiguLaiksVērtība);  // Attēlo beigu laiku teksta laukā.
	}

	private void ParādītBeiguLaiku(float time)
	{
		int minutes = Mathf.FloorToInt(time / 60);  // Aprēķina minūtes.
		int seconds = Mathf.FloorToInt(time % 60);  // Aprēķina sekundes.
		int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);  // Aprēķina milisekundes.
		// Attēlo beigu laiku teksta formātā mm:ss:ms
		beiguLaiks.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
	}
}
