using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		print ("Tank collided with-->"+col.gameObject.name+"<--");
		if(col.gameObject.name.Equals("Shell(Clone)")){
			Destroy(col.gameObject);
		}
	}
}
