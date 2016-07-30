using UnityEngine;
using UnityEditor;


class MobEditorWindow : EditorWindow {

    public static MobEditorWindow mobEditorWindow;
    public static MobData sentMobData;
    private MobData mobData;

    bool rangeHPBtn;

    [MenuItem("Window/TestTaskIceCat/Mob Editor")]
	public static void Init() {
		mobEditorWindow = GetWindow<MobEditorWindow>(false, "Mob Editor", true);
		mobEditorWindow.Show();
        mobEditorWindow.Populate();
    }


    void OnSelectionChange(){
		Populate();
        Repaint();
    }


    private void Populate() {

        if (sentMobData != null) {
            EditorGUIUtility.PingObject(sentMobData);
            Selection.activeObject = sentMobData;
            sentMobData = null;
        }

        Object[] selection = Selection.GetFiltered(typeof(MobData), SelectionMode.Assets);
		if (selection.Length > 0){
			if (selection[0] == null) return;
			mobData = (MobData) selection[0];
		}
        
    }

    void OnEnable(){
		Populate();
	}
	
	void OnFocus(){
		Populate();
	}
	

    public void OnGUI() {
        if (mobData == null) {
            GUILayout.BeginHorizontal("GroupBox");
            GUILayout.Label("Select a Mob Data file or create a new Mob Data.", "CN EntryInfo");
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("Create new Mob Data"))
                ScriptableObjectUtility.CreateAsset<MobData>();

            return;
        }

        GUIStyle fontStyle = new GUIStyle();
		
		fontStyle.fontSize = 20;
		fontStyle.alignment = TextAnchor.UpperCenter;
		fontStyle.normal.textColor = Color.white;
		fontStyle.hover.textColor = Color.white;
		
        EditorGUILayout.BeginVertical();{
			EditorGUILayout.BeginHorizontal();{
				EditorGUILayout.LabelField("", (mobData.nameMob.Equals("") ? "Mob Data" : "Mob Data (" + mobData.nameMob + ")") , fontStyle, GUILayout.Height(32));
				
			}EditorGUILayout.EndHorizontal();
		}EditorGUILayout.EndVertical();


        EditorGUILayout.BeginVertical();{				
				EditorGUILayout.BeginVertical();{
					EditorGUILayout.Space();
					EditorGUI.indentLevel += 1;
					EditorGUIUtility.labelWidth = 110;

					EditorGUILayout.Space();
				    mobData.nameMob = EditorGUILayout.TextField("Name", mobData.nameMob);
                    mobData.HP = EditorGUILayout.FloatField("HP:", mobData.HP);
                    mobData.rangeHP = EditorGUILayout.Toggle("Range HP", mobData.rangeHP);
                    if (mobData.rangeHP)
                        mobData.maxHp = EditorGUILayout.FloatField("Max HP:", mobData.maxHp);				        

                    mobData.points = EditorGUILayout.IntField("Points:", mobData.points);                    

				    mobData.creatureType = (CreatureType)EditorGUILayout.EnumPopup("Creature type:", mobData.creatureType);                        
                    mobData.Color = EditorGUI.ColorField(new Rect(3, 165, position.width - 6, 15), "Color:",  mobData.Color);
                    mobData.particle = (GameObject) EditorGUI.ObjectField(new Rect(3, 185, position.width - 6, 20), "particle", mobData.particle, typeof(GameObject), false);

					EditorGUI.indentLevel -= 1;
					EditorGUILayout.Space();
				}EditorGUILayout.EndVertical();
				
		}EditorGUILayout.EndVertical();
		
		if (GUI.changed) {
			Undo.RecordObject(mobData, "Mob Data Modify");
			EditorUtility.SetDirty(mobData);
		}
    }
}
