using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public PlayerController playerController;
    public float speed;
    
    private float playerZ; // Pozycja Z gracza
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerZ = playerController.transform.position.z; // Ustawienie pozycji Z gracza
    }

    // Update is called once per frame
    void Update()
    {
        // Przesuwamy przeszkodę tylko wzdłuż osi Z, w kierunku przeciwnym do gracza
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        
        // Utrzymanie tej samej osi Z co gracz
        Vector3 currentPosition = transform.position;
        currentPosition.z = playerZ; // Ustawienie Z na wartość Z gracza
        transform.position = currentPosition;

        // Zniszczenie przeszkody, gdy osiągnie określoną pozycję Z
        if (transform.position.z < -2.5f) // Sprawdzamy czy pozycja przeszkody jest mniejsza niż -2.5 na osi Z
        {
            playerController.points = playerController.points + 1; // Dodajemy do zmiennej Points 1
            Destroy(gameObject); // Niszczenie obiektu
        }
    }
}
