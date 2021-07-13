using UnityEngine;

public class MoveSymbol : MonoBehaviour
{
    float speed = 0f;
    GameControler GC;

    void Start()
    {
        GC = FindObjectOfType<GameControler>();
        speed = GC.Speed;
    }

    void Update()
    {
        if (GC.IsStart())
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if(transform.position.y <= -3.5f)
            {
                transform.position = new Vector3(transform.position.x, 5.25f, transform.position.z);
            }
        }
    }
}
