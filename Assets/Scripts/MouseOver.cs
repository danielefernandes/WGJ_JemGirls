using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public Color hoverColor; // Cor quando o mouse está sobre o botão
    private Color originalColor; // Cor original do botão
    private Button button; // Referência ao componente Button
    [SerializeField]
    private AudioClip hoverSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        if (button != null)
        {
            originalColor = button.image.color;
        }
        else
        {
            Debug.LogError("Button component not found!");
        }

        if (audioSource == null)
        {
            // Adiciona um componente AudioSource se não houver nenhum
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button != null)
        {
            // Altera a cor do botão quando o mouse passa sobre ele
            button.image.color = hoverColor;
            if (hoverSound != null)
            {
                audioSource.PlayOneShot(hoverSound);
            }
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (button != null)
        {
            // Restaura a cor original do botão quando o mouse sai
            button.image.color = originalColor;
        }
    }
}
