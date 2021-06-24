namespace New_Unity_Project.Assets.Scripts
{

    using UnityEngine;
    public struct Genome
    {
        public GenomeLeg left;
        public GenomeLeg right;

        public Genome Clone()
        {
            Genome genome = new Genome();
            genome.left = left.Clone();//use clone method in Genome Leg to clone it.
            genome.right = right.Clone();
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