using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Button))]
public class ButtonDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        Button settings = (Button) attribute;
        return DisplayButton(ref settings) ? EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing : 0;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Button settings = (Button) attribute;
    
        if (!DisplayButton(ref settings)) return;
    
        string buttonLabel = (!string.IsNullOrEmpty(settings.customLabel)) ? settings.customLabel : label.text;

        if (property.serializedObject.targetObject is MonoBehaviour mb)
        {
            if (GUI.Button(position, buttonLabel))
            {
                mb.SendMessage(settings.methodName, settings.methodParameter);
            }
        }
    }
    
    private bool DisplayButton(ref Button settings)
    {
        return (settings.displayIn == Button.DisplayIn.PlayAndEditModes) ||
               (settings.displayIn == Button.DisplayIn.EditMode && !Application.isPlaying) ||
               (settings.displayIn == Button.DisplayIn.PlayMode && Application.isPlaying);
    }
}