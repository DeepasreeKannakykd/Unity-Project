using UnityEngine;
using UnityEngine.UI;

namespace Unity.Tutorials
{
   
    [CreateAssetMenu(fileName = "HealthSystemCriteria", menuName = "Tutorials/YVTgame/HealthSystemCriteria")]
    class HealthSystemCriteria : ScriptableObject
    {
        public bool IsCanvasCreated()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            if (canvas != null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public bool IsCanvas_UIScaleMode()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            if (canvas != null)
            {
                CanvasScaler canvasScaler = canvas.GetComponent<CanvasScaler>();
                if (canvasScaler != null)
                {
                    if (canvasScaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCanvas_Resolution()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            if (canvas != null)
            {
                CanvasScaler canvasScaler = canvas.GetComponent<CanvasScaler>();
                if (canvasScaler != null)
                {
                    if (canvasScaler.referenceResolution == new Vector2(1920, 1080))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCanvas_Match()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            if (canvas != null)
            {
                CanvasScaler canvasScaler = canvas.GetComponent<CanvasScaler>();
                if (canvasScaler != null)
                {
                    if (canvasScaler.matchWidthOrHeight == 0.5f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsHeathbarCreated()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            if(canvas.transform.Find("Healthbar")!=null)
            {
                GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;
                if (heathbar != null)
                
                    return true;
               
            }
            return false;
        }
        public bool IsHeathbar_SetFullStrech()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;
            if (heathbar != null)
            {
                RectTransform heathbar_rt = heathbar.GetComponent<RectTransform>();
                if (heathbar_rt.anchorMin == Vector2.zero && heathbar_rt.anchorMax == Vector2.one)
                    return true;
            }
            return false;
        }
        public bool IsHealthbarTotalCreated()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;
            if (heathbar != null)
            {
                if (heathbar.transform.Find("HealthbarTotal") != null)
                {
                    GameObject HealthbarTotal = heathbar.transform.Find("HealthbarTotal").gameObject;
                    if (HealthbarTotal != null)
                    {
                        return true;
                    }
                }
            }
                return false;
        }
        public bool IsHealthbarTotal_RectTransform_AnchorPresets()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                RectTransform HealthbarTotal_RT= HealthbarTotal.GetComponent<RectTransform>();  
                if(HealthbarTotal_RT.anchorMin == new Vector2(0, 1) && HealthbarTotal_RT.anchorMax == new Vector2(0, 1))
                    return true;
            }
            return false;
        } 
        public bool IsHealthbarTotal_RectTransform_Position()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                RectTransform HealthbarTotal_RT= HealthbarTotal.GetComponent<RectTransform>();
                if(HealthbarTotal_RT.anchoredPosition == new Vector2(350, -50))
                    return true;
            }
            return false;
        }
        public bool IsHealthbarTotal_RectTransform_SizeDelta()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                RectTransform HealthbarTotal_RT= HealthbarTotal.GetComponent<RectTransform>();  
                if(HealthbarTotal_RT.sizeDelta == new Vector2(680, 80))
                    return true;
            }
            return false;
        }
        public Sprite HealthbarTotalSprite;
        public bool IsHealthbarTotal_Image_SourceImage()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                Image HealthbarTotal_Img= HealthbarTotal.GetComponent<Image>();  
                if(HealthbarTotal_Img.sprite== HealthbarTotalSprite)
                    return true;
            }
            return false;
        }
        public bool IsHealthbarTotal_Image_Color()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                Image HealthbarTotal_Img= HealthbarTotal.GetComponent<Image>();  
                if(HealthbarTotal_Img.color== Color.black)
                    return true;
            }
            return false;
        } 
        public bool IsHealthbarTotal_Image_ImageType()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                Image HealthbarTotal_Img= HealthbarTotal.GetComponent<Image>();  
                if(HealthbarTotal_Img.type== Image.Type.Filled)
                    return true;
            }
            return false;
        } 
        public bool IsHealthbarTotal_Image_FillMethod()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                Image HealthbarTotal_Img= HealthbarTotal.GetComponent<Image>();  
                if(HealthbarTotal_Img.fillMethod== Image.FillMethod.Horizontal)
                    return true;
            }
            return false;
        } 
        public bool IsHealthbarTotal_Image_FillOrigin()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                Image HealthbarTotal_Img= HealthbarTotal.GetComponent<Image>();  
                if(HealthbarTotal_Img.fillOrigin== 0)
                    return true;
            }
            return false;
        }
        public bool IsHealthbarTotal_Image_FillAmount()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                Image HealthbarTotal_Img= HealthbarTotal.GetComponent<Image>();  
                if(HealthbarTotal_Img.fillAmount== 0.3f)
                    return true;
            }
            return false;
        } 
        public bool IsHealthbarTotal_Image_PreserveAspect()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarTotal = GameObject.Find("HealthbarTotal").gameObject;
            if (HealthbarTotal != null)
            {                
                Image HealthbarTotal_Img= HealthbarTotal.GetComponent<Image>();  
                if(HealthbarTotal_Img.preserveAspect)
                    return true;
            }
            return false;
        }
        public bool IsHealthbarCurrentCreated()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();
            GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;
            if (heathbar != null)
            {
                if (heathbar.transform.Find("HealthbarCurrent")!=null)
                {
                    GameObject HealthbarCurrent = heathbar.transform.Find("HealthbarCurrent").gameObject;
                    if (HealthbarCurrent != null)
                    {
                        Image HealthbarCurrent_Img = HealthbarCurrent.GetComponent<Image>();
                        if (HealthbarCurrent_Img.preserveAspect)
                            return true;
                    }
                }
                
            }
            return false;
        }
        public bool IsHealthbarCurrent_Image_Color()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject HealthbarCurrent = GameObject.Find("HealthbarCurrent").gameObject;
            if (HealthbarCurrent != null)
            {
                Image HealthbarCurrent_Img = HealthbarCurrent.GetComponent<Image>();
                if (HealthbarCurrent_Img.color == Color.white)
                    return true;
            }
            return false;
        }
        public bool IsPlayer_HeathAdded()
        {
           

            GameObject player = GameObject.Find("Player").gameObject;
            if (player != null)
            {
                Health playerHeath = player.GetComponent<Health>();  
                if(playerHeath!=null)
                    return true;
            }
            return false;
        }  
        public bool IsPlayer_Health_StartingHealth()
        {
           

            GameObject player = GameObject.Find("Player").gameObject;
            if (player != null)
            {
                Health playerHeath = player.GetComponent<Health>();  
                if(playerHeath!=null)
                {
                    if(playerHeath.startingHealth==3)
                        return true;
                }
            }
            return false;
        }
        public bool IsPlayer_Health_IFrameDuration()
        {
           

            GameObject player = GameObject.Find("Player").gameObject;
            if (player != null)
            {
                Health playerHeath = player.GetComponent<Health>();  
                if(playerHeath!=null)
                {
                    if(playerHeath.iFramesDuration==1.5f)
                        return true;
                }
            }
            return false;
        }
        public bool IsPlayer_Health_NoOfFlashes()
        {
           

            GameObject player = GameObject.Find("Player").gameObject;
            if (player != null)
            {
                Health playerHeath = player.GetComponent<Health>();  
                if(playerHeath!=null)
                {
                    if(playerHeath.numberOfFlashes==3)
                        return true;
                }
            }
            return false;
        } 
        public bool IsPlayer_Health_SetComponentLength()
        {
           

            GameObject player = GameObject.Find("Player").gameObject;
            if (player != null)
            {
                Health playerHeath = player.GetComponent<Health>();  
                if(playerHeath!=null)
                {
                    if(playerHeath.components.Length==3)
                        return true;
                }
            }
            return false;
        }

        public bool IsPlayer_Health_AssignComponents()
        {
           

            GameObject player = GameObject.Find("Player").gameObject;
            if (player != null)
            {
                Health playerHeath = player.GetComponent<Health>();  
                if(playerHeath!=null)
                {
                    if(playerHeath.components.Length==3)
                    {
                        if (playerHeath.components[0]==player.GetComponent<PlayerAttack>()&&
                            playerHeath.components[1]==player.GetComponent<PlayerMovement>()&& 
                            playerHeath.components[2]==player.GetComponent<Health>())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsHeathbar_HeathbarAdded()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;
            if (heathbar != null)
            {
                Healthbar heathbar_HB = heathbar.GetComponent<Healthbar>();
                if (heathbar_HB!=null)
                    return true;
            }
            return false;
        }

        public bool IsHeathbar_Heathbar_PlayerHeath()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;
            if (heathbar != null)
            {
                Healthbar heathbar_HB = heathbar.GetComponent<Healthbar>();
                if (heathbar_HB != null)
                {
                    GameObject player = GameObject.Find("Player").gameObject;
                    if (player != null)
                    {
                        Health playerHeath = player.GetComponent<Health>();
                        if (heathbar_HB.playerHealth == playerHeath)
                            return true;
                    }
                }

            }
            return false;
        }

        public bool IsHeathbar_Heathbar_TotalHeathBar()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;

            if (heathbar != null)
            {
                Healthbar heathbar_HB = heathbar.GetComponent<Healthbar>();
                if (heathbar_HB != null)
                {
                    GameObject HealthbarTotal = heathbar_HB.transform.Find("HealthbarTotal").gameObject;
                    if (HealthbarTotal != null)
                    {
                        Image HealthbarTotal_Img = HealthbarTotal.GetComponent<Image>();
                        if (heathbar_HB.healthbarTotal== HealthbarTotal_Img)
                            return true;
                    }
                }

            }
            return false;
        }

        public bool IsHeathbar_Heathbar_CurrentHeathBar()
        {
            Canvas canvas = FindFirstObjectByType<Canvas>();

            GameObject heathbar = canvas.transform.Find("Healthbar").gameObject;

            if (heathbar != null)
            {
                Healthbar heathbar_HB = heathbar.GetComponent<Healthbar>();
                if (heathbar_HB != null)
                {
                    GameObject HealthbarCurrent = heathbar_HB.transform.Find("HealthbarCurrent").gameObject;
                    if (HealthbarCurrent != null)
                    {
                        Image HealthbarCurrent_Img = HealthbarCurrent.GetComponent<Image>();
                        if (heathbar_HB.healthbarCurrent== HealthbarCurrent_Img)
                            return true;
                    }
                }

            }
            return false;
        }
    }
}