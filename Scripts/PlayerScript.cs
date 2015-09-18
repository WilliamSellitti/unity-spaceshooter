using UnityEngine;
using System.Collections;

[System.Serializable]
public class Border {

	public float leftX, rightX;
	public float upZ, downZ;

}

public class PlayerScript : MonoBehaviour {

	public Border Boundary; /* For Player Movement*/
	public float Speed;		/*--*/
	public float tilt;		/*--*/

	public GameObject Bolt;					/* For Shooting */
	public Transform WeaponsOriginPoint;	/*--*/
	public float fireRate;					/*--*/ // rate of time allowed between shots
											/*--*/
	private float newShot;					/*--*/

	void Start () {
	
	}

	void Update () {
	
		if (rigidbody.position.x > Boundary.rightX) 
			rigidbody.position = new Vector3 (Boundary.rightX, 0, rigidbody.position.z);

		if (rigidbody.position.x < Boundary.leftX)
			rigidbody.position = new Vector3 (Boundary.leftX, 0, rigidbody.position.z);

		if (rigidbody.position.z > Boundary.upZ) 
			rigidbody.position = new Vector3 (rigidbody.position.x, 0, Boundary.upZ);
		
		if (rigidbody.position.z < Boundary.downZ)
			rigidbody.position = new Vector3 (rigidbody.position.x , 0, Boundary.downZ);

		if (Input.GetKey ("space") && Time.time > newShot) {
		
			Instantiate( Bolt , WeaponsOriginPoint.position , WeaponsOriginPoint.rotation );
			newShot = Time.time + fireRate;
			audio.Play ();

		}


	}	

	void FixedUpdate () {
		
		float Xmove = Input.GetAxis ("Horizontal");
		float Zmove = 0; //Input.GetAxis ("Vertical"); 

		/* I like the Galaga play style and am stealing it by removing all vertical movement */

		rigidbody.velocity = new Vector3 (Xmove, 0, Zmove) * Speed;

		rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -tilt );
		
	}


}
