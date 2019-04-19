using UnityEngine;

namespace Worpd.aMazeGame.GameManagement
{
    public class QuitButton : MonoBehaviour
    {
        public void OnQuit()
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
