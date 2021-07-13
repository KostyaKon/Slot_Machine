using UnityEngine;

public class CreateSymbols : MonoBehaviour
{
    public Transform CreatePoint;
    public GameObject[] PrefabSymbols;

    float Y;

    public GameObject[] CreateArrSymbols(int number, float distans)
    {
        if (number < 5)
            number = 5;
        else if (number > 20)
            number = 20;

        GameObject[] symbols = new GameObject[number];

        float X = CreatePoint.position.x;
        Y = CreatePoint.position.y;
        float Z = CreatePoint.position.z;

        for(int i = 0; i < number; i++)
        {
            symbols[i] = Instantiate(PrefabSymbols[Random.Range(0, PrefabSymbols.Length)], new Vector3(X, Y, Z), Quaternion.identity);
            Y += distans;
        }

        return symbols;
    }

    
}
