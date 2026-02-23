#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
using Unity.Tutorials.Core.Editor;
using Unity.EditorCoroutines.Editor;
#endif

using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using System.Globalization;
using System.Collections;
using System.Text;
using UnityEngine.Networking;
namespace Unity.Tutorials
{
    [CreateAssetMenu(fileName = "TutorialManager", menuName = "Tutorials/YVTScore/TutorialManager")]

    public class TutorialManager : ScriptableObject
    {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

        public static TutorialManager Instance;
        public Tutorial[] tutorials;
        bool autoClose = false;

        public void ChangeExtension()

        {
        }
        public void StartTutorial(Tutorial tutorial)
        {
            if (PlayerPrefs.GetInt("LicenseKeyUptoDate") == 1)
            {
                int lastDoneTutorialIdx = PlayerPrefs.GetInt("HighestCompletedTutorialIdx");

                int currentTutorialIdx = 0;
                for (int i = 0; i < tutorials.Length; i++)
                {
                    if (tutorials[i] == tutorial)
                    {
                        currentTutorialIdx = i;
                    }
                }

                if (currentTutorialIdx <= lastDoneTutorialIdx + 1)
                {
                    //  Debug.Log("Show");
                }
                else
                {

                    if (tutorial.CurrentPage != null)
                    {
                        autoClose = true;
                        TutorialWindow.ExitTutorial();
                    }
                    else
                    {
                    }
                }

                PlayerPrefs.SetInt("CurrentTutorialIdx", currentTutorialIdx);
                SetCurrentTutorialStartTime(currentTutorialIdx);

                int TotalCourseMasteryPoints = 0;
                int totalPages = 0;
                for (int i = 0; i < tutorials.Length; i++)
                {
                    totalPages += tutorials[i].PageCount;
                }
                TotalCourseMasteryPoints = totalPages * 10;
                PlayerPrefs.SetInt("TotalCourseMasteryPoints", TotalCourseMasteryPoints);
                PlayerPrefs.SetInt("CurrentRunningTutorial", currentTutorialIdx);

            }
            else
            {
                EditorApplication.ExecuteMenuItem("ISA/License Validator");
                autoClose = true;

                TutorialWindow.ExitTutorial();

            }
            SetTutorialProgress();

        }
        public void EndTutorial(int tutorialIdx)
        {
            PlayerPrefs.SetInt("RecentCompletedTutorialIdx", tutorialIdx);
            int HighestCompletedTutorialIdx = PlayerPrefs.GetInt("HighestCompletedTutorialIdx");
            if (HighestCompletedTutorialIdx <= tutorialIdx)
            {
                PlayerPrefs.SetInt("HighestCompletedTutorialIdx", tutorialIdx);
                SetTutorialProgress();
            }

            int earnedPoints = 1;
            int totalPages = 0;
            for (int i = 0; i < tutorials.Length; i++)
            {
                totalPages += tutorials[i].PageCount;
            }
            earnedPoints = totalPages * 10;
            PlayerPrefs.SetInt("TotalEarnedPoints", earnedPoints);
            SetCurrentTutorialEndTime();
            autoClose = true;
            TutorialDonePopup.ShowWindow();

        }
        public void LoadNextTutorial()
        {
            int tutorialIdx = PlayerPrefs.GetInt("RecentCompletedTutorialIdx");
            tutorialIdx++;
            TutorialWindowUtils.StartTutorial(tutorials[tutorialIdx]);
        }
        public void StartFirstTutorial()
        {
            TutorialWindowUtils.StartTutorial(tutorials[0]);
        }

