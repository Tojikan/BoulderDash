using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



/// <summary>
/// Custom inspector for obstacles
/// Probably won't use because sliders don't apply to multiple objects
/// </summary>

[CustomEditor(typeof(Obstacle))]
public class ObstacleEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Obstacle obstacle = (Obstacle)target;


        EditorGUILayout.HelpBox("Obstacle timer counts up from 0 to 1000. Each obstacle has its own count to determine when it triggers the obstacle, which follows along with the obstacle timer." +
                                "When the timer reaches the Loop Length value, the obstacle's count goes to zero. When the obstacle's count hits the trigger time, it'll trigger the obstacle.", MessageType.Info);
        GUILayout.Label("Trigger Time");
        obstacle.triggerTime = EditorGUILayout.IntSlider(obstacle.triggerTime, 0, obstacle.loopLength - 1);
        GUILayout.Label("Loop Length");
        obstacle.loopLength = EditorGUILayout.IntSlider(obstacle.loopLength, 0, 1000);
        GUILayout.Label("Show Obstacle Collider Size");
        obstacle.showBox = EditorGUILayout.Toggle(obstacle.showBox);

    }
}
