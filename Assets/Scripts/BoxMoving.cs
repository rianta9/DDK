using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f, changeDirection = -1;
    public bool grounded = true, faceright = true;
    public float dem;
    Vector3 Move;
   

    // Use this for initialization
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         Move.x += speed;
        this.transform.position = Move;
    }

   
  
}


