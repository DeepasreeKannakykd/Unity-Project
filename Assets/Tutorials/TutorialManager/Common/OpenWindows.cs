
using UnityEditor;
using UnityEngine;
namespace Unity.Tutorials
{
    [CreateAssetMenu(fileName = "OpenWindows", menuName = "Tutorials/Common/OpenWindows")]
    public class OpenWindows : ScriptableObject
    {
        public void OpenProject()
        {
            // Focuses on the Project window if it's open or opens it if it's not
            EditorApplication.ExecuteMenuItem("Window/General/Project");
        }
    }
}