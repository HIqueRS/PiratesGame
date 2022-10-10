using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private Slider _sliderSpw;

    [SerializeField]
    private Configs _config;

    [SerializeField]
    private TextMeshProUGUI _enemiesPerSecond;
    [SerializeField]
    private TextMeshProUGUI _time;

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

    public void ChangeTextSPW()
    {
        _enemiesPerSecond.text =  _sliderSpw.value.ToString("F2");
    }

    public void ChangeTextTime()
    {
        int trunc;

        float value;

   

        trunc = ((int)_slider.value) / 60;

        value = _slider.value - (60 * trunc);

        _time.text = string.Concat(trunc, ":",value.ToString("F0") );
    }
}
