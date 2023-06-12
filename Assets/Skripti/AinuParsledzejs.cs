using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importé, lai varétu veikt ainu ieládi
using UnityEngine.SceneManagement;

//Ainas pec indexiem
public class AinuParsledzejs : MonoBehaviour {
	public void UzSakumu(){
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}
	public void UzUI()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
	public void UzNoteikumiem()
	{
		SceneManager.LoadScene (2, LoadSceneMode.Single);
	}
	public void UzBeigam(){
		SceneManager.LoadScene (3, LoadSceneMode.Single);
	}
	public void UzAtbildem(){
		SceneManager.LoadScene (4, LoadSceneMode.Single);
	}
	public void Apturet()
	{
		Application.Quit ();
	}

}
