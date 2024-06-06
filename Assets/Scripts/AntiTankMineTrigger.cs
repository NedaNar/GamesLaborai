using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntiTankMineTrigger : MonoBehaviour
{
    [SerializeField]
    private string antiTankMineTag = "ATMine";

    [SerializeField]
    private float minExplosionForce = 3f;

    [SerializeField]
    private float maxExplosionForce = 5f;

    [Header("Effects")]
    [SerializeField]
    private GameObject explosionPrefab;

    private AntiTankMineController antiTankMineController;
    private Rigidbody rb;
    private Player player;

    private void Awake()
    {
        antiTankMineController = FindObjectOfType<AntiTankMineController>();
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var other = collision.gameObject;

        if (IsAntiTankMine(other))
        {
            CreateExplosionEffect(other.transform.position);

            AddExplosionForce();
            other.SetActive(false);
            Destroy(other);
            player.TakeDamage();
            antiTankMineController.CreateMine();
        }
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }

    private bool IsAntiTankMine(GameObject obj)
    {
        return obj.CompareTag(antiTankMineTag);
    }

    private void AddExplosionForce()
    {
        var force = Random.Range(minExplosionForce, maxExplosionForce);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
