using UnityEngine;
using UnityEngine.UI;

public class FlashText : MonoBehaviour
{
	private float Seconds;
	private Text text; 

	void Start()
	{
		Seconds = 0.0f;
		text = GetComponent<Text>();
	}

	void Update()
	{
		if (Logic.Instance.IsGameOver)
		{
			Seconds += Time.deltaTime;
			if (Seconds >= 0.5f)
				text.enabled = false;
			if (Seconds >= 1.0f)
			{
				text.enabled = true;
				Seconds = 0.0f;
			}
		}
	}
}
