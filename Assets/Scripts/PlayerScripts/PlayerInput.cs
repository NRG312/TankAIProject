using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speedMov;
    [SerializeField] private float speedRot;

    #region Variables
        private Rigidbody _rg;
        private Vector3 _mov;
        private float _rot;
        private float _gravity = -5f;
        [SerializeField]private bool _blockTank;
    
    #endregion

    private void OnEnable()
    {
        EventManager.onDeathPlayer.AddListener(BlockTank);
    }

    private void OnDisable()
    {
        EventManager.onDeathPlayer.RemoveListener(BlockTank);
    }

    private void Start()
    {
        _rg = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveTank();
        RotateTank();
    }

    private void MoveTank()
    {
        if (_blockTank == false)
        {
            _mov = Input.GetAxis("Vertical") * transform.forward;
            _rg.velocity = _mov * speedMov * Time.fixedDeltaTime;
            _rg.AddForce(new Vector3(0,_gravity,0) * _rg.mass * 5.7f);
        }
    }

    private void RotateTank()
    {
        if (_blockTank == false)
        {
            _rot = Input.GetAxis("Horizontal") * speedRot * Time.deltaTime;
            _rg.MoveRotation(_rg.rotation * UnityEngine.Quaternion.Euler(0,_rot,0));
        }
    }
    
    //After death block all movement and rotate tank
    private void BlockTank()
    {
        _blockTank = true;
        GetComponentInChildren<TowerRotation>().enabled = false;
    }
    //musze usunac eventy ktore nie potrzebuja uzywania kilku skryptow np changebullet moge zrobic przez singletona
    
    //skonczylem na zrobieniu funkcji smierci dla gracza blokowanie skryptow zrobilem ale musze zrobic jeszcze przeciwnika i reszte rzeczy na dole
    //skonczylem na robieniu funkcji smierci nie skonyczlem jeszcze, ale skonczylem robic na szybko dwie mapki moze troche je poprawie dla pewnosci,zrobilem menu tylko brakuje wybor mapy i sprawdzenie czy jak wejde do gry to dobrze funkcje dzialaja
    //brakuje mi funkcja smierci szybkie UI wygranej i przegranej,w menu wybor mapy i skrypty na wykrywanie ktora mapa zostala wybrana,dzwieki, i cala funkcja level controller i chyba wsio
    //po smierciach musze UI dokonczyc samej gierki ze menu, a nastepnie musze zrobic 3 mapy juz w calosci a pozniej MainMenu i koniec wszystko zrobione
    //chcialbym dodac zeby przecinicy mieli dodany peneteration jak u gracza w zaleznosci od poziomu trudnosci narazie wpisalem w bullet function plus 50 dla przeciwnika zmien to pozniej
    //pomysl zeby zrobic dwie podlogi jedna dla nev masha przeciwnika a druga bedzie zapelnieniem zeby tam nie chodzil
    //pomyslalem ze na mapie bedzie level controller ktory trzyma spawn pointy i dane o czolgach jakie sie wybralo i game manager bedzie trzymal te dane i podczas zaladowania mapy bedzie event ktory wysle dane do level controllera
    
    
    //UIsystem bedzie od operowania UI
    //Gamemanager bedzie od trzymania danych w menu gdzie sie wybiera czolg poziom trudnosci oraz mape itp.
    //zapisz sobie animacje na przyszlosc
    
}
