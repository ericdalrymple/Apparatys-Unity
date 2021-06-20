using Apparatys.Data;
using UnityEditor;
using UnityEngine;

namespace Apparatys.DataEditor
{
    [CustomPropertyDrawer(typeof(DataId), true)]
    public class DataIdDrawer
        : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            float initialX = position.x;
            float initialWidth = position.width;

            // Draw label
            position.width = EditorGUIUtility.labelWidth;

            EditorGUI.PrefixLabel(position, label);

            // Draw checkbox with tooltip
            position.x = initialX + EditorGUIUtility.labelWidth;
            position.width = EditorGUIUtility.singleLineHeight;

            bool wasEnabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(position, property.ToString());
            GUI.enabled = wasEnabled;

            /*
            SerializedProperty useConstantProperty = property.FindPropertyRelative("useConstant");
            useConstantProperty.boolValue = EditorGUI.Toggle(position, new GUIContent(string.Empty, "Use constant"), useConstantProperty.boolValue);

            position.x = initialX + EditorGUIUtility.labelWidth + EditorGUIUtility.singleLineHeight;
            position.width = initialWidth - (EditorGUIUtility.labelWidth + EditorGUIUtility.singleLineHeight);

            if (useConstantProperty.boolValue)
            {
                SerializedProperty valueProperty = property.FindPropertyRelative("constant");
                EditorGUI.PropertyField(position, valueProperty, new GUIContent(string.Empty));
            }
            else
            {
                SerializedProperty variableProperty = property.FindPropertyRelative("variable");
                EditorGUI.PropertyField(position, variableProperty, new GUIContent(string.Empty));
            }
            */
        }
    }
}
