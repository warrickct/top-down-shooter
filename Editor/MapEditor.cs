using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator))]
public class MapEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();  //draws all the default stuff

        MapGenerator map = target as MapGenerator; //what the map editor is an editor of

        map.GenerateMap();
    }

}
