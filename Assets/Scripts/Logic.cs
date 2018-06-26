using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
	[Header("Text")]
	public Text PrintScore;
	public Text PrintGameOver;
	public Text PrintTapToStart;
	[Header("Animation")]
	public Animator AnimationBackground;
	[Header("Sound")]
	public AudioSource SoundBackground;
	[Header("Gameplay")]
	public int Record;
	public int Score;
	public float SpeedItems;
	public bool IsGameOver;
	public bool IsPause;
	public bool IsPressed;

	static public Logic Instance { get; private set; }
	void Awake()
	{
		Record = PlayerPrefs.GetInt("Record");
		Instance = this;
	}

	void Start()
	{
		PrintGameOver.enabled = false;
		PrintScore.text = "0";
		if (!ActionButton.IsSoundOn)
			SoundBackground.Stop();
	}

	void Update()
	{
		if (Score % 5 == 0 && Score != 0)
		{
			SpeedItems += 0.0002f;
			AnimationBackground.speed += 0.0002f;
		}
		if (IsGameOver)
		{
			AnimationBackground.speed = 1;
			AnimationBackground.StartPlayback();
		}
		else
			AnimationBackground.StopPlayback();
	}

	void OnMouseDown()
	{
		IsPressed = true;	
	}
}
