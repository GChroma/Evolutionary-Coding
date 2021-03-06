
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
        //public float cutOffScore;
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


        public void Evaluate(List<Environment> environments, Evolution evolution)
        {
            float max = -10000;
            float min = +10000;
            float totalScore = 0;
            foreach (Environment environment in environments)
            {

                if (environment.creature.genome.score > max)
                {
                    max = environment.creature.genome.score;
                }

                if (environment.creature.genome.score < min)
                {
                    min = environment.creature.genome.score;
                }

                totalScore += environment.creature.genome.score;
            }


            //Debug.Log(max);
            //cutOffScore = (totalScore / evolution.creaturesPerGen) * 1.25f;//take the average and then multiply by 1.25 to get the top 25%.
            maxScore = max;
            minScore = min;

        }

        //Not working quicksort algorithm.
        /*        static public int Partition(List<Environment> environments, int left, int right)
                {
                    float pivot;
                    pivot = environments[left].creature.genome.score;
                    while (true)
                    {
                        while (environments[left].creature.genome.score < pivot)
                        {
                            left++;
                        }
                        while (environments[right].creature.genome.score > pivot)
                        {
                            right--;
                        }
                        if (left < right)
                        {
                            Environment temp = environments[right];
                            environments[right] = environments[left];
                            environments[left] = temp;
                        }
                        else
                        {
                            return right;
                        }
                    }
                }
                public void QuickSort(List<Environment> environments, int left, int right)
                {
                    float pivot;
                    if (left < right)
                    {
                        pivot = Partition(environments, left, right);
                        if (pivot > 1)
                        {
                            QuickSort(environments, left, (int)(pivot) + 1);
                        }
                        if (pivot + 1 < right)
                        {
                            QuickSort(environments, (int)(pivot) + 1, right);
                        }
                    }
                }*/

        /* Update is called once per frame
        void Update()
        {

        }
        */
    }
}
