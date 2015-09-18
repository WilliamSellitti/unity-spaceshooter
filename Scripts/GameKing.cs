using UnityEngine;
using System.Collections;

public class GameKing : MonoBehaviour {

	public GameObject hazards;
	public Vector3 SpawnValues;
	public int HazardCount;
	public float startWait;
	public float spawnWait;
	public float WaveWait;

	public GUIText scoreText;
	private int score;

	public GUIText restartText;
	public GUIText gameOverText;
	private bool restart;
	private bool gameOver;

	void Start () {

		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());

		restart = false;
		gameOver = false;

		restartText.text = "";
		gameOverText.text = "";
	
	}

	void Update(){

		if (restart) {

			if(Input.GetKeyDown (KeyCode.R)){

				Application.LoadLevel(Application.loadedLevel);
				print("My Butt");

			}

		}
	
	}

	IEnumerator SpawnWaves () {

		yield return new WaitForSeconds (startWait);

		while(true){

			for (int i = 0; i < HazardCount; i++) {

				Vector3 spawnPosition = new Vector3 (Random.Range (SpawnValues.x, -SpawnValues.x), SpawnValues.y, SpawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazards, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);

			}

			yield return new WaitForSeconds (WaveWait);

			if(gameOver){

				restartText.text = "PRESS 'R' FOR RESTART!";
				restart = true;
				break;

			}
		
		}
	
	}

	public void AddScore (int newScoreValue){

		score += newScoreValue;
		UpdateScore ();
	
	}

	void UpdateScore () {
		
		scoreText.text = "Score: " + score.ToString ();

	}

	public void endGame () {

		gameOverText.text = "Game Over";
		gameOver = true;
	
	}

}
