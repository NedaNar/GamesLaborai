using UnityEngine;

public class CollectibleTrigger : MonoBehaviour
{
    [SerializeField]
    private int pillValue = 1;

    [SerializeField]
    private int ammoValue = 2;

    [SerializeField]
    private string medicalPillTag = "MedicalPill";

    [SerializeField]
    private string ammoTag = "Ammo";

    private CollectibleController collectibleController;
    private Player player;

    private void Awake()
    {
        collectibleController = FindObjectOfType<CollectibleController>();
        player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        var collected = false;

        if (IsMedicalPill(otherGameObject))
        {
            player.AddLives(pillValue);
            collected = true;
        }
        else if (IsAmmo(otherGameObject))
        {
            player.AddAmmo(ammoValue);
            collected = true;
        }

        if (collected)
        {
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            collectibleController.CreateCollectible();
        }
    }

    private bool IsMedicalPill(GameObject obj)
    {
        return obj.CompareTag(medicalPillTag);
    }

    private bool IsAmmo(GameObject obj)
    {
        return obj.CompareTag(ammoTag);
    }
}
