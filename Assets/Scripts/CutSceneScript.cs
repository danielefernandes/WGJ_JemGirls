using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CutSceneScript : MonoBehaviour
{
    public Image image; // Referência à Image
    public float targetSize = 1.5f; // Tamanho desejado (escala)
    public float zoomDuration = 2f; // Duração da animação do zoom em segundos
    public Vector2 targetAnchoredPosition = new Vector2(0, 0); // Posição final do eixo âncora
    public Vector2 targetSizeDelta = new Vector2(800, 600); // Tamanho final do eixo delta

    private Vector2 originalAnchoredPosition;
    private Vector2 originalSizeDelta;
    [SerializeField]
    private AudioClip startSound;
    [SerializeField]
    private AudioClip telephoneSound;
    private AudioSource audioSource;

    public TMP_Text dialogueText; // Referência ao componente Text para exibir o texto
    public Button dialogButton; // Referência ao botão para alternar o texto

    private string[] dialogues = 
    {
        "*Triiimm... triiimmmm...",
        "Mãe de Ana: Alô Maria... está bem?",
        "Maria: ....",
        "Mãe de Ana: Você vai conseguir as fotos?",
        "Maria: Ok... vou tentar."
    };

    private int currentDialogueIndex = 0;
    private RectTransform rectTransform;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Adiciona um componente AudioSource se não houver nenhum
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (image != null)
        {
            // Salva os valores originais do RectTransform
            rectTransform = image.rectTransform;
            originalAnchoredPosition = rectTransform.anchoredPosition;
            originalSizeDelta = rectTransform.sizeDelta;

            if (startSound != null)
            {
                audioSource.PlayOneShot(startSound);
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

                StartCoroutine(DialogCoroutine(3f));
            }

            
            
        }
        else
        {
            Debug.LogError("Image not assigned!");
        }
    }

    
    IEnumerator DialogCoroutine(float duration)
    {
        //barulho de telefone
        yield return new WaitForSeconds(duration);
        //ativar caixa de dialogo pra visibe
        dialogButton.gameObject.SetActive(true);
        //ativa som de fundo da ligação
        if (telephoneSound != null)
            audioSource.PlayOneShot(telephoneSound);
        
    }

    IEnumerator ZoomCoroutine(RectTransform rectTransform, Vector2 startSizeDelta, Vector2 endSizeDelta, Vector2 startPosition, Vector2 endPosition, float duration)
    {
        float elapsedTime = 0f;


        while (elapsedTime < duration )
        {
            float t = elapsedTime / duration;

            // Interpola o tamanho e a posição
            rectTransform.sizeDelta = Vector2.Lerp(startSizeDelta, endSizeDelta, t);
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null; // Espera o próximo frame
        }

        // Garante que os valores finais sejam definidos
        rectTransform.sizeDelta = endSizeDelta;
        rectTransform.anchoredPosition = endPosition;

        SceneManager.LoadScene("Room1");
    }

    void NextDialogue()
    {
        // Avança para o próximo texto
        currentDialogueIndex++;
        
        // Se o índice estiver fora dos limites, reinicia o diálogo
        /*if (currentDialogueIndex >= dialogues.Length)
        {
            currentDialogueIndex = 0;
        }*/

        // Atualiza o texto
        if (dialogueText != null && currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }

        if (currentDialogueIndex >= dialogues.Length)
        {
            dialogButton.gameObject.SetActive(false);
            
            StartCoroutine(ZoomCoroutine(rectTransform, originalSizeDelta, targetSizeDelta, originalAnchoredPosition, targetAnchoredPosition, zoomDuration));     
        }
    }
}
