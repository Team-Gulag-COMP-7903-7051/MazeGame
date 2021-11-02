using UnityEngine;

public class MazeRenderer : MonoBehaviour {
    [SerializeField] [Range(1, 50)] private int _height = 10;
    [SerializeField] [Range(1, 50)] private int _width = 10;
    [SerializeField] [Range(0, 50)] private int _additionalBots;
    [SerializeField] private float _size = 1.0f;
    [SerializeField] private Transform _wallPrefabNorthSouth = null;
    [SerializeField] private Transform _wallPrefabEastWest = null;
    [SerializeField] private Transform _floorPrefab = null;
    [SerializeField] private Transform _winFloorPrefab = null;
    [SerializeField] private GameObject _bot = null;
    

    void Start() {
        var maze = MazeGenerator.Generate(_width, _height);
        Draw(maze);

        for(int i = 0; i < _additionalBots; i++) {
            float x = Random.Range(-4.5f, 4.5f);
            float y = Random.Range(0.15f, 0.3f);
            float z = Random.Range(-4.5f, 4.5f);
            Instantiate(_bot, new Vector3(x, y, z), Quaternion.identity);
        }
    }

    private void Draw(WallState[,] maze) {
        var floor = Instantiate(_floorPrefab, transform);
        floor.localScale = new Vector3(_width, 1, _height);

        for (int i = 0; i < _width; i++) {
            for (int j = 0; j < _height; j++) {
                var cell = maze[i, j];
                var position = new Vector3(-_width/2 + i, 0, -_height/2 + j);

                if (cell.HasFlag(WallState.UP)) {
                    var topWall = Instantiate(_wallPrefabNorthSouth, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, _size/2);
                    topWall.localScale = new Vector3(_size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT)) {
                    var leftWall = Instantiate(_wallPrefabEastWest, transform) as Transform;
                    leftWall.position = position + new Vector3(-_size/2, 0, 0);
                    leftWall.localScale = new Vector3(_size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0,90,0);
                }

                if (i == _width - 1) {
                    if (cell.HasFlag(WallState.RIGHT)) {
                        var rightWall = Instantiate(_wallPrefabEastWest, transform) as Transform;
                        rightWall.position = position + new Vector3(_size/2, 0, 0);
                        rightWall.localScale = new Vector3(_size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0) {
                    if (cell.HasFlag(WallState.DOWN)) {
                        var bottomWall = Instantiate(_wallPrefabNorthSouth, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -_size/2);
                        bottomWall.localScale = new Vector3(_size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }

        //Random winning Tile
        var rng = Random.Range(-_width, _width);
        var winPosition = new Vector3(rng/2, 0, -5f);
        var winFloor = Instantiate(_winFloorPrefab, transform) as Transform;
        winFloor.position = winPosition;
    }
}
