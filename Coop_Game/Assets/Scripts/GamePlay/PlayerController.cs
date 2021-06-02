using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Animations;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int health;
    public GameObject player;
    public GameObject UpperBody;
    public GameObject LowerBody;
    public Joystick Mjoystick;
    public Joystick Ajoystick;
    //private float gravityValue = -9.8f;
    CharacterController controller;
    Animator anim;
    public bool UpperBodyTrans;

    Vector3 playerVector;
    Vector3 playerVelocity;
    Vector3 UpperBodyVector;

   

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
        anim = player.GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        float x1 = Mjoystick.Horizontal;
        float z1= Mjoystick.Vertical;

        float x2 = Ajoystick.Horizontal;
        float z2 = Ajoystick.Vertical;

        playerVelocity = new Vector3(x1, 0f, z1);
        Ajoystick.DeadZone = 0.5f;

       
        UpperBodyVector = new Vector3(x2, 0f, z2);
        
        if (playerVelocity.magnitude>0)
        {
            LowerBody.transform.LookAt(LowerBody.transform.position - new Vector3(x1, 0, z1) - new Vector3(0, 90, 0));
            UpperBody.transform.LookAt(UpperBody.transform.position - new Vector3(x1, 0, z1) + new Vector3(0, 90, 0));
            UpperBodyTrans = false;
            

        }
        else
        {
            LowerBody.transform.LookAt(LowerBody.transform.position - new Vector3(x1, 0, z1));
            UpperBodyTrans = false;
        }

        if (UpperBodyVector.magnitude > 0)
        {

            UpperBody.transform.LookAt(UpperBody.transform.position - new Vector3(x2, 0, z2) + new Vector3(0, 90, 0));
            UpperBodyTrans = true;
            anim.SetInteger("UpperState", 2);
            
        }
        else if (UpperBodyVector.magnitude==0)
        {
            anim.SetInteger("UpperState", 0);
        }
        if ((UpperBodyVector.magnitude == 0) && (playerVelocity.magnitude > 0))
        {
            anim.SetInteger("UpperState", 1);
        }

        if ((playerVelocity.magnitude > 0)&& (playerVelocity.magnitude<0.5))
        {
            anim.SetInteger("LowerState", 1);
        }
        if (playerVelocity.magnitude == 0)
        {
            anim.SetInteger("LowerState", 0);
        }
        if (playerVelocity.magnitude > 0.5)
        {
            anim.SetInteger("LowerState", 2);
        }



        controller.Move(playerVelocity*Time.fixedDeltaTime*speed);
        


    }


}
