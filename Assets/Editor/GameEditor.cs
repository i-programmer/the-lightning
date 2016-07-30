using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GameData))]
public class GameEditor : Editor {
	public override void OnInspectorGUI(){
		if (GUILayout.Button("Open Game Editor")) 
			GameEditorWindow.Init();		
	}
}