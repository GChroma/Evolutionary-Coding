namespace New_Unity_Project.Assets.Scripts
{

    using UnityEngine;

    [System.Serializable]
    public struct GenomeLeg
    {
        //Sin wave equation s = (M - m)/2 (1 + sin((t + o)2pi/p)) + m
        //where it has period p, range of m to M and is shiften on the X axis by o.
        //this wave dictates how the muscle extends and contracts and therefore how the legs move.
        // t represents the x axis.
        public float m;
        public float M;
        public float o;
        public float p;

        public float EvaluateAt(float time)//use to find position that the leg should be.
        {
            //gives the point on the sin wave at any time.
            return (M - m) / 2 * (1 + Mathf.Sin((time + o) * Mathf.PI * 2 / p)) + m;
        }

        public GenomeLeg Clone()
        {

            GenomeLeg leg = new GenomeLeg();//create a new leg with all the same variables
            leg.m = m;
            leg.M = M;
            leg.o = o;
            leg.p = p;
            return leg;
        }

        public static GenomeLeg CreateRandom()
        {
            GenomeLeg leg = new GenomeLeg();
            leg.m = Random.Range(0f, 1f);
            leg.M = Random.Range(0f, 1f);
            leg.o = Random.Range(0f, 1f);
            leg.p = Random.Range(0f, 1f);
            return leg;
        }

        public void Mutate()
        {//change the values of this leg by a relatively small random amount

            switch (Random.Range(0, 4))
            {
                case 0:
                    m += Random.Range(-0.1f, 0.1f);
                    m = Mathf.Clamp(m, -1f, +1f);
                    break;
                case 1:
                    M += Random.Range(-0.1f, 0.1f);
                    M = Mathf.Clamp(M, -1f, +1f);
                    break;
                case 2:
                    p += Random.Range(-0.25f, 0.25f);
                    p = Mathf.Clamp(p, 0.1f, 2f);
                    break;
                case 3:
                    o += Random.Range(-0.25f, 0.25f);
                    o = Mathf.Clamp(o, -2f, 2f);
                    break;
            }

        }
    }
}