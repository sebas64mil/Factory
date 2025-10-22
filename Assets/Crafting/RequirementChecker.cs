using System.Collections.Generic;
using UnityEngine;

public class RequirementChecker : MonoBehaviour
{
    [System.Serializable]
    public class MaterialRequirement
    {
        public string materialName;
        public int requiredAmount;
    }

    [SerializeField] private MaterialRequirement[] requirements;

    public bool HasAllMaterials()
    {
        foreach (var req in requirements)
        {
            int have = PlayerInventory.GetMineralAmount(req.materialName);
            if (have < req.requiredAmount)
                return false;
        }
        return true;
    }

    public void ConsumeMaterials()
    {
        foreach (var req in requirements)
        {
            PlayerInventory.RemoveMineral(req.materialName, req.requiredAmount);
        }
    }

    public Dictionary<string, int> GetMissingMaterials()
    {
        var missing = new Dictionary<string, int>();
        foreach (var req in requirements)
        {
            int have = PlayerInventory.GetMineralAmount(req.materialName);
            if (have < req.requiredAmount)
                missing[req.materialName] = req.requiredAmount - have;
        }
        return missing;
    }
}
