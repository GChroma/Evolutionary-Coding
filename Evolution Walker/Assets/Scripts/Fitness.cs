using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fitness : MonoBehaviour
{

    private Vector3 initialPosition;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = body.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public float GetScore()
    {
        float walkingScore = body.transform.position.x - initialPosition.x;//how far did the creature walk

        //check if the creature is balanced
        //bool bodyBalanced = body.transform.eulerAngles.z < 30 || body.transform.eulerAngles.z > 330;//less than 30 or greater than 360-30
        //bool bodyImBalanced = body.transform.eulerAngles.z < 135 && body.transform.eulerAngles.z > 225;//less than 180-45 and greater than 180+45

        /*float imBalancedMod;
        if (bodyImBalanced)
        {
            imBalancedMod = 0.5f;
        }
        else
        {
            imBalancedMod = 1f;
        }
        float balancedMod;
        if (bodyBalanced)
        {
            balancedMod = 2f;
        }
        else
        {
            balancedMod = 1f;
        }*/

        return walkingScore /** imBalancedMod + balancedMod*/;
    }
}
