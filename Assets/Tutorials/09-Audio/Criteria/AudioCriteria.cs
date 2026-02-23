using UnityEngine;

namespace Unity.Tutorials
{
    [CreateAssetMenu(fileName = "AudioCriteria", menuName = "Tutorials/YVTgame/AudioCriteria")]
    class AudioCriteria : ScriptableObject
    {
        public bool IsSoundManagerCreated()
        {
            if (GameObject.Find("SoundManager") != null)
            {
                if (GameObject.Find("SoundManager").GetComponent<AudioSource>() != null)
                {
                    Transform soundMansger = GameObject.Find("SoundManager").transform;
                    if (soundMansger.localPosition == new Vector3(0, 0, 0))
                    {
                        return true;
                    }  
                }
            }
            return false;
        }
        public bool IsSoundManager_SoundManager_Added()
        {
            if (GameObject.Find("SoundManager") != null)
            {
                if (GameObject.Find("SoundManager").GetComponent<SoundManager>() != null)
                    return true;
            }
            return false;
        }
        public bool IsMusicSourceCreated()
        {
            if (GameObject.Find("SoundManager") != null)
            {

                GameObject soundManager = GameObject.Find("SoundManager");
                if (GameObject.Find("MusicSource") != null)
                {
                    if (soundManager.transform.Find("MusicSource").gameObject != null)
                    {
                        if (soundManager.transform.Find("MusicSource").GetComponent<AudioSource>() != null)
                            return true;
                    }
                }
            }
            return false;
        }
        public AudioClip musicSourceClip;
        public bool IsMusicSourceClipAdded()
        {
            if (GameObject.Find("SoundManager") != null)
            {
                GameObject soundManager = GameObject.Find("SoundManager");
                if (soundManager.transform.Find("MusicSource").gameObject != null)
                {
                    GameObject MusicSource = soundManager.transform.Find("MusicSource").gameObject;
                    if (MusicSource.GetComponent<AudioSource>() != null)
                        if (MusicSource.GetComponent<AudioSource>().clip != null)
                            if (MusicSource.GetComponent<AudioSource>().clip == musicSourceClip)
                                return true;
                }
            }
            return false;
        }
    }
}