using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    public int wood;
    public int stone;

    public GameData()
    {
        this.gold = 0;
        this.wood = 0;
        this.stone = 0;
    }
}