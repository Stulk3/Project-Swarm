using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarryScript : MonoBehaviour
{
    public PlayerController playercontoller;
    public GameObject Bullet_Place;
    public GameObject bullet;
    private GameObject bullet_shot;
    public Joystick a_joystick;
    Rigidbody rb;
    Vector3 shoot_dir;
    public float fireRate;
    Vector3 Bullet_Spawn;
    float nextFire=0f;
    bool Shot=true;

    void Start()
    {

        
    }

    
    void FixedUpdate()
    {
        Shooting();
        
    }


    void Shooting() 
    {
        Bullet_Spawn = Bullet_Place.transform.position;
        float x = a_joystick.Horizontal;
        float z = a_joystick.Vertical;

        shoot_dir = new Vector3(x, 0, z);
        nextFire += fireRate;



        if ((nextFire > 1f) && (Shot == false))
        {
            Shot = true;
            nextFire = 0;
        }
        Quaternion rotation = Quaternion.LookRotation(shoot_dir, Vector3.up);
        if ((shoot_dir.magnitude != 0) && (Shot) && (playercontoller.UpperBodyTrans))
        {
            nextFire = 0;
            bullet_shot = Instantiate(bullet, Bullet_Spawn, rotation);
            Shot = false;

        }

    }





   

}
