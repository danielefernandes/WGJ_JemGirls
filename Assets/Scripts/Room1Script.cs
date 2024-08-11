using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Room1Script : MonoBehaviour
{
    [SerializeField]
    private AudioClip startSound;
    private AudioSource audioSource;
    [SerializeField]
    public TMP_Text dialogueText; // Referência ao componente Text para exibir o texto
    public Button dialogButton;

    private string[] dialogues1 = 
    {
        "Maria: Ana, a gente precisa conversar direito, você já terminou com ele?",
        "Ana: Claro que não! Por que eu faria isso?!",
        "Maria: Eu já te alertei, o Ricardão não é gente que se cheire! Ele é o próprio conceito de tóxico..",
        "Ana: Não sei o que você está falando...",
        "Maria: Não lembra quando ele deu em cima da Clara? ",
        "Ou quando ele resolveu que seria uma boa ideia postar nossas fotos privadas?",
        "Semana passada ele quase te machucou na sua festa!",
        "Ana: Uhm... Ele pode ser meio Bruto mas é o jeito dele!",
        "Maria: (grita) Ana, você precisa enxergar a verdade! ele não faz bem a você, e é violento! E se ele te machucar?",
        "Ana: Você tá errada, não sabe de nada! Por que eu iria te escutar se você é solteira!? (corre pra longe)"
    };
    private string[] dialogues2 = 
    {
        "Barman: Eai vai um drinque?",
        "Maria: Não obrigada, você viu alguém suspeito por perto?",
        "Barman: bom, gente suspeita sempre tem, mas hoje parece que foi pior, tinha dois caras brigando que nem lutador de MMA na pista de dança mais cedo, mas em geral, apenas discussões... ",
        "Mas e você tá livre pra uma conversa mais tranquila? (flerta)",
        "Maria: É... então, o que você tem aí? Tô curiosa sobre a vida de barman.",
        "Barman: pode vir, sinte-se a vontade pra ver o que faço"
    };

    private string[] dialogues;

    private int currentDialogueIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        dialogues = dialogues1;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Adiciona um componente AudioSource se não houver nenhum
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (startSound != null)
            {
                audioSource.PlayOneShot(startSound); //audio da disco
            }

            if (dialogueText != null && dialogues.Length > 0)
            {
                dialogueText.text = dialogues[currentDialogueIndex];
            }

            // Adiciona o evento de clique ao botão
            if (dialogButton != null)
            {
                dialogButton.onClick.AddListener(NextDialogue);
                dialogButton.gameObject.SetActive(false);

                StartCoroutine(DialogCoroutine(1f));
                
            }
    }

    IEnumerator DialogCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        //ativar caixa de dialogo pra visibe
        dialogButton.gameObject.SetActive(true);
    }

    void NextDialogue()
    {
        // Avança para o próximo texto
        currentDialogueIndex++;

        // Atualiza o texto
        if (dialogueText != null && currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }

        if (currentDialogueIndex >= dialogues.Length)
        {
            dialogButton.gameObject.SetActive(false);
            
            //abre o puzzle
        }
    }
}
