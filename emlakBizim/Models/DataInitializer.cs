using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace emlakBizim.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var sehirler = new List<Sehir>()
            {
                new Sehir() { sehirAd = "İSTANBUL" },
                new Sehir() { sehirAd = "ANKARA" },
                new Sehir() { sehirAd = "İZMİR" },
                new Sehir() { sehirAd = "DENİZLİ" },
            };
            foreach (var sehir in sehirler)
            {
                context.Sehirs.Add(sehir);
            }
            context.SaveChanges();

            var semtler = new List<Semt>()
            {
                new Semt() { semtAd = "KAĞITHANE", sehirId = 1 },
                new Semt() { semtAd = "KEÇİÖREN", sehirId = 2 },
                new Semt() { semtAd = "BORNOVA", sehirId = 3 },
            };
            foreach (var semt in semtler)
            {
                context.Semts.Add(semt);
            }
            context.SaveChanges();

            var mahalleler = new List<Mahalle>()
            {
                new Mahalle() { mahalleAd = "ÇAĞLAYAN", semtId = 1 },
                new Mahalle() { mahalleAd = "İZZETBAŞA", semtId = 2 },
                new Mahalle() { mahalleAd = "TALATPAŞA", semtId = 3 },
            };
            foreach (var mahalle in mahalleler)
            {
                context.Mahalles.Add(mahalle);
            }
            context.SaveChanges();

            var durumlar = new List<Durum>()
            {
                new Durum() { durumAd = "KİRALIK" },
                new Durum() { durumAd = "SATILIK" },
            };
            foreach (var durum in durumlar)
            {
                context.Durums.Add(durum);
            }
            context.SaveChanges();

            var tipler = new List<Tip>()
            {
                new Tip() { tipAd = "EV", durumId = 1 },
                new Tip() { tipAd = "DÜKKAN", durumId = 1 },
                new Tip() { tipAd = "EV", durumId = 2 },
                new Tip() { tipAd = "DÜKKAN", durumId = 2 },    
            };
            foreach (var tip in tipler)
            {
                context.Tips.Add(tip);
            }
            context.SaveChanges();

            var ilanlar = new List<Ilan>()
            {
                /*
                new Ilan() { acıklama = "Boğaz manzaralı.", adres = "Şan Sokak", odaSayisi = 5,
                             banyoSayisi = 2, kredi = true, fiyat = 3500, mahalleId = 1, semtId = 1,
                             sehirId = 1, durumId = 1, tipId = 1, alan = 210, telefon = "2122132121",
                             kat = "2. kat", userName = "Atakan Turgut" },
                new Ilan() { acıklama = "Geniş Bahçe.", adres = "Can Sokak", odaSayisi = 4,
                             banyoSayisi = 1, kredi = false, fiyat = 2000, mahalleId = 2, semtId = 2,
                             sehirId = 2, durumId = 2, tipId = 4, alan = 160, telefon = "2122121212",
                             kat = "5. kat", userName = "Emir Kuzeyoğlu" },
                */
            };
            foreach (var ilan in ilanlar)
            {
                context.Ilans.Add(ilan);
            }
            context.SaveChanges();

            var resimler = new List<Resim>()
            {
                new Resim() { resimAd = "apartment0.jfif", ilanId = 1 },
                new Resim() { resimAd = "apartment1.jfif", ilanId = 1 },
                new Resim() { resimAd = "house0.jfif", ilanId = 2 },
                new Resim() { resimAd = "inside0.jfif", ilanId = 2 },
            };
            foreach (var resim in resimler)
            {
                context.Resims.Add(resim);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}