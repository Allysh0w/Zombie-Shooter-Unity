using UnityEngine;
using System.Collections;
using System;

public class AIZumbi : MonoBehaviour {
   

    public float distance;
    public Transform target;
    public float lookAtDistance = 25.0f;
    public float attackRange    = 1.0f;
    public int rangeDeVisao     = 15;
    public float moveSpeed      = 3.0f;
    public float Damping        = 6.0f;


    // Update is called once per frame
    void Start()
    {
        this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
        //if (this.gameObject.name == "MaleZombiePrefab" || this.gameObject.name == "FemaleZombiePrefab" || this.gameObject.name == "FatZombiePrefab")
        //{
           // Destroy(this.gameObject);
        //}
       // this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
        // target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () {        

            distance = Vector3.Distance(target.position, transform.position);

        if (distance > lookAtDistance)
        {
            //Estado normal
            //transform.GetComponent<Animation>().Play("idle");
            //transform.GetComponent<Animation>()["idle"].layer = 1; GetComponent<Animation>().Play("idle");

            CorreAtras();
        }
        else if (distance < attackRange)
        {
            Attack();

        }
        else if (distance < rangeDeVisao)

        {
            
            CorreAtras();

        }
        else if (distance < lookAtDistance)
        {

            CorreAtras();
        }


    }


    public void LookAt()
    {
        //transform.GetComponent<Animation> ().Play("idle");
        transform.GetComponent<Animation>()["idle"].layer = 1; GetComponent<Animation>().Play("idle");
        var rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
        //Debug.Log("idle");
    }

    public void Attack()
    {
        //var rotation = Quaternion.LookRotation(Target.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
        transform.Translate(Vector3.forward * 0.2f * Time.deltaTime);
        // Debug.Log(rotation);
        //transform.GetComponent<Rigidbody>().AddForce(this.transform.forward * 500);
        if (transform.gameObject.name == "zdog_low_Prefab")
        {
            transform.GetComponent<Animation>()["attack_01"].layer = 1; GetComponent<Animation>().Play("attack_01");

        }
        else
        {
            transform.GetComponent<Animation>()["attack1"].speed = 0.6f;
            transform.GetComponent<Animation>()["attack1"].layer = 1; GetComponent<Animation>().Play("attack1");
        }
          
            
      
    }

    public void CorreAtras()
    {
        if (transform.GetComponent<EnemyControllerZumbi>().DieStatus == false)
        {
            
            //var rotation = Quaternion.LookRotation(target.position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
            //transform.GetComponent<Animation>().Play("shamble");  
            if (transform.gameObject.name == "zdog_low_Prefab")
            {
                var rotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
                transform.GetComponent<Animation>()["run_fast"].layer = 1; GetComponent<Animation>().Play("run_fast");
                transform.Translate(Vector3.forward * 3.5f * Time.deltaTime);
            }
            else if (transform.gameObject.name == "MaleZombiePrefab")
            {
                var rotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
                transform.GetComponent<Animation>()["crawl"].layer = 1; GetComponent<Animation>().Play("crawl");
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }else
            {
                var rotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
                transform.GetComponent<Animation>()["shamble"].layer = 1; GetComponent<Animation>().Play("shamble");
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            }
                
            //Debug.Log("Corre atras");
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

    }




}
