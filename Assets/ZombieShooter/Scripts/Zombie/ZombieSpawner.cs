using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject fx_Shred;

    private GameObject zombie;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;

        fx_Shred.SetActive(true);

        AudioManager.instance.ZombieRiseSound();

        zombie = Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);

        if (zombie.transform.position.x < player.position.x)
        {
            zombie.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (zombie.transform.position.x > player.position.x)
        {
            zombie.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        StartCoroutine(WaitDeactivate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitDeactivate()
    {
        yield return new WaitForSeconds(Random.Range(2.5f, 4f));

        gameObject.SetActive(false);
    }
}
