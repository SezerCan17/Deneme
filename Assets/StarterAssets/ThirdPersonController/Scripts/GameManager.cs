using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Enemy> activeEnemies = new List<Enemy>(); // Listeyi baþlat
    public GameObject enemyPrefab;
    public Transform enemyTarget;
    public Transform healthBar;
    public Transform spawnReferencePoint; // Spawn pozisyonunu referans alacak GameObject'in Transform'u
    public GameObject canvasMenu;
    public GameObject mainMenuCanvas;
    public GameObject CameraMenu;
    public GameObject CharacterDance;

    int spawnCount = 0;
    float nextSpawnDelay = 5f; // Spawn delay süresini 5 saniye olarak belirleyin

    private void Start()
    {
        StartCoroutine(SpawnEnemiesPeriodically());
    }

    IEnumerator SpawnEnemiesPeriodically()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(nextSpawnDelay); // 5 saniye bekle
        }
    }

    void SpawnEnemy()
    {
        float angleInDegrees = Random.Range(0f, 360f);
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;

        float radius = Random.Range(10, 20);
        float x = Mathf.Cos(angleInRadians) * radius;
        float z = Mathf.Sin(angleInRadians) * radius;

        Vector3 spawnPosition = spawnReferencePoint.position + new Vector3(x, 0.1f, z); // Referans noktasýndan hesaplanan pozisyon

        // Debug.Log ile spawn pozisyonunu kontrol et
        Debug.Log("Spawn Position: " + spawnPosition);

        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyComponent = spawnedEnemy.GetComponent<Enemy>();

        if (enemyComponent == null)
        {
            Debug.LogError("Spawned enemy does not have an Enemy component.");
            return;
        }

        enemyComponent.gm = this;
        enemyComponent.target = enemyTarget;

        activeEnemies.Add(enemyComponent);
        spawnCount++;
    }


    public void StartButton()
    {
       //ameraMenu.SetActive(true);
        mainMenuCanvas.SetActive(false);
    //  CharacterDance.SetActive(false);
     canvasMenu.SetActive(true);
    }

    public void SettingsButton()
    {
       //ceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
