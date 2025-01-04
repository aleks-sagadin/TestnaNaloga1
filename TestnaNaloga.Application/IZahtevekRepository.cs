using TestnaNaloga.Domain;

namespace TestnaNaloga.Application
{
    public interface IZahtevekRepository
    {
        List<Zahtevek> GetAll();
        Zahtevek? GetOneZahtevek(int id);
        Zahtevek AddZahtevek(Zahtevek zahtevek);
        Zahtevek? ModifyZahtevek(int id, Zahtevek zahtevek);
        Zahtevek? DeleteZahtevek(Zahtevek zahtevek);
    }
}
