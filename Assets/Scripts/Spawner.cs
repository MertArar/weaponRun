using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject doors; // Doors game object'inin referansı için değişken
    public int numberOfDoorsToSpawn = 5;
    public float minZPositionBetweenDoors = 15f;
    public float doorYPosition = -1.5f; // Y pozisyonu için değişken

    private void Start()
    {
        SpawnDoors();
    }

    private void SpawnDoors()
    {
        for (int i = 0; i < numberOfDoorsToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-4f, 4f),
                doorYPosition, // Y pozisyonu ayarlandı
                (i + 1) * minZPositionBetweenDoors
            );

            GameObject doorPrefab = GetRandomDoorPrefab();
            Instantiate(doorPrefab, spawnPosition, Quaternion.identity, doors.transform); // Doors objesinin altında oluştur
        }
    }

    private GameObject GetRandomDoorPrefab()
    {
        GameObject[] doorPrefabs = new GameObject[] { doors.transform.GetChild(0).gameObject, doors.transform.GetChild(1).gameObject }; // GreenDoor ve RedDoor
        int randomIndex = Random.Range(0, doorPrefabs.Length);
        return doorPrefabs[randomIndex];
    }
}