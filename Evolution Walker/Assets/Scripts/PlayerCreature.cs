namespace New_Unity_Project.Assets.Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerCreature : MonoBehaviour
    {
        public PlayerLegController left;
        public PlayerLegController right;
        public Fitness fitness;
        public float score;

        public float rightLeg = 0;
        public float leftLeg = 0;
        // Start is called before the first frame update
        void Start()//upon being created, create the legs.
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.D))
            {
                left.motor.motorSpeed = 60;
            }
            else if (Input.GetKey(KeyCode.F))
            {
                left.motor.motorSpeed = -60;
            }
            else
            {
                left.motor.motorSpeed = 0;
            }

            if (Input.GetKey(KeyCode.J))
            {
                right.motor.motorSpeed = 60;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                right.motor.motorSpeed = -60;
            }
            else
            {
                right.motor.motorSpeed = 0;
            }

            score = fitness.GetScore();
        }
    }


}
