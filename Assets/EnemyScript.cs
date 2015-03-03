using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private int health = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Destroy(this);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		print ("Tank collided with-->"+col.gameObject.name+"<--");
		if(col.gameObject.name.Equals("Shell(Clone)")){
			health -= 20;
			print("Health:"+health);
			if(health <= 0){
				Destroy(this.gameObject);
			}
			Destroy(col.gameObject);
		}
	}

	public int GetHealth(){
		return health;
	}
}
