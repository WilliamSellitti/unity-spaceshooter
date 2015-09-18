using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	void Start () {
	
		float lifetime = 1;
		Destroy (gameObject, lifetime);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
