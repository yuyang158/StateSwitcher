using UnityEditor;
using UnityEngine;

namespace Extend.Common.Editor {
	public static class UIEditorUtil {
		public static readonly float LINE_HEIGHT = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
		
		public static Rect CalcMultiColumnRect(Rect position, int index, int totalColumn) {
			var rect = position;
			rect.width /= totalColumn;
			rect.x += rect.width * index;
			return rect;
		}
	}
}