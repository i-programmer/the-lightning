using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
        
	public GameData gameData;
    public float spawnCreatureTimeTmp = 0;
    public float levelReducingTime = 0;

    public List<Creature> creatureList;
    public GameObject lightningDrawer;
    public Text pointsUI;
    public Text TimerUI;
    public static bool isPaused = false;

    private int clockSpeed = 1;  
    private bool isGameOver = false;    
    private static int points = 0;
    

    private SpawnCreature spawnCreature;
    private ControlScript controlScript;
    private GameObject background;
    private DrawLightningScript drawLightningScript;
    private LevelUIControlScript levelUIControlScript;

	void Start () {
        Application.runInBackground = false;
        ResetGame();
        spawnCreatureTimeTmp = gameData.spawnCreatureTime;
	    levelReducingTime = gameData.levelReducingTimeDefault;

        spawnCreature = GetComponent<SpawnCreature>();
	    controlScript = GetComponent<ControlScript>();
        drawLightningScript = lightningDrawer.GetComponent<DrawLightningScript>();
        background = GameObject.Find("Bg").gameObject;
        levelUIControlScript = GameObject.Find("Game/LevelUI").gameObject.GetComponent<LevelUIControlScript>();
	    Setup();	    

        InvokeRepeating("LevelClock", 0, clockSpeed);
        //InvokeRepeating("RespawnCreatures", 0, gameData.spawnCreatureTime);
	}


    private void Update () {        
        if (isGameOver) {
            isPaused = true;
            SetGameOver();
            return;
        }

        if (isPaused) {
            OnPause();
            return;
        } else
            OnUnpause();

        spawnCreatureTimeTmp -= Time.deltaTime + levelReducingTime;
        if (spawnCreatureTimeTmp <= 0) {
            spawnCreatureTimeTmp = gameData.spawnCreatureTime;            
            levelReducingTime += gameData.levelReducingTimeDelta;            
            RespawnCreatures();
        }

        RefreshCreatureList();
	    RefreshPointsUI();

        if (drawLightningScript.GetPointsList().Count > 0) {
	        var pointsList = drawLightningScript.GetPointsList();
	        var points = pointsList.Count;
	        for (int i = 0; i < points; ++i) {
	            for (int j = 0; j < creatureList.Count; ++j) {
	                Creature creature = creatureList[j];	                
                    if (creature.boxCollider2D == null)
                        return;

                    float enemySize = creature.boxCollider2D.size.x * creature.Size;
                    
	                if (pointsList[i].x > creature.position.x - enemySize / 2 && pointsList[i].x < creature.position.x + enemySize / 2 &&
	                    pointsList[i].y > creature.position.y - enemySize / 2 && pointsList[i].y < creature.position.y + enemySize / 2) {
                        
                        // the greater the distance, the greater damage
	                    if (controlScript.touchType == TouchType.Two) {
                            var touches = controlScript.Touches;
                            var distance = Vector3.Distance(Camera.main.ScreenPointToRay(touches[0]).origin, Camera.main.ScreenPointToRay(touches[1]).origin);
	                        creature.SetDamage(gameData.damage + (distance * gameData.damageDistanceRatio));
	                        return;
	                    }
                       
	                    creature.SetDamage(gameData.damage);
	                }
	            }
	        }
	    }
	}


    public void RestartGame() {            
        levelUIControlScript.RestartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public static int GetPoints() {
        return points;
    }


    public static void SetPoints(int _points) {
        points += _points;
    }


    void OnPause() {        
        levelUIControlScript.PauseMenu();       
    }


    void OnUnpause() {
        levelUIControlScript.ResumeGame();     
    }

    
    void ResetPoints() {
        points = 0;
    }


    // Game Start Setup
    void Setup() {
        ResizeBgToScreen();        
        TimerUI.text = (gameData.levelTime + 1).ToString();

        for (int i = 0; i < gameData.startCreaturesCount; i++) {
	        creatureList.Add(spawnCreature.Create());
	    }        
    }


    void SetPause() {        
        isPaused = !isPaused;        
        Time.timeScale = isPaused ? 0 : 1;

        var audio = GetComponent<AudioSource>();
        if (isPaused)
            audio.Pause();
        else
            audio.Play();
    }

    
    void LevelClock() {        
        int levelTime = Int32.Parse(TimerUI.text);
        levelTime--;
        TimerUI.text = levelTime.ToString();

        if (levelTime <= 0) {                      
            isGameOver = true;
        }
    }


    void SetGameOver() {
        CancelInvoke("RespawnCreatures");
        CancelInvoke("LevelClock");        
        TimerUI.text = "0";

        if (creatureList.Count > 0) { 
            for (int i = 0; i < creatureList.Count; i++) {            
                creatureList[i].Speed = 9999;
            }            
        }        
        GameObject.Find("Game/LevelUI/PauseMenu").gameObject.SetActive(false);                    
        levelUIControlScript.GameOverMenu(points);
    }


    void ResizeBgToScreen() {
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        var bgSpriteRenderer = background.GetComponent<SpriteRenderer>();

        background.transform.localScale = new Vector3(worldScreenWidth / bgSpriteRenderer.sprite.bounds.size.x, worldScreenHeight / bgSpriteRenderer.sprite.bounds.size.y, 1);
    }


    void RefreshCreatureList() {
        creatureList.RemoveAll(item => item == null);
    }


    void RefreshPointsUI() {
        pointsUI.text = points.ToString();
    }


    void ResetGame() {
        ResetPoints();
        isGameOver = false;
        isPaused = false;
        Time.timeScale = 1;
    }


    public void ClearScene() {
        foreach (var creature in creatureList) {
            Destroy(creature);
        }
        creatureList.Clear(); 
    }


    void RespawnCreatures() {
        creatureList.Add(spawnCreature.Create());
    }


    void OnApplicationFocus(bool focusStatus) {
        if (!focusStatus)
            SetPause();        
    }
}
