using System;

public interface IEdificio
{
    void Construir();
}

public interface ICastillo : IEdificio { }
public interface ITorre : IEdificio { }
public interface IMuralla : IEdificio { }


public class CastilloA : ICastillo
{
    public void Construir()
    {
        Console.WriteLine("Construyendo un castillo de tipo A");
    }
}

public class TorreB : ITorre
{
    public void Construir()
    {
        Console.WriteLine("Construyendo una torre de tipo B");
    }
}

public class MurallaC : IMuralla
{
    public void Construir()
    {
        Console.WriteLine("Construyendo una muralla de tipo C");
    }
}


public interface IFabricaDeCastillos
{
    ICastillo CrearCastillo();
}

public interface IFabricaDeTorres
{
    ITorre CrearTorre();
}

public interface IFabricaDeMurallas
{
    IMuralla CrearMuralla();
}


public class FabricaDeCastillos : IFabricaDeCastillos
{
    public ICastillo CrearCastillo()
    {
        return new CastilloA();
    }
}

public class FabricaDeTorres : IFabricaDeTorres
{
    public ITorre CrearTorre()
    {
        return new TorreB();
    }
}

public class FabricaDeMurallas : IFabricaDeMurallas
{
    public IMuralla CrearMuralla()
    {
        return new MurallaC();
    }
}


public class Cliente
{
    private readonly ICastillo _castillo;
    private readonly ITorre _torre;
    private readonly IMuralla _muralla;

    public Cliente(IFabricaDeCastillos fabricaCastillos, IFabricaDeTorres fabricaTorres, IFabricaDeMurallas fabricaMurallas)
    {
        _castillo = fabricaCastillos.CrearCastillo();
        _torre = fabricaTorres.CrearTorre();
        _muralla = fabricaMurallas.CrearMuralla();
    }

    public void Construir()
    {
        _castillo.Construir();
        _torre.Construir();
        _muralla.Construir();
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        IFabricaDeCastillos fabricaCastillos = new FabricaDeCastillos();
        IFabricaDeTorres fabricaTorres = new FabricaDeTorres();
        IFabricaDeMurallas fabricaMurallas = new FabricaDeMurallas();

        Cliente cliente = new Cliente(fabricaCastillos, fabricaTorres, fabricaMurallas);
        cliente.Construir();
    }
}