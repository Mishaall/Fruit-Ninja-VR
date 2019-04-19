using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] fruitPrefabs;
	public Player player;
	public TextMesh infoText;

	public float horizontalArea = 5f;
	public float spawnHeight = 0.5f;
	public float spawnDepth = -3f;

	public float spawnDuration = 3f;

	public float gameTimer = 15f;

	private float spawnTimer;
	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
		spawnTimer = spawnDuration;
	}

	// Update is called once per frame
	void Update () {
		if (gameTimer > 0) {
			gameTimer -= Time.deltaTime;

			spawnTimer -= Time.deltaTime;

			if (spawnTimer <= 0f) {
				spawnTimer = spawnDuration;

				for (int i = 0; i < 3; i++) {
					GameObject fruit = Instantiate (fruitPrefabs [Random.Range (0, fruitPrefabs.Length)]);
					fruit.transform.position = new Vector3 (
						Random.Range (-horizontalArea, horizontalArea),
						spawnHeight,
						spawnDepth
					);
				}
			}

			infoText.text = "Slash the fruits!\nTime: " + Mathf.Floor (gameTimer) + "\nScore: " + player.score;
		} else {
			infoText.text = "Game over! Score: " + player.score;

			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}
