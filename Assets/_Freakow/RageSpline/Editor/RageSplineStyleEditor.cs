﻿using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

[CustomEditor(typeof(RageSplineStyle))]
public class RageSplineStyleEditor : Editor
{
    public bool paintMode = true;
    public int selectedCurveIndex = -1;
    public bool showGradientAngle;
    public bool embossFoldout;
    public override void OnInspectorGUI()
    {

        EditorGUIUtility.LookLikeInspector();
        GUI.Label(new Rect(10f, 20f, 200f, 50f), "This is a RageSpline style.");
        GUI.Label(new Rect(10f, 50f, 200f, 50f), "Drag it to a RageSpline object.");
        GUI.Label(new Rect(10f, 80f, 200f, 50f), "Make changes to RageSpline");
        GUI.Label(new Rect(10f, 95f, 200f, 50f), "object and they will affect");
        GUI.Label(new Rect(10f, 110f, 200f, 50f), "every instance with this style.");

        
        if (Event.current.type == EventType.mouseDown)
        {
            Undo.CreateSnapshot();
            Undo.RegisterSnapshot();
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }

    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}