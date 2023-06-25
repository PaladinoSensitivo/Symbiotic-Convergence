using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    public string cena;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    public void AbrirOpcoes()
    {
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
    }
    public void ChamaCenaCredito()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
    }
    public void ChamaCenaMenuInicial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene"); //Atencao!!!, alterar para o nome correto da cena
    }
    public void Pausado()
    {
        Time.timeScale = 0; //jogo está pausado
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }
    public void SairDoPause()
    {
        Time.timeScale = 1; // sair do pause
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
