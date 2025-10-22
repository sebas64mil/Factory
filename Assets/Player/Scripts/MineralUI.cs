using UnityEngine;
using TMPro;

public class MineralUI : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private string mineralName;

    [Header("Referencia de UI")]
    [SerializeField] private TMP_Text text;

    private void OnEnable()
    {
        // Suscribirse al evento
        PlayerInventory.OnMineralChanged += UpdateUI;
        // Mostrar el valor actual al inicio
        int cantidad = PlayerInventory.GetMineralAmount(mineralName);
        UpdateUI(mineralName, cantidad);
    }

    private void OnDisable()
    {
        // Desuscribirse para evitar errores si el objeto se destruye
        PlayerInventory.OnMineralChanged -= UpdateUI;
    }

    private void UpdateUI(string name, int cantidad)
    {
        if (name != mineralName) return; // Solo actualiza si es su mineral
        if (text != null)
            text.text = $"{mineralName}: {cantidad}";
    }
}
