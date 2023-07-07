using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImagePrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab; // to spawn when a tracked image 
    [SerializeField] private Vector3 prefabOffset; // offset to apply to the spawned object's position

    private GameObject spawnedObject; // Reference to the spawned object
    private ARTrackedImageManager trackedImageManager; // Reference to the ARTrackedImageManager 

    private void OnEnable()
    {
        trackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Iterate through each added image in the event args
        foreach (ARTrackedImage image in eventArgs.added)
        {
            // Instantiate the objectPrefab at the image's transform, and applying the prefabOffset to its position
            spawnedObject = Instantiate(objectPrefab, image.transform);
            spawnedObject.transform.position += prefabOffset;
        }
    }
}