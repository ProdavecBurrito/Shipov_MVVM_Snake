using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shipov_Snake
{
    internal class GameSpeed
    {
        public void StopGame()
        {
            Time.timeScale = 0.0f;
        }

        public void RestartGame()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        }
    }
}
