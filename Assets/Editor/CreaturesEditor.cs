using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CreaturesData))]
public class CreaturesEditor : Editor {
	public override void OnInspectorGUI(){
		if (GUILayout.Button("Open Creatures Editor")) 
			CreaturesEditorWindow.Init();		
	}
}