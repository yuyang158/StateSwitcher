using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Extend.Switcher.Action.Editor {
	public abstract class ActionDrawer {
		public abstract void OnEditorGUI(Rect rect, SerializedProperty property);
		public abstract float GetEditorHeight(SerializedProperty property);

		private static readonly Dictionary<Type, ActionDrawer> m_drawers = new Dictionary<Type, ActionDrawer>();

		static ActionDrawer() {
			m_drawers.Add(typeof(AnimatorSwitcherAction), new AnimatorSwitcherActionDrawer());
			m_drawers.Add(typeof(GOActiveSwitcherAction), new GOActiveSwitcherActionDrawer());
			m_drawers.Add(typeof(TextAssignSwitcherAction), new TextAssignSwitcherActionDrawer());
		}

		public static ActionDrawer GetDrawer(Type type) {
			return m_drawers[type];
		}
	}

	public class AnimatorSwitcherActionDrawer : ActionDrawer {
		public override void OnEditorGUI(Rect rect, SerializedProperty property) {
			var processorProperty = property.FindPropertyRelative("Processor");
			EditorGUI.PropertyField(rect, processorProperty);
		}

		public override float GetEditorHeight(SerializedProperty property) {
			var processorProperty = property.FindPropertyRelative("Processor");
			return EditorGUI.GetPropertyHeight(processorProperty);
		}
	}

	public class GOActiveSwitcherActionDrawer : ActionDrawer {
		private static readonly GUIContent m_gameObjectTitle = new GUIContent("GameObject");
		public override void OnEditorGUI(Rect rect, SerializedProperty property) {
			var goProp = property.FindPropertyRelative("GO");
			rect.xMax -= 20;
			rect.height = EditorGUIUtility.singleLineHeight;
			EditorGUI.PropertyField(rect, goProp, m_gameObjectTitle);

			var activeProp = property.FindPropertyRelative("Active");
			var toggleRect = rect;
			toggleRect.xMin = rect.xMax + 7.5f;
			toggleRect.xMax += 20;
			activeProp.boolValue = EditorGUI.Toggle(toggleRect, activeProp.boolValue);
		}

		public override float GetEditorHeight(SerializedProperty property) {
			return Common.Editor.UIEditorUtil.LINE_HEIGHT;
		}
	}

	public class TextAssignSwitcherActionDrawer : ActionDrawer {
		public override void OnEditorGUI(Rect rect, SerializedProperty property) {
			rect.height = EditorGUIUtility.singleLineHeight;
			var textGUIProperty = property.FindPropertyRelative("m_textGUI");
			EditorGUI.PropertyField(rect, textGUIProperty);

			rect.y += Common.Editor.UIEditorUtil.LINE_HEIGHT;
			var textProp = property.FindPropertyRelative("m_text");
			rect.height = Common.Editor.UIEditorUtil.LINE_HEIGHT * 3 - EditorGUIUtility.standardVerticalSpacing;
			textProp.stringValue = EditorGUI.TextField(rect, textProp.stringValue);
		}

		public override float GetEditorHeight(SerializedProperty property) {
			return Common.Editor.UIEditorUtil.LINE_HEIGHT * 4;
		}
	}
}