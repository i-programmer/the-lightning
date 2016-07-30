using UnityEngine;
using System.Collections.Generic;

public class AndroidController : MonoBehaviour, IInputController {
    
    private const int MAX_COUNT_TOUCHES = 2;

    public List<Vector3>  OnTouch() {
        List<Vector3> list = new List<Vector3>();

        for (var i = 0; i < Input.touchCount; ++i) {
            var phase = Input.GetTouch(i).phase;
            if (phase == TouchPhase.Stationary || phase == TouchPhase.Moved) {      
                list.Add(Input.GetTouch(i).position); // list.Add(Input.GetTouch(i).deltaPosition);
            }
            if (list.Count >= MAX_COUNT_TOUCHES)
                break;
        }

        return list;   
    }


    public bool IsCursorMoving() {        
        if (Input.GetTouch(0).phase == TouchPhase.Moved) 
            return true;

        return false;
    }


    public bool IsTouchEnd() {
        for (var i = 0; i < Input.touchCount; ++i) {
            var phase = Input.GetTouch(i).phase;
            if (phase == TouchPhase.Ended)
                return true;
        }

        return false;
    }
}
