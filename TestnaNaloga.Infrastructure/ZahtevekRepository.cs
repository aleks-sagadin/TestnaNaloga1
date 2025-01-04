using TestnaNaloga.Application;
using TestnaNaloga.Domain;

namespace TestnaNaloga.Infrastructure
{
    public class ZahtevekRepository : IZahtevekRepository
    {
        private readonly ZahtevekDbContext _dbContext;

        public ZahtevekRepository(ZahtevekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Zahtevek> GetAll()
        {
            return _dbContext.Zahteveks.ToList();
        }

        public Zahtevek? GetOneZahtevek(int id)
        {
            return _dbContext.Zahteveks?.Find(id);
        }

        public Zahtevek AddZahtevek(Zahtevek zahtevek)
        {
            _dbContext.Zahteveks.Add(zahtevek);
            _dbContext.SaveChanges();
            return zahtevek;
        }

        public Zahtevek ModifyZahtevek(int id, Zahtevek zahtevek)
        {

            _dbContext.Zahteveks.Update(zahtevek);
            //save
            _dbContext.SaveChanges();
            return zahtevek;
        }

        public Zahtevek? DeleteZahtevek(Zahtevek zahtevek)
        {
            _dbContext.Zahteveks.Remove(zahtevek);
            _dbContext.SaveChanges();
            return zahtevek;
        }

    }




}
