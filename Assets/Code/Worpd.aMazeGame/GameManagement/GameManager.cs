using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Worpd.aMazeGame.MazeGeneration;

namespace Worpd.aMazeGame.GameManagement
{
    internal enum GameState
    {
        MainMenu,
        Playing,
        Paused
    }

    public class GameManager : MonoBehaviour
    {
        public GameObject MazeWallPrefab;
        private string Level { get; set; }
        private MazeManager MazeManager;
        private int MazeHeightSetting = 30;
        private int MazeWidthSetting = 30;
        private GameState State;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            MazeManager = new MazeManager(MazeWallPrefab);
            State = GameState.MainMenu;
        }

        public void SetMazeHeightSetting(int Height)
        {
            MazeHeightSetting = Height * 3;
        }

        public void SetMazeWidthSetting(int Width)
        {
            MazeWidthSetting = Width * 3;
        }

        public void LoadLevel(string lvl)
        {
            Level = lvl;
            StartCoroutine(LoadLevelScene());
        }

        private IEnumerator LoadLevelScene()
        {
            var loading = SceneManager.LoadSceneAsync("Scenes/MazeScene");
            while (!loading.isDone)
                yield return null;

            OnLevelSceneLoaded();
            State = GameState.Playing;
        }

        private void OnLevelSceneLoaded()
        {
            MazeManager.GenerateMaze(MazeHeightSetting, MazeWidthSetting, 3);
        }

        public void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                HandleCancel();
        }

        private void HandleCancel()
        {
            switch (State)
            {
                case GameState.MainMenu:
                    Debug.Log("Detected Cancel From Main Menu. Ignoring.");
                    break;
                case GameState.Playing:
                    Debug.Log("Detected Cancel From Game Screen. Pausing.");
                    SceneManager.LoadSceneAsync("Scenes/MainScene");
                    State = GameState.MainMenu;
                    break;
                case GameState.Paused:
                    Debug.Log("Detected Cancel From Paused Game. Resuming.");
                    State = GameState.Playing;
                    break;
            }
        }
    }
}
