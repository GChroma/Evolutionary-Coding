namespace New_Unity_Project.Assets.Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Creature : MonoBehaviour
    {
        public LegController left;
        public LegController right;
        public Fitness fitness;
        public Genome genome;//genome decides how the Leg Controllers are used.

        // Start is called before the first frame update
        void Start()//upon being created, create the legs.
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {

            left.position = genome.left.EvaluateAt(Time.time);
            right.position = genome.right.EvaluateAt(Time.time);
            genome.score = fitness.GetScore();
        }
    }


}
