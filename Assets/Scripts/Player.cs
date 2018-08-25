using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private void OnTriggerEnter(Collider col){
		if(col.CompareTag ("Enemy")){
			col.GetComponent<AI>().Kill();
		}
	}

	private void Update(){
		if(Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime *7f);
		}

		if(Input.GetKey (KeyCode.S)) {
			transform.Translate(-Vector3.forward * Time.deltaTime *7f);
		}

		if(Input.GetKey (KeyCode.A)) {
			transform.Translate(Vector3.left * Time.deltaTime *7f);
		}

		if(Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector3.right * Time.deltaTime *7f);
		}

		Vector3 newPos = transform.position;
		newPos.z = Mathf.Clamp (newPos.z, -15f, 15f);
		newPos.x = Mathf.Clamp (newPos.x, -15f, 15f);
		transform.position = newPos; 
	}
}
