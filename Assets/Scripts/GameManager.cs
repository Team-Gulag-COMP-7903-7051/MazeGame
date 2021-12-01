using UnityEngine;

[SerializeField]
public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bot;

    private BotMovement _botMvmt;

    private void Awake() {
        _botMvmt = _bot.GetComponent<BotMovement>();
        LoadGame();
    }

    public void SaveGame() {
        int score = _botMvmt.PlayerScore;
        Vector3 playerLocation = _player.transform.position;
        Vector3 botLocation = _botMvmt.transform.position;
        GameData data = new GameData(score, playerLocation, botLocation);

        SaveManager.SaveData(data);
    }

    public void LoadGame() {
        GameData data = SaveManager.LoadData();
        
        if (data != null) {
            _botMvmt.PlayerScore = data.PlayerScore;
            _botMvmt.transform.position = data.BotLocation;
            _player.transform.position = data.PlayerLocation;

            print(data.PlayerScore);
            print(data.BotLocation);
            print(data.PlayerLocation);
        }
    }
}
