using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
	[Header("Only button pause")]
	public GameObject Pause;
	public GameObject SpawnPause;
	[Header("Only sound button")]
	public GameObject Sound;
	public Sprite SoundOn;
	public Sprite SoundOff;

	static public bool IsSoundOn = true;
	void OnMouseDown()
	{
		if (gameObject.tag == "Resume")
		{
			Logic.Instance.IsPause = false;
			GameObject pause = GameObject.FindGameObjectWithTag("PausePop");
			Destroy(pause);
			Time.timeScale = 1;
		}
		else if (gameObject.tag == "BackToMenu")
		{
			Time.timeScale = 1;
			SceneManager.LoadScene("Menu");
		}
	}
	public void UseButton(string Name)
	{
		if (Name == "Play")
			SceneManager.LoadScene("Main");
		else if (Name == "Exit")
			Application.Quit();
		else if (Name == "Pause")
		{
			if (!Logic.Instance.IsPause)
			{
				Logic.Instance.IsPause = true;
				Instantiate(Pause, SpawnPause.transform.position, Quaternion.identity);
				Time.timeScale = 0;
			}
		}
		else if (Name == "Sound")
		{
			IsSoundOn = !IsSoundOn;
			if (!IsSoundOn)
				Sound.GetComponent<Image>().sprite = SoundOff;
			else
				Sound.GetComponent<Image>().sprite = SoundOn;
		}
	}
}
