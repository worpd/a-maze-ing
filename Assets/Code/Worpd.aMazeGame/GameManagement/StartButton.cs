using UnityEngine;

namespace Worpd.aMazeGame.GameManagement
{
    public class StartButton : MonoBehaviour
    {
        public GameManager gameManager;
        public void OnClick()
        {
            Debug.Log("Start Button Clicked");
            gameManager.LoadLevel("1");
        }
    }
}
