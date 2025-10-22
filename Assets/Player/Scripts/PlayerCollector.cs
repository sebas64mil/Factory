using UnityEngine;
using TMPro; // asegúrate de tener TextMeshPro importado

public class PlayerCollector : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text mineralText; // referencia al texto en pantalla

    private MineralNode currentMineral;

    private void Start()
    {
        if (mineralText != null)
            mineralText.gameObject.SetActive(false); // Oculta al inicio
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out MineralNode mineral))
        {
            currentMineral = mineral;

            if (mineralText != null)
            {
                mineralText.text = $"Presiona E para recolectar {mineral.mineralName}";
                mineralText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out MineralNode mineral) && mineral == currentMineral)
        {
            currentMineral = null;

            if (mineralText != null)
                mineralText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (currentMineral != null && Input.GetKeyDown(KeyCode.E))
        {
            currentMineral.Collect();
            currentMineral = null;

            if (mineralText != null)
                mineralText.gameObject.SetActive(false);
        }
    }
}
