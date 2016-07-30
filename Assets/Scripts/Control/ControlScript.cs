using System;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

enum TouchType {
    None,
    One,
    Two
}

class ControlScript : MonoBehaviour {

    //public Text debugText;

    public IInputController inputController;
    public GameObject button;
    public GameObject lightning;   

    public GameObject background;
    public DrawLightningScript lightningDrawer;
    public TouchType touchType;

    public List<Vector3> Touches { get; private set; }
    private int countTouches = 0;
    private bool isFirstTouch = true;


    public List<Vector3> listTouches = new List<Vector3>();

    void Start() {
        inputController = GetInputController();        
    }


    // Get one of the controllers depending on platform
    private IInputController GetInputController() {
        RuntimePlatform platform = Application.platform;
        IInputController controller = GetComponent<WinController>();
        
        if(platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
            controller = GetComponent<AndroidController>();
        }

        return controller;
    }


    void Update() {        
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Menu)) {
            GetComponent<GameManager>().ClearScene();
            GameManager.isPaused = true;
            SceneManager.LoadScene("Main");
        }

        if (inputController.IsTouchEnd())        
            lightningDrawer.StopDraw();

        Touches = inputController.OnTouch();

        countTouches = Touches.Count;
        touchType = countTouches == 0 ? TouchType.None : countTouches == 1 ? TouchType.One : TouchType.Two;

        if (countTouches == 0) {            
            isFirstTouch = true;            
            ActivateButton(false);
            lightningDrawer.StopDraw();               
        }

        if (GameManager.isPaused)
            return;

        // Drawing a line following the cursor          
        if (countTouches == 1) {
            // if first touch than shows the lightningBtn
            if (isFirstTouch) {
                ActivateButton(true, Camera.main.ScreenPointToRay(Touches[0]).origin);
            } else {
                ActivateButton(false);
            }

            if (inputController.IsCursorMoving()) {
                isFirstTouch = false;
                lightningDrawer.Draw(Touches[0]);                
            } else {
                lightningDrawer.StopDraw(true);
            }
        // Drawing a line between two points
        } else if (countTouches == 2) {            
            isFirstTouch = false;            
            lightningDrawer.Draw(Touches[0], Touches[1]);
        }
    }


    // Show Lightning Btn
    void ActivateButton(bool visible, Vector3 pos = new Vector3()) {
        button.transform.position = pos;
        button.SetActive(visible);
    }    
}

