using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rename script to basic blast when finished.
//Specific card extending base class prototype.
public class ExplorerAttack : c_BaseCard
{
    private static int _id, _cost, _damage, _upgradeDamage;
    private static string _name, _type, _description;
    private static Sprite _sprite;
    private static Rarity _rarity;

    public ExplorerAttack()
        : base ()
        //: base (_id, _cost, _name, _type, _description, _sprite, _rarity)
    {
        cost = 1;
        cardName = "Blast";
        type = "Attack";
        description = "Deal 6 damage.";
        thisImage = _sprite;
        //Damage here might need to be split up into two variables, baseDamage and totalDamage, where totalDamage is the output after modifiers such as strength.
        damage = 6;
        this.tags.Add("BASIC_ATTACK");
    }
    override public void OnThisCardPlayed(GameObject _target)
    {
        //Add attack to the selected target onto the GameStateManager/ActionManager stack.
        Effect attack = new Effect(Effect.EffectType.Attack, damage, _target);
        TurnSystem.instance.ResolveEffect(attack);
    }

    public override void upgrade()
    {
        this.damage += _upgradeDamage;
        this.upgraded = true;
        this.timesUpgraded++;
    }

}
