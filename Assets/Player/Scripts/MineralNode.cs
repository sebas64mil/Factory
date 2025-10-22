using UnityEngine;

public class MineralNode : MonoBehaviour
{
    public string mineralName = "Iron";
    public int amount = 1;

    public void Collect()
    {
        PlayerInventory.AddMineral(mineralName, amount);
        Debug.Log($"Recolectado {amount} de {mineralName}");
        gameObject.SetActive(false);
    }

}
