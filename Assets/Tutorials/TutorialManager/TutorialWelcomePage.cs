
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
using Unity.Tutorials.Core.Editor;
using Unity.Tutorials;
#endif

using UnityEditor;
using UnityEngine;


public class TutorialWelcomePage : EditorWindow
{
    private static Vector2 windowSize = new Vector2(640, 520);
    [MenuItem("Window/Welcome Window")]
    public static void ShowWindow()
    {
        TutorialWelcomePage window = GetWindow<TutorialWelcomePage>("2D Platformer");
        window.minSize = windowSize;
        window.maxSize = windowSize;

    }
    private GUIStyle titleStyle;
    private GUIStyle subtitleStyle;
    private GUIStyle buttonStyle;
    private Texture2D characterImage;
    private void OnEnable()
    {
        // Enforce the fixed size in case the user resizes before OnEnable
        this.minSize = windowSize;
        this.maxSize = windowSize;
    }

    private void OnGUI()
    {

#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

        characterImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Tutorials/TutorialManager/UI/Logo.png");

        titleStyle = new GUIStyle();
        titleStyle.fontSize = 24;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.alignment = TextAnchor.MiddleLeft;
        titleStyle.normal.textColor = Color.white;
        titleStyle.margin = new RectOffset(20, 20, 10, 10);


        subtitleStyle = new GUIStyle();
        subtitleStyle.fontSize = 14;
        subtitleStyle.fontStyle = FontStyle.Normal;
        subtitleStyle.alignment = TextAnchor.MiddleLeft;
        subtitleStyle.normal.textColor = Color.white;
        subtitleStyle.margin = new RectOffset(20, 20, 10, 10);


        buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 12;
        buttonStyle.fixedHeight = 40;
        buttonStyle.fontStyle = FontStyle.Bold;
        buttonStyle.alignment = TextAnchor.MiddleCenter;

        Rect ImageBGRect = new Rect(0, 0, position.width, 150);
        EditorGUI.DrawRect(ImageBGRect, new Color(0.15f, 0.15f, 0.15f));

        Rect TextBGRect = new Rect(0, 150, position.width, 250);
        EditorGUI.DrawRect(TextBGRect, new Color(0.2f, 0.2f, 0.2f));

        Rect ButtonBGRect = new Rect(0, 400, position.width, 200);
        EditorGUI.DrawRect(ButtonBGRect, new Color(0.25f, 0.25f, 0.25f));


        if (characterImage != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(characterImage, GUILayout.Width(200), GUILayout.Height(150));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }


        GUILayout.Space(30);

        GUILayout.Label("Unity 2D Platformer Game!", titleStyle);

        int tutorialIdx = PlayerPrefs.GetInt("RecentCompletedTutorialIdx");
        Unity.Tutorials.TutorialManager tutorialManager = AssetDatabase.LoadAssetAtPath<Unity.Tutorials.TutorialManager>("Assets/Tutorials/TutorialManager/TutorialManager.asset");

        GUILayout.Space(10);

        GUILayout.Label("Make this platformer game your own!." +
            "\n\nIn this project, you'll find preloaded scenes, scripts, audio, tutorials, and more to inspire" +
            "\nyou and help you start creating." +
            "\n\nNew to Unity ? Quickstart your creation journey with the step - by - step <b> Tutorials.</b>" +
            "\n\nReady to create ? Head straight to the <b> Scene.</b>", subtitleStyle);


        GUILayout.Space(50);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Start Tutorial", buttonStyle, GUILayout.Width(100), GUILayout.Height(30)))
        {
            this.Close();
            Unity.Tutorials.TutorialManager tutorialsSO = AssetDatabase.LoadAssetAtPath<Unity.Tutorials.TutorialManager>("Assets/Tutorials/TutorialManager/TutorialManager.asset");
            tutorialsSO.StartFirstTutorial();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
#endif

    }
}
