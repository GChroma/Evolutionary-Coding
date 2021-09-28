namespace New_Unity_Project.Assets.Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Evolution : MonoBehaviour
    {

        //create initial genomes to populate from

        //START IENUMERATOR
        //populate from top25Genomes
        //Create Environments
        //wait 10 seconds
        //naturalSelection
        //destroy Environments.

        public EvolutionHistory history;
        public List<Environment> environments = new List<Environment>();
        public int creaturesPerGen = 100;
        public int testsPerCreature = 1;
        public int creaturesSurvived = 30;
        public int simulationLength = 10;//in seconds
        public int cycles = 10;
        public GameObject environmentContainer;
        public GameObject prefab;

        // Start is called before the first frame update
        void Start()
        {
            history.Clear();
            prepareCreatures(history);
            StartCoroutine(Simulation());

        }

        public void prepareCreatures(EvolutionHistory history)//create genomes to repopulate from
        {
            for (int i = 0; i < creaturesPerGen; i++)
            {
                history.currentGeneration.Add(Genome.CreateRandom());
            }
        }

        public void createEnvironments(EvolutionHistory history, List<Environment> environments)//spawns environments using the current generation
        {
            for (int i = 0; i < creaturesPerGen; i++)
            {
                for (int t = 0; t < testsPerCreature; t++)
                {
                    GameObject environmentObject = Instantiate(prefab, new Vector3(0, ((-i * 12) + (t * 4)), 0), Quaternion.identity, environmentContainer.transform);
                    Environment environment = environmentObject.GetComponent<Environment>();
                    environment.creature.genome = history.currentGeneration[i];
                    environment.transform.parent = environmentContainer.transform;
                    environment.name = "creature " + i + ". Test " + t;
                    environments.Add(environment);
                }

            }
        }

        public void destroyEnvironments(List<Environment> environments)//clear environments list and also destroy environment game objects
        {
            foreach (Transform child in environmentContainer.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            environments.Clear();
        }

        public void repopulate(EvolutionHistory history)//clones and mutates the top genomes 5 times each.
        {
            history.currentGeneration.Clear();
            int cloneAmount = creaturesPerGen / creaturesSurvived;
            foreach (Genome genome in history.top25Genomes)
            {
                //history.currentGeneration.Add(genome);//keep one of the same

                for (int i = 0; i < cloneAmount; i++)//clone and mutate the rest
                {
                    Genome newGenome = genome.Clone();
                    newGenome.Mutate();
                    history.currentGeneration.Add(newGenome);

                }
            }
        }

        public void naturalSelection(EvolutionHistory history, List<Environment> environments)//moves the best 25% genomes to allow them to reproduce.
        {//also puts the top per the generation into a list
            bool topGenomeChosen = false;
            history.top25Genomes.Clear();
            history.Evaluate(environments, this);
            environments.Sort(SortByScore);// Finish compare
            Debug.Log("max score " + history.maxScore);
            Debug.Log("min score " + history.minScore);
            for (int i = 99; i > (99 - creaturesSurvived); i--)
            {
                if (topGenomeChosen == false)
                {
                    history.bestPerGen.Add(environments[i].creature.genome);
                    Debug.Log("max score if sorted properly " + environments[i].creature.genome.score);
                    topGenomeChosen = true;
                }
                history.top25Genomes.Add(environments[i].creature.genome);
            }
        }

        static int SortByScore(Environment e1, Environment e2)
        {
            return e1.creature.genome.score.CompareTo(e2.creature.genome.score);
        }

        public IEnumerator Simulation()
        {
            for (int i = 0; i < cycles; i++)
            {
                Debug.Log("Cycle: " + (i + 1));
                createEnvironments(history, environments);
                yield return new WaitForSeconds(simulationLength);

                naturalSelection(history, environments);
                destroyEnvironments(environments);
                repopulate(history);
                //Debug.Log("Top Score: " + history.maxScore);
                yield return new WaitForSeconds(1);
            }
            Debug.Log(history.bestPerGen);

            yield return null;
        }

        /* Update is called once per frame
        void Update()
        {

        }
        */



    }


}


