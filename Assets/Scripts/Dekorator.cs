using UnityEngine;

public class Dekorator
{
    
}

public interface IIgralec
{
    int PridobiMaxZdravje();
    float PridobiHitrost();
    int IzracunajPobranDenar(int osnovnaVrednost);
    int IzracunajZdravljenje(int osnovnaVrednost);
}


//osnova
public class OsnovniIgralec : IIgralec
{
    public int PridobiMaxZdravje() => 20;
    public float PridobiHitrost() => 1f;
    public int IzracunajPobranDenar(int osnovnaVrednost) => osnovnaVrednost;
    public int IzracunajZdravljenje(int osnovnaVrednost) => osnovnaVrednost;
}


//osnovni dekorator
public abstract class IgralecDekorator : IIgralec
{
    protected IIgralec dekoriraniIgralec;

    public IgralecDekorator(IIgralec igralec)
    {
        this.dekoriraniIgralec = igralec;
    }

    public virtual int PridobiMaxZdravje() => dekoriraniIgralec.PridobiMaxZdravje();
    public virtual float PridobiHitrost() => dekoriraniIgralec.PridobiHitrost();
    public virtual int IzracunajPobranDenar(int osnovnaVrednost) => dekoriraniIgralec.IzracunajPobranDenar(osnovnaVrednost);
    public virtual int IzracunajZdravljenje(int osnovnaVrednost) => dekoriraniIgralec.IzracunajZdravljenje(osnovnaVrednost);
}

//dejanski dekorator za veèje zdravje
public class ZdravjeDekorator : IgralecDekorator
{
    public ZdravjeDekorator(IIgralec igralec) : base(igralec) { }

    public override int PridobiMaxZdravje() => base.PridobiMaxZdravje() + 10;//osnova: 20; nadgradnje: 30, 40, 50
}

//dejanski dekorator za veèjo hitrost
public class HitrostDekorator : IgralecDekorator
{
    public HitrostDekorator(IIgralec igralec) : base(igralec) { }

    public override float PridobiHitrost() => base.PridobiHitrost() + 2f;//osnova: 1; nadgradnje: 3, 5
}

//dejanski dekorator za veè denarja
public class DenarDekorator : IgralecDekorator
{
    public DenarDekorator(IIgralec igralec) : base(igralec) { }

    public override int IzracunajPobranDenar(int osnovnaVrednost)
    {
         return base.IzracunajPobranDenar(osnovnaVrednost) + (int)(osnovnaVrednost* 0.5f);//osnova: 10; nadgradnje: 15, 20 za zaklad
                                                                                          //osnova: kolikor je osnova; nadgradnje: +50%, +100% 
    }
}

//dejanski dekorator za veèje zdravljenje
public class ZdravljenjeDekorator : IgralecDekorator
{
    public ZdravljenjeDekorator(IIgralec igralec) : base(igralec) { }

    public override int IzracunajZdravljenje(int osnovnaVrednost) => base.IzracunajZdravljenje(osnovnaVrednost)*2; //osnova: 5; nadgradnja: 10 za zeleno steno
                                                                                                                     //osnova: kolikor je osnova; nadgradnja: *2
}