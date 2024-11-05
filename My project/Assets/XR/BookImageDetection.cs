using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BookImageDetection : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;

    public GameObject contentPrefab; // El objeto AR que se mostrará sobre el libro

    void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            if (trackedImage.referenceImage.name == "Libro_XYZ") // Asegúrate de que coincida con el nombre en la biblioteca
            {
                // Instancia o activa el contenido sobre el libro detectado
                GameObject content = Instantiate(contentPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                content.transform.SetParent(trackedImage.transform); // Para que se mueva con el libro si es necesario
            }
        }
    }
}
