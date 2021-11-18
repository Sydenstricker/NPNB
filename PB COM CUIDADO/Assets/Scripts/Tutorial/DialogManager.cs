using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject panel;
    public Text textBox;
    private string[] linhas;
    private int linhaAtual;
    private PlayerController player;
    private float oldVelocidade;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void StartDialog(TextAsset file)
    {
        linhaAtual = 0;
        if (file != null)
            linhas = file.text.Split('\n');

        oldVelocidade = player.velocidade;
        player.velocidade = 0;
        panel.SetActive(true);

    }

    void Update()
    {
        if (!panel.activeInHierarchy) return;
        textBox.text = linhas[linhaAtual];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            linhaAtual++;
            if (linhaAtual >= 2)
            {
                panel.SetActive(false);
                player.velocidade = oldVelocidade;

            }
        }
    }
}
