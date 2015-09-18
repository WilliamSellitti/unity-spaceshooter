using UnityEngine;
using System.Collections;

public class DeathBoundary : MonoBehaviour {

	void OnTriggerExit (Collider Other){

		Destroy (Other.gameObject);

	}

}
