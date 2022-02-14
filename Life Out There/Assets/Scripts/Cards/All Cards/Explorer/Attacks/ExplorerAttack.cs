using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rename script to basic blast when finished.
//Specific card extending base class prototype.
public class ExplorerAttack : c_Card
{
    private static int _id, _cost, _damage, _upgradeDamage;
    private static string _name, _type, _description;
    private static Sprite _sprite;
    private static Rarity _rarity;

    public ExplorerAttack()
        : base (_id, _cost, _name, _type, _description, _sprite, _rarity)
    {
        damage = _damage;
        this.tags.Add("BASIC_ATTACK");
    }
    override public void OnThisCardPlayed()
    {
        //Add attack to the selected target onto the GameStateManager/ActionManager stack.
    }

    public override void upgrade()
    {
        this.damage += _upgradeDamage;
        this.upgraded = true;
        this.timesUpgraded++;
    }

}
