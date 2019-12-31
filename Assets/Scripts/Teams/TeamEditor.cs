// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// namespace Pokerball{
// public class TeamEditor : EditorWindow
// {
//     public TeamList teamList;
//     private int viewIndex = 1;

//     [MenuItem ("Window/Team Editor %#e")]
//     static void Init ()
//     {
//         EditorWindow.GetWindow(typeof (TeamEditor));
//     }

//     void OnEnable () 
//     {
//         if(EditorPrefs.HasKey("ObjectPath"))
//         {
//             string objectPath = EditorPrefs.GetString("ObjectPath");
//             teamList = AssetDatabase.LoadAssetAtPath (objectPath, typeof(TeamList)) as TeamList;
//         }
//     }

// void  OnGUI () {
//         GUILayout.BeginHorizontal ();
//         GUILayout.Label ("Team Editor", EditorStyles.boldLabel);
//         if (teamList != null) {
//             if (GUILayout.Button("Show Team List")) 
//             {
//                 EditorUtility.FocusProjectWindow();
//                 Selection.activeObject = teamList;
//             }
//         }
//         if (GUILayout.Button("Open Team List")) 
//         {
//                 OpenTeamList();
//         }
//         if (GUILayout.Button("New Team List")) 
//         {
//             EditorUtility.FocusProjectWindow();
//             Selection.activeObject = teamList;
//         }
//         GUILayout.EndHorizontal ();

//         if (teamList == null) 
//         {
//             GUILayout.BeginHorizontal ();
//             GUILayout.Space(10);
//             if (GUILayout.Button("Create New Team List", GUILayout.ExpandWidth(false))) 
//             {
//                 CreateNewTeamList();
//             }
//             if (GUILayout.Button("Open Existing Team List", GUILayout.ExpandWidth(false))) 
//             {
//                 OpenTeamList();
//             }
//             GUILayout.EndHorizontal ();
//         }

//             GUILayout.Space(20);

//         if (teamList != null) 
//         {
//             GUILayout.BeginHorizontal ();

//             GUILayout.Space(10);

//             if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false))) 
//             {
//                 if (viewIndex > 1)
//                     viewIndex --;
//             }
//             GUILayout.Space(5);
//             if (GUILayout.Button("Next", GUILayout.ExpandWidth(false))) 
//             {
//                 if (viewIndex < TeamList.teamList.Count) 
//                 {
//                     viewIndex ++;
//                 }
//             }

//             GUILayout.Space(60);

//             if (GUILayout.Button("Add Team", GUILayout.ExpandWidth(false))) 
//             {
//                 AddTeam();
//             }
//             if (GUILayout.Button("Delete Team", GUILayout.ExpandWidth(false))) 
//             {
//                 DeleteItem(viewIndex - 1);
//             }

//             GUILayout.EndHorizontal ();
//             if (TeamList.teamList == null)
//                 Debug.Log("wtf");
//             if (TeamList.teamList.Count > 0) 
//             {
//                 GUILayout.BeginHorizontal ();
//                 viewIndex = Mathf.Clamp (EditorGUILayout.IntField ("Current Team", viewIndex, GUILayout.ExpandWidth(false)), 1, TeamList.teamList.Count);
//                 //Mathf.Clamp (viewIndex, 1, TeamList.teamList.Count);
//                 EditorGUILayout.LabelField ("of " +  TeamList.teamList.Count.ToString() + " teams", "", GUILayout.ExpandWidth(false));
//                 GUILayout.EndHorizontal ();

//                 GUILayout.Space(10);

//                 GUILayout.BeginHorizontal ();
//                 TeamList.teamList[viewIndex-1].school = EditorGUILayout.TextField("School", TeamList.teamList[viewIndex-1].school as string);
//                 TeamList.teamList[viewIndex-1].shortname = EditorGUILayout.TextField ("Short Name", TeamList.teamList[viewIndex-1].shortname as string, GUILayout.ExpandWidth(false));
//                 TeamList.teamList[viewIndex-1].teamName = EditorGUILayout.TextField ("Team Name", TeamList.teamList[viewIndex-1].teamName as string);
//                 TeamList.teamList[viewIndex-1].conference = EditorGUILayout.TextField("Conference", TeamList.teamList[viewIndex-1].conference as string);
//                 TeamList.teamList[viewIndex-1].sprite = EditorGUILayout.ObjectField("Sprite", TeamList.teamList[viewIndex-1].sprite, typeof(Sprite),  false) as Sprite;
//                 GUILayout.EndHorizontal ();

//                 GUILayout.Space(10);

//             } 
//             else 
//             {
//                 GUILayout.Label ("This Team List is Empty.");
//             }
//         }
//         if (GUI.changed) 
//         {
//             EditorUtility.SetDirty(teamList);
//         }
//     }

//     void CreateNewTeamList () 
//     {
//         // There is no overwrite protection here!
//         // There is No "Are you sure you want to overwrite your existing object?" if it exists.
//         // This should probably get a string from the user to create a new name and pass it ...
//         viewIndex = 1;
//         teamList = CreateTeamList.Create();
//         if (teamList) 
//         {
//             TeamList.teamList = new List<Team>();
//             string relPath = AssetDatabase.GetAssetPath(teamList);
//             EditorPrefs.SetString("ObjectPath", relPath);
//         }
//     }

//     void OpenTeamList () 
//     {
//         string absPath = EditorUtility.OpenFilePanel ("Select Team List", "", "");
//         if (absPath.StartsWith(Application.dataPath)) 
//         {
//             string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
//             teamList = AssetDatabase.LoadAssetAtPath (relPath, typeof(TeamList)) as TeamList;
//             if (TeamList.teamList == null)
//                 TeamList.teamList = new List<Team>();
//             if (teamList) {
//                 EditorPrefs.SetString("ObjectPath", relPath);
//             }
//         }
//     }

//     void AddTeam () 
//     {
//         Team newTeam = new Team();
//         newTeam.teamName = "New Item";
//         TeamList.teamList.Add(newTeam);
//         viewIndex = TeamList.teamList.Count;
//     }

//     void DeleteItem (int index) 
//     {
//         TeamList.teamList.RemoveAt (index);
//     }
// }
// }