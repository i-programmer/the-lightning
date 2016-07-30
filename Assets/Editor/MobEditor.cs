using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MobData))]
public class MobEditor : Editor {
	public override void OnInspectorGUI(){
		if (GUILayout.Button("Open Mob Editor")) 
			MobEditorWindow.Init();		
	}
}