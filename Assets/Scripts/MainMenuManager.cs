using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] GameObject menuAjustes;
    bool isPaused;

    public void Jogar()
    {
        Time.timeScale = 1;
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
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
    }
    public void ChamaCenaMenuInicial()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene"); //Atencao!!!, alterar para o nome correto da cena
    }
    public void Pause()
    {
        isPaused = !isPaused;
        if(isPaused == true){
            Time.timeScale = 0; //jogo está pausado
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }
        else
        {            
            Time.timeScale = 1; // sair do pause
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Play();
            }
        }
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(painelOpcoes.activeSelf == true){
                painelOpcoes.SetActive(false);
                Pause();
                return;
            }
            Pause();
            MenuAjustes();
        }
    }

    void MenuAjustes(){
        menuAjustes.SetActive(!menuAjustes.activeInHierarchy);
    }
}
