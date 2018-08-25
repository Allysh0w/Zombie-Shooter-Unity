using UnityEngine;
using System.Collections;

public class SelfDamageView : MonoBehaviour {

    public static float hitalpha = 0;
    public Texture2D TextureDamage;
    public static bool getDamage = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


    }

    void OnGUI()
    {

        if (getDamage)
        {                     
            if (Time.time % 2 < 1.5f) {             
               // Debug.Log(Time.time);               
                GUI.color = new Color(1, 1, 1, 1.8f);
                if (TextureDamage)
                {

                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), TextureDamage);
                }
            }
        }
    }



}
