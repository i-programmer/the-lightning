using UnityEngine;
using System.Collections.Generic;


public class WinController : MonoBehaviour, IInputController {

    public List<Vector3> OnTouch() {
        List<Vector3> list = new List<Vector3>();

        if (Input.GetMouseButton(0))
            list.Add(Input.mousePosition);
        if (Input.GetKey(KeyCode.LeftShift)) 
            list.Add(new Vector3(Screen.width / (float)2, Random.Range(Screen.height / 4.0f, Screen.height / 1.2f), 0));            

        return list;        
    }


    public bool IsCursorMoving() {
        if (Input.GetKey(KeyCode.LeftShift))
            return true;

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            return true;

        return false;
    }


    public bool IsTouchEnd() {
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.LeftShift)) {
            return true;
        }

        return false;
    }
}
