using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{

    [SerializeField]
    private GameObject _panel;

    private bool _ended;
    private float _passedTime;

    [SerializeField]
    private Configs _config;

    [SerializeField]
    private TextMeshProUGUI _text;



    // Start is called before the first frame update
    void Start()
    {
        _ended = false;

        _passedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_ended)
        {
            if( TestTime() || TestDeaths() )
            {
                TurnOnPanel();
                SetPoints();
            }
            
        }
       
    }


    private bool TestTime()
    {
        _passedTime += Time.deltaTime;

        if(_passedTime > _config.GetTimeToEnd())
        {
            _ended = true;
            return true;
        }

        return false;
    }

    private bool TestDeaths()
    {
        if(_config.EveryoneisDead())
        {
            _ended = true;
            return true;
        }

        return false;
    }

    private void TurnOnPanel()
    {
        _panel.SetActive(true);
    }

    private void SetPoints()
    {
        _text.text = string.Concat("Points: ", _config.GetPoints());
    }
}
