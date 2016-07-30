using UnityEditor;
using UnityEngine;

public class GameAssetCreate {

	[MenuItem("Assets/Create/CreateGameData")]
	public static void CreateAsset () {
		ScriptableObjectUtility.CreateAsset<GameData>();
	}
}
