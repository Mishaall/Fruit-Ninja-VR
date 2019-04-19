using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//definition of fruit class- how game object will behave. Can have methods, variables, properties

public class Fruit : MonoBehaviour {

	//force that propells fruit outwards. Stores float number 
	public float verticalForce = 400f;
	public float horizontalForce = 150f;
	public float lifetime = 2f;

	// Use this for initialization- below are methods e.g. start method
	void Start () {
		Rigidbody rigidbody = GetComponent<Rigidbody> (); //searches for rigidbody component
		rigidbody.AddForce (new Vector3(
			Random.Range(-horizontalForce, horizontalForce),
			verticalForce,
			0
		
		));
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0f) {
			Destroy (gameObject);
		}
	}
}
