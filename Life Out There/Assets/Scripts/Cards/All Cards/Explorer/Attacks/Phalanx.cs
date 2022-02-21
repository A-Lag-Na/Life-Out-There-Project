using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rename script to basic blast when finished.
//Specific card extending base class prototype.
public class Phalanx : ExplorerAttackTemplate
{
    private static int _id, _cost, _damage, _upgradeDamage, _upgradeBlock;
    private static string _name, _type, _description;
    //private static Sprite _sprite;
    private static Rarity _rarity;

    public Phalanx()
        : base()
    //: base (_id, _cost, _name, _type, _description, _sprite, _rarity)
    {
        cost = 1;
        damage = 6;
        block = 6;
        description = "Deal " + damage + " damage. Block " + block;
        cardName = "Phalanx Formation";
        _upgradeDamage = 3;
        _upgradeBlock = 3;
    }
    override public void OnThisCardPlayed(GameObject _target)
    {
        //Add attack to the selected target onto the GameStateManager/ActionManager stack.
        Effect attack = new Effect(Effect.EffectType.Attack, damage, _target);
        TurnSystem.instance.ResolveEffect(attack);
        Effect defend = new Effect(Effect.EffectType.Block, block);
        TurnSystem.instance.ResolveEffect(defend);
    }

    public override void upgrade()
    {
        this.damage += _upgradeDamage;
        this.block += _upgradeBlock;
        this.upgraded = true;
        this.timesUpgraded++;
    }

}
