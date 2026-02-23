using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEditor.Compilation;
using UnityEngine.Networking;
using System.Collections;
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
using Unity.EditorCoroutines.Editor;
#endif
using System.Text;
using System;
using System.Security.Cryptography;
using Unity.Tutorials;
//[InitializeOnLoad]
public class LicenseValidationWindow : EditorWindow
{
    private string licenseKey = "";//
    private string messageText = "";
    private bool isLicenseValid = false;


    private bool isSending = false; // To prevent multiple sends at once
    private IEnumerator currentCoroutine; // Holds the current coroutine

    public static void ValidateLicense()
    {



        LicenseValidationWindow.ShowWindow();
    }

    [MenuItem("ISA/License Validator")]
    public static void ShowWindow()
    {
        //#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
        //        TutorialManager window = ScriptableObject.CreateInstance<TutorialManager>();

        //        if (window != null)
        //        {
        //            window.SetTutorialProgress();
        //        }
        //        else
        //        {
        //            //Debug.LogWarning("Failed to find Editor Window instance.");
        //        }
        //        Debug.Log("Calling");

        //#endif

        if (PlayerPrefs.GetInt("ValidLicenseKey") == 0)//Need Activate
        {
            GetWindow<LicenseValidationWindow>("License Validator");
        }
        else
        {
            //Debug.Log(PlayerPrefs.GetInt("LicenseKeyUptoDate"));
            if (PlayerPrefs.GetInt("LicenseKeyUptoDate") == 1)
            {
                LicenseAlreadyActivatedDialog();
            }
            else
            {
                GetWindow<LicenseValidationWindow>("License Validator");
            }


        }
    }

    public static void LicenseAlreadyActivatedDialog()
    {
        // Display a dialog with a title, message, and a single button
        if (EditorUtility.DisplayDialog(
            "License Status", // Title
            "Your license has already been activated.", // Message
            "Close" // Button label
        ))
        {
            // This code runs when the "Close" button is clicked
            //Debug.Log("License dialog closed.");
        }
    }
    public static void LicenseActivatedExpiredDialog()
    {
        // Show a dialog with "Activate" and "Close" buttons
        bool activateClicked = EditorUtility.DisplayDialog(
            "License Status",           // Title
            "Your license has expired. Would you like to activate it now?", // Message
            "Activate",                 // First button label (returns true)
            "Close"                     // Second button label (returns false)
        );

        if (activateClicked)
        {
            // "Activate" button clicked
            //Debug.Log("Activate button clicked. Redirecting to activation process...");
            Application.OpenURL("https://immersiveskillsacademy.com/");
            // PerformLicenseActivation();
        }
        else
        {
            // "Close" button clicked
            //Debug.Log("Close button clicked. Dialog dismissed.");
        }
    }
    private void OnGUI()
    {
        GUILayout.Label("Enter License Key", EditorStyles.boldLabel);

        // Input field for license key
        licenseKey = EditorGUILayout.TextField("License Key:", licenseKey);

        // Validate button
        if (GUILayout.Button("Validate License"))
        {
            ValidateLicense_BtnOnClick();
        }

        // Display validation status
        if (isSending)
        {
            EditorGUILayout.LabelField("Sending...");
        }
        else if (isLicenseValid)
        {
            EditorGUILayout.HelpBox("License validated successfully!", MessageType.Info);
        }
        else if (messageText != "")
        {
            EditorGUILayout.HelpBox(messageText, MessageType.Warning);
        }
        else if (string.IsNullOrEmpty(licenseKey))
        {
            EditorGUILayout.HelpBox("Enter your license key.", MessageType.Warning);
        }
    }

    private void ValidateLicense_BtnOnClick()
    {
        messageText = "";
        isLicenseValid = false;
        isSending = true;
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

        EditorCoroutineUtility.StartCoroutine(PostValidateLicense(), this);
#endif
    }

    private IEnumerator PostValidateLicense()
    {
        const string Url = "https://api.immersiveskillsacademy.com/license/validate";

        string email = CloudProjectSettings.userName;
        string license = licenseKey;
        string course_id = "Platformer";
        string unity_id = CloudProjectSettings.userId;
        string build_platform = Application.platform.ToString();
        string unity_version = Application.unityVersion;
        string editor_os = SystemInfo.operatingSystem;
        string contentType = "application/json"; // Default Content-Type
        string requestBody;
        // Construct the request body based on the Content-Type
        if (contentType == "application/json")
        {
            ValidateRequestData data = new ValidateRequestData
            {
                email = email,
                license = license,
                course_id = course_id,
                build_platform = build_platform,
                unity_id = unity_id,
                unity_version = unity_version,
                editor_os = editor_os,

            };

            requestBody = JsonUtility.ToJson(data);
        }
        else
        {
            yield break;
        }
        byte[] bodyRaw = Encoding.UTF8.GetBytes(requestBody);

        using (UnityWebRequest request = new UnityWebRequest(Url, UnityWebRequest.kHttpVerbPOST))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {

                string jsonResponse = request.downloadHandler.text;
                ValidateResponseData response = JsonUtility.FromJson<ValidateResponseData>(jsonResponse);
                if (PlayerPrefs.GetInt("ValidLicenseKey") == 0)
                {
                    PlayerPrefs.SetString("FirstValidDone", "True");
                }
                PlayerPrefs.SetInt("ValidLicenseKey", 1);
                PlayerPrefs.SetString("LicenseKey", licenseKey);
                isLicenseValid = true;
                messageText = "Message: " + response.message;
                LicenseCheckWindow.CheckLicense();

            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                ValidateResponseData response = JsonUtility.FromJson<ValidateResponseData>(jsonResponse);
                messageText = "Message: " + response.message;
            }
        }
        isSending = false;

    }
    public void CloseValidationWindow()
    {
        // Get the current instance of MyEditorWindow
        LicenseValidationWindow window = GetWindow<LicenseValidationWindow>();

        // Close the window
        if (window != null)
        {
            window.Close();
        }
    }
}

// Class to represent the data structure
[System.Serializable]
public class ValidateRequestData
{
    public string email;
    public string license;
    public string course_id;
    public string build_platform;
    public string unity_id;
    public string unity_version;
    public string editor_os;
}

// Define a class to represent the JSON structure
[System.Serializable]
public class ValidateResponseData
{
    public bool error;
    public string message;
    public Data data;
}

[System.Serializable]
public class Data
{
    public bool validation_status;
}