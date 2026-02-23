using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using System.Reflection;
using System;
using UnityEditor.Build;
using Unity.Tutorials;

[InitializeOnLoad]
public class AutoInstallUnityPackages
{

    private const string TutorialFrameworkPackage = "com.unity.learn.iet-framework";
    private const string TutorialFrameworkVersion = "4.0.3";
    private const string TutorialAuthoringToolsPackage = "com.unity.learn.iet-framework.authoring";
    private const string TutorialAuthoringToolsVersion = "1.2.2";
    private const string Sprite2DPackage = "com.unity.2d.sprite";
    private const string Sprite2DVersion = "1.0.0";
    private const string UnityUIPackage = "com.unity.ugui";
    private const string UnityUIVersion = "2.0.0";
    private const string UnityEditorCoroutinesPackage = "com.unity.editorcoroutines";
    private const string UnityEditorCoroutinesVersion = "1.0.0";

    static DateTime dateTime;
    static AutoInstallUnityPackages()
    {
        //PlayerPrefs.SetInt("HighestCompletedTutorialIdx", -1);

        dateTime = DateTime.Now;
        //PlayerPrefs.SetString("LastDateLicenseCheck", "23-12-2024");
        //  HideMenuItem("Tutorials");
        RemoveTutorialsMenu();
        EditorApplication.update += CheckAndInstallPackages;
    }

    private static void CheckAndInstallPackages()
    {


        if (!IsPackageInstalled(TutorialFrameworkPackage, TutorialFrameworkVersion))
        {
            // Debug.Log($"Installing required package: {TutorialFrameworkPackage} version {TutorialFrameworkVersion}");
            AddPackage($"{TutorialFrameworkPackage}@{TutorialFrameworkVersion}", TutorialFrameworkPackage);
        }
        else if (!IsPackageInstalled(TutorialAuthoringToolsPackage, TutorialAuthoringToolsVersion))
        {


            // Debug.Log($"Installing required package: {TutorialAuthoringToolsPackage} version {TutorialAuthoringToolsVersion}");
            AddPackage($"{TutorialAuthoringToolsPackage}@{TutorialAuthoringToolsVersion}", TutorialAuthoringToolsPackage);
        }
        else if (!IsPackageInstalled(Sprite2DPackage, Sprite2DVersion))
        {
            // Debug.Log($"Installing required package: {Sprite2DPackage} version {Sprite2DVersion}");
            AddPackage($"{Sprite2DPackage}@{Sprite2DVersion}", Sprite2DPackage);
        }
        else if (!IsPackageInstalled(UnityUIPackage, UnityUIVersion))
        {
            // Debug.Log($"Installing required package: {Sprite2DPackage} version {Sprite2DVersion}");
            AddPackage($"{UnityUIPackage}@{UnityUIVersion}", UnityUIPackage);
        }//        
        else if (!IsPackageInstalled(UnityEditorCoroutinesPackage, UnityEditorCoroutinesVersion))
        {
            // Debug.Log($"Installing required package: {Sprite2DPackage} version {Sprite2DVersion}");
            AddPackage($"{UnityEditorCoroutinesPackage}@{UnityEditorCoroutinesVersion}", UnityEditorCoroutinesPackage);
        }//
        else
        {

#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
            CheckLicense();

#endif
#if !UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
            AutoInstallUnityPackages.AddScriptingDefineSymbolIfNeeded();
#endif


            EditorApplication.update -= CheckAndInstallPackages;

        }

    }
    static void CheckLicense()
    {
        if (dateTime.ToShortDateString() != PlayerPrefs.GetString("LastDateLicenseCheck"))
        {
            if (PlayerPrefs.GetInt("ValidLicenseKey") == 0)
            {
                LicenseValidationWindow.ValidateLicense();
            }
            else
            {
                LicenseCheckWindow.CheckLicense();
            }
        }
        else
        {

        }
    }

    private static bool IsPackageInstalled(string packageName, string requiredVersion = null)
    {
        var listRequest = Client.List(true);
        while (!listRequest.IsCompleted) { }

        if (listRequest.Status == StatusCode.Success)
        {
            foreach (var package in listRequest.Result)
            {
                if (package.name == packageName)
                {
                    if (requiredVersion == null || package.version == requiredVersion)
                    {
                        return true;
                    }
                }
            }
        }
        else if (listRequest.Status >= StatusCode.Failure)
        {
            //  Debug.LogError("Failed to retrieve package list.");
        }

        return false;
    }

    private static void AddPackage(string packageNameWithVersion, string packageName)
    {
        AddRequest request = Client.Add(packageNameWithVersion);
        EditorApplication.update += () => CheckPackageAddStatus(request, packageName);
    }

    private static void CheckPackageAddStatus(AddRequest request, string packageName)
    {
        if (request.IsCompleted)
        {
            if (request.Status == StatusCode.Success)
            {
                // Debug.Log($"Package {request.Result.displayName} installed successfully.");
                if (packageName == TutorialFrameworkPackage)
                {
                    // RemoveTutorialsMenu();
                    LicenseValidationWindow.ShowWindow();
                    //  AddScriptingDefineSymbolIfNeeded();
                }
            }
            else
            {
                // Debug.LogError($"Failed to install package: {request.Error.message}");
            }

            EditorApplication.update -= () => CheckPackageAddStatus(request, packageName);
        }
    }

    public static void AddScriptingDefineSymbolIfNeeded()
    {
        const string symbol = "UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE";
        string currentSymbols = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.Standalone);

        if (!currentSymbols.Contains(symbol))
        {
            currentSymbols = $"{currentSymbols};{symbol}";

            PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, currentSymbols);
            PlayerPrefs.SetInt("HighestCompletedTutorialIdx", -1);

        }
        else
        {
        }
    }


    private static void RemoveTutorialsMenu()
    {
        // Use reflection to remove the "Tutorials" menu
        var menuItemPath = "Tutorials";
        var menuType = typeof(EditorApplication).Assembly.GetType("UnityEditor.Menu");
        var removeMenuItemMethod = menuType?.GetMethod("RemoveMenuItem", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        if (removeMenuItemMethod != null)
        {
            removeMenuItemMethod.Invoke(null, new object[] { menuItemPath });
        }
        else
        {
        }
    }


}