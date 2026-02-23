 using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Unity.Tutorials
{   
    [CreateAssetMenu(fileName = "ShootingCriteria", menuName = "Tutorials/YVTgame/ShootingCriteria")]
    class ShootingCriteria : ScriptableObject
    {
        public bool IsPlayerAttackAdded()
        {
            return GameObject.Find("Player").GetComponent<PlayerAttack>();
        }
        public bool IsCreateFirePoint()
        {
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                if (player.transform.childCount > 0)
                {
                    if(player.transform.GetChild(0).gameObject.name == "FirePoint")
                    {
                        GameObject FirePoint = player.transform.GetChild(0).gameObject;// == "FirePoint";

                        if(FirePoint.name== "FirePoint")
                        {
                            if (FirePoint.transform.localPosition == new Vector3(1.5f, -0.5f, 0))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
            
        }
        public bool IsCreateFireballHolder()
        {
            GameObject FireballHolder = GameObject.Find("FireballHolder");
            if (FireballHolder != null)
            {
                if (FireballHolder.transform.localPosition == new Vector3(0, 0, 0))
                {
                    return true;
                }
            }
            
                return false;
            
        }

        public bool IsAssignFireBallToFireballHolder()
        {
            GameObject FireballHolder = GameObject.Find("FireballHolder");
            Projectile[] Fireball = Resources.FindObjectsOfTypeAll<Projectile>();

            if (Fireball[0].transform.IsChildOf(FireballHolder.transform))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool IsTenFireBallInsideFireballHolder()
        {
            GameObject FireballHolder = GameObject.Find("FireballHolder");

            if (FireballHolder.transform.childCount == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsPlayerAttack_AttackCooldown()
        {
            PlayerAttack playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();

            if (playerAttack.attackCooldown == 1)
            {
                return true;
            }
            else
            { return false; }

        }
        public bool IsPlayerAttack_FirePoint()
        {
            PlayerAttack playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();

            if (playerAttack.firePoint == playerAttack.transform.GetChild(0).gameObject.transform)
            {
                return true;
            }
            else
            { return false; }

        }
        public bool IsPlayerAttack_FireBallsReference()
        {
            PlayerAttack playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
            GameObject FireballHolder = GameObject.Find("FireballHolder");

            bool isAllRefAssigned = true;
            if(playerAttack.fireballs.Length==10)
            {
                if (FireballHolder.transform.childCount >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (playerAttack.fireballs[i] == null)
                        {
                            isAllRefAssigned = false;
                            return isAllRefAssigned;
                        }
                    }
                }
                else
                {
                    isAllRefAssigned = false;
                    return isAllRefAssigned;
                }
            }
            else
            {
                isAllRefAssigned = false;
            }
           
            return isAllRefAssigned;

        }
        public AudioClip FireballSound;
        public bool IsPlayerAttack_FireBallSound()
        {
            PlayerAttack playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();

            if (playerAttack.fireballSound == FireballSound)
            {
                return true;
            }
            else
            {  return false; }

        }
    }
}
