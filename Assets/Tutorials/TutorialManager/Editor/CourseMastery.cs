using System;
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
using Unity.Tutorials.Core.Editor;
#endif
using UnityEditor;
using UnityEngine;

public class CourseMastery : EditorWindow
{  
    [MenuItem("Window/Course Mastery")]
    public static void ShowWindow()
    {
        CourseMastery window = GetWindow<CourseMastery>("Course Mastery");

        window.minSize = new Vector2(640, 460);
        window.maxSize = new Vector2(640, 460);
    }
    private GUIStyle titleStyle;
    private GUIStyle subtitleStyle;
    private GUIStyle buttonStyle;

    private void OnGUI()
    {

        titleStyle = new GUIStyle();
        titleStyle.fontSize = 24;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.normal.textColor = Color.white;

        subtitleStyle = new GUIStyle();
        subtitleStyle.fontSize = 14;
        subtitleStyle.fontStyle = FontStyle.Bold;

        subtitleStyle.fontStyle = FontStyle.Normal;
        subtitleStyle.alignment = TextAnchor.MiddleCenter;
        subtitleStyle.normal.textColor = Color.white;

        buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 12;
        buttonStyle.fixedHeight = 40;
        buttonStyle.fontStyle = FontStyle.Bold;
        buttonStyle.alignment = TextAnchor.MiddleCenter;
       
        GUILayout.Space(100);

        GUILayout.Label("Awesome! you improved your skills!", titleStyle);             

        GUILayout.Space(50);

        int earnedScore =   PlayerPrefs.GetInt("TotalEarnedPoints");
        int TotalCourseMasteryPoints = PlayerPrefs.GetInt("TotalCourseMasteryPoints");
        GUILayout.Label("Course mastery points:"+ earnedScore.ToString()+ $"/{TotalCourseMasteryPoints}", subtitleStyle);

        TimeSpan CourseMasterySpendTime= TimeSpan.Zero;


        for (int i = 0; i < 10; i++)
        {
            string tutorialSpend = PlayerPrefs.GetString("Tutorial " + i.ToString() + " Spend Time");
            if (tutorialSpend == "")
            {
                tutorialSpend = "00:00:00"; 
            }
            TimeSpan previousSpendTS = TimeSpan.Parse(tutorialSpend);
            CourseMasterySpendTime = previousSpendTS + CourseMasterySpendTime;
        }       

        GUILayout.Space(30);
        GUILayout.Label("Time Spent: " + CourseMasterySpendTime.ToString(), subtitleStyle);


        GUILayout.Space(100);

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Close", GUILayout.Width(120), GUILayout.Height(40)))
        {
            this.Close(); 
        }

        GUILayout.FlexibleSpace(); 
        GUILayout.EndHorizontal();
    }
}
