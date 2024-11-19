using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManajer : MonoBehaviour
{
    public static GameManajer Instance;
    public List<SelecionPersonaje> personajes;

    private void Awake()
    {
        if (GameManajer.Instance == null)
        {
            GameManajer.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
