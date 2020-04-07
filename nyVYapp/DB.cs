using System;
using System.Collections.Generic;
using System.Linq;
using nyVYapp.Models;

namespace nyVYapp
{
    public class DB
    {
        public bool settInnBestilling(Billet bestiltBillet)
        {
            using (var db = new KundeContext())
            {
                var bestilling = new Bestilling()
                {
                    Antall = bestiltBillet.antall,
                    ReiseFra = bestiltBillet.reiseFra,
                    ReiseTil = bestiltBillet.reiseTil,
                    Dato = bestiltBillet.dato,
                    Tid = bestiltBillet.tid,
                    Reisende = bestiltBillet.reisende
                };

                Kunde funnetKunde = db.Kunder.FirstOrDefault(k => k.Navn == bestiltBillet.navn);

                if (funnetKunde == null)
                {
                    // opprett kunden
                    var kunde = new Kunde
                    {
                        Navn = bestiltBillet.navn,
                        Epost = bestiltBillet.epost,
                        Telefonnr = bestiltBillet.telefonnr,
                    };
                    // legg bestillingen inn i kunden
                    kunde.Bestillinger = new List<Bestilling>();
                    kunde.Bestillinger.Add(bestilling);
                    try
                    {
                        db.Kunder.Add(kunde);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
                else
                {
                    try
                    {
                        funnetKunde.Bestillinger.Add(bestilling);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public List<Billet> listAlleBestillinger()
        {
            var db = new KundeContext();

            
            List<Billet> alleBestillinger = db.Kunder.Join(db.Bestillinger,
                                                   k => k.KId,
                                                   b => b.KId,
                                                   (k, b) => new Billet
                                                   {
                                                       Bid = b.BId,
                                                       navn = k.Navn,
                                                       epost = k.Epost,
                                                       telefonnr = k.Telefonnr,
                                                       reiseFra = b.ReiseFra,
                                                       reiseTil = b.ReiseTil,
                                                       dato = b.Dato,
                                                       tid = b.Tid,
                                                       reisende = b.Reisende,
                                                       antall = b.Antall
                                                   }).ToList();

            return alleBestillinger;
        }
        /* For å gjøre endringer på billetter. ikke klar ennå.
        public Bestilling hentBestilling(int Bid)
        {
            using (var db = new KundeContext())
            {
                Bestilling enBestilling = db.Bestillinger.Find(Bid);
                var hentetBestilling = new Bestilling()
                {
                    Bid = enBestilling.BId,
                    reiseFra = enBestilling.ReiseFra,
                    reiseTil = enBestilling.ReiseTil,
                    dato = enBestilling.Dato,
                    tid = enBestilling.Tid,
                };
                return hentetBestilling;
            }
        }

        public bool endreBestilling(int Bid)
        {
            using (var db = new KundeContext())
            {
                Bestilling enBestilling = db.Bestillinger.Find(Bid);
                if (enBestilling == null) // fant ikke billetten
                {
                    return false;
                }
                try
                {
                    
                    var endreObjekt = db.Bestillinger.Find(enBestilling.BId);

                    endreObjekt.ReiseFra = ennBestilling.reiseFra;
                    endreObjekt.ReiseTil = enBestilling.reiseTil;
                    endreObjekt.Dato = enBestilling.dato;
                    endreObjekt.Tid = enBestilling.tid;
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }
        }*/

        public bool slettBestilling(int Bid)
        {
            // vil ikke slette kunden selv om det ikke er noen flere billetter på denne
            using (var db = new KundeContext())
            {
                // finn bestillingen
                Bestilling enBestilling = db.Bestillinger.Find(Bid);
                if (enBestilling == null) // fant ikke billetten
                {
                    return false;
                }
                // slett billetten 
                try
                {
                    db.Bestillinger.Remove(enBestilling);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}