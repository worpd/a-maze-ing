using UnityEngine;
using Worpd.aMazeLib.MazeGeneration;
using Worpd.aMazeLib.Core;
using Random = System.Random;

namespace Worpd.aMazeGame.MazeGeneration
{
    public class MazeGeneration : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject mazeWallPrefab;
        public GameObject mazeFloorPrefab;
        public int mazeHeight = 51;
        public int mazeWidth = 51;
        public int mazeMagnitude = 1;

        void Start()
        {
            GameObject mazeParent = new GameObject();
            mazeParent.name = "Generated Maze";

            RandomDirectionMazeBuilder builder = new RandomDirectionMazeBuilder();
            Maze maze = builder.GenerateMaze(mazeWidth, mazeHeight, new Random(1));

            GameObject floor = Instantiate(mazeFloorPrefab,
                new Vector3(mazeWidth * mazeMagnitude / 2, 0, mazeHeight * mazeMagnitude / 2), Quaternion.identity);
            floor.transform.localScale = new Vector3(mazeWidth * mazeMagnitude * 2, 1, mazeHeight * mazeMagnitude * 2);
            floor.transform.parent = mazeParent.transform;
            floor.GetComponent<Renderer>().material.mainTextureScale = new Vector2(mazeWidth, mazeHeight);

            Point2D entrance = null;

            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    Point2D point = new Point2D(x, y);
                    if (maze.hasWallAt(point))
                    {
                        // y here is actuall z in Unity
                        GameObject wall = Instantiate(mazeWallPrefab,
                            new Vector3(x * mazeMagnitude, 1, y * mazeMagnitude), Quaternion.identity);
                        wall.transform.parent = mazeParent.transform;
                        wall.transform.localScale = new Vector3(1 * mazeMagnitude, 2, 1 * mazeMagnitude);
                        wall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(3, 2);
                    }
                    else if ((point.x == 0 || point.y == 0) && entrance == null)
                    {
                        entrance = point;
                    }
                }
            }

            mazeParent.transform.position = new Vector3(-1 * (mazeWidth * mazeMagnitude / 2), 0,
                -1 * (mazeHeight * mazeMagnitude / 2));
            GameObject player = Instantiate(
                playerPrefab,
                new Vector3((mazeWidth * mazeMagnitude), 1, 0),
                Quaternion.identity);
        }
    }
}
