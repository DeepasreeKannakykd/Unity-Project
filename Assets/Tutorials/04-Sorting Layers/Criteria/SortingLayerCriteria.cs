using System.Collections.Generic;
using UnityEngine;

namespace Unity.Tutorials
{  
    [CreateAssetMenu(fileName = "SortingLayerCriteria", menuName = "Tutorials/YVTgame/SortingLayerCriteria")]
    class SortingLayerCriteria : ScriptableObject
    {


        public bool IsCreatedBackgroundSortingLayer()
        {
            string sortingLayerName = "Background";
            return IsSortingLayerExists(sortingLayerName);
        }
        public bool IsCreatedForegroundSortingLayer()
        {
            string sortingLayerName = "Foreground";
            return IsSortingLayerExists(sortingLayerName);
        }
        public bool IsCreatedPlayerSortingLayer()
        {
            string sortingLayerName = "Player";
            return IsSortingLayerExists(sortingLayerName);
        }
        public bool IsCreatedGroundroundSortingLayer()
        {
            string sortingLayerName = "Ground";
            return IsSortingLayerExists(sortingLayerName);
        }

        bool IsSortingLayerExists(string layerName)
        {
            foreach (SortingLayer layer in SortingLayer.layers)
            {
                if (layer.name == layerName)
                {
                    return true;
                }
            }
            return false;
        }


        public bool CheckSortingOrder()
        {
            string[] SortingLayers = { "Default", "Background", "Foreground", "Player", "Ground" };
            bool isDone = true;
            for (int i = 0; i < SortingLayers.Length; i++)
            {
                if (i == GetSortingLayerOrder(SortingLayers[i]))
                {
                    isDone = true;
                }
                else
                {
                    isDone = false;
                    return isDone;
                }
            }

            return isDone;
        }
        int GetSortingLayerOrder(string layerName)
        {
            foreach (SortingLayer layer in SortingLayer.layers)
            {
                if (layer.name == layerName)
                {
                    return layer.value;
                }
            }
            return -1;
        }


        public bool SetPlayerSortingLayer()
        {
            GameObject player = GameObject.Find("Player");
            return player.GetComponent<SpriteRenderer>().sortingLayerName == "Player";
           
        }

        public bool SetRoom1GroundSortingLayer()
        {
            GameObject room1 = GameObject.Find("Room1");
            GameObject parent = room1.transform.Find("Ground").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Ground");
        }
        public bool SetRoom1WallLeftSortingLayer()
        {
            GameObject room1 = GameObject.Find("Room1");
            GameObject parent = room1.transform.Find("WallLeft").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }
        public bool SetRoom1WallRightSortingLayer()
        {
            GameObject room1 = GameObject.Find("Room1");
            GameObject parent = room1.transform.Find("WallRight").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }
        public bool SetRoom1CeilingSortingLayer()
        {
            GameObject room1 = GameObject.Find("Room1");
            GameObject parent = room1.transform.Find("Ceiling").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }
        public bool SetRoom1RoomEndSortingLayer()
        {
            GameObject room1 = GameObject.Find("Room1");
            GameObject FineshLine = room1.transform.Find("RoomEnd").gameObject;
          
            return FineshLine.GetComponent<SpriteRenderer>().sortingLayerName == "Foreground";

        }
        public bool SetRoom1BackgroundSortingLayer()
        {
            GameObject room2 = GameObject.Find("Room1");
            GameObject parent = room2.transform.Find("Background").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Background");
        }  
        public bool SetRoom2GroundSortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject parent = room2.transform.Find("Ground").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Ground");
        }
      
        public bool SetRoom2WallRightSortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject parent = room2.transform.Find("WallRight").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }
        public bool SetRoom2CeilingSortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject parent = room2.transform.Find("Ceiling").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }
        public bool SetRoom2RoomEndLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject FineshLine = room2.transform.Find("RoomEnd").gameObject;
            return FineshLine.GetComponent<SpriteRenderer>().sortingLayerName == "Foreground";

        }
        public bool SetRoom2BackgroundSortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject parent = room2.transform.Find("Background").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Background");
        }
        public bool SetRoom3GroundSortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            GameObject parent = room3.transform.Find("Ground").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Ground");
        }
      
        public bool SetRoom3WallRightSortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            GameObject parent = room3.transform.Find("WallRight").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }
        public bool SetRoom3CeilingSortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            GameObject parent = room3.transform.Find("Ceiling").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }
        public bool SetRoom3RoomEndLayer()
        {
            GameObject room2 = GameObject.Find("Room3");
            GameObject FineshLine = room2.transform.Find("RoomEnd").gameObject;
            return FineshLine.GetComponent<SpriteRenderer>().sortingLayerName == "Foreground";

        }

        public bool SetRoom3BackgroundSortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            GameObject parent = room3.transform.Find("Background").gameObject;
            return AreAllChildrenSortingLayerSet(parent, "Background");
        }
        public bool SetFireballHolderSortingLayer()
        {
            if(GameObject.Find("FireballHolder")!=null)
            {
                GameObject FireballHolder = GameObject.Find("FireballHolder");
                return AreAllChildrenSortingLayerSet(FireballHolder, "Foreground");
            }
           return false;
        }
        List<SpriteRenderer> sortingOrderGO = new List<SpriteRenderer>();
        bool AreAllChildrenSortingLayerSet(GameObject parent, string sortingLayerName)
        {
            sortingOrderGO.Clear();           
            GetComponentsFromGameObject(parent);
            TraverseChildren(parent.transform);


            foreach (SpriteRenderer sr in sortingOrderGO)
            {
                if (sr.sortingLayerName != sortingLayerName)
                {
                    return false;
                }
            }
            return true;
        }
        void TraverseChildren(Transform parent)
        {
            foreach (Transform child in parent)
            {
                GetComponentsFromGameObject(child.gameObject);

                TraverseChildren(child);
            }
        }

        bool GetComponentsFromGameObject(GameObject obj)
        {
            SpriteRenderer[] spriteRenderer = obj.GetComponents<SpriteRenderer>();

            foreach (SpriteRenderer sr in spriteRenderer)
            {
                if (!sortingOrderGO.Contains(sr))
                {
                    sortingOrderGO.Add(sr);
                }
            }
            return false;
        }
    }
}
