using UnityEngine;
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
using Unity.Tutorials.Core.Editor;
#endif
using UnityEditor;

namespace Unity.Tutorials
{
   
    public class TutorialCallbacks : ScriptableObject
    {
        public GameObject TokenToSelect;
       
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
        public void SelectSpawnedGameObject(FutureObjectReference futureObjectReference)
        {
            if (futureObjectReference.SceneObjectReference == null) { return; }
            SelectGameObject(futureObjectReference.SceneObjectReference.ReferencedObjectAsGameObject);
        }

        public void SelectGameObject(GameObject gameObject)
        {
            if (!gameObject) { return; }
            Selection.activeObject = gameObject;
        }

        public void SelectToken()
        {
            if (!TokenToSelect)
            {
                TokenToSelect = GameObject.FindGameObjectWithTag("TutorialRequirement");
                if (!TokenToSelect)
                {
                    Debug.LogErrorFormat("A TokenInstance with the tag '{0}' must be in the scene in order to make this tutorial work properly. Please add the tag {0} to one of your tokens in the scene", "TutorialRequirement");
                    return;
                }
            }
            SelectGameObject(TokenToSelect);
        }

        public void SelectMoveTool()
        {
            Tools.current = Tool.Move;
        }

        public void SelectRotateTool()
        {
            Tools.current = Tool.Rotate;
        }

        public void StartTutorial(Tutorial tutorial)
        {
            TutorialWindowUtils.StartTutorial(tutorial);
        }
        public void DisableTutorial(Tutorial tutorial)
        {
            TutorialWindowUtils.StartTutorial(tutorial);
        }
#endif

    }

}