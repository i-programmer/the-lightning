
using UnityEngine;


public class GameData : ScriptableObject {

    public int startCreaturesCount = 16;
    public int levelTime = 10;
    public float spawnCreatureTime = 1;
    public float damage = 0.01f;
    public float damageDistanceRatio = 0.01f;
    public float levelReducingTimeDefault = 0.01f;
    public float levelReducingTimeDelta = 0.01f;
}

