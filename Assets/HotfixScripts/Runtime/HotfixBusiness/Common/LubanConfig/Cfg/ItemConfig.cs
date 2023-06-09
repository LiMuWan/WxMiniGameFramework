//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace GameConfig.Cfg
{
public sealed partial class ItemConfig :  Bright.Config.BeanBase 
{
    public ItemConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Type = _buf.ReadInt();
        Name = _buf.ReadString();
        Icon = _buf.ReadString();
        Hp = _buf.ReadInt();
        Spd = _buf.ReadInt();
        Atk = _buf.ReadInt();
        Def = _buf.ReadInt();
        PostInit();
    }

    public static ItemConfig DeserializeItemConfig(ByteBuf _buf)
    {
        return new Cfg.ItemConfig(_buf);
    }

    /// <summary>
    /// id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public int Type { get; private set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; private set; }
    /// <summary>
    /// 血量修正
    /// </summary>
    public int Hp { get; private set; }
    /// <summary>
    /// 速度修正
    /// </summary>
    public int Spd { get; private set; }
    /// <summary>
    /// 攻击修正
    /// </summary>
    public int Atk { get; private set; }
    /// <summary>
    /// 防御修正
    /// </summary>
    public int Def { get; private set; }

    public const int __ID__ = -783814593;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Type:" + Type + ","
        + "Name:" + Name + ","
        + "Icon:" + Icon + ","
        + "Hp:" + Hp + ","
        + "Spd:" + Spd + ","
        + "Atk:" + Atk + ","
        + "Def:" + Def + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}