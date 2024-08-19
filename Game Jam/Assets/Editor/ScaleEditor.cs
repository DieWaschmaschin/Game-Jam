using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Scale))]
public class ScaleEditor : Editor
{
    private float _weight = 10f;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Editor Settings", EditorStyles.boldLabel);
        _weight = EditorGUILayout.FloatField("Weight", _weight);
        if(Application.isPlaying)
        {
            if (GUILayout.Button("Add weight"))
            {
                Scale scale = (Scale)target;
                scale.AddWeight(_weight);
            }
        }
    }
}
