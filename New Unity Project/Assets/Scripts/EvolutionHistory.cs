
namespace New_Unity_Project.Assets.Scripts
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EvolutionHistory : MonoBehaviour
    {

        public List<Genome> currentGeneration = new List<Genome>();//the current running generation
        public List<Genome> top25Genomes = new List<Genome>();//the top 25% best genomes that will mutate into the future generation
        public int generation = 0;//tracks what generation it is on

        public float maxScore;
        public float minScore;
        public float cutOffScore;
        public List<Genome> bestPerGen = new List<Genome>();//list of the best genome for each generation

        // Start is called before the first frame update
        void Start()
        {

        }

        public void Clear()
        {
            generation = 0;
            currentGeneration.Clear();
            bestPerGen.Clear();
            top25Genomes.Clear();
        }


        public void Evaluate()
        {
            float max = -10000;
            float min = +10000;
            float top25;
            foreach (Genome genome in currentGeneration)
            {

                if (genome.score > max)
                {
                    max = genome.score;
                }

                if (genome.score < min)
                {
                    min = genome.score;
                }
            }

            top25 = (max - min) * 0.75f + min;

            cutOffScore = top25;
            maxScore = max;
            minScore = min;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
