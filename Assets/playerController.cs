using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameApiService api = new GameApiService();
    public int vida = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        //api.AtualizarJogador(1, )
    }
}
