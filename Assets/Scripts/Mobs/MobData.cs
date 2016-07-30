using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MobData : ScriptableObject {

    public string nameMob = "";
    public CreatureType creatureType;
    public float HP = 1;
    public bool rangeHP;
    public float maxHp = 4;
    public Color Color;
    public int points;
    public GameObject particle;    
}
