using System.Collections.Generic;
using UnityEngine;

namespace Unity.Tutorials
{
    [CreateAssetMenu(fileName = "AddEnemyCriteria", menuName = "Tutorials/YVTgame/AddEnemyCriteria")]
    class AddEnemyCriteria : ScriptableObject
    {
        public bool IsMeleeEnemyRoom2Created()
        {
            GameObject room2 = GameObject.Find("Room2");
           
            if (room2.transform.Find("MeleeEnemy") != null)
            {
                Transform child = room2.transform.Find("MeleeEnemy").transform;               
                if (child.transform.IsChildOf(room2.transform))
                {
                    return true;
                }
            }
            return false;
        }
        public bool SetMeleeEnemyRoom2SortingLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject MeleeEnemy = room2.transform.Find("MeleeEnemy").gameObject;
            if (MeleeEnemy.GetComponent<SpriteRenderer>().sortingLayerName == "Foreground")
            {
                return true;
            }
            return false;
        } 
        public bool SetMeleeEnemyPlayerLayer()
        {
            GameObject room2 = GameObject.Find("Room2");
            GameObject MeleeEnemy = room2.transform.Find("MeleeEnemy").gameObject;
            int layerIndex = LayerMask.GetMask("Player");

            if (MeleeEnemy.GetComponent<MeleeEnemy>().playerLayer.value == layerIndex)
            {
                return true;
            }
            return false;
        }
    
        public bool IsRangedEnemyHolderRoom3Created()
        {
            GameObject room3 = GameObject.Find("Room3");

            if (room3.transform.Find("RangedEnemyHolder") != null)
            {
                Transform child = room3.transform.Find("RangedEnemyHolder").transform;
                if (child.transform.IsChildOf(room3.transform))
                {
                    return true;
                }
            }
            return false;
        }
        public bool SetRangedEnemySortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            if (room3.transform.Find("RangedEnemyHolder") != null)
            {
                GameObject arrowTrap = room3.transform.Find("RangedEnemyHolder").gameObject;
                if (arrowTrap.transform.Find("RangedEnemy") != null)
                {
                    if (arrowTrap.transform.Find("RangedEnemy").GetComponent<SpriteRenderer>().sortingLayerName == "Foreground")
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool SetRangedEnemyFireballsHolderSortingLayer()
        {
            GameObject room3 = GameObject.Find("Room3");
            GameObject RangedEnemyHolder = room3.transform.Find("RangedEnemyHolder").gameObject;
            if (RangedEnemyHolder.transform.Find("FireballsHolder") != null)
            {
                GameObject FireballsHolder = RangedEnemyHolder.transform.Find("FireballsHolder").gameObject;
                return AreAllChildrenSortingLayerSet(FireballsHolder, "Foreground");

            }
            return false;

        }

        public bool SetRangedEnemyPlayerLayer()
        {
            // RangedEnemy
            GameObject room3 = GameObject.Find("Room3");           
           
            if (room3.transform.Find("RangedEnemyHolder") != null)
            {
                GameObject RangedEnemyHolder = room3.transform.Find("RangedEnemyHolder").gameObject;
                if (RangedEnemyHolder.transform.Find("RangedEnemy") != null)
                {
                    GameObject RangedEnemy = RangedEnemyHolder.transform.Find("RangedEnemy").gameObject;

                    int layerIndex = LayerMask.GetMask("Player");

                    if (RangedEnemy.GetComponent<RangedEnemy>().playerLayer.value == layerIndex)
                    {
                        return true;
                    }
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