namespace New_Unity_Project.Assets.Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Evolution : MonoBehaviour
    {

        //instantiate a bunch of environments into a gameobject container
        //at the same time, create a list of all of the environments
        //also before that, fill the currentGeneration list with genomes
        //place the correct genome into the environment.
        //start the simulation.

        public EvolutionHistory history;
        public List<Environment> environments = new List<Environment>();
        public int creaturesPerGen;
        public int creaturesSurvived;

        // Start is called before the first frame update
        void Start()
        {
            history.Clear();
        }

        public void prepareCreatures(EvolutionHistory history)
        {
            for (int i = 0; i < creaturesSurvived; i++)
            {
                history.top25Genomes.Add(Genome.CreateRandom());
            }


        }


        // Update is called once per frame
        void Update()
        {

        }





    }


}


