using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private Slider _sliderSpw;

    [SerializeField]
    private Configs _config;

    // Start is called before the first frame update
    void Start()
    {
        _slider.value = _config.GetTimeToEnd();
        _sliderSpw.value = _config.GetSpawnRate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTime()
    {
        _config.SetTimeToEnd(_slider.value);
    }

    public void ChangeSpawnRate()
    {
        _config.SetSpawnRate(_sliderSpw.value);
    }
}
