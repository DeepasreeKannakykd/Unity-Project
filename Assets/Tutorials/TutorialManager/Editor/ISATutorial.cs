using UnityEditor;
using UnityEngine;
using System.Reflection;

public class ISATutorial : EditorWindow
{
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

    [MenuItem("ISA/Show Tutorials")]
    private static void ISATutorialCall()
    {
        if (PlayerPrefs.GetInt("LicenseKeyUptoDate") == 1)
        {
            // Access the TutorialWelcomePage using reflection
            var editorAssembly = Assembly.Load("Unity.Tutorials.Core.Editor");
            var tutorialWindowType = editorAssembly.GetType("Unity.Tutorials.Core.Editor.TutorialWindow");
            if (tutorialWindowType != null)
            {
                EditorWindow.GetWindow(tutorialWindowType, false, "Tutorials", true);
                // Debug.Log("Tutorial Welcome Page opened successfully.");
            }
            else
            {
                //Debug.LogWarning("TutorialWindow class not found in Unity.Tutorials.Core.Editor.");
            }
        }
        else
        {
            LicenseValidationWindow.ValidateLicense();
        }



    }
#endif

}
