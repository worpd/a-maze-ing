using UnityEngine;
using UnityEngine.UI;

namespace Worpd.aMazeGame.GameManagement
{
    public class MazeSettingsForm : MonoBehaviour
    {
        public GameManager gameManager;
        private Slider slider;
        public void Start()
        {
            slider = GetComponent<Slider>();
        }
        public void OnHeightSettingChange()
        {
            gameManager.SetMazeHeightSetting((int) slider.value);

        }

        public void OnWidthSettingChange()
        {
            gameManager.SetMazeWidthSetting((int) slider.value);
        }
    }
}
