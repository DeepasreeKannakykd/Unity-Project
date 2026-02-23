using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class EditorQuit
{
    static EditorQuit()
    {
        // Subscribe to the quitting event
        EditorApplication.quitting += OnEditorQuitting;
    }

    private static void OnEditorQuitting()
    {
#if TUTORIAL
        Debug.Log("Unity Editor is about to close.");
        Unity.Tutorials.TutorialManager tutorialsSO = AssetDatabase.LoadAssetAtPath<Unity.Tutorials.TutorialManager>("Assets/Tutorials/TutorialManager/TutorialManager.asset");

        tutorialsSO.QuitTutorial();
        // Unsubscribe to avoid any issues (though it's not strictly necessary here)
        EditorApplication.quitting -= OnEditorQuitting;
#endif

    }
}
