using UnityEngine;

[RequireComponent(typeof(Collider2D))] // o Collider si usas 3D
public class CraftingStation : MonoBehaviour
{
    [SerializeField] private RequirementChecker requirementChecker;
    [SerializeField] private GameObject interactText; // Texto “Presiona E para crear” (opcional)

    private bool isPlayerNearby = false;

    private void Start()
    {
        if (interactText != null)
            interactText.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            TryCraft();
        }
    }

    private void TryCraft()
    {
        if (requirementChecker.HasAllMaterials())
        {
            requirementChecker.ConsumeMaterials();
            Debug.Log(" Materiales suficientes. ¡Has creado el objeto!");
        }
        else
        {
            var missing = requirementChecker.GetMissingMaterials();
            foreach (var kvp in missing)
                Debug.Log($" Faltan {kvp.Value} de {kvp.Key}");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactText != null)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactText != null)
                interactText.SetActive(false);
        }
    }
}
