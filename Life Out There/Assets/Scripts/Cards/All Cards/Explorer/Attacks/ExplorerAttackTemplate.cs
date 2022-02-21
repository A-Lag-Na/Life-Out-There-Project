using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rename script to basic blast when finished.
//Specific card extending base class prototype.
public class ExplorerAttackTemplate : c_BaseCard
{
    private static int _id, _cost, _damage, _upgradeDamage;
    private static string _name, _type, _description;
    //private static Sprite _sprite;
    private static Rarity _rarity;

    //Extend this class to save yourself some time over extending BaseCard.
    public ExplorerAttackTemplate()
        : base()
    //: base (_id, _cost, _name, _type, _description, _sprite, _rarity)
    {
        character = Character.explorer;
        type = "Attack";
        description = "Deal " + damage + " damage.";
        //thisImage = _sprite;
        //Damage here might need to be split up into two variables, baseDamage and totalDamage, where totalDamage is the output after modifiers such as strength.
        _upgradeDamage = 3;
        thisImage = Resources.Load<Sprite>("Card Art/BlastArt");
        
        cost = 1;
        damage = 6;
        cardName = "Blast";        
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
