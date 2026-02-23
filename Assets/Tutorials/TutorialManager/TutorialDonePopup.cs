
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
using Unity.Tutorials.Core.Editor;
using Unity.Tutorials;
#endif

using UnityEditor;
using UnityEngine;

public class TutorialDonePopup : EditorWindow
{  
    [MenuItem("Window/TutorialDonePopup")]
    public static void ShowWindow()
    {
        TutorialDonePopup window = GetWindow<TutorialDonePopup>("TutorialDonePopup");
        window.minSize = new Vector2(640, 460);
        window.maxSize = new Vector2(640, 460);
    }
    private GUIStyle titleStyle;
    private GUIStyle subtitleStyle;
    private GUIStyle buttonStyle;
    private Texture2D characterImage;


    private void OnGUI()
    {

#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

        characterImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Tutorials/TutorialManager/UI/Cup.png");  

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
       
        Rect ImageBGRect = new Rect(0, 0, position.width, 170);
        EditorGUI.DrawRect(ImageBGRect, new Color(0.15f, 0.15f, 0.15f));
        
        Rect TextBGRect = new Rect(0, 170, position.width,200);
        EditorGUI.DrawRect(TextBGRect, new Color(0.2f, 0.2f, 0.2f));

        Rect ButtonBGRect = new Rect(0, 370, position.width,200);
        EditorGUI.DrawRect(ButtonBGRect, new Color(0.25f, 0.25f, 0.25f));


        if (characterImage != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(characterImage, GUILayout.Width(80), GUILayout.Height(150));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

       
        GUILayout.Space(40);

        GUILayout.Label("Awesome! you improved your skills!", titleStyle);

        int tutorialIdx = PlayerPrefs.GetInt("RecentCompletedTutorialIdx");
        Unity.Tutorials.TutorialManager tutorialManager = AssetDatabase.LoadAssetAtPath<Unity.Tutorials.TutorialManager>("Assets/Tutorials/TutorialManager/TutorialManager.asset");

        GUILayout.Space(10);

        string tutorialName = tutorialManager.tutorials[tutorialIdx].name;
        tutorialName = tutorialName.Replace("Tutorial", "");
        GUILayout.Label("You have successfully Completed : "+ tutorialName+" Module", subtitleStyle);

    
        GUILayout.Space(10);

        string spendTime = PlayerPrefs.GetString("Tutorial " + tutorialIdx.ToString() + " Spend Time");
        GUILayout.Space(10);
        GUILayout.Label("Time Spent: "+spendTime.ToString(), subtitleStyle);

        GUILayout.Space(10);
        GUILayout.Label("", subtitleStyle);
        GUILayout.Space(80);

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Load Scene", GUILayout.Width(100), GUILayout.Height(30)))
        {
            this.Close();
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Next Tutorials", GUILayout.Width(100), GUILayout.Height(30)))
        {           
            this.Close();
            Unity.Tutorials.TutorialManager tutorialsSO = AssetDatabase.LoadAssetAtPath<Unity.Tutorials.TutorialManager>("Assets/Tutorials/TutorialManager/TutorialManager.asset");
            tutorialsSO.LoadNextTutorial();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal(); 
#endif

    }
}
