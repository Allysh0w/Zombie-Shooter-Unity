using UnityEngine;
using System.Collections;

public class EnemyControllerZumbi : MonoBehaviour {

    public int HealthEnemyNv1;
    public GameObject Player;
    public bool DieStatus = false;
    public int DamageZombie = 2;     // Primeiro dano do attack do zumbi
    public int DamageZombieStay = 1; // Dano constante aplicado ao jogador
    private SpawnManager spawnManager;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
       
        if (HealthEnemyNv1 <= 0 ){
            ZumbieDie();
            
            DieStatus = true;
        }
	}

    // Aplica o Damage ao zumbi, o damage vem do tiro.
    public void ZumbiDamage()
    {
        if (DieStatus == false) {
            if (transform.gameObject.name == "zdog_low_Prefab")
            {
                transform.GetComponent<Animation>()["hit_01"].layer = 1; GetComponent<Animation>().Play("hit_01");
                HealthEnemyNv1 -= 50;
            }
            else
            {
                transform.GetComponent<Animation>()["hit2"].layer = 1; GetComponent<Animation>().Play("hit2");
                HealthEnemyNv1 -= 50;
            }
            //transform.GetComponent<Animation>()["hit2"].layer = 1; GetComponent<Animation>().Play("hit2");
            
        }
    }

    // Detecta a primeira Colisão do Zumbi ao jogador
    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            SelfDamageView.getDamage = true;
            Player.GetComponent<MSPFps>().Hit(DamageZombie);  
                      

        }
    }

    // Detecta o atack constante do zumbi ao jogador
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            Player.GetComponent<MSPFps>().Hit(DamageZombieStay);            
            
        }
    }

    void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SelfDamageView.getDamage = false;

        }
    }

   void OnGUI()
    {
        //GUI.Label(new Rect(200, 10, 250, 200), teste);
    }

        //O Zumbi morre
    public void ZumbieDie()
    {

        if (transform.gameObject.name == "zdog_low_Prefab")
        {
            transform.GetComponent<Animation>()["death_05"].layer = 1; GetComponent<Animation>().Play("death_05");
        }
        else
        {
            transform.GetComponent<Animation>()["fallBack"].layer = 1; GetComponent<Animation>().Play("fallBack");
        }
            // transform.GetComponent<Animation>().Play("fallToBack",PlayMode.StopAll);
            
        
        //transform.GetComponent<Animation>().Play("fallBack");
        transform.Translate(0,0,0);
        StartCoroutine(WaitZumbiDie());

    }

    IEnumerator WaitZumbiDie()
    {
        yield return new WaitForSeconds(2);
        spawnManager.EnemyKilled();
        Destroy(this.gameObject);
    }

    public void Set(GameObject mainGO)
    {
        spawnManager = mainGO.GetComponent<SpawnManager>();
    }

}
