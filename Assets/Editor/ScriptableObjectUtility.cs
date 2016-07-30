using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectUtility {
	public static void CreateAsset<T>() where T : ScriptableObject {
		T asset = ScriptableObject.CreateInstance<T>();

		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (path == "") {
			path = "Assets";
		} else if (Path.GetExtension(path) != "") {
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}

		string fileName;
		if (asset is MobData) {
			fileName = "_MobData";
		} else if (asset is GameData) {
			fileName = "_GameData";
		} else if (asset is CreaturesData) {
			fileName = "_CreaturesData";
		} else {
			fileName = typeof(T).ToString();
		}
		
		AssetDatabase.CreateAsset(asset, "Assets/CustomAssetsTemplates/" + fileName + ".asset");

		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
}