        public void SetCurrentTutorialStartTime(int tutorialNo)
        {
            DateTime startTime = DateTime.Now;
            PlayerPrefs.SetInt("Tutorial No", tutorialNo);

            int lastDoneTutorialIdx = PlayerPrefs.GetInt("HighestCompletedTutorialIdx");
            if (lastDoneTutorialIdx < tutorialNo && lastDoneTutorialIdx + 1 >= tutorialNo)
            {
                // Debug.Log(PlayerPrefs.GetString("Tutorial " + tutorialNo.ToString() + " Start Time"));
                if (PlayerPrefs.GetString("Tutorial " + tutorialNo.ToString() + " Start Time") == "")
                {
                    PlayerPrefs.SetString("Tutorial " + tutorialNo.ToString() + " Start Time", startTime.ToString());

                }
                else
                {

                }
            }
            else
            {

            }
        }
        public void SetCurrentTutorialEndTime()
        {
            int lastDoneTutorialIdx = PlayerPrefs.GetInt("HighestCompletedTutorialIdx");
            int RecentCompletedTutorialIdx = PlayerPrefs.GetInt("RecentCompletedTutorialIdx");


            int tutorialNo = PlayerPrefs.GetInt("Tutorial No");
            if (lastDoneTutorialIdx <= tutorialNo)
            {
                DateTime endTime = DateTime.Now;
                string startDateTimeString = PlayerPrefs.GetString("Tutorial " + tutorialNo.ToString() + " Start Time");
                PlayerPrefs.SetString("Tutorial " + tutorialNo.ToString() + " End Time", endTime.ToString());
                if (startDateTimeString == "")
                {
                    startDateTimeString = "00:00:00";
                }
                DateTime startTime = DateTime.Parse(startDateTimeString);

                TimeSpan difference = endTime - startTime;

                string formattedDifference = string.Format("{0:D2}:{1:D2}:{2:D2}", difference.Hours, difference.Minutes, difference.Seconds);

                string previousSpend = PlayerPrefs.GetString("Tutorial " + tutorialNo.ToString() + " Spend Time");
                if (previousSpend == "")
                {
                    previousSpend = "00:00:00";
                }
                TimeSpan previousSpendTS = TimeSpan.Parse(previousSpend);

                TimeSpan spendTime = difference + previousSpendTS;

                string spendTimeString = string.Format("{0:D2}:{1:D2}:{2:D2}",
                   spendTime.Hours, spendTime.Minutes, spendTime.Seconds);
                PlayerPrefs.SetString("Tutorial " + tutorialNo.ToString() + " Spend Time", spendTimeString.ToString());

                SendProgressToServer();


            }
            else
            {

            }

        }



        public void QuitTutorial()
        {
            if (!autoClose)
            {
                SetCurrentTutorialEndTime();
            }
            autoClose = false;
        }
        public void SetTutorialProgress()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            int HighestCompletedTutorialIdx = PlayerPrefs.GetInt("HighestCompletedTutorialIdx");

            for (int i = 0; i < tutorials.Length; i++)
            {
                Tutorial tutorial = tutorials[i];

                if (HighestCompletedTutorialIdx <= i)
                {
                    tutorial.ProgressTrackingEnabled = true;

                }
                else
                {
                    tutorial.ProgressTrackingEnabled = false;

                }
            }
#endif
        }

        //Send Time and Score
        public void SendProgressToServer()
        {
            int lastDoneTutorialIdx = PlayerPrefs.GetInt("HighestCompletedTutorialIdx");

            ProgressRequestData progressRequestData = new ProgressRequestData();
            progressRequestData.email = CloudProjectSettings.userName;
            progressRequestData.license = PlayerPrefs.GetString("LicenseKey");
            progressRequestData.course_id = "Platformer";
            progressRequestData.unity_id = CloudProjectSettings.userId;
            progressRequestData.build_platform = Application.platform.ToString();
            progressRequestData.unity_version = Application.unityVersion;
            progressRequestData.editor_os = SystemInfo.operatingSystem;

            for (int i = 0; i < tutorials.Length; i++)
            {

                ModuleData moduleData = new ModuleData();
                if (lastDoneTutorialIdx >= i)        //Done-1>=0
                {
                    moduleData.moduleIdx = i;
                    moduleData.moduleName = tutorials[i].name;
                    moduleData.isStarted = true;
                    moduleData.isCompleted = true;

                    string startDateTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " Start Time");
                    string endDateTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " End Time");
                    string spendTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " Spend Time");

                    moduleData.startTime = StdToUtcTime(startDateTimeString);
                    moduleData.endTime = StdToUtcTime(endDateTimeString);
                    moduleData.spentTime = MinsToSec(spendTimeString);

                    moduleData.totalScore = tutorials[i].PageCount * 10;
                    moduleData.earnedScore = tutorials[i].CurrentPageIndex * 10;
                    moduleData.progress = 100;

