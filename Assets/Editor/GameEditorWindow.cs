using UnityEngine;
using UnityEditor;


class GameEditorWindow : EditorWindow {

    public static GameEditorWindow gameEditorWindow;
    private GameData gameData;

    [MenuItem("Window/TestTaskIceCat/Game Editor")]
	public static void Init() {
		gameEditorWindow = GetWindow<GameEditorWindow>(false, "Game Editor", true);
		gameEditorWindow.Show();
	}


    void OnSelectionChange(){
		Populate();		
	}


    private void Populate() {
		Object[] selection = Selection.GetFiltered(typeof(GameData), SelectionMode.Assets);
		if (selection.Length > 0){
			if (selection[0] == null) return;
			gameData = (GameData) selection[0];
		}
    }

    void OnEnable(){
		Populate();
	}
	
	void OnFocus(){
		Populate();
	}
	

    public void OnGUI() {  
        if (gameData == null)
            return;
              
        GUIStyle fontStyle = new GUIStyle();
		
		fontStyle.fontSize = 20;
		fontStyle.alignment = TextAnchor.UpperCenter;
		fontStyle.normal.textColor = Color.white;
		fontStyle.hover.textColor = Color.white;
		
        EditorGUILayout.BeginVertical();{
			EditorGUILayout.BeginHorizontal();{
				EditorGUILayout.LabelField("", ("Game Data") , fontStyle, GUILayout.Height(32));
				
			}EditorGUILayout.EndHorizontal();
		}EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical();{				
				EditorGUILayout.BeginVertical();{
					EditorGUILayout.Space();
					EditorGUI.indentLevel += 1;
					EditorGUIUtility.labelWidth = 210;

					EditorGUILayout.Space();                        
                    gameData.startCreaturesCount = EditorGUILayout.IntField("Start creatures count:", gameData.startCreaturesCount);
                    gameData.levelTime = EditorGUILayout.IntField("Level time:", gameData.levelTime);
                    gameData.spawnCreatureTime = EditorGUILayout.FloatField("Spawn creature time (seconds):", gameData.spawnCreatureTime);						
                    gameData.damage = EditorGUILayout.FloatField("Damage:", gameData.damage);						
                    gameData.damageDistanceRatio = EditorGUILayout.FloatField("Damage distance ratio:", gameData.damageDistanceRatio);						
                    gameData.levelReducingTimeDefault = EditorGUILayout.FloatField("Level Reducing Time Default:", gameData.levelReducingTimeDefault);						
                    gameData.levelReducingTimeDelta = EditorGUILayout.FloatField("Level Reducing Time Delta:", gameData.levelReducingTimeDelta);						
												
					EditorGUI.indentLevel -= 1;
					EditorGUILayout.Space();
				}EditorGUILayout.EndVertical();
				
		}EditorGUILayout.EndVertical();
		
		if (GUI.changed) {
			Undo.RecordObject(gameData, "Game Data Modify");
			EditorUtility.SetDirty(gameData);
		}
    }
}
