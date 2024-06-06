using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> collectibles;

    [Min(0f)]
    [SerializeField]
    private int count = 3;

    [SerializeField]
    private Vector3 size = new Vector3(16f, 0f, 16f);

    // Start is called before the first frame update
    void Start()
    {
        CreateCollectibles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCollectible()
    {
        var randomCollectible = collectibles.OrderBy(collectible => Random.value).FirstOrDefault();

        if (randomCollectible == null) return;

        CreateCollectible(randomCollectible);
    }

    private void CreateCollectibles()
    {
        for (var i = 0; i < count; i++)
        {
            foreach (var item in collectibles)
            {
                CreateCollectible(item);
            }
        }
    }

    private void CreateCollectible(GameObject collectible)
    {
        Instantiate(
            collectible, GetRandomPosition(), collectible.transform.rotation, gameObject.transform);
    }

    private Vector3 GetRandomPosition()
    {
        var volumePosition = new Vector3(
            Random.Range(0, size.x),
            Random.Range(0, size.y),
            Random.Range(0, size.z));

        return transform.position + volumePosition - size / 2;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }*/
}
