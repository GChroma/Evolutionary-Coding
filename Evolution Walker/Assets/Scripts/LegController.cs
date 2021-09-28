using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{

    public DistanceJoint2D muscle;
    private float contracted;
    private float relaxed;
    [Range(-1, +1)] public float position = 1;//restricts the following float

    // Start is called before the first frame update
    void Start()
    {
        float distance = muscle.distance;
        //set distance for relaxed vs contracted muscle.
        relaxed = distance * 1.5f;
        contracted = distance / 2f;
    }

    // Update is called once per frame
    void FixedUpdate()//occurs after the update, with physics checks already done. etc.
    {

        muscle.distance = linearInterpolation(-1, 1, contracted, relaxed, position);//moves the leg

    }

    public static float linearInterpolation(float x0, float x1, float y0, float y1, float x)
    {
        float d = x1 - x0;
        if (d == 0)
            return (y0 + y1) / 2;
        return y0 + (x - x0) * (y1 - y0) / d;
    }
}