                    //Debug.Log(tutorials[i].PageCount);
                    //Debug.Log(tutorials[i].CurrentPageIndex);

                }
                else if (lastDoneTutorialIdx + 1 >= i)//Inprogress 
                {
                    moduleData.moduleIdx = i;
                    moduleData.moduleName = tutorials[i].name;

                    moduleData.isStarted = true;
                    moduleData.isCompleted = false;

                    string startDateTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " Start Time");
                    string endDateTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " End Time");
                    string spendTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " Spend Time");

                    if (startDateTimeString == "")
                    {
                        moduleData.isStarted = false;
                    }
                    moduleData.startTime = StdToUtcTime(startDateTimeString);
                    moduleData.endTime = StdToUtcTime(endDateTimeString);
                    moduleData.spentTime = MinsToSec(spendTimeString);


                    moduleData.totalScore = tutorials[i].PageCount * 10;
                    moduleData.earnedScore = tutorials[i].CurrentPageIndex * 10;
                    moduleData.progress = ProgressTutorial(tutorials[i].PageCount, tutorials[i].CurrentPageIndex);

                    //Debug.Log(tutorials[i].PageCount);
                    //Debug.Log(tutorials[i].CurrentPageIndex);
                }
                else//Not Start Yet
                {
                    moduleData.moduleIdx = i;
                    moduleData.moduleName = tutorials[i].name;
                    moduleData.isStarted = false;
                    moduleData.isCompleted = false;

                    string startDateTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " Start Time");
                    string endDateTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " End Time");

                    string spendTimeString = PlayerPrefs.GetString("Tutorial " + i.ToString() + " Spend Time");

                    moduleData.startTime = StdToUtcTime(startDateTimeString);
                    moduleData.endTime = StdToUtcTime(endDateTimeString);
                    moduleData.spentTime = MinsToSec(spendTimeString);

                    moduleData.totalScore = tutorials[i].PageCount * 10;
                    moduleData.earnedScore = tutorials[i].CurrentPageIndex * 10;
                    moduleData.progress = 0;
                    //Debug.Log(tutorials[i].PageCount);
                    //Debug.Log(tutorials[i].CurrentPageIndex);
                }
                progressRequestData.moduleData.Add(moduleData);
            }
            string requestBody = JsonUtility.ToJson(progressRequestData);
            //Debug.Log(requestBody);
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            EditorCoroutineUtility.StartCoroutine(PostValidateLicense(requestBody), this);
#endif
        }

        private IEnumerator PostValidateLicense(string _requestBody)
        {
            const string Url = "https://api.immersiveskillsacademy.com/module";

            string contentType = "application/json"; // Default Content-Type
            string requestBody = _requestBody;
            // Construct the request body based on the Content-Type
            if (contentType == "application/json")
            {
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
                    ProgressResponseData response = JsonUtility.FromJson<ProgressResponseData>(jsonResponse);

                    // Debug.Log(response.error);
                }
                else
                {
                    string jsonResponse = request.downloadHandler.text;
                    ProgressResponseData response = JsonUtility.FromJson<ProgressResponseData>(jsonResponse);
                    // Debug.Log(response.error);

                }
            }

        }


        string StdToUtcTime(string _inputDateTime)
        {
            string inputDateTime = _inputDateTime;// "10-01-2025 17:50:07";
            string isoDateTime = null;
            try
            {
                // Parse the input string to a DateTime object
                DateTime dateTime = DateTime.ParseExact(inputDateTime, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                // Convert the DateTime to ISO 8601 format in UTC
                isoDateTime = dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

            }
            catch (FormatException ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                isoDateTime = null;
            }

            return isoDateTime;

        }
        int MinsToSec(string _timeString)
        {
            string timeString = _timeString;// "12:34:56"; // Example time in HH:MM:SS format

            // Split the time string into hours, minutes, and seconds
            string[] timeParts = timeString.Split(':');
            int totalSeconds = 0;
            if (timeParts.Length == 3)
            {
                int hours = int.Parse(timeParts[0]);
                int minutes = int.Parse(timeParts[1]);
                int seconds = int.Parse(timeParts[2]);

                // Calculate the total number of seconds
                totalSeconds = (hours * 3600) + (minutes * 60) + seconds;
            }


            // Print the result
            //Console.WriteLine($"Total seconds: {totalSeconds}");
            return totalSeconds;
        }

        int ProgressTutorial(int _total, int _completed)
        {
            int completed = _completed;// 75; // Updated value
            int total = _total;// 100;

            // Calculate the percentage
            float percentage = ((float)completed / total) * 100;
            return (int)percentage;
        }
        // Class to represent the data structure
        [System.Serializable]
        public class ProgressRequestData
        {
            public string email;
            public string license;
            public string course_id;
            public string build_platform;
            public string unity_id;
            public string unity_version;
            public string editor_os;
            public List<ModuleData> moduleData = new List<ModuleData>();
        }

        // Define a class to represent the JSON structure
        [System.Serializable]
        public class ModuleData
        {
            public int moduleIdx;
            public string moduleName;
            public bool isStarted;
            public bool isCompleted;
            public string startTime;
            public string endTime;
            public int spentTime;
            public int totalScore;
            public int earnedScore;
            public int progress;
        }

        // Define a class to represent the JSON structure
        [System.Serializable]
        public class ProgressResponseData
        {
            public bool error;
            public string message;
            //public Data data;
        }

        [System.Serializable]
        public class Data
        {
            public bool Progress_status;
        }

#endif

    }
}