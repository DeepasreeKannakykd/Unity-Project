using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Unity.Tutorials
{
    [CreateAssetMenu(fileName = "PlayerMovementCriteria", menuName = "Tutorials/YVTgame/PlayerMovementCriteria")]
    class PlayerMovementCriteria : ScriptableObject
    {

        public AudioClip narrationClip;
        public void PlayAudio()
        {
            if (GameObject.Find("TutorialGuideAudioSource") != null)
            {
                DestroyImmediate(GameObject.Find("TutorialGuideAudioSource"));
            }
            GameObject tutorialGuideAudioSourceGO = new GameObject("TutorialGuideAudioSource");
            AudioSource tutorialGuideAudioSource;
            tutorialGuideAudioSourceGO.AddComponent<AudioSource>();
            tutorialGuideAudioSource = tutorialGuideAudioSourceGO.GetComponent<AudioSource>();
            tutorialGuideAudioSource.pitch = 1f;
            tutorialGuideAudioSource.volume = 1f;
            tutorialGuideAudioSource.PlayOneShot(narrationClip);
            Debug.Log("Page Is Showing");
            tutorialGuideAudioSourceGO.hideFlags = HideFlags.HideInHierarchy;
        }
        public bool IsMainSceneOpened()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE
            return EditorSceneManager.GetActiveScene().name == "MainScene";
#else
            return false;
#endif
        }
        public bool IsPlayerFound()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            if ( GameObject.Find("Player")!=null)
            {
                GameObject player = GameObject.Find("Player");
                if (player.GetComponent<SpriteRenderer>() != null)
                {
                    if (player.transform.localPosition == new Vector3(-6, 0, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
#else
            return false;
#endif
        }
        public bool IsPlayerSprite()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            return GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite.name== "Player";
#else
            return false;
#endif 
        }
        public bool IsPlayerSpriteRenderSortOrder()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            return GameObject.Find("Player").GetComponent<SpriteRenderer>().sortingOrder == 1;
#else
            return false;
#endif 
        }

        public bool IsPlayerBoxCollider2D()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            if(GameObject.Find("Player").GetComponent<BoxCollider2D>())
            {
                BoxCollider2D boxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();

                if(boxCollider2D.offset==new Vector2(0.1f,-0.5f)&&boxCollider2D.size==new Vector2(1,1.5f))
                {
                    return true;
                }
            }
            return false;
#else
            return false;
#endif 
        }
        public bool IsPlayerRigidbody2D()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            return GameObject.Find("Player").GetComponent<Rigidbody2D>();
#else
            return false;
#endif 
        }
        public bool IsPlayerPlayerMovementComponent()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            return GameObject.Find("Player").GetComponent<PlayerMovement>();
#else
            return false;
#endif 
        }
        public bool IsPlayerAnimator()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            return GameObject.Find("Player").GetComponent<Animator>();
#else
            return false;
#endif 
        }
        public bool IsPlayerAnimatorController()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            if(GameObject.Find("Player").GetComponent<Animator>()!=null)
            {
                Animator animator = GameObject.Find("Player").GetComponent<Animator>();
                if(animator.runtimeAnimatorController!=null)
                {
                    if (animator.runtimeAnimatorController.name == "Player")
                    {
                        return true;
                    }
                }
            }
            return false;
#else
            return false;
#endif 
        }
        public bool IsLevelGameObjectCreated()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE


            if (GameObject.Find("Level") == null)
            {
                return false;
            }
            else
            {
                GameObject player = GameObject.Find("Level");
                if (player.transform.localPosition == new Vector3(0, 0, 0))
                {
                    return true;
                }
            }
            return false;
#else
            return false;
#endif 
        }
        public bool IsAssignRoom1ToLevelChild()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            GameObject Level= GameObject.Find("Level");
            if(GameObject.Find("Room1")!=null)
            {
                GameObject Room1 = GameObject.Find("Room1");
                if (Room1.transform.IsChildOf(Level.transform))
                {
                    return true;
                }
            }
            return false;

#else
            return false;
#endif 
        }
        public bool IsCreatedPlayerLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            string layerName = "Player";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (layerIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
#else
            return false;
#endif 
        }

        public bool IsCreatedGroundLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            string layerName = "Ground";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (layerIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
#else
            return false;
#endif 
        }
        public bool IsCreatedWallLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            string layerName = "Wall";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (layerIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
#else
            return false;
#endif 
        }

        public bool SetPlayerLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            GameObject player = GameObject.Find("Player");
            string layerName = "Player";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (player.layer== layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

#else
            return false;
#endif 
        }
        public bool SetGroundLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            GameObject player = GameObject.Find("Ground");
            string layerName = "Ground";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (player.layer== layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

#else
            return false;
#endif 
        }
        public bool SetWallLeftLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            GameObject player = GameObject.Find("WallLeft");
            string layerName = "Wall";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (player.layer== layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

#else
            return false;
#endif 
        }
        public bool SetWallRightLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            GameObject player = GameObject.Find("WallRight");
            string layerName = "Wall";
            int layerIndex = LayerMask.NameToLayer(layerName);

            if (player.layer== layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

#else
            return false;
#endif 
        }

        public bool IsPlayerMovement_MovementParameters()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
          
            if(playerMovement.speed==10&&playerMovement.jumpPower==20)
            {
                return true;
            }
            else
            { return false; }

#else
            return false;
#endif 
        }
        public bool IsPlayerMovement_CoyoteTime()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
          
            if(playerMovement.coyoteTime==0.25f)
            {
                return true;
            }
            else
            { return false; }

#else
            return false;
#endif 
        }
        public bool IsPlayerMovement_ExtraJumps()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
          
            if(playerMovement.extraJumps==1)
            {
                return true;
            }
            else
            { return false; }

#else
            return false;
#endif 
        }
        public bool IsPlayerMovement_WallJumps()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
          
            if(playerMovement.wallJumpX==1500&&playerMovement.wallJumpY==750)
            {
                return true;
            }
            else
            { return false; }

#else
            return false;
#endif 
        }
        public bool IsPlayerMovement_GroundLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
            int layerIndex = LayerMask.GetMask("Ground");
            if (playerMovement.groundLayer.value== layerIndex)
            {
                return true;
            } 
            return false; 
           


#else
            return false;
#endif 
        }
        public bool IsPlayerMovement_WallLayer()
        {
#if UNITY_TUTORIALS_CORE_EDITOR_AVAILABLE

            PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
            int layerIndex = LayerMask.GetMask("Wall");
            if (playerMovement.wallLayer.value == layerIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

#else
            return false;
#endif 
        }

    }
}
