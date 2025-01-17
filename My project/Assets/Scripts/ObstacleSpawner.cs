using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Tablica prefabrykowanych przeszkód
    public float spawnInterval = 2f; // Czas pomiędzy pojawianiem się przeszkód
    public float spawnHeight = 10f; // Wysokość, z której przeszkody będą się pojawiać
    public float speed = 5f; // Szybkość poruszania się przeszkód
    public Transform playerTransform; // Referencja do obiektu gracza (player)

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval; // Ustawienie początkowego czasu
    }

    // Update is called once per frame
    void Update()
    {
        // Liczymy czas, aby pojawiały się przeszkody w regularnych odstępach
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Resetowanie timera
            timer = spawnInterval;

            // Losowe wybranie przeszkody
            GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Losowanie pozycji na osi X (np. -4 do 4)
            float randomX = Random.Range(-4f, 4f);

            // Używamy tej samej osi Z co gracz
            float playerZ = playerTransform.position.z;

            // Tworzenie przeszkody w górnej części ekranu (na tej samej osi Z co gracz)
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, playerZ);
            GameObject newObstacle = Instantiate(obstacle, spawnPosition, Quaternion.identity);

            // Ustawiamy szybkość poruszania się przeszkody
            newObstacle.GetComponent<ObstacleController>().speed = speed;
        }
    }
}
