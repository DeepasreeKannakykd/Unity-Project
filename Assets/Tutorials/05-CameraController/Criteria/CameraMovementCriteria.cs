                 using UnityEngine;

namespace Unity.Tutorials
{
   
    [CreateAssetMenu(fileName = "CameraMovementCriteria", menuName = "Tutorials/YVTgame/CameraMovementCriteria")]
    class CameraMovementCriteria : ScriptableObject
    {
        public bool IsCameraControllerAdded()
        {
            GameObject camera = Camera.main.gameObject;
            if (camera.GetComponent<CameraController>() != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool IsCameraController_Speed()
        {
            GameObject camera = Camera.main.gameObject;
            if (camera.GetComponent<CameraController>() != null)
            {
                if (camera.GetComponent<CameraController>().speed == 0.5f)
                {
                    return true;

                }
                else { return false; }
            }
            else
            {
                return false;
            }

        }
        public bool IsCameraController_Player()
        {
            GameObject camera = Camera.main.gameObject;
            GameObject player = GameObject.Find("Player");
            if (camera.GetComponent<CameraController>() != null)
            {

                if (camera.GetComponent<CameraController>().player == player.transform)
                {
                    return true;

                }
                else
                { return false; }
            }
            else
            {
                return false;
            }

        }
        public bool IsCameraController_AheadDistance()
        {
            GameObject camera = Camera.main.gameObject;
            if (camera.GetComponent<CameraController>() != null)
            {
                if (camera.GetComponent<CameraController>().aheadDistance == 2)
                {
                    return true;

                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }
        public bool IsCameraController_CameraSpeed()
        {
            GameObject camera = Camera.main.gameObject;
            if (camera.GetComponent<CameraController>() != null)
            {
                if (camera.GetComponent<CameraController>().cameraSpeed == 0.5f)
                {
                    return true;

                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }
        public bool IsRoom1Door_DoorAdded()
        {
            GameObject level=GameObject.Find("Level");
            if (level.transform.childCount > 0)
            {
                Transform Room1 = level.transform.Find("Room1");

                GameObject Room1Door = Room1.transform.Find("Door").gameObject;
                if(Room1Door!=null)
                {
                    return Room1Door.GetComponent<Door>();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }  
        public bool IsRoom1Door_Door_PreviousRoom()
        {
            GameObject level=GameObject.Find("Level");
            Transform Room1 = level.transform.Find("Room1");
            Transform Room2 = level.transform.Find("Room2");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room1Door= Room1.transform.Find("Door").gameObject;
                if(Room1Door!=null)
                {
                    if(Room1Door.GetComponent<Door>() != null)
                    {

                        return Room1Door.GetComponent<Door>().previousRoom==Room1;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom1Door_Door_NextRoom()
        {
            GameObject level=GameObject.Find("Level");
            Transform Room1 = level.transform.Find("Room1");
            Transform Room2 = level.transform.Find("Room2");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room1Door= Room1.transform.Find("Door").gameObject;
                if(Room1Door!=null)
                {
                    if(Room1Door.GetComponent<Door>() != null)
                    {

                        return Room1Door.GetComponent<Door>().nextRoom==Room2;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom1Door_Door_CameraController()
        {
            GameObject level=GameObject.Find("Level");
            Transform Room1 = level.transform.Find("Room1");
            Transform Room2 = level.transform.Find("Room2");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room1Door=Room1.transform.Find("Door").gameObject;
                if(Room1Door!=null)
                {
                    if(Room1Door.GetComponent<Door>() != null)
                    {

                        return Room1Door.GetComponent<Door>().cameraController == cameraController;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }

        public bool IsRoom2Door_DoorAdded()
        {
            GameObject level = GameObject.Find("Level");
            if (level.transform.childCount > 0)
            {
                Transform Room2 = level.transform.Find("Room2");

                GameObject Room2Door = Room2.transform.Find("Door").gameObject;
                if (Room2Door != null)
                {
                    return Room2Door.GetComponent<Door>();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom2Door_Door_PreviousRoom()
        {
            GameObject level = GameObject.Find("Level");
            Transform Room2 = level.transform.Find("Room2");
            Transform Room3 = level.transform.Find("Room3");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room2Door = Room2.transform.Find("Door").gameObject;
                if (Room2Door != null)
                {
                    if (Room2Door.GetComponent<Door>() != null)
                    {

                        return Room2Door.GetComponent<Door>().previousRoom == Room2;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom2Door_Door_NextRoom()
        {
            GameObject level = GameObject.Find("Level");
            Transform Room2 = level.transform.Find("Room2");
            Transform Room3 = level.transform.Find("Room3");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room2Door = Room2.transform.Find("Door").gameObject;
                if (Room2Door != null)
                {
                    if (Room2Door.GetComponent<Door>() != null)
                    {

                        return Room2Door.GetComponent<Door>().nextRoom == Room3;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom2Door_Door_CameraController()
        {
            GameObject level = GameObject.Find("Level");
            Transform Room2 = level.transform.Find("Room2");
            Transform Room3 = level.transform.Find("Room3");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room2Door = Room2.transform.Find("Door").gameObject;
                if (Room2Door != null)
                {
                    if (Room2Door.GetComponent<Door>() != null)
                    {

                        return Room2Door.GetComponent<Door>().cameraController == cameraController;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }

        public bool IsRoom3Door_DoorAdded()
        {
            GameObject level = GameObject.Find("Level");
            if (level.transform.childCount > 0)
            {
                Transform Room3 = level.transform.Find("Room3");

                GameObject Room3Door = Room3.transform.Find("Door").gameObject;
                if (Room3Door != null)
                {
                    return Room3Door.GetComponent<Door>();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom3Door_Door_PreviousRoom()
        {
            GameObject level = GameObject.Find("Level");
            Transform Room3 = level.transform.Find("Room3");
            Transform Room4 = level.transform.Find("Room4");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room3Door = Room3.transform.Find("Door").gameObject;
                if (Room3Door != null)
                {
                    if (Room3Door.GetComponent<Door>() != null)
                    {

                        return Room3Door.GetComponent<Door>().previousRoom == Room3;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom3Door_Door_NextRoom()
        {
            GameObject level = GameObject.Find("Level");
            Transform Room3 = level.transform.Find("Room3");
            Transform Room4 = level.transform.Find("Room4");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room3Door = Room3.transform.Find("Door").gameObject;
                if (Room3Door != null)
                {
                    if (Room3Door.GetComponent<Door>() != null)
                    {

                        return Room3Door.GetComponent<Door>().nextRoom == Room4;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsRoom3Door_Door_CameraController()
        {
            GameObject level = GameObject.Find("Level");
            Transform Room3 = level.transform.Find("Room3");
            Transform Room4 = level.transform.Find("Room4");
            CameraController cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (level.transform.childCount > 0)
            {
                GameObject Room3Door = Room3.transform.Find("Door").gameObject;
                if (Room3Door != null)
                {
                    if (Room3Door.GetComponent<Door>() != null)
                    {

                        return Room3Door.GetComponent<Door>().cameraController == cameraController;
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
        public bool IsPlayerTagSet()
        {
            GameObject player = GameObject.Find("Player");

            return player.tag == "Player";
        }

    }
}