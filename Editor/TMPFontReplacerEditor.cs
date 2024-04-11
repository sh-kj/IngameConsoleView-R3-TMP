using UnityEngine;
using UnityEditor;

namespace radiants.IngameConsole.View
{
	[CustomEditor(typeof(TMPFontReplacer))]
	public class TMPFontReplacerEditor: Editor
	{
		private TMPFontReplacer _Target;
		private TMPFontReplacer Target
		{
			get
			{
				if (_Target == null) _Target = target as TMPFontReplacer;
				return _Target;
			}
		}

		public override void OnInspectorGUI()
		{
			Target.FontAsset =
				EditorGUILayout.ObjectField("Font Asset to replace:", Target.FontAsset, typeof(TMPro.TMP_FontAsset), false) as TMPro.TMP_FontAsset;

			if(GUI.changed)
			{
				EditorUtility.SetDirty(Target);
			}


			if(GUILayout.Button("Execute Replace"))
			{
				if (Target == null) return;

				//replace text
				var texts = Target.GetComponentsInChildren<TMPro.TMP_Text>();
				foreach (var txt in texts)
				{
					txt.font = Target.FontAsset;
					EditorUtility.SetDirty(txt);
				}

				//replace input
				var inputs = Target.GetComponentsInChildren<TMPro.TMP_InputField>();
				foreach (var input in inputs)
				{
					input.fontAsset = Target.FontAsset;
					EditorUtility.SetDirty(input);
				}
			}

		}
	}
}
