using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config")]
public class Configs : ScriptableObject
{
    [SerializeField]
    private int points;

    public void AddPoints(int add)
    {
        points += add;
    }

    public void ResetPoint()
    {
        points = 0;
    }
}
