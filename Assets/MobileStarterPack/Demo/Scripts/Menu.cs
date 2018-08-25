using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public Texture Title;
	public GUIStyle Style;
	void OnGUI () {
		GUI.DrawTexture(new Rect(Screen.width/3,0,Screen.width/3,Screen.height/5),Title,ScaleMode.ScaleToFit,true);
		GUI.Label(new Rect(Screen.width-80,0,100,30),"Version 1.2",Style);
		GUI.Label(new Rect(0,Screen.height/12*2.15f,Screen.width,Screen.height/12),"C# Version",Style);
		
		if(GUI.Button(new Rect(Screen.width/3,Screen.height/12*3.15f,Screen.width/3,Screen.height/12*0.8f),"Classic Control")){
			Application.LoadLevel("CSClassic");
		}
		if(GUI.Button(new Rect(Screen.width/3,Screen.height/12*4.15f,Screen.width/3,Screen.height/12*0.8f),"Accelerometer Control")){
			Application.LoadLevel("CSAccelero");
		}
		if(GUI.Button(new Rect(Screen.width/3,Screen.height/12*5.15f,Screen.width/3,Screen.height/12*0.8f),"Gyro Control (if device is compatible) * ")){
			Application.LoadLevel("CSGyro");
		}
		
		GUI.Label(new Rect(0,Screen.height/12*7.15f,Screen.width,Screen.height/12),"JS Version",Style);
		
		if(GUI.Button(new Rect(Screen.width/3,Screen.height/12*8.15f,Screen.width/3,Screen.height/12*0.8f),"Classic Control")){
			Application.LoadLevel("JSClassic");
		}
		if(GUI.Button(new Rect(Screen.width/3,Screen.height/12*9.15f,Screen.width/3,Screen.height/12*0.8f),"Accelerometer Control")){
			Application.LoadLevel("JSAccelero");
		}
		if(GUI.Button(new Rect(Screen.width/3,Screen.height/12*10.15f,Screen.width/3,Screen.height/12*0.8f),"Gyro Control (if device is compatible) * ")){
			Application.LoadLevel("JSGyro");
		}
		GUI.Label(new Rect(Screen.width-480,Screen.height-20,480,30),"* Gyroscope needs a few seconds to calibrate itself after that the scene is loaded.",Style);
	}
}
