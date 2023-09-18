
using UnityEngine;

public static class PluginAngel
{
    public static int GenerateRandomInteger(int minValue, int maxValue)
    {
        int randomValue = Random.Range(minValue, maxValue + 1);
        return randomValue;
    }


}
