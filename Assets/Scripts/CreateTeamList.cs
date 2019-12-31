// using System.Collections;
// using UnityEngine;
// using UnityEditor;

// namespace Pokerball
// {
//     public class CreateTeamList 
//     {
//         [MenuItem("Assets/Create/Team List")]
//         public static TeamList Create()
//         {
//             TeamList asset = ScriptableObject.CreateInstance<TeamList>();

//             AssetDatabase.CreateAsset(asset, "Assets/TeamList.asset");
//             AssetDatabase.SaveAssets();
//             return asset;
//         }
//     }
// }