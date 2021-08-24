namespace New_Unity_Project.Assets.Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerSpawner : MonoBehaviour
    {

        public GameObject prefab;
        public Text scoreDisplay;
        public Text timeDisplay;
        public PlayerCreature player;
        float timer;
        float startTime;

        // Start is called before the first frame update
        void Start()
        {
            startTime = 0;
            timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            timer = Time.time - startTime;
            if (timer < 20)
                scoreDisplay.text = "Score: " + player.score;

            timeDisplay.text = "Time: " + timer;


        }

        public void Reset()
        {
            startTime = Time.time;
            GameObject.Destroy(GameObject.FindGameObjectWithTag("Player"));
            GameObject env = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            PlayerEnvironment playerEnvironment = env.GetComponent<PlayerEnvironment>();
            player = playerEnvironment.playerCreature;
        }
    }

}
