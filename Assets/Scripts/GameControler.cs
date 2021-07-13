using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public float Speed = 0f;
    public Text ButtonText;

    bool isStart = false;
    void Start()
    {
        isStart = false;
    }

    public bool IsStart()
    {
        return isStart;
    }

    public void StartMachine()
    {
        isStart = !isStart;
        if (isStart)
            ButtonText.text = "Stop";
        else
            ButtonText.text = "Start";
    }
}
