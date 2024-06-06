using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    [Header("Player state")]
    [SerializeField]
    private int lives = 3;

    [SerializeField, Min(0)]
    private int ammo = 5;

    /*[Header("UI")]
    [SerializeField]
    private TextMeshProUGUI livesText;

    [SerializeField]
    private TextMeshProUGUI ammoText;

    [SerializeField]
    private TextMeshProUGUI finalText;*/

    private PlayerController playerController;

    private GameplayCanvasController canvasController;
    private ProjectileController projectileController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        canvasController = FindObjectOfType<GameplayCanvasController>();
        projectileController = GetComponent<ProjectileController>();

    }



    // Start is called before the first frame update
    void Start()
    {
        projectileController.UpdateAmmo(ammo);
        //UpdateLivesText();
        //UpdateAmmoText();
    }

    public void TakeDamage()
    {
        lives--;
        canvasController.UpdateHeartsUI(lives);
        if (lives <= 0) StopGame();
    }

    public void AddLives(int value)
    {
        lives += value;
        canvasController.UpdateHeartsUI(lives);
    }

    public void AddAmmo(int value)
    {
        ammo += value;
        canvasController.UpdateAmmoUI(ammo);
        projectileController.UpdateAmmo(ammo);
    }

    private void StopGame()
    {
        playerController.enabled = false;
        canvasController.ShowGameOverMenu();
    }

    /*private void UpdateAmmoText()
    {
        ammoText.text = $"Ammo: {ammo}";
    }

    private void UpdateLivesText()
    {
        livesText.text = $"Lives: {lives}";
    }*/
}
