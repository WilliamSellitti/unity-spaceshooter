using UnityEngine;
using System.Collections;

public class RandomRotato : MonoBehaviour {
		
	public float tumble;

	void Start () {

		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	
	}

}
