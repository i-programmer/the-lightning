using UnityEditor;


public class CreatureAssetCreate {

	[MenuItem("Assets/Create/CreateCreatureData")]
	public static void CreateAsset () {
		ScriptableObjectUtility.CreateAsset<CreaturesData> ();
	}
}
