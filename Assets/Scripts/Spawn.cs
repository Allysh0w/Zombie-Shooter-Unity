using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	private bool canSpawn = true; //are we on cooldown?

	//Return status of this spawn point, can we spawn here?
	public bool Status(){
		return canSpawn;
	}

	//Mark that we just spaned from this position
	public void Spawned(float amount){
		StartCoroutine("CoolDown", amount);
	}

	//Wait after how much we can spawn next enemy
	public IEnumerator CoolDown(float amount){
		canSpawn = false;
		yield return new WaitForSeconds(amount);
		canSpawn = true;
	}
}
