using UnityEditor;
using UnityEngine;

public class MobAssetCreate {

	[MenuItem("Assets/Create/CreateMobData")]
	public static void CreateAsset () {
		ScriptableObjectUtility.CreateAsset<MobData> ();
	}
}
