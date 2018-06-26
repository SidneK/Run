using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[Header("Audio")]
	public AudioSource GameOverSound;
	public AudioSource JumpSound;
	[Header("Gameplay")]
	public float SpeedSpace;
	public bool isGround;

	private float spawnX;
	private float spawnY;
	private Rigidbody2D rb;
	private Animator animator;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spawnX = rb.transform.position.x;
		spawnY = rb.transform.position.y;
	}

	void Update()
	{
		if (Logic.Instance.Score % 5 == 0 && Logic.Instance.Score != 0)
			animator.speed += 0.0002f;
		if (!Logic.Instance.IsGameOver)
		{
			if (Logic.Instance.IsPressed && isGround)
			{
				Logic.Instance.IsPressed = false;
				if (ActionButton.IsSoundOn)
					JumpSound.Play();
				animator.SetInteger("State", 2);
				rb.AddForce(Vector2.up * SpeedSpace, ForceMode2D.Impulse);
				isGround = false;
			}
		}
		else // is game over
		{
			animator.SetInteger("State", 0);
			if (Logic.Instance.IsPressed)
			{
				rb.transform.position = new Vector3(spawnX, spawnY, 0.0f);
				Logic.Instance.PrintTapToStart.enabled = false;
				Logic.Instance.Score = 0;
				Logic.Instance.PrintScore.text = "0";
				Logic.Instance.IsGameOver = false;
				Logic.Instance.PrintGameOver.enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Block")
		{
			if (ActionButton.IsSoundOn)
				GameOverSound.Play();
			Logic.Instance.PrintTapToStart.enabled = true;
			animator.speed = 1;
			Logic.Instance.IsGameOver = true;
			Logic.Instance.SpeedItems = 0.2f;
			GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
			GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
			foreach (GameObject it in blocks)
				Destroy(it.gameObject);
			foreach (GameObject it in points)
				Destroy(it.gameObject);
			if (Logic.Instance.Score > Logic.Instance.Record)
			{
				PlayerPrefs.SetInt("Record", Logic.Instance.Score);
				PlayerPrefs.Save();
				Logic.Instance.Record = Logic.Instance.Score;
			}
			Logic.Instance.PrintGameOver.enabled = true;
			Logic.Instance.PrintGameOver.text = "Game Over\r\nScore: "
				+ Logic.Instance.Score + "\r\nRecord: " + Logic.Instance.Record;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!Logic.Instance.IsGameOver)
		{
			if (collision.gameObject.tag == "Platform")
			{
				animator.SetInteger("State", 1);
				isGround = true;
			}
		}
	}
}
