using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> entity)
        {
            entity.ToTable("StateProvince", "Sale");

            entity.HasIndex(e => e.CountryId, "IX_StateProvince_CountryId");

            entity.Property(e => e.Abbreviation).HasMaxLength(100);
            entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.StateProvinces)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_StateProvince_Country");

            #region StateProvince Seed

            entity.HasData(

                new StateProvince()
                {
                    Id = 12,
                    CountryId = 11,
                    Name = "Ciudad Autonoma de Buenos Aires",
                    Abbreviation = "CABA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 13,
                    CountryId = 11,
                    Name = "Buenos Aires",
                    Abbreviation = "BA",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 14,
                    CountryId = 11,
                    Name = "Catamarca",
                    Abbreviation = "CA",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 15,
                    CountryId = 11,
                    Name = "Chaco",
                    Abbreviation = "CH",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 16,
                    CountryId = 11,
                    Name = "Chubut",
                    Abbreviation = "CT",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 17,
                    CountryId = 11,
                    Name = "Cordoba",
                    Abbreviation = "CB",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 18,
                    CountryId = 11,
                    Name = "Corrientes",
                    Abbreviation = "CR",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 19,
                    CountryId = 11,
                    Name = "Entre Rios",
                    Abbreviation = "ER",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 20,
                    CountryId = 11,
                    Name = "Formosa",
                    Abbreviation = "FO",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 21,
                    CountryId = 11,
                    Name = "Jujuy",
                    Abbreviation = "JY",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 22,
                    CountryId = 11,
                    Name = "La Pampa",
                    Abbreviation = "LP",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 23,
                    CountryId = 11,
                    Name = "La Rioja",
                    Abbreviation = "LR",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 24,
                    CountryId = 11,
                    Name = "Mendoza",
                    Abbreviation = "MZ",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 25,
                    CountryId = 11,
                    Name = "Misiones",
                    Abbreviation = "MI",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 26,
                    CountryId = 11,
                    Name = "Neuquen",
                    Abbreviation = "NQ",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 27,
                    CountryId = 11,
                    Name = "Rio Negro",
                    Abbreviation = "RN",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 28,
                    CountryId = 11,
                    Name = "Salta",
                    Abbreviation = "SA",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 29,
                    CountryId = 11,
                    Name = "San Juan",
                    Abbreviation = "SJ",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 30,
                    CountryId = 11,
                    Name = "San Luis",
                    Abbreviation = "SL",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 31,
                    CountryId = 11,
                    Name = "Santa Cruz",
                    Abbreviation = "SC",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 32,
                    CountryId = 11,
                    Name = "Santa Fe",
                    Abbreviation = "SF",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 33,
                    CountryId = 11,
                    Name = "Santiago del Estero",
                    Abbreviation = "SE",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 34,
                    CountryId = 11,
                    Name = "Tierra del Fuego",
                    Abbreviation = "TF",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 35,
                    CountryId = 11,
                    Name = "Tucuman",
                    Abbreviation = "TU",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1,
                    CountryId = 12,
                    Name = "Երևան",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 2,
                    CountryId = 12,
                    Name = "Արարատի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 3,
                    CountryId = 12,
                    Name = "Արմավիրի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 4,
                    CountryId = 12,
                    Name = "Կոտայքի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 5,
                    CountryId = 12,
                    Name = "Արագածոտնի մարտ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 6,
                    CountryId = 12,
                    Name = "Գեղարքունիքի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 7,
                    CountryId = 12,
                    Name = "Շիրակի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 8,
                    CountryId = 12,
                    Name = "Լոռու մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 9,
                    CountryId = 12,
                    Name = "Վայոց ձորի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 10,
                    CountryId = 12,
                    Name = "Սյունիքի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 11,
                    CountryId = 12,
                    Name = "Տավուշի մարզ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 45,
                    CountryId = 14,
                    Name = "Australian Capital Territory",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 46,
                    CountryId = 14,
                    Name = "New South Wales",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 47,
                    CountryId = 14,
                    Name = "Northern Territory",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 48,
                    CountryId = 14,
                    Name = "Queensland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 49,
                    CountryId = 14,
                    Name = "South Australia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 50,
                    CountryId = 14,
                    Name = "Tasmania",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 51,
                    CountryId = 14,
                    Name = "Victoria",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 52,
                    CountryId = 14,
                    Name = "Western Australia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 36,
                    CountryId = 15,
                    Name = "Wien",
                    Abbreviation = "W",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 37,
                    CountryId = 15,
                    Name = "Niederösterreich",
                    Abbreviation = "NÖ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 38,
                    CountryId = 15,
                    Name = "Oberösterreich",
                    Abbreviation = "OÖ",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 39,
                    CountryId = 15,
                    Name = "Salzburg",
                    Abbreviation = "S",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 40,
                    CountryId = 15,
                    Name = "Tirol",
                    Abbreviation = "T",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 41,
                    CountryId = 15,
                    Name = "Vorarlberg",
                    Abbreviation = "V",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 42,
                    CountryId = 15,
                    Name = "Burgenland",
                    Abbreviation = "B",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 43,
                    CountryId = 15,
                    Name = "Steiermark",
                    Abbreviation = "ST",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 44,
                    CountryId = 15,
                    Name = "Kärnten",
                    Abbreviation = "K",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 53,
                    CountryId = 19,
                    Name = "বরগুনা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 54,
                    CountryId = 19,
                    Name = "বরিশাল",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 55,
                    CountryId = 19,
                    Name = "ভোলা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 56,
                    CountryId = 19,
                    Name = "ঝালকাঠি",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 57,
                    CountryId = 19,
                    Name = "পটুয়াখালী",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 58,
                    CountryId = 19,
                    Name = "পিরোজপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 59,
                    CountryId = 19,
                    Name = "বান্দরবান",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 60,
                    CountryId = 19,
                    Name = "ব্রাহ্মণবাড়ীয়া",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 61,
                    CountryId = 19,
                    Name = "চাঁদপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 62,
                    CountryId = 19,
                    Name = "চট্টগ্রাম",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 63,
                    CountryId = 19,
                    Name = "কুমিল্লা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 64,
                    CountryId = 19,
                    Name = "কক্সবাজার",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 65,
                    CountryId = 19,
                    Name = "ফেনী",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 66,
                    CountryId = 19,
                    Name = "খাগড়াছড়ি",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 67,
                    CountryId = 19,
                    Name = "লক্ষ্মীপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 68,
                    CountryId = 19,
                    Name = "নোয়াখালী",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 69,
                    CountryId = 19,
                    Name = "রাঙ্গামাটি",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 70,
                    CountryId = 19,
                    Name = "ঢাকা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 71,
                    CountryId = 19,
                    Name = "ফরিদপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 72,
                    CountryId = 19,
                    Name = "গাজীপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 73,
                    CountryId = 19,
                    Name = "গোপালগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 74,
                    CountryId = 19,
                    Name = "কিশোরগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 75,
                    CountryId = 19,
                    Name = "মাদারীপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 76,
                    CountryId = 19,
                    Name = "মানিকগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 77,
                    CountryId = 19,
                    Name = "মুন্সীগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 78,
                    CountryId = 19,
                    Name = "নারায়ণগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 79,
                    CountryId = 19,
                    Name = "নরসিংদী",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 80,
                    CountryId = 19,
                    Name = "রাজবাড়ী",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 81,
                    CountryId = 19,
                    Name = "শরীয়তপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 82,
                    CountryId = 19,
                    Name = "টাঙ্গাইল",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 83,
                    CountryId = 19,
                    Name = "বাগেরহাট",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 84,
                    CountryId = 19,
                    Name = "চুয়াডাঙ্গা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 85,
                    CountryId = 19,
                    Name = "যশোর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 86,
                    CountryId = 19,
                    Name = "ঝিনাইদহ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 87,
                    CountryId = 19,
                    Name = "খুলনা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 88,
                    CountryId = 19,
                    Name = "কুষ্টিয়া",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 89,
                    CountryId = 19,
                    Name = "মাগুরা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 90,
                    CountryId = 19,
                    Name = "মেহেরপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 91,
                    CountryId = 19,
                    Name = "নড়াইল",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 92,
                    CountryId = 19,
                    Name = "সাতক্ষিরা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 93,
                    CountryId = 19,
                    Name = "জামালপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 94,
                    CountryId = 19,
                    Name = "ময়মনসিংহ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 95,
                    CountryId = 19,
                    Name = "নেত্রকোনা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 96,
                    CountryId = 19,
                    Name = "শেরপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 97,
                    CountryId = 19,
                    Name = "বগুড়া",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 98,
                    CountryId = 19,
                    Name = "জয়পুরহাট",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 99,
                    CountryId = 19,
                    Name = "নওগাঁ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 100,
                    CountryId = 19,
                    Name = "নাটোর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 101,
                    CountryId = 19,
                    Name = "চাঁপাই নবাবগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 102,
                    CountryId = 19,
                    Name = "পাবনা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 103,
                    CountryId = 19,
                    Name = "রাজশাহী",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 104,
                    CountryId = 19,
                    Name = "সিরাজগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 105,
                    CountryId = 19,
                    Name = "দিনাজপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 106,
                    CountryId = 19,
                    Name = "গাইবান্ধা",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 107,
                    CountryId = 19,
                    Name = "কুড়িগ্রাম",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 108,
                    CountryId = 19,
                    Name = "লালমনিরহাট",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 109,
                    CountryId = 19,
                    Name = "নীলফামারী",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 110,
                    CountryId = 19,
                    Name = "পঞ্চগড়",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 111,
                    CountryId = 19,
                    Name = "রংপুর",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 112,
                    CountryId = 19,
                    Name = "ঠাকুরগাঁও",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 113,
                    CountryId = 19,
                    Name = "হবিগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 114,
                    CountryId = 19,
                    Name = "মৌলভীবাজার",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 115,
                    CountryId = 19,
                    Name = "সুনামগঞ্জ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 116,
                    CountryId = 19,
                    Name = "সিলেট",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 186,
                    CountryId = 21,
                    Name = "Брестская область",
                    Abbreviation = "1",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 187,
                    CountryId = 21,
                    Name = "Витебская область",
                    Abbreviation = "2",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 188,
                    CountryId = 21,
                    Name = "Гомельская область",
                    Abbreviation = "3",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 189,
                    CountryId = 21,
                    Name = "Гродненская область",
                    Abbreviation = "4",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 190,
                    CountryId = 21,
                    Name = "Минская область",
                    Abbreviation = "5",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 191,
                    CountryId = 21,
                    Name = "Могилёвская область",
                    Abbreviation = "6",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 192,
                    CountryId = 21,
                    Name = "Минск",
                    Abbreviation = "7",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 117,
                    CountryId = 22,
                    Name = "Antwerpen",
                    Abbreviation = "ANT",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 118,
                    CountryId = 22,
                    Name = "Brabant wallon",
                    Abbreviation = "VBR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 119,
                    CountryId = 22,
                    Name = "Hainaut",
                    Abbreviation = "HAI",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 120,
                    CountryId = 22,
                    Name = "Liège",
                    Abbreviation = "LIE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 121,
                    CountryId = 22,
                    Name = "Limburg",
                    Abbreviation = "LIM",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 122,
                    CountryId = 22,
                    Name = "Luxembourg",
                    Abbreviation = "LUX",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 123,
                    CountryId = 22,
                    Name = "Namur",
                    Abbreviation = "NAM",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 124,
                    CountryId = 22,
                    Name = "Oost-Vlaanderen",
                    Abbreviation = "OVL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 125,
                    CountryId = 22,
                    Name = "Vlaams-Brabant",
                    Abbreviation = "VBR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 126,
                    CountryId = 22,
                    Name = "West-Vlaanderen",
                    Abbreviation = "WVL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 159,
                    CountryId = 32,
                    Name = "Acre",
                    Abbreviation = "AC",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 160,
                    CountryId = 32,
                    Name = "Alagoas",
                    Abbreviation = "AL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 161,
                    CountryId = 32,
                    Name = "Amapá",
                    Abbreviation = "AP",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 162,
                    CountryId = 32,
                    Name = "Amazonas",
                    Abbreviation = "AM",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 163,
                    CountryId = 32,
                    Name = "Bahia",
                    Abbreviation = "BA",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 164,
                    CountryId = 32,
                    Name = "Ceará",
                    Abbreviation = "CE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 165,
                    CountryId = 32,
                    Name = "Distrito Federal",
                    Abbreviation = "DF",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 166,
                    CountryId = 32,
                    Name = "Espírito Santo",
                    Abbreviation = "ES",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 167,
                    CountryId = 32,
                    Name = "Goiás",
                    Abbreviation = "GO",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 168,
                    CountryId = 32,
                    Name = "Maranhão",
                    Abbreviation = "MA",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 169,
                    CountryId = 32,
                    Name = "Mato Grosso",
                    Abbreviation = "MT",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 170,
                    CountryId = 32,
                    Name = "Mato Grosso do Sul",
                    Abbreviation = "MS",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 171,
                    CountryId = 32,
                    Name = "Minas Gerais",
                    Abbreviation = "MG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 172,
                    CountryId = 32,
                    Name = "Pará",
                    Abbreviation = "PA",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 173,
                    CountryId = 32,
                    Name = "Paraíba",
                    Abbreviation = "PB",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 174,
                    CountryId = 32,
                    Name = "Paraná",
                    Abbreviation = "PR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 175,
                    CountryId = 32,
                    Name = "Pernambuco",
                    Abbreviation = "PE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 176,
                    CountryId = 32,
                    Name = "Piauí",
                    Abbreviation = "PI",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 177,
                    CountryId = 32,
                    Name = "Rio de Janeiro",
                    Abbreviation = "RJ",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 178,
                    CountryId = 32,
                    Name = "Rio Grande do Norte",
                    Abbreviation = "RN",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 179,
                    CountryId = 32,
                    Name = "Rio Grande do Sul",
                    Abbreviation = "RS",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 180,
                    CountryId = 32,
                    Name = "Rondônia",
                    Abbreviation = "RO",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 181,
                    CountryId = 32,
                    Name = "Roraima",
                    Abbreviation = "RR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 182,
                    CountryId = 32,
                    Name = "Santa Catarina",
                    Abbreviation = "SC",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 183,
                    CountryId = 32,
                    Name = "São Paulo",
                    Abbreviation = "SP",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 184,
                    CountryId = 32,
                    Name = "Sergipe",
                    Abbreviation = "SE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 185,
                    CountryId = 32,
                    Name = "Tocantins",
                    Abbreviation = "TO",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 155,
                    CountryId = 34,
                    Name = "Belait",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 156,
                    CountryId = 34,
                    Name = "Brunei-Muara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 157,
                    CountryId = 34,
                    Name = "Temburong",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 158,
                    CountryId = 34,
                    Name = "Tutong",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 127,
                    CountryId = 35,
                    Name = "Blagoevgrad",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 128,
                    CountryId = 35,
                    Name = "Burgas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 129,
                    CountryId = 35,
                    Name = "Dobrich",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 130,
                    CountryId = 35,
                    Name = "Gabrovo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 131,
                    CountryId = 35,
                    Name = "Haskovo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 132,
                    CountryId = 35,
                    Name = "Kardzhali",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 133,
                    CountryId = 35,
                    Name = "Kyustendil",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 134,
                    CountryId = 35,
                    Name = "Lovech",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 135,
                    CountryId = 35,
                    Name = "Montana",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 136,
                    CountryId = 35,
                    Name = "Pazardzhik",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 137,
                    CountryId = 35,
                    Name = "Pernik",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 138,
                    CountryId = 35,
                    Name = "Pleven",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 139,
                    CountryId = 35,
                    Name = "Plovdiv",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 140,
                    CountryId = 35,
                    Name = "Razgrad",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 141,
                    CountryId = 35,
                    Name = "Ruse",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 142,
                    CountryId = 35,
                    Name = "Shumen",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 143,
                    CountryId = 35,
                    Name = "Silistra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 144,
                    CountryId = 35,
                    Name = "Sliven",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 145,
                    CountryId = 35,
                    Name = "Smolyan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 146,
                    CountryId = 35,
                    Name = "Sofia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 147,
                    CountryId = 35,
                    Name = "Sofia city",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 148,
                    CountryId = 35,
                    Name = "Stara Zagora",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 149,
                    CountryId = 35,
                    Name = "Targovishte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 150,
                    CountryId = 35,
                    Name = "Varna",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 151,
                    CountryId = 35,
                    Name = "Veliko Tarnovo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 152,
                    CountryId = 35,
                    Name = "Vidin",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 153,
                    CountryId = 35,
                    Name = "Vratsa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 154,
                    CountryId = 35,
                    Name = "Yambol",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 193,
                    CountryId = 41,
                    Name = "Alberta",
                    Abbreviation = "AB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 194,
                    CountryId = 41,
                    Name = "British Columbia",
                    Abbreviation = "BC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 195,
                    CountryId = 41,
                    Name = "Manitoba",
                    Abbreviation = "MB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 196,
                    CountryId = 41,
                    Name = "New Brunswick",
                    Abbreviation = "NB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 197,
                    CountryId = 41,
                    Name = "Newfoundland and Labrador",
                    Abbreviation = "NL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 198,
                    CountryId = 41,
                    Name = "Northwest Territories",
                    Abbreviation = "NT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 199,
                    CountryId = 41,
                    Name = "Nova Scotia",
                    Abbreviation = "NS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 200,
                    CountryId = 41,
                    Name = "Nunavut",
                    Abbreviation = "NU",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 201,
                    CountryId = 41,
                    Name = "Ontario",
                    Abbreviation = "ON",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 202,
                    CountryId = 41,
                    Name = "Prince Edward Island",
                    Abbreviation = "PE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 203,
                    CountryId = 41,
                    Name = "Quebec",
                    Abbreviation = "QC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 204,
                    CountryId = 41,
                    Name = "Saskatchewan",
                    Abbreviation = "SK",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 205,
                    CountryId = 41,
                    Name = "Yukon Territory",
                    Abbreviation = "YU",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 232,
                    CountryId = 46,
                    Name = "北京市",
                    Abbreviation = "北京市",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 233,
                    CountryId = 46,
                    Name = "天津市",
                    Abbreviation = "天津市",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 234,
                    CountryId = 46,
                    Name = "河北省",
                    Abbreviation = "河北省",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 235,
                    CountryId = 46,
                    Name = "山西省",
                    Abbreviation = "山西省",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 236,
                    CountryId = 46,
                    Name = "内蒙古自治区",
                    Abbreviation = "内蒙古自治区",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 237,
                    CountryId = 46,
                    Name = "辽宁省",
                    Abbreviation = "辽宁省",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 238,
                    CountryId = 46,
                    Name = "吉林省",
                    Abbreviation = "吉林省",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 239,
                    CountryId = 46,
                    Name = "黑龙江省",
                    Abbreviation = "黑龙江省",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 240,
                    CountryId = 46,
                    Name = "上海市",
                    Abbreviation = "上海市",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 241,
                    CountryId = 46,
                    Name = "江苏省",
                    Abbreviation = "江苏省",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 242,
                    CountryId = 46,
                    Name = "浙江省",
                    Abbreviation = "浙江省",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 243,
                    CountryId = 46,
                    Name = "安徽省",
                    Abbreviation = "安徽省",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 244,
                    CountryId = 46,
                    Name = "福建省",
                    Abbreviation = "福建省",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 245,
                    CountryId = 46,
                    Name = "江西省",
                    Abbreviation = "江西省",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 246,
                    CountryId = 46,
                    Name = "山东省",
                    Abbreviation = "山东省",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 247,
                    CountryId = 46,
                    Name = "河南省",
                    Abbreviation = "河南省",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 248,
                    CountryId = 46,
                    Name = "湖北省",
                    Abbreviation = "湖北省",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 249,
                    CountryId = 46,
                    Name = "湖南省",
                    Abbreviation = "湖南省",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 250,
                    CountryId = 46,
                    Name = "广东省",
                    Abbreviation = "广东省",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 251,
                    CountryId = 46,
                    Name = "广西壮族自治区",
                    Abbreviation = "广西壮族自治区",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 252,
                    CountryId = 46,
                    Name = "海南省",
                    Abbreviation = "海南省",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 253,
                    CountryId = 46,
                    Name = "重庆市",
                    Abbreviation = "重庆市",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 254,
                    CountryId = 46,
                    Name = "四川省",
                    Abbreviation = "四川省",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 255,
                    CountryId = 46,
                    Name = "贵州省",
                    Abbreviation = "贵州省",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 256,
                    CountryId = 46,
                    Name = "云南省",
                    Abbreviation = "云南省",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 257,
                    CountryId = 46,
                    Name = "西藏自治区",
                    Abbreviation = "西藏自治区",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 258,
                    CountryId = 46,
                    Name = "陕西省",
                    Abbreviation = "陕西省",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 259,
                    CountryId = 46,
                    Name = "甘肃省",
                    Abbreviation = "甘肃省",
                    Published = true,
                    DisplayOrder = 28
                },

                new StateProvince()
                {
                    Id = 260,
                    CountryId = 46,
                    Name = "青海省",
                    Abbreviation = "青海省",
                    Published = true,
                    DisplayOrder = 29
                },

                new StateProvince()
                {
                    Id = 261,
                    CountryId = 46,
                    Name = "宁夏回族自治区",
                    Abbreviation = "宁夏回族自治区",
                    Published = true,
                    DisplayOrder = 30
                },

                new StateProvince()
                {
                    Id = 262,
                    CountryId = 46,
                    Name = "新疆维吾尔自治区",
                    Abbreviation = "新疆维吾尔自治区",
                    Published = true,
                    DisplayOrder = 31
                },

                new StateProvince()
                {
                    Id = 263,
                    CountryId = 46,
                    Name = "香港特别行政区",
                    Abbreviation = "香港特别行政区",
                    Published = true,
                    DisplayOrder = 32
                },

                new StateProvince()
                {
                    Id = 264,
                    CountryId = 46,
                    Name = "澳门特别行政区",
                    Abbreviation = "澳门特别行政区",
                    Published = true,
                    DisplayOrder = 33
                },

                new StateProvince()
                {
                    Id = 265,
                    CountryId = 46,
                    Name = "台湾省",
                    Abbreviation = "台湾省",
                    Published = true,
                    DisplayOrder = 34
                },

                new StateProvince()
                {
                    Id = 266,
                    CountryId = 49,
                    Name = "Amazonas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 267,
                    CountryId = 49,
                    Name = "Antioquia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 268,
                    CountryId = 49,
                    Name = "Arauca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 269,
                    CountryId = 49,
                    Name = "Atlántico",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 270,
                    CountryId = 49,
                    Name = "Bolívar",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 271,
                    CountryId = 49,
                    Name = "Boyacá",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 272,
                    CountryId = 49,
                    Name = "Caldas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 273,
                    CountryId = 49,
                    Name = "Caquetá",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 274,
                    CountryId = 49,
                    Name = "Casanare",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 275,
                    CountryId = 49,
                    Name = "Cauca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 276,
                    CountryId = 49,
                    Name = "Cesar",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 277,
                    CountryId = 49,
                    Name = "Chocó",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 278,
                    CountryId = 49,
                    Name = "Córdoba",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 279,
                    CountryId = 49,
                    Name = "Cundinamarca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 280,
                    CountryId = 49,
                    Name = "Guainía",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 281,
                    CountryId = 49,
                    Name = "Guaviare",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 282,
                    CountryId = 49,
                    Name = "Huila",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 283,
                    CountryId = 49,
                    Name = "La Guajira",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 284,
                    CountryId = 49,
                    Name = "Magdalena",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 285,
                    CountryId = 49,
                    Name = "Meta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 286,
                    CountryId = 49,
                    Name = "Nariño",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 287,
                    CountryId = 49,
                    Name = "Norte de Santander",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 288,
                    CountryId = 49,
                    Name = "Putumayo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 289,
                    CountryId = 49,
                    Name = "Quindío",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 290,
                    CountryId = 49,
                    Name = "Risaralda",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 291,
                    CountryId = 49,
                    Name = "San Andrés y Providencia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 292,
                    CountryId = 49,
                    Name = "Santander",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 293,
                    CountryId = 49,
                    Name = "Sucre",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 294,
                    CountryId = 49,
                    Name = "Tolima",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 295,
                    CountryId = 49,
                    Name = "Valle del Cauca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 296,
                    CountryId = 49,
                    Name = "Vaupés",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 297,
                    CountryId = 49,
                    Name = "Vichada",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 298,
                    CountryId = 54,
                    Name = "Alajuela",
                    Abbreviation = "CR-A",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 299,
                    CountryId = 54,
                    Name = "Cartago",
                    Abbreviation = "CR-C",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 300,
                    CountryId = 54,
                    Name = "Guanacaste",
                    Abbreviation = "CR-G",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 301,
                    CountryId = 54,
                    Name = "Heredia",
                    Abbreviation = "CR-H",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 302,
                    CountryId = 54,
                    Name = "Limón",
                    Abbreviation = "CR-L",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 303,
                    CountryId = 54,
                    Name = "Puntarenas",
                    Abbreviation = "CR-P",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 304,
                    CountryId = 54,
                    Name = "San José",
                    Abbreviation = "CR-SJ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 733,
                    CountryId = 56,
                    Name = "Grad Zagreb",
                    Abbreviation = "GZG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 734,
                    CountryId = 56,
                    Name = "Bjelovarsko-bilogorska",
                    Abbreviation = "BBŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 735,
                    CountryId = 56,
                    Name = "Brodsko-posavska",
                    Abbreviation = "BPŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 736,
                    CountryId = 56,
                    Name = "Dubrovačko-neretvanska",
                    Abbreviation = "DNŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 737,
                    CountryId = 56,
                    Name = "Istarska",
                    Abbreviation = "IŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 738,
                    CountryId = 56,
                    Name = "Karlovačka",
                    Abbreviation = "KŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 739,
                    CountryId = 56,
                    Name = "Koprivničko-križevačka",
                    Abbreviation = "KKŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 740,
                    CountryId = 56,
                    Name = "Krapinsko-zagorska",
                    Abbreviation = "KZŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 741,
                    CountryId = 56,
                    Name = "Ličko-senjska",
                    Abbreviation = "LSŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 742,
                    CountryId = 56,
                    Name = "Međimurska",
                    Abbreviation = "MŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 743,
                    CountryId = 56,
                    Name = "Osječko-baranjska",
                    Abbreviation = "OBŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 744,
                    CountryId = 56,
                    Name = "Požeško-slavonska",
                    Abbreviation = "PSŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 745,
                    CountryId = 56,
                    Name = "Primorsko-goranska",
                    Abbreviation = "PGŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 746,
                    CountryId = 56,
                    Name = "Sisačko-moslavačka",
                    Abbreviation = "SMŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 747,
                    CountryId = 56,
                    Name = "Splitsko-dalmatinska",
                    Abbreviation = "SDŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 748,
                    CountryId = 56,
                    Name = "Šibensko-kninska",
                    Abbreviation = "ŠKŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 749,
                    CountryId = 56,
                    Name = "Varaždinska",
                    Abbreviation = "VŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 750,
                    CountryId = 56,
                    Name = "Virovitičko-podravska",
                    Abbreviation = "VPŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 751,
                    CountryId = 56,
                    Name = "Vukovarsko-srijemska",
                    Abbreviation = "VSŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 752,
                    CountryId = 56,
                    Name = "Zadarska",
                    Abbreviation = "ZDŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 753,
                    CountryId = 56,
                    Name = "Zagrebačka",
                    Abbreviation = "ZGŽ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 305,
                    CountryId = 57,
                    Name = "Pinar del Río",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 306,
                    CountryId = 57,
                    Name = "Artemisa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 307,
                    CountryId = 57,
                    Name = "La Habana",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 308,
                    CountryId = 57,
                    Name = "Mayabeque",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 309,
                    CountryId = 57,
                    Name = "Matanzas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 310,
                    CountryId = 57,
                    Name = "Cienfuegos",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 311,
                    CountryId = 57,
                    Name = "Villa Clara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 312,
                    CountryId = 57,
                    Name = "Sancti Spíritus",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 313,
                    CountryId = 57,
                    Name = "Ciego de Ávila",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 314,
                    CountryId = 57,
                    Name = "Camagüey",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 315,
                    CountryId = 57,
                    Name = "Las Tunas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 316,
                    CountryId = 57,
                    Name = "Holguín",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 317,
                    CountryId = 57,
                    Name = "Granma",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 318,
                    CountryId = 57,
                    Name = "Santiago de Cuba",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 319,
                    CountryId = 57,
                    Name = "Guantánamo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 320,
                    CountryId = 57,
                    Name = "Isla de la Juventud",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 321,
                    CountryId = 59,
                    Name = "Famagusta district",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 322,
                    CountryId = 59,
                    Name = "Kyrenia district",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 323,
                    CountryId = 59,
                    Name = "Limassol district",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 324,
                    CountryId = 59,
                    Name = "Larnaca district",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 325,
                    CountryId = 59,
                    Name = "Nicosia district",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 326,
                    CountryId = 59,
                    Name = "Paphos district",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 327,
                    CountryId = 60,
                    Name = "Hlavní město Praha",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 328,
                    CountryId = 60,
                    Name = "Středočeský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 329,
                    CountryId = 60,
                    Name = "Jihočeský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 330,
                    CountryId = 60,
                    Name = "Plzeňský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 331,
                    CountryId = 60,
                    Name = "Karlovarský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 332,
                    CountryId = 60,
                    Name = "Ústecký kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 333,
                    CountryId = 60,
                    Name = "Liberecký kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 334,
                    CountryId = 60,
                    Name = "Královéhradecký kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 335,
                    CountryId = 60,
                    Name = "Pardubický kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 336,
                    CountryId = 60,
                    Name = "Kraj Vysočina",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 337,
                    CountryId = 60,
                    Name = "Jihomoravský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 338,
                    CountryId = 60,
                    Name = "Olomoucký kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 339,
                    CountryId = 60,
                    Name = "Zlínský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 340,
                    CountryId = 60,
                    Name = "Moravskoslezský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 341,
                    CountryId = 61,
                    Name = "Hovedstaden",
                    Abbreviation = "84",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 342,
                    CountryId = 61,
                    Name = "Midtjylland",
                    Abbreviation = "82",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 343,
                    CountryId = 61,
                    Name = "Nordjylland",
                    Abbreviation = "81",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 344,
                    CountryId = 61,
                    Name = "Sjælland",
                    Abbreviation = "85",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 345,
                    CountryId = 61,
                    Name = "Syddanmark",
                    Abbreviation = "83",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 377,
                    CountryId = 66,
                    Name = "Cairo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 378,
                    CountryId = 66,
                    Name = "Alexandria",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 379,
                    CountryId = 66,
                    Name = "Ismailia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 380,
                    CountryId = 66,
                    Name = "Aswan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 381,
                    CountryId = 66,
                    Name = "Asyut",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 382,
                    CountryId = 66,
                    Name = "Beheira",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 383,
                    CountryId = 66,
                    Name = "Beni Suef",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 384,
                    CountryId = 66,
                    Name = "Dakahlia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 385,
                    CountryId = 66,
                    Name = "Damietta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 386,
                    CountryId = 66,
                    Name = "Faiyum",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 387,
                    CountryId = 66,
                    Name = "Gharbia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 388,
                    CountryId = 66,
                    Name = "Giza",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 389,
                    CountryId = 66,
                    Name = "Kafr El Sheikh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 390,
                    CountryId = 66,
                    Name = "Luxor",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 391,
                    CountryId = 66,
                    Name = "Matruh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 392,
                    CountryId = 66,
                    Name = "Minya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 393,
                    CountryId = 66,
                    Name = "Monufia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 394,
                    CountryId = 66,
                    Name = "New Valley",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 395,
                    CountryId = 66,
                    Name = "North Sinai",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 396,
                    CountryId = 66,
                    Name = "Port Said",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 397,
                    CountryId = 66,
                    Name = "Qalyubia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 398,
                    CountryId = 66,
                    Name = "Qena",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 399,
                    CountryId = 66,
                    Name = "Red Sea",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 400,
                    CountryId = 66,
                    Name = "Sharqia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 401,
                    CountryId = 66,
                    Name = "Sohag",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 402,
                    CountryId = 66,
                    Name = "South Sinai",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 403,
                    CountryId = 66,
                    Name = "Suez",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 362,
                    CountryId = 70,
                    Name = "Harjumaa",
                    Abbreviation = "37",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 363,
                    CountryId = 70,
                    Name = "Hiiumaa",
                    Abbreviation = "39",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 364,
                    CountryId = 70,
                    Name = "Ida-Virumaa",
                    Abbreviation = "44",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 365,
                    CountryId = 70,
                    Name = "Jõgevamaa",
                    Abbreviation = "49",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 366,
                    CountryId = 70,
                    Name = "Järvamaa",
                    Abbreviation = "51",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 367,
                    CountryId = 70,
                    Name = "Läänemaa",
                    Abbreviation = "57",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 368,
                    CountryId = 70,
                    Name = "Lääne-Virumaa",
                    Abbreviation = "59",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 369,
                    CountryId = 70,
                    Name = "Põlvamaa",
                    Abbreviation = "65",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 370,
                    CountryId = 70,
                    Name = "Pärnumaa",
                    Abbreviation = "67",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 371,
                    CountryId = 70,
                    Name = "Raplamaa",
                    Abbreviation = "70",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 372,
                    CountryId = 70,
                    Name = "Saaremaa",
                    Abbreviation = "74",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 373,
                    CountryId = 70,
                    Name = "Tartumaa",
                    Abbreviation = "78",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 374,
                    CountryId = 70,
                    Name = "Valgamaa",
                    Abbreviation = "82",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 375,
                    CountryId = 70,
                    Name = "Viljandimaa",
                    Abbreviation = "84",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 376,
                    CountryId = 70,
                    Name = "Võrumaa",
                    Abbreviation = "86",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 456,
                    CountryId = 76,
                    Name = "Ahvenanmaan maakunta/Landskapet Åland",
                    Abbreviation = "01",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 457,
                    CountryId = 76,
                    Name = "Etelä-Karjala/Södra Karelen",
                    Abbreviation = "02",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 458,
                    CountryId = 76,
                    Name = "Etelä-Pohjanmaa/Södra Österbotten",
                    Abbreviation = "03",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 459,
                    CountryId = 76,
                    Name = "Etelä-Savo/Södra Savolax",
                    Abbreviation = "04",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 460,
                    CountryId = 76,
                    Name = "Kainuu/Kajanaland",
                    Abbreviation = "05",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 461,
                    CountryId = 76,
                    Name = "Kanta-Häme/Egentliga Tavastland",
                    Abbreviation = "06",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 462,
                    CountryId = 76,
                    Name = "Keski-Pohjanmaa/Mellersta Österbotten",
                    Abbreviation = "07",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 463,
                    CountryId = 76,
                    Name = "Keski-Suomi/Mellersta Finland",
                    Abbreviation = "08",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 464,
                    CountryId = 76,
                    Name = "Kymenlaakso/Kymmenedalen",
                    Abbreviation = "09",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 465,
                    CountryId = 76,
                    Name = "Lappi/Lappland",
                    Abbreviation = "10",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 466,
                    CountryId = 76,
                    Name = "Pirkanmaa/Birkaland",
                    Abbreviation = "11",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 467,
                    CountryId = 76,
                    Name = "Pohjanmaa/Österbotten",
                    Abbreviation = "12",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 468,
                    CountryId = 76,
                    Name = "Pohjois-Karjala/Norra Karelen",
                    Abbreviation = "13",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 469,
                    CountryId = 76,
                    Name = "Pohjois-Pohjanmaa/Norra Österbotten",
                    Abbreviation = "14",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 470,
                    CountryId = 76,
                    Name = "Pohjois-Savo/Norra Savolax",
                    Abbreviation = "15",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 471,
                    CountryId = 76,
                    Name = "Päijät-Häme/Päijänne-Tavastland",
                    Abbreviation = "16",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 472,
                    CountryId = 76,
                    Name = "Satakunta/Satakunda",
                    Abbreviation = "17",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 473,
                    CountryId = 76,
                    Name = "Uusimaa/Nyland",
                    Abbreviation = "18",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 474,
                    CountryId = 76,
                    Name = "Varsinais-Suomi/Egentliga Finland",
                    Abbreviation = "19",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 475,
                    CountryId = 77,
                    Name = "Ain",
                    Abbreviation = "01",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 476,
                    CountryId = 77,
                    Name = "Aisne",
                    Abbreviation = "02",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 477,
                    CountryId = 77,
                    Name = "Allier",
                    Abbreviation = "03",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 478,
                    CountryId = 77,
                    Name = "Alpes de Hautes-Provence",
                    Abbreviation = "04",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 479,
                    CountryId = 77,
                    Name = "Alpes (Hautes)",
                    Abbreviation = "05",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 480,
                    CountryId = 77,
                    Name = "Alpes Maritimes",
                    Abbreviation = "06",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 481,
                    CountryId = 77,
                    Name = "Ardèche",
                    Abbreviation = "07",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 482,
                    CountryId = 77,
                    Name = "Ardennes",
                    Abbreviation = "08",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 483,
                    CountryId = 77,
                    Name = "Ariège",
                    Abbreviation = "09",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 484,
                    CountryId = 77,
                    Name = "Aube",
                    Abbreviation = "10",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 485,
                    CountryId = 77,
                    Name = "Aude",
                    Abbreviation = "11",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 486,
                    CountryId = 77,
                    Name = "Aveyron",
                    Abbreviation = "12",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 487,
                    CountryId = 77,
                    Name = "Bouches du Rhône",
                    Abbreviation = "13",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 488,
                    CountryId = 77,
                    Name = "Calvados",
                    Abbreviation = "14",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 489,
                    CountryId = 77,
                    Name = "Cantal",
                    Abbreviation = "15",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 490,
                    CountryId = 77,
                    Name = "Charente",
                    Abbreviation = "16",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 491,
                    CountryId = 77,
                    Name = "Charente Maritime",
                    Abbreviation = "17",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 492,
                    CountryId = 77,
                    Name = "Cher",
                    Abbreviation = "18",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 493,
                    CountryId = 77,
                    Name = "Corrèze",
                    Abbreviation = "19",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 494,
                    CountryId = 77,
                    Name = "Corse du sud",
                    Abbreviation = "2A",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 495,
                    CountryId = 77,
                    Name = "Haute corse",
                    Abbreviation = "2B",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 496,
                    CountryId = 77,
                    Name = "Côte-d'Or",
                    Abbreviation = "21",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 497,
                    CountryId = 77,
                    Name = "Côtes d'Armor",
                    Abbreviation = "22",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 498,
                    CountryId = 77,
                    Name = "Creuse",
                    Abbreviation = "23",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 499,
                    CountryId = 77,
                    Name = "Dordogne",
                    Abbreviation = "24",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 500,
                    CountryId = 77,
                    Name = "Doubs",
                    Abbreviation = "25",
                    Published = true,
                    DisplayOrder = 28
                },

                new StateProvince()
                {
                    Id = 501,
                    CountryId = 77,
                    Name = "Drôme",
                    Abbreviation = "26",
                    Published = true,
                    DisplayOrder = 29
                },

                new StateProvince()
                {
                    Id = 502,
                    CountryId = 77,
                    Name = "Eure",
                    Abbreviation = "27",
                    Published = true,
                    DisplayOrder = 30
                },

                new StateProvince()
                {
                    Id = 503,
                    CountryId = 77,
                    Name = "Eure et Loir",
                    Abbreviation = "28",
                    Published = true,
                    DisplayOrder = 31
                },

                new StateProvince()
                {
                    Id = 504,
                    CountryId = 77,
                    Name = "Finistère",
                    Abbreviation = "29",
                    Published = true,
                    DisplayOrder = 32
                },

                new StateProvince()
                {
                    Id = 505,
                    CountryId = 77,
                    Name = "Gard",
                    Abbreviation = "30",
                    Published = true,
                    DisplayOrder = 33
                },

                new StateProvince()
                {
                    Id = 506,
                    CountryId = 77,
                    Name = "Garonne (Haute)",
                    Abbreviation = "31",
                    Published = true,
                    DisplayOrder = 34
                },

                new StateProvince()
                {
                    Id = 507,
                    CountryId = 77,
                    Name = "Gers",
                    Abbreviation = "32",
                    Published = true,
                    DisplayOrder = 35
                },

                new StateProvince()
                {
                    Id = 508,
                    CountryId = 77,
                    Name = "Gironde",
                    Abbreviation = "33",
                    Published = true,
                    DisplayOrder = 36
                },

                new StateProvince()
                {
                    Id = 509,
                    CountryId = 77,
                    Name = "Hérault",
                    Abbreviation = "34",
                    Published = true,
                    DisplayOrder = 37
                },

                new StateProvince()
                {
                    Id = 510,
                    CountryId = 77,
                    Name = "Ille et Vilaine",
                    Abbreviation = "35",
                    Published = true,
                    DisplayOrder = 38
                },

                new StateProvince()
                {
                    Id = 511,
                    CountryId = 77,
                    Name = "Indre",
                    Abbreviation = "36",
                    Published = true,
                    DisplayOrder = 39
                },

                new StateProvince()
                {
                    Id = 512,
                    CountryId = 77,
                    Name = "Indre et Loire",
                    Abbreviation = "37",
                    Published = true,
                    DisplayOrder = 40
                },

                new StateProvince()
                {
                    Id = 513,
                    CountryId = 77,
                    Name = "Isère",
                    Abbreviation = "38",
                    Published = true,
                    DisplayOrder = 41
                },

                new StateProvince()
                {
                    Id = 514,
                    CountryId = 77,
                    Name = "Jura",
                    Abbreviation = "39",
                    Published = true,
                    DisplayOrder = 42
                },

                new StateProvince()
                {
                    Id = 515,
                    CountryId = 77,
                    Name = "Landes",
                    Abbreviation = "40",
                    Published = true,
                    DisplayOrder = 43
                },

                new StateProvince()
                {
                    Id = 516,
                    CountryId = 77,
                    Name = "Loir et Cher",
                    Abbreviation = "41",
                    Published = true,
                    DisplayOrder = 44
                },

                new StateProvince()
                {
                    Id = 517,
                    CountryId = 77,
                    Name = "Loire",
                    Abbreviation = "42",
                    Published = true,
                    DisplayOrder = 45
                },

                new StateProvince()
                {
                    Id = 518,
                    CountryId = 77,
                    Name = "Loire (Haute)",
                    Abbreviation = "43",
                    Published = true,
                    DisplayOrder = 46
                },

                new StateProvince()
                {
                    Id = 519,
                    CountryId = 77,
                    Name = "Loire Atlantique",
                    Abbreviation = "44",
                    Published = true,
                    DisplayOrder = 47
                },

                new StateProvince()
                {
                    Id = 520,
                    CountryId = 77,
                    Name = "Loiret",
                    Abbreviation = "45",
                    Published = true,
                    DisplayOrder = 48
                },

                new StateProvince()
                {
                    Id = 521,
                    CountryId = 77,
                    Name = "Lot",
                    Abbreviation = "46",
                    Published = true,
                    DisplayOrder = 49
                },

                new StateProvince()
                {
                    Id = 522,
                    CountryId = 77,
                    Name = "Lot et Garonne",
                    Abbreviation = "47",
                    Published = true,
                    DisplayOrder = 50
                },

                new StateProvince()
                {
                    Id = 523,
                    CountryId = 77,
                    Name = "Lozère",
                    Abbreviation = "48",
                    Published = true,
                    DisplayOrder = 51
                },

                new StateProvince()
                {
                    Id = 524,
                    CountryId = 77,
                    Name = "Maine et Loire",
                    Abbreviation = "49",
                    Published = true,
                    DisplayOrder = 52
                },

                new StateProvince()
                {
                    Id = 525,
                    CountryId = 77,
                    Name = "Manche",
                    Abbreviation = "50",
                    Published = true,
                    DisplayOrder = 53
                },

                new StateProvince()
                {
                    Id = 526,
                    CountryId = 77,
                    Name = "Marne",
                    Abbreviation = "51",
                    Published = true,
                    DisplayOrder = 54
                },

                new StateProvince()
                {
                    Id = 527,
                    CountryId = 77,
                    Name = "Marne (Haute)",
                    Abbreviation = "52",
                    Published = true,
                    DisplayOrder = 55
                },

                new StateProvince()
                {
                    Id = 528,
                    CountryId = 77,
                    Name = "Mayenne",
                    Abbreviation = "53",
                    Published = true,
                    DisplayOrder = 56
                },

                new StateProvince()
                {
                    Id = 529,
                    CountryId = 77,
                    Name = "Meurthe et Moselle",
                    Abbreviation = "54",
                    Published = true,
                    DisplayOrder = 57
                },

                new StateProvince()
                {
                    Id = 530,
                    CountryId = 77,
                    Name = "Meuse",
                    Abbreviation = "55",
                    Published = true,
                    DisplayOrder = 58
                },

                new StateProvince()
                {
                    Id = 531,
                    CountryId = 77,
                    Name = "Morbihan",
                    Abbreviation = "56",
                    Published = true,
                    DisplayOrder = 59
                },

                new StateProvince()
                {
                    Id = 532,
                    CountryId = 77,
                    Name = "Moselle",
                    Abbreviation = "57",
                    Published = true,
                    DisplayOrder = 60
                },

                new StateProvince()
                {
                    Id = 533,
                    CountryId = 77,
                    Name = "Nièvre",
                    Abbreviation = "58",
                    Published = true,
                    DisplayOrder = 61
                },

                new StateProvince()
                {
                    Id = 534,
                    CountryId = 77,
                    Name = "Nord",
                    Abbreviation = "59",
                    Published = true,
                    DisplayOrder = 62
                },

                new StateProvince()
                {
                    Id = 535,
                    CountryId = 77,
                    Name = "Oise",
                    Abbreviation = "60",
                    Published = true,
                    DisplayOrder = 63
                },

                new StateProvince()
                {
                    Id = 536,
                    CountryId = 77,
                    Name = "Orne",
                    Abbreviation = "61",
                    Published = true,
                    DisplayOrder = 64
                },

                new StateProvince()
                {
                    Id = 537,
                    CountryId = 77,
                    Name = "Pas de Calais",
                    Abbreviation = "62",
                    Published = true,
                    DisplayOrder = 65
                },

                new StateProvince()
                {
                    Id = 538,
                    CountryId = 77,
                    Name = "Puy de Dôme",
                    Abbreviation = "63",
                    Published = true,
                    DisplayOrder = 66
                },

                new StateProvince()
                {
                    Id = 539,
                    CountryId = 77,
                    Name = "Pyrénées Atlantiques",
                    Abbreviation = "64",
                    Published = true,
                    DisplayOrder = 67
                },

                new StateProvince()
                {
                    Id = 540,
                    CountryId = 77,
                    Name = "Pyrénées (Hautes)",
                    Abbreviation = "65",
                    Published = true,
                    DisplayOrder = 68
                },

                new StateProvince()
                {
                    Id = 541,
                    CountryId = 77,
                    Name = "Pyrénées Orientales",
                    Abbreviation = "66",
                    Published = true,
                    DisplayOrder = 69
                },

                new StateProvince()
                {
                    Id = 542,
                    CountryId = 77,
                    Name = "Rhin (Bas)",
                    Abbreviation = "67",
                    Published = true,
                    DisplayOrder = 70
                },

                new StateProvince()
                {
                    Id = 543,
                    CountryId = 77,
                    Name = "Rhin (Haut)",
                    Abbreviation = "68",
                    Published = true,
                    DisplayOrder = 71
                },

                new StateProvince()
                {
                    Id = 544,
                    CountryId = 77,
                    Name = "Rhône",
                    Abbreviation = "69",
                    Published = true,
                    DisplayOrder = 72
                },

                new StateProvince()
                {
                    Id = 545,
                    CountryId = 77,
                    Name = "Saône (Haute)",
                    Abbreviation = "70",
                    Published = true,
                    DisplayOrder = 73
                },

                new StateProvince()
                {
                    Id = 546,
                    CountryId = 77,
                    Name = "Saône et Loire",
                    Abbreviation = "71",
                    Published = true,
                    DisplayOrder = 74
                },

                new StateProvince()
                {
                    Id = 547,
                    CountryId = 77,
                    Name = "Sarthe",
                    Abbreviation = "72",
                    Published = true,
                    DisplayOrder = 75
                },

                new StateProvince()
                {
                    Id = 548,
                    CountryId = 77,
                    Name = "Savoie",
                    Abbreviation = "73",
                    Published = true,
                    DisplayOrder = 76
                },

                new StateProvince()
                {
                    Id = 549,
                    CountryId = 77,
                    Name = "Savoie (Haute)",
                    Abbreviation = "74",
                    Published = true,
                    DisplayOrder = 77
                },

                new StateProvince()
                {
                    Id = 550,
                    CountryId = 77,
                    Name = "Paris",
                    Abbreviation = "75",
                    Published = true,
                    DisplayOrder = 78
                },

                new StateProvince()
                {
                    Id = 551,
                    CountryId = 77,
                    Name = "Seine Maritime",
                    Abbreviation = "76",
                    Published = true,
                    DisplayOrder = 79
                },

                new StateProvince()
                {
                    Id = 552,
                    CountryId = 77,
                    Name = "Seine et Marne",
                    Abbreviation = "77",
                    Published = true,
                    DisplayOrder = 80
                },

                new StateProvince()
                {
                    Id = 553,
                    CountryId = 77,
                    Name = "Yvelines",
                    Abbreviation = "78",
                    Published = true,
                    DisplayOrder = 81
                },

                new StateProvince()
                {
                    Id = 554,
                    CountryId = 77,
                    Name = "Sèvres (Deux)",
                    Abbreviation = "79",
                    Published = true,
                    DisplayOrder = 82
                },

                new StateProvince()
                {
                    Id = 555,
                    CountryId = 77,
                    Name = "Somme",
                    Abbreviation = "80",
                    Published = true,
                    DisplayOrder = 83
                },

                new StateProvince()
                {
                    Id = 556,
                    CountryId = 77,
                    Name = "Tarn",
                    Abbreviation = "81",
                    Published = true,
                    DisplayOrder = 84
                },

                new StateProvince()
                {
                    Id = 557,
                    CountryId = 77,
                    Name = "Tarn et Garonne",
                    Abbreviation = "82",
                    Published = true,
                    DisplayOrder = 85
                },

                new StateProvince()
                {
                    Id = 558,
                    CountryId = 77,
                    Name = "Var",
                    Abbreviation = "83",
                    Published = true,
                    DisplayOrder = 86
                },

                new StateProvince()
                {
                    Id = 559,
                    CountryId = 77,
                    Name = "Vaucluse",
                    Abbreviation = "84",
                    Published = true,
                    DisplayOrder = 87
                },

                new StateProvince()
                {
                    Id = 560,
                    CountryId = 77,
                    Name = "Vendée",
                    Abbreviation = "85",
                    Published = true,
                    DisplayOrder = 88
                },

                new StateProvince()
                {
                    Id = 561,
                    CountryId = 77,
                    Name = "Vienne",
                    Abbreviation = "86",
                    Published = true,
                    DisplayOrder = 89
                },

                new StateProvince()
                {
                    Id = 562,
                    CountryId = 77,
                    Name = "Vienne (Haute)",
                    Abbreviation = "87",
                    Published = true,
                    DisplayOrder = 90
                },

                new StateProvince()
                {
                    Id = 563,
                    CountryId = 77,
                    Name = "Vosges",
                    Abbreviation = "88",
                    Published = true,
                    DisplayOrder = 91
                },

                new StateProvince()
                {
                    Id = 564,
                    CountryId = 77,
                    Name = "Yonne",
                    Abbreviation = "89",
                    Published = true,
                    DisplayOrder = 92
                },

                new StateProvince()
                {
                    Id = 565,
                    CountryId = 77,
                    Name = "Belfort (Territoire de)",
                    Abbreviation = "90",
                    Published = true,
                    DisplayOrder = 93
                },

                new StateProvince()
                {
                    Id = 566,
                    CountryId = 77,
                    Name = "Essonne",
                    Abbreviation = "91",
                    Published = true,
                    DisplayOrder = 94
                },

                new StateProvince()
                {
                    Id = 567,
                    CountryId = 77,
                    Name = "Hauts de Seine",
                    Abbreviation = "92",
                    Published = true,
                    DisplayOrder = 95
                },

                new StateProvince()
                {
                    Id = 568,
                    CountryId = 77,
                    Name = "Seine Saint Denis",
                    Abbreviation = "93",
                    Published = true,
                    DisplayOrder = 96
                },

                new StateProvince()
                {
                    Id = 569,
                    CountryId = 77,
                    Name = "Val de Marne",
                    Abbreviation = "94",
                    Published = true,
                    DisplayOrder = 97
                },

                new StateProvince()
                {
                    Id = 570,
                    CountryId = 77,
                    Name = "Val d'oise",
                    Abbreviation = "95",
                    Published = true,
                    DisplayOrder = 98
                },

                new StateProvince()
                {
                    Id = 571,
                    CountryId = 77,
                    Name = "Guadeloupe",
                    Abbreviation = "971",
                    Published = true,
                    DisplayOrder = 99
                },

                new StateProvince()
                {
                    Id = 572,
                    CountryId = 77,
                    Name = "Martinique",
                    Abbreviation = "972",
                    Published = true,
                    DisplayOrder = 100
                },

                new StateProvince()
                {
                    Id = 573,
                    CountryId = 77,
                    Name = "Guyane",
                    Abbreviation = "973",
                    Published = true,
                    DisplayOrder = 101
                },

                new StateProvince()
                {
                    Id = 574,
                    CountryId = 77,
                    Name = "Réunion",
                    Abbreviation = "974",
                    Published = true,
                    DisplayOrder = 102
                },

                new StateProvince()
                {
                    Id = 575,
                    CountryId = 77,
                    Name = "Saint-Pierre-et-Miquelon",
                    Abbreviation = "975",
                    Published = true,
                    DisplayOrder = 103
                },

                new StateProvince()
                {
                    Id = 576,
                    CountryId = 77,
                    Name = "Mayotte",
                    Abbreviation = "976",
                    Published = true,
                    DisplayOrder = 104
                },

                new StateProvince()
                {
                    Id = 577,
                    CountryId = 77,
                    Name = "Terres Australes et Antarctiques",
                    Abbreviation = "984",
                    Published = true,
                    DisplayOrder = 105
                },

                new StateProvince()
                {
                    Id = 578,
                    CountryId = 77,
                    Name = "Wallis et futuna",
                    Abbreviation = "986",
                    Published = true,
                    DisplayOrder = 106
                },

                new StateProvince()
                {
                    Id = 579,
                    CountryId = 77,
                    Name = "Polynésie Française",
                    Abbreviation = "987",
                    Published = true,
                    DisplayOrder = 107
                },

                new StateProvince()
                {
                    Id = 580,
                    CountryId = 77,
                    Name = "Nouvelle-Calédonie",
                    Abbreviation = "988",
                    Published = true,
                    DisplayOrder = 108
                },

                new StateProvince()
                {
                    Id = 346,
                    CountryId = 84,
                    Name = "Baden-Württemberg",
                    Abbreviation = "BW",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 347,
                    CountryId = 84,
                    Name = "Bayern",
                    Abbreviation = "BY",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 348,
                    CountryId = 84,
                    Name = "Berlin",
                    Abbreviation = "BE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 349,
                    CountryId = 84,
                    Name = "Brandenburg",
                    Abbreviation = "BB",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 350,
                    CountryId = 84,
                    Name = "Bremen",
                    Abbreviation = "HB",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 351,
                    CountryId = 84,
                    Name = "Hamburg",
                    Abbreviation = "HH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 352,
                    CountryId = 84,
                    Name = "Hessen",
                    Abbreviation = "HE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 353,
                    CountryId = 84,
                    Name = "Mecklenburg-Vorpommern",
                    Abbreviation = "MV",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 354,
                    CountryId = 84,
                    Name = "Niedersachsen",
                    Abbreviation = "NI",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 355,
                    CountryId = 84,
                    Name = "Nordrhein-Westfalen",
                    Abbreviation = "NW",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 356,
                    CountryId = 84,
                    Name = "Rheinland-Pfalz",
                    Abbreviation = "RP",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 357,
                    CountryId = 84,
                    Name = "Saarland",
                    Abbreviation = "SL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 358,
                    CountryId = 84,
                    Name = "Sachsen",
                    Abbreviation = "SN",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 359,
                    CountryId = 84,
                    Name = "Sachsen-Anhalt",
                    Abbreviation = "ST",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 360,
                    CountryId = 84,
                    Name = "Schleswig-Holstein",
                    Abbreviation = "SH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 361,
                    CountryId = 84,
                    Name = "Thüringen",
                    Abbreviation = "TH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 682,
                    CountryId = 87,
                    Name = "ΑΙΤΩΛΟΑΚΑΡΝΑΝΙΑΣ",
                    Abbreviation = "ΑΙΤ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 683,
                    CountryId = 87,
                    Name = "ΑΡΓΟΛΙΔΑΣ",
                    Abbreviation = "ΑΡΓ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 684,
                    CountryId = 87,
                    Name = "ΑΡΚΑΔΙΑΣ",
                    Abbreviation = "ΑΡΚ",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 685,
                    CountryId = 87,
                    Name = "ΑΡΤΑΣ",
                    Abbreviation = "ΑΡΤ",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 686,
                    CountryId = 87,
                    Name = "ΑΤΤΙΚΗΣ",
                    Abbreviation = "ΑΤΤ",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 687,
                    CountryId = 87,
                    Name = "ΑΧΑΙΑΣ",
                    Abbreviation = "ΑΧΑ",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 688,
                    CountryId = 87,
                    Name = "ΒΟΙΩΤΙΑΣ",
                    Abbreviation = "ΒΟΙ",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 689,
                    CountryId = 87,
                    Name = "ΓΡΕΒΕΝΩΝ",
                    Abbreviation = "ΓΡΕ",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 690,
                    CountryId = 87,
                    Name = "ΔΡΑΜΑΣ",
                    Abbreviation = "ΔΡΑ",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 691,
                    CountryId = 87,
                    Name = "ΔΩΔΕΚΑΝΗΣΟΥ",
                    Abbreviation = "ΔΩΔ",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 692,
                    CountryId = 87,
                    Name = "ΕΒΡΟΥ",
                    Abbreviation = "ΕΒΡ",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 693,
                    CountryId = 87,
                    Name = "ΕΥΒΟΙΑΣ",
                    Abbreviation = "ΕΥΒ",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 694,
                    CountryId = 87,
                    Name = "ΕΥΡΥΤΑΝΙΑΣ",
                    Abbreviation = "ΕΥΡ",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 695,
                    CountryId = 87,
                    Name = "ΖΑΚΥΝΘΟΥ",
                    Abbreviation = "ΖΑΚ",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 696,
                    CountryId = 87,
                    Name = "ΗΛΕΙΑΣ",
                    Abbreviation = "ΗΛΕ",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 697,
                    CountryId = 87,
                    Name = "ΗΜΑΘΙΑΣ",
                    Abbreviation = "ΗΜΑ",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 698,
                    CountryId = 87,
                    Name = "ΗΡΑΚΛΕΙΟΥ",
                    Abbreviation = "ΗΡΑ",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 699,
                    CountryId = 87,
                    Name = "ΘΕΣΠΡΩΤΙΑΣ",
                    Abbreviation = "ΘΕΣ",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 700,
                    CountryId = 87,
                    Name = "ΘΕΣΣΑΛΟΝΙΚΗΣ",
                    Abbreviation = "ΘΕΣ",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 701,
                    CountryId = 87,
                    Name = "ΙΩΑΝΝΙΝΩΝ",
                    Abbreviation = "ΙΩΑ",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 702,
                    CountryId = 87,
                    Name = "ΚΑΒΑΛΑΣ",
                    Abbreviation = "ΚΑΒ",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 703,
                    CountryId = 87,
                    Name = "ΚΑΡΔΙΤΣΑΣ",
                    Abbreviation = "ΚΑΡ",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 704,
                    CountryId = 87,
                    Name = "ΚΑΣΤΟΡΙΑΣ",
                    Abbreviation = "ΚΑΣ",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 705,
                    CountryId = 87,
                    Name = "ΚΕΡΚΥΡΑΣ",
                    Abbreviation = "ΚΕΡ",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 706,
                    CountryId = 87,
                    Name = "ΚΕΦΑΛΛΗΝΙΑΣ",
                    Abbreviation = "ΚΕΦ",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 707,
                    CountryId = 87,
                    Name = "ΚΙΛΚΙΣ",
                    Abbreviation = "ΚΙΛ",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 708,
                    CountryId = 87,
                    Name = "ΚΟΖΑΝΗΣ",
                    Abbreviation = "ΚΟΖ",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 709,
                    CountryId = 87,
                    Name = "ΚΟΡΙΝΘΙΑΣ",
                    Abbreviation = "ΚΟΡ",
                    Published = true,
                    DisplayOrder = 28
                },

                new StateProvince()
                {
                    Id = 710,
                    CountryId = 87,
                    Name = "ΚΥΚΛΑΔΩΝ",
                    Abbreviation = "ΚΥΚ",
                    Published = true,
                    DisplayOrder = 29
                },

                new StateProvince()
                {
                    Id = 711,
                    CountryId = 87,
                    Name = "ΛΑΚΩΝΙΑΣ",
                    Abbreviation = "ΛΑΚ",
                    Published = true,
                    DisplayOrder = 30
                },

                new StateProvince()
                {
                    Id = 712,
                    CountryId = 87,
                    Name = "ΛΑΡΙΣΑΣ",
                    Abbreviation = "ΛΑΡ",
                    Published = true,
                    DisplayOrder = 31
                },

                new StateProvince()
                {
                    Id = 713,
                    CountryId = 87,
                    Name = "ΛΑΣΙΘΙΟΥ",
                    Abbreviation = "ΛΑΣ",
                    Published = true,
                    DisplayOrder = 32
                },

                new StateProvince()
                {
                    Id = 714,
                    CountryId = 87,
                    Name = "ΛΕΣΒΟΥ",
                    Abbreviation = "ΛΕΣ",
                    Published = true,
                    DisplayOrder = 33
                },

                new StateProvince()
                {
                    Id = 715,
                    CountryId = 87,
                    Name = "ΛΕΥΚΑΔΑΣ",
                    Abbreviation = "ΛΕΥ",
                    Published = true,
                    DisplayOrder = 34
                },

                new StateProvince()
                {
                    Id = 716,
                    CountryId = 87,
                    Name = "ΜΑΓΝΗΣΙΑΣ",
                    Abbreviation = "ΜΑΓ",
                    Published = true,
                    DisplayOrder = 35
                },

                new StateProvince()
                {
                    Id = 717,
                    CountryId = 87,
                    Name = "ΜΕΣΣΗΝΙΑΣ",
                    Abbreviation = "ΜΕΣ",
                    Published = true,
                    DisplayOrder = 36
                },

                new StateProvince()
                {
                    Id = 718,
                    CountryId = 87,
                    Name = "ΞΑΝΘΗΣ",
                    Abbreviation = "ΞΑΝ",
                    Published = true,
                    DisplayOrder = 37
                },

                new StateProvince()
                {
                    Id = 719,
                    CountryId = 87,
                    Name = "ΠΕΛΛΗΣ",
                    Abbreviation = "ΠΕΛ",
                    Published = true,
                    DisplayOrder = 38
                },

                new StateProvince()
                {
                    Id = 720,
                    CountryId = 87,
                    Name = "ΠΙΕΡΙΑΣ",
                    Abbreviation = "ΠΙΕ",
                    Published = true,
                    DisplayOrder = 39
                },

                new StateProvince()
                {
                    Id = 721,
                    CountryId = 87,
                    Name = "ΠΡΕΒΕΖΑΣ",
                    Abbreviation = "ΠΡΕ",
                    Published = true,
                    DisplayOrder = 40
                },

                new StateProvince()
                {
                    Id = 722,
                    CountryId = 87,
                    Name = "ΡΕΘΥΜΝΗΣ",
                    Abbreviation = "ΡΕΘ",
                    Published = true,
                    DisplayOrder = 41
                },

                new StateProvince()
                {
                    Id = 723,
                    CountryId = 87,
                    Name = "ΡΟΔΟΠΗΣ",
                    Abbreviation = "ΡΟΔ",
                    Published = true,
                    DisplayOrder = 42
                },

                new StateProvince()
                {
                    Id = 724,
                    CountryId = 87,
                    Name = "ΣΑΜΟΥ",
                    Abbreviation = "ΣΑΜ",
                    Published = true,
                    DisplayOrder = 43
                },

                new StateProvince()
                {
                    Id = 725,
                    CountryId = 87,
                    Name = "ΣΕΡΡΩΝ",
                    Abbreviation = "ΣΕΡ",
                    Published = true,
                    DisplayOrder = 44
                },

                new StateProvince()
                {
                    Id = 726,
                    CountryId = 87,
                    Name = "ΤΡΙΚΑΛΩΝ",
                    Abbreviation = "ΤΡΙ",
                    Published = true,
                    DisplayOrder = 45
                },

                new StateProvince()
                {
                    Id = 727,
                    CountryId = 87,
                    Name = "ΦΘΙΩΤΙΔΑΣ",
                    Abbreviation = "ΦΘΙ",
                    Published = true,
                    DisplayOrder = 46
                },

                new StateProvince()
                {
                    Id = 728,
                    CountryId = 87,
                    Name = "ΦΛΩΡΙΝΑΣ",
                    Abbreviation = "ΦΛΩ",
                    Published = true,
                    DisplayOrder = 47
                },

                new StateProvince()
                {
                    Id = 729,
                    CountryId = 87,
                    Name = "ΦΩΚΙΔΑΣ",
                    Abbreviation = "ΦΩΚ",
                    Published = true,
                    DisplayOrder = 48
                },

                new StateProvince()
                {
                    Id = 730,
                    CountryId = 87,
                    Name = "ΧΑΛΚΙΔΙΚΗΣ",
                    Abbreviation = "ΧΑΛ",
                    Published = true,
                    DisplayOrder = 49
                },

                new StateProvince()
                {
                    Id = 731,
                    CountryId = 87,
                    Name = "ΧΑΝΙΩΝ",
                    Abbreviation = "ΧΑΝ",
                    Published = true,
                    DisplayOrder = 50
                },

                new StateProvince()
                {
                    Id = 732,
                    CountryId = 87,
                    Name = "ΧΙΟΥ",
                    Abbreviation = "ΧΙΟ",
                    Published = true,
                    DisplayOrder = 51
                },

                new StateProvince()
                {
                    Id = 754,
                    CountryId = 102,
                    Name = "Budapest",
                    Abbreviation = "BU",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 755,
                    CountryId = 102,
                    Name = "Bács-Kiskun",
                    Abbreviation = "BK",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 756,
                    CountryId = 102,
                    Name = "Baranya",
                    Abbreviation = "BA",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 757,
                    CountryId = 102,
                    Name = "Békés",
                    Abbreviation = "BE",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 758,
                    CountryId = 102,
                    Name = "Borsod-Abaúj-Zemplén",
                    Abbreviation = "BZ",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 759,
                    CountryId = 102,
                    Name = "Csongrád",
                    Abbreviation = "CS",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 760,
                    CountryId = 102,
                    Name = "Fejér",
                    Abbreviation = "FE",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 761,
                    CountryId = 102,
                    Name = "Győr-Moson-Sopron",
                    Abbreviation = "GS",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 762,
                    CountryId = 102,
                    Name = "Hajdú-Bihar",
                    Abbreviation = "HB",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 763,
                    CountryId = 102,
                    Name = "Heves",
                    Abbreviation = "HE",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 764,
                    CountryId = 102,
                    Name = "Jász-Nagykun-Szolnok",
                    Abbreviation = "JN",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 765,
                    CountryId = 102,
                    Name = "Komárom-Esztergom",
                    Abbreviation = "KE",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 766,
                    CountryId = 102,
                    Name = "Nógrád",
                    Abbreviation = "NO",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 767,
                    CountryId = 102,
                    Name = "Pest",
                    Abbreviation = "PE",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 768,
                    CountryId = 102,
                    Name = "Somogy",
                    Abbreviation = "SO",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 769,
                    CountryId = 102,
                    Name = "Szabolcs-Szatmár-Bereg",
                    Abbreviation = "SZ",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 770,
                    CountryId = 102,
                    Name = "Tolna",
                    Abbreviation = "TO",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 771,
                    CountryId = 102,
                    Name = "Vas",
                    Abbreviation = "VA",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 772,
                    CountryId = 102,
                    Name = "Veszprém",
                    Abbreviation = "VE",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 773,
                    CountryId = 102,
                    Name = "Zala",
                    Abbreviation = "ZA",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 901,
                    CountryId = 103,
                    Name = "Höfuðborgarsvæðið",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 902,
                    CountryId = 103,
                    Name = "Suðurnes",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 903,
                    CountryId = 103,
                    Name = "Vesturland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 904,
                    CountryId = 103,
                    Name = "Vestfirðir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 905,
                    CountryId = 103,
                    Name = "Norðurland vestra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 906,
                    CountryId = 103,
                    Name = "Norðurland eystra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 907,
                    CountryId = 103,
                    Name = "Austurland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 908,
                    CountryId = 103,
                    Name = "Suðurland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 834,
                    CountryId = 104,
                    Name = "Andhra Pradesh",
                    Abbreviation = "AP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 835,
                    CountryId = 104,
                    Name = "Arunachal Pradesh",
                    Abbreviation = "AR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 836,
                    CountryId = 104,
                    Name = "Assam",
                    Abbreviation = "AS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 837,
                    CountryId = 104,
                    Name = "Bihar",
                    Abbreviation = "BR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 838,
                    CountryId = 104,
                    Name = "Chhattisgarh",
                    Abbreviation = "CT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 839,
                    CountryId = 104,
                    Name = "Goa",
                    Abbreviation = "GA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 840,
                    CountryId = 104,
                    Name = "Gujarat",
                    Abbreviation = "GJ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 841,
                    CountryId = 104,
                    Name = "Haryana",
                    Abbreviation = "HR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 842,
                    CountryId = 104,
                    Name = "Himachal Pradesh",
                    Abbreviation = "HP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 843,
                    CountryId = 104,
                    Name = "Jammu and Kashmir",
                    Abbreviation = "JK",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 844,
                    CountryId = 104,
                    Name = "Jharkhand",
                    Abbreviation = "JH",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 845,
                    CountryId = 104,
                    Name = "Karnataka",
                    Abbreviation = "KA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 846,
                    CountryId = 104,
                    Name = "Kerala",
                    Abbreviation = "KL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 847,
                    CountryId = 104,
                    Name = "Madhya Pradesh",
                    Abbreviation = "MP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 848,
                    CountryId = 104,
                    Name = "Maharashtra",
                    Abbreviation = "MH",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 849,
                    CountryId = 104,
                    Name = "Manipur",
                    Abbreviation = "MN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 850,
                    CountryId = 104,
                    Name = "Meghalaya",
                    Abbreviation = "ML",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 851,
                    CountryId = 104,
                    Name = "Mizoram",
                    Abbreviation = "MZ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 852,
                    CountryId = 104,
                    Name = "Nagaland",
                    Abbreviation = "NL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 853,
                    CountryId = 104,
                    Name = "Odisha",
                    Abbreviation = "OR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 854,
                    CountryId = 104,
                    Name = "Punjab",
                    Abbreviation = "PB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 855,
                    CountryId = 104,
                    Name = "Rajasthan",
                    Abbreviation = "RJ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 856,
                    CountryId = 104,
                    Name = "Sikkim",
                    Abbreviation = "SK",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 857,
                    CountryId = 104,
                    Name = "Tamil Nadu",
                    Abbreviation = "TN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 858,
                    CountryId = 104,
                    Name = "Telangana",
                    Abbreviation = "TG",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 859,
                    CountryId = 104,
                    Name = "Tripura",
                    Abbreviation = "TR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 860,
                    CountryId = 104,
                    Name = "Uttarakhand",
                    Abbreviation = "UT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 861,
                    CountryId = 104,
                    Name = "Uttar Pradesh",
                    Abbreviation = "UP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 862,
                    CountryId = 104,
                    Name = "West Bengal",
                    Abbreviation = "WB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 863,
                    CountryId = 104,
                    Name = "Andaman and Nicobar Islands",
                    Abbreviation = "AN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 864,
                    CountryId = 104,
                    Name = "Chandigarh",
                    Abbreviation = "CH",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 865,
                    CountryId = 104,
                    Name = "Dadra and Nagar Haveli",
                    Abbreviation = "DN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 866,
                    CountryId = 104,
                    Name = "Daman and Diu",
                    Abbreviation = "DD",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 867,
                    CountryId = 104,
                    Name = "Delhi",
                    Abbreviation = "DL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 868,
                    CountryId = 104,
                    Name = "Lakshadweep",
                    Abbreviation = "LD",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 869,
                    CountryId = 104,
                    Name = "Puducherry",
                    Abbreviation = "PY",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 774,
                    CountryId = 105,
                    Name = "Aceh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 775,
                    CountryId = 105,
                    Name = "Bali",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 776,
                    CountryId = 105,
                    Name = "Banten",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 777,
                    CountryId = 105,
                    Name = "Bengkulu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 778,
                    CountryId = 105,
                    Name = "Gorontalo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 779,
                    CountryId = 105,
                    Name = "Jakarta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 780,
                    CountryId = 105,
                    Name = "Jambi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 781,
                    CountryId = 105,
                    Name = "Jawa Barat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 782,
                    CountryId = 105,
                    Name = "Jawa Tengah",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 783,
                    CountryId = 105,
                    Name = "Jawa Timur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 784,
                    CountryId = 105,
                    Name = "Kalimantan Barat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 785,
                    CountryId = 105,
                    Name = "Kalimantan Selatan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 786,
                    CountryId = 105,
                    Name = "Kalimantan Tengah",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 787,
                    CountryId = 105,
                    Name = "Kalimantan Timur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 788,
                    CountryId = 105,
                    Name = "Kalimantan Utara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 789,
                    CountryId = 105,
                    Name = "Kepulauan Bangka Belitung",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 790,
                    CountryId = 105,
                    Name = "Kepulauan Riau",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 791,
                    CountryId = 105,
                    Name = "Lampung",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 792,
                    CountryId = 105,
                    Name = "Maluku",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 793,
                    CountryId = 105,
                    Name = "Maluku Utara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 794,
                    CountryId = 105,
                    Name = "Nusa Tenggara Barat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 795,
                    CountryId = 105,
                    Name = "Nusa Tenggara Timur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 796,
                    CountryId = 105,
                    Name = "Papua",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 797,
                    CountryId = 105,
                    Name = "Papua Barat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 798,
                    CountryId = 105,
                    Name = "Riau",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 799,
                    CountryId = 105,
                    Name = "Sulawesi Barat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 800,
                    CountryId = 105,
                    Name = "Sulawesi Selatan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 801,
                    CountryId = 105,
                    Name = "Sulawesi Tengah",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 28
                },

                new StateProvince()
                {
                    Id = 802,
                    CountryId = 105,
                    Name = "Sulawesi Tenggara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 29
                },

                new StateProvince()
                {
                    Id = 803,
                    CountryId = 105,
                    Name = "Sulawesi Utara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 30
                },

                new StateProvince()
                {
                    Id = 804,
                    CountryId = 105,
                    Name = "Sumatera Barat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 31
                },

                new StateProvince()
                {
                    Id = 805,
                    CountryId = 105,
                    Name = "Sumatera Selatan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 32
                },

                new StateProvince()
                {
                    Id = 806,
                    CountryId = 105,
                    Name = "Sumatera Utara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 33
                },

                new StateProvince()
                {
                    Id = 807,
                    CountryId = 105,
                    Name = "Yogyakarta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 34
                },

                new StateProvince()
                {
                    Id = 870,
                    CountryId = 106,
                    Name = "آذربایجان شرقی",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 871,
                    CountryId = 106,
                    Name = "آذربایجان غربی",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 872,
                    CountryId = 106,
                    Name = "اردبیل",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 873,
                    CountryId = 106,
                    Name = "اصفهان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 874,
                    CountryId = 106,
                    Name = "البرز",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 875,
                    CountryId = 106,
                    Name = "ایلام",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 876,
                    CountryId = 106,
                    Name = "بوشهر",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 877,
                    CountryId = 106,
                    Name = "تهران",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 878,
                    CountryId = 106,
                    Name = "چهارمحال و بختیاری",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 879,
                    CountryId = 106,
                    Name = "خراسان جنوبی",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 880,
                    CountryId = 106,
                    Name = "خراسان رضوی",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 881,
                    CountryId = 106,
                    Name = "خراسان شمالی",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 882,
                    CountryId = 106,
                    Name = "خوزستان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 883,
                    CountryId = 106,
                    Name = "زنجان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 884,
                    CountryId = 106,
                    Name = "سمنان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 885,
                    CountryId = 106,
                    Name = "سیستان و بلوچستان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 886,
                    CountryId = 106,
                    Name = "فارس",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 887,
                    CountryId = 106,
                    Name = "قزوین",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 888,
                    CountryId = 106,
                    Name = "قم",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 889,
                    CountryId = 106,
                    Name = "کردستان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 890,
                    CountryId = 106,
                    Name = "کرمان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 891,
                    CountryId = 106,
                    Name = "کرمانشاه",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 892,
                    CountryId = 106,
                    Name = "کهگیلویه و بویراحمد",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 893,
                    CountryId = 106,
                    Name = "گلستان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 894,
                    CountryId = 106,
                    Name = "گیلان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 895,
                    CountryId = 106,
                    Name = "لرستان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 896,
                    CountryId = 106,
                    Name = "مازندران",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 897,
                    CountryId = 106,
                    Name = "مرکزی",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 898,
                    CountryId = 106,
                    Name = "هرمزگان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 899,
                    CountryId = 106,
                    Name = "همدان",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 900,
                    CountryId = 106,
                    Name = "یزد",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 808,
                    CountryId = 108,
                    Name = "County Carlow",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 809,
                    CountryId = 108,
                    Name = "County Cavan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 810,
                    CountryId = 108,
                    Name = "County Clare",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 811,
                    CountryId = 108,
                    Name = "County Cork",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 812,
                    CountryId = 108,
                    Name = "County Donegal",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 813,
                    CountryId = 108,
                    Name = "County Dublin",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 814,
                    CountryId = 108,
                    Name = "County Galway",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 815,
                    CountryId = 108,
                    Name = "County Kerry",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 816,
                    CountryId = 108,
                    Name = "County Kildare",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 817,
                    CountryId = 108,
                    Name = "County Kilkenny",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 818,
                    CountryId = 108,
                    Name = "County Laois",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 819,
                    CountryId = 108,
                    Name = "County Leitrim",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 820,
                    CountryId = 108,
                    Name = "County Limerick",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 821,
                    CountryId = 108,
                    Name = "County Longford",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 822,
                    CountryId = 108,
                    Name = "County Louth",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 823,
                    CountryId = 108,
                    Name = "County Mayo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 824,
                    CountryId = 108,
                    Name = "County Meath",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 825,
                    CountryId = 108,
                    Name = "County Monaghan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 826,
                    CountryId = 108,
                    Name = "County Offaly",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 827,
                    CountryId = 108,
                    Name = "County Roscommon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 828,
                    CountryId = 108,
                    Name = "County Sligo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 829,
                    CountryId = 108,
                    Name = "County Tipperary",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 830,
                    CountryId = 108,
                    Name = "County Waterford",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 831,
                    CountryId = 108,
                    Name = "County Westmeath",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 832,
                    CountryId = 108,
                    Name = "County Wexford",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 833,
                    CountryId = 108,
                    Name = "County Wicklow",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 909,
                    CountryId = 111,
                    Name = "Agrigento",
                    Abbreviation = "AG",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 910,
                    CountryId = 111,
                    Name = "Alessandria",
                    Abbreviation = "AL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 911,
                    CountryId = 111,
                    Name = "Ancona",
                    Abbreviation = "AN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 912,
                    CountryId = 111,
                    Name = "Aosta",
                    Abbreviation = "AO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 913,
                    CountryId = 111,
                    Name = "Arezzo",
                    Abbreviation = "AR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 914,
                    CountryId = 111,
                    Name = "Ascoli Piceno",
                    Abbreviation = "AP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 915,
                    CountryId = 111,
                    Name = "Asti",
                    Abbreviation = "AT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 916,
                    CountryId = 111,
                    Name = "Avellino",
                    Abbreviation = "AV",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 917,
                    CountryId = 111,
                    Name = "Bari",
                    Abbreviation = "BA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 918,
                    CountryId = 111,
                    Name = "Barletta-Andria-Trani",
                    Abbreviation = "BT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 919,
                    CountryId = 111,
                    Name = "Belluno",
                    Abbreviation = "BL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 920,
                    CountryId = 111,
                    Name = "Benevento",
                    Abbreviation = "BN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 921,
                    CountryId = 111,
                    Name = "Bergamo",
                    Abbreviation = "BG",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 922,
                    CountryId = 111,
                    Name = "Biella",
                    Abbreviation = "BI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 923,
                    CountryId = 111,
                    Name = "Bologna",
                    Abbreviation = "BO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 924,
                    CountryId = 111,
                    Name = "Bolzano",
                    Abbreviation = "BZ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 925,
                    CountryId = 111,
                    Name = "Brescia",
                    Abbreviation = "BS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 926,
                    CountryId = 111,
                    Name = "Brindisi",
                    Abbreviation = "BR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 927,
                    CountryId = 111,
                    Name = "Cagliari",
                    Abbreviation = "CA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 928,
                    CountryId = 111,
                    Name = "Caltanissetta",
                    Abbreviation = "CL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 929,
                    CountryId = 111,
                    Name = "Campobasso",
                    Abbreviation = "CB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 930,
                    CountryId = 111,
                    Name = "Carbonia-Iglesias",
                    Abbreviation = "CI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 931,
                    CountryId = 111,
                    Name = "Caserta",
                    Abbreviation = "CE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 932,
                    CountryId = 111,
                    Name = "Catania",
                    Abbreviation = "CT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 933,
                    CountryId = 111,
                    Name = "Catanzaro",
                    Abbreviation = "CZ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 934,
                    CountryId = 111,
                    Name = "Chieti",
                    Abbreviation = "CH",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 935,
                    CountryId = 111,
                    Name = "Como",
                    Abbreviation = "CO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 936,
                    CountryId = 111,
                    Name = "Cosenza",
                    Abbreviation = "CS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 937,
                    CountryId = 111,
                    Name = "Cremona",
                    Abbreviation = "CR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 938,
                    CountryId = 111,
                    Name = "Crotone",
                    Abbreviation = "KR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 939,
                    CountryId = 111,
                    Name = "Cuneo",
                    Abbreviation = "CN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 940,
                    CountryId = 111,
                    Name = "Enna",
                    Abbreviation = "EN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 941,
                    CountryId = 111,
                    Name = "Fermo",
                    Abbreviation = "FM",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 942,
                    CountryId = 111,
                    Name = "Ferrara",
                    Abbreviation = "FE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 943,
                    CountryId = 111,
                    Name = "Firenze",
                    Abbreviation = "FI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 944,
                    CountryId = 111,
                    Name = "Foggia",
                    Abbreviation = "FG",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 945,
                    CountryId = 111,
                    Name = "Forlì-Cesena",
                    Abbreviation = "FC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 946,
                    CountryId = 111,
                    Name = "Frosinone",
                    Abbreviation = "FR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 947,
                    CountryId = 111,
                    Name = "Genova",
                    Abbreviation = "GE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 948,
                    CountryId = 111,
                    Name = "Gorizia",
                    Abbreviation = "GO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 949,
                    CountryId = 111,
                    Name = "Grosseto",
                    Abbreviation = "GR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 950,
                    CountryId = 111,
                    Name = "Imperia",
                    Abbreviation = "IM",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 951,
                    CountryId = 111,
                    Name = "Isernia",
                    Abbreviation = "IS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 952,
                    CountryId = 111,
                    Name = "La Spezia",
                    Abbreviation = "SP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 953,
                    CountryId = 111,
                    Name = "L'Aquila",
                    Abbreviation = "AQ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 954,
                    CountryId = 111,
                    Name = "Latina",
                    Abbreviation = "LT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 955,
                    CountryId = 111,
                    Name = "Lecce",
                    Abbreviation = "LE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 956,
                    CountryId = 111,
                    Name = "Lecco",
                    Abbreviation = "LC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 957,
                    CountryId = 111,
                    Name = "Livorno",
                    Abbreviation = "LI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 958,
                    CountryId = 111,
                    Name = "Lodi",
                    Abbreviation = "LO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 959,
                    CountryId = 111,
                    Name = "Lucca",
                    Abbreviation = "LU",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 960,
                    CountryId = 111,
                    Name = "Macerata",
                    Abbreviation = "MC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 961,
                    CountryId = 111,
                    Name = "Mantova",
                    Abbreviation = "MN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 962,
                    CountryId = 111,
                    Name = "Massa-Carrara",
                    Abbreviation = "MS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 963,
                    CountryId = 111,
                    Name = "Matera",
                    Abbreviation = "MT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 964,
                    CountryId = 111,
                    Name = "Medio Campidano",
                    Abbreviation = "VS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 965,
                    CountryId = 111,
                    Name = "Messina",
                    Abbreviation = "ME",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 966,
                    CountryId = 111,
                    Name = "Milano",
                    Abbreviation = "MI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 967,
                    CountryId = 111,
                    Name = "Modena",
                    Abbreviation = "MO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 968,
                    CountryId = 111,
                    Name = "Monza e della Brianza",
                    Abbreviation = "MB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 969,
                    CountryId = 111,
                    Name = "Napoli",
                    Abbreviation = "NA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 970,
                    CountryId = 111,
                    Name = "Novara",
                    Abbreviation = "NO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 971,
                    CountryId = 111,
                    Name = "Nuoro",
                    Abbreviation = "NU",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 972,
                    CountryId = 111,
                    Name = "Ogliastra",
                    Abbreviation = "OG",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 973,
                    CountryId = 111,
                    Name = "Olbia-Tempio",
                    Abbreviation = "OT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 974,
                    CountryId = 111,
                    Name = "Oristano",
                    Abbreviation = "OR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 975,
                    CountryId = 111,
                    Name = "Padova",
                    Abbreviation = "PD",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 976,
                    CountryId = 111,
                    Name = "Palermo",
                    Abbreviation = "PA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 977,
                    CountryId = 111,
                    Name = "Parma",
                    Abbreviation = "PR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 978,
                    CountryId = 111,
                    Name = "Pavia",
                    Abbreviation = "PV",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 979,
                    CountryId = 111,
                    Name = "Perugia",
                    Abbreviation = "PG",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 980,
                    CountryId = 111,
                    Name = "Pesaro e Urbino",
                    Abbreviation = "PU",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 981,
                    CountryId = 111,
                    Name = "Pescara",
                    Abbreviation = "PE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 982,
                    CountryId = 111,
                    Name = "Piacenza",
                    Abbreviation = "PC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 983,
                    CountryId = 111,
                    Name = "Pisa",
                    Abbreviation = "PI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 984,
                    CountryId = 111,
                    Name = "Pistoia",
                    Abbreviation = "PT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 985,
                    CountryId = 111,
                    Name = "Pordenone",
                    Abbreviation = "PN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 986,
                    CountryId = 111,
                    Name = "Potenza",
                    Abbreviation = "PZ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 987,
                    CountryId = 111,
                    Name = "Prato",
                    Abbreviation = "PO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 988,
                    CountryId = 111,
                    Name = "Ragusa",
                    Abbreviation = "RG",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 989,
                    CountryId = 111,
                    Name = "Ravenna",
                    Abbreviation = "RA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 990,
                    CountryId = 111,
                    Name = "Reggio Calabria",
                    Abbreviation = "RC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 991,
                    CountryId = 111,
                    Name = "Reggio Emilia",
                    Abbreviation = "RE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 992,
                    CountryId = 111,
                    Name = "Rieti",
                    Abbreviation = "RI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 993,
                    CountryId = 111,
                    Name = "Rimini",
                    Abbreviation = "RN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 994,
                    CountryId = 111,
                    Name = "Roma",
                    Abbreviation = "RM",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 995,
                    CountryId = 111,
                    Name = "Rovigo",
                    Abbreviation = "RO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 996,
                    CountryId = 111,
                    Name = "Salerno",
                    Abbreviation = "SA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 997,
                    CountryId = 111,
                    Name = "Sassari",
                    Abbreviation = "SS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 998,
                    CountryId = 111,
                    Name = "Savona",
                    Abbreviation = "SV",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 999,
                    CountryId = 111,
                    Name = "Siena",
                    Abbreviation = "SI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1000,
                    CountryId = 111,
                    Name = "Siracusa",
                    Abbreviation = "SR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1001,
                    CountryId = 111,
                    Name = "Sondrio",
                    Abbreviation = "SO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1002,
                    CountryId = 111,
                    Name = "Taranto",
                    Abbreviation = "TA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1003,
                    CountryId = 111,
                    Name = "Teramo",
                    Abbreviation = "TE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1004,
                    CountryId = 111,
                    Name = "Terni",
                    Abbreviation = "TR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1005,
                    CountryId = 111,
                    Name = "Torino",
                    Abbreviation = "TO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1006,
                    CountryId = 111,
                    Name = "Trapani",
                    Abbreviation = "TP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1007,
                    CountryId = 111,
                    Name = "Trento",
                    Abbreviation = "TN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1008,
                    CountryId = 111,
                    Name = "Treviso",
                    Abbreviation = "TV",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1009,
                    CountryId = 111,
                    Name = "Trieste",
                    Abbreviation = "TS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1010,
                    CountryId = 111,
                    Name = "Udine",
                    Abbreviation = "UD",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1011,
                    CountryId = 111,
                    Name = "Varese",
                    Abbreviation = "VA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1012,
                    CountryId = 111,
                    Name = "Venezia",
                    Abbreviation = "VE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1013,
                    CountryId = 111,
                    Name = "Verbano-Cusio-Ossola",
                    Abbreviation = "VB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1014,
                    CountryId = 111,
                    Name = "Vercelli",
                    Abbreviation = "VC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1015,
                    CountryId = 111,
                    Name = "Verona",
                    Abbreviation = "VR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1016,
                    CountryId = 111,
                    Name = "Vibo Valentia",
                    Abbreviation = "VV",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1017,
                    CountryId = 111,
                    Name = "Vicenza",
                    Abbreviation = "VI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1018,
                    CountryId = 111,
                    Name = "Viterbo",
                    Abbreviation = "VT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1019,
                    CountryId = 121,
                    Name = "Al Asimah",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1020,
                    CountryId = 121,
                    Name = "Hawalli",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1021,
                    CountryId = 121,
                    Name = "Al Farwaniya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1022,
                    CountryId = 121,
                    Name = "Mubarak Al Kabeer",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1023,
                    CountryId = 121,
                    Name = "Al Ahmadi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1024,
                    CountryId = 121,
                    Name = "Al Jahraa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1025,
                    CountryId = 130,
                    Name = "Alytaus apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1026,
                    CountryId = 130,
                    Name = "Kauno apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1027,
                    CountryId = 130,
                    Name = "Klaipėdos apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1028,
                    CountryId = 130,
                    Name = "Marijampolės apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1029,
                    CountryId = 130,
                    Name = "Panevėžio apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1030,
                    CountryId = 130,
                    Name = "Šiaulių apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1031,
                    CountryId = 130,
                    Name = "Tauragės apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1032,
                    CountryId = 130,
                    Name = "Telšių apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1033,
                    CountryId = 130,
                    Name = "Utenos apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1034,
                    CountryId = 130,
                    Name = "Vilniaus apskritis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1035,
                    CountryId = 131,
                    Name = "Capellen",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1036,
                    CountryId = 131,
                    Name = "Clerveaux",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1037,
                    CountryId = 131,
                    Name = "Diekirch",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1038,
                    CountryId = 131,
                    Name = "Echternach",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1039,
                    CountryId = 131,
                    Name = "Esch-Sur-Azette",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1040,
                    CountryId = 131,
                    Name = "Greven-Macher",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1041,
                    CountryId = 131,
                    Name = "Luxembourg Campagne",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1042,
                    CountryId = 131,
                    Name = "Mersch",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1043,
                    CountryId = 131,
                    Name = "Redange",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1044,
                    CountryId = 131,
                    Name = "Remich",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1045,
                    CountryId = 131,
                    Name = "Vianden",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1046,
                    CountryId = 131,
                    Name = "Wiltz",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1133,
                    CountryId = 136,
                    Name = "Johor",
                    Abbreviation = "JHR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1134,
                    CountryId = 136,
                    Name = "Kedah",
                    Abbreviation = "KDH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1135,
                    CountryId = 136,
                    Name = "Kelantan",
                    Abbreviation = "KTN",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1136,
                    CountryId = 136,
                    Name = "Kuala Lumpur",
                    Abbreviation = "KUL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1137,
                    CountryId = 136,
                    Name = "Labuan",
                    Abbreviation = "LBN",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1138,
                    CountryId = 136,
                    Name = "Melaka",
                    Abbreviation = "MLK",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1139,
                    CountryId = 136,
                    Name = "Negeri Sembilan",
                    Abbreviation = "NSN",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1140,
                    CountryId = 136,
                    Name = "Pahang",
                    Abbreviation = "PHG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1141,
                    CountryId = 136,
                    Name = "Perak",
                    Abbreviation = "PRK",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1142,
                    CountryId = 136,
                    Name = "Perlis",
                    Abbreviation = "PLS",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1143,
                    CountryId = 136,
                    Name = "Pulau Pinang",
                    Abbreviation = "PNG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1144,
                    CountryId = 136,
                    Name = "Putrajaya",
                    Abbreviation = "PJY",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1145,
                    CountryId = 136,
                    Name = "Sabah",
                    Abbreviation = "SBH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1146,
                    CountryId = 136,
                    Name = "Sarawak",
                    Abbreviation = "SWK",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1147,
                    CountryId = 136,
                    Name = "Selangor",
                    Abbreviation = "SGR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1148,
                    CountryId = 136,
                    Name = "Terengganu",
                    Abbreviation = "TRG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1101,
                    CountryId = 145,
                    Name = "Aguascalientes",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1102,
                    CountryId = 145,
                    Name = "Baja California",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1103,
                    CountryId = 145,
                    Name = "Baja California Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1104,
                    CountryId = 145,
                    Name = "Campeche",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1105,
                    CountryId = 145,
                    Name = "Chiapas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1106,
                    CountryId = 145,
                    Name = "Chihuahua",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1107,
                    CountryId = 145,
                    Name = "Coahuila",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1108,
                    CountryId = 145,
                    Name = "Colima",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1109,
                    CountryId = 145,
                    Name = "Distrito Federal",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1110,
                    CountryId = 145,
                    Name = "Durango",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1111,
                    CountryId = 145,
                    Name = "Estado de México",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1112,
                    CountryId = 145,
                    Name = "Guanajuato",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1113,
                    CountryId = 145,
                    Name = "Guerrero",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1114,
                    CountryId = 145,
                    Name = "Hidalgo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1115,
                    CountryId = 145,
                    Name = "Jalisco",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1116,
                    CountryId = 145,
                    Name = "Michoacán",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1117,
                    CountryId = 145,
                    Name = "Morelos",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1118,
                    CountryId = 145,
                    Name = "Nayarit",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1119,
                    CountryId = 145,
                    Name = "Nuevo León",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1120,
                    CountryId = 145,
                    Name = "Oaxaca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1121,
                    CountryId = 145,
                    Name = "Puebla",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1122,
                    CountryId = 145,
                    Name = "Querétaro",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1123,
                    CountryId = 145,
                    Name = "Quintana Roo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1124,
                    CountryId = 145,
                    Name = "San Luis Potosí",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1125,
                    CountryId = 145,
                    Name = "Sinaloa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1126,
                    CountryId = 145,
                    Name = "Sonora",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1127,
                    CountryId = 145,
                    Name = "Tabasco",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1128,
                    CountryId = 145,
                    Name = "Tamaulipas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1129,
                    CountryId = 145,
                    Name = "Tlaxcala",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1130,
                    CountryId = 145,
                    Name = "Veracruz",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1131,
                    CountryId = 145,
                    Name = "Yucatán",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1132,
                    CountryId = 145,
                    Name = "Zacatecas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1071,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Багануур дүүрэг",
                    Abbreviation = "БН",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1072,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Багахангай дүүрэг",
                    Abbreviation = "БХ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1073,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Баянгол дүүрэг",
                    Abbreviation = "БГ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1074,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Баянзүрх дүүрэг",
                    Abbreviation = "БЗ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1075,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Налайх дүүрэг",
                    Abbreviation = "НА",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1076,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Сонгино хайрхан дүүрэг",
                    Abbreviation = "СХ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1077,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Сүхбаатар дүүрэг",
                    Abbreviation = "СБ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1078,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Хан-Уул дүүрэг",
                    Abbreviation = "ХУ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1079,
                    CountryId = 149,
                    Name = "Улаанбаатар хот - Чингэлтэй дүүрэг",
                    Abbreviation = "ЧИ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1080,
                    CountryId = 149,
                    Name = "Архангай аймаг",
                    Abbreviation = "АР",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1081,
                    CountryId = 149,
                    Name = "Баян-Өлгий аймаг",
                    Abbreviation = "БӨ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1082,
                    CountryId = 149,
                    Name = "Баянхонгор аймаг",
                    Abbreviation = "БХ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1083,
                    CountryId = 149,
                    Name = "Булган аймаг",
                    Abbreviation = "БУ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1084,
                    CountryId = 149,
                    Name = "Өвөрхангай аймаг",
                    Abbreviation = "ӨВ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1085,
                    CountryId = 149,
                    Name = "Говь-Алтай аймаг",
                    Abbreviation = "ГА",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1086,
                    CountryId = 149,
                    Name = "Говьсүмбэр аймаг",
                    Abbreviation = "ГС",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1087,
                    CountryId = 149,
                    Name = "Дархан-Уул аймаг",
                    Abbreviation = "ДА",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1088,
                    CountryId = 149,
                    Name = "Дорноговь аймаг",
                    Abbreviation = "ДГ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1089,
                    CountryId = 149,
                    Name = "Дорнод аймаг",
                    Abbreviation = "ДО",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1090,
                    CountryId = 149,
                    Name = "Дундговь аймаг",
                    Abbreviation = "ДУ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1091,
                    CountryId = 149,
                    Name = "Завхан аймаг",
                    Abbreviation = "ЗА",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1092,
                    CountryId = 149,
                    Name = "Өмнөговь аймаг",
                    Abbreviation = "ӨМ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1093,
                    CountryId = 149,
                    Name = "Орхон аймаг",
                    Abbreviation = "ОР",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1094,
                    CountryId = 149,
                    Name = "Сүхбаатар аймаг",
                    Abbreviation = "СҮ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1095,
                    CountryId = 149,
                    Name = "Сэлэнгэ аймаг",
                    Abbreviation = "СЭ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1096,
                    CountryId = 149,
                    Name = "Төв аймаг",
                    Abbreviation = "ТӨ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1097,
                    CountryId = 149,
                    Name = "Увс аймаг",
                    Abbreviation = "УВ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1098,
                    CountryId = 149,
                    Name = "Хөвсгөл аймаг",
                    Abbreviation = "ХӨ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1099,
                    CountryId = 149,
                    Name = "Ховд аймаг",
                    Abbreviation = "ХО",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1100,
                    CountryId = 149,
                    Name = "Хэнтий аймаг",
                    Abbreviation = "ХЭ",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1047,
                    CountryId = 152,
                    Name = "Agadir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1048,
                    CountryId = 152,
                    Name = "Beni mellal",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1049,
                    CountryId = 152,
                    Name = "Berkane",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1050,
                    CountryId = 152,
                    Name = "Casablanca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1051,
                    CountryId = 152,
                    Name = "El jadida",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1052,
                    CountryId = 152,
                    Name = "Fes",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1053,
                    CountryId = 152,
                    Name = "Inezgane",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1054,
                    CountryId = 152,
                    Name = "Kenitra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1055,
                    CountryId = 152,
                    Name = "Khemisset",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1056,
                    CountryId = 152,
                    Name = "Khenifra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1057,
                    CountryId = 152,
                    Name = "Khouribga",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1058,
                    CountryId = 152,
                    Name = "Laayoune",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1059,
                    CountryId = 152,
                    Name = "Marrakech",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1060,
                    CountryId = 152,
                    Name = "Meknes",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1061,
                    CountryId = 152,
                    Name = "Mohammedia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1062,
                    CountryId = 152,
                    Name = "Nador",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1063,
                    CountryId = 152,
                    Name = "Oujda",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1064,
                    CountryId = 152,
                    Name = "Rabat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1065,
                    CountryId = 152,
                    Name = "Safi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1066,
                    CountryId = 152,
                    Name = "Sale",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1067,
                    CountryId = 152,
                    Name = "Tanger",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1068,
                    CountryId = 152,
                    Name = "Taza",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1069,
                    CountryId = 152,
                    Name = "Temara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1070,
                    CountryId = 152,
                    Name = "Tetouan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1219,
                    CountryId = 157,
                    Name = "Province No. 1",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1220,
                    CountryId = 157,
                    Name = "Province No. 2",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1221,
                    CountryId = 157,
                    Name = "Province No. 3",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1222,
                    CountryId = 157,
                    Name = "Gandaki Pradesh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1223,
                    CountryId = 157,
                    Name = "Province No. 5",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1224,
                    CountryId = 157,
                    Name = "Karnali Pradesh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1225,
                    CountryId = 157,
                    Name = "Sudurpashchim Pradesh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1186,
                    CountryId = 158,
                    Name = "Drenthe",
                    Abbreviation = "DR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1187,
                    CountryId = 158,
                    Name = "Flevoland",
                    Abbreviation = "FL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1188,
                    CountryId = 158,
                    Name = "Friesland",
                    Abbreviation = "FR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1189,
                    CountryId = 158,
                    Name = "Gelderland",
                    Abbreviation = "GD",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1190,
                    CountryId = 158,
                    Name = "Groningen",
                    Abbreviation = "GR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1191,
                    CountryId = 158,
                    Name = "Limburg",
                    Abbreviation = "LB",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1192,
                    CountryId = 158,
                    Name = "Noord-Brabant",
                    Abbreviation = "NB",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1193,
                    CountryId = 158,
                    Name = "Noord-Holland",
                    Abbreviation = "NH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1194,
                    CountryId = 158,
                    Name = "Overijssel",
                    Abbreviation = "OV",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1195,
                    CountryId = 158,
                    Name = "Utrecht",
                    Abbreviation = "UT",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1196,
                    CountryId = 158,
                    Name = "Zeeland",
                    Abbreviation = "ZL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1197,
                    CountryId = 158,
                    Name = "Zuid-Holland",
                    Abbreviation = "ZH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1226,
                    CountryId = 160,
                    Name = "Northland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1227,
                    CountryId = 160,
                    Name = "Auckland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1228,
                    CountryId = 160,
                    Name = "Waikato",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1229,
                    CountryId = 160,
                    Name = "Waitomo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1230,
                    CountryId = 160,
                    Name = "Bay of Plenty",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1231,
                    CountryId = 160,
                    Name = "Taupo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1232,
                    CountryId = 160,
                    Name = "King Country",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1233,
                    CountryId = 160,
                    Name = "Taranaki",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1234,
                    CountryId = 160,
                    Name = "Wanganui",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1235,
                    CountryId = 160,
                    Name = "Manawatu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1236,
                    CountryId = 160,
                    Name = "Horowhenua",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1237,
                    CountryId = 160,
                    Name = "Kapiti",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1238,
                    CountryId = 160,
                    Name = "Gisborne",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1239,
                    CountryId = 160,
                    Name = "Hawkes Bay",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1240,
                    CountryId = 160,
                    Name = "Wairarapa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1241,
                    CountryId = 160,
                    Name = "Wellington",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1242,
                    CountryId = 160,
                    Name = "Nelson",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1243,
                    CountryId = 160,
                    Name = "Marlborough",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1244,
                    CountryId = 160,
                    Name = "Buller",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1245,
                    CountryId = 160,
                    Name = "West Coast",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1246,
                    CountryId = 160,
                    Name = "Canterbury",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1247,
                    CountryId = 160,
                    Name = "Otago",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1248,
                    CountryId = 160,
                    Name = "Southland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1149,
                    CountryId = 163,
                    Name = "Abia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1150,
                    CountryId = 163,
                    Name = "Adamawa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1151,
                    CountryId = 163,
                    Name = "Akwa Ibom",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1152,
                    CountryId = 163,
                    Name = "Anambra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1153,
                    CountryId = 163,
                    Name = "Bauchi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1154,
                    CountryId = 163,
                    Name = "Bayelsa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1155,
                    CountryId = 163,
                    Name = "Benue",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1156,
                    CountryId = 163,
                    Name = "Borno",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1157,
                    CountryId = 163,
                    Name = "Cross River",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1158,
                    CountryId = 163,
                    Name = "Delta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1159,
                    CountryId = 163,
                    Name = "Ebonyi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1160,
                    CountryId = 163,
                    Name = "Edo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1161,
                    CountryId = 163,
                    Name = "Enugu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1162,
                    CountryId = 163,
                    Name = "Ekiti",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1163,
                    CountryId = 163,
                    Name = "FCT",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1164,
                    CountryId = 163,
                    Name = "Gombe",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1165,
                    CountryId = 163,
                    Name = "Imo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1166,
                    CountryId = 163,
                    Name = "Jigawa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1167,
                    CountryId = 163,
                    Name = "Kaduna",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1168,
                    CountryId = 163,
                    Name = "Kano",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1169,
                    CountryId = 163,
                    Name = "Katsina",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1170,
                    CountryId = 163,
                    Name = "Kebbi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1171,
                    CountryId = 163,
                    Name = "Kogi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1172,
                    CountryId = 163,
                    Name = "Kwara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1173,
                    CountryId = 163,
                    Name = "Lagos",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1174,
                    CountryId = 163,
                    Name = "Nasarawa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1175,
                    CountryId = 163,
                    Name = "Niger",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1176,
                    CountryId = 163,
                    Name = "Ogun",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1177,
                    CountryId = 163,
                    Name = "Ondo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1178,
                    CountryId = 163,
                    Name = "Osun",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1179,
                    CountryId = 163,
                    Name = "Oyo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1180,
                    CountryId = 163,
                    Name = "Plateau",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1181,
                    CountryId = 163,
                    Name = "Rivers",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1182,
                    CountryId = 163,
                    Name = "Sokoto",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1183,
                    CountryId = 163,
                    Name = "Taraba",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1184,
                    CountryId = 163,
                    Name = "Yobe",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1185,
                    CountryId = 163,
                    Name = "Zamafara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1198,
                    CountryId = 167,
                    Name = "Østfold",
                    Abbreviation = "01",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1199,
                    CountryId = 167,
                    Name = "Akershus",
                    Abbreviation = "02",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1200,
                    CountryId = 167,
                    Name = "Oslo",
                    Abbreviation = "03",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1201,
                    CountryId = 167,
                    Name = "Hedmark",
                    Abbreviation = "04",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1202,
                    CountryId = 167,
                    Name = "Oppland",
                    Abbreviation = "05",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1203,
                    CountryId = 167,
                    Name = "Buskerud",
                    Abbreviation = "06",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1204,
                    CountryId = 167,
                    Name = "Vestfold",
                    Abbreviation = "07",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1205,
                    CountryId = 167,
                    Name = "Telemark",
                    Abbreviation = "08",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1206,
                    CountryId = 167,
                    Name = "Aust-Agder",
                    Abbreviation = "09",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1207,
                    CountryId = 167,
                    Name = "Vest-Agder",
                    Abbreviation = "10",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 1208,
                    CountryId = 167,
                    Name = "Rogaland",
                    Abbreviation = "11",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1209,
                    CountryId = 167,
                    Name = "Hordaland",
                    Abbreviation = "12",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1210,
                    CountryId = 167,
                    Name = "Sogn og Fjordane",
                    Abbreviation = "14",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 1211,
                    CountryId = 167,
                    Name = "Møre og Romsdal",
                    Abbreviation = "15",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 1212,
                    CountryId = 167,
                    Name = "Sør-Trøndelag",
                    Abbreviation = "16",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 1213,
                    CountryId = 167,
                    Name = "Nord-Trøndelag",
                    Abbreviation = "17",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 1214,
                    CountryId = 167,
                    Name = "Nordland",
                    Abbreviation = "18",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 1215,
                    CountryId = 167,
                    Name = "Troms",
                    Abbreviation = "19",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 1216,
                    CountryId = 167,
                    Name = "Finnmark",
                    Abbreviation = "20",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1217,
                    CountryId = 167,
                    Name = "Svalbard",
                    Abbreviation = "21",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 1218,
                    CountryId = 167,
                    Name = "Jan Mayen",
                    Abbreviation = "22",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 1331,
                    CountryId = 169,
                    Name = "Azad Kashmir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1332,
                    CountryId = 169,
                    Name = "Balochistan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1333,
                    CountryId = 169,
                    Name = "Capital Territory",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1334,
                    CountryId = 169,
                    Name = "Gilgit–Baltistan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1335,
                    CountryId = 169,
                    Name = "Khyber Pakhtunkhwa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1336,
                    CountryId = 169,
                    Name = "Punjab",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1337,
                    CountryId = 169,
                    Name = "Sindh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1338,
                    CountryId = 169,
                    Name = "Tribal Areas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1249,
                    CountryId = 176,
                    Name = "Abra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1250,
                    CountryId = 176,
                    Name = "Agusan del Norte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1251,
                    CountryId = 176,
                    Name = "Agusan del Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1252,
                    CountryId = 176,
                    Name = "Aklan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1253,
                    CountryId = 176,
                    Name = "Albay",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1254,
                    CountryId = 176,
                    Name = "Antique",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1255,
                    CountryId = 176,
                    Name = "Apayao",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1256,
                    CountryId = 176,
                    Name = "Aurora",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1257,
                    CountryId = 176,
                    Name = "Basilan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1258,
                    CountryId = 176,
                    Name = "Bataan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 1259,
                    CountryId = 176,
                    Name = "Batanes",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1260,
                    CountryId = 176,
                    Name = "Batangas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1261,
                    CountryId = 176,
                    Name = "Benguet",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 1262,
                    CountryId = 176,
                    Name = "Biliran",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 1263,
                    CountryId = 176,
                    Name = "Bohol",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 1264,
                    CountryId = 176,
                    Name = "Bukidnon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 1265,
                    CountryId = 176,
                    Name = "Bulacan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 1266,
                    CountryId = 176,
                    Name = "Cagayan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 1267,
                    CountryId = 176,
                    Name = "Camarines Norte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 1268,
                    CountryId = 176,
                    Name = "Camarines Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1269,
                    CountryId = 176,
                    Name = "Camiguin",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 1270,
                    CountryId = 176,
                    Name = "Capiz",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 1271,
                    CountryId = 176,
                    Name = "Catanduanes",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 1272,
                    CountryId = 176,
                    Name = "Cavite",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 1273,
                    CountryId = 176,
                    Name = "Cebu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 1274,
                    CountryId = 176,
                    Name = "Compostela Valley",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 1275,
                    CountryId = 176,
                    Name = "Cotabato",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 1276,
                    CountryId = 176,
                    Name = "Davao del Norte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 28
                },

                new StateProvince()
                {
                    Id = 1277,
                    CountryId = 176,
                    Name = "Davao del Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 29
                },

                new StateProvince()
                {
                    Id = 1278,
                    CountryId = 176,
                    Name = "Davao Occidental",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 30
                },

                new StateProvince()
                {
                    Id = 1279,
                    CountryId = 176,
                    Name = "Davao Oriental",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 31
                },

                new StateProvince()
                {
                    Id = 1280,
                    CountryId = 176,
                    Name = "Dinagat Islands",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 32
                },

                new StateProvince()
                {
                    Id = 1281,
                    CountryId = 176,
                    Name = "Eastern Samar",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 33
                },

                new StateProvince()
                {
                    Id = 1282,
                    CountryId = 176,
                    Name = "Guimaras",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 34
                },

                new StateProvince()
                {
                    Id = 1283,
                    CountryId = 176,
                    Name = "Ifugao",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 35
                },

                new StateProvince()
                {
                    Id = 1284,
                    CountryId = 176,
                    Name = "Ilocos Norte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 36
                },

                new StateProvince()
                {
                    Id = 1285,
                    CountryId = 176,
                    Name = "Ilocos Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 37
                },

                new StateProvince()
                {
                    Id = 1286,
                    CountryId = 176,
                    Name = "Iloilo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 38
                },

                new StateProvince()
                {
                    Id = 1287,
                    CountryId = 176,
                    Name = "Isabela",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 39
                },

                new StateProvince()
                {
                    Id = 1288,
                    CountryId = 176,
                    Name = "Kalinga",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 40
                },

                new StateProvince()
                {
                    Id = 1289,
                    CountryId = 176,
                    Name = "La Union",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 41
                },

                new StateProvince()
                {
                    Id = 1290,
                    CountryId = 176,
                    Name = "Laguna",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 42
                },

                new StateProvince()
                {
                    Id = 1291,
                    CountryId = 176,
                    Name = "Lanao del Norte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 43
                },

                new StateProvince()
                {
                    Id = 1292,
                    CountryId = 176,
                    Name = "Lanao del Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 44
                },

                new StateProvince()
                {
                    Id = 1293,
                    CountryId = 176,
                    Name = "Leyte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 45
                },

                new StateProvince()
                {
                    Id = 1294,
                    CountryId = 176,
                    Name = "Maguindanao",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 46
                },

                new StateProvince()
                {
                    Id = 1295,
                    CountryId = 176,
                    Name = "Marinduque",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 47
                },

                new StateProvince()
                {
                    Id = 1296,
                    CountryId = 176,
                    Name = "Masbate",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 48
                },

                new StateProvince()
                {
                    Id = 1297,
                    CountryId = 176,
                    Name = "Misamis Occidental",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 49
                },

                new StateProvince()
                {
                    Id = 1298,
                    CountryId = 176,
                    Name = "Misamis Oriental",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 50
                },

                new StateProvince()
                {
                    Id = 1299,
                    CountryId = 176,
                    Name = "Mountain Province",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 51
                },

                new StateProvince()
                {
                    Id = 1300,
                    CountryId = 176,
                    Name = "Negros Occidental",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 52
                },

                new StateProvince()
                {
                    Id = 1301,
                    CountryId = 176,
                    Name = "Negros Oriental",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 53
                },

                new StateProvince()
                {
                    Id = 1302,
                    CountryId = 176,
                    Name = "Northern Samar",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 54
                },

                new StateProvince()
                {
                    Id = 1303,
                    CountryId = 176,
                    Name = "Nueva Ecija",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 55
                },

                new StateProvince()
                {
                    Id = 1304,
                    CountryId = 176,
                    Name = "Nueva Vizcaya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 56
                },

                new StateProvince()
                {
                    Id = 1305,
                    CountryId = 176,
                    Name = "Occidental Mindoro",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 57
                },

                new StateProvince()
                {
                    Id = 1306,
                    CountryId = 176,
                    Name = "Oriental Mindoro",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 58
                },

                new StateProvince()
                {
                    Id = 1307,
                    CountryId = 176,
                    Name = "Palawan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 59
                },

                new StateProvince()
                {
                    Id = 1308,
                    CountryId = 176,
                    Name = "Pampanga",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 60
                },

                new StateProvince()
                {
                    Id = 1309,
                    CountryId = 176,
                    Name = "Pangasinan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 61
                },

                new StateProvince()
                {
                    Id = 1310,
                    CountryId = 176,
                    Name = "Quezon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 62
                },

                new StateProvince()
                {
                    Id = 1311,
                    CountryId = 176,
                    Name = "Quirino",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 63
                },

                new StateProvince()
                {
                    Id = 1312,
                    CountryId = 176,
                    Name = "Rizal",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 64
                },

                new StateProvince()
                {
                    Id = 1313,
                    CountryId = 176,
                    Name = "Romblon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 65
                },

                new StateProvince()
                {
                    Id = 1314,
                    CountryId = 176,
                    Name = "Samar",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 66
                },

                new StateProvince()
                {
                    Id = 1315,
                    CountryId = 176,
                    Name = "Sarangani",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 67
                },

                new StateProvince()
                {
                    Id = 1316,
                    CountryId = 176,
                    Name = "Siquijor",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 68
                },

                new StateProvince()
                {
                    Id = 1317,
                    CountryId = 176,
                    Name = "Sorsogon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 69
                },

                new StateProvince()
                {
                    Id = 1318,
                    CountryId = 176,
                    Name = "South Cotabato",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 70
                },

                new StateProvince()
                {
                    Id = 1319,
                    CountryId = 176,
                    Name = "Southern Leyte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 71
                },

                new StateProvince()
                {
                    Id = 1320,
                    CountryId = 176,
                    Name = "Sultan Kudarat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 72
                },

                new StateProvince()
                {
                    Id = 1321,
                    CountryId = 176,
                    Name = "Sulu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 73
                },

                new StateProvince()
                {
                    Id = 1322,
                    CountryId = 176,
                    Name = "Surigao del Norte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 74
                },

                new StateProvince()
                {
                    Id = 1323,
                    CountryId = 176,
                    Name = "Surigao del Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 75
                },

                new StateProvince()
                {
                    Id = 1324,
                    CountryId = 176,
                    Name = "Tarlac",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 76
                },

                new StateProvince()
                {
                    Id = 1325,
                    CountryId = 176,
                    Name = "Tawi-Tawi",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 77
                },

                new StateProvince()
                {
                    Id = 1326,
                    CountryId = 176,
                    Name = "Zambales",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 78
                },

                new StateProvince()
                {
                    Id = 1327,
                    CountryId = 176,
                    Name = "Zamboanga del Norte",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 79
                },

                new StateProvince()
                {
                    Id = 1328,
                    CountryId = 176,
                    Name = "Zamboanga del Sur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 80
                },

                new StateProvince()
                {
                    Id = 1329,
                    CountryId = 176,
                    Name = "Zamboanga Sibugay",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 81
                },

                new StateProvince()
                {
                    Id = 1330,
                    CountryId = 176,
                    Name = "Metro Manila",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 82
                },

                new StateProvince()
                {
                    Id = 1339,
                    CountryId = 178,
                    Name = "Dolnośląskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1340,
                    CountryId = 178,
                    Name = "Kujawsko-pomorskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1341,
                    CountryId = 178,
                    Name = "Lubelskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1342,
                    CountryId = 178,
                    Name = "Lubuskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1343,
                    CountryId = 178,
                    Name = "Łódzkie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1344,
                    CountryId = 178,
                    Name = "Małopolskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1345,
                    CountryId = 178,
                    Name = "Mazowieckie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1346,
                    CountryId = 178,
                    Name = "Opolskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1347,
                    CountryId = 178,
                    Name = "Podkarpackie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1348,
                    CountryId = 178,
                    Name = "Podlaskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1349,
                    CountryId = 178,
                    Name = "Pomorskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1350,
                    CountryId = 178,
                    Name = "Śląskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1351,
                    CountryId = 178,
                    Name = "Świętokrzyskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1352,
                    CountryId = 178,
                    Name = "Warmińsko-mazurskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1353,
                    CountryId = 178,
                    Name = "Wielkopolskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1354,
                    CountryId = 178,
                    Name = "Zachodniopomorskie",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1355,
                    CountryId = 179,
                    Name = "Aveiro",
                    Abbreviation = "01",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1356,
                    CountryId = 179,
                    Name = "Beja",
                    Abbreviation = "02",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1357,
                    CountryId = 179,
                    Name = "Braga",
                    Abbreviation = "03",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1358,
                    CountryId = 179,
                    Name = "Bragança",
                    Abbreviation = "04",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1359,
                    CountryId = 179,
                    Name = "Castelo Branco",
                    Abbreviation = "05",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1360,
                    CountryId = 179,
                    Name = "Coimbra",
                    Abbreviation = "06",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1361,
                    CountryId = 179,
                    Name = "Évora",
                    Abbreviation = "07",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1362,
                    CountryId = 179,
                    Name = "Faro",
                    Abbreviation = "08",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1363,
                    CountryId = 179,
                    Name = "Guarda",
                    Abbreviation = "09",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1364,
                    CountryId = 179,
                    Name = "Leiria",
                    Abbreviation = "10",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 1365,
                    CountryId = 179,
                    Name = "Lisboa",
                    Abbreviation = "11",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1366,
                    CountryId = 179,
                    Name = "Portalegre",
                    Abbreviation = "12",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1367,
                    CountryId = 179,
                    Name = "Porto",
                    Abbreviation = "13",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 1368,
                    CountryId = 179,
                    Name = "Santarém",
                    Abbreviation = "14",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 1369,
                    CountryId = 179,
                    Name = "Setúbal",
                    Abbreviation = "15",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 1370,
                    CountryId = 179,
                    Name = "Viana do Castelo",
                    Abbreviation = "16",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 1371,
                    CountryId = 179,
                    Name = "Vila Real",
                    Abbreviation = "17",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 1372,
                    CountryId = 179,
                    Name = "Viseu",
                    Abbreviation = "18",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 1373,
                    CountryId = 179,
                    Name = "Região Autónoma dos Açores",
                    Abbreviation = "20",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 1374,
                    CountryId = 179,
                    Name = "Região Autónoma da Madeira",
                    Abbreviation = "30",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1375,
                    CountryId = 183,
                    Name = "Alba",
                    Abbreviation = "AB",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1376,
                    CountryId = 183,
                    Name = "Arad",
                    Abbreviation = "AR",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1377,
                    CountryId = 183,
                    Name = "Argeș",
                    Abbreviation = "AG",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1378,
                    CountryId = 183,
                    Name = "Bacău",
                    Abbreviation = "BC",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1379,
                    CountryId = 183,
                    Name = "Bihor",
                    Abbreviation = "BH",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1380,
                    CountryId = 183,
                    Name = "Bistrița-Năsăud",
                    Abbreviation = "BN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1381,
                    CountryId = 183,
                    Name = "Botoșani",
                    Abbreviation = "BT",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1382,
                    CountryId = 183,
                    Name = "Brașov",
                    Abbreviation = "BV",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1383,
                    CountryId = 183,
                    Name = "Brăila",
                    Abbreviation = "BR",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1384,
                    CountryId = 183,
                    Name = "București Sector 1",
                    Abbreviation = "B",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 1385,
                    CountryId = 183,
                    Name = "București Sector 2",
                    Abbreviation = "B",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1386,
                    CountryId = 183,
                    Name = "București Sector 3",
                    Abbreviation = "B",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1387,
                    CountryId = 183,
                    Name = "București Sector 4",
                    Abbreviation = "B",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 1388,
                    CountryId = 183,
                    Name = "București Sector 5",
                    Abbreviation = "B",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 1389,
                    CountryId = 183,
                    Name = "București Sector 6",
                    Abbreviation = "B",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 1390,
                    CountryId = 183,
                    Name = "Buzău",
                    Abbreviation = "BZ",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 1391,
                    CountryId = 183,
                    Name = "Caraș-Severin",
                    Abbreviation = "CS",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 1392,
                    CountryId = 183,
                    Name = "Călărași",
                    Abbreviation = "CL",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 1393,
                    CountryId = 183,
                    Name = "Cluj",
                    Abbreviation = "CJ",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 1394,
                    CountryId = 183,
                    Name = "Constanța",
                    Abbreviation = "CT",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1395,
                    CountryId = 183,
                    Name = "Covasna",
                    Abbreviation = "CV",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 1396,
                    CountryId = 183,
                    Name = "Dâmbovița",
                    Abbreviation = "DB",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 1397,
                    CountryId = 183,
                    Name = "Dolj",
                    Abbreviation = "DJ",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 1398,
                    CountryId = 183,
                    Name = "Galați",
                    Abbreviation = "GL",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 1399,
                    CountryId = 183,
                    Name = "Giurgiu",
                    Abbreviation = "GR",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 1400,
                    CountryId = 183,
                    Name = "Gorj",
                    Abbreviation = "GJ",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 1401,
                    CountryId = 183,
                    Name = "Harghita",
                    Abbreviation = "HR",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 1402,
                    CountryId = 183,
                    Name = "Hunedoara",
                    Abbreviation = "HD",
                    Published = true,
                    DisplayOrder = 28
                },

                new StateProvince()
                {
                    Id = 1403,
                    CountryId = 183,
                    Name = "Ialomița",
                    Abbreviation = "IL",
                    Published = true,
                    DisplayOrder = 29
                },

                new StateProvince()
                {
                    Id = 1404,
                    CountryId = 183,
                    Name = "Iași",
                    Abbreviation = "IS",
                    Published = true,
                    DisplayOrder = 30
                },

                new StateProvince()
                {
                    Id = 1405,
                    CountryId = 183,
                    Name = "Ilfov",
                    Abbreviation = "IF",
                    Published = true,
                    DisplayOrder = 31
                },

                new StateProvince()
                {
                    Id = 1406,
                    CountryId = 183,
                    Name = "Maramureș",
                    Abbreviation = "MM",
                    Published = true,
                    DisplayOrder = 32
                },

                new StateProvince()
                {
                    Id = 1407,
                    CountryId = 183,
                    Name = "Mehedinți",
                    Abbreviation = "MH",
                    Published = true,
                    DisplayOrder = 33
                },

                new StateProvince()
                {
                    Id = 1408,
                    CountryId = 183,
                    Name = "Mureș",
                    Abbreviation = "MS",
                    Published = true,
                    DisplayOrder = 34
                },

                new StateProvince()
                {
                    Id = 1409,
                    CountryId = 183,
                    Name = "Neamț",
                    Abbreviation = "NT",
                    Published = true,
                    DisplayOrder = 35
                },

                new StateProvince()
                {
                    Id = 1410,
                    CountryId = 183,
                    Name = "Olt",
                    Abbreviation = "OT",
                    Published = true,
                    DisplayOrder = 36
                },

                new StateProvince()
                {
                    Id = 1411,
                    CountryId = 183,
                    Name = "Prahova",
                    Abbreviation = "PH",
                    Published = true,
                    DisplayOrder = 37
                },

                new StateProvince()
                {
                    Id = 1412,
                    CountryId = 183,
                    Name = "Satu Mare",
                    Abbreviation = "SM",
                    Published = true,
                    DisplayOrder = 38
                },

                new StateProvince()
                {
                    Id = 1413,
                    CountryId = 183,
                    Name = "Sălaj",
                    Abbreviation = "SJ",
                    Published = true,
                    DisplayOrder = 39
                },

                new StateProvince()
                {
                    Id = 1414,
                    CountryId = 183,
                    Name = "Sibiu",
                    Abbreviation = "SB",
                    Published = true,
                    DisplayOrder = 40
                },

                new StateProvince()
                {
                    Id = 1415,
                    CountryId = 183,
                    Name = "Suceava",
                    Abbreviation = "SV",
                    Published = true,
                    DisplayOrder = 41
                },

                new StateProvince()
                {
                    Id = 1416,
                    CountryId = 183,
                    Name = "Teleorman",
                    Abbreviation = "TR",
                    Published = true,
                    DisplayOrder = 42
                },

                new StateProvince()
                {
                    Id = 1417,
                    CountryId = 183,
                    Name = "Timiș",
                    Abbreviation = "TM",
                    Published = true,
                    DisplayOrder = 43
                },

                new StateProvince()
                {
                    Id = 1418,
                    CountryId = 183,
                    Name = "Tulcea",
                    Abbreviation = "TL",
                    Published = true,
                    DisplayOrder = 44
                },

                new StateProvince()
                {
                    Id = 1419,
                    CountryId = 183,
                    Name = "Vaslui",
                    Abbreviation = "VS",
                    Published = true,
                    DisplayOrder = 45
                },

                new StateProvince()
                {
                    Id = 1420,
                    CountryId = 183,
                    Name = "Vâlcea",
                    Abbreviation = "VL",
                    Published = true,
                    DisplayOrder = 46
                },

                new StateProvince()
                {
                    Id = 1421,
                    CountryId = 183,
                    Name = "Vrancea",
                    Abbreviation = "VN",
                    Published = true,
                    DisplayOrder = 47
                },

                new StateProvince()
                {
                    Id = 1425,
                    CountryId = 184,
                    Name = "Адыгея",
                    Abbreviation = "01",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1426,
                    CountryId = 184,
                    Name = "Алтай",
                    Abbreviation = "04",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1427,
                    CountryId = 184,
                    Name = "Алтайский край",
                    Abbreviation = "22",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1428,
                    CountryId = 184,
                    Name = "Амурская область",
                    Abbreviation = "28",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1429,
                    CountryId = 184,
                    Name = "Архангельская область",
                    Abbreviation = "29",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1430,
                    CountryId = 184,
                    Name = "Астраханская область",
                    Abbreviation = "30",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1431,
                    CountryId = 184,
                    Name = "Башкортостан",
                    Abbreviation = "02",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1432,
                    CountryId = 184,
                    Name = "Белгородская область",
                    Abbreviation = "31",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1433,
                    CountryId = 184,
                    Name = "Брянская область",
                    Abbreviation = "32",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1434,
                    CountryId = 184,
                    Name = "Бурятия",
                    Abbreviation = "03",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1435,
                    CountryId = 184,
                    Name = "Владимирская область",
                    Abbreviation = "33",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1436,
                    CountryId = 184,
                    Name = "Волгоградская область",
                    Abbreviation = "34",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1437,
                    CountryId = 184,
                    Name = "Вологодская область",
                    Abbreviation = "35",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1438,
                    CountryId = 184,
                    Name = "Воронежская область",
                    Abbreviation = "36",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1439,
                    CountryId = 184,
                    Name = "Дагестан",
                    Abbreviation = "05",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1440,
                    CountryId = 184,
                    Name = "Еврейская автономная область",
                    Abbreviation = "79",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1441,
                    CountryId = 184,
                    Name = "Забайкальский край",
                    Abbreviation = "75",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1442,
                    CountryId = 184,
                    Name = "Ивановская область",
                    Abbreviation = "37",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1443,
                    CountryId = 184,
                    Name = "Ингушетия",
                    Abbreviation = "06",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1444,
                    CountryId = 184,
                    Name = "Иркутская область",
                    Abbreviation = "38",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1445,
                    CountryId = 184,
                    Name = "Кабардино-Балкарская Республика",
                    Abbreviation = "7",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1446,
                    CountryId = 184,
                    Name = "Калининградская область",
                    Abbreviation = "39",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1447,
                    CountryId = 184,
                    Name = "Калмыкия",
                    Abbreviation = "08",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1448,
                    CountryId = 184,
                    Name = "Калужская область",
                    Abbreviation = "40",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1449,
                    CountryId = 184,
                    Name = "Камчатский край",
                    Abbreviation = "41",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1450,
                    CountryId = 184,
                    Name = "Карачаево-Черкесская Республика",
                    Abbreviation = "09",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1451,
                    CountryId = 184,
                    Name = "Карелия",
                    Abbreviation = "10",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1452,
                    CountryId = 184,
                    Name = "Кемеровская область",
                    Abbreviation = "42",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1453,
                    CountryId = 184,
                    Name = "Кировская область",
                    Abbreviation = "43",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1454,
                    CountryId = 184,
                    Name = "Коми",
                    Abbreviation = "11",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1455,
                    CountryId = 184,
                    Name = "Костромская область",
                    Abbreviation = "44",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1456,
                    CountryId = 184,
                    Name = "Краснодарский край",
                    Abbreviation = "23",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1457,
                    CountryId = 184,
                    Name = "Красноярский край",
                    Abbreviation = "24",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1458,
                    CountryId = 184,
                    Name = "Курганская область",
                    Abbreviation = "45",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1459,
                    CountryId = 184,
                    Name = "Курская область",
                    Abbreviation = "46",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1460,
                    CountryId = 184,
                    Name = "Ленинградская область",
                    Abbreviation = "47",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1461,
                    CountryId = 184,
                    Name = "Липецкая область",
                    Abbreviation = "48",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1462,
                    CountryId = 184,
                    Name = "Магаданская область",
                    Abbreviation = "49",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1463,
                    CountryId = 184,
                    Name = "Марий Эл",
                    Abbreviation = "12",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1464,
                    CountryId = 184,
                    Name = "Мордовия",
                    Abbreviation = "13",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1465,
                    CountryId = 184,
                    Name = "Москва",
                    Abbreviation = "77",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1466,
                    CountryId = 184,
                    Name = "Московская область",
                    Abbreviation = "50",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1467,
                    CountryId = 184,
                    Name = "Мурманская область",
                    Abbreviation = "51",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1468,
                    CountryId = 184,
                    Name = "Ненецкий автономный округ",
                    Abbreviation = "83",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1469,
                    CountryId = 184,
                    Name = "Нижегородская область",
                    Abbreviation = "52",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1470,
                    CountryId = 184,
                    Name = "Новгородская область",
                    Abbreviation = "53",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1471,
                    CountryId = 184,
                    Name = "Новосибирская область",
                    Abbreviation = "54",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1472,
                    CountryId = 184,
                    Name = "Омская область",
                    Abbreviation = "55",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1473,
                    CountryId = 184,
                    Name = "Оренбургская область",
                    Abbreviation = "56",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1474,
                    CountryId = 184,
                    Name = "Орловская область",
                    Abbreviation = "57",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1475,
                    CountryId = 184,
                    Name = "Пензенская область",
                    Abbreviation = "58",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1476,
                    CountryId = 184,
                    Name = "Пермский край",
                    Abbreviation = "59",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1477,
                    CountryId = 184,
                    Name = "Приморский край",
                    Abbreviation = "25",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1478,
                    CountryId = 184,
                    Name = "Псковская область",
                    Abbreviation = "60",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1479,
                    CountryId = 184,
                    Name = "Ростовская область",
                    Abbreviation = "61",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1480,
                    CountryId = 184,
                    Name = "Рязанская область",
                    Abbreviation = "62",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1481,
                    CountryId = 184,
                    Name = "Самарская область",
                    Abbreviation = "63",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1482,
                    CountryId = 184,
                    Name = "Санкт-Петербург",
                    Abbreviation = "78",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1483,
                    CountryId = 184,
                    Name = "Саратовская область",
                    Abbreviation = "64",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1484,
                    CountryId = 184,
                    Name = "Саха (Якутия)",
                    Abbreviation = "14",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1485,
                    CountryId = 184,
                    Name = "Сахалинская область",
                    Abbreviation = "65",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1486,
                    CountryId = 184,
                    Name = "Свердловская область",
                    Abbreviation = "66",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1487,
                    CountryId = 184,
                    Name = "Севастополь",
                    Abbreviation = "92",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1488,
                    CountryId = 184,
                    Name = "Северная Осетия-Алания",
                    Abbreviation = "15",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1489,
                    CountryId = 184,
                    Name = "Смоленская область",
                    Abbreviation = "67",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1490,
                    CountryId = 184,
                    Name = "Ставропольский край",
                    Abbreviation = "26",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1491,
                    CountryId = 184,
                    Name = "Тамбовская область",
                    Abbreviation = "68",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1492,
                    CountryId = 184,
                    Name = "Татарстан",
                    Abbreviation = "16",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1493,
                    CountryId = 184,
                    Name = "Тверская область",
                    Abbreviation = "69",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1494,
                    CountryId = 184,
                    Name = "Томская область",
                    Abbreviation = "70",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1495,
                    CountryId = 184,
                    Name = "Тульская область",
                    Abbreviation = "71",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1496,
                    CountryId = 184,
                    Name = "Тыва",
                    Abbreviation = "17",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1497,
                    CountryId = 184,
                    Name = "Тюменская область",
                    Abbreviation = "72",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1498,
                    CountryId = 184,
                    Name = "Удмуртская Республика",
                    Abbreviation = "18",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1499,
                    CountryId = 184,
                    Name = "Ульяновская область",
                    Abbreviation = "73",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1500,
                    CountryId = 184,
                    Name = "Хабаровский край",
                    Abbreviation = "27",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1501,
                    CountryId = 184,
                    Name = "Хакасия",
                    Abbreviation = "19",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1502,
                    CountryId = 184,
                    Name = "Ханты-Мансийский автономный округ-Югра",
                    Abbreviation = "86",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1503,
                    CountryId = 184,
                    Name = "Челябинская область",
                    Abbreviation = "74",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1504,
                    CountryId = 184,
                    Name = "Чеченская Республика",
                    Abbreviation = "95",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1505,
                    CountryId = 184,
                    Name = "Чувашская Республика",
                    Abbreviation = "21",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1506,
                    CountryId = 184,
                    Name = "Чукотский автономный округ",
                    Abbreviation = "87",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1507,
                    CountryId = 184,
                    Name = "Ямало-Ненецкий автономный округ",
                    Abbreviation = "89",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1508,
                    CountryId = 184,
                    Name = "Ярославская область",
                    Abbreviation = "76",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1509,
                    CountryId = 196,
                    Name = "Eastern Cape",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1510,
                    CountryId = 196,
                    Name = "Al Bahah",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1511,
                    CountryId = 196,
                    Name = "Al Jawf",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1512,
                    CountryId = 196,
                    Name = "Al Madinah",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1513,
                    CountryId = 196,
                    Name = "Al Qasim",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1514,
                    CountryId = 196,
                    Name = "Al Riyadh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1515,
                    CountryId = 196,
                    Name = "Asir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1516,
                    CountryId = 196,
                    Name = "Eastern Province",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1517,
                    CountryId = 196,
                    Name = "Ha'il",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1518,
                    CountryId = 196,
                    Name = "Jizan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1519,
                    CountryId = 196,
                    Name = "Makkah",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 1520,
                    CountryId = 196,
                    Name = "Najran",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1521,
                    CountryId = 196,
                    Name = "Northern Borders",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1522,
                    CountryId = 196,
                    Name = "Tabuk",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 1422,
                    CountryId = 198,
                    Name = "Serbia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1423,
                    CountryId = 198,
                    Name = "Kosovo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1424,
                    CountryId = 198,
                    Name = "Vojvodina",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1556,
                    CountryId = 203,
                    Name = "Bratislavský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1557,
                    CountryId = 203,
                    Name = "Trnavský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1558,
                    CountryId = 203,
                    Name = "Nitrianský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1559,
                    CountryId = 203,
                    Name = "Trenčianský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1560,
                    CountryId = 203,
                    Name = "Žilinský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1561,
                    CountryId = 203,
                    Name = "Banskobystrický kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1562,
                    CountryId = 203,
                    Name = "Košický kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1563,
                    CountryId = 203,
                    Name = "Prešovský kraj",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1544,
                    CountryId = 204,
                    Name = "Pomurska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1545,
                    CountryId = 204,
                    Name = "Podravska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1546,
                    CountryId = 204,
                    Name = "Koroška",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1547,
                    CountryId = 204,
                    Name = "Savinjska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1548,
                    CountryId = 204,
                    Name = "Zasavska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1549,
                    CountryId = 204,
                    Name = "Posavska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1550,
                    CountryId = 204,
                    Name = "Jugovzhodna Slovenija",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1551,
                    CountryId = 204,
                    Name = "Primorsko-notranjska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1552,
                    CountryId = 204,
                    Name = "Osrednjeslovenska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1553,
                    CountryId = 204,
                    Name = "Gorenjska",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1554,
                    CountryId = 204,
                    Name = "Goriška",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1555,
                    CountryId = 204,
                    Name = "Obalno-kraška",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1818,
                    CountryId = 207,
                    Name = "Eastern Cape",
                    Abbreviation = "EC",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1819,
                    CountryId = 207,
                    Name = "Free State",
                    Abbreviation = "FS",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1820,
                    CountryId = 207,
                    Name = "Gauteng",
                    Abbreviation = "GP",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1821,
                    CountryId = 207,
                    Name = "KwaZulu-Natal",
                    Abbreviation = "KZN",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1822,
                    CountryId = 207,
                    Name = "Limpopo",
                    Abbreviation = "LP",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1823,
                    CountryId = 207,
                    Name = "Mpumalanga",
                    Abbreviation = "MP",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1824,
                    CountryId = 207,
                    Name = "Northern Cape",
                    Abbreviation = "NC",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1825,
                    CountryId = 207,
                    Name = "North West",
                    Abbreviation = "NW",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1826,
                    CountryId = 207,
                    Name = "Western Cape",
                    Abbreviation = "WC",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 404,
                    CountryId = 210,
                    Name = "Álava",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 405,
                    CountryId = 210,
                    Name = "Albacete",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 406,
                    CountryId = 210,
                    Name = "Alicante",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 407,
                    CountryId = 210,
                    Name = "Almería",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 408,
                    CountryId = 210,
                    Name = "Ávila",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 409,
                    CountryId = 210,
                    Name = "Badajoz",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 410,
                    CountryId = 210,
                    Name = "Baleares (Illes)",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 411,
                    CountryId = 210,
                    Name = "Barcelona",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 412,
                    CountryId = 210,
                    Name = "Burgos",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 413,
                    CountryId = 210,
                    Name = "Cáceres",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 414,
                    CountryId = 210,
                    Name = "Cádiz",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 415,
                    CountryId = 210,
                    Name = "Castellón",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 416,
                    CountryId = 210,
                    Name = "Ciudad Real",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 417,
                    CountryId = 210,
                    Name = "Córdoba",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 418,
                    CountryId = 210,
                    Name = "A Coruña",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 419,
                    CountryId = 210,
                    Name = "Cuenca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 420,
                    CountryId = 210,
                    Name = "Girona",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 421,
                    CountryId = 210,
                    Name = "Granada",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 422,
                    CountryId = 210,
                    Name = "Guadalajara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 423,
                    CountryId = 210,
                    Name = "Guipúzcoa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 424,
                    CountryId = 210,
                    Name = "Huelva",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 425,
                    CountryId = 210,
                    Name = "Huesca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 426,
                    CountryId = 210,
                    Name = "Jaén",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 427,
                    CountryId = 210,
                    Name = "León",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 428,
                    CountryId = 210,
                    Name = "Lleida",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 429,
                    CountryId = 210,
                    Name = "La Rioja",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 26
                },

                new StateProvince()
                {
                    Id = 430,
                    CountryId = 210,
                    Name = "Lugo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 27
                },

                new StateProvince()
                {
                    Id = 431,
                    CountryId = 210,
                    Name = "Madrid",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 28
                },

                new StateProvince()
                {
                    Id = 432,
                    CountryId = 210,
                    Name = "Málaga",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 29
                },

                new StateProvince()
                {
                    Id = 433,
                    CountryId = 210,
                    Name = "Murcia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 30
                },

                new StateProvince()
                {
                    Id = 434,
                    CountryId = 210,
                    Name = "Navarra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 31
                },

                new StateProvince()
                {
                    Id = 435,
                    CountryId = 210,
                    Name = "Ourense",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 32
                },

                new StateProvince()
                {
                    Id = 436,
                    CountryId = 210,
                    Name = "Asturias",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 33
                },

                new StateProvince()
                {
                    Id = 437,
                    CountryId = 210,
                    Name = "Palencia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 34
                },

                new StateProvince()
                {
                    Id = 438,
                    CountryId = 210,
                    Name = "Las Palmas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 35
                },

                new StateProvince()
                {
                    Id = 439,
                    CountryId = 210,
                    Name = "Pontevedra",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 36
                },

                new StateProvince()
                {
                    Id = 440,
                    CountryId = 210,
                    Name = "Salamanca",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 37
                },

                new StateProvince()
                {
                    Id = 441,
                    CountryId = 210,
                    Name = "Santa Cruz de Tenerife",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 38
                },

                new StateProvince()
                {
                    Id = 442,
                    CountryId = 210,
                    Name = "Cantabria",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 39
                },

                new StateProvince()
                {
                    Id = 443,
                    CountryId = 210,
                    Name = "Segovia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 40
                },

                new StateProvince()
                {
                    Id = 444,
                    CountryId = 210,
                    Name = "Sevilla",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 41
                },

                new StateProvince()
                {
                    Id = 445,
                    CountryId = 210,
                    Name = "Soria",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 42
                },

                new StateProvince()
                {
                    Id = 446,
                    CountryId = 210,
                    Name = "Tarragona",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 43
                },

                new StateProvince()
                {
                    Id = 447,
                    CountryId = 210,
                    Name = "Teruel",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 44
                },

                new StateProvince()
                {
                    Id = 448,
                    CountryId = 210,
                    Name = "Toledo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 45
                },

                new StateProvince()
                {
                    Id = 449,
                    CountryId = 210,
                    Name = "Valencia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 46
                },

                new StateProvince()
                {
                    Id = 450,
                    CountryId = 210,
                    Name = "Valladolid",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 47
                },

                new StateProvince()
                {
                    Id = 451,
                    CountryId = 210,
                    Name = "Vizcaya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 48
                },

                new StateProvince()
                {
                    Id = 452,
                    CountryId = 210,
                    Name = "Zamora",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 49
                },

                new StateProvince()
                {
                    Id = 453,
                    CountryId = 210,
                    Name = "Zaragoza",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 50
                },

                new StateProvince()
                {
                    Id = 454,
                    CountryId = 210,
                    Name = "Ceuta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 51
                },

                new StateProvince()
                {
                    Id = 455,
                    CountryId = 210,
                    Name = "Melilla",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 52
                },

                new StateProvince()
                {
                    Id = 1523,
                    CountryId = 215,
                    Name = "Stockholms län",
                    Abbreviation = "01",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1524,
                    CountryId = 215,
                    Name = "Uppsala län",
                    Abbreviation = "03",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1525,
                    CountryId = 215,
                    Name = "Södermanlands län",
                    Abbreviation = "04",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1526,
                    CountryId = 215,
                    Name = "Östergötlands län",
                    Abbreviation = "05",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1527,
                    CountryId = 215,
                    Name = "Jönköpings län",
                    Abbreviation = "06",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1528,
                    CountryId = 215,
                    Name = "Kronobergs län",
                    Abbreviation = "07",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1529,
                    CountryId = 215,
                    Name = "Kalmar län",
                    Abbreviation = "08",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1530,
                    CountryId = 215,
                    Name = "Gotlands län",
                    Abbreviation = "09",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1531,
                    CountryId = 215,
                    Name = "Blekinge län",
                    Abbreviation = "11",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1532,
                    CountryId = 215,
                    Name = "Skåne län",
                    Abbreviation = "12",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1533,
                    CountryId = 215,
                    Name = "Hallands län",
                    Abbreviation = "14",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 1534,
                    CountryId = 215,
                    Name = "Västra Götalands län",
                    Abbreviation = "15",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 1535,
                    CountryId = 215,
                    Name = "Värmlands län",
                    Abbreviation = "17",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 1536,
                    CountryId = 215,
                    Name = "Örebro län",
                    Abbreviation = "18",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 1537,
                    CountryId = 215,
                    Name = "Västmanlands län",
                    Abbreviation = "19",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 1538,
                    CountryId = 215,
                    Name = "Dalarnas län",
                    Abbreviation = "20",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1539,
                    CountryId = 215,
                    Name = "Gävleborgs län",
                    Abbreviation = "21",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 1540,
                    CountryId = 215,
                    Name = "Jämtlands län",
                    Abbreviation = "22",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 1541,
                    CountryId = 215,
                    Name = "Västernorrlands län",
                    Abbreviation = "23",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 1542,
                    CountryId = 215,
                    Name = "Västerbottens län",
                    Abbreviation = "24",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 1543,
                    CountryId = 215,
                    Name = "Norbottens län",
                    Abbreviation = "25",
                    Published = true,
                    DisplayOrder = 25
                },

                new StateProvince()
                {
                    Id = 206,
                    CountryId = 216,
                    Name = "Aargau",
                    Abbreviation = "AG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 207,
                    CountryId = 216,
                    Name = "Appenzell Ausserrhoden",
                    Abbreviation = "AR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 208,
                    CountryId = 216,
                    Name = "Appenzell Innerrhoden",
                    Abbreviation = "AI",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 209,
                    CountryId = 216,
                    Name = "Basel-Landschaft",
                    Abbreviation = "BL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 210,
                    CountryId = 216,
                    Name = "Basel-Stadt",
                    Abbreviation = "BS",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 211,
                    CountryId = 216,
                    Name = "Bern",
                    Abbreviation = "BE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 212,
                    CountryId = 216,
                    Name = "Fribourg/Freiburg",
                    Abbreviation = "FR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 213,
                    CountryId = 216,
                    Name = "Genève",
                    Abbreviation = "GE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 214,
                    CountryId = 216,
                    Name = "Glarus",
                    Abbreviation = "GL",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 215,
                    CountryId = 216,
                    Name = "Graubünden/Grischun",
                    Abbreviation = "GR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 216,
                    CountryId = 216,
                    Name = "Jura",
                    Abbreviation = "JU",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 217,
                    CountryId = 216,
                    Name = "Luzern",
                    Abbreviation = "LU",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 218,
                    CountryId = 216,
                    Name = "Neuchâtel",
                    Abbreviation = "NE",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 219,
                    CountryId = 216,
                    Name = "Nidwalden",
                    Abbreviation = "NW",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 220,
                    CountryId = 216,
                    Name = "Obwalden",
                    Abbreviation = "OW",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 221,
                    CountryId = 216,
                    Name = "Schaffhausen",
                    Abbreviation = "SH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 222,
                    CountryId = 216,
                    Name = "Schwyz",
                    Abbreviation = "SZ",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 223,
                    CountryId = 216,
                    Name = "Solothurn",
                    Abbreviation = "SO",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 224,
                    CountryId = 216,
                    Name = "St. Gallen",
                    Abbreviation = "SG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 225,
                    CountryId = 216,
                    Name = "Ticino",
                    Abbreviation = "TI",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 226,
                    CountryId = 216,
                    Name = "Thurgau",
                    Abbreviation = "TG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 227,
                    CountryId = 216,
                    Name = "Uri",
                    Abbreviation = "UR",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 228,
                    CountryId = 216,
                    Name = "Vaud",
                    Abbreviation = "VD",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 229,
                    CountryId = 216,
                    Name = "Valais/Wallis",
                    Abbreviation = "VS",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 230,
                    CountryId = 216,
                    Name = "Zug",
                    Abbreviation = "ZG",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 231,
                    CountryId = 216,
                    Name = "Zürich",
                    Abbreviation = "ZH",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1564,
                    CountryId = 228,
                    Name = "Adana",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1565,
                    CountryId = 228,
                    Name = "Adıyaman",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1566,
                    CountryId = 228,
                    Name = "Afyonkarahisar",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1567,
                    CountryId = 228,
                    Name = "Ağrı",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1568,
                    CountryId = 228,
                    Name = "Aksaray",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1569,
                    CountryId = 228,
                    Name = "Amasya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1570,
                    CountryId = 228,
                    Name = "Ankara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1571,
                    CountryId = 228,
                    Name = "Antalya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1572,
                    CountryId = 228,
                    Name = "Ardahan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1573,
                    CountryId = 228,
                    Name = "Artvin",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1574,
                    CountryId = 228,
                    Name = "Aydın",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1575,
                    CountryId = 228,
                    Name = "Balıkesir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1576,
                    CountryId = 228,
                    Name = "Bartın",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1577,
                    CountryId = 228,
                    Name = "Batman",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1578,
                    CountryId = 228,
                    Name = "Bayburt",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1579,
                    CountryId = 228,
                    Name = "Bilecik",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1580,
                    CountryId = 228,
                    Name = "Bingöl",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1581,
                    CountryId = 228,
                    Name = "Bitlis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1582,
                    CountryId = 228,
                    Name = "Bolu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1583,
                    CountryId = 228,
                    Name = "Burdur",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1584,
                    CountryId = 228,
                    Name = "Bursa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1585,
                    CountryId = 228,
                    Name = "Çanakkale",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1586,
                    CountryId = 228,
                    Name = "Çankırı",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1587,
                    CountryId = 228,
                    Name = "Çorum",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1588,
                    CountryId = 228,
                    Name = "Denizli",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1589,
                    CountryId = 228,
                    Name = "Diyarbakır",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1590,
                    CountryId = 228,
                    Name = "Düzce",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1591,
                    CountryId = 228,
                    Name = "Edirne",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1592,
                    CountryId = 228,
                    Name = "Elazığ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1593,
                    CountryId = 228,
                    Name = "Erzincan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1594,
                    CountryId = 228,
                    Name = "Erzurum",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1595,
                    CountryId = 228,
                    Name = "Eskişehir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1596,
                    CountryId = 228,
                    Name = "Gaziantep",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1597,
                    CountryId = 228,
                    Name = "Giresun",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1598,
                    CountryId = 228,
                    Name = "Gümüşhane",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1599,
                    CountryId = 228,
                    Name = "Hakkari",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1600,
                    CountryId = 228,
                    Name = "Hatay",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1601,
                    CountryId = 228,
                    Name = "Iğdır",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1602,
                    CountryId = 228,
                    Name = "Isparta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1603,
                    CountryId = 228,
                    Name = "İstanbul",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1604,
                    CountryId = 228,
                    Name = "İzmir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1605,
                    CountryId = 228,
                    Name = "Kahramanmaraş",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1606,
                    CountryId = 228,
                    Name = "Karabük",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1607,
                    CountryId = 228,
                    Name = "Karaman",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1608,
                    CountryId = 228,
                    Name = "Kars",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1609,
                    CountryId = 228,
                    Name = "Kastamonu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1610,
                    CountryId = 228,
                    Name = "Kayseri",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1611,
                    CountryId = 228,
                    Name = "Kırıkkale",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1612,
                    CountryId = 228,
                    Name = "Kırklareli",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1613,
                    CountryId = 228,
                    Name = "Kırşehir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1614,
                    CountryId = 228,
                    Name = "Kilis",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1615,
                    CountryId = 228,
                    Name = "Kocaeli",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1616,
                    CountryId = 228,
                    Name = "Konya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1617,
                    CountryId = 228,
                    Name = "Kütahya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1618,
                    CountryId = 228,
                    Name = "Malatya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1619,
                    CountryId = 228,
                    Name = "Manisa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1620,
                    CountryId = 228,
                    Name = "Mardin",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1621,
                    CountryId = 228,
                    Name = "Mersin",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1622,
                    CountryId = 228,
                    Name = "Muğla",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1623,
                    CountryId = 228,
                    Name = "Muş",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1624,
                    CountryId = 228,
                    Name = "Nevşehir",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1625,
                    CountryId = 228,
                    Name = "Niğde",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1626,
                    CountryId = 228,
                    Name = "Ordu",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1627,
                    CountryId = 228,
                    Name = "Osmaniye",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1628,
                    CountryId = 228,
                    Name = "Rize",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1629,
                    CountryId = 228,
                    Name = "Sakarya",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1630,
                    CountryId = 228,
                    Name = "Samsun",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1631,
                    CountryId = 228,
                    Name = "Siirt",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1632,
                    CountryId = 228,
                    Name = "Sinop",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1633,
                    CountryId = 228,
                    Name = "Sivas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1634,
                    CountryId = 228,
                    Name = "Şanlıurfa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1635,
                    CountryId = 228,
                    Name = "Şırnak",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1636,
                    CountryId = 228,
                    Name = "Tekirdağ",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1637,
                    CountryId = 228,
                    Name = "Tokat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1638,
                    CountryId = 228,
                    Name = "Trabzon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1639,
                    CountryId = 228,
                    Name = "Tunceli",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1640,
                    CountryId = 228,
                    Name = "Uşak",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1641,
                    CountryId = 228,
                    Name = "Van",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1642,
                    CountryId = 228,
                    Name = "Yalova",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1643,
                    CountryId = 228,
                    Name = "Yozgat",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1644,
                    CountryId = 228,
                    Name = "Zonguldak",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1645,
                    CountryId = 233,
                    Name = "Вінницька область",
                    Abbreviation = "Вінн. обл.",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1646,
                    CountryId = 233,
                    Name = "Волинська область",
                    Abbreviation = "Волин. обл.",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1647,
                    CountryId = 233,
                    Name = "Дніпропетровська область",
                    Abbreviation = "Дніпроп. обл.",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1648,
                    CountryId = 233,
                    Name = "Донецька область",
                    Abbreviation = "Донец. обл.",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1649,
                    CountryId = 233,
                    Name = "Житомирська область",
                    Abbreviation = "Житом. обл.",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1650,
                    CountryId = 233,
                    Name = "Закарпатська область",
                    Abbreviation = "Закарп. обл.",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1651,
                    CountryId = 233,
                    Name = "Запорізька область",
                    Abbreviation = "Запоріз. обл.",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1652,
                    CountryId = 233,
                    Name = "Івано-Франківська область",
                    Abbreviation = "Івано-Фр. обл.",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1653,
                    CountryId = 233,
                    Name = "Київська область",
                    Abbreviation = "Київ. обл.",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 1654,
                    CountryId = 233,
                    Name = "Кіровоградська область",
                    Abbreviation = "Кіровогр. обл.",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1655,
                    CountryId = 233,
                    Name = "Луганська область",
                    Abbreviation = "Луган. обл.",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1656,
                    CountryId = 233,
                    Name = "Львівська область",
                    Abbreviation = "Львів. обл.",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 1657,
                    CountryId = 233,
                    Name = "Миколаївська область",
                    Abbreviation = "Микол. обл.",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 1658,
                    CountryId = 233,
                    Name = "Одеська область",
                    Abbreviation = "Одес. обл.",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 1659,
                    CountryId = 233,
                    Name = "Полтавська область",
                    Abbreviation = "Полтав. обл.",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 1660,
                    CountryId = 233,
                    Name = "Рівненська область",
                    Abbreviation = "Рівн. обл.",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 1661,
                    CountryId = 233,
                    Name = "Сумська область",
                    Abbreviation = "Сумськ. обл.",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 1662,
                    CountryId = 233,
                    Name = "Тернопільська область",
                    Abbreviation = "Терноп. обл.",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 1663,
                    CountryId = 233,
                    Name = "Харківська область",
                    Abbreviation = "Харк. обл.",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1664,
                    CountryId = 233,
                    Name = "Херсонська область",
                    Abbreviation = "Херсон. обл.",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1665,
                    CountryId = 233,
                    Name = "Хмельницька область",
                    Abbreviation = "Хмельн. обл.",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 1666,
                    CountryId = 233,
                    Name = "Черкаська область",
                    Abbreviation = "Черкас. обл.",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 1667,
                    CountryId = 233,
                    Name = "Чернівецька область",
                    Abbreviation = "Чернів. обл.",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 1668,
                    CountryId = 233,
                    Name = "Чернігівська область",
                    Abbreviation = "Черніг. обл.",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 581,
                    CountryId = 235,
                    Name = "Aberdeenshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 582,
                    CountryId = 235,
                    Name = "Anglesey/Sir Fon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 583,
                    CountryId = 235,
                    Name = "Angus",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 584,
                    CountryId = 235,
                    Name = "Argyll and Bute",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 585,
                    CountryId = 235,
                    Name = "Ayrshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 586,
                    CountryId = 235,
                    Name = "Berkshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 587,
                    CountryId = 235,
                    Name = "Blaenau Gwent",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 588,
                    CountryId = 235,
                    Name = "Bridgend",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 589,
                    CountryId = 235,
                    Name = "Bristol",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 590,
                    CountryId = 235,
                    Name = "Buckinghamshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 591,
                    CountryId = 235,
                    Name = "Caerphilly",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 592,
                    CountryId = 235,
                    Name = "Cambridgeshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 593,
                    CountryId = 235,
                    Name = "Cardiff",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 594,
                    CountryId = 235,
                    Name = "Carmarthenshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 595,
                    CountryId = 235,
                    Name = "Ceredigion",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 596,
                    CountryId = 235,
                    Name = "Cheshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 597,
                    CountryId = 235,
                    Name = "Clackmannanshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 598,
                    CountryId = 235,
                    Name = "Conwy",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 599,
                    CountryId = 235,
                    Name = "Cornwall",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 600,
                    CountryId = 235,
                    Name = "County Antrim",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 601,
                    CountryId = 235,
                    Name = "County Armagh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 602,
                    CountryId = 235,
                    Name = "County Down",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 603,
                    CountryId = 235,
                    Name = "County Fermanagh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 604,
                    CountryId = 235,
                    Name = "County Londonderry",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 605,
                    CountryId = 235,
                    Name = "County Tyrone",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 606,
                    CountryId = 235,
                    Name = "Cumbria",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 607,
                    CountryId = 235,
                    Name = "Denbighshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 608,
                    CountryId = 235,
                    Name = "Derbyshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 609,
                    CountryId = 235,
                    Name = "Devon",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 610,
                    CountryId = 235,
                    Name = "Dorset",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 611,
                    CountryId = 235,
                    Name = "Dumfries and Galloway",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 612,
                    CountryId = 235,
                    Name = "Dunbartonshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 613,
                    CountryId = 235,
                    Name = "Dundee",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 614,
                    CountryId = 235,
                    Name = "Durham",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 615,
                    CountryId = 235,
                    Name = "East Lothian",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 616,
                    CountryId = 235,
                    Name = "East Riding of Yorkshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 617,
                    CountryId = 235,
                    Name = "East Sussex",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 618,
                    CountryId = 235,
                    Name = "Edinburgh",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 619,
                    CountryId = 235,
                    Name = "Essex",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 620,
                    CountryId = 235,
                    Name = "Falkirk",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 621,
                    CountryId = 235,
                    Name = "Fife",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 622,
                    CountryId = 235,
                    Name = "Flintshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 623,
                    CountryId = 235,
                    Name = "Glamorgan",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 624,
                    CountryId = 235,
                    Name = "Glasgow",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 625,
                    CountryId = 235,
                    Name = "Gloucestershire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 626,
                    CountryId = 235,
                    Name = "Greater Manchester",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 627,
                    CountryId = 235,
                    Name = "Gwynedd",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 628,
                    CountryId = 235,
                    Name = "Hampshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 629,
                    CountryId = 235,
                    Name = "Hereford and Worcester",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 630,
                    CountryId = 235,
                    Name = "Hertfordshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 631,
                    CountryId = 235,
                    Name = "Highland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 632,
                    CountryId = 235,
                    Name = "Inverclyde",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 633,
                    CountryId = 235,
                    Name = "Isle of Man",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 634,
                    CountryId = 235,
                    Name = "Isle of Wight",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 635,
                    CountryId = 235,
                    Name = "Kent",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 636,
                    CountryId = 235,
                    Name = "Lanarkshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 637,
                    CountryId = 235,
                    Name = "Lancashire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 638,
                    CountryId = 235,
                    Name = "Leicestershire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 639,
                    CountryId = 235,
                    Name = "Lincolnshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 640,
                    CountryId = 235,
                    Name = "London",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 641,
                    CountryId = 235,
                    Name = "Merseyside",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 642,
                    CountryId = 235,
                    Name = "Merthyr Tydfil",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 643,
                    CountryId = 235,
                    Name = "Middlesex",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 644,
                    CountryId = 235,
                    Name = "Midlothian",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 645,
                    CountryId = 235,
                    Name = "Monmouthshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 646,
                    CountryId = 235,
                    Name = "Moray",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 647,
                    CountryId = 235,
                    Name = "Neath Port Talbot",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 648,
                    CountryId = 235,
                    Name = "Newport",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 649,
                    CountryId = 235,
                    Name = "Norfolk",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 650,
                    CountryId = 235,
                    Name = "North Yorkshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 651,
                    CountryId = 235,
                    Name = "Northamptonshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 652,
                    CountryId = 235,
                    Name = "Northumberland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 653,
                    CountryId = 235,
                    Name = "Nottinghamshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 654,
                    CountryId = 235,
                    Name = "Orkney",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 655,
                    CountryId = 235,
                    Name = "Oxfordshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 656,
                    CountryId = 235,
                    Name = "Pembrokeshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 657,
                    CountryId = 235,
                    Name = "Perth and Kinross",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 658,
                    CountryId = 235,
                    Name = "Powys",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 659,
                    CountryId = 235,
                    Name = "Renfrewshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 660,
                    CountryId = 235,
                    Name = "Rhondda Cynon Taff",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 661,
                    CountryId = 235,
                    Name = "Rutland",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 662,
                    CountryId = 235,
                    Name = "Scottish Borders",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 663,
                    CountryId = 235,
                    Name = "Shetland Isles",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 664,
                    CountryId = 235,
                    Name = "Shropshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 665,
                    CountryId = 235,
                    Name = "Somerset",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 666,
                    CountryId = 235,
                    Name = "South Yorkshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 667,
                    CountryId = 235,
                    Name = "Staffordshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 668,
                    CountryId = 235,
                    Name = "Stirlingshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 669,
                    CountryId = 235,
                    Name = "Suffolk",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 670,
                    CountryId = 235,
                    Name = "Surrey",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 671,
                    CountryId = 235,
                    Name = "Swansea",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 672,
                    CountryId = 235,
                    Name = "Torfaen",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 673,
                    CountryId = 235,
                    Name = "Tyne and Wear",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 674,
                    CountryId = 235,
                    Name = "Warwickshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 675,
                    CountryId = 235,
                    Name = "West Lothian",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 676,
                    CountryId = 235,
                    Name = "West Midlands",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 677,
                    CountryId = 235,
                    Name = "West Sussex",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 678,
                    CountryId = 235,
                    Name = "West Yorkshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 679,
                    CountryId = 235,
                    Name = "Western Isles",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 680,
                    CountryId = 235,
                    Name = "Wiltshire",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 681,
                    CountryId = 235,
                    Name = "Wrexham",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1669,
                    CountryId = 237,
                    Name = "AA (Armed Forces Americas)",
                    Abbreviation = "AA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1670,
                    CountryId = 237,
                    Name = "AE (Armed Forces Europe)",
                    Abbreviation = "AE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1671,
                    CountryId = 237,
                    Name = "Alabama",
                    Abbreviation = "AL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1672,
                    CountryId = 237,
                    Name = "Alaska",
                    Abbreviation = "AK",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1673,
                    CountryId = 237,
                    Name = "American Samoa",
                    Abbreviation = "AS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1674,
                    CountryId = 237,
                    Name = "AP (Armed Forces Pacific)",
                    Abbreviation = "AP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1675,
                    CountryId = 237,
                    Name = "Arizona",
                    Abbreviation = "AZ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1676,
                    CountryId = 237,
                    Name = "Arkansas",
                    Abbreviation = "AR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1677,
                    CountryId = 237,
                    Name = "California",
                    Abbreviation = "CA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1678,
                    CountryId = 237,
                    Name = "Colorado",
                    Abbreviation = "CO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1679,
                    CountryId = 237,
                    Name = "Connecticut",
                    Abbreviation = "CT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1680,
                    CountryId = 237,
                    Name = "Delaware",
                    Abbreviation = "DE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1681,
                    CountryId = 237,
                    Name = "District of Columbia",
                    Abbreviation = "DC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1682,
                    CountryId = 237,
                    Name = "Federated States of Micronesia",
                    Abbreviation = "FM",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1683,
                    CountryId = 237,
                    Name = "Florida",
                    Abbreviation = "FL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1684,
                    CountryId = 237,
                    Name = "Georgia",
                    Abbreviation = "GA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1685,
                    CountryId = 237,
                    Name = "Guam",
                    Abbreviation = "GU",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1686,
                    CountryId = 237,
                    Name = "Hawaii",
                    Abbreviation = "HI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1687,
                    CountryId = 237,
                    Name = "Idaho",
                    Abbreviation = "ID",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1688,
                    CountryId = 237,
                    Name = "Illinois",
                    Abbreviation = "IL",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1689,
                    CountryId = 237,
                    Name = "Indiana",
                    Abbreviation = "IN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1690,
                    CountryId = 237,
                    Name = "Iowa",
                    Abbreviation = "IA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1691,
                    CountryId = 237,
                    Name = "Kansas",
                    Abbreviation = "KS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1692,
                    CountryId = 237,
                    Name = "Kentucky",
                    Abbreviation = "KY",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1693,
                    CountryId = 237,
                    Name = "Louisiana",
                    Abbreviation = "LA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1694,
                    CountryId = 237,
                    Name = "Maine",
                    Abbreviation = "ME",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1695,
                    CountryId = 237,
                    Name = "Marshall Islands",
                    Abbreviation = "MH",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1696,
                    CountryId = 237,
                    Name = "Maryland",
                    Abbreviation = "MD",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1697,
                    CountryId = 237,
                    Name = "Massachusetts",
                    Abbreviation = "MA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1698,
                    CountryId = 237,
                    Name = "Michigan",
                    Abbreviation = "MI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1699,
                    CountryId = 237,
                    Name = "Minnesota",
                    Abbreviation = "MN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1700,
                    CountryId = 237,
                    Name = "Mississippi",
                    Abbreviation = "MS",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1701,
                    CountryId = 237,
                    Name = "Missouri",
                    Abbreviation = "MO",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1702,
                    CountryId = 237,
                    Name = "Montana",
                    Abbreviation = "MT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1703,
                    CountryId = 237,
                    Name = "Nebraska",
                    Abbreviation = "NE",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1704,
                    CountryId = 237,
                    Name = "Nevada",
                    Abbreviation = "NV",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1705,
                    CountryId = 237,
                    Name = "New Hampshire",
                    Abbreviation = "NH",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1706,
                    CountryId = 237,
                    Name = "New Jersey",
                    Abbreviation = "NJ",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1707,
                    CountryId = 237,
                    Name = "New Mexico",
                    Abbreviation = "NM",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1708,
                    CountryId = 237,
                    Name = "New York",
                    Abbreviation = "NY",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1709,
                    CountryId = 237,
                    Name = "North Carolina",
                    Abbreviation = "NC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1710,
                    CountryId = 237,
                    Name = "North Dakota",
                    Abbreviation = "ND",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1711,
                    CountryId = 237,
                    Name = "Northern Mariana Islands",
                    Abbreviation = "MP",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1712,
                    CountryId = 237,
                    Name = "Ohio",
                    Abbreviation = "OH",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1713,
                    CountryId = 237,
                    Name = "Oklahoma",
                    Abbreviation = "OK",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1714,
                    CountryId = 237,
                    Name = "Oregon",
                    Abbreviation = "OR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1715,
                    CountryId = 237,
                    Name = "Palau",
                    Abbreviation = "PW",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1716,
                    CountryId = 237,
                    Name = "Pennsylvania",
                    Abbreviation = "PA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1717,
                    CountryId = 237,
                    Name = "Puerto Rico",
                    Abbreviation = "PR",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1718,
                    CountryId = 237,
                    Name = "Rhode Island",
                    Abbreviation = "RI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1719,
                    CountryId = 237,
                    Name = "South Carolina",
                    Abbreviation = "SC",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1720,
                    CountryId = 237,
                    Name = "South Dakota",
                    Abbreviation = "SD",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1721,
                    CountryId = 237,
                    Name = "Tennessee",
                    Abbreviation = "TN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1722,
                    CountryId = 237,
                    Name = "Texas",
                    Abbreviation = "TX",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1723,
                    CountryId = 237,
                    Name = "Utah",
                    Abbreviation = "UT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1724,
                    CountryId = 237,
                    Name = "Vermont",
                    Abbreviation = "VT",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1725,
                    CountryId = 237,
                    Name = "Virgin Islands",
                    Abbreviation = "VI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1726,
                    CountryId = 237,
                    Name = "Virginia",
                    Abbreviation = "VA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1727,
                    CountryId = 237,
                    Name = "Washington",
                    Abbreviation = "WA",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1728,
                    CountryId = 237,
                    Name = "West Virginia",
                    Abbreviation = "WV",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1729,
                    CountryId = 237,
                    Name = "Wisconsin",
                    Abbreviation = "WI",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1730,
                    CountryId = 237,
                    Name = "Wyoming",
                    Abbreviation = "WY",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1731,
                    CountryId = 241,
                    Name = "Amazonas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1732,
                    CountryId = 241,
                    Name = "Anzoategui",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1733,
                    CountryId = 241,
                    Name = "Apure",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1734,
                    CountryId = 241,
                    Name = "Aragua",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1735,
                    CountryId = 241,
                    Name = "Barinas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1736,
                    CountryId = 241,
                    Name = "Bolívar",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1737,
                    CountryId = 241,
                    Name = "Carabobo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 7
                },

                new StateProvince()
                {
                    Id = 1738,
                    CountryId = 241,
                    Name = "Cojedes",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 8
                },

                new StateProvince()
                {
                    Id = 1739,
                    CountryId = 241,
                    Name = "Delta Amacuro",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 9
                },

                new StateProvince()
                {
                    Id = 1740,
                    CountryId = 241,
                    Name = "Distrito Capital",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 10
                },

                new StateProvince()
                {
                    Id = 1741,
                    CountryId = 241,
                    Name = "Falcón",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 11
                },

                new StateProvince()
                {
                    Id = 1742,
                    CountryId = 241,
                    Name = "Guárico",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 12
                },

                new StateProvince()
                {
                    Id = 1743,
                    CountryId = 241,
                    Name = "Lara",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 13
                },

                new StateProvince()
                {
                    Id = 1744,
                    CountryId = 241,
                    Name = "Mérida",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 14
                },

                new StateProvince()
                {
                    Id = 1745,
                    CountryId = 241,
                    Name = "Miranda",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 15
                },

                new StateProvince()
                {
                    Id = 1746,
                    CountryId = 241,
                    Name = "Monagas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 16
                },

                new StateProvince()
                {
                    Id = 1747,
                    CountryId = 241,
                    Name = "Nueva Esparta",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 17
                },

                new StateProvince()
                {
                    Id = 1748,
                    CountryId = 241,
                    Name = "Portuguesa",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 18
                },

                new StateProvince()
                {
                    Id = 1749,
                    CountryId = 241,
                    Name = "Sucre",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 19
                },

                new StateProvince()
                {
                    Id = 1750,
                    CountryId = 241,
                    Name = "Táchira",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 20
                },

                new StateProvince()
                {
                    Id = 1751,
                    CountryId = 241,
                    Name = "Trujillo",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 21
                },

                new StateProvince()
                {
                    Id = 1752,
                    CountryId = 241,
                    Name = "Vargas",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 22
                },

                new StateProvince()
                {
                    Id = 1753,
                    CountryId = 241,
                    Name = "Yaracuy",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 23
                },

                new StateProvince()
                {
                    Id = 1754,
                    CountryId = 241,
                    Name = "Zulia",
                    Abbreviation = "",
                    Published = true,
                    DisplayOrder = 24
                },

                new StateProvince()
                {
                    Id = 1755,
                    CountryId = 242,
                    Name = "Hà Nội",
                    Abbreviation = "HN",
                    Published = true,
                    DisplayOrder = 1
                },

                new StateProvince()
                {
                    Id = 1756,
                    CountryId = 242,
                    Name = "Hồ Chí Minh",
                    Abbreviation = "HCM",
                    Published = true,
                    DisplayOrder = 2
                },

                new StateProvince()
                {
                    Id = 1757,
                    CountryId = 242,
                    Name = "Đà Nẵng",
                    Abbreviation = "ĐN",
                    Published = true,
                    DisplayOrder = 3
                },

                new StateProvince()
                {
                    Id = 1758,
                    CountryId = 242,
                    Name = "Hải Phòng",
                    Abbreviation = "HP",
                    Published = true,
                    DisplayOrder = 4
                },

                new StateProvince()
                {
                    Id = 1759,
                    CountryId = 242,
                    Name = "Cần Thơ",
                    Abbreviation = "CT",
                    Published = true,
                    DisplayOrder = 5
                },

                new StateProvince()
                {
                    Id = 1760,
                    CountryId = 242,
                    Name = "Hà Giang",
                    Abbreviation = "HG",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1761,
                    CountryId = 242,
                    Name = "Cao Bằng",
                    Abbreviation = "CB",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1762,
                    CountryId = 242,
                    Name = "Bắc Kạn",
                    Abbreviation = "BK",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1763,
                    CountryId = 242,
                    Name = "Tuyên Quang",
                    Abbreviation = "TQ",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1764,
                    CountryId = 242,
                    Name = "Lào Cai",
                    Abbreviation = "LC",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1765,
                    CountryId = 242,
                    Name = "Điện Biên",
                    Abbreviation = "ĐB",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1766,
                    CountryId = 242,
                    Name = "Lai Châu",
                    Abbreviation = "LC",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1767,
                    CountryId = 242,
                    Name = "Sơn La",
                    Abbreviation = "SL",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1768,
                    CountryId = 242,
                    Name = "Yên Bái",
                    Abbreviation = "YB",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1769,
                    CountryId = 242,
                    Name = "Hòa Bình",
                    Abbreviation = "HB",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1770,
                    CountryId = 242,
                    Name = "Thái Nguyên",
                    Abbreviation = "TN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1771,
                    CountryId = 242,
                    Name = "Lạng Sơn",
                    Abbreviation = "LS",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1772,
                    CountryId = 242,
                    Name = "Quảng Ninh",
                    Abbreviation = "QN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1773,
                    CountryId = 242,
                    Name = "Bắc Giang",
                    Abbreviation = "BG",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1774,
                    CountryId = 242,
                    Name = "Phú Thọ",
                    Abbreviation = "PT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1775,
                    CountryId = 242,
                    Name = "Vĩnh Phúc",
                    Abbreviation = "VP",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1776,
                    CountryId = 242,
                    Name = "Bắc Ninh",
                    Abbreviation = "BN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1777,
                    CountryId = 242,
                    Name = "Hải Dương",
                    Abbreviation = "HD",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1778,
                    CountryId = 242,
                    Name = "Hưng Yên",
                    Abbreviation = "HY",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1779,
                    CountryId = 242,
                    Name = "Thái Bình",
                    Abbreviation = "TB",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1780,
                    CountryId = 242,
                    Name = "Hà Nam",
                    Abbreviation = "HN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1781,
                    CountryId = 242,
                    Name = "Nam Định",
                    Abbreviation = "NĐ",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1782,
                    CountryId = 242,
                    Name = "Ninh Bình",
                    Abbreviation = "NB",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1783,
                    CountryId = 242,
                    Name = "Thanh Hóa",
                    Abbreviation = "TH",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1784,
                    CountryId = 242,
                    Name = "Nghệ An",
                    Abbreviation = "NA",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1785,
                    CountryId = 242,
                    Name = "Hà Tĩnh",
                    Abbreviation = "HT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1786,
                    CountryId = 242,
                    Name = "Quảng Bình",
                    Abbreviation = "QB",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1787,
                    CountryId = 242,
                    Name = "Quảng Trị",
                    Abbreviation = "QT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1788,
                    CountryId = 242,
                    Name = "Thừa Thiên Huế",
                    Abbreviation = "TTH",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1789,
                    CountryId = 242,
                    Name = "Quảng Nam",
                    Abbreviation = "QN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1790,
                    CountryId = 242,
                    Name = "Quảng Ngãi",
                    Abbreviation = "QN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1791,
                    CountryId = 242,
                    Name = "Bình Định",
                    Abbreviation = "BĐ",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1792,
                    CountryId = 242,
                    Name = "Phú Yên",
                    Abbreviation = "PY",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1793,
                    CountryId = 242,
                    Name = "Khánh Hòa",
                    Abbreviation = "KH",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1794,
                    CountryId = 242,
                    Name = "Ninh Thuận",
                    Abbreviation = "NT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1795,
                    CountryId = 242,
                    Name = "Bình Thuận",
                    Abbreviation = "BT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1796,
                    CountryId = 242,
                    Name = "Kon Tum",
                    Abbreviation = "KT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1797,
                    CountryId = 242,
                    Name = "Gia Lai",
                    Abbreviation = "GL",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1798,
                    CountryId = 242,
                    Name = "Đắk Lắk",
                    Abbreviation = "ĐL",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1799,
                    CountryId = 242,
                    Name = "Đắk Nông",
                    Abbreviation = "ĐN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1800,
                    CountryId = 242,
                    Name = "Lâm Đồng",
                    Abbreviation = "LĐ",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1801,
                    CountryId = 242,
                    Name = "Bình Phước",
                    Abbreviation = "BP",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1802,
                    CountryId = 242,
                    Name = "Tây Ninh",
                    Abbreviation = "TN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1803,
                    CountryId = 242,
                    Name = "Bình Dương",
                    Abbreviation = "BD",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1804,
                    CountryId = 242,
                    Name = "Đồng Nai",
                    Abbreviation = "ĐN",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1805,
                    CountryId = 242,
                    Name = "Bà Rịa - Vũng Tàu",
                    Abbreviation = "BR",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1806,
                    CountryId = 242,
                    Name = "Long An",
                    Abbreviation = "LA",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1807,
                    CountryId = 242,
                    Name = "Tiền Giang",
                    Abbreviation = "TG",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1808,
                    CountryId = 242,
                    Name = "Bến Tre",
                    Abbreviation = "BT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1809,
                    CountryId = 242,
                    Name = "Trà Vinh",
                    Abbreviation = "TV",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1810,
                    CountryId = 242,
                    Name = "Vĩnh Long",
                    Abbreviation = "VL",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1811,
                    CountryId = 242,
                    Name = "Đồng Tháp",
                    Abbreviation = "ĐT",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1812,
                    CountryId = 242,
                    Name = "An Giang",
                    Abbreviation = "AG",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1813,
                    CountryId = 242,
                    Name = "Kiên Giang",
                    Abbreviation = "KG",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1814,
                    CountryId = 242,
                    Name = "Hậu Giang",
                    Abbreviation = "HG",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1815,
                    CountryId = 242,
                    Name = "Sóc Trăng",
                    Abbreviation = "ST",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1816,
                    CountryId = 242,
                    Name = "Bạc Liêu",
                    Abbreviation = "BL",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1817,
                    CountryId = 242,
                    Name = "Cà Mau",
                    Abbreviation = "CM",
                    Published = true,
                    DisplayOrder = 6
                },

                new StateProvince()
                {
                    Id = 1827,
                    CountryId = 249,
                    Name = "Bulawayo",
                    Abbreviation = "BU",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1828,
                    CountryId = 249,
                    Name = "Harare",
                    Abbreviation = "HA",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1829,
                    CountryId = 249,
                    Name = "Manicaland",
                    Abbreviation = "MA",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1830,
                    CountryId = 249,
                    Name = "Mashonaland Central",
                    Abbreviation = "MC",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1831,
                    CountryId = 249,
                    Name = "Mashonaland East",
                    Abbreviation = "ME",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1832,
                    CountryId = 249,
                    Name = "Mashonaland West",
                    Abbreviation = "MW",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1833,
                    CountryId = 249,
                    Name = "Masvingo",
                    Abbreviation = "MV",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1834,
                    CountryId = 249,
                    Name = "Matabeleland North",
                    Abbreviation = "MN",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1835,
                    CountryId = 249,
                    Name = "Matabeleland South",
                    Abbreviation = "MS",
                    Published = true,
                    DisplayOrder = 0
                },

                new StateProvince()
                {
                    Id = 1836,
                    CountryId = 249,
                    Name = "Midlands",
                    Abbreviation = "MI",
                    Published = true,
                    DisplayOrder = 0
                }
                );
            #endregion
        }
    }
}
