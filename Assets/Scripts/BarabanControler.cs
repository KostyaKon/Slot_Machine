using UnityEngine;

public class BarabanControler : MonoBehaviour
{
    public int numberSymbols;
    public float distansSymbol = 1.75f;

    CreateSymbols createSymbols;
    GameObject[] symbols;
    float maxY, minY;
    bool isStopBaraban;

    float speed = 0f;
    GameControler GC;
    void Start()
    {
        createSymbols = GetComponent<CreateSymbols>();
        symbols = createSymbols.CreateArrSymbols(numberSymbols, distansSymbol);
        maxY = symbols[symbols.Length - 1].transform.position.y;
        minY = symbols[0].transform.position.y - distansSymbol;
        GC = FindObjectOfType<GameControler>();
        speed = GC.Speed;
        isStopBaraban = false;
    }

    void Update()
    {
        if (GC.IsStart())
        {
            if (!isStopBaraban) isStopBaraban = true;
            for(int i = 0; i < symbols.Length; i++)
            {
                MoveSymbol(i);
            }
        }
        else if (isStopBaraban)
        {
            StopBaraban();
            isStopBaraban = false;
        }
    }

    void MoveSymbol(int number)
    {
        symbols[number].transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (symbols[number].transform.position.y <= minY)
        {
            symbols[number].transform.position = new Vector3(symbols[number].transform.position.x, maxY, symbols[number].transform.position.z);
        }
    }

    int FirstNumber()
    {
        for(int i = 0; i < symbols.Length; i++)
        {
            if (symbols[i].transform.position.y < 0)
                return i;
        }
        return -1;
    }

    void StopBaraban()
    {
        int i = FirstNumber();
        if (i != -1)
        {
            float posY = minY;
            for (int j = i; j < symbols.Length; j++)
            {
                symbols[j].transform.position = new Vector3(symbols[j].transform.position.x, posY, symbols[j].transform.position.z);
                posY += distansSymbol;
            }
            for (int j = 0; j < i; j++)
            {
                symbols[j].transform.position = new Vector3(symbols[j].transform.position.x, posY, symbols[j].transform.position.z);
                posY += distansSymbol;
            }
        }
    }
}
