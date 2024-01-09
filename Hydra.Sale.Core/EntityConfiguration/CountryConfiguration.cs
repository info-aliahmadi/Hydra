using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.ToTable("Country", "Sale");

            entity.HasIndex(e => e.DisplayOrder, "IX_Country_DisplayOrder");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);
            entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);

            #region Country Seed

            entity.HasData(
                new Country()
                {
                    Id = 1,
                    Name = "Afghanistan",
                    TwoLetterIsoCode = "AF",
                    ThreeLetterIsoCode = "AFG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 4,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 2,
                    Name = "Åland Islands",
                    TwoLetterIsoCode = "AX",
                    ThreeLetterIsoCode = "ALA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 248,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 3,
                    Name = "Albania",
                    TwoLetterIsoCode = "AL",
                    ThreeLetterIsoCode = "ALB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 8,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 4,
                    Name = "Algeria",
                    TwoLetterIsoCode = "DZ",
                    ThreeLetterIsoCode = "DZA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 12,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 5,
                    Name = "American Samoa",
                    TwoLetterIsoCode = "AS",
                    ThreeLetterIsoCode = "ASM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 16,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 6,
                    Name = "Andorra",
                    TwoLetterIsoCode = "AD",
                    ThreeLetterIsoCode = "AND",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 20,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 7,
                    Name = "Angola",
                    TwoLetterIsoCode = "AO",
                    ThreeLetterIsoCode = "AGO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 24,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 8,
                    Name = "Anguilla",
                    TwoLetterIsoCode = "AI",
                    ThreeLetterIsoCode = "AIA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 660,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 9,
                    Name = "Antarctica",
                    TwoLetterIsoCode = "AQ",
                    ThreeLetterIsoCode = "ATA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 10,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 10,
                    Name = "Antigua and Barbuda",
                    TwoLetterIsoCode = "AG",
                    ThreeLetterIsoCode = "ATG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 28,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 11,
                    Name = "Argentina",
                    TwoLetterIsoCode = "AR",
                    ThreeLetterIsoCode = "ARG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 32,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 12,
                    Name = "Armenia",
                    TwoLetterIsoCode = "AM",
                    ThreeLetterIsoCode = "ARM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 51,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 13,
                    Name = "Aruba",
                    TwoLetterIsoCode = "AW",
                    ThreeLetterIsoCode = "ABW",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 533,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 14,
                    Name = "Australia",
                    TwoLetterIsoCode = "AU",
                    ThreeLetterIsoCode = "AUS",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 36,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 15,
                    Name = "Austria",
                    TwoLetterIsoCode = "AT",
                    ThreeLetterIsoCode = "AUT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 40,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 16,
                    Name = "Azerbaijan",
                    TwoLetterIsoCode = "AZ",
                    ThreeLetterIsoCode = "AZE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 31,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 17,
                    Name = "Bahamas",
                    TwoLetterIsoCode = "BS",
                    ThreeLetterIsoCode = "BHS",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 44,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 18,
                    Name = "Bahrain",
                    TwoLetterIsoCode = "BH",
                    ThreeLetterIsoCode = "BHR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 48,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 19,
                    Name = "Bangladesh",
                    TwoLetterIsoCode = "BD",
                    ThreeLetterIsoCode = "BGD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 50,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 20,
                    Name = "Barbados",
                    TwoLetterIsoCode = "BB",
                    ThreeLetterIsoCode = "BRB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 52,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 21,
                    Name = "Belarus",
                    TwoLetterIsoCode = "BY",
                    ThreeLetterIsoCode = "BLR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 112,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 22,
                    Name = "Belgium",
                    TwoLetterIsoCode = "BE",
                    ThreeLetterIsoCode = "BEL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 56,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 23,
                    Name = "Belize",
                    TwoLetterIsoCode = "BZ",
                    ThreeLetterIsoCode = "BLZ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 84,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 24,
                    Name = "Benin",
                    TwoLetterIsoCode = "BJ",
                    ThreeLetterIsoCode = "BEN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 204,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 25,
                    Name = "Bermuda",
                    TwoLetterIsoCode = "BM",
                    ThreeLetterIsoCode = "BMU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 60,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 26,
                    Name = "Bhutan",
                    TwoLetterIsoCode = "BT",
                    ThreeLetterIsoCode = "BTN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 64,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 27,
                    Name = "Bolivia (Plurinational State of)",
                    TwoLetterIsoCode = "BO",
                    ThreeLetterIsoCode = "BOL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 68,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 28,
                    Name = "Bonaire, Sint Eustatius and Saba",
                    TwoLetterIsoCode = "BQ",
                    ThreeLetterIsoCode = "BES",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 535,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 29,
                    Name = "Bosnia and Herzegovina",
                    TwoLetterIsoCode = "BA",
                    ThreeLetterIsoCode = "BIH",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 70,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 30,
                    Name = "Botswana",
                    TwoLetterIsoCode = "BW",
                    ThreeLetterIsoCode = "BWA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 72,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 31,
                    Name = "Bouvet Island",
                    TwoLetterIsoCode = "BV",
                    ThreeLetterIsoCode = "BVT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 74,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 32,
                    Name = "Brazil",
                    TwoLetterIsoCode = "BR",
                    ThreeLetterIsoCode = "BRA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 76,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 33,
                    Name = "British Indian Ocean Territory",
                    TwoLetterIsoCode = "IO",
                    ThreeLetterIsoCode = "IOT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 86,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 34,
                    Name = "Brunei Darussalam",
                    TwoLetterIsoCode = "BN",
                    ThreeLetterIsoCode = "BRN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 96,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 35,
                    Name = "Bulgaria",
                    TwoLetterIsoCode = "BG",
                    ThreeLetterIsoCode = "BGR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 100,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 36,
                    Name = "Burkina Faso",
                    TwoLetterIsoCode = "BF",
                    ThreeLetterIsoCode = "BFA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 854,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 37,
                    Name = "Burundi",
                    TwoLetterIsoCode = "BI",
                    ThreeLetterIsoCode = "BDI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 108,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 38,
                    Name = "Cabo Verde",
                    TwoLetterIsoCode = "CV",
                    ThreeLetterIsoCode = "CPV",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 132,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 39,
                    Name = "Cambodia",
                    TwoLetterIsoCode = "KH",
                    ThreeLetterIsoCode = "KHM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 116,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 40,
                    Name = "Cameroon",
                    TwoLetterIsoCode = "CM",
                    ThreeLetterIsoCode = "CMR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 120,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 41,
                    Name = "Canada",
                    TwoLetterIsoCode = "CA",
                    ThreeLetterIsoCode = "CAN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 124,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 42,
                    Name = "Cayman Islands",
                    TwoLetterIsoCode = "KY",
                    ThreeLetterIsoCode = "CYM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 136,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 43,
                    Name = "Central African Republic",
                    TwoLetterIsoCode = "CF",
                    ThreeLetterIsoCode = "CAF",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 140,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 44,
                    Name = "Chad",
                    TwoLetterIsoCode = "TD",
                    ThreeLetterIsoCode = "TCD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 148,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 45,
                    Name = "Chile",
                    TwoLetterIsoCode = "CL",
                    ThreeLetterIsoCode = "CHL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 152,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 46,
                    Name = "China",
                    TwoLetterIsoCode = "CN",
                    ThreeLetterIsoCode = "CHN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 156,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 47,
                    Name = "Christmas Island",
                    TwoLetterIsoCode = "CX",
                    ThreeLetterIsoCode = "CXR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 162,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 48,
                    Name = "Cocos (Keeling) Islands",
                    TwoLetterIsoCode = "CC",
                    ThreeLetterIsoCode = "CCK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 166,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 49,
                    Name = "Colombia",
                    TwoLetterIsoCode = "CO",
                    ThreeLetterIsoCode = "COL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 170,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 50,
                    Name = "Comoros",
                    TwoLetterIsoCode = "KM",
                    ThreeLetterIsoCode = "COM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 174,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 51,
                    Name = "Congo",
                    TwoLetterIsoCode = "CG",
                    ThreeLetterIsoCode = "COG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 178,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 52,
                    Name = "Congo (Democratic Republic of the)",
                    TwoLetterIsoCode = "CD",
                    ThreeLetterIsoCode = "COD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 180,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 53,
                    Name = "Cook Islands",
                    TwoLetterIsoCode = "CK",
                    ThreeLetterIsoCode = "COK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 184,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 54,
                    Name = "Costa Rica",
                    TwoLetterIsoCode = "CR",
                    ThreeLetterIsoCode = "CRI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 188,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 55,
                    Name = "Côte d'Ivoire",
                    TwoLetterIsoCode = "CI",
                    ThreeLetterIsoCode = "CIV",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 384,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 56,
                    Name = "Croatia",
                    TwoLetterIsoCode = "HR",
                    ThreeLetterIsoCode = "HRV",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 191,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 57,
                    Name = "Cuba",
                    TwoLetterIsoCode = "CU",
                    ThreeLetterIsoCode = "CUB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 192,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 58,
                    Name = "Curaçao",
                    TwoLetterIsoCode = "CW",
                    ThreeLetterIsoCode = "CUW",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 531,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 59,
                    Name = "Cyprus",
                    TwoLetterIsoCode = "CY",
                    ThreeLetterIsoCode = "CYP",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 196,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 60,
                    Name = "Czechia",
                    TwoLetterIsoCode = "CZ",
                    ThreeLetterIsoCode = "CZE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 203,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 61,
                    Name = "Denmark",
                    TwoLetterIsoCode = "DK",
                    ThreeLetterIsoCode = "DNK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 208,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 62,
                    Name = "Djibouti",
                    TwoLetterIsoCode = "DJ",
                    ThreeLetterIsoCode = "DJI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 262,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 63,
                    Name = "Dominica",
                    TwoLetterIsoCode = "DM",
                    ThreeLetterIsoCode = "DMA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 212,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 64,
                    Name = "Dominican Republic",
                    TwoLetterIsoCode = "DO",
                    ThreeLetterIsoCode = "DOM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 214,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 65,
                    Name = "Ecuador",
                    TwoLetterIsoCode = "EC",
                    ThreeLetterIsoCode = "ECU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 218,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 66,
                    Name = "Egypt",
                    TwoLetterIsoCode = "EG",
                    ThreeLetterIsoCode = "EGY",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 818,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 67,
                    Name = "El Salvador",
                    TwoLetterIsoCode = "SV",
                    ThreeLetterIsoCode = "SLV",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 222,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 68,
                    Name = "Equatorial Guinea",
                    TwoLetterIsoCode = "GQ",
                    ThreeLetterIsoCode = "GNQ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 226,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 69,
                    Name = "Eritrea",
                    TwoLetterIsoCode = "ER",
                    ThreeLetterIsoCode = "ERI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 232,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 70,
                    Name = "Estonia",
                    TwoLetterIsoCode = "EE",
                    ThreeLetterIsoCode = "EST",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 233,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 71,
                    Name = "Eswatini",
                    TwoLetterIsoCode = "SZ",
                    ThreeLetterIsoCode = "SWZ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 748,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 72,
                    Name = "Ethiopia",
                    TwoLetterIsoCode = "ET",
                    ThreeLetterIsoCode = "ETH",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 231,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 73,
                    Name = "Falkland Islands (Malvinas)",
                    TwoLetterIsoCode = "FK",
                    ThreeLetterIsoCode = "FLK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 238,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 74,
                    Name = "Faroe Islands",
                    TwoLetterIsoCode = "FO",
                    ThreeLetterIsoCode = "FRO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 234,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 75,
                    Name = "Fiji",
                    TwoLetterIsoCode = "FJ",
                    ThreeLetterIsoCode = "FJI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 242,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 76,
                    Name = "Finland",
                    TwoLetterIsoCode = "FI",
                    ThreeLetterIsoCode = "FIN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 246,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 77,
                    Name = "France",
                    TwoLetterIsoCode = "FR",
                    ThreeLetterIsoCode = "FRA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 250,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 78,
                    Name = "French Guiana",
                    TwoLetterIsoCode = "GF",
                    ThreeLetterIsoCode = "GUF",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 254,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 79,
                    Name = "French Polynesia",
                    TwoLetterIsoCode = "PF",
                    ThreeLetterIsoCode = "PYF",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 258,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 80,
                    Name = "French Southern Territories",
                    TwoLetterIsoCode = "TF",
                    ThreeLetterIsoCode = "ATF",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 260,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 81,
                    Name = "Gabon",
                    TwoLetterIsoCode = "GA",
                    ThreeLetterIsoCode = "GAB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 266,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 82,
                    Name = "Gambia",
                    TwoLetterIsoCode = "GM",
                    ThreeLetterIsoCode = "GMB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 270,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 83,
                    Name = "Georgia",
                    TwoLetterIsoCode = "GE",
                    ThreeLetterIsoCode = "GEO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 268,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 84,
                    Name = "Germany",
                    TwoLetterIsoCode = "DE",
                    ThreeLetterIsoCode = "DEU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 276,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 85,
                    Name = "Ghana",
                    TwoLetterIsoCode = "GH",
                    ThreeLetterIsoCode = "GHA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 288,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 86,
                    Name = "Gibraltar",
                    TwoLetterIsoCode = "GI",
                    ThreeLetterIsoCode = "GIB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 292,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 87,
                    Name = "Greece",
                    TwoLetterIsoCode = "GR",
                    ThreeLetterIsoCode = "GRC",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 300,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 88,
                    Name = "Greenland",
                    TwoLetterIsoCode = "GL",
                    ThreeLetterIsoCode = "GRL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 304,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 89,
                    Name = "Grenada",
                    TwoLetterIsoCode = "GD",
                    ThreeLetterIsoCode = "GRD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 308,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 90,
                    Name = "Guadeloupe",
                    TwoLetterIsoCode = "GP",
                    ThreeLetterIsoCode = "GLP",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 312,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 91,
                    Name = "Guam",
                    TwoLetterIsoCode = "GU",
                    ThreeLetterIsoCode = "GUM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 316,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 92,
                    Name = "Guatemala",
                    TwoLetterIsoCode = "GT",
                    ThreeLetterIsoCode = "GTM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 320,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 93,
                    Name = "Guernsey",
                    TwoLetterIsoCode = "GG",
                    ThreeLetterIsoCode = "GGY",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 831,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 94,
                    Name = "Guinea",
                    TwoLetterIsoCode = "GN",
                    ThreeLetterIsoCode = "GIN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 324,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 95,
                    Name = "Guinea-Bissau",
                    TwoLetterIsoCode = "GW",
                    ThreeLetterIsoCode = "GNB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 624,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 96,
                    Name = "Guyana",
                    TwoLetterIsoCode = "GY",
                    ThreeLetterIsoCode = "GUY",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 328,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 97,
                    Name = "Haiti",
                    TwoLetterIsoCode = "HT",
                    ThreeLetterIsoCode = "HTI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 332,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 98,
                    Name = "Heard Island and McDonald Islands",
                    TwoLetterIsoCode = "HM",
                    ThreeLetterIsoCode = "HMD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 334,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 99,
                    Name = "Holy See",
                    TwoLetterIsoCode = "VA",
                    ThreeLetterIsoCode = "VAT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 336,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 100,
                    Name = "Honduras",
                    TwoLetterIsoCode = "HN",
                    ThreeLetterIsoCode = "HND",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 340,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 101,
                    Name = "Hong Kong",
                    TwoLetterIsoCode = "HK",
                    ThreeLetterIsoCode = "HKG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 344,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 102,
                    Name = "Hungary",
                    TwoLetterIsoCode = "HU",
                    ThreeLetterIsoCode = "HUN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 348,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 103,
                    Name = "Iceland",
                    TwoLetterIsoCode = "IS",
                    ThreeLetterIsoCode = "ISL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 352,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 104,
                    Name = "India",
                    TwoLetterIsoCode = "IN",
                    ThreeLetterIsoCode = "IND",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 356,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 105,
                    Name = "Indonesia",
                    TwoLetterIsoCode = "ID",
                    ThreeLetterIsoCode = "IDN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 360,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 106,
                    Name = "Iran (Islamic Republic of)",
                    TwoLetterIsoCode = "IR",
                    ThreeLetterIsoCode = "IRN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 364,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 107,
                    Name = "Iraq",
                    TwoLetterIsoCode = "IQ",
                    ThreeLetterIsoCode = "IRQ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 368,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 108,
                    Name = "Ireland",
                    TwoLetterIsoCode = "IE",
                    ThreeLetterIsoCode = "IRL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 372,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 109,
                    Name = "Isle of Man",
                    TwoLetterIsoCode = "IM",
                    ThreeLetterIsoCode = "IMN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 833,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 110,
                    Name = "Israel",
                    TwoLetterIsoCode = "IL",
                    ThreeLetterIsoCode = "ISR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 376,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 111,
                    Name = "Italy",
                    TwoLetterIsoCode = "IT",
                    ThreeLetterIsoCode = "ITA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 380,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 112,
                    Name = "Jamaica",
                    TwoLetterIsoCode = "JM",
                    ThreeLetterIsoCode = "JAM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 388,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 113,
                    Name = "Japan",
                    TwoLetterIsoCode = "JP",
                    ThreeLetterIsoCode = "JPN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 392,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 114,
                    Name = "Jersey",
                    TwoLetterIsoCode = "JE",
                    ThreeLetterIsoCode = "JEY",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 832,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 115,
                    Name = "Jordan",
                    TwoLetterIsoCode = "JO",
                    ThreeLetterIsoCode = "JOR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 400,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 116,
                    Name = "Kazakhstan",
                    TwoLetterIsoCode = "KZ",
                    ThreeLetterIsoCode = "KAZ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 398,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 117,
                    Name = "Kenya",
                    TwoLetterIsoCode = "KE",
                    ThreeLetterIsoCode = "KEN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 404,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 118,
                    Name = "Kiribati",
                    TwoLetterIsoCode = "KI",
                    ThreeLetterIsoCode = "KIR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 296,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 119,
                    Name = "Korea (Democratic People's Republic of)",
                    TwoLetterIsoCode = "KP",
                    ThreeLetterIsoCode = "PRK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 408,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 120,
                    Name = "Korea (Republic of)",
                    TwoLetterIsoCode = "KR",
                    ThreeLetterIsoCode = "KOR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 410,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 121,
                    Name = "Kuwait",
                    TwoLetterIsoCode = "KW",
                    ThreeLetterIsoCode = "KWT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 414,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 122,
                    Name = "Kyrgyzstan",
                    TwoLetterIsoCode = "KG",
                    ThreeLetterIsoCode = "KGZ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 417,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 123,
                    Name = "Lao People's Democratic Republic",
                    TwoLetterIsoCode = "LA",
                    ThreeLetterIsoCode = "LAO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 418,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 124,
                    Name = "Latvia",
                    TwoLetterIsoCode = "LV",
                    ThreeLetterIsoCode = "LVA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 428,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 125,
                    Name = "Lebanon",
                    TwoLetterIsoCode = "LB",
                    ThreeLetterIsoCode = "LBN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 422,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 126,
                    Name = "Lesotho",
                    TwoLetterIsoCode = "LS",
                    ThreeLetterIsoCode = "LSO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 426,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 127,
                    Name = "Liberia",
                    TwoLetterIsoCode = "LR",
                    ThreeLetterIsoCode = "LBR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 430,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 128,
                    Name = "Libya",
                    TwoLetterIsoCode = "LY",
                    ThreeLetterIsoCode = "LBY",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 434,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 129,
                    Name = "Liechtenstein",
                    TwoLetterIsoCode = "LI",
                    ThreeLetterIsoCode = "LIE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 438,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 130,
                    Name = "Lithuania",
                    TwoLetterIsoCode = "LT",
                    ThreeLetterIsoCode = "LTU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 440,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 131,
                    Name = "Luxembourg",
                    TwoLetterIsoCode = "LU",
                    ThreeLetterIsoCode = "LUX",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 442,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 132,
                    Name = "Macao",
                    TwoLetterIsoCode = "MO",
                    ThreeLetterIsoCode = "MAC",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 446,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 133,
                    Name = "North Macedonia",
                    TwoLetterIsoCode = "MK",
                    ThreeLetterIsoCode = "MKD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 807,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 134,
                    Name = "Madagascar",
                    TwoLetterIsoCode = "MG",
                    ThreeLetterIsoCode = "MDG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 450,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 135,
                    Name = "Malawi",
                    TwoLetterIsoCode = "MW",
                    ThreeLetterIsoCode = "MWI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 454,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 136,
                    Name = "Malaysia",
                    TwoLetterIsoCode = "MY",
                    ThreeLetterIsoCode = "MYS",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 458,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 137,
                    Name = "Maldives",
                    TwoLetterIsoCode = "MV",
                    ThreeLetterIsoCode = "MDV",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 462,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 138,
                    Name = "Mali",
                    TwoLetterIsoCode = "ML",
                    ThreeLetterIsoCode = "MLI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 466,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 139,
                    Name = "Malta",
                    TwoLetterIsoCode = "MT",
                    ThreeLetterIsoCode = "MLT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 470,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 140,
                    Name = "Marshall Islands",
                    TwoLetterIsoCode = "MH",
                    ThreeLetterIsoCode = "MHL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 584,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 141,
                    Name = "Martinique",
                    TwoLetterIsoCode = "MQ",
                    ThreeLetterIsoCode = "MTQ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 474,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 142,
                    Name = "Mauritania",
                    TwoLetterIsoCode = "MR",
                    ThreeLetterIsoCode = "MRT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 478,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 143,
                    Name = "Mauritius",
                    TwoLetterIsoCode = "MU",
                    ThreeLetterIsoCode = "MUS",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 480,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 144,
                    Name = "Mayotte",
                    TwoLetterIsoCode = "YT",
                    ThreeLetterIsoCode = "MYT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 175,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 145,
                    Name = "Mexico",
                    TwoLetterIsoCode = "MX",
                    ThreeLetterIsoCode = "MEX",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 484,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 146,
                    Name = "Micronesia (Federated States of)",
                    TwoLetterIsoCode = "FM",
                    ThreeLetterIsoCode = "FSM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 583,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 147,
                    Name = "Moldova (Republic of)",
                    TwoLetterIsoCode = "MD",
                    ThreeLetterIsoCode = "MDA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 498,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 148,
                    Name = "Monaco",
                    TwoLetterIsoCode = "MC",
                    ThreeLetterIsoCode = "MCO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 492,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 149,
                    Name = "Mongolia",
                    TwoLetterIsoCode = "MN",
                    ThreeLetterIsoCode = "MNG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 496,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 150,
                    Name = "Montenegro",
                    TwoLetterIsoCode = "ME",
                    ThreeLetterIsoCode = "MNE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 499,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 151,
                    Name = "Montserrat",
                    TwoLetterIsoCode = "MS",
                    ThreeLetterIsoCode = "MSR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 500,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 152,
                    Name = "Morocco",
                    TwoLetterIsoCode = "MA",
                    ThreeLetterIsoCode = "MAR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 504,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 153,
                    Name = "Mozambique",
                    TwoLetterIsoCode = "MZ",
                    ThreeLetterIsoCode = "MOZ",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 508,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 154,
                    Name = "Myanmar",
                    TwoLetterIsoCode = "MM",
                    ThreeLetterIsoCode = "MMR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 104,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 155,
                    Name = "Namibia",
                    TwoLetterIsoCode = "NA",
                    ThreeLetterIsoCode = "NAM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 516,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 156,
                    Name = "Nauru",
                    TwoLetterIsoCode = "NR",
                    ThreeLetterIsoCode = "NRU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 520,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 157,
                    Name = "Nepal",
                    TwoLetterIsoCode = "NP",
                    ThreeLetterIsoCode = "NPL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 524,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 158,
                    Name = "Netherlands",
                    TwoLetterIsoCode = "NL",
                    ThreeLetterIsoCode = "NLD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 528,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 159,
                    Name = "New Caledonia",
                    TwoLetterIsoCode = "NC",
                    ThreeLetterIsoCode = "NCL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 540,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 160,
                    Name = "New Zealand",
                    TwoLetterIsoCode = "NZ",
                    ThreeLetterIsoCode = "NZL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 554,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 161,
                    Name = "Nicaragua",
                    TwoLetterIsoCode = "NI",
                    ThreeLetterIsoCode = "NIC",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 558,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 162,
                    Name = "Niger",
                    TwoLetterIsoCode = "NE",
                    ThreeLetterIsoCode = "NER",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 562,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 163,
                    Name = "Nigeria",
                    TwoLetterIsoCode = "NG",
                    ThreeLetterIsoCode = "NGA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 566,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 164,
                    Name = "Niue",
                    TwoLetterIsoCode = "NU",
                    ThreeLetterIsoCode = "NIU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 570,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 165,
                    Name = "Norfolk Island",
                    TwoLetterIsoCode = "NF",
                    ThreeLetterIsoCode = "NFK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 574,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 166,
                    Name = "Northern Mariana Islands",
                    TwoLetterIsoCode = "MP",
                    ThreeLetterIsoCode = "MNP",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 580,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 167,
                    Name = "Norway",
                    TwoLetterIsoCode = "NO",
                    ThreeLetterIsoCode = "NOR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 578,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 168,
                    Name = "Oman",
                    TwoLetterIsoCode = "OM",
                    ThreeLetterIsoCode = "OMN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 512,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 169,
                    Name = "Pakistan",
                    TwoLetterIsoCode = "PK",
                    ThreeLetterIsoCode = "PAK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 586,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 170,
                    Name = "Palau",
                    TwoLetterIsoCode = "PW",
                    ThreeLetterIsoCode = "PLW",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 585,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 171,
                    Name = "Palestine, State of",
                    TwoLetterIsoCode = "PS",
                    ThreeLetterIsoCode = "PSE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 275,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 172,
                    Name = "Panama",
                    TwoLetterIsoCode = "PA",
                    ThreeLetterIsoCode = "PAN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 591,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 173,
                    Name = "Papua New Guinea",
                    TwoLetterIsoCode = "PG",
                    ThreeLetterIsoCode = "PNG",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 598,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 174,
                    Name = "Paraguay",
                    TwoLetterIsoCode = "PY",
                    ThreeLetterIsoCode = "PRY",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 600,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 175,
                    Name = "Peru",
                    TwoLetterIsoCode = "PE",
                    ThreeLetterIsoCode = "PER",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 604,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 176,
                    Name = "Philippines",
                    TwoLetterIsoCode = "PH",
                    ThreeLetterIsoCode = "PHL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 608,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 177,
                    Name = "Pitcairn",
                    TwoLetterIsoCode = "PN",
                    ThreeLetterIsoCode = "PCN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 612,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 178,
                    Name = "Poland",
                    TwoLetterIsoCode = "PL",
                    ThreeLetterIsoCode = "POL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 616,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 179,
                    Name = "Portugal",
                    TwoLetterIsoCode = "PT",
                    ThreeLetterIsoCode = "PRT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 620,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 180,
                    Name = "Puerto Rico",
                    TwoLetterIsoCode = "PR",
                    ThreeLetterIsoCode = "PRI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 630,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 181,
                    Name = "Qatar",
                    TwoLetterIsoCode = "QA",
                    ThreeLetterIsoCode = "QAT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 634,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 182,
                    Name = "Réunion",
                    TwoLetterIsoCode = "RE",
                    ThreeLetterIsoCode = "REU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 638,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 183,
                    Name = "Romania",
                    TwoLetterIsoCode = "RO",
                    ThreeLetterIsoCode = "ROU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 642,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 184,
                    Name = "Russian Federation",
                    TwoLetterIsoCode = "RU",
                    ThreeLetterIsoCode = "RUS",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 643,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 185,
                    Name = "Rwanda",
                    TwoLetterIsoCode = "RW",
                    ThreeLetterIsoCode = "RWA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 646,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 186,
                    Name = "Saint Barthélemy",
                    TwoLetterIsoCode = "BL",
                    ThreeLetterIsoCode = "BLM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 652,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 187,
                    Name = "Saint Helena, Ascension and Tristan da Cunha",
                    TwoLetterIsoCode = "SH",
                    ThreeLetterIsoCode = "SHN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 654,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 188,
                    Name = "Saint Kitts and Nevis",
                    TwoLetterIsoCode = "KN",
                    ThreeLetterIsoCode = "KNA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 659,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 189,
                    Name = "Saint Lucia",
                    TwoLetterIsoCode = "LC",
                    ThreeLetterIsoCode = "LCA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 662,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 190,
                    Name = "Saint Martin (French part)",
                    TwoLetterIsoCode = "MF",
                    ThreeLetterIsoCode = "MAF",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 663,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 191,
                    Name = "Saint Pierre and Miquelon",
                    TwoLetterIsoCode = "PM",
                    ThreeLetterIsoCode = "SPM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 666,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 192,
                    Name = "Saint Vincent and the Grenadines",
                    TwoLetterIsoCode = "VC",
                    ThreeLetterIsoCode = "VCT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 670,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 193,
                    Name = "Samoa",
                    TwoLetterIsoCode = "WS",
                    ThreeLetterIsoCode = "WSM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 882,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 194,
                    Name = "San Marino",
                    TwoLetterIsoCode = "SP",
                    ThreeLetterIsoCode = "SMR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 674,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 195,
                    Name = "Sao Tome and Principe",
                    TwoLetterIsoCode = "ST",
                    ThreeLetterIsoCode = "STP",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 678,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 196,
                    Name = "Saudi Arabia",
                    TwoLetterIsoCode = "SA",
                    ThreeLetterIsoCode = "SAU",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 682,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 197,
                    Name = "Senegal",
                    TwoLetterIsoCode = "SN",
                    ThreeLetterIsoCode = "SEN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 686,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 198,
                    Name = "Serbia",
                    TwoLetterIsoCode = "RS",
                    ThreeLetterIsoCode = "SRB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 688,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 199,
                    Name = "Seychelles",
                    TwoLetterIsoCode = "SC",
                    ThreeLetterIsoCode = "SYC",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 690,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 200,
                    Name = "Sierra Leone",
                    TwoLetterIsoCode = "SL",
                    ThreeLetterIsoCode = "SLE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 694,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 201,
                    Name = "Singapore",
                    TwoLetterIsoCode = "SG",
                    ThreeLetterIsoCode = "SGP",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 702,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 202,
                    Name = "Sint Maarten (Dutch part)",
                    TwoLetterIsoCode = "SX",
                    ThreeLetterIsoCode = "SXM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 534,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 203,
                    Name = "Slovakia",
                    TwoLetterIsoCode = "SK",
                    ThreeLetterIsoCode = "SVK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 703,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 204,
                    Name = "Slovenia",
                    TwoLetterIsoCode = "SI",
                    ThreeLetterIsoCode = "SVN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 705,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 205,
                    Name = "Solomon Islands",
                    TwoLetterIsoCode = "SB",
                    ThreeLetterIsoCode = "SLB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 90,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 206,
                    Name = "Somalia",
                    TwoLetterIsoCode = "SO",
                    ThreeLetterIsoCode = "SOM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 706,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 207,
                    Name = "South Africa",
                    TwoLetterIsoCode = "ZA",
                    ThreeLetterIsoCode = "ZAF",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 710,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 208,
                    Name = "South Georgia and the South Sandwich Islands",
                    TwoLetterIsoCode = "GS",
                    ThreeLetterIsoCode = "SGS",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 239,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 209,
                    Name = "South Sudan",
                    TwoLetterIsoCode = "SS",
                    ThreeLetterIsoCode = "SSD",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 728,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 210,
                    Name = "Spain",
                    TwoLetterIsoCode = "ES",
                    ThreeLetterIsoCode = "ESP",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 724,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 211,
                    Name = "Sri Lanka",
                    TwoLetterIsoCode = "LK",
                    ThreeLetterIsoCode = "LKA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 144,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 212,
                    Name = "Sudan",
                    TwoLetterIsoCode = "SD",
                    ThreeLetterIsoCode = "SDN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 729,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 213,
                    Name = "Suriname",
                    TwoLetterIsoCode = "SR",
                    ThreeLetterIsoCode = "SUR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 740,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 214,
                    Name = "Svalbard and Jan Mayen",
                    TwoLetterIsoCode = "SJ",
                    ThreeLetterIsoCode = "SJM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 744,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 215,
                    Name = "Sweden",
                    TwoLetterIsoCode = "SE",
                    ThreeLetterIsoCode = "SWE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 752,
                    SubjectToVat = true,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 216,
                    Name = "Switzerland",
                    TwoLetterIsoCode = "CH",
                    ThreeLetterIsoCode = "CHE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 756,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 217,
                    Name = "Syrian Arab Republic",
                    TwoLetterIsoCode = "SY",
                    ThreeLetterIsoCode = "SYR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 760,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 218,
                    Name = "Taiwan, Province of China",
                    TwoLetterIsoCode = "TW",
                    ThreeLetterIsoCode = "TWN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 158,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 219,
                    Name = "Tajikistan",
                    TwoLetterIsoCode = "TJ",
                    ThreeLetterIsoCode = "TJK",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 762,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 220,
                    Name = "Tanzania, United Republic of",
                    TwoLetterIsoCode = "TZ",
                    ThreeLetterIsoCode = "TZA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 834,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 221,
                    Name = "Thailand",
                    TwoLetterIsoCode = "TH",
                    ThreeLetterIsoCode = "THA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 764,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 222,
                    Name = "Timor-Leste",
                    TwoLetterIsoCode = "TL",
                    ThreeLetterIsoCode = "TLS",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 626,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 223,
                    Name = "Togo",
                    TwoLetterIsoCode = "TG",
                    ThreeLetterIsoCode = "TGO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 768,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 224,
                    Name = "Tokelau",
                    TwoLetterIsoCode = "TK",
                    ThreeLetterIsoCode = "TKL",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 772,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 225,
                    Name = "Tonga",
                    TwoLetterIsoCode = "TO",
                    ThreeLetterIsoCode = "TON",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 776,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 226,
                    Name = "Trinidad and Tobago",
                    TwoLetterIsoCode = "TT",
                    ThreeLetterIsoCode = "TTO",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 780,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 227,
                    Name = "Tunisia",
                    TwoLetterIsoCode = "TN",
                    ThreeLetterIsoCode = "TUN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 788,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 228,
                    Name = "Turkey",
                    TwoLetterIsoCode = "TR",
                    ThreeLetterIsoCode = "TUR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 792,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 229,
                    Name = "Turkmenistan",
                    TwoLetterIsoCode = "TM",
                    ThreeLetterIsoCode = "TKM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 795,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 230,
                    Name = "Turks and Caicos Islands",
                    TwoLetterIsoCode = "TC",
                    ThreeLetterIsoCode = "TCA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 796,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 231,
                    Name = "Tuvalu",
                    TwoLetterIsoCode = "TV",
                    ThreeLetterIsoCode = "TUV",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 798,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 232,
                    Name = "Uganda",
                    TwoLetterIsoCode = "UG",
                    ThreeLetterIsoCode = "UGA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 800,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 233,
                    Name = "Ukraine",
                    TwoLetterIsoCode = "UA",
                    ThreeLetterIsoCode = "UKR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 804,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 234,
                    Name = "United Arab Emirates",
                    TwoLetterIsoCode = "AE",
                    ThreeLetterIsoCode = "ARE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 784,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 235,
                    Name = "United Kingdom of Great Britain and Northern Ireland",
                    TwoLetterIsoCode = "GB",
                    ThreeLetterIsoCode = "GBR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 826,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 236,
                    Name = "United States Minor Outlying Islands",
                    TwoLetterIsoCode = "UM",
                    ThreeLetterIsoCode = "UMI",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 581,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 237,
                    Name = "United States of America",
                    TwoLetterIsoCode = "US",
                    ThreeLetterIsoCode = "USA",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 840,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 1,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 238,
                    Name = "Uruguay",
                    TwoLetterIsoCode = "UY",
                    ThreeLetterIsoCode = "URY",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 858,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 239,
                    Name = "Uzbekistan",
                    TwoLetterIsoCode = "UZ",
                    ThreeLetterIsoCode = "UZB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 860,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 240,
                    Name = "Vanuatu",
                    TwoLetterIsoCode = "VU",
                    ThreeLetterIsoCode = "VUT",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 548,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 241,
                    Name = "Venezuela (Bolivarian Republic of)",
                    TwoLetterIsoCode = "VE",
                    ThreeLetterIsoCode = "VEN",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 862,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 242,
                    Name = "Vietnam",
                    TwoLetterIsoCode = "VN",
                    ThreeLetterIsoCode = "VNM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 704,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 243,
                    Name = "Virgin Islands (British)",
                    TwoLetterIsoCode = "VG",
                    ThreeLetterIsoCode = "VGB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 92,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 244,
                    Name = "Virgin Islands (U.S.)",
                    TwoLetterIsoCode = "VI",
                    ThreeLetterIsoCode = "VIR",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 850,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 245,
                    Name = "Wallis and Futuna",
                    TwoLetterIsoCode = "WF",
                    ThreeLetterIsoCode = "WLF",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 876,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 246,
                    Name = "Western Sahara",
                    TwoLetterIsoCode = "EH",
                    ThreeLetterIsoCode = "ESH",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 732,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 247,
                    Name = "Yemen",
                    TwoLetterIsoCode = "YE",
                    ThreeLetterIsoCode = "YEM",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 887,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 248,
                    Name = "Zambia",
                    TwoLetterIsoCode = "ZM",
                    ThreeLetterIsoCode = "ZMB",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 894,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                },
                new Country()
                {
                    Id = 249,
                    Name = "Zimbabwe",
                    TwoLetterIsoCode = "ZW",
                    ThreeLetterIsoCode = "ZWE",
                    AllowsBilling = true,
                    AllowsShipping = true,
                    NumericIsoCode = 716,
                    SubjectToVat = false,
                    Published = true,
                    DisplayOrder = 100,
                    LimitedToStores = false
                }
            );
            #endregion
        }
    }
}