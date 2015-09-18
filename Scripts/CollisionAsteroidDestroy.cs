using UnityEngine;
using System.Collections;

public class CollisionAsteroidDestroy : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameKing controller;

	void Start(){ //all the code in here finds the game controller object for each instantiation of a hazard object because the asteroids are only the hellspawn of a prefab and the prefab cannot contain hardcoded links to specific objects

		GameObject GKO = GameObject.FindWithTag ("GameController");

		if (GKO != null) {

			controller = GKO.GetComponent <GameKing>();

		} if (controller == null) {

			Debug.Log("GAME CONTROLLER IS NOT FOUND, YOU FAIL");

		}

	}

	void OnTriggerEnter (Collider Other) {

		if (Other.tag == "Boundary") {

			return;
		
		}

		Instantiate( explosion , transform.position , transform.rotation );

		if (Other.tag == "Player") {

			Instantiate (playerExplosion, Other.transform.position, Other.transform.rotation);
			controller.endGame();

		}

		Destroy (Other.gameObject);
		Destroy (gameObject);

		controller.AddScore (10);

	}

}
