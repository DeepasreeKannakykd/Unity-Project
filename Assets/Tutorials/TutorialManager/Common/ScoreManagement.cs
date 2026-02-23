using UnityEngine;

namespace Unity.Tutorials
{
   
    [CreateAssetMenu(fileName = "ScoreManagement", menuName = "Tutorials/YVTScore/ScoreManagement")]
    class ScoreManagement : ScriptableObject
    {
        public void SetCurrentTutorialNo(int tutorialNo)
        {
            PlayerPrefs.SetInt("Tutorial No", tutorialNo);
        }
        public void SetCurrentTutorialCompletedPoint(int CompletedPoint)
        {
            int tutorialNo = PlayerPrefs.GetInt("Tutorial No");
            PlayerPrefs.SetInt("Tutorial "+ tutorialNo.ToString(), CompletedPoint);
        }
    }
}
