using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private GameObject _shipGO;
    private Ships _shipScript;
    [SerializeField]
    private Image _greenBar;

    private float _health;
    private float _maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        _shipScript = _shipGO.GetComponent<Ships>();

        _health = _shipScript._health;
        _maxHealth = _shipScript._maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_shipGO != null)
        transform.position = _shipGO.transform.position + new Vector3(0, 0.8f);

        _greenBar.fillAmount = (float)_shipScript._health / (float)_shipScript._maxHealth;

    }

    public void AtualizeHealth(int health)
    {
        _health = health;
        if(_health > 0)
        {
            _greenBar.fillAmount = _health / _maxHealth;
        }
        else
        {
            _greenBar.fillAmount = 0;
        }
    }

    public void AtualizeMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        if (_health > 0)
        {
            _greenBar.fillAmount = _health / _maxHealth;
        }
        else
        {
            _greenBar.fillAmount = 0;
        }
    }

}
