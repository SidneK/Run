using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			++Logic.Instance.Score;
			Logic.Instance.PrintScore.text = Logic.Instance.Score.ToString();
			Destroy(gameObject);
		}
	}
}
