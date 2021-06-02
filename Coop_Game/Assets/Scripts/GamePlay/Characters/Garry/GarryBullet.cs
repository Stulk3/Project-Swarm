using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarryBullet : MonoBehaviour
{

    public float damage = 25;
    public float bullet_speed = 300f;
    public Rigidbody rb;
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bullet_speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider Thing)
    {
        if (Thing.gameObject.tag == "Enemy")
        {
            
            Thing.gameObject.GetComponent<EnemyScript>().currenthealth -= damage;
            Destroy(this.gameObject);
        }
        else if (Thing.gameObject.tag == "Untagged")
        {
            Destroy(this.gameObject);
        }
        
    }

    void Update()
    {

    }
}
