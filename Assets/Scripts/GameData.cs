using System;
using UnityEngine;

[Serializable]
public class GameData {
    public int PlayerScore;
    public Vector3 PlayerLocation;
    public Vector3 BotLocation;

    public GameData(int score, Vector3 PlayerLoc, Vector3 BotLoc) {
        PlayerScore = score;
        PlayerLocation = PlayerLoc;
        BotLocation = BotLoc;
    }
}
