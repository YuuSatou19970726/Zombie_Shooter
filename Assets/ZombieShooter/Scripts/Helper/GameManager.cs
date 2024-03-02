using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;

    [HideInInspector]
    public int character_Index;

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        character_Index = 0;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name != TagManager.MAIN_MENU_NAME)
        {
            if (character_Index != 0)
            {
                GameObject characterTemp = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);

                Instantiate(characters[character_Index], characterTemp.transform.position, Quaternion.identity);

                characterTemp.SetActive(false);
            }
        }
    }
}
