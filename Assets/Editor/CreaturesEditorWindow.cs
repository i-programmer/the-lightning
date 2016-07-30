using UnityEngine;
using UnityEditor;


class CreaturesEditorWindow : EditorWindow {

    public static CreaturesEditorWindow creaturesEditorWindow;
    private CreaturesData creaturesData;

    [MenuItem("Window/TestTaskIceCat/Creatures Editor")]
	public static void Init() {
		creaturesEditorWindow = GetWindow<CreaturesEditorWindow>(false, "Creatures Editor", true);
		creaturesEditorWindow.Show();
	}


    void OnSelectionChange(){
		Populate();		
	}


    private void Populate() {
		Object[] selection = Selection.GetFiltered(typeof(CreaturesData), SelectionMode.Assets);
		if (selection.Length > 0){
			if (selection[0] == null) return;
			creaturesData = (CreaturesData) selection[0];
		}
    }

    void OnEnable(){
		Populate();
	}
	
	void OnFocus(){
		Populate();
	}
	

    public void OnGUI() {    
        if (creaturesData == null)    
            return;

        GUIStyle fontStyle = new GUIStyle();
		
		fontStyle.fontSize = 20;
		fontStyle.alignment = TextAnchor.UpperCenter;
		fontStyle.normal.textColor = Color.white;
		fontStyle.hover.textColor = Color.white;
		
        EditorGUILayout.BeginVertical();{
			EditorGUILayout.BeginHorizontal();{
				EditorGUILayout.LabelField("", ("Creatures Data") , fontStyle, GUILayout.Height(32));
				
			}EditorGUILayout.EndHorizontal();
		}EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical();{				
				EditorGUILayout.BeginVertical();{
					EditorGUILayout.Space();
					EditorGUI.indentLevel += 1;
					EditorGUIUtility.labelWidth = 210;

					EditorGUILayout.Space();    
                    creaturesData.destroyTime = EditorGUILayout.FloatField("Destroy time:", creaturesData.destroyTime);;
                    creaturesData.changeDirectionTime = EditorGUILayout.FloatField("Change direction time:", creaturesData.changeDirectionTime);
                    creaturesData.MinHp = EditorGUILayout.FloatField("Min hp for death:", creaturesData.MinHp);
                    creaturesData.sizeFactor = EditorGUILayout.FloatField("Size factor:", creaturesData.sizeFactor);
                    creaturesData.speedFactor = EditorGUILayout.FloatField("Speed factor:", creaturesData.speedFactor);
                    creaturesData.speedAcceleration = EditorGUILayout.FloatField("Speed acceleration:", creaturesData.speedAcceleration);
                    
					EditorGUI.indentLevel -= 1;
					EditorGUILayout.Space();
				}EditorGUILayout.EndVertical();
				
		}EditorGUILayout.EndVertical();		
		
		if (GUI.changed) {
			Undo.RecordObject(creaturesData, "Creatures Data Modify");
			EditorUtility.SetDirty(creaturesData);
		}
    }
}
