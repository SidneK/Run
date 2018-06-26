using UnityEngine;

public class MoveItems : MonoBehaviour
{
	public bool Direction; // 1 - x, 0 - y

	private Rigidbody2D rb;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Direction && !Logic.Instance.IsPause)
		{
			rb.transform.position = new Vector3(rb.transform.position.x - Logic.Instance.SpeedItems,
											rb.transform.position.y,
											rb.transform.position.z);
		}
		else if (!Direction && !Logic.Instance.IsPause)
		{
			rb.transform.position = new Vector3(rb.transform.position.x,
										rb.transform.position.y + Logic.Instance.SpeedItems,
										rb.transform.position.z);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Destroy")
			Destroy(gameObject);
	}
}
