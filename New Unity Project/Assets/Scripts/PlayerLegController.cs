using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegController : MonoBehaviour
{

    public HingeJoint2D hinge;
    public JointMotor2D motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = hinge.motor;

    }

    // Update is called once per frame
    void Update()
    {
        hinge.motor = motor;
    }

}
