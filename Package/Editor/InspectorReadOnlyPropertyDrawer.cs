using UnityEditor;
using UnityEngine;

namespace CheesePie.Utils.Editor {

	/// <summary>
	/// Property drawer for a readonly property.
	/// </summary>
	[CustomPropertyDrawer(typeof(InspectorReadOnlyAttribute))]
	public class InspectorReadOnlyPropertyDrawer : PropertyDrawer {

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			bool prevEnabled = GUI.enabled;
			GUI.enabled = false;
			EditorGUI.PropertyField(position, property, label, true);
			GUI.enabled = prevEnabled;
		}
	}
}
