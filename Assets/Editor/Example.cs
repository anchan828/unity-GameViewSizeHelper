using UnityEngine;
using UnityEditor;
public class Example : EditorWindow
{
		[MenuItem("Window/GameViewSizeHelper")]
		static void Open ()
		{
				GetWindow<Example> ();
		}
		string baseText = "";
		int width, height;
		GameViewSizeHelper.GameViewSizeType gameViewSizeType = GameViewSizeHelper.GameViewSizeType.AspectRatio;
		GameViewSizeGroupType gameViewSizeGroupType = GameViewSizeGroupType.Standalone;
		
		void OnGUI ()
		{
				GUILayout.Label ("プラットフォーム");
				gameViewSizeGroupType = (GameViewSizeGroupType)EditorGUILayout.EnumPopup (gameViewSizeGroupType);
				GUILayout.Label ("サイズタイプ");
				gameViewSizeType = (GameViewSizeHelper.GameViewSizeType)EditorGUILayout.EnumPopup (gameViewSizeType);
				baseText = EditorGUILayout.TextField ("名前", baseText);
				EditorGUILayout.BeginHorizontal ();
				GUILayout.Label ("幅");
				width = EditorGUILayout.IntField (width);
				GUILayout.Label ("高さ");
				height = EditorGUILayout.IntField (height);
				EditorGUILayout.EndHorizontal ();
				if (GUILayout.Button ("追加")) {
						if (!GameViewSizeHelper.Contains (gameViewSizeGroupType, gameViewSizeType, width, height, baseText))
								GameViewSizeHelper.AddCustomSize (gameViewSizeGroupType, gameViewSizeType, width, height, baseText);
						GameViewSizeHelper.ChangeGameViewSize (gameViewSizeGroupType, gameViewSizeType, width, height, baseText);
				}
				if (GUILayout.Button ("削除")) {
						if (GameViewSizeHelper.Contains (gameViewSizeGroupType, gameViewSizeType, width, height, baseText))
								GameViewSizeHelper.RemoveCustomSize (gameViewSizeGroupType, gameViewSizeType, width, height, baseText);
				}
		}
}