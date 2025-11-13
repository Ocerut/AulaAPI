using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class playerController : MonoBehaviour
{
    public GameApiService api = new GameApiService();
    public int vida = 100;
    public int qtdeItens = 0;
    public Player jogador1 = new Player();
    float horizontalInput;
    float verticalInput;
    public float speed = 10;
    Vector3 direction;
    Rigidbody rb;
    public GameObject uiManagerObj;
    public UIManager uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = uiManagerObj.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(direction * Time.deltaTime * speed);

        jogador1.Id = "1";
        jogador1.Vida = vida.ToString();
        jogador1.QtdeItens = qtdeItens.ToString();
        jogador1.PosX = (int)transform.position.x;
        jogador1.PosY = (int)transform.position.y;
        jogador1.PosZ = (int)transform.position.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            vida = vida - 10;
            api.AtualizarJogador("1", jogador1);
            uiManager.saveUI.SetActive(true);
            
        }
        else if (collision.gameObject.tag == "Comida")
        {
            qtdeItens++;
            Destroy(collision.gameObject);
            api.AtualizarJogador("1", jogador1);
            uiManager.saveUI.SetActive(true);
        }
        StartCoroutine(AutosaveOff());
    }

    private IEnumerator AutosaveOff()
    {
        yield return new WaitForSeconds(4);
        uiManager.saveUI.SetActive(false);
    }
}
