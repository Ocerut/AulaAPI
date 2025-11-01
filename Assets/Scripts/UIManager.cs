using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject saveUI;
    public GameObject playerObj;
    public playerController playerCtrlr;
    public TextMeshProUGUI saveInfoTxt;
    private string playerName;
    private string playerHP;
    private string playerItens;
    private string playerX;
    private string playerY;
    private string playerZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCtrlr = playerObj.GetComponent<playerController>();
        playerName = playerCtrlr.jogador1.id;
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = playerCtrlr.vida.ToString();
        playerItens = playerCtrlr.qtdeItens.ToString();
        playerX = playerCtrlr.transform.position.x.ToString();
        playerY = playerCtrlr.transform.position.y.ToString();
        playerZ = playerCtrlr.transform.position.z.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(true);
            ButtonUpdate();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseUI.SetActive(false);
        }
    }

    void ButtonUpdate()
    {
        saveInfoTxt.text = "Nome: " + playerName + " | HP: " + playerHP + " | Inventário: " + playerItens + " itens | Posição: x " + playerX + " y " + playerY + " z " + playerZ;
    }
}
