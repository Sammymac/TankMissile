using System.Collections;
using UnityEngine;
using System.IO;
using System;

public class PlayerScript : MonoBehaviour {

	private float speed;
	private float maxSpeed;
	private float accelration;
	private float turnSpeed;

	// Use this for initialization
	void Start () {
		speed = 0;
		accelration = 2;
		turnSpeed = 1;
		maxSpeed = 100;

		applyMap("Map1.txt");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			turnSpeed = 5;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			turnSpeed = 1;
		}

		if(Input.GetKey(KeyCode.W)){
			speed += accelration;
		}
		if(Input.GetKey(KeyCode.S)){ //Negative speed means tank reverses
			speed -= accelration;
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(0,0,turnSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(0,0,-turnSpeed);
		}

		if(speed > maxSpeed){
			speed = maxSpeed;
		}
		if(speed < -maxSpeed/2){
			speed = -maxSpeed/2;
		}

		if(speed > 0){
			speed -= accelration / 2;	
		}
		else if(speed < 0){
			speed += accelration / 2;
		}

		if(Input.GetMouseButtonDown(0)){
			var newShell = Resources.Load("Shell");
			Instantiate(newShell, transform.position, transform.rotation);
		}

		transform.Translate(Vector3.right * speed/1000f);
	}

	void applyMap(string mapName){
		int blockx = -18;
		int blocky = -6;
		mapName = "Assets\\Resources\\" + mapName;
		string text = "";
		FileInfo file = null;
		StreamReader reader = null;

		file = new FileInfo (mapName);
		reader = file.OpenText();

		for(int i=0;i<10;i++){
			blocky++;
			blockx = -13;
			if(text != null){
				text = reader.ReadLine();
				print (text);
				string[] numbers = text.Split(' ');
				foreach(string num in numbers){
					blockx++;
					if(num.Equals("1")){
						fillSquare(blockx, blocky);
					} else if(num.Equals("0")){

					} else {
//						throw Exception;
					}
				}
			}
		}
	}

	void fillSquare(int x, int y){
		float intervalx = 0.125f;
		float intervaly = 0.125f;

		for(int i=0;i<4;i++){
			for(int j=0;j<4;j++){
				var newShell = Resources.Load("Wall Piece");
				var pos = transform.position;
				pos.x = 0.125f + (0.25f * (float) j) + x;
				pos.y = 0.125f + (0.25f * (float) i) + y;
				Instantiate(newShell, pos, transform.rotation);
			}
		}
	}

}
