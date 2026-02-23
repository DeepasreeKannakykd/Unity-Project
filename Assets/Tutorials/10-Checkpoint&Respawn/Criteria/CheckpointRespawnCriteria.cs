
using UnityEngine;

#if UNITY_EDITOR
using UnityEditorInternal;
#endif



namespace Unity.Tutorials
{
   
    [CreateAssetMenu(fileName = "CheckpointRespawnCriteria", menuName = "Tutorials/YVTgame/CheckpointRespawnCriteria")]
    class CheckpointRespawnCriteria : ScriptableObject
    {
        public bool IsCheckpointCreated()
        {
            GameObject room2 = GameObject.Find("Room2");
            if (GameObject.Find("Checkpoint") != null)
            {
                GameObject Checkpoint = room2.transform.Find("Checkpoint").gameObject;

                return true;
            }
            return false;
        }
        public bool SetCheckpointSortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            if (GameObject.Find("Checkpoint") != null)
            {
                GameObject Checkpoint = room2.transform.Find("Checkpoint").gameObject;
                if(Checkpoint.GetComponent<SpriteRenderer>().sortingLayerName == "Foreground")
                {
                    return true;
                }
            }
            return false;
        }
        public bool SetCheckpointTag()
        {
            GameObject room2 = GameObject.Find("Room2");
            if (GameObject.Find("Checkpoint") != null)
            {
                GameObject Checkpoint = room2.transform.Find("Checkpoint").gameObject;
                if (Checkpoint.tag== "Checkpoint")
                {
                    return true;
                }
            }
            return false;
        }
        public bool AddPlayerRespawn() 
        {
            GameObject player = GameObject.Find("Player");
            if (player.GetComponent<PlayerRespawn>()!=null)
            {
                return true;
            }
            return false;

        }
        public AudioClip CheckpointClip;
        public bool AssignCheckpointAudio() 
        {
            GameObject player = GameObject.Find("Player");
            if (player.GetComponent<PlayerRespawn>()!=null)
            {
                if (player.GetComponent<PlayerRespawn>().checkpoint != null)
                {
                    if (player.GetComponent<PlayerRespawn>().checkpoint == CheckpointClip)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

    }
}