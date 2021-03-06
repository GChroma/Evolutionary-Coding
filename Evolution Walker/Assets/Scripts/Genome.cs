namespace New_Unity_Project.Assets.Scripts
{

    using UnityEngine;
    public class Genome//contains both legs, acts as a specific species/version of the species.
    {
        public GenomeLeg left;
        public GenomeLeg right;
        public float score;

        public Genome Clone()
        {
            Genome genome = new Genome();
            genome.left = left.Clone();//use clone method in Genome Leg to clone it.
            genome.right = right.Clone();
            return genome;
        }
        public static Genome CreateRandom()//create a random genome
        {
            Genome genome = new Genome();
            genome.left = GenomeLeg.CreateRandom();
            genome.right = GenomeLeg.CreateRandom();
            return genome;

        }

        public void Mutate()
        {
            if (Random.Range(0f, 1f) > 0.5f)
                left.Mutate();
            else
                right.Mutate();
        }
    }
}