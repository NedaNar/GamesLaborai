using System;
using UnityEngine;

public class GameplayCanvasController : MonoBehaviour
{
    [Header("Collectibles")]
    [SerializeField]
    private RectTransform heartContainer;

    [SerializeField]
    private RectTransform ammoContainer;

    [SerializeField]
    private GameObject heartPrefab;

    [SerializeField]
    private GameObject ammoPrefab;

    [Header("Menus")]
    [SerializeField]
    private RectTransform pausedMenu;

    [SerializeField]
    private RectTransform gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        Hide(pausedMenu);
        Hide(gameOverMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }

    public void UpdateHeartsUI(int newValue)
    {
        UpdateChildCount(heartContainer, heartPrefab, newValue);
    }

    private void UpdateChildCount(Transform container, GameObject prefab, int newCount)
    {
        var childCount = container.childCount;
        var change = Mathf.Min(
            Mathf.Abs(childCount - newCount), childCount);

        if (childCount < newCount) AddChildren(container, prefab, change);
        else RemoveChildren(container, change);
    }

    private void RemoveChildren(Transform container, int change)
    {
        for (var i = 0; i < change;  i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }

    private void AddChildren(Transform container, GameObject prefab, int change)
    {
        for (var i = 0; i < change; i++)
        {
            Instantiate(prefab, container);
        }
    }

    public void UpdateAmmoUI(int newValue)
    {
        UpdateChildCount(ammoContainer, ammoPrefab, newValue);
    }

    public void ShowGameOverMenu()
    {
        Hide(pausedMenu);
        Show(gameOverMenu);
    }

    public void ResumeGame()
    {
        Hide(pausedMenu);
        Time.timeScale = 1.0f;
    }

    public void RestartGame()
    {
        Scenes.RestartScene();
    }

    public void ExitGame()
    {
        Scenes.LoadPreviousScene();
    }

    private void TogglePauseGame()
    {
        if (IsGameOver()) return;
        if (IsGamePaused()) ResumeGame();
        else PauseGame();
    }

    private void PauseGame()
    {
        Show(pausedMenu);
        Time.timeScale = 0f;
    }

    private bool IsGameOver()
    {
        return gameOverMenu.gameObject.activeInHierarchy;
    }

    private bool IsGamePaused()
    {
        return pausedMenu.gameObject.activeInHierarchy;
    }

    private static void Show(Component component)
    {
        component.gameObject.SetActive(true);
    }

    private static void Hide(Component component)
    {
        component.gameObject.SetActive(false);
    }
}
