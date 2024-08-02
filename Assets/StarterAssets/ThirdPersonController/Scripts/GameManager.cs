using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Enemy> activeEnemies = new List<Enemy>(); // Listeyi baþlat

    public GameObject enemyPrefab1; // Birinci düþman prefab'ý
    public GameObject enemyPrefab2; // Ýkinci düþman prefab'ý
    public GameObject enemyPrefab3; // Üçüncü düþman prefab'ý
    public GameObject enemyPrefab4; // Dördüncü düþman prefab'ý

    public Transform target1; // Birinci düþman hedefi
    public Transform target2; // Ýkinci düþman hedefi
    public Transform target3; // Üçüncü düþman hedefi
    public Transform target4; // Dördüncü düþman hedefi

    public Transform spawnPoint1; // Birinci düþman spawn pozisyonu
    public Transform spawnPoint2; // Ýkinci düþman spawn pozisyonu
    public Transform spawnPoint3; // Üçüncü düþman spawn pozisyonu
    public Transform spawnPoint4; // Dördüncü düþman spawn pozisyonu

    public GameObject canvasMenu;
    public GameObject mainMenuCanvas;
    public GameObject CameraMenu;
    public GameObject CharacterDance;

    int spawnCount = 0;
    float nextSpawnDelay = 5f; // Spawn delay süresini 5 saniye olarak belirleyin
    int maxSpawnCount = 20; // Maksimum spawn edilecek düþman sayýsý

    
    private void Start()
    {
        StartCoroutine(SpawnEnemiesPeriodically());
    }

    IEnumerator SpawnEnemiesPeriodically()
    {
        while (spawnCount < maxSpawnCount)
        {
            int randomEnemy = Random.Range(0, 4);
            switch (randomEnemy)
            {
                case 0:
                    SpawnEnemy(enemyPrefab1, spawnPoint1, target1);
                    break;
                case 1:
                    SpawnEnemy(enemyPrefab2, spawnPoint2, target2);
                    break;
                case 2:
                    SpawnEnemy(enemyPrefab3, spawnPoint3, target3);
                    break;
                case 3:
                    SpawnEnemy(enemyPrefab4, spawnPoint4, target4);
                    break;
            }
            yield return new WaitForSeconds(nextSpawnDelay); // 5 saniye bekle
        }
    }

    void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint, Transform target)
    {
        float angleInDegrees = Random.Range(0f, 360f);
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;

        float radius = Random.Range(10, 20);
        float x = Mathf.Cos(angleInRadians) * radius;
        float z = Mathf.Sin(angleInRadians) * radius;

        Vector3 spawnPosition = spawnPoint.position + new Vector3(x, 0.1f, z); // Referans noktasýndan hesaplanan pozisyon

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
        enemyComponent.target = target;

        activeEnemies.Add(enemyComponent);
        spawnCount++;
    }

    public void StartButton()
    {
        // CameraMenu.SetActive(true);
        mainMenuCanvas.SetActive(false);
        // CharacterDance.SetActive(false);
        canvasMenu.SetActive(true);
    }

    public void SettingsButton()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
