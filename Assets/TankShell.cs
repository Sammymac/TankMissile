using UnityEngine;
using System.Collections;

public class TankShell : MonoBehaviour {

	private float speed = 10.0f;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target.z = transform.position.z;

		Vector3 dir = target - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//Move the shell away from the Player tank to avoid a collision
		transform.Translate(Vector3.right * 1);

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}

}