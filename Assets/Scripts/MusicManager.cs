using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [Header("----------i just learned i can do this wow----------")]
    public AudioSource myMusic;

    public AudioSource mySounds;

    public AudioClip mxTitle;
    public AudioClip mxMainLevel;
    public AudioClip mxShower;

    public AudioClip sfxClick;
    public AudioClip sfxPos;
    public AudioClip sfxNeg;

    // public AudioFadeOut fadeOut;

    public static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
            //if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

  /*  void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/

    private void Start()
    {
        myMusic = GetComponent<AudioSource>();
        myMusic.clip = mxTitle;
        myMusic.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(FadeOut(myMusic, 2.5f));
            
            //AudioClip thisLevelMusic = mxMainLevel;
            //myMusic.clip = thisLevelMusic;
            //myMusic.loop = true;
            //myMusic.Play();
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            StartCoroutine(FadeOut(myMusic, 3f));
            //StopMusic();
        }

        /*public void PlayClickSound()
    {
        mySounds.clip = sfxClick;
        mySounds.PlayOneShot(sfxClick);
    }*/

        IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
        {
            float startVolume = audioSource.volume;
            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

                yield return null;
            }

            //audioSource.Stop();
            //audioSource.volume = startVolume;
        }
    }
}