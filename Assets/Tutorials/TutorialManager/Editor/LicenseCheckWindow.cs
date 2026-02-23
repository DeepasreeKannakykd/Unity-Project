using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
using Unity.EditorCoroutines.Editor;

#endif
using System;
using Unity.Tutorials;

//[InitializeOnLoad]
public class LicenseCheckWindow : EditorWindow
{
    private string licenseKey = "";
    private string messageText = "";
    private bool isLicenseValid = false;


    private bool isSending = false; // To prevent multiple sends at once

    public bool LicenseValid = false;

    public static void CheckLicense()
    {

        LicenseCheckWindow window = GetWindow<LicenseCheckWindow>();
        if (window != null)
        {
            window.ValidateLicense_BtnOnClick();
            CloseWindow();
        }
        else
        {
            //Debug.LogWarning("Failed to find Editor Window instance.");
        }
    }


    //  [MenuItem("ISA/License Check")]
    public static void ShowWindow()
    {
        // GetWindow<LicenseCheckWindow>("License Validator");
        // RemoveTutorialsMenu();                  
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
            // Debug.Log("Activate button clicked. Redirecting to activation process...");
            Application.OpenURL("https://immersiveskillsacademy.com/");
            // PerformLicenseActivation();
        }
        else
        {
            // "Close" button clicked
            //Debug.Log("Close button clicked. Dialog dismissed.");
        }
    }
    private void OnGUIHide()
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
        const string Url = "https://api.immersiveskillsacademy.com/license/check/";


        string license = PlayerPrefs.GetString("LicenseKey");

        string updatedUrl = Url + license;

        WWWForm form = new WWWForm();
        using (UnityWebRequest request = UnityWebRequest.Post(updatedUrl, form))
        {
            yield return request.SendWebRequest();

            // Handle the response
            if (request.result == UnityWebRequest.Result.Success)
            {
                // Convert the JSON response to an object
                string jsonResponse = request.downloadHandler.text;
                CheckResponseData response = JsonUtility.FromJson<CheckResponseData>(jsonResponse);
                PlayerPrefs.SetInt("ValidLicenseKey", 1);
                DateTime dateTime = DateTime.Now;
                //Debug.Log(dateTime.ToShortDateString());
                PlayerPrefs.SetString("LastDateLicenseCheck", dateTime.ToShortDateString());
                response.daysLeft = 1;
                if (response.daysLeft > 0)
                {
                    PlayerPrefs.SetInt("LicenseKeyUptoDate", 1);
                    isLicenseValid = true;
                    messageText = "Message: " + response.message;

                    if (PlayerPrefs.GetString("FirstValidDone") == "True")
                    {
                        //Debug.LogWarning(messageText);
                        TutorialWelcomePage.ShowWindow();
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

                        // TutorialManager tutorialManager = new TutorialManager();
                        // tutorialManager.SetTutorialProgress();
#endif
                        LicenseValidationWindow window = GetWindow<LicenseValidationWindow>();
                        // Close the window
                        if (window != null)
                        {
                            window.Close();
                        }
                    }
                    PlayerPrefs.SetString("FirstValidDone", "False");
                }
                else
                {
                    PlayerPrefs.SetInt("LicenseKeyUptoDate", 0);
                    LicenseActivatedExpiredDialog();
                }



            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                CheckResponseData response = JsonUtility.FromJson<CheckResponseData>(jsonResponse);
                messageText = "Message: " + response.message;
            }
        }
        isSending = false;
    }

    private static void AddTutorialsMenu()
    {

    }

    static void CloseWindow()
    {
        // Get the current instance of MyEditorWindow
        LicenseCheckWindow window = GetWindow<LicenseCheckWindow>();

        // Close the window
        if (window != null)
        {
            window.Close();
        }
    }
}


// Define a class to represent the JSON structure
[System.Serializable]
public class CheckResponseData
{
    public bool error;
    public string message;
    public bool isValid;
    public int daysLeft;
}
