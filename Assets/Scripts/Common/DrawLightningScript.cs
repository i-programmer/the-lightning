using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DrawLightningScript : MonoBehaviour {

    public GameObject lightning;

    public List<GameObject> lightningList;
    private List<Vector3> pointsList;
    private const int MAX_POINTS_COUNT = 25;
    private Vector3 touchPos;
    
    void Awake() {       
        pointsList = new List<Vector3>();
    }


    void Update() {
        if (pointsList.Count >= MAX_POINTS_COUNT && lightningList.Count > 1) {
            Clear(0);
        }
    }


    // multiple drawing (line drawing)
    public void Draw(Vector3 position) {
        touchPos = Camera.main.ScreenToWorldPoint(position);
        touchPos.z = 0;
        if (!pointsList.Contains(touchPos)) {
            pointsList.Add(touchPos);
           
            GameObject li = Instantiate(lightning, touchPos, Quaternion.identity) as GameObject;
            if (li != null) {
                li.GetComponent<LightningBoltScriptExt>().isLightningTypeSimple = false;           

                li.SetActive(true);
                lightningList.Add(li);
                if (lightningList.Count > 1) {
                    li.GetComponent<LightningBoltScriptExt>().StartObject.transform.position = touchPos;
                    li.GetComponent<LightningBoltScriptExt>().EndObject.transform.position = lightningList[lightningList.Count - 2].GetComponent<LightningBoltScriptExt>().StartObject.transform.position;
                }
            }
        }
    }


    // single drawing (from one point to another)
    public void Draw(Vector3 position1, Vector3 position2) {
        var pos1 = Camera.main.ScreenToWorldPoint(position1);
        var pos2 = Camera.main.ScreenToWorldPoint(position2);

        pointsList = Helper.GetLineEquation(pos1, pos2);
        if (lightningList.Count == 0) {
            GameObject li = Instantiate(lightning, pos1, Quaternion.identity) as GameObject;
            lightningList.Add(li);
            lightningList[0].SetActive(true);
        } else {
            if (lightningList.Count > 1) {
                StopDraw();
            } else {
                lightningList[0].GetComponent<LightningBoltScriptExt>().StartObject.transform.position = pos1;
                lightningList[0].GetComponent<LightningBoltScriptExt>().EndObject.transform.position = pos2;
            }
        }
    }


    public void StopDraw(bool smooth) {
        if (pointsList.Count > 0) {
            Clear(0);
        }
    }


    public void StopDraw() {
        if (lightningList.Count > 0) {
            for (int i = 0; i < lightningList.Count; i++) {
                Destroy(lightningList[i]);
            }
        }
        pointsList.Clear();
        lightningList.Clear();        
    }


    public List<Vector3> GetPointsList() {
        return pointsList;
    }


    void Clear(int index) {
        pointsList.RemoveAt(index);
        if (lightningList.Count > 0) {            
            Destroy(lightningList[index]);
            lightningList.RemoveAt(index);
        }
    }    
}