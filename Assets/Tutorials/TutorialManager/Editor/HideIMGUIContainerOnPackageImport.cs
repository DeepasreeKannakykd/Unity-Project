using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[InitializeOnLoad]
public class HideIMGUIContainerOnPackageImport
{
    static HideIMGUIContainerOnPackageImport()
    {
        EditorApplication.delayCall += InitializeHideIMGUIContainer;
    }

    private static void InitializeHideIMGUIContainer()
    {
        EditorApplication.update += ContinuouslyModifyTutorialWindow;
    }

    private static void ContinuouslyModifyTutorialWindow()
    {
        EditorWindow tutorialWindow = GetWindowByName("Tutorials");

        if (tutorialWindow != null)
        {
            VisualElement root = tutorialWindow.rootVisualElement;

            var imguiContainer = root.Q<IMGUIContainer>(className: "unity-imgui-container");

            if (imguiContainer != null && imguiContainer.style.display != DisplayStyle.None)
            {
                imguiContainer.style.display = DisplayStyle.None;
            }
        }
    }

    private static EditorWindow GetWindowByName(string windowName)
    {
        foreach (var window in Resources.FindObjectsOfTypeAll<EditorWindow>())
        {
            if (window.titleContent.text == windowName)
            {
                return window;
            }
        }
        return null;
    }


}