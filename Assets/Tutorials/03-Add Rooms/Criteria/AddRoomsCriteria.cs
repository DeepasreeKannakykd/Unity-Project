using UnityEngine;

namespace Unity.Tutorials
{
    [CreateAssetMenu(fileName = "AddRoomsCriteria", menuName = "Tutorials/YVTgame/AddRoomsCriteria")]
    class AddRoomsCriteria : ScriptableObject
    {
        public bool IsRoom2Created()
        {
            GameObject level = GameObject.Find("Level");

            if (level.transform.childCount >= 2)
            {
                if (level.transform.GetChild(1).name == "Room2")
                {  
                    return true;                   
                } 
            }
            return false;
        }

        public bool SetRoom2GroundLayer()
        {

            GameObject room2 = GameObject.Find("Room2");
            GameObject Ground = room2.transform.Find("Ground").gameObject;
            string layerName = "Ground";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (Ground.layer == layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SetRoom2WallRightLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject WallRight = room2.transform.Find("WallRight").gameObject;
            string layerName = "Wall";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (WallRight.layer == layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsRoom3Created()
        {
            GameObject level = GameObject.Find("Level");

            if (level.transform.childCount >= 3)
            {
                if (level.transform.GetChild(2).name == "Room3")
                {
                    return true;
                }
            }
            return false;

        }

        public bool SetRoom3GroundLayer()
        {

            GameObject room3 = GameObject.Find("Room3");
            GameObject Ground = room3.transform.Find("Ground").gameObject;
            string layerName = "Ground";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (Ground.layer == layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SetRoom3WallRightLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            GameObject WallRight = room3.transform.Find("WallRight").gameObject;
            string layerName = "Wall";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (WallRight.layer == layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
