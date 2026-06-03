using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    public int wood;
    public int stone;
    public Vector3 playerPosition;

    public GameData()
    {
        this.gold = 0;
        this.wood = 0;
        this.stone = 0;
        this.playerPosition = new Vector3(138.2893f, 0.47f, 109.0063f);
    }
}