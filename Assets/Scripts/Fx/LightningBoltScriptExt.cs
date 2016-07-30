using UnityEngine;
using System.Collections;
using DigitalRuby.LightningBolt;

public class LightningBoltScriptExt : LightningBoltScript {

    public bool isLightningTypeSimple = false;

    void Update() {
        base.Update();

        if (!isLightningTypeSimple) {
            Generations = 1;
            Duration = 0.088f;
            ChaosFactor = 0f;
        }        
    }
}