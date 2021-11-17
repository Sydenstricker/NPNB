using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private Animator tiroBoss;
    [SerializeField] bool ehParaDesaparecerQuandoMorre = false;
    [SerializeField] int damage = 100;

    private void Start()
    {
        tiroBoss = GetComponent<Animator>();
    }
    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        if (gameObject.CompareTag("Tiro Boss")) {  tiroBoss.SetTrigger("acertou"); return; }         
        if (gameObject.CompareTag("shot1"))     {  tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot2"))     {  tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot3"))     {  tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot4"))     {  tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot5"))     {  tiroBoss.SetTrigger("acertou"); return; }
        if (gameObject.CompareTag("shot6"))     {  tiroBoss.SetTrigger("acertou"); return; }
        if (ehParaDesaparecerQuandoMorre) {return;}
        else
        {
            Destroy(gameObject);
        }
    }
    public void PedraCaiFeliz()
    {
        return;
    }
}
