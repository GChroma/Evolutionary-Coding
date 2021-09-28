namespace New_Unity_Project.Assets.Scripts
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Menu : MonoBehaviour
    {

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
        public void BackToMenu()
        {
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene(0);

        }
        public void Pause()
        {
            Time.timeScale = 0;
        }
        public void Unpause()
        {
            Time.timeScale = 1;
        }
        public void Exit()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }

}
