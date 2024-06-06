using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speedMov;
    [SerializeField] private float speedRot;

    #region Variables
        private Rigidbody rg;
        private Vector3 mov;
        private float rot;
        private float gravity = -5f;
    
    #endregion
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveTank();
        RotateTank();
    }

    private void MoveTank()
    {
        mov = Input.GetAxis("Vertical") * transform.forward;
        rg.velocity = mov * speedMov * Time.fixedDeltaTime;
        rg.AddForce(new Vector3(0,gravity,0) * rg.mass * 5.7f);
    }

    private void RotateTank()
    {
        rot = Input.GetAxis("Horizontal") * speedRot * Time.deltaTime;
        rg.MoveRotation(rg.rotation * UnityEngine.Quaternion.Euler(0,rot,0));
    }
    //musze usunac eventy ktore nie potrzebuja uzywania kilku skryptow np changebullet moge zrobic przez singletona
    //skonczylem na robieniu GUI  ulepsz te GUI bo jest brzydkie, i musze pomyslec czy te GUi bedzie ciagle wyswietlane czy tylko jak sie patrze na przeciwnika <== tutaj skonczylem przed przeciwnikiem i tutaj wroc
    
    //musze przemyslec jak zrobic patrzenie sie na gracza i wysylanie informacji ze mozna strzelic i ze sie patrzy prosto na niego
    //skonczylem na robieniu randomowym obrotu wiezyczki i chce jeszcze wprowadzic tam funkcje patrzenia na gracza jak bedzie go widzial i jak bedzie patrzyl sie na niego bedzie wysylal boola ze mozna strzelac i trzeba dokonczyc strzelanie i enemy bedzie zrobiony, przemysl czy moze nie zrobic osobnego skryptu na obracanie bo wtedy moglbym ciagle obracac wiezyczke w miejscu gdzie byl gracz //jak bede blisko zrobienia musze poukladac dane i opisac funkcje oraz dane co i jak
    //pomysl zeby zrobic dwie podlogi jedna dla nev masha przeciwnika a druga bedzie zapelnieniem zeby tam nie chodzil
    //w przeciwniku musze zrobic skrypty na poruszanie sie po mapie,strzelanie,na pole widocznosci jak zauwazy gracza, eventami bedzie sie dogadywal pomiedzy skryptami albo znajde lepszy pomysl
    //pomysl nad skryptami czy czegos nie lepiej zrobic np poprzez eventy
    //Ui Zrob w eventach i moze pomysl nad eventami w scriptableObject przydadza sie zeby uzywac ich poprzez game manager ktory bedzie w osobnej scenie
    //pomyslalem ze na mapie bedzie level controller ktory trzyma spawn pointy i dane o czolgach jakie sie wybralo i game manager bedzie trzymal te dane i podczas zaladowania mapy bedzie event ktory wysle dane do level controllera
    
    
    //UIsystem bedzie od operowania UI
    //Gamemanager bedzie od trzymania danych w menu gdzie sie wybiera czolg poziom trudnosci oraz mape itp.
    //zapisz sobie animacje na przyszlosc
    
}
