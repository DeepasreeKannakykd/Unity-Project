using System.Collections.Generic;
using UnityEngine;

namespace Unity.Tutorials
{
    [CreateAssetMenu(fileName = "AddTrapsCriteria", menuName = "Tutorials/YVTgame/AddTrapsCriteria")]
    class AddTrapsCriteria : ScriptableObject
    {
        public bool IsSpikesTrapRoom1Created()
        {
            GameObject room1 = GameObject.Find("Room1");
            if (room1.transform.Find("Spikes") != null)
            {
                Transform child = room1.transform.Find("Spikes").transform;
                return true;
            }
            return false;
           
        } 
        public bool SetSpikesChildRoom1SortingLayer()
        {
            GameObject room1 = GameObject.Find("Room1");
            GameObject parent = room1.transform.Find("Spikes").gameObject;


            return AreAllChildrenSortingLayerSet(parent, "Foreground");
        }

        public bool IsFireTrapRoom2Created()
        {
            GameObject room2 = GameObject.Find("Room2");

            if (room2.transform.Find("FireTrap") != null)
            {
                return true;
            }
            return false;
           
        }

        public bool SetFireTrapRoom2SortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject Firetrap = room2.transform.Find("FireTrap").gameObject;
            return Firetrap.GetComponent<SpriteRenderer>().sortingLayerName == "Foreground";

        }
        public bool IsArrowTrapRoom2Created()
        {
            GameObject room2 = GameObject.Find("Room2");
            if (room2.transform.Find("ArrowTrap") != null)
            {
                GameObject arrowTrap = room2.transform.Find("ArrowTrap").gameObject;
                Transform child = room2.transform.Find("ArrowTrap").transform;
                return true;
            }
            return false;
        }

        public bool SetArrowTrapSpriteRoom2SortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            if (room2.transform.Find("ArrowTrap") != null)
            {
                GameObject arrowTrap = room2.transform.Find("ArrowTrap").gameObject;
                if (arrowTrap.transform.Find("Sprite") != null)
                {
                    if (arrowTrap.transform.Find("Sprite").GetComponent<SpriteRenderer>().sortingLayerName == "Foreground")
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool SetArrowTrapArrowHolderRoom2SortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject ArrowTrap = room2.transform.Find("ArrowTrap").gameObject;
            if (ArrowTrap.transform.Find("ArrowHolder") != null)
            {
                GameObject ArrowHolder = ArrowTrap.transform.Find("ArrowHolder").gameObject;
                return AreAllChildrenSortingLayerSet(ArrowTrap, "Foreground");

            }
            return false;

        }
        bool ParentContainsChildWithComponent<T>(Transform parent) where T : ArrowTrap
        {
            bool isDone = true;
            foreach (Transform child in parent)
            {
                T component = child.GetComponent<T>();
                if (component != null)
                {
                    // isDone= true; 
                }
                else
                {
                    isDone = false;
                }
            }
            return isDone; 
        }
        public bool IsArrowTrapRoom3Created()
        {
            GameObject room3 = GameObject.Find("Room3");
            if (room3.transform.Find("ArrowTrap") != null)
            {
                Transform child = room3.transform.Find("ArrowTrap").transform;
                return true;
            }
            return false;
        }
        public bool SetArrowTrapSpriteRoom3SortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            if (room3.transform.Find("ArrowTrap") != null)
            {
                GameObject arrowTrap = room3.transform.Find("ArrowTrap").gameObject;
                if (arrowTrap.transform.Find("Sprite") != null)
                {
                    if (arrowTrap.transform.Find("Sprite").GetComponent<SpriteRenderer>().sortingLayerName == "Foreground")
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool SetArrowTrapArrowHolderRoom3SortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            GameObject ArrowTrap = room3.transform.Find("ArrowTrap").gameObject;
            if (ArrowTrap.transform.Find("ArrowHolder") != null)
            {
                GameObject ArrowHolder = ArrowTrap.transform.Find("ArrowHolder").gameObject;
                return AreAllChildrenSortingLayerSet(ArrowTrap, "Foreground");

            }
            return false;

        }

        public bool ArrowTrapRoom3PositionAndRotation()
        {
            GameObject parentObject = GameObject.Find("Room3");

            List<ArrowTrap> arrowTraps = GetComponentsFromAllChildren<ArrowTrap>(parentObject.transform);

            if (arrowTraps.Count > 0)
            {
                bool isPositionDone=false;

               if( arrowTraps[0].transform.localPosition == new Vector3(-6f, 3.5f, 0))
               {
                    isPositionDone = true;

               }

                bool isRotationDone = false;

                float zRotation = arrowTraps[0].transform.eulerAngles.z;
                if (zRotation > 180)
                    zRotation -= 360;
                if (zRotation == -90)
                {
                    isRotationDone = true;

                }
                if (isPositionDone && isRotationDone)
                {
                    return true;
                }
                else
                { 
                    return false;
                }

            }
            return false;

        }      

        public bool ArrowTrap2Room3PositionAndRotation()
        {
            GameObject parentObject = GameObject.Find("Room3");

            List<ArrowTrap> arrowTraps = GetComponentsFromAllChildren<ArrowTrap>(parentObject.transform);
            if (arrowTraps.Count > 1)
            {
                bool isPositionDone = false;

                if (arrowTraps[1].transform.localPosition == new Vector3(-5f, 3.5f, 0))
                {
                    isPositionDone = true;

                }

                bool isRotationDone = false;

                float zRotation = arrowTraps[1].transform.eulerAngles.z;
                if (zRotation > 180)
                    zRotation -= 360;
                if (zRotation == -90)
                {
                    isRotationDone = true;

                }
                if (isPositionDone && isRotationDone)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }
        public bool ArrowTrap3Room3PositionAndRotation()
        {
            GameObject parentObject = GameObject.Find("Room3");

            List<ArrowTrap> arrowTraps = GetComponentsFromAllChildren<ArrowTrap>(parentObject.transform);

            if (arrowTraps.Count > 2)
            {
                bool isPositionDone = false;

                if (arrowTraps[2].transform.localPosition == new Vector3(-4f, 3.5f, 0))
                {
                    isPositionDone = true;

                }

                bool isRotationDone = false;

                float zRotation = arrowTraps[2].transform.eulerAngles.z;
                if (zRotation > 180)
                    zRotation -= 360;
                if (zRotation == -90)
                {
                    isRotationDone = true;

                }
                if (isPositionDone && isRotationDone)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }
        public bool ArrowTrap4Room3PositionAndRotation()
        {
            GameObject parentObject = GameObject.Find("Room3");

            List<ArrowTrap> arrowTraps = GetComponentsFromAllChildren<ArrowTrap>(parentObject.transform);
            
            if (arrowTraps.Count > 3)
            {
                bool isPositionDone = false;

                if (arrowTraps[3].transform.localPosition == new Vector3(-3f, 3.5f, 0))
                {
                    isPositionDone = true;

                }

                bool isRotationDone = false;

                float zRotation = arrowTraps[3].transform.eulerAngles.z;
                if (zRotation > 180)
                    zRotation -= 360;
                if (zRotation == -90)
                {
                    isRotationDone = true;

                }
                if (isPositionDone && isRotationDone)
                {
                    return true;
                }
                else
                {
                    return false;
                }

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
        List<T> GetComponentsFromAllChildren<T>(Transform parent) where T : Component
        {
            List<T> components = new List<T>();

            foreach (Transform child in parent)
            {
                T component = child.GetComponent<T>();
                if (component != null)
                {
                    components.Add(component);
                }
            }

            return components;
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