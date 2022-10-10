using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config")]
public class Configs : ScriptableObject
{
    [SerializeField]
    private int _points;
    [SerializeField]
    private int _numberOfPlayer;
    [SerializeField]
    private int _numberOfDeads;
    [SerializeField]
    private float _timeToEnd;

    [SerializeField]
    private float _spawnRate;

    public float GetSpawnRate()
    {
        return _spawnRate;
    }

    public void SetSpawnRate(float spwRate )
    {
        _spawnRate = spwRate;
    }

    public void SetTimeToEnd(float time)
    {
        _timeToEnd = time;
    }

    public float GetTimeToEnd()
    {
        return _timeToEnd;
    }

    public void AddPoints(int add)
    {
        _points += add;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void ResetPoint()
    {
        _points = 0;
    }

    public void SetNumberPlayers(int nPlayer)
    {
        _numberOfPlayer = nPlayer;
    }

    public void ResetDeathCount()
    {
        _numberOfDeads = 0;
    }

    public void AddDeath()
    {
        _numberOfDeads++;
    }

    public bool EveryoneisDead()
    {
        if(_numberOfDeads >= _numberOfPlayer)
        {
            return true;
        
        }
        return false;
    }
}
