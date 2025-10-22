using System;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInventory
{
    private static Dictionary<string, int> minerals = new Dictionary<string, int>();

    public static event Action<string, int> OnMineralChanged;

    public static void AddMineral(string name, int amount)
    {
        if (!minerals.ContainsKey(name))
            minerals[name] = 0;

        minerals[name] += amount;
        OnMineralChanged?.Invoke(name, minerals[name]);
    }

    public static void RemoveMineral(string name, int amount)
    {
        if (!minerals.ContainsKey(name))
            return;

        minerals[name] = Mathf.Max(0, minerals[name] - amount);
        OnMineralChanged?.Invoke(name, minerals[name]);
    }

    public static int GetMineralAmount(string name)
    {
        return minerals.ContainsKey(name) ? minerals[name] : 0;
    }

    public static IReadOnlyDictionary<string, int> GetAllMinerals() => minerals;
}
