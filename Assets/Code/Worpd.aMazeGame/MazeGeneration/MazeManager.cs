using System;
using UnityEngine;
using Worpd.aMazeLib.MazeGeneration;
using Worpd.aMazeLib.Core;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace Worpd.aMazeGame.MazeGeneration
{
    [Serializable]
    public class MazeManager
    {
        private readonly GameObject MazeWallPrefab;

        public MazeManager(GameObject MazeWallPrefab)
        {
            this.MazeWallPrefab = MazeWallPrefab;
        }

        public void GenerateMaze(int Height, int Width, int Magnitude)
        {
            GameObject mazeParent = new GameObject();
            mazeParent.name = "Generated Maze";

            Debug.Log(String.Format("Generating ({0},{1}) Maze", Height, Width));

            RandomDirectionMazeBuilder builder = new RandomDirectionMazeBuilder();
            Maze maze = builder.GenerateMaze(Width, Height, new Random(1));

            Point2D entrance = null;

            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    Point2D point = new Point2D(x, y);
                    if (maze.hasWallAt(point))
                    {
                        // y here is actuall z in Unity
                        GameObject wall = Object.Instantiate(
                            MazeWallPrefab,
                            new Vector3(x * Magnitude, 1, y * Magnitude),
                            Quaternion.identity);
                        wall.transform.parent = mazeParent.transform;
                        wall.transform.localScale = new Vector3(1 * Magnitude, 2, 1 * Magnitude);
                        wall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(3, 2);
                    }
                    else if ((point.x == 0 || point.y == 0) && entrance == null)
                    {
                        entrance = point;
                    }
                }
            }

            mazeParent.transform.position = new Vector3(
                -1 * (Width * Magnitude / 2),
                0,
                -1 * (Height * Magnitude / 2));
        }
    }
}
