using UnityEngine;

public class SpawnItems : MonoBehaviour
{
	[Header("Objects")]
	public GameObject spawn_star;
	public GameObject star;
	public GameObject Block;

	private float seconds_for_star;
	private float seconds_for_point;
	private int time_point_creation;
	private int time_star_creation;
	private Transform tr;
	void Start()
	{
		seconds_for_point = 0.0f;
		seconds_for_star = 0.0f;
		tr = GetComponent<Transform>();
		time_point_creation = Random.Range(1, 3);
		time_star_creation = Random.Range(5, 50);
	}

	void Update()
	{
		if (!Logic.Instance.IsGameOver && !Logic.Instance.IsPause)
		{
			seconds_for_point += Time.deltaTime;
			seconds_for_star += Time.deltaTime;
			if (seconds_for_point >= time_point_creation)
			{
				// create object
				Instantiate(Block, tr.transform.position, Quaternion.identity);
				seconds_for_point = 0.0f;
				time_point_creation = Random.Range(1, 3);
			}
			if (seconds_for_star >= time_star_creation)
			{
				Instantiate(star, spawn_star.transform.position, Quaternion.identity);
				seconds_for_star = 0.0f;
				time_star_creation = Random.Range(5, 50);
			}
		}
	}
}
