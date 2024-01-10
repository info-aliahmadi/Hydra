using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hydra.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Country",
                columns: new[] { "Id", "AllowsBilling", "AllowsShipping", "DisplayOrder", "LimitedToStores", "Name", "NumericIsoCode", "Published", "SubjectToVat", "ThreeLetterIsoCode", "TwoLetterIsoCode" },
                values: new object[,]
                {
                    { 1, true, true, 100, false, "Afghanistan", 4, true, false, "AFG", "AF" },
                    { 2, true, true, 100, false, "Åland Islands", 248, true, false, "ALA", "AX" },
                    { 3, true, true, 100, false, "Albania", 8, true, false, "ALB", "AL" },
                    { 4, true, true, 100, false, "Algeria", 12, true, false, "DZA", "DZ" },
                    { 5, true, true, 100, false, "American Samoa", 16, true, false, "ASM", "AS" },
                    { 6, true, true, 100, false, "Andorra", 20, true, false, "AND", "AD" },
                    { 7, true, true, 100, false, "Angola", 24, true, false, "AGO", "AO" },
                    { 8, true, true, 100, false, "Anguilla", 660, true, false, "AIA", "AI" },
                    { 9, true, true, 100, false, "Antarctica", 10, true, false, "ATA", "AQ" },
                    { 10, true, true, 100, false, "Antigua and Barbuda", 28, true, false, "ATG", "AG" },
                    { 11, true, true, 100, false, "Argentina", 32, true, false, "ARG", "AR" },
                    { 12, true, true, 100, false, "Armenia", 51, true, false, "ARM", "AM" },
                    { 13, true, true, 100, false, "Aruba", 533, true, false, "ABW", "AW" },
                    { 14, true, true, 100, false, "Australia", 36, true, false, "AUS", "AU" },
                    { 15, true, true, 100, false, "Austria", 40, true, true, "AUT", "AT" },
                    { 16, true, true, 100, false, "Azerbaijan", 31, true, false, "AZE", "AZ" },
                    { 17, true, true, 100, false, "Bahamas", 44, true, false, "BHS", "BS" },
                    { 18, true, true, 100, false, "Bahrain", 48, true, false, "BHR", "BH" },
                    { 19, true, true, 100, false, "Bangladesh", 50, true, false, "BGD", "BD" },
                    { 20, true, true, 100, false, "Barbados", 52, true, false, "BRB", "BB" },
                    { 21, true, true, 100, false, "Belarus", 112, true, false, "BLR", "BY" },
                    { 22, true, true, 100, false, "Belgium", 56, true, true, "BEL", "BE" },
                    { 23, true, true, 100, false, "Belize", 84, true, false, "BLZ", "BZ" },
                    { 24, true, true, 100, false, "Benin", 204, true, false, "BEN", "BJ" },
                    { 25, true, true, 100, false, "Bermuda", 60, true, false, "BMU", "BM" },
                    { 26, true, true, 100, false, "Bhutan", 64, true, false, "BTN", "BT" },
                    { 27, true, true, 100, false, "Bolivia (Plurinational State of)", 68, true, false, "BOL", "BO" },
                    { 28, true, true, 100, false, "Bonaire, Sint Eustatius and Saba", 535, true, false, "BES", "BQ" },
                    { 29, true, true, 100, false, "Bosnia and Herzegovina", 70, true, false, "BIH", "BA" },
                    { 30, true, true, 100, false, "Botswana", 72, true, false, "BWA", "BW" },
                    { 31, true, true, 100, false, "Bouvet Island", 74, true, false, "BVT", "BV" },
                    { 32, true, true, 100, false, "Brazil", 76, true, false, "BRA", "BR" },
                    { 33, true, true, 100, false, "British Indian Ocean Territory", 86, true, false, "IOT", "IO" },
                    { 34, true, true, 100, false, "Brunei Darussalam", 96, true, false, "BRN", "BN" },
                    { 35, true, true, 100, false, "Bulgaria", 100, true, true, "BGR", "BG" },
                    { 36, true, true, 100, false, "Burkina Faso", 854, true, false, "BFA", "BF" },
                    { 37, true, true, 100, false, "Burundi", 108, true, false, "BDI", "BI" },
                    { 38, true, true, 100, false, "Cabo Verde", 132, true, false, "CPV", "CV" },
                    { 39, true, true, 100, false, "Cambodia", 116, true, false, "KHM", "KH" },
                    { 40, true, true, 100, false, "Cameroon", 120, true, false, "CMR", "CM" },
                    { 41, true, true, 100, false, "Canada", 124, true, false, "CAN", "CA" },
                    { 42, true, true, 100, false, "Cayman Islands", 136, true, false, "CYM", "KY" },
                    { 43, true, true, 100, false, "Central African Republic", 140, true, false, "CAF", "CF" },
                    { 44, true, true, 100, false, "Chad", 148, true, false, "TCD", "TD" },
                    { 45, true, true, 100, false, "Chile", 152, true, false, "CHL", "CL" },
                    { 46, true, true, 100, false, "China", 156, true, false, "CHN", "CN" },
                    { 47, true, true, 100, false, "Christmas Island", 162, true, false, "CXR", "CX" },
                    { 48, true, true, 100, false, "Cocos (Keeling) Islands", 166, true, false, "CCK", "CC" },
                    { 49, true, true, 100, false, "Colombia", 170, true, false, "COL", "CO" },
                    { 50, true, true, 100, false, "Comoros", 174, true, false, "COM", "KM" },
                    { 51, true, true, 100, false, "Congo", 178, true, false, "COG", "CG" },
                    { 52, true, true, 100, false, "Congo (Democratic Republic of the)", 180, true, false, "COD", "CD" },
                    { 53, true, true, 100, false, "Cook Islands", 184, true, false, "COK", "CK" },
                    { 54, true, true, 100, false, "Costa Rica", 188, true, false, "CRI", "CR" },
                    { 55, true, true, 100, false, "Côte d'Ivoire", 384, true, false, "CIV", "CI" },
                    { 56, true, true, 100, false, "Croatia", 191, true, true, "HRV", "HR" },
                    { 57, true, true, 100, false, "Cuba", 192, true, false, "CUB", "CU" },
                    { 58, true, true, 100, false, "Curaçao", 531, true, false, "CUW", "CW" },
                    { 59, true, true, 100, false, "Cyprus", 196, true, true, "CYP", "CY" },
                    { 60, true, true, 100, false, "Czechia", 203, true, true, "CZE", "CZ" },
                    { 61, true, true, 100, false, "Denmark", 208, true, true, "DNK", "DK" },
                    { 62, true, true, 100, false, "Djibouti", 262, true, false, "DJI", "DJ" },
                    { 63, true, true, 100, false, "Dominica", 212, true, false, "DMA", "DM" },
                    { 64, true, true, 100, false, "Dominican Republic", 214, true, false, "DOM", "DO" },
                    { 65, true, true, 100, false, "Ecuador", 218, true, false, "ECU", "EC" },
                    { 66, true, true, 100, false, "Egypt", 818, true, false, "EGY", "EG" },
                    { 67, true, true, 100, false, "El Salvador", 222, true, false, "SLV", "SV" },
                    { 68, true, true, 100, false, "Equatorial Guinea", 226, true, false, "GNQ", "GQ" },
                    { 69, true, true, 100, false, "Eritrea", 232, true, false, "ERI", "ER" },
                    { 70, true, true, 100, false, "Estonia", 233, true, true, "EST", "EE" },
                    { 71, true, true, 100, false, "Eswatini", 748, true, false, "SWZ", "SZ" },
                    { 72, true, true, 100, false, "Ethiopia", 231, true, false, "ETH", "ET" },
                    { 73, true, true, 100, false, "Falkland Islands (Malvinas)", 238, true, false, "FLK", "FK" },
                    { 74, true, true, 100, false, "Faroe Islands", 234, true, false, "FRO", "FO" },
                    { 75, true, true, 100, false, "Fiji", 242, true, false, "FJI", "FJ" },
                    { 76, true, true, 100, false, "Finland", 246, true, true, "FIN", "FI" },
                    { 77, true, true, 100, false, "France", 250, true, true, "FRA", "FR" },
                    { 78, true, true, 100, false, "French Guiana", 254, true, false, "GUF", "GF" },
                    { 79, true, true, 100, false, "French Polynesia", 258, true, false, "PYF", "PF" },
                    { 80, true, true, 100, false, "French Southern Territories", 260, true, false, "ATF", "TF" },
                    { 81, true, true, 100, false, "Gabon", 266, true, false, "GAB", "GA" },
                    { 82, true, true, 100, false, "Gambia", 270, true, false, "GMB", "GM" },
                    { 83, true, true, 100, false, "Georgia", 268, true, false, "GEO", "GE" },
                    { 84, true, true, 100, false, "Germany", 276, true, true, "DEU", "DE" },
                    { 85, true, true, 100, false, "Ghana", 288, true, false, "GHA", "GH" },
                    { 86, true, true, 100, false, "Gibraltar", 292, true, false, "GIB", "GI" },
                    { 87, true, true, 100, false, "Greece", 300, true, true, "GRC", "GR" },
                    { 88, true, true, 100, false, "Greenland", 304, true, false, "GRL", "GL" },
                    { 89, true, true, 100, false, "Grenada", 308, true, false, "GRD", "GD" },
                    { 90, true, true, 100, false, "Guadeloupe", 312, true, false, "GLP", "GP" },
                    { 91, true, true, 100, false, "Guam", 316, true, false, "GUM", "GU" },
                    { 92, true, true, 100, false, "Guatemala", 320, true, false, "GTM", "GT" },
                    { 93, true, true, 100, false, "Guernsey", 831, true, false, "GGY", "GG" },
                    { 94, true, true, 100, false, "Guinea", 324, true, false, "GIN", "GN" },
                    { 95, true, true, 100, false, "Guinea-Bissau", 624, true, false, "GNB", "GW" },
                    { 96, true, true, 100, false, "Guyana", 328, true, false, "GUY", "GY" },
                    { 97, true, true, 100, false, "Haiti", 332, true, false, "HTI", "HT" },
                    { 98, true, true, 100, false, "Heard Island and McDonald Islands", 334, true, false, "HMD", "HM" },
                    { 99, true, true, 100, false, "Holy See", 336, true, false, "VAT", "VA" },
                    { 100, true, true, 100, false, "Honduras", 340, true, false, "HND", "HN" },
                    { 101, true, true, 100, false, "Hong Kong", 344, true, false, "HKG", "HK" },
                    { 102, true, true, 100, false, "Hungary", 348, true, true, "HUN", "HU" },
                    { 103, true, true, 100, false, "Iceland", 352, true, false, "ISL", "IS" },
                    { 104, true, true, 100, false, "India", 356, true, false, "IND", "IN" },
                    { 105, true, true, 100, false, "Indonesia", 360, true, false, "IDN", "ID" },
                    { 106, true, true, 100, false, "Iran (Islamic Republic of)", 364, true, false, "IRN", "IR" },
                    { 107, true, true, 100, false, "Iraq", 368, true, false, "IRQ", "IQ" },
                    { 108, true, true, 100, false, "Ireland", 372, true, true, "IRL", "IE" },
                    { 109, true, true, 100, false, "Isle of Man", 833, true, false, "IMN", "IM" },
                    { 110, true, true, 100, false, "Israel", 376, true, false, "ISR", "IL" },
                    { 111, true, true, 100, false, "Italy", 380, true, true, "ITA", "IT" },
                    { 112, true, true, 100, false, "Jamaica", 388, true, false, "JAM", "JM" },
                    { 113, true, true, 100, false, "Japan", 392, true, false, "JPN", "JP" },
                    { 114, true, true, 100, false, "Jersey", 832, true, false, "JEY", "JE" },
                    { 115, true, true, 100, false, "Jordan", 400, true, false, "JOR", "JO" },
                    { 116, true, true, 100, false, "Kazakhstan", 398, true, false, "KAZ", "KZ" },
                    { 117, true, true, 100, false, "Kenya", 404, true, false, "KEN", "KE" },
                    { 118, true, true, 100, false, "Kiribati", 296, true, false, "KIR", "KI" },
                    { 119, true, true, 100, false, "Korea (Democratic People's Republic of)", 408, true, false, "PRK", "KP" },
                    { 120, true, true, 100, false, "Korea (Republic of)", 410, true, false, "KOR", "KR" },
                    { 121, true, true, 100, false, "Kuwait", 414, true, false, "KWT", "KW" },
                    { 122, true, true, 100, false, "Kyrgyzstan", 417, true, false, "KGZ", "KG" },
                    { 123, true, true, 100, false, "Lao People's Democratic Republic", 418, true, false, "LAO", "LA" },
                    { 124, true, true, 100, false, "Latvia", 428, true, true, "LVA", "LV" },
                    { 125, true, true, 100, false, "Lebanon", 422, true, false, "LBN", "LB" },
                    { 126, true, true, 100, false, "Lesotho", 426, true, false, "LSO", "LS" },
                    { 127, true, true, 100, false, "Liberia", 430, true, false, "LBR", "LR" },
                    { 128, true, true, 100, false, "Libya", 434, true, false, "LBY", "LY" },
                    { 129, true, true, 100, false, "Liechtenstein", 438, true, false, "LIE", "LI" },
                    { 130, true, true, 100, false, "Lithuania", 440, true, true, "LTU", "LT" },
                    { 131, true, true, 100, false, "Luxembourg", 442, true, true, "LUX", "LU" },
                    { 132, true, true, 100, false, "Macao", 446, true, false, "MAC", "MO" },
                    { 133, true, true, 100, false, "North Macedonia", 807, true, false, "MKD", "MK" },
                    { 134, true, true, 100, false, "Madagascar", 450, true, false, "MDG", "MG" },
                    { 135, true, true, 100, false, "Malawi", 454, true, false, "MWI", "MW" },
                    { 136, true, true, 100, false, "Malaysia", 458, true, false, "MYS", "MY" },
                    { 137, true, true, 100, false, "Maldives", 462, true, false, "MDV", "MV" },
                    { 138, true, true, 100, false, "Mali", 466, true, false, "MLI", "ML" },
                    { 139, true, true, 100, false, "Malta", 470, true, true, "MLT", "MT" },
                    { 140, true, true, 100, false, "Marshall Islands", 584, true, false, "MHL", "MH" },
                    { 141, true, true, 100, false, "Martinique", 474, true, false, "MTQ", "MQ" },
                    { 142, true, true, 100, false, "Mauritania", 478, true, false, "MRT", "MR" },
                    { 143, true, true, 100, false, "Mauritius", 480, true, false, "MUS", "MU" },
                    { 144, true, true, 100, false, "Mayotte", 175, true, false, "MYT", "YT" },
                    { 145, true, true, 100, false, "Mexico", 484, true, false, "MEX", "MX" },
                    { 146, true, true, 100, false, "Micronesia (Federated States of)", 583, true, false, "FSM", "FM" },
                    { 147, true, true, 100, false, "Moldova (Republic of)", 498, true, false, "MDA", "MD" },
                    { 148, true, true, 100, false, "Monaco", 492, true, false, "MCO", "MC" },
                    { 149, true, true, 100, false, "Mongolia", 496, true, false, "MNG", "MN" },
                    { 150, true, true, 100, false, "Montenegro", 499, true, false, "MNE", "ME" },
                    { 151, true, true, 100, false, "Montserrat", 500, true, false, "MSR", "MS" },
                    { 152, true, true, 100, false, "Morocco", 504, true, false, "MAR", "MA" },
                    { 153, true, true, 100, false, "Mozambique", 508, true, false, "MOZ", "MZ" },
                    { 154, true, true, 100, false, "Myanmar", 104, true, false, "MMR", "MM" },
                    { 155, true, true, 100, false, "Namibia", 516, true, false, "NAM", "NA" },
                    { 156, true, true, 100, false, "Nauru", 520, true, false, "NRU", "NR" },
                    { 157, true, true, 100, false, "Nepal", 524, true, false, "NPL", "NP" },
                    { 158, true, true, 100, false, "Netherlands", 528, true, true, "NLD", "NL" },
                    { 159, true, true, 100, false, "New Caledonia", 540, true, false, "NCL", "NC" },
                    { 160, true, true, 100, false, "New Zealand", 554, true, false, "NZL", "NZ" },
                    { 161, true, true, 100, false, "Nicaragua", 558, true, false, "NIC", "NI" },
                    { 162, true, true, 100, false, "Niger", 562, true, false, "NER", "NE" },
                    { 163, true, true, 100, false, "Nigeria", 566, true, false, "NGA", "NG" },
                    { 164, true, true, 100, false, "Niue", 570, true, false, "NIU", "NU" },
                    { 165, true, true, 100, false, "Norfolk Island", 574, true, false, "NFK", "NF" },
                    { 166, true, true, 100, false, "Northern Mariana Islands", 580, true, false, "MNP", "MP" },
                    { 167, true, true, 100, false, "Norway", 578, true, false, "NOR", "NO" },
                    { 168, true, true, 100, false, "Oman", 512, true, false, "OMN", "OM" },
                    { 169, true, true, 100, false, "Pakistan", 586, true, false, "PAK", "PK" },
                    { 170, true, true, 100, false, "Palau", 585, true, false, "PLW", "PW" },
                    { 171, true, true, 100, false, "Palestine, State of", 275, true, false, "PSE", "PS" },
                    { 172, true, true, 100, false, "Panama", 591, true, false, "PAN", "PA" },
                    { 173, true, true, 100, false, "Papua New Guinea", 598, true, false, "PNG", "PG" },
                    { 174, true, true, 100, false, "Paraguay", 600, true, false, "PRY", "PY" },
                    { 175, true, true, 100, false, "Peru", 604, true, false, "PER", "PE" },
                    { 176, true, true, 100, false, "Philippines", 608, true, false, "PHL", "PH" },
                    { 177, true, true, 100, false, "Pitcairn", 612, true, false, "PCN", "PN" },
                    { 178, true, true, 100, false, "Poland", 616, true, true, "POL", "PL" },
                    { 179, true, true, 100, false, "Portugal", 620, true, true, "PRT", "PT" },
                    { 180, true, true, 100, false, "Puerto Rico", 630, true, false, "PRI", "PR" },
                    { 181, true, true, 100, false, "Qatar", 634, true, false, "QAT", "QA" },
                    { 182, true, true, 100, false, "Réunion", 638, true, false, "REU", "RE" },
                    { 183, true, true, 100, false, "Romania", 642, true, true, "ROU", "RO" },
                    { 184, true, true, 100, false, "Russian Federation", 643, true, false, "RUS", "RU" },
                    { 185, true, true, 100, false, "Rwanda", 646, true, false, "RWA", "RW" },
                    { 186, true, true, 100, false, "Saint Barthélemy", 652, true, false, "BLM", "BL" },
                    { 187, true, true, 100, false, "Saint Helena, Ascension and Tristan da Cunha", 654, true, false, "SHN", "SH" },
                    { 188, true, true, 100, false, "Saint Kitts and Nevis", 659, true, false, "KNA", "KN" },
                    { 189, true, true, 100, false, "Saint Lucia", 662, true, false, "LCA", "LC" },
                    { 190, true, true, 100, false, "Saint Martin (French part)", 663, true, false, "MAF", "MF" },
                    { 191, true, true, 100, false, "Saint Pierre and Miquelon", 666, true, false, "SPM", "PM" },
                    { 192, true, true, 100, false, "Saint Vincent and the Grenadines", 670, true, false, "VCT", "VC" },
                    { 193, true, true, 100, false, "Samoa", 882, true, false, "WSM", "WS" },
                    { 194, true, true, 100, false, "San Marino", 674, true, false, "SMR", "SP" },
                    { 195, true, true, 100, false, "Sao Tome and Principe", 678, true, false, "STP", "ST" },
                    { 196, true, true, 100, false, "Saudi Arabia", 682, true, false, "SAU", "SA" },
                    { 197, true, true, 100, false, "Senegal", 686, true, false, "SEN", "SN" },
                    { 198, true, true, 100, false, "Serbia", 688, true, false, "SRB", "RS" },
                    { 199, true, true, 100, false, "Seychelles", 690, true, false, "SYC", "SC" },
                    { 200, true, true, 100, false, "Sierra Leone", 694, true, false, "SLE", "SL" },
                    { 201, true, true, 100, false, "Singapore", 702, true, false, "SGP", "SG" },
                    { 202, true, true, 100, false, "Sint Maarten (Dutch part)", 534, true, false, "SXM", "SX" },
                    { 203, true, true, 100, false, "Slovakia", 703, true, true, "SVK", "SK" },
                    { 204, true, true, 100, false, "Slovenia", 705, true, true, "SVN", "SI" },
                    { 205, true, true, 100, false, "Solomon Islands", 90, true, false, "SLB", "SB" },
                    { 206, true, true, 100, false, "Somalia", 706, true, false, "SOM", "SO" },
                    { 207, true, true, 100, false, "South Africa", 710, true, false, "ZAF", "ZA" },
                    { 208, true, true, 100, false, "South Georgia and the South Sandwich Islands", 239, true, false, "SGS", "GS" },
                    { 209, true, true, 100, false, "South Sudan", 728, true, false, "SSD", "SS" },
                    { 210, true, true, 100, false, "Spain", 724, true, true, "ESP", "ES" },
                    { 211, true, true, 100, false, "Sri Lanka", 144, true, false, "LKA", "LK" },
                    { 212, true, true, 100, false, "Sudan", 729, true, false, "SDN", "SD" },
                    { 213, true, true, 100, false, "Suriname", 740, true, false, "SUR", "SR" },
                    { 214, true, true, 100, false, "Svalbard and Jan Mayen", 744, true, false, "SJM", "SJ" },
                    { 215, true, true, 100, false, "Sweden", 752, true, true, "SWE", "SE" },
                    { 216, true, true, 100, false, "Switzerland", 756, true, false, "CHE", "CH" },
                    { 217, true, true, 100, false, "Syrian Arab Republic", 760, true, false, "SYR", "SY" },
                    { 218, true, true, 100, false, "Taiwan, Province of China", 158, true, false, "TWN", "TW" },
                    { 219, true, true, 100, false, "Tajikistan", 762, true, false, "TJK", "TJ" },
                    { 220, true, true, 100, false, "Tanzania, United Republic of", 834, true, false, "TZA", "TZ" },
                    { 221, true, true, 100, false, "Thailand", 764, true, false, "THA", "TH" },
                    { 222, true, true, 100, false, "Timor-Leste", 626, true, false, "TLS", "TL" },
                    { 223, true, true, 100, false, "Togo", 768, true, false, "TGO", "TG" },
                    { 224, true, true, 100, false, "Tokelau", 772, true, false, "TKL", "TK" },
                    { 225, true, true, 100, false, "Tonga", 776, true, false, "TON", "TO" },
                    { 226, true, true, 100, false, "Trinidad and Tobago", 780, true, false, "TTO", "TT" },
                    { 227, true, true, 100, false, "Tunisia", 788, true, false, "TUN", "TN" },
                    { 228, true, true, 100, false, "Turkey", 792, true, false, "TUR", "TR" },
                    { 229, true, true, 100, false, "Turkmenistan", 795, true, false, "TKM", "TM" },
                    { 230, true, true, 100, false, "Turks and Caicos Islands", 796, true, false, "TCA", "TC" },
                    { 231, true, true, 100, false, "Tuvalu", 798, true, false, "TUV", "TV" },
                    { 232, true, true, 100, false, "Uganda", 800, true, false, "UGA", "UG" },
                    { 233, true, true, 100, false, "Ukraine", 804, true, false, "UKR", "UA" },
                    { 234, true, true, 100, false, "United Arab Emirates", 784, true, false, "ARE", "AE" },
                    { 235, true, true, 100, false, "United Kingdom of Great Britain and Northern Ireland", 826, true, false, "GBR", "GB" },
                    { 236, true, true, 100, false, "United States Minor Outlying Islands", 581, true, false, "UMI", "UM" },
                    { 237, true, true, 1, false, "United States of America", 840, true, false, "USA", "US" },
                    { 238, true, true, 100, false, "Uruguay", 858, true, false, "URY", "UY" },
                    { 239, true, true, 100, false, "Uzbekistan", 860, true, false, "UZB", "UZ" },
                    { 240, true, true, 100, false, "Vanuatu", 548, true, false, "VUT", "VU" },
                    { 241, true, true, 100, false, "Venezuela (Bolivarian Republic of)", 862, true, false, "VEN", "VE" },
                    { 242, true, true, 100, false, "Vietnam", 704, true, false, "VNM", "VN" },
                    { 243, true, true, 100, false, "Virgin Islands (British)", 92, true, false, "VGB", "VG" },
                    { 244, true, true, 100, false, "Virgin Islands (U.S.)", 850, true, false, "VIR", "VI" },
                    { 245, true, true, 100, false, "Wallis and Futuna", 876, true, false, "WLF", "WF" },
                    { 246, true, true, 100, false, "Western Sahara", 732, true, false, "ESH", "EH" },
                    { 247, true, true, 100, false, "Yemen", 887, true, false, "YEM", "YE" },
                    { 248, true, true, 100, false, "Zambia", 894, true, false, "ZMB", "ZM" },
                    { 249, true, true, 100, false, "Zimbabwe", 716, true, false, "ZWE", "ZW" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Currency",
                columns: new[] { "Id", "CreatedOnUtc", "CurrencyCode", "CustomFormatting", "DisplayLocale", "DisplayOrder", "LimitedToStores", "Name", "Published", "Rate", "RoundingTypeId", "UpdatedOnUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8977), "USD", "", "en-US", 1, false, "US Dollar", true, 1m, 0, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8979) },
                    { 2, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8982), "EUR", "€0.00", "", 2, false, "Euro", true, 0.86m, 0, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8982) },
                    { 3, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8985), "Rial", "", "fa-IR", 3, false, "Iranian", true, 1m, 0, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Utc).AddTicks(8985) }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "DeliveryDate",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "1-2 days" },
                    { 2, 2, "3-5 days" },
                    { 3, 3, "1 week" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "ShippingMethod",
                columns: new[] { "Id", "Description", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, "Shipping by land transport", 1, "Ground" },
                    { 2, "The one day air shipping", 2, "Next Day Air" },
                    { 3, "The two day air shipping", 3, "2nd Day Air" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "StateProvince",
                columns: new[] { "Id", "Abbreviation", "CountryId", "DisplayOrder", "Name", "Published" },
                values: new object[,]
                {
                    { 1, "", 12, 0, "Երևան", true },
                    { 2, "", 12, 1, "Արարատի մարզ", true },
                    { 3, "", 12, 2, "Արմավիրի մարզ", true },
                    { 4, "", 12, 3, "Կոտայքի մարզ", true },
                    { 5, "", 12, 4, "Արագածոտնի մարտ", true },
                    { 6, "", 12, 5, "Գեղարքունիքի մարզ", true },
                    { 7, "", 12, 6, "Շիրակի մարզ", true },
                    { 8, "", 12, 7, "Լոռու մարզ", true },
                    { 9, "", 12, 8, "Վայոց ձորի մարզ", true },
                    { 10, "", 12, 9, "Սյունիքի մարզ", true },
                    { 11, "", 12, 10, "Տավուշի մարզ", true },
                    { 12, "CABA", 11, 1, "Ciudad Autonoma de Buenos Aires", true },
                    { 13, "BA", 11, 2, "Buenos Aires", true },
                    { 14, "CA", 11, 3, "Catamarca", true },
                    { 15, "CH", 11, 3, "Chaco", true },
                    { 16, "CT", 11, 3, "Chubut", true },
                    { 17, "CB", 11, 3, "Cordoba", true },
                    { 18, "CR", 11, 3, "Corrientes", true },
                    { 19, "ER", 11, 3, "Entre Rios", true },
                    { 20, "FO", 11, 3, "Formosa", true },
                    { 21, "JY", 11, 3, "Jujuy", true },
                    { 22, "LP", 11, 3, "La Pampa", true },
                    { 23, "LR", 11, 3, "La Rioja", true },
                    { 24, "MZ", 11, 3, "Mendoza", true },
                    { 25, "MI", 11, 3, "Misiones", true },
                    { 26, "NQ", 11, 3, "Neuquen", true },
                    { 27, "RN", 11, 3, "Rio Negro", true },
                    { 28, "SA", 11, 3, "Salta", true },
                    { 29, "SJ", 11, 3, "San Juan", true },
                    { 30, "SL", 11, 3, "San Luis", true },
                    { 31, "SC", 11, 3, "Santa Cruz", true },
                    { 32, "SF", 11, 3, "Santa Fe", true },
                    { 33, "SE", 11, 3, "Santiago del Estero", true },
                    { 34, "TF", 11, 3, "Tierra del Fuego", true },
                    { 35, "TU", 11, 3, "Tucuman", true },
                    { 36, "W", 15, 1, "Wien", true },
                    { 37, "NÖ", 15, 2, "Niederösterreich", true },
                    { 38, "OÖ", 15, 3, "Oberösterreich", true },
                    { 39, "S", 15, 4, "Salzburg", true },
                    { 40, "T", 15, 5, "Tirol", true },
                    { 41, "V", 15, 6, "Vorarlberg", true },
                    { 42, "B", 15, 7, "Burgenland", true },
                    { 43, "ST", 15, 8, "Steiermark", true },
                    { 44, "K", 15, 9, "Kärnten", true },
                    { 45, "", 14, 0, "Australian Capital Territory", true },
                    { 46, "", 14, 0, "New South Wales", true },
                    { 47, "", 14, 0, "Northern Territory", true },
                    { 48, "", 14, 0, "Queensland", true },
                    { 49, "", 14, 0, "South Australia", true },
                    { 50, "", 14, 0, "Tasmania", true },
                    { 51, "", 14, 0, "Victoria", true },
                    { 52, "", 14, 0, "Western Australia", true },
                    { 53, "", 19, 2, "বরগুনা", true },
                    { 54, "", 19, 2, "বরিশাল", true },
                    { 55, "", 19, 2, "ভোলা", true },
                    { 56, "", 19, 2, "ঝালকাঠি", true },
                    { 57, "", 19, 2, "পটুয়াখালী", true },
                    { 58, "", 19, 2, "পিরোজপুর", true },
                    { 59, "", 19, 2, "বান্দরবান", true },
                    { 60, "", 19, 2, "ব্রাহ্মণবাড়ীয়া", true },
                    { 61, "", 19, 2, "চাঁদপুর", true },
                    { 62, "", 19, 2, "চট্টগ্রাম", true },
                    { 63, "", 19, 2, "কুমিল্লা", true },
                    { 64, "", 19, 2, "কক্সবাজার", true },
                    { 65, "", 19, 2, "ফেনী", true },
                    { 66, "", 19, 2, "খাগড়াছড়ি", true },
                    { 67, "", 19, 2, "লক্ষ্মীপুর", true },
                    { 68, "", 19, 2, "নোয়াখালী", true },
                    { 69, "", 19, 2, "রাঙ্গামাটি", true },
                    { 70, "", 19, 1, "ঢাকা", true },
                    { 71, "", 19, 2, "ফরিদপুর", true },
                    { 72, "", 19, 2, "গাজীপুর", true },
                    { 73, "", 19, 2, "গোপালগঞ্জ", true },
                    { 74, "", 19, 2, "কিশোরগঞ্জ", true },
                    { 75, "", 19, 2, "মাদারীপুর", true },
                    { 76, "", 19, 2, "মানিকগঞ্জ", true },
                    { 77, "", 19, 2, "মুন্সীগঞ্জ", true },
                    { 78, "", 19, 2, "নারায়ণগঞ্জ", true },
                    { 79, "", 19, 2, "নরসিংদী", true },
                    { 80, "", 19, 2, "রাজবাড়ী", true },
                    { 81, "", 19, 2, "শরীয়তপুর", true },
                    { 82, "", 19, 2, "টাঙ্গাইল", true },
                    { 83, "", 19, 2, "বাগেরহাট", true },
                    { 84, "", 19, 2, "চুয়াডাঙ্গা", true },
                    { 85, "", 19, 2, "যশোর", true },
                    { 86, "", 19, 2, "ঝিনাইদহ", true },
                    { 87, "", 19, 2, "খুলনা", true },
                    { 88, "", 19, 2, "কুষ্টিয়া", true },
                    { 89, "", 19, 2, "মাগুরা", true },
                    { 90, "", 19, 2, "মেহেরপুর", true },
                    { 91, "", 19, 2, "নড়াইল", true },
                    { 92, "", 19, 2, "সাতক্ষিরা", true },
                    { 93, "", 19, 2, "জামালপুর", true },
                    { 94, "", 19, 2, "ময়মনসিংহ", true },
                    { 95, "", 19, 2, "নেত্রকোনা", true },
                    { 96, "", 19, 2, "শেরপুর", true },
                    { 97, "", 19, 2, "বগুড়া", true },
                    { 98, "", 19, 2, "জয়পুরহাট", true },
                    { 99, "", 19, 2, "নওগাঁ", true },
                    { 100, "", 19, 2, "নাটোর", true },
                    { 101, "", 19, 2, "চাঁপাই নবাবগঞ্জ", true },
                    { 102, "", 19, 2, "পাবনা", true },
                    { 103, "", 19, 2, "রাজশাহী", true },
                    { 104, "", 19, 2, "সিরাজগঞ্জ", true },
                    { 105, "", 19, 2, "দিনাজপুর", true },
                    { 106, "", 19, 2, "গাইবান্ধা", true },
                    { 107, "", 19, 2, "কুড়িগ্রাম", true },
                    { 108, "", 19, 2, "লালমনিরহাট", true },
                    { 109, "", 19, 2, "নীলফামারী", true },
                    { 110, "", 19, 2, "পঞ্চগড়", true },
                    { 111, "", 19, 2, "রংপুর", true },
                    { 112, "", 19, 2, "ঠাকুরগাঁও", true },
                    { 113, "", 19, 2, "হবিগঞ্জ", true },
                    { 114, "", 19, 2, "মৌলভীবাজার", true },
                    { 115, "", 19, 2, "সুনামগঞ্জ", true },
                    { 116, "", 19, 2, "সিলেট", true },
                    { 117, "ANT", 22, 0, "Antwerpen", true },
                    { 118, "VBR", 22, 0, "Brabant wallon", true },
                    { 119, "HAI", 22, 0, "Hainaut", true },
                    { 120, "LIE", 22, 0, "Liège", true },
                    { 121, "LIM", 22, 0, "Limburg", true },
                    { 122, "LUX", 22, 0, "Luxembourg", true },
                    { 123, "NAM", 22, 0, "Namur", true },
                    { 124, "OVL", 22, 0, "Oost-Vlaanderen", true },
                    { 125, "VBR", 22, 0, "Vlaams-Brabant", true },
                    { 126, "WVL", 22, 0, "West-Vlaanderen", true },
                    { 127, "", 35, 0, "Blagoevgrad", true },
                    { 128, "", 35, 0, "Burgas", true },
                    { 129, "", 35, 0, "Dobrich", true },
                    { 130, "", 35, 0, "Gabrovo", true },
                    { 131, "", 35, 0, "Haskovo", true },
                    { 132, "", 35, 0, "Kardzhali", true },
                    { 133, "", 35, 0, "Kyustendil", true },
                    { 134, "", 35, 0, "Lovech", true },
                    { 135, "", 35, 0, "Montana", true },
                    { 136, "", 35, 0, "Pazardzhik", true },
                    { 137, "", 35, 0, "Pernik", true },
                    { 138, "", 35, 0, "Pleven", true },
                    { 139, "", 35, 0, "Plovdiv", true },
                    { 140, "", 35, 0, "Razgrad", true },
                    { 141, "", 35, 0, "Ruse", true },
                    { 142, "", 35, 0, "Shumen", true },
                    { 143, "", 35, 0, "Silistra", true },
                    { 144, "", 35, 0, "Sliven", true },
                    { 145, "", 35, 0, "Smolyan", true },
                    { 146, "", 35, 0, "Sofia", true },
                    { 147, "", 35, 0, "Sofia city", true },
                    { 148, "", 35, 0, "Stara Zagora", true },
                    { 149, "", 35, 0, "Targovishte", true },
                    { 150, "", 35, 0, "Varna", true },
                    { 151, "", 35, 0, "Veliko Tarnovo", true },
                    { 152, "", 35, 0, "Vidin", true },
                    { 153, "", 35, 0, "Vratsa", true },
                    { 154, "", 35, 0, "Yambol", true },
                    { 155, "", 34, 1, "Belait", true },
                    { 156, "", 34, 2, "Brunei-Muara", true },
                    { 157, "", 34, 3, "Temburong", true },
                    { 158, "", 34, 4, "Tutong", true },
                    { 159, "AC", 32, 0, "Acre", true },
                    { 160, "AL", 32, 0, "Alagoas", true },
                    { 161, "AP", 32, 0, "Amapá", true },
                    { 162, "AM", 32, 0, "Amazonas", true },
                    { 163, "BA", 32, 0, "Bahia", true },
                    { 164, "CE", 32, 0, "Ceará", true },
                    { 165, "DF", 32, 0, "Distrito Federal", true },
                    { 166, "ES", 32, 0, "Espírito Santo", true },
                    { 167, "GO", 32, 0, "Goiás", true },
                    { 168, "MA", 32, 0, "Maranhão", true },
                    { 169, "MT", 32, 0, "Mato Grosso", true },
                    { 170, "MS", 32, 0, "Mato Grosso do Sul", true },
                    { 171, "MG", 32, 0, "Minas Gerais", true },
                    { 172, "PA", 32, 0, "Pará", true },
                    { 173, "PB", 32, 0, "Paraíba", true },
                    { 174, "PR", 32, 0, "Paraná", true },
                    { 175, "PE", 32, 0, "Pernambuco", true },
                    { 176, "PI", 32, 0, "Piauí", true },
                    { 177, "RJ", 32, 0, "Rio de Janeiro", true },
                    { 178, "RN", 32, 0, "Rio Grande do Norte", true },
                    { 179, "RS", 32, 0, "Rio Grande do Sul", true },
                    { 180, "RO", 32, 0, "Rondônia", true },
                    { 181, "RR", 32, 0, "Roraima", true },
                    { 182, "SC", 32, 0, "Santa Catarina", true },
                    { 183, "SP", 32, 0, "São Paulo", true },
                    { 184, "SE", 32, 0, "Sergipe", true },
                    { 185, "TO", 32, 0, "Tocantins", true },
                    { 186, "1", 21, 1, "Брестская область", true },
                    { 187, "2", 21, 1, "Витебская область", true },
                    { 188, "3", 21, 1, "Гомельская область", true },
                    { 189, "4", 21, 1, "Гродненская область", true },
                    { 190, "5", 21, 1, "Минская область", true },
                    { 191, "6", 21, 1, "Могилёвская область", true },
                    { 192, "7", 21, 1, "Минск", true },
                    { 193, "AB", 41, 1, "Alberta", true },
                    { 194, "BC", 41, 1, "British Columbia", true },
                    { 195, "MB", 41, 1, "Manitoba", true },
                    { 196, "NB", 41, 1, "New Brunswick", true },
                    { 197, "NL", 41, 1, "Newfoundland and Labrador", true },
                    { 198, "NT", 41, 1, "Northwest Territories", true },
                    { 199, "NS", 41, 1, "Nova Scotia", true },
                    { 200, "NU", 41, 1, "Nunavut", true },
                    { 201, "ON", 41, 1, "Ontario", true },
                    { 202, "PE", 41, 1, "Prince Edward Island", true },
                    { 203, "QC", 41, 1, "Quebec", true },
                    { 204, "SK", 41, 1, "Saskatchewan", true },
                    { 205, "YU", 41, 1, "Yukon Territory", true },
                    { 206, "AG", 216, 0, "Aargau", true },
                    { 207, "AR", 216, 0, "Appenzell Ausserrhoden", true },
                    { 208, "AI", 216, 0, "Appenzell Innerrhoden", true },
                    { 209, "BL", 216, 0, "Basel-Landschaft", true },
                    { 210, "BS", 216, 0, "Basel-Stadt", true },
                    { 211, "BE", 216, 0, "Bern", true },
                    { 212, "FR", 216, 0, "Fribourg/Freiburg", true },
                    { 213, "GE", 216, 0, "Genève", true },
                    { 214, "GL", 216, 0, "Glarus", true },
                    { 215, "GR", 216, 0, "Graubünden/Grischun", true },
                    { 216, "JU", 216, 0, "Jura", true },
                    { 217, "LU", 216, 0, "Luzern", true },
                    { 218, "NE", 216, 0, "Neuchâtel", true },
                    { 219, "NW", 216, 0, "Nidwalden", true },
                    { 220, "OW", 216, 0, "Obwalden", true },
                    { 221, "SH", 216, 0, "Schaffhausen", true },
                    { 222, "SZ", 216, 0, "Schwyz", true },
                    { 223, "SO", 216, 0, "Solothurn", true },
                    { 224, "SG", 216, 0, "St. Gallen", true },
                    { 225, "TI", 216, 0, "Ticino", true },
                    { 226, "TG", 216, 0, "Thurgau", true },
                    { 227, "UR", 216, 0, "Uri", true },
                    { 228, "VD", 216, 0, "Vaud", true },
                    { 229, "VS", 216, 0, "Valais/Wallis", true },
                    { 230, "ZG", 216, 0, "Zug", true },
                    { 231, "ZH", 216, 0, "Zürich", true },
                    { 232, "北京市", 46, 1, "北京市", true },
                    { 233, "天津市", 46, 2, "天津市", true },
                    { 234, "河北省", 46, 3, "河北省", true },
                    { 235, "山西省", 46, 4, "山西省", true },
                    { 236, "内蒙古自治区", 46, 5, "内蒙古自治区", true },
                    { 237, "辽宁省", 46, 6, "辽宁省", true },
                    { 238, "吉林省", 46, 7, "吉林省", true },
                    { 239, "黑龙江省", 46, 8, "黑龙江省", true },
                    { 240, "上海市", 46, 9, "上海市", true },
                    { 241, "江苏省", 46, 10, "江苏省", true },
                    { 242, "浙江省", 46, 11, "浙江省", true },
                    { 243, "安徽省", 46, 12, "安徽省", true },
                    { 244, "福建省", 46, 13, "福建省", true },
                    { 245, "江西省", 46, 14, "江西省", true },
                    { 246, "山东省", 46, 15, "山东省", true },
                    { 247, "河南省", 46, 16, "河南省", true },
                    { 248, "湖北省", 46, 17, "湖北省", true },
                    { 249, "湖南省", 46, 18, "湖南省", true },
                    { 250, "广东省", 46, 19, "广东省", true },
                    { 251, "广西壮族自治区", 46, 20, "广西壮族自治区", true },
                    { 252, "海南省", 46, 21, "海南省", true },
                    { 253, "重庆市", 46, 22, "重庆市", true },
                    { 254, "四川省", 46, 23, "四川省", true },
                    { 255, "贵州省", 46, 24, "贵州省", true },
                    { 256, "云南省", 46, 25, "云南省", true },
                    { 257, "西藏自治区", 46, 26, "西藏自治区", true },
                    { 258, "陕西省", 46, 27, "陕西省", true },
                    { 259, "甘肃省", 46, 28, "甘肃省", true },
                    { 260, "青海省", 46, 29, "青海省", true },
                    { 261, "宁夏回族自治区", 46, 30, "宁夏回族自治区", true },
                    { 262, "新疆维吾尔自治区", 46, 31, "新疆维吾尔自治区", true },
                    { 263, "香港特别行政区", 46, 32, "香港特别行政区", true },
                    { 264, "澳门特别行政区", 46, 33, "澳门特别行政区", true },
                    { 265, "台湾省", 46, 34, "台湾省", true },
                    { 266, "", 49, 0, "Amazonas", true },
                    { 267, "", 49, 0, "Antioquia", true },
                    { 268, "", 49, 0, "Arauca", true },
                    { 269, "", 49, 0, "Atlántico", true },
                    { 270, "", 49, 0, "Bolívar", true },
                    { 271, "", 49, 0, "Boyacá", true },
                    { 272, "", 49, 0, "Caldas", true },
                    { 273, "", 49, 0, "Caquetá", true },
                    { 274, "", 49, 0, "Casanare", true },
                    { 275, "", 49, 0, "Cauca", true },
                    { 276, "", 49, 0, "Cesar", true },
                    { 277, "", 49, 0, "Chocó", true },
                    { 278, "", 49, 0, "Córdoba", true },
                    { 279, "", 49, 0, "Cundinamarca", true },
                    { 280, "", 49, 0, "Guainía", true },
                    { 281, "", 49, 0, "Guaviare", true },
                    { 282, "", 49, 0, "Huila", true },
                    { 283, "", 49, 0, "La Guajira", true },
                    { 284, "", 49, 0, "Magdalena", true },
                    { 285, "", 49, 0, "Meta", true },
                    { 286, "", 49, 0, "Nariño", true },
                    { 287, "", 49, 0, "Norte de Santander", true },
                    { 288, "", 49, 0, "Putumayo", true },
                    { 289, "", 49, 0, "Quindío", true },
                    { 290, "", 49, 0, "Risaralda", true },
                    { 291, "", 49, 0, "San Andrés y Providencia", true },
                    { 292, "", 49, 0, "Santander", true },
                    { 293, "", 49, 0, "Sucre", true },
                    { 294, "", 49, 0, "Tolima", true },
                    { 295, "", 49, 0, "Valle del Cauca", true },
                    { 296, "", 49, 0, "Vaupés", true },
                    { 297, "", 49, 0, "Vichada", true },
                    { 298, "CR-A", 54, 1, "Alajuela", true },
                    { 299, "CR-C", 54, 1, "Cartago", true },
                    { 300, "CR-G", 54, 1, "Guanacaste", true },
                    { 301, "CR-H", 54, 1, "Heredia", true },
                    { 302, "CR-L", 54, 1, "Limón", true },
                    { 303, "CR-P", 54, 1, "Puntarenas", true },
                    { 304, "CR-SJ", 54, 1, "San José", true },
                    { 305, "", 57, 1, "Pinar del Río", true },
                    { 306, "", 57, 2, "Artemisa", true },
                    { 307, "", 57, 3, "La Habana", true },
                    { 308, "", 57, 4, "Mayabeque", true },
                    { 309, "", 57, 5, "Matanzas", true },
                    { 310, "", 57, 6, "Cienfuegos", true },
                    { 311, "", 57, 7, "Villa Clara", true },
                    { 312, "", 57, 8, "Sancti Spíritus", true },
                    { 313, "", 57, 9, "Ciego de Ávila", true },
                    { 314, "", 57, 10, "Camagüey", true },
                    { 315, "", 57, 11, "Las Tunas", true },
                    { 316, "", 57, 12, "Holguín", true },
                    { 317, "", 57, 13, "Granma", true },
                    { 318, "", 57, 14, "Santiago de Cuba", true },
                    { 319, "", 57, 15, "Guantánamo", true },
                    { 320, "", 57, 16, "Isla de la Juventud", true },
                    { 321, "", 59, 0, "Famagusta district", true },
                    { 322, "", 59, 0, "Kyrenia district", true },
                    { 323, "", 59, 0, "Limassol district", true },
                    { 324, "", 59, 0, "Larnaca district", true },
                    { 325, "", 59, 0, "Nicosia district", true },
                    { 326, "", 59, 0, "Paphos district", true },
                    { 327, "", 60, 0, "Hlavní město Praha", true },
                    { 328, "", 60, 0, "Středočeský kraj", true },
                    { 329, "", 60, 0, "Jihočeský kraj", true },
                    { 330, "", 60, 0, "Plzeňský kraj", true },
                    { 331, "", 60, 0, "Karlovarský kraj", true },
                    { 332, "", 60, 0, "Ústecký kraj", true },
                    { 333, "", 60, 0, "Liberecký kraj", true },
                    { 334, "", 60, 0, "Královéhradecký kraj", true },
                    { 335, "", 60, 0, "Pardubický kraj", true },
                    { 336, "", 60, 0, "Kraj Vysočina", true },
                    { 337, "", 60, 0, "Jihomoravský kraj", true },
                    { 338, "", 60, 0, "Olomoucký kraj", true },
                    { 339, "", 60, 0, "Zlínský kraj", true },
                    { 340, "", 60, 0, "Moravskoslezský kraj", true },
                    { 341, "84", 61, 1, "Hovedstaden", true },
                    { 342, "82", 61, 2, "Midtjylland", true },
                    { 343, "81", 61, 3, "Nordjylland", true },
                    { 344, "85", 61, 4, "Sjælland", true },
                    { 345, "83", 61, 5, "Syddanmark", true },
                    { 346, "BW", 84, 0, "Baden-Württemberg", true },
                    { 347, "BY", 84, 0, "Bayern", true },
                    { 348, "BE", 84, 0, "Berlin", true },
                    { 349, "BB", 84, 0, "Brandenburg", true },
                    { 350, "HB", 84, 0, "Bremen", true },
                    { 351, "HH", 84, 0, "Hamburg", true },
                    { 352, "HE", 84, 0, "Hessen", true },
                    { 353, "MV", 84, 0, "Mecklenburg-Vorpommern", true },
                    { 354, "NI", 84, 0, "Niedersachsen", true },
                    { 355, "NW", 84, 0, "Nordrhein-Westfalen", true },
                    { 356, "RP", 84, 0, "Rheinland-Pfalz", true },
                    { 357, "SL", 84, 0, "Saarland", true },
                    { 358, "SN", 84, 0, "Sachsen", true },
                    { 359, "ST", 84, 0, "Sachsen-Anhalt", true },
                    { 360, "SH", 84, 0, "Schleswig-Holstein", true },
                    { 361, "TH", 84, 0, "Thüringen", true },
                    { 362, "37", 70, 1, "Harjumaa", true },
                    { 363, "39", 70, 2, "Hiiumaa", true },
                    { 364, "44", 70, 3, "Ida-Virumaa", true },
                    { 365, "49", 70, 4, "Jõgevamaa", true },
                    { 366, "51", 70, 5, "Järvamaa", true },
                    { 367, "57", 70, 6, "Läänemaa", true },
                    { 368, "59", 70, 7, "Lääne-Virumaa", true },
                    { 369, "65", 70, 8, "Põlvamaa", true },
                    { 370, "67", 70, 9, "Pärnumaa", true },
                    { 371, "70", 70, 10, "Raplamaa", true },
                    { 372, "74", 70, 11, "Saaremaa", true },
                    { 373, "78", 70, 12, "Tartumaa", true },
                    { 374, "82", 70, 13, "Valgamaa", true },
                    { 375, "84", 70, 14, "Viljandimaa", true },
                    { 376, "86", 70, 15, "Võrumaa", true },
                    { 377, "", 66, 1, "Cairo", true },
                    { 378, "", 66, 2, "Alexandria", true },
                    { 379, "", 66, 3, "Ismailia", true },
                    { 380, "", 66, 4, "Aswan", true },
                    { 381, "", 66, 5, "Asyut", true },
                    { 382, "", 66, 6, "Beheira", true },
                    { 383, "", 66, 7, "Beni Suef", true },
                    { 384, "", 66, 8, "Dakahlia", true },
                    { 385, "", 66, 9, "Damietta", true },
                    { 386, "", 66, 10, "Faiyum", true },
                    { 387, "", 66, 11, "Gharbia", true },
                    { 388, "", 66, 12, "Giza", true },
                    { 389, "", 66, 13, "Kafr El Sheikh", true },
                    { 390, "", 66, 14, "Luxor", true },
                    { 391, "", 66, 15, "Matruh", true },
                    { 392, "", 66, 16, "Minya", true },
                    { 393, "", 66, 17, "Monufia", true },
                    { 394, "", 66, 18, "New Valley", true },
                    { 395, "", 66, 19, "North Sinai", true },
                    { 396, "", 66, 20, "Port Said", true },
                    { 397, "", 66, 21, "Qalyubia", true },
                    { 398, "", 66, 22, "Qena", true },
                    { 399, "", 66, 23, "Red Sea", true },
                    { 400, "", 66, 24, "Sharqia", true },
                    { 401, "", 66, 25, "Sohag", true },
                    { 402, "", 66, 26, "South Sinai", true },
                    { 403, "", 66, 27, "Suez", true },
                    { 404, "", 210, 1, "Álava", true },
                    { 405, "", 210, 2, "Albacete", true },
                    { 406, "", 210, 3, "Alicante", true },
                    { 407, "", 210, 4, "Almería", true },
                    { 408, "", 210, 5, "Ávila", true },
                    { 409, "", 210, 6, "Badajoz", true },
                    { 410, "", 210, 7, "Baleares (Illes)", true },
                    { 411, "", 210, 8, "Barcelona", true },
                    { 412, "", 210, 9, "Burgos", true },
                    { 413, "", 210, 10, "Cáceres", true },
                    { 414, "", 210, 11, "Cádiz", true },
                    { 415, "", 210, 12, "Castellón", true },
                    { 416, "", 210, 13, "Ciudad Real", true },
                    { 417, "", 210, 14, "Córdoba", true },
                    { 418, "", 210, 15, "A Coruña", true },
                    { 419, "", 210, 16, "Cuenca", true },
                    { 420, "", 210, 17, "Girona", true },
                    { 421, "", 210, 18, "Granada", true },
                    { 422, "", 210, 19, "Guadalajara", true },
                    { 423, "", 210, 20, "Guipúzcoa", true },
                    { 424, "", 210, 21, "Huelva", true },
                    { 425, "", 210, 22, "Huesca", true },
                    { 426, "", 210, 23, "Jaén", true },
                    { 427, "", 210, 24, "León", true },
                    { 428, "", 210, 25, "Lleida", true },
                    { 429, "", 210, 26, "La Rioja", true },
                    { 430, "", 210, 27, "Lugo", true },
                    { 431, "", 210, 28, "Madrid", true },
                    { 432, "", 210, 29, "Málaga", true },
                    { 433, "", 210, 30, "Murcia", true },
                    { 434, "", 210, 31, "Navarra", true },
                    { 435, "", 210, 32, "Ourense", true },
                    { 436, "", 210, 33, "Asturias", true },
                    { 437, "", 210, 34, "Palencia", true },
                    { 438, "", 210, 35, "Las Palmas", true },
                    { 439, "", 210, 36, "Pontevedra", true },
                    { 440, "", 210, 37, "Salamanca", true },
                    { 441, "", 210, 38, "Santa Cruz de Tenerife", true },
                    { 442, "", 210, 39, "Cantabria", true },
                    { 443, "", 210, 40, "Segovia", true },
                    { 444, "", 210, 41, "Sevilla", true },
                    { 445, "", 210, 42, "Soria", true },
                    { 446, "", 210, 43, "Tarragona", true },
                    { 447, "", 210, 44, "Teruel", true },
                    { 448, "", 210, 45, "Toledo", true },
                    { 449, "", 210, 46, "Valencia", true },
                    { 450, "", 210, 47, "Valladolid", true },
                    { 451, "", 210, 48, "Vizcaya", true },
                    { 452, "", 210, 49, "Zamora", true },
                    { 453, "", 210, 50, "Zaragoza", true },
                    { 454, "", 210, 51, "Ceuta", true },
                    { 455, "", 210, 52, "Melilla", true },
                    { 456, "01", 76, 1, "Ahvenanmaan maakunta/Landskapet Åland", true },
                    { 457, "02", 76, 2, "Etelä-Karjala/Södra Karelen", true },
                    { 458, "03", 76, 3, "Etelä-Pohjanmaa/Södra Österbotten", true },
                    { 459, "04", 76, 4, "Etelä-Savo/Södra Savolax", true },
                    { 460, "05", 76, 5, "Kainuu/Kajanaland", true },
                    { 461, "06", 76, 6, "Kanta-Häme/Egentliga Tavastland", true },
                    { 462, "07", 76, 7, "Keski-Pohjanmaa/Mellersta Österbotten", true },
                    { 463, "08", 76, 8, "Keski-Suomi/Mellersta Finland", true },
                    { 464, "09", 76, 9, "Kymenlaakso/Kymmenedalen", true },
                    { 465, "10", 76, 10, "Lappi/Lappland", true },
                    { 466, "11", 76, 11, "Pirkanmaa/Birkaland", true },
                    { 467, "12", 76, 12, "Pohjanmaa/Österbotten", true },
                    { 468, "13", 76, 13, "Pohjois-Karjala/Norra Karelen", true },
                    { 469, "14", 76, 14, "Pohjois-Pohjanmaa/Norra Österbotten", true },
                    { 470, "15", 76, 15, "Pohjois-Savo/Norra Savolax", true },
                    { 471, "16", 76, 16, "Päijät-Häme/Päijänne-Tavastland", true },
                    { 472, "17", 76, 17, "Satakunta/Satakunda", true },
                    { 473, "18", 76, 18, "Uusimaa/Nyland", true },
                    { 474, "19", 76, 19, "Varsinais-Suomi/Egentliga Finland", true },
                    { 475, "01", 77, 1, "Ain", true },
                    { 476, "02", 77, 2, "Aisne", true },
                    { 477, "03", 77, 3, "Allier", true },
                    { 478, "04", 77, 4, "Alpes de Hautes-Provence", true },
                    { 479, "05", 77, 5, "Alpes (Hautes)", true },
                    { 480, "06", 77, 6, "Alpes Maritimes", true },
                    { 481, "07", 77, 7, "Ardèche", true },
                    { 482, "08", 77, 8, "Ardennes", true },
                    { 483, "09", 77, 9, "Ariège", true },
                    { 484, "10", 77, 10, "Aube", true },
                    { 485, "11", 77, 11, "Aude", true },
                    { 486, "12", 77, 12, "Aveyron", true },
                    { 487, "13", 77, 13, "Bouches du Rhône", true },
                    { 488, "14", 77, 14, "Calvados", true },
                    { 489, "15", 77, 15, "Cantal", true },
                    { 490, "16", 77, 16, "Charente", true },
                    { 491, "17", 77, 17, "Charente Maritime", true },
                    { 492, "18", 77, 18, "Cher", true },
                    { 493, "19", 77, 19, "Corrèze", true },
                    { 494, "2A", 77, 20, "Corse du sud", true },
                    { 495, "2B", 77, 21, "Haute corse", true },
                    { 496, "21", 77, 22, "Côte-d'Or", true },
                    { 497, "22", 77, 24, "Côtes d'Armor", true },
                    { 498, "23", 77, 26, "Creuse", true },
                    { 499, "24", 77, 27, "Dordogne", true },
                    { 500, "25", 77, 28, "Doubs", true },
                    { 501, "26", 77, 29, "Drôme", true },
                    { 502, "27", 77, 30, "Eure", true },
                    { 503, "28", 77, 31, "Eure et Loir", true },
                    { 504, "29", 77, 32, "Finistère", true },
                    { 505, "30", 77, 33, "Gard", true },
                    { 506, "31", 77, 34, "Garonne (Haute)", true },
                    { 507, "32", 77, 35, "Gers", true },
                    { 508, "33", 77, 36, "Gironde", true },
                    { 509, "34", 77, 37, "Hérault", true },
                    { 510, "35", 77, 38, "Ille et Vilaine", true },
                    { 511, "36", 77, 39, "Indre", true },
                    { 512, "37", 77, 40, "Indre et Loire", true },
                    { 513, "38", 77, 41, "Isère", true },
                    { 514, "39", 77, 42, "Jura", true },
                    { 515, "40", 77, 43, "Landes", true },
                    { 516, "41", 77, 44, "Loir et Cher", true },
                    { 517, "42", 77, 45, "Loire", true },
                    { 518, "43", 77, 46, "Loire (Haute)", true },
                    { 519, "44", 77, 47, "Loire Atlantique", true },
                    { 520, "45", 77, 48, "Loiret", true },
                    { 521, "46", 77, 49, "Lot", true },
                    { 522, "47", 77, 50, "Lot et Garonne", true },
                    { 523, "48", 77, 51, "Lozère", true },
                    { 524, "49", 77, 52, "Maine et Loire", true },
                    { 525, "50", 77, 53, "Manche", true },
                    { 526, "51", 77, 54, "Marne", true },
                    { 527, "52", 77, 55, "Marne (Haute)", true },
                    { 528, "53", 77, 56, "Mayenne", true },
                    { 529, "54", 77, 57, "Meurthe et Moselle", true },
                    { 530, "55", 77, 58, "Meuse", true },
                    { 531, "56", 77, 59, "Morbihan", true },
                    { 532, "57", 77, 60, "Moselle", true },
                    { 533, "58", 77, 61, "Nièvre", true },
                    { 534, "59", 77, 62, "Nord", true },
                    { 535, "60", 77, 63, "Oise", true },
                    { 536, "61", 77, 64, "Orne", true },
                    { 537, "62", 77, 65, "Pas de Calais", true },
                    { 538, "63", 77, 66, "Puy de Dôme", true },
                    { 539, "64", 77, 67, "Pyrénées Atlantiques", true },
                    { 540, "65", 77, 68, "Pyrénées (Hautes)", true },
                    { 541, "66", 77, 69, "Pyrénées Orientales", true },
                    { 542, "67", 77, 70, "Rhin (Bas)", true },
                    { 543, "68", 77, 71, "Rhin (Haut)", true },
                    { 544, "69", 77, 72, "Rhône", true },
                    { 545, "70", 77, 73, "Saône (Haute)", true },
                    { 546, "71", 77, 74, "Saône et Loire", true },
                    { 547, "72", 77, 75, "Sarthe", true },
                    { 548, "73", 77, 76, "Savoie", true },
                    { 549, "74", 77, 77, "Savoie (Haute)", true },
                    { 550, "75", 77, 78, "Paris", true },
                    { 551, "76", 77, 79, "Seine Maritime", true },
                    { 552, "77", 77, 80, "Seine et Marne", true },
                    { 553, "78", 77, 81, "Yvelines", true },
                    { 554, "79", 77, 82, "Sèvres (Deux)", true },
                    { 555, "80", 77, 83, "Somme", true },
                    { 556, "81", 77, 84, "Tarn", true },
                    { 557, "82", 77, 85, "Tarn et Garonne", true },
                    { 558, "83", 77, 86, "Var", true },
                    { 559, "84", 77, 87, "Vaucluse", true },
                    { 560, "85", 77, 88, "Vendée", true },
                    { 561, "86", 77, 89, "Vienne", true },
                    { 562, "87", 77, 90, "Vienne (Haute)", true },
                    { 563, "88", 77, 91, "Vosges", true },
                    { 564, "89", 77, 92, "Yonne", true },
                    { 565, "90", 77, 93, "Belfort (Territoire de)", true },
                    { 566, "91", 77, 94, "Essonne", true },
                    { 567, "92", 77, 95, "Hauts de Seine", true },
                    { 568, "93", 77, 96, "Seine Saint Denis", true },
                    { 569, "94", 77, 97, "Val de Marne", true },
                    { 570, "95", 77, 98, "Val d'oise", true },
                    { 571, "971", 77, 99, "Guadeloupe", true },
                    { 572, "972", 77, 100, "Martinique", true },
                    { 573, "973", 77, 101, "Guyane", true },
                    { 574, "974", 77, 102, "Réunion", true },
                    { 575, "975", 77, 103, "Saint-Pierre-et-Miquelon", true },
                    { 576, "976", 77, 104, "Mayotte", true },
                    { 577, "984", 77, 105, "Terres Australes et Antarctiques", true },
                    { 578, "986", 77, 106, "Wallis et futuna", true },
                    { 579, "987", 77, 107, "Polynésie Française", true },
                    { 580, "988", 77, 108, "Nouvelle-Calédonie", true },
                    { 581, "", 235, 1, "Aberdeenshire", true },
                    { 582, "", 235, 1, "Anglesey/Sir Fon", true },
                    { 583, "", 235, 1, "Angus", true },
                    { 584, "", 235, 1, "Argyll and Bute", true },
                    { 585, "", 235, 1, "Ayrshire", true },
                    { 586, "", 235, 1, "Berkshire", true },
                    { 587, "", 235, 1, "Blaenau Gwent", true },
                    { 588, "", 235, 1, "Bridgend", true },
                    { 589, "", 235, 1, "Bristol", true },
                    { 590, "", 235, 1, "Buckinghamshire", true },
                    { 591, "", 235, 1, "Caerphilly", true },
                    { 592, "", 235, 1, "Cambridgeshire", true },
                    { 593, "", 235, 1, "Cardiff", true },
                    { 594, "", 235, 1, "Carmarthenshire", true },
                    { 595, "", 235, 1, "Ceredigion", true },
                    { 596, "", 235, 1, "Cheshire", true },
                    { 597, "", 235, 1, "Clackmannanshire", true },
                    { 598, "", 235, 1, "Conwy", true },
                    { 599, "", 235, 1, "Cornwall", true },
                    { 600, "", 235, 1, "County Antrim", true },
                    { 601, "", 235, 1, "County Armagh", true },
                    { 602, "", 235, 1, "County Down", true },
                    { 603, "", 235, 1, "County Fermanagh", true },
                    { 604, "", 235, 1, "County Londonderry", true },
                    { 605, "", 235, 1, "County Tyrone", true },
                    { 606, "", 235, 1, "Cumbria", true },
                    { 607, "", 235, 1, "Denbighshire", true },
                    { 608, "", 235, 1, "Derbyshire", true },
                    { 609, "", 235, 1, "Devon", true },
                    { 610, "", 235, 1, "Dorset", true },
                    { 611, "", 235, 1, "Dumfries and Galloway", true },
                    { 612, "", 235, 1, "Dunbartonshire", true },
                    { 613, "", 235, 1, "Dundee", true },
                    { 614, "", 235, 1, "Durham", true },
                    { 615, "", 235, 1, "East Lothian", true },
                    { 616, "", 235, 1, "East Riding of Yorkshire", true },
                    { 617, "", 235, 1, "East Sussex", true },
                    { 618, "", 235, 1, "Edinburgh", true },
                    { 619, "", 235, 1, "Essex", true },
                    { 620, "", 235, 1, "Falkirk", true },
                    { 621, "", 235, 1, "Fife", true },
                    { 622, "", 235, 1, "Flintshire", true },
                    { 623, "", 235, 1, "Glamorgan", true },
                    { 624, "", 235, 1, "Glasgow", true },
                    { 625, "", 235, 1, "Gloucestershire", true },
                    { 626, "", 235, 1, "Greater Manchester", true },
                    { 627, "", 235, 1, "Gwynedd", true },
                    { 628, "", 235, 1, "Hampshire", true },
                    { 629, "", 235, 1, "Hereford and Worcester", true },
                    { 630, "", 235, 1, "Hertfordshire", true },
                    { 631, "", 235, 1, "Highland", true },
                    { 632, "", 235, 1, "Inverclyde", true },
                    { 633, "", 235, 1, "Isle of Man", true },
                    { 634, "", 235, 1, "Isle of Wight", true },
                    { 635, "", 235, 1, "Kent", true },
                    { 636, "", 235, 1, "Lanarkshire", true },
                    { 637, "", 235, 1, "Lancashire", true },
                    { 638, "", 235, 1, "Leicestershire", true },
                    { 639, "", 235, 1, "Lincolnshire", true },
                    { 640, "", 235, 1, "London", true },
                    { 641, "", 235, 1, "Merseyside", true },
                    { 642, "", 235, 1, "Merthyr Tydfil", true },
                    { 643, "", 235, 1, "Middlesex", true },
                    { 644, "", 235, 1, "Midlothian", true },
                    { 645, "", 235, 1, "Monmouthshire", true },
                    { 646, "", 235, 1, "Moray", true },
                    { 647, "", 235, 1, "Neath Port Talbot", true },
                    { 648, "", 235, 1, "Newport", true },
                    { 649, "", 235, 1, "Norfolk", true },
                    { 650, "", 235, 1, "North Yorkshire", true },
                    { 651, "", 235, 1, "Northamptonshire", true },
                    { 652, "", 235, 1, "Northumberland", true },
                    { 653, "", 235, 1, "Nottinghamshire", true },
                    { 654, "", 235, 1, "Orkney", true },
                    { 655, "", 235, 1, "Oxfordshire", true },
                    { 656, "", 235, 1, "Pembrokeshire", true },
                    { 657, "", 235, 1, "Perth and Kinross", true },
                    { 658, "", 235, 1, "Powys", true },
                    { 659, "", 235, 1, "Renfrewshire", true },
                    { 660, "", 235, 1, "Rhondda Cynon Taff", true },
                    { 661, "", 235, 1, "Rutland", true },
                    { 662, "", 235, 1, "Scottish Borders", true },
                    { 663, "", 235, 1, "Shetland Isles", true },
                    { 664, "", 235, 1, "Shropshire", true },
                    { 665, "", 235, 1, "Somerset", true },
                    { 666, "", 235, 1, "South Yorkshire", true },
                    { 667, "", 235, 1, "Staffordshire", true },
                    { 668, "", 235, 1, "Stirlingshire", true },
                    { 669, "", 235, 1, "Suffolk", true },
                    { 670, "", 235, 1, "Surrey", true },
                    { 671, "", 235, 1, "Swansea", true },
                    { 672, "", 235, 1, "Torfaen", true },
                    { 673, "", 235, 1, "Tyne and Wear", true },
                    { 674, "", 235, 1, "Warwickshire", true },
                    { 675, "", 235, 1, "West Lothian", true },
                    { 676, "", 235, 1, "West Midlands", true },
                    { 677, "", 235, 1, "West Sussex", true },
                    { 678, "", 235, 1, "West Yorkshire", true },
                    { 679, "", 235, 1, "Western Isles", true },
                    { 680, "", 235, 1, "Wiltshire", true },
                    { 681, "", 235, 1, "Wrexham", true },
                    { 682, "ΑΙΤ", 87, 1, "ΑΙΤΩΛΟΑΚΑΡΝΑΝΙΑΣ", true },
                    { 683, "ΑΡΓ", 87, 2, "ΑΡΓΟΛΙΔΑΣ", true },
                    { 684, "ΑΡΚ", 87, 3, "ΑΡΚΑΔΙΑΣ", true },
                    { 685, "ΑΡΤ", 87, 4, "ΑΡΤΑΣ", true },
                    { 686, "ΑΤΤ", 87, 5, "ΑΤΤΙΚΗΣ", true },
                    { 687, "ΑΧΑ", 87, 6, "ΑΧΑΙΑΣ", true },
                    { 688, "ΒΟΙ", 87, 7, "ΒΟΙΩΤΙΑΣ", true },
                    { 689, "ΓΡΕ", 87, 8, "ΓΡΕΒΕΝΩΝ", true },
                    { 690, "ΔΡΑ", 87, 9, "ΔΡΑΜΑΣ", true },
                    { 691, "ΔΩΔ", 87, 10, "ΔΩΔΕΚΑΝΗΣΟΥ", true },
                    { 692, "ΕΒΡ", 87, 11, "ΕΒΡΟΥ", true },
                    { 693, "ΕΥΒ", 87, 12, "ΕΥΒΟΙΑΣ", true },
                    { 694, "ΕΥΡ", 87, 13, "ΕΥΡΥΤΑΝΙΑΣ", true },
                    { 695, "ΖΑΚ", 87, 14, "ΖΑΚΥΝΘΟΥ", true },
                    { 696, "ΗΛΕ", 87, 15, "ΗΛΕΙΑΣ", true },
                    { 697, "ΗΜΑ", 87, 16, "ΗΜΑΘΙΑΣ", true },
                    { 698, "ΗΡΑ", 87, 17, "ΗΡΑΚΛΕΙΟΥ", true },
                    { 699, "ΘΕΣ", 87, 18, "ΘΕΣΠΡΩΤΙΑΣ", true },
                    { 700, "ΘΕΣ", 87, 19, "ΘΕΣΣΑΛΟΝΙΚΗΣ", true },
                    { 701, "ΙΩΑ", 87, 20, "ΙΩΑΝΝΙΝΩΝ", true },
                    { 702, "ΚΑΒ", 87, 21, "ΚΑΒΑΛΑΣ", true },
                    { 703, "ΚΑΡ", 87, 22, "ΚΑΡΔΙΤΣΑΣ", true },
                    { 704, "ΚΑΣ", 87, 23, "ΚΑΣΤΟΡΙΑΣ", true },
                    { 705, "ΚΕΡ", 87, 24, "ΚΕΡΚΥΡΑΣ", true },
                    { 706, "ΚΕΦ", 87, 25, "ΚΕΦΑΛΛΗΝΙΑΣ", true },
                    { 707, "ΚΙΛ", 87, 26, "ΚΙΛΚΙΣ", true },
                    { 708, "ΚΟΖ", 87, 27, "ΚΟΖΑΝΗΣ", true },
                    { 709, "ΚΟΡ", 87, 28, "ΚΟΡΙΝΘΙΑΣ", true },
                    { 710, "ΚΥΚ", 87, 29, "ΚΥΚΛΑΔΩΝ", true },
                    { 711, "ΛΑΚ", 87, 30, "ΛΑΚΩΝΙΑΣ", true },
                    { 712, "ΛΑΡ", 87, 31, "ΛΑΡΙΣΑΣ", true },
                    { 713, "ΛΑΣ", 87, 32, "ΛΑΣΙΘΙΟΥ", true },
                    { 714, "ΛΕΣ", 87, 33, "ΛΕΣΒΟΥ", true },
                    { 715, "ΛΕΥ", 87, 34, "ΛΕΥΚΑΔΑΣ", true },
                    { 716, "ΜΑΓ", 87, 35, "ΜΑΓΝΗΣΙΑΣ", true },
                    { 717, "ΜΕΣ", 87, 36, "ΜΕΣΣΗΝΙΑΣ", true },
                    { 718, "ΞΑΝ", 87, 37, "ΞΑΝΘΗΣ", true },
                    { 719, "ΠΕΛ", 87, 38, "ΠΕΛΛΗΣ", true },
                    { 720, "ΠΙΕ", 87, 39, "ΠΙΕΡΙΑΣ", true },
                    { 721, "ΠΡΕ", 87, 40, "ΠΡΕΒΕΖΑΣ", true },
                    { 722, "ΡΕΘ", 87, 41, "ΡΕΘΥΜΝΗΣ", true },
                    { 723, "ΡΟΔ", 87, 42, "ΡΟΔΟΠΗΣ", true },
                    { 724, "ΣΑΜ", 87, 43, "ΣΑΜΟΥ", true },
                    { 725, "ΣΕΡ", 87, 44, "ΣΕΡΡΩΝ", true },
                    { 726, "ΤΡΙ", 87, 45, "ΤΡΙΚΑΛΩΝ", true },
                    { 727, "ΦΘΙ", 87, 46, "ΦΘΙΩΤΙΔΑΣ", true },
                    { 728, "ΦΛΩ", 87, 47, "ΦΛΩΡΙΝΑΣ", true },
                    { 729, "ΦΩΚ", 87, 48, "ΦΩΚΙΔΑΣ", true },
                    { 730, "ΧΑΛ", 87, 49, "ΧΑΛΚΙΔΙΚΗΣ", true },
                    { 731, "ΧΑΝ", 87, 50, "ΧΑΝΙΩΝ", true },
                    { 732, "ΧΙΟ", 87, 51, "ΧΙΟΥ", true },
                    { 733, "GZG", 56, 0, "Grad Zagreb", true },
                    { 734, "BBŽ", 56, 1, "Bjelovarsko-bilogorska", true },
                    { 735, "BPŽ", 56, 1, "Brodsko-posavska", true },
                    { 736, "DNŽ", 56, 1, "Dubrovačko-neretvanska", true },
                    { 737, "IŽ", 56, 1, "Istarska", true },
                    { 738, "KŽ", 56, 1, "Karlovačka", true },
                    { 739, "KKŽ", 56, 1, "Koprivničko-križevačka", true },
                    { 740, "KZŽ", 56, 1, "Krapinsko-zagorska", true },
                    { 741, "LSŽ", 56, 1, "Ličko-senjska", true },
                    { 742, "MŽ", 56, 1, "Međimurska", true },
                    { 743, "OBŽ", 56, 1, "Osječko-baranjska", true },
                    { 744, "PSŽ", 56, 1, "Požeško-slavonska", true },
                    { 745, "PGŽ", 56, 1, "Primorsko-goranska", true },
                    { 746, "SMŽ", 56, 1, "Sisačko-moslavačka", true },
                    { 747, "SDŽ", 56, 1, "Splitsko-dalmatinska", true },
                    { 748, "ŠKŽ", 56, 1, "Šibensko-kninska", true },
                    { 749, "VŽ", 56, 1, "Varaždinska", true },
                    { 750, "VPŽ", 56, 1, "Virovitičko-podravska", true },
                    { 751, "VSŽ", 56, 1, "Vukovarsko-srijemska", true },
                    { 752, "ZDŽ", 56, 1, "Zadarska", true },
                    { 753, "ZGŽ", 56, 1, "Zagrebačka", true },
                    { 754, "BU", 102, 1, "Budapest", true },
                    { 755, "BK", 102, 2, "Bács-Kiskun", true },
                    { 756, "BA", 102, 3, "Baranya", true },
                    { 757, "BE", 102, 4, "Békés", true },
                    { 758, "BZ", 102, 5, "Borsod-Abaúj-Zemplén", true },
                    { 759, "CS", 102, 6, "Csongrád", true },
                    { 760, "FE", 102, 7, "Fejér", true },
                    { 761, "GS", 102, 8, "Győr-Moson-Sopron", true },
                    { 762, "HB", 102, 9, "Hajdú-Bihar", true },
                    { 763, "HE", 102, 10, "Heves", true },
                    { 764, "JN", 102, 11, "Jász-Nagykun-Szolnok", true },
                    { 765, "KE", 102, 12, "Komárom-Esztergom", true },
                    { 766, "NO", 102, 13, "Nógrád", true },
                    { 767, "PE", 102, 14, "Pest", true },
                    { 768, "SO", 102, 15, "Somogy", true },
                    { 769, "SZ", 102, 16, "Szabolcs-Szatmár-Bereg", true },
                    { 770, "TO", 102, 17, "Tolna", true },
                    { 771, "VA", 102, 18, "Vas", true },
                    { 772, "VE", 102, 19, "Veszprém", true },
                    { 773, "ZA", 102, 20, "Zala", true },
                    { 774, "", 105, 1, "Aceh", true },
                    { 775, "", 105, 2, "Bali", true },
                    { 776, "", 105, 3, "Banten", true },
                    { 777, "", 105, 4, "Bengkulu", true },
                    { 778, "", 105, 5, "Gorontalo", true },
                    { 779, "", 105, 6, "Jakarta", true },
                    { 780, "", 105, 7, "Jambi", true },
                    { 781, "", 105, 8, "Jawa Barat", true },
                    { 782, "", 105, 9, "Jawa Tengah", true },
                    { 783, "", 105, 10, "Jawa Timur", true },
                    { 784, "", 105, 11, "Kalimantan Barat", true },
                    { 785, "", 105, 12, "Kalimantan Selatan", true },
                    { 786, "", 105, 13, "Kalimantan Tengah", true },
                    { 787, "", 105, 14, "Kalimantan Timur", true },
                    { 788, "", 105, 15, "Kalimantan Utara", true },
                    { 789, "", 105, 16, "Kepulauan Bangka Belitung", true },
                    { 790, "", 105, 17, "Kepulauan Riau", true },
                    { 791, "", 105, 18, "Lampung", true },
                    { 792, "", 105, 19, "Maluku", true },
                    { 793, "", 105, 20, "Maluku Utara", true },
                    { 794, "", 105, 21, "Nusa Tenggara Barat", true },
                    { 795, "", 105, 22, "Nusa Tenggara Timur", true },
                    { 796, "", 105, 23, "Papua", true },
                    { 797, "", 105, 24, "Papua Barat", true },
                    { 798, "", 105, 25, "Riau", true },
                    { 799, "", 105, 26, "Sulawesi Barat", true },
                    { 800, "", 105, 27, "Sulawesi Selatan", true },
                    { 801, "", 105, 28, "Sulawesi Tengah", true },
                    { 802, "", 105, 29, "Sulawesi Tenggara", true },
                    { 803, "", 105, 30, "Sulawesi Utara", true },
                    { 804, "", 105, 31, "Sumatera Barat", true },
                    { 805, "", 105, 32, "Sumatera Selatan", true },
                    { 806, "", 105, 33, "Sumatera Utara", true },
                    { 807, "", 105, 34, "Yogyakarta", true },
                    { 808, "", 108, 1, "County Carlow", true },
                    { 809, "", 108, 2, "County Cavan", true },
                    { 810, "", 108, 3, "County Clare", true },
                    { 811, "", 108, 4, "County Cork", true },
                    { 812, "", 108, 5, "County Donegal", true },
                    { 813, "", 108, 6, "County Dublin", true },
                    { 814, "", 108, 7, "County Galway", true },
                    { 815, "", 108, 8, "County Kerry", true },
                    { 816, "", 108, 9, "County Kildare", true },
                    { 817, "", 108, 10, "County Kilkenny", true },
                    { 818, "", 108, 11, "County Laois", true },
                    { 819, "", 108, 12, "County Leitrim", true },
                    { 820, "", 108, 13, "County Limerick", true },
                    { 821, "", 108, 14, "County Longford", true },
                    { 822, "", 108, 15, "County Louth", true },
                    { 823, "", 108, 16, "County Mayo", true },
                    { 824, "", 108, 17, "County Meath", true },
                    { 825, "", 108, 18, "County Monaghan", true },
                    { 826, "", 108, 19, "County Offaly", true },
                    { 827, "", 108, 20, "County Roscommon", true },
                    { 828, "", 108, 21, "County Sligo", true },
                    { 829, "", 108, 22, "County Tipperary", true },
                    { 830, "", 108, 23, "County Waterford", true },
                    { 831, "", 108, 24, "County Westmeath", true },
                    { 832, "", 108, 25, "County Wexford", true },
                    { 833, "", 108, 26, "County Wicklow", true },
                    { 834, "AP", 104, 1, "Andhra Pradesh", true },
                    { 835, "AR", 104, 1, "Arunachal Pradesh", true },
                    { 836, "AS", 104, 1, "Assam", true },
                    { 837, "BR", 104, 1, "Bihar", true },
                    { 838, "CT", 104, 1, "Chhattisgarh", true },
                    { 839, "GA", 104, 1, "Goa", true },
                    { 840, "GJ", 104, 1, "Gujarat", true },
                    { 841, "HR", 104, 1, "Haryana", true },
                    { 842, "HP", 104, 1, "Himachal Pradesh", true },
                    { 843, "JK", 104, 1, "Jammu and Kashmir", true },
                    { 844, "JH", 104, 1, "Jharkhand", true },
                    { 845, "KA", 104, 1, "Karnataka", true },
                    { 846, "KL", 104, 1, "Kerala", true },
                    { 847, "MP", 104, 1, "Madhya Pradesh", true },
                    { 848, "MH", 104, 1, "Maharashtra", true },
                    { 849, "MN", 104, 1, "Manipur", true },
                    { 850, "ML", 104, 1, "Meghalaya", true },
                    { 851, "MZ", 104, 1, "Mizoram", true },
                    { 852, "NL", 104, 1, "Nagaland", true },
                    { 853, "OR", 104, 1, "Odisha", true },
                    { 854, "PB", 104, 1, "Punjab", true },
                    { 855, "RJ", 104, 1, "Rajasthan", true },
                    { 856, "SK", 104, 1, "Sikkim", true },
                    { 857, "TN", 104, 1, "Tamil Nadu", true },
                    { 858, "TG", 104, 1, "Telangana", true },
                    { 859, "TR", 104, 1, "Tripura", true },
                    { 860, "UT", 104, 1, "Uttarakhand", true },
                    { 861, "UP", 104, 1, "Uttar Pradesh", true },
                    { 862, "WB", 104, 1, "West Bengal", true },
                    { 863, "AN", 104, 1, "Andaman and Nicobar Islands", true },
                    { 864, "CH", 104, 1, "Chandigarh", true },
                    { 865, "DN", 104, 1, "Dadra and Nagar Haveli", true },
                    { 866, "DD", 104, 1, "Daman and Diu", true },
                    { 867, "DL", 104, 1, "Delhi", true },
                    { 868, "LD", 104, 1, "Lakshadweep", true },
                    { 869, "PY", 104, 1, "Puducherry", true },
                    { 870, "", 106, 0, "آذربایجان شرقی", true },
                    { 871, "", 106, 0, "آذربایجان غربی", true },
                    { 872, "", 106, 0, "اردبیل", true },
                    { 873, "", 106, 0, "اصفهان", true },
                    { 874, "", 106, 0, "البرز", true },
                    { 875, "", 106, 0, "ایلام", true },
                    { 876, "", 106, 0, "بوشهر", true },
                    { 877, "", 106, 0, "تهران", true },
                    { 878, "", 106, 0, "چهارمحال و بختیاری", true },
                    { 879, "", 106, 0, "خراسان جنوبی", true },
                    { 880, "", 106, 0, "خراسان رضوی", true },
                    { 881, "", 106, 0, "خراسان شمالی", true },
                    { 882, "", 106, 0, "خوزستان", true },
                    { 883, "", 106, 0, "زنجان", true },
                    { 884, "", 106, 0, "سمنان", true },
                    { 885, "", 106, 0, "سیستان و بلوچستان", true },
                    { 886, "", 106, 0, "فارس", true },
                    { 887, "", 106, 0, "قزوین", true },
                    { 888, "", 106, 0, "قم", true },
                    { 889, "", 106, 0, "کردستان", true },
                    { 890, "", 106, 0, "کرمان", true },
                    { 891, "", 106, 0, "کرمانشاه", true },
                    { 892, "", 106, 0, "کهگیلویه و بویراحمد", true },
                    { 893, "", 106, 0, "گلستان", true },
                    { 894, "", 106, 0, "گیلان", true },
                    { 895, "", 106, 0, "لرستان", true },
                    { 896, "", 106, 0, "مازندران", true },
                    { 897, "", 106, 0, "مرکزی", true },
                    { 898, "", 106, 0, "هرمزگان", true },
                    { 899, "", 106, 0, "همدان", true },
                    { 900, "", 106, 0, "یزد", true },
                    { 901, "", 103, 0, "Höfuðborgarsvæðið", true },
                    { 902, "", 103, 0, "Suðurnes", true },
                    { 903, "", 103, 0, "Vesturland", true },
                    { 904, "", 103, 0, "Vestfirðir", true },
                    { 905, "", 103, 0, "Norðurland vestra", true },
                    { 906, "", 103, 0, "Norðurland eystra", true },
                    { 907, "", 103, 0, "Austurland", true },
                    { 908, "", 103, 0, "Suðurland", true },
                    { 909, "AG", 111, 1, "Agrigento", true },
                    { 910, "AL", 111, 1, "Alessandria", true },
                    { 911, "AN", 111, 1, "Ancona", true },
                    { 912, "AO", 111, 1, "Aosta", true },
                    { 913, "AR", 111, 1, "Arezzo", true },
                    { 914, "AP", 111, 1, "Ascoli Piceno", true },
                    { 915, "AT", 111, 1, "Asti", true },
                    { 916, "AV", 111, 1, "Avellino", true },
                    { 917, "BA", 111, 1, "Bari", true },
                    { 918, "BT", 111, 1, "Barletta-Andria-Trani", true },
                    { 919, "BL", 111, 1, "Belluno", true },
                    { 920, "BN", 111, 1, "Benevento", true },
                    { 921, "BG", 111, 1, "Bergamo", true },
                    { 922, "BI", 111, 1, "Biella", true },
                    { 923, "BO", 111, 1, "Bologna", true },
                    { 924, "BZ", 111, 1, "Bolzano", true },
                    { 925, "BS", 111, 1, "Brescia", true },
                    { 926, "BR", 111, 1, "Brindisi", true },
                    { 927, "CA", 111, 1, "Cagliari", true },
                    { 928, "CL", 111, 1, "Caltanissetta", true },
                    { 929, "CB", 111, 1, "Campobasso", true },
                    { 930, "CI", 111, 1, "Carbonia-Iglesias", true },
                    { 931, "CE", 111, 1, "Caserta", true },
                    { 932, "CT", 111, 1, "Catania", true },
                    { 933, "CZ", 111, 1, "Catanzaro", true },
                    { 934, "CH", 111, 1, "Chieti", true },
                    { 935, "CO", 111, 1, "Como", true },
                    { 936, "CS", 111, 1, "Cosenza", true },
                    { 937, "CR", 111, 1, "Cremona", true },
                    { 938, "KR", 111, 1, "Crotone", true },
                    { 939, "CN", 111, 1, "Cuneo", true },
                    { 940, "EN", 111, 1, "Enna", true },
                    { 941, "FM", 111, 1, "Fermo", true },
                    { 942, "FE", 111, 1, "Ferrara", true },
                    { 943, "FI", 111, 1, "Firenze", true },
                    { 944, "FG", 111, 1, "Foggia", true },
                    { 945, "FC", 111, 1, "Forlì-Cesena", true },
                    { 946, "FR", 111, 1, "Frosinone", true },
                    { 947, "GE", 111, 1, "Genova", true },
                    { 948, "GO", 111, 1, "Gorizia", true },
                    { 949, "GR", 111, 1, "Grosseto", true },
                    { 950, "IM", 111, 1, "Imperia", true },
                    { 951, "IS", 111, 1, "Isernia", true },
                    { 952, "SP", 111, 1, "La Spezia", true },
                    { 953, "AQ", 111, 1, "L'Aquila", true },
                    { 954, "LT", 111, 1, "Latina", true },
                    { 955, "LE", 111, 1, "Lecce", true },
                    { 956, "LC", 111, 1, "Lecco", true },
                    { 957, "LI", 111, 1, "Livorno", true },
                    { 958, "LO", 111, 1, "Lodi", true },
                    { 959, "LU", 111, 1, "Lucca", true },
                    { 960, "MC", 111, 1, "Macerata", true },
                    { 961, "MN", 111, 1, "Mantova", true },
                    { 962, "MS", 111, 1, "Massa-Carrara", true },
                    { 963, "MT", 111, 1, "Matera", true },
                    { 964, "VS", 111, 1, "Medio Campidano", true },
                    { 965, "ME", 111, 1, "Messina", true },
                    { 966, "MI", 111, 1, "Milano", true },
                    { 967, "MO", 111, 1, "Modena", true },
                    { 968, "MB", 111, 1, "Monza e della Brianza", true },
                    { 969, "NA", 111, 1, "Napoli", true },
                    { 970, "NO", 111, 1, "Novara", true },
                    { 971, "NU", 111, 1, "Nuoro", true },
                    { 972, "OG", 111, 1, "Ogliastra", true },
                    { 973, "OT", 111, 1, "Olbia-Tempio", true },
                    { 974, "OR", 111, 1, "Oristano", true },
                    { 975, "PD", 111, 1, "Padova", true },
                    { 976, "PA", 111, 1, "Palermo", true },
                    { 977, "PR", 111, 1, "Parma", true },
                    { 978, "PV", 111, 1, "Pavia", true },
                    { 979, "PG", 111, 1, "Perugia", true },
                    { 980, "PU", 111, 1, "Pesaro e Urbino", true },
                    { 981, "PE", 111, 1, "Pescara", true },
                    { 982, "PC", 111, 1, "Piacenza", true },
                    { 983, "PI", 111, 1, "Pisa", true },
                    { 984, "PT", 111, 1, "Pistoia", true },
                    { 985, "PN", 111, 1, "Pordenone", true },
                    { 986, "PZ", 111, 1, "Potenza", true },
                    { 987, "PO", 111, 1, "Prato", true },
                    { 988, "RG", 111, 1, "Ragusa", true },
                    { 989, "RA", 111, 1, "Ravenna", true },
                    { 990, "RC", 111, 1, "Reggio Calabria", true },
                    { 991, "RE", 111, 1, "Reggio Emilia", true },
                    { 992, "RI", 111, 1, "Rieti", true },
                    { 993, "RN", 111, 1, "Rimini", true },
                    { 994, "RM", 111, 1, "Roma", true },
                    { 995, "RO", 111, 1, "Rovigo", true },
                    { 996, "SA", 111, 1, "Salerno", true },
                    { 997, "SS", 111, 1, "Sassari", true },
                    { 998, "SV", 111, 1, "Savona", true },
                    { 999, "SI", 111, 1, "Siena", true },
                    { 1000, "SR", 111, 1, "Siracusa", true },
                    { 1001, "SO", 111, 1, "Sondrio", true },
                    { 1002, "TA", 111, 1, "Taranto", true },
                    { 1003, "TE", 111, 1, "Teramo", true },
                    { 1004, "TR", 111, 1, "Terni", true },
                    { 1005, "TO", 111, 1, "Torino", true },
                    { 1006, "TP", 111, 1, "Trapani", true },
                    { 1007, "TN", 111, 1, "Trento", true },
                    { 1008, "TV", 111, 1, "Treviso", true },
                    { 1009, "TS", 111, 1, "Trieste", true },
                    { 1010, "UD", 111, 1, "Udine", true },
                    { 1011, "VA", 111, 1, "Varese", true },
                    { 1012, "VE", 111, 1, "Venezia", true },
                    { 1013, "VB", 111, 1, "Verbano-Cusio-Ossola", true },
                    { 1014, "VC", 111, 1, "Vercelli", true },
                    { 1015, "VR", 111, 1, "Verona", true },
                    { 1016, "VV", 111, 1, "Vibo Valentia", true },
                    { 1017, "VI", 111, 1, "Vicenza", true },
                    { 1018, "VT", 111, 1, "Viterbo", true },
                    { 1019, "", 121, 0, "Al Asimah", true },
                    { 1020, "", 121, 0, "Hawalli", true },
                    { 1021, "", 121, 0, "Al Farwaniya", true },
                    { 1022, "", 121, 0, "Mubarak Al Kabeer", true },
                    { 1023, "", 121, 0, "Al Ahmadi", true },
                    { 1024, "", 121, 0, "Al Jahraa", true },
                    { 1025, "", 130, 0, "Alytaus apskritis", true },
                    { 1026, "", 130, 0, "Kauno apskritis", true },
                    { 1027, "", 130, 0, "Klaipėdos apskritis", true },
                    { 1028, "", 130, 0, "Marijampolės apskritis", true },
                    { 1029, "", 130, 0, "Panevėžio apskritis", true },
                    { 1030, "", 130, 0, "Šiaulių apskritis", true },
                    { 1031, "", 130, 0, "Tauragės apskritis", true },
                    { 1032, "", 130, 0, "Telšių apskritis", true },
                    { 1033, "", 130, 0, "Utenos apskritis", true },
                    { 1034, "", 130, 0, "Vilniaus apskritis", true },
                    { 1035, "", 131, 0, "Capellen", true },
                    { 1036, "", 131, 0, "Clerveaux", true },
                    { 1037, "", 131, 0, "Diekirch", true },
                    { 1038, "", 131, 0, "Echternach", true },
                    { 1039, "", 131, 0, "Esch-Sur-Azette", true },
                    { 1040, "", 131, 0, "Greven-Macher", true },
                    { 1041, "", 131, 0, "Luxembourg Campagne", true },
                    { 1042, "", 131, 0, "Mersch", true },
                    { 1043, "", 131, 0, "Redange", true },
                    { 1044, "", 131, 0, "Remich", true },
                    { 1045, "", 131, 0, "Vianden", true },
                    { 1046, "", 131, 0, "Wiltz", true },
                    { 1047, "", 152, 0, "Agadir", true },
                    { 1048, "", 152, 0, "Beni mellal", true },
                    { 1049, "", 152, 0, "Berkane", true },
                    { 1050, "", 152, 0, "Casablanca", true },
                    { 1051, "", 152, 0, "El jadida", true },
                    { 1052, "", 152, 0, "Fes", true },
                    { 1053, "", 152, 0, "Inezgane", true },
                    { 1054, "", 152, 0, "Kenitra", true },
                    { 1055, "", 152, 0, "Khemisset", true },
                    { 1056, "", 152, 0, "Khenifra", true },
                    { 1057, "", 152, 0, "Khouribga", true },
                    { 1058, "", 152, 0, "Laayoune", true },
                    { 1059, "", 152, 0, "Marrakech", true },
                    { 1060, "", 152, 0, "Meknes", true },
                    { 1061, "", 152, 0, "Mohammedia", true },
                    { 1062, "", 152, 0, "Nador", true },
                    { 1063, "", 152, 0, "Oujda", true },
                    { 1064, "", 152, 0, "Rabat", true },
                    { 1065, "", 152, 0, "Safi", true },
                    { 1066, "", 152, 0, "Sale", true },
                    { 1067, "", 152, 0, "Tanger", true },
                    { 1068, "", 152, 0, "Taza", true },
                    { 1069, "", 152, 0, "Temara", true },
                    { 1070, "", 152, 0, "Tetouan", true },
                    { 1071, "БН", 149, 1, "Улаанбаатар хот - Багануур дүүрэг", true },
                    { 1072, "БХ", 149, 1, "Улаанбаатар хот - Багахангай дүүрэг", true },
                    { 1073, "БГ", 149, 1, "Улаанбаатар хот - Баянгол дүүрэг", true },
                    { 1074, "БЗ", 149, 1, "Улаанбаатар хот - Баянзүрх дүүрэг", true },
                    { 1075, "НА", 149, 1, "Улаанбаатар хот - Налайх дүүрэг", true },
                    { 1076, "СХ", 149, 1, "Улаанбаатар хот - Сонгино хайрхан дүүрэг", true },
                    { 1077, "СБ", 149, 1, "Улаанбаатар хот - Сүхбаатар дүүрэг", true },
                    { 1078, "ХУ", 149, 1, "Улаанбаатар хот - Хан-Уул дүүрэг", true },
                    { 1079, "ЧИ", 149, 1, "Улаанбаатар хот - Чингэлтэй дүүрэг", true },
                    { 1080, "АР", 149, 2, "Архангай аймаг", true },
                    { 1081, "БӨ", 149, 2, "Баян-Өлгий аймаг", true },
                    { 1082, "БХ", 149, 2, "Баянхонгор аймаг", true },
                    { 1083, "БУ", 149, 2, "Булган аймаг", true },
                    { 1084, "ӨВ", 149, 2, "Өвөрхангай аймаг", true },
                    { 1085, "ГА", 149, 2, "Говь-Алтай аймаг", true },
                    { 1086, "ГС", 149, 2, "Говьсүмбэр аймаг", true },
                    { 1087, "ДА", 149, 2, "Дархан-Уул аймаг", true },
                    { 1088, "ДГ", 149, 2, "Дорноговь аймаг", true },
                    { 1089, "ДО", 149, 2, "Дорнод аймаг", true },
                    { 1090, "ДУ", 149, 2, "Дундговь аймаг", true },
                    { 1091, "ЗА", 149, 2, "Завхан аймаг", true },
                    { 1092, "ӨМ", 149, 2, "Өмнөговь аймаг", true },
                    { 1093, "ОР", 149, 2, "Орхон аймаг", true },
                    { 1094, "СҮ", 149, 2, "Сүхбаатар аймаг", true },
                    { 1095, "СЭ", 149, 2, "Сэлэнгэ аймаг", true },
                    { 1096, "ТӨ", 149, 2, "Төв аймаг", true },
                    { 1097, "УВ", 149, 2, "Увс аймаг", true },
                    { 1098, "ХӨ", 149, 2, "Хөвсгөл аймаг", true },
                    { 1099, "ХО", 149, 2, "Ховд аймаг", true },
                    { 1100, "ХЭ", 149, 2, "Хэнтий аймаг", true },
                    { 1101, "", 145, 0, "Aguascalientes", true },
                    { 1102, "", 145, 0, "Baja California", true },
                    { 1103, "", 145, 0, "Baja California Sur", true },
                    { 1104, "", 145, 0, "Campeche", true },
                    { 1105, "", 145, 0, "Chiapas", true },
                    { 1106, "", 145, 0, "Chihuahua", true },
                    { 1107, "", 145, 0, "Coahuila", true },
                    { 1108, "", 145, 0, "Colima", true },
                    { 1109, "", 145, 0, "Distrito Federal", true },
                    { 1110, "", 145, 0, "Durango", true },
                    { 1111, "", 145, 0, "Estado de México", true },
                    { 1112, "", 145, 0, "Guanajuato", true },
                    { 1113, "", 145, 0, "Guerrero", true },
                    { 1114, "", 145, 0, "Hidalgo", true },
                    { 1115, "", 145, 0, "Jalisco", true },
                    { 1116, "", 145, 0, "Michoacán", true },
                    { 1117, "", 145, 0, "Morelos", true },
                    { 1118, "", 145, 0, "Nayarit", true },
                    { 1119, "", 145, 0, "Nuevo León", true },
                    { 1120, "", 145, 0, "Oaxaca", true },
                    { 1121, "", 145, 0, "Puebla", true },
                    { 1122, "", 145, 0, "Querétaro", true },
                    { 1123, "", 145, 0, "Quintana Roo", true },
                    { 1124, "", 145, 0, "San Luis Potosí", true },
                    { 1125, "", 145, 0, "Sinaloa", true },
                    { 1126, "", 145, 0, "Sonora", true },
                    { 1127, "", 145, 0, "Tabasco", true },
                    { 1128, "", 145, 0, "Tamaulipas", true },
                    { 1129, "", 145, 0, "Tlaxcala", true },
                    { 1130, "", 145, 0, "Veracruz", true },
                    { 1131, "", 145, 0, "Yucatán", true },
                    { 1132, "", 145, 0, "Zacatecas", true },
                    { 1133, "JHR", 136, 0, "Johor", true },
                    { 1134, "KDH", 136, 0, "Kedah", true },
                    { 1135, "KTN", 136, 0, "Kelantan", true },
                    { 1136, "KUL", 136, 0, "Kuala Lumpur", true },
                    { 1137, "LBN", 136, 0, "Labuan", true },
                    { 1138, "MLK", 136, 0, "Melaka", true },
                    { 1139, "NSN", 136, 0, "Negeri Sembilan", true },
                    { 1140, "PHG", 136, 0, "Pahang", true },
                    { 1141, "PRK", 136, 0, "Perak", true },
                    { 1142, "PLS", 136, 0, "Perlis", true },
                    { 1143, "PNG", 136, 0, "Pulau Pinang", true },
                    { 1144, "PJY", 136, 0, "Putrajaya", true },
                    { 1145, "SBH", 136, 0, "Sabah", true },
                    { 1146, "SWK", 136, 0, "Sarawak", true },
                    { 1147, "SGR", 136, 0, "Selangor", true },
                    { 1148, "TRG", 136, 0, "Terengganu", true },
                    { 1149, "", 163, 0, "Abia", true },
                    { 1150, "", 163, 0, "Adamawa", true },
                    { 1151, "", 163, 0, "Akwa Ibom", true },
                    { 1152, "", 163, 0, "Anambra", true },
                    { 1153, "", 163, 0, "Bauchi", true },
                    { 1154, "", 163, 0, "Bayelsa", true },
                    { 1155, "", 163, 0, "Benue", true },
                    { 1156, "", 163, 0, "Borno", true },
                    { 1157, "", 163, 0, "Cross River", true },
                    { 1158, "", 163, 0, "Delta", true },
                    { 1159, "", 163, 0, "Ebonyi", true },
                    { 1160, "", 163, 0, "Edo", true },
                    { 1161, "", 163, 0, "Enugu", true },
                    { 1162, "", 163, 0, "Ekiti", true },
                    { 1163, "", 163, 0, "FCT", true },
                    { 1164, "", 163, 0, "Gombe", true },
                    { 1165, "", 163, 0, "Imo", true },
                    { 1166, "", 163, 0, "Jigawa", true },
                    { 1167, "", 163, 0, "Kaduna", true },
                    { 1168, "", 163, 0, "Kano", true },
                    { 1169, "", 163, 0, "Katsina", true },
                    { 1170, "", 163, 0, "Kebbi", true },
                    { 1171, "", 163, 0, "Kogi", true },
                    { 1172, "", 163, 0, "Kwara", true },
                    { 1173, "", 163, 0, "Lagos", true },
                    { 1174, "", 163, 0, "Nasarawa", true },
                    { 1175, "", 163, 0, "Niger", true },
                    { 1176, "", 163, 0, "Ogun", true },
                    { 1177, "", 163, 0, "Ondo", true },
                    { 1178, "", 163, 0, "Osun", true },
                    { 1179, "", 163, 0, "Oyo", true },
                    { 1180, "", 163, 0, "Plateau", true },
                    { 1181, "", 163, 0, "Rivers", true },
                    { 1182, "", 163, 0, "Sokoto", true },
                    { 1183, "", 163, 0, "Taraba", true },
                    { 1184, "", 163, 0, "Yobe", true },
                    { 1185, "", 163, 0, "Zamafara", true },
                    { 1186, "DR", 158, 0, "Drenthe", true },
                    { 1187, "FL", 158, 0, "Flevoland", true },
                    { 1188, "FR", 158, 0, "Friesland", true },
                    { 1189, "GD", 158, 0, "Gelderland", true },
                    { 1190, "GR", 158, 0, "Groningen", true },
                    { 1191, "LB", 158, 0, "Limburg", true },
                    { 1192, "NB", 158, 0, "Noord-Brabant", true },
                    { 1193, "NH", 158, 0, "Noord-Holland", true },
                    { 1194, "OV", 158, 0, "Overijssel", true },
                    { 1195, "UT", 158, 0, "Utrecht", true },
                    { 1196, "ZL", 158, 0, "Zeeland", true },
                    { 1197, "ZH", 158, 0, "Zuid-Holland", true },
                    { 1198, "01", 167, 1, "Østfold", true },
                    { 1199, "02", 167, 2, "Akershus", true },
                    { 1200, "03", 167, 3, "Oslo", true },
                    { 1201, "04", 167, 4, "Hedmark", true },
                    { 1202, "05", 167, 5, "Oppland", true },
                    { 1203, "06", 167, 6, "Buskerud", true },
                    { 1204, "07", 167, 7, "Vestfold", true },
                    { 1205, "08", 167, 8, "Telemark", true },
                    { 1206, "09", 167, 9, "Aust-Agder", true },
                    { 1207, "10", 167, 10, "Vest-Agder", true },
                    { 1208, "11", 167, 11, "Rogaland", true },
                    { 1209, "12", 167, 12, "Hordaland", true },
                    { 1210, "14", 167, 14, "Sogn og Fjordane", true },
                    { 1211, "15", 167, 15, "Møre og Romsdal", true },
                    { 1212, "16", 167, 16, "Sør-Trøndelag", true },
                    { 1213, "17", 167, 17, "Nord-Trøndelag", true },
                    { 1214, "18", 167, 18, "Nordland", true },
                    { 1215, "19", 167, 19, "Troms", true },
                    { 1216, "20", 167, 20, "Finnmark", true },
                    { 1217, "21", 167, 21, "Svalbard", true },
                    { 1218, "22", 167, 22, "Jan Mayen", true },
                    { 1219, "", 157, 1, "Province No. 1", true },
                    { 1220, "", 157, 2, "Province No. 2", true },
                    { 1221, "", 157, 3, "Province No. 3", true },
                    { 1222, "", 157, 4, "Gandaki Pradesh", true },
                    { 1223, "", 157, 5, "Province No. 5", true },
                    { 1224, "", 157, 6, "Karnali Pradesh", true },
                    { 1225, "", 157, 7, "Sudurpashchim Pradesh", true },
                    { 1226, "", 160, 0, "Northland", true },
                    { 1227, "", 160, 0, "Auckland", true },
                    { 1228, "", 160, 0, "Waikato", true },
                    { 1229, "", 160, 0, "Waitomo", true },
                    { 1230, "", 160, 0, "Bay of Plenty", true },
                    { 1231, "", 160, 0, "Taupo", true },
                    { 1232, "", 160, 0, "King Country", true },
                    { 1233, "", 160, 0, "Taranaki", true },
                    { 1234, "", 160, 0, "Wanganui", true },
                    { 1235, "", 160, 0, "Manawatu", true },
                    { 1236, "", 160, 0, "Horowhenua", true },
                    { 1237, "", 160, 0, "Kapiti", true },
                    { 1238, "", 160, 0, "Gisborne", true },
                    { 1239, "", 160, 0, "Hawkes Bay", true },
                    { 1240, "", 160, 0, "Wairarapa", true },
                    { 1241, "", 160, 0, "Wellington", true },
                    { 1242, "", 160, 0, "Nelson", true },
                    { 1243, "", 160, 0, "Marlborough", true },
                    { 1244, "", 160, 0, "Buller", true },
                    { 1245, "", 160, 0, "West Coast", true },
                    { 1246, "", 160, 0, "Canterbury", true },
                    { 1247, "", 160, 0, "Otago", true },
                    { 1248, "", 160, 0, "Southland", true },
                    { 1249, "", 176, 1, "Abra", true },
                    { 1250, "", 176, 2, "Agusan del Norte", true },
                    { 1251, "", 176, 3, "Agusan del Sur", true },
                    { 1252, "", 176, 4, "Aklan", true },
                    { 1253, "", 176, 5, "Albay", true },
                    { 1254, "", 176, 6, "Antique", true },
                    { 1255, "", 176, 7, "Apayao", true },
                    { 1256, "", 176, 8, "Aurora", true },
                    { 1257, "", 176, 9, "Basilan", true },
                    { 1258, "", 176, 10, "Bataan", true },
                    { 1259, "", 176, 11, "Batanes", true },
                    { 1260, "", 176, 12, "Batangas", true },
                    { 1261, "", 176, 13, "Benguet", true },
                    { 1262, "", 176, 14, "Biliran", true },
                    { 1263, "", 176, 15, "Bohol", true },
                    { 1264, "", 176, 16, "Bukidnon", true },
                    { 1265, "", 176, 17, "Bulacan", true },
                    { 1266, "", 176, 18, "Cagayan", true },
                    { 1267, "", 176, 19, "Camarines Norte", true },
                    { 1268, "", 176, 20, "Camarines Sur", true },
                    { 1269, "", 176, 21, "Camiguin", true },
                    { 1270, "", 176, 22, "Capiz", true },
                    { 1271, "", 176, 23, "Catanduanes", true },
                    { 1272, "", 176, 24, "Cavite", true },
                    { 1273, "", 176, 25, "Cebu", true },
                    { 1274, "", 176, 26, "Compostela Valley", true },
                    { 1275, "", 176, 27, "Cotabato", true },
                    { 1276, "", 176, 28, "Davao del Norte", true },
                    { 1277, "", 176, 29, "Davao del Sur", true },
                    { 1278, "", 176, 30, "Davao Occidental", true },
                    { 1279, "", 176, 31, "Davao Oriental", true },
                    { 1280, "", 176, 32, "Dinagat Islands", true },
                    { 1281, "", 176, 33, "Eastern Samar", true },
                    { 1282, "", 176, 34, "Guimaras", true },
                    { 1283, "", 176, 35, "Ifugao", true },
                    { 1284, "", 176, 36, "Ilocos Norte", true },
                    { 1285, "", 176, 37, "Ilocos Sur", true },
                    { 1286, "", 176, 38, "Iloilo", true },
                    { 1287, "", 176, 39, "Isabela", true },
                    { 1288, "", 176, 40, "Kalinga", true },
                    { 1289, "", 176, 41, "La Union", true },
                    { 1290, "", 176, 42, "Laguna", true },
                    { 1291, "", 176, 43, "Lanao del Norte", true },
                    { 1292, "", 176, 44, "Lanao del Sur", true },
                    { 1293, "", 176, 45, "Leyte", true },
                    { 1294, "", 176, 46, "Maguindanao", true },
                    { 1295, "", 176, 47, "Marinduque", true },
                    { 1296, "", 176, 48, "Masbate", true },
                    { 1297, "", 176, 49, "Misamis Occidental", true },
                    { 1298, "", 176, 50, "Misamis Oriental", true },
                    { 1299, "", 176, 51, "Mountain Province", true },
                    { 1300, "", 176, 52, "Negros Occidental", true },
                    { 1301, "", 176, 53, "Negros Oriental", true },
                    { 1302, "", 176, 54, "Northern Samar", true },
                    { 1303, "", 176, 55, "Nueva Ecija", true },
                    { 1304, "", 176, 56, "Nueva Vizcaya", true },
                    { 1305, "", 176, 57, "Occidental Mindoro", true },
                    { 1306, "", 176, 58, "Oriental Mindoro", true },
                    { 1307, "", 176, 59, "Palawan", true },
                    { 1308, "", 176, 60, "Pampanga", true },
                    { 1309, "", 176, 61, "Pangasinan", true },
                    { 1310, "", 176, 62, "Quezon", true },
                    { 1311, "", 176, 63, "Quirino", true },
                    { 1312, "", 176, 64, "Rizal", true },
                    { 1313, "", 176, 65, "Romblon", true },
                    { 1314, "", 176, 66, "Samar", true },
                    { 1315, "", 176, 67, "Sarangani", true },
                    { 1316, "", 176, 68, "Siquijor", true },
                    { 1317, "", 176, 69, "Sorsogon", true },
                    { 1318, "", 176, 70, "South Cotabato", true },
                    { 1319, "", 176, 71, "Southern Leyte", true },
                    { 1320, "", 176, 72, "Sultan Kudarat", true },
                    { 1321, "", 176, 73, "Sulu", true },
                    { 1322, "", 176, 74, "Surigao del Norte", true },
                    { 1323, "", 176, 75, "Surigao del Sur", true },
                    { 1324, "", 176, 76, "Tarlac", true },
                    { 1325, "", 176, 77, "Tawi-Tawi", true },
                    { 1326, "", 176, 78, "Zambales", true },
                    { 1327, "", 176, 79, "Zamboanga del Norte", true },
                    { 1328, "", 176, 80, "Zamboanga del Sur", true },
                    { 1329, "", 176, 81, "Zamboanga Sibugay", true },
                    { 1330, "", 176, 82, "Metro Manila", true },
                    { 1331, "", 169, 0, "Azad Kashmir", true },
                    { 1332, "", 169, 0, "Balochistan", true },
                    { 1333, "", 169, 0, "Capital Territory", true },
                    { 1334, "", 169, 0, "Gilgit–Baltistan", true },
                    { 1335, "", 169, 0, "Khyber Pakhtunkhwa", true },
                    { 1336, "", 169, 0, "Punjab", true },
                    { 1337, "", 169, 0, "Sindh", true },
                    { 1338, "", 169, 0, "Tribal Areas", true },
                    { 1339, "", 178, 0, "Dolnośląskie", true },
                    { 1340, "", 178, 0, "Kujawsko-pomorskie", true },
                    { 1341, "", 178, 0, "Lubelskie", true },
                    { 1342, "", 178, 0, "Lubuskie", true },
                    { 1343, "", 178, 0, "Łódzkie", true },
                    { 1344, "", 178, 0, "Małopolskie", true },
                    { 1345, "", 178, 0, "Mazowieckie", true },
                    { 1346, "", 178, 0, "Opolskie", true },
                    { 1347, "", 178, 0, "Podkarpackie", true },
                    { 1348, "", 178, 0, "Podlaskie", true },
                    { 1349, "", 178, 0, "Pomorskie", true },
                    { 1350, "", 178, 0, "Śląskie", true },
                    { 1351, "", 178, 0, "Świętokrzyskie", true },
                    { 1352, "", 178, 0, "Warmińsko-mazurskie", true },
                    { 1353, "", 178, 0, "Wielkopolskie", true },
                    { 1354, "", 178, 0, "Zachodniopomorskie", true },
                    { 1355, "01", 179, 1, "Aveiro", true },
                    { 1356, "02", 179, 2, "Beja", true },
                    { 1357, "03", 179, 3, "Braga", true },
                    { 1358, "04", 179, 4, "Bragança", true },
                    { 1359, "05", 179, 5, "Castelo Branco", true },
                    { 1360, "06", 179, 6, "Coimbra", true },
                    { 1361, "07", 179, 7, "Évora", true },
                    { 1362, "08", 179, 8, "Faro", true },
                    { 1363, "09", 179, 9, "Guarda", true },
                    { 1364, "10", 179, 10, "Leiria", true },
                    { 1365, "11", 179, 11, "Lisboa", true },
                    { 1366, "12", 179, 12, "Portalegre", true },
                    { 1367, "13", 179, 13, "Porto", true },
                    { 1368, "14", 179, 14, "Santarém", true },
                    { 1369, "15", 179, 15, "Setúbal", true },
                    { 1370, "16", 179, 16, "Viana do Castelo", true },
                    { 1371, "17", 179, 17, "Vila Real", true },
                    { 1372, "18", 179, 18, "Viseu", true },
                    { 1373, "20", 179, 19, "Região Autónoma dos Açores", true },
                    { 1374, "30", 179, 20, "Região Autónoma da Madeira", true },
                    { 1375, "AB", 183, 1, "Alba", true },
                    { 1376, "AR", 183, 2, "Arad", true },
                    { 1377, "AG", 183, 3, "Argeș", true },
                    { 1378, "BC", 183, 4, "Bacău", true },
                    { 1379, "BH", 183, 5, "Bihor", true },
                    { 1380, "BN", 183, 6, "Bistrița-Năsăud", true },
                    { 1381, "BT", 183, 7, "Botoșani", true },
                    { 1382, "BV", 183, 8, "Brașov", true },
                    { 1383, "BR", 183, 9, "Brăila", true },
                    { 1384, "B", 183, 10, "București Sector 1", true },
                    { 1385, "B", 183, 11, "București Sector 2", true },
                    { 1386, "B", 183, 12, "București Sector 3", true },
                    { 1387, "B", 183, 13, "București Sector 4", true },
                    { 1388, "B", 183, 14, "București Sector 5", true },
                    { 1389, "B", 183, 15, "București Sector 6", true },
                    { 1390, "BZ", 183, 16, "Buzău", true },
                    { 1391, "CS", 183, 17, "Caraș-Severin", true },
                    { 1392, "CL", 183, 18, "Călărași", true },
                    { 1393, "CJ", 183, 19, "Cluj", true },
                    { 1394, "CT", 183, 20, "Constanța", true },
                    { 1395, "CV", 183, 21, "Covasna", true },
                    { 1396, "DB", 183, 22, "Dâmbovița", true },
                    { 1397, "DJ", 183, 23, "Dolj", true },
                    { 1398, "GL", 183, 24, "Galați", true },
                    { 1399, "GR", 183, 25, "Giurgiu", true },
                    { 1400, "GJ", 183, 26, "Gorj", true },
                    { 1401, "HR", 183, 27, "Harghita", true },
                    { 1402, "HD", 183, 28, "Hunedoara", true },
                    { 1403, "IL", 183, 29, "Ialomița", true },
                    { 1404, "IS", 183, 30, "Iași", true },
                    { 1405, "IF", 183, 31, "Ilfov", true },
                    { 1406, "MM", 183, 32, "Maramureș", true },
                    { 1407, "MH", 183, 33, "Mehedinți", true },
                    { 1408, "MS", 183, 34, "Mureș", true },
                    { 1409, "NT", 183, 35, "Neamț", true },
                    { 1410, "OT", 183, 36, "Olt", true },
                    { 1411, "PH", 183, 37, "Prahova", true },
                    { 1412, "SM", 183, 38, "Satu Mare", true },
                    { 1413, "SJ", 183, 39, "Sălaj", true },
                    { 1414, "SB", 183, 40, "Sibiu", true },
                    { 1415, "SV", 183, 41, "Suceava", true },
                    { 1416, "TR", 183, 42, "Teleorman", true },
                    { 1417, "TM", 183, 43, "Timiș", true },
                    { 1418, "TL", 183, 44, "Tulcea", true },
                    { 1419, "VS", 183, 45, "Vaslui", true },
                    { 1420, "VL", 183, 46, "Vâlcea", true },
                    { 1421, "VN", 183, 47, "Vrancea", true },
                    { 1422, "", 198, 0, "Serbia", true },
                    { 1423, "", 198, 0, "Kosovo", true },
                    { 1424, "", 198, 0, "Vojvodina", true },
                    { 1425, "01", 184, 1, "Адыгея", true },
                    { 1426, "04", 184, 1, "Алтай", true },
                    { 1427, "22", 184, 1, "Алтайский край", true },
                    { 1428, "28", 184, 1, "Амурская область", true },
                    { 1429, "29", 184, 1, "Архангельская область", true },
                    { 1430, "30", 184, 1, "Астраханская область", true },
                    { 1431, "02", 184, 1, "Башкортостан", true },
                    { 1432, "31", 184, 1, "Белгородская область", true },
                    { 1433, "32", 184, 1, "Брянская область", true },
                    { 1434, "03", 184, 1, "Бурятия", true },
                    { 1435, "33", 184, 1, "Владимирская область", true },
                    { 1436, "34", 184, 1, "Волгоградская область", true },
                    { 1437, "35", 184, 1, "Вологодская область", true },
                    { 1438, "36", 184, 1, "Воронежская область", true },
                    { 1439, "05", 184, 1, "Дагестан", true },
                    { 1440, "79", 184, 1, "Еврейская автономная область", true },
                    { 1441, "75", 184, 1, "Забайкальский край", true },
                    { 1442, "37", 184, 1, "Ивановская область", true },
                    { 1443, "06", 184, 1, "Ингушетия", true },
                    { 1444, "38", 184, 1, "Иркутская область", true },
                    { 1445, "7", 184, 1, "Кабардино-Балкарская Республика", true },
                    { 1446, "39", 184, 1, "Калининградская область", true },
                    { 1447, "08", 184, 1, "Калмыкия", true },
                    { 1448, "40", 184, 1, "Калужская область", true },
                    { 1449, "41", 184, 1, "Камчатский край", true },
                    { 1450, "09", 184, 1, "Карачаево-Черкесская Республика", true },
                    { 1451, "10", 184, 1, "Карелия", true },
                    { 1452, "42", 184, 1, "Кемеровская область", true },
                    { 1453, "43", 184, 1, "Кировская область", true },
                    { 1454, "11", 184, 1, "Коми", true },
                    { 1455, "44", 184, 1, "Костромская область", true },
                    { 1456, "23", 184, 1, "Краснодарский край", true },
                    { 1457, "24", 184, 1, "Красноярский край", true },
                    { 1458, "45", 184, 1, "Курганская область", true },
                    { 1459, "46", 184, 1, "Курская область", true },
                    { 1460, "47", 184, 1, "Ленинградская область", true },
                    { 1461, "48", 184, 1, "Липецкая область", true },
                    { 1462, "49", 184, 1, "Магаданская область", true },
                    { 1463, "12", 184, 1, "Марий Эл", true },
                    { 1464, "13", 184, 1, "Мордовия", true },
                    { 1465, "77", 184, 1, "Москва", true },
                    { 1466, "50", 184, 1, "Московская область", true },
                    { 1467, "51", 184, 1, "Мурманская область", true },
                    { 1468, "83", 184, 1, "Ненецкий автономный округ", true },
                    { 1469, "52", 184, 1, "Нижегородская область", true },
                    { 1470, "53", 184, 1, "Новгородская область", true },
                    { 1471, "54", 184, 1, "Новосибирская область", true },
                    { 1472, "55", 184, 1, "Омская область", true },
                    { 1473, "56", 184, 1, "Оренбургская область", true },
                    { 1474, "57", 184, 1, "Орловская область", true },
                    { 1475, "58", 184, 1, "Пензенская область", true },
                    { 1476, "59", 184, 1, "Пермский край", true },
                    { 1477, "25", 184, 1, "Приморский край", true },
                    { 1478, "60", 184, 1, "Псковская область", true },
                    { 1479, "61", 184, 1, "Ростовская область", true },
                    { 1480, "62", 184, 1, "Рязанская область", true },
                    { 1481, "63", 184, 1, "Самарская область", true },
                    { 1482, "78", 184, 1, "Санкт-Петербург", true },
                    { 1483, "64", 184, 1, "Саратовская область", true },
                    { 1484, "14", 184, 1, "Саха (Якутия)", true },
                    { 1485, "65", 184, 1, "Сахалинская область", true },
                    { 1486, "66", 184, 1, "Свердловская область", true },
                    { 1487, "92", 184, 1, "Севастополь", true },
                    { 1488, "15", 184, 1, "Северная Осетия-Алания", true },
                    { 1489, "67", 184, 1, "Смоленская область", true },
                    { 1490, "26", 184, 1, "Ставропольский край", true },
                    { 1491, "68", 184, 1, "Тамбовская область", true },
                    { 1492, "16", 184, 1, "Татарстан", true },
                    { 1493, "69", 184, 1, "Тверская область", true },
                    { 1494, "70", 184, 1, "Томская область", true },
                    { 1495, "71", 184, 1, "Тульская область", true },
                    { 1496, "17", 184, 1, "Тыва", true },
                    { 1497, "72", 184, 1, "Тюменская область", true },
                    { 1498, "18", 184, 1, "Удмуртская Республика", true },
                    { 1499, "73", 184, 1, "Ульяновская область", true },
                    { 1500, "27", 184, 1, "Хабаровский край", true },
                    { 1501, "19", 184, 1, "Хакасия", true },
                    { 1502, "86", 184, 1, "Ханты-Мансийский автономный округ-Югра", true },
                    { 1503, "74", 184, 1, "Челябинская область", true },
                    { 1504, "95", 184, 1, "Чеченская Республика", true },
                    { 1505, "21", 184, 1, "Чувашская Республика", true },
                    { 1506, "87", 184, 1, "Чукотский автономный округ", true },
                    { 1507, "89", 184, 1, "Ямало-Ненецкий автономный округ", true },
                    { 1508, "76", 184, 1, "Ярославская область", true },
                    { 1509, "", 196, 0, "Eastern Cape", true },
                    { 1510, "", 196, 1, "Al Bahah", true },
                    { 1511, "", 196, 2, "Al Jawf", true },
                    { 1512, "", 196, 3, "Al Madinah", true },
                    { 1513, "", 196, 4, "Al Qasim", true },
                    { 1514, "", 196, 5, "Al Riyadh", true },
                    { 1515, "", 196, 6, "Asir", true },
                    { 1516, "", 196, 7, "Eastern Province", true },
                    { 1517, "", 196, 8, "Ha'il", true },
                    { 1518, "", 196, 9, "Jizan", true },
                    { 1519, "", 196, 10, "Makkah", true },
                    { 1520, "", 196, 11, "Najran", true },
                    { 1521, "", 196, 12, "Northern Borders", true },
                    { 1522, "", 196, 13, "Tabuk", true },
                    { 1523, "01", 215, 1, "Stockholms län", true },
                    { 1524, "03", 215, 3, "Uppsala län", true },
                    { 1525, "04", 215, 4, "Södermanlands län", true },
                    { 1526, "05", 215, 5, "Östergötlands län", true },
                    { 1527, "06", 215, 6, "Jönköpings län", true },
                    { 1528, "07", 215, 7, "Kronobergs län", true },
                    { 1529, "08", 215, 8, "Kalmar län", true },
                    { 1530, "09", 215, 9, "Gotlands län", true },
                    { 1531, "11", 215, 11, "Blekinge län", true },
                    { 1532, "12", 215, 12, "Skåne län", true },
                    { 1533, "14", 215, 14, "Hallands län", true },
                    { 1534, "15", 215, 15, "Västra Götalands län", true },
                    { 1535, "17", 215, 17, "Värmlands län", true },
                    { 1536, "18", 215, 18, "Örebro län", true },
                    { 1537, "19", 215, 19, "Västmanlands län", true },
                    { 1538, "20", 215, 20, "Dalarnas län", true },
                    { 1539, "21", 215, 21, "Gävleborgs län", true },
                    { 1540, "22", 215, 22, "Jämtlands län", true },
                    { 1541, "23", 215, 23, "Västernorrlands län", true },
                    { 1542, "24", 215, 24, "Västerbottens län", true },
                    { 1543, "25", 215, 25, "Norbottens län", true },
                    { 1544, "", 204, 0, "Pomurska", true },
                    { 1545, "", 204, 0, "Podravska", true },
                    { 1546, "", 204, 0, "Koroška", true },
                    { 1547, "", 204, 0, "Savinjska", true },
                    { 1548, "", 204, 0, "Zasavska", true },
                    { 1549, "", 204, 0, "Posavska", true },
                    { 1550, "", 204, 0, "Jugovzhodna Slovenija", true },
                    { 1551, "", 204, 0, "Primorsko-notranjska", true },
                    { 1552, "", 204, 0, "Osrednjeslovenska", true },
                    { 1553, "", 204, 0, "Gorenjska", true },
                    { 1554, "", 204, 0, "Goriška", true },
                    { 1555, "", 204, 0, "Obalno-kraška", true },
                    { 1556, "", 203, 0, "Bratislavský kraj", true },
                    { 1557, "", 203, 0, "Trnavský kraj", true },
                    { 1558, "", 203, 0, "Nitrianský kraj", true },
                    { 1559, "", 203, 0, "Trenčianský kraj", true },
                    { 1560, "", 203, 0, "Žilinský kraj", true },
                    { 1561, "", 203, 0, "Banskobystrický kraj", true },
                    { 1562, "", 203, 0, "Košický kraj", true },
                    { 1563, "", 203, 0, "Prešovský kraj", true },
                    { 1564, "", 228, 0, "Adana", true },
                    { 1565, "", 228, 0, "Adıyaman", true },
                    { 1566, "", 228, 0, "Afyonkarahisar", true },
                    { 1567, "", 228, 0, "Ağrı", true },
                    { 1568, "", 228, 0, "Aksaray", true },
                    { 1569, "", 228, 0, "Amasya", true },
                    { 1570, "", 228, 0, "Ankara", true },
                    { 1571, "", 228, 0, "Antalya", true },
                    { 1572, "", 228, 0, "Ardahan", true },
                    { 1573, "", 228, 0, "Artvin", true },
                    { 1574, "", 228, 0, "Aydın", true },
                    { 1575, "", 228, 0, "Balıkesir", true },
                    { 1576, "", 228, 0, "Bartın", true },
                    { 1577, "", 228, 0, "Batman", true },
                    { 1578, "", 228, 0, "Bayburt", true },
                    { 1579, "", 228, 0, "Bilecik", true },
                    { 1580, "", 228, 0, "Bingöl", true },
                    { 1581, "", 228, 0, "Bitlis", true },
                    { 1582, "", 228, 0, "Bolu", true },
                    { 1583, "", 228, 0, "Burdur", true },
                    { 1584, "", 228, 0, "Bursa", true },
                    { 1585, "", 228, 0, "Çanakkale", true },
                    { 1586, "", 228, 0, "Çankırı", true },
                    { 1587, "", 228, 0, "Çorum", true },
                    { 1588, "", 228, 0, "Denizli", true },
                    { 1589, "", 228, 0, "Diyarbakır", true },
                    { 1590, "", 228, 0, "Düzce", true },
                    { 1591, "", 228, 0, "Edirne", true },
                    { 1592, "", 228, 0, "Elazığ", true },
                    { 1593, "", 228, 0, "Erzincan", true },
                    { 1594, "", 228, 0, "Erzurum", true },
                    { 1595, "", 228, 0, "Eskişehir", true },
                    { 1596, "", 228, 0, "Gaziantep", true },
                    { 1597, "", 228, 0, "Giresun", true },
                    { 1598, "", 228, 0, "Gümüşhane", true },
                    { 1599, "", 228, 0, "Hakkari", true },
                    { 1600, "", 228, 0, "Hatay", true },
                    { 1601, "", 228, 0, "Iğdır", true },
                    { 1602, "", 228, 0, "Isparta", true },
                    { 1603, "", 228, 0, "İstanbul", true },
                    { 1604, "", 228, 0, "İzmir", true },
                    { 1605, "", 228, 0, "Kahramanmaraş", true },
                    { 1606, "", 228, 0, "Karabük", true },
                    { 1607, "", 228, 0, "Karaman", true },
                    { 1608, "", 228, 0, "Kars", true },
                    { 1609, "", 228, 0, "Kastamonu", true },
                    { 1610, "", 228, 0, "Kayseri", true },
                    { 1611, "", 228, 0, "Kırıkkale", true },
                    { 1612, "", 228, 0, "Kırklareli", true },
                    { 1613, "", 228, 0, "Kırşehir", true },
                    { 1614, "", 228, 0, "Kilis", true },
                    { 1615, "", 228, 0, "Kocaeli", true },
                    { 1616, "", 228, 0, "Konya", true },
                    { 1617, "", 228, 0, "Kütahya", true },
                    { 1618, "", 228, 0, "Malatya", true },
                    { 1619, "", 228, 0, "Manisa", true },
                    { 1620, "", 228, 0, "Mardin", true },
                    { 1621, "", 228, 0, "Mersin", true },
                    { 1622, "", 228, 0, "Muğla", true },
                    { 1623, "", 228, 0, "Muş", true },
                    { 1624, "", 228, 0, "Nevşehir", true },
                    { 1625, "", 228, 0, "Niğde", true },
                    { 1626, "", 228, 0, "Ordu", true },
                    { 1627, "", 228, 0, "Osmaniye", true },
                    { 1628, "", 228, 0, "Rize", true },
                    { 1629, "", 228, 0, "Sakarya", true },
                    { 1630, "", 228, 0, "Samsun", true },
                    { 1631, "", 228, 0, "Siirt", true },
                    { 1632, "", 228, 0, "Sinop", true },
                    { 1633, "", 228, 0, "Sivas", true },
                    { 1634, "", 228, 0, "Şanlıurfa", true },
                    { 1635, "", 228, 0, "Şırnak", true },
                    { 1636, "", 228, 0, "Tekirdağ", true },
                    { 1637, "", 228, 0, "Tokat", true },
                    { 1638, "", 228, 0, "Trabzon", true },
                    { 1639, "", 228, 0, "Tunceli", true },
                    { 1640, "", 228, 0, "Uşak", true },
                    { 1641, "", 228, 0, "Van", true },
                    { 1642, "", 228, 0, "Yalova", true },
                    { 1643, "", 228, 0, "Yozgat", true },
                    { 1644, "", 228, 0, "Zonguldak", true },
                    { 1645, "Вінн. обл.", 233, 2, "Вінницька область", true },
                    { 1646, "Волин. обл.", 233, 3, "Волинська область", true },
                    { 1647, "Дніпроп. обл.", 233, 4, "Дніпропетровська область", true },
                    { 1648, "Донец. обл.", 233, 5, "Донецька область", true },
                    { 1649, "Житом. обл.", 233, 6, "Житомирська область", true },
                    { 1650, "Закарп. обл.", 233, 7, "Закарпатська область", true },
                    { 1651, "Запоріз. обл.", 233, 8, "Запорізька область", true },
                    { 1652, "Івано-Фр. обл.", 233, 9, "Івано-Франківська область", true },
                    { 1653, "Київ. обл.", 233, 10, "Київська область", true },
                    { 1654, "Кіровогр. обл.", 233, 11, "Кіровоградська область", true },
                    { 1655, "Луган. обл.", 233, 12, "Луганська область", true },
                    { 1656, "Львів. обл.", 233, 13, "Львівська область", true },
                    { 1657, "Микол. обл.", 233, 14, "Миколаївська область", true },
                    { 1658, "Одес. обл.", 233, 15, "Одеська область", true },
                    { 1659, "Полтав. обл.", 233, 16, "Полтавська область", true },
                    { 1660, "Рівн. обл.", 233, 17, "Рівненська область", true },
                    { 1661, "Сумськ. обл.", 233, 18, "Сумська область", true },
                    { 1662, "Терноп. обл.", 233, 19, "Тернопільська область", true },
                    { 1663, "Харк. обл.", 233, 20, "Харківська область", true },
                    { 1664, "Херсон. обл.", 233, 20, "Херсонська область", true },
                    { 1665, "Хмельн. обл.", 233, 21, "Хмельницька область", true },
                    { 1666, "Черкас. обл.", 233, 22, "Черкаська область", true },
                    { 1667, "Чернів. обл.", 233, 23, "Чернівецька область", true },
                    { 1668, "Черніг. обл.", 233, 24, "Чернігівська область", true },
                    { 1669, "AA", 237, 1, "AA (Armed Forces Americas)", true },
                    { 1670, "AE", 237, 1, "AE (Armed Forces Europe)", true },
                    { 1671, "AL", 237, 1, "Alabama", true },
                    { 1672, "AK", 237, 1, "Alaska", true },
                    { 1673, "AS", 237, 1, "American Samoa", true },
                    { 1674, "AP", 237, 1, "AP (Armed Forces Pacific)", true },
                    { 1675, "AZ", 237, 1, "Arizona", true },
                    { 1676, "AR", 237, 1, "Arkansas", true },
                    { 1677, "CA", 237, 1, "California", true },
                    { 1678, "CO", 237, 1, "Colorado", true },
                    { 1679, "CT", 237, 1, "Connecticut", true },
                    { 1680, "DE", 237, 1, "Delaware", true },
                    { 1681, "DC", 237, 1, "District of Columbia", true },
                    { 1682, "FM", 237, 1, "Federated States of Micronesia", true },
                    { 1683, "FL", 237, 1, "Florida", true },
                    { 1684, "GA", 237, 1, "Georgia", true },
                    { 1685, "GU", 237, 1, "Guam", true },
                    { 1686, "HI", 237, 1, "Hawaii", true },
                    { 1687, "ID", 237, 1, "Idaho", true },
                    { 1688, "IL", 237, 1, "Illinois", true },
                    { 1689, "IN", 237, 1, "Indiana", true },
                    { 1690, "IA", 237, 1, "Iowa", true },
                    { 1691, "KS", 237, 1, "Kansas", true },
                    { 1692, "KY", 237, 1, "Kentucky", true },
                    { 1693, "LA", 237, 1, "Louisiana", true },
                    { 1694, "ME", 237, 1, "Maine", true },
                    { 1695, "MH", 237, 1, "Marshall Islands", true },
                    { 1696, "MD", 237, 1, "Maryland", true },
                    { 1697, "MA", 237, 1, "Massachusetts", true },
                    { 1698, "MI", 237, 1, "Michigan", true },
                    { 1699, "MN", 237, 1, "Minnesota", true },
                    { 1700, "MS", 237, 1, "Mississippi", true },
                    { 1701, "MO", 237, 1, "Missouri", true },
                    { 1702, "MT", 237, 1, "Montana", true },
                    { 1703, "NE", 237, 1, "Nebraska", true },
                    { 1704, "NV", 237, 1, "Nevada", true },
                    { 1705, "NH", 237, 1, "New Hampshire", true },
                    { 1706, "NJ", 237, 1, "New Jersey", true },
                    { 1707, "NM", 237, 1, "New Mexico", true },
                    { 1708, "NY", 237, 1, "New York", true },
                    { 1709, "NC", 237, 1, "North Carolina", true },
                    { 1710, "ND", 237, 1, "North Dakota", true },
                    { 1711, "MP", 237, 1, "Northern Mariana Islands", true },
                    { 1712, "OH", 237, 1, "Ohio", true },
                    { 1713, "OK", 237, 1, "Oklahoma", true },
                    { 1714, "OR", 237, 1, "Oregon", true },
                    { 1715, "PW", 237, 1, "Palau", true },
                    { 1716, "PA", 237, 1, "Pennsylvania", true },
                    { 1717, "PR", 237, 1, "Puerto Rico", true },
                    { 1718, "RI", 237, 1, "Rhode Island", true },
                    { 1719, "SC", 237, 1, "South Carolina", true },
                    { 1720, "SD", 237, 1, "South Dakota", true },
                    { 1721, "TN", 237, 1, "Tennessee", true },
                    { 1722, "TX", 237, 1, "Texas", true },
                    { 1723, "UT", 237, 1, "Utah", true },
                    { 1724, "VT", 237, 1, "Vermont", true },
                    { 1725, "VI", 237, 1, "Virgin Islands", true },
                    { 1726, "VA", 237, 1, "Virginia", true },
                    { 1727, "WA", 237, 1, "Washington", true },
                    { 1728, "WV", 237, 1, "West Virginia", true },
                    { 1729, "WI", 237, 1, "Wisconsin", true },
                    { 1730, "WY", 237, 1, "Wyoming", true },
                    { 1731, "", 241, 1, "Amazonas", true },
                    { 1732, "", 241, 2, "Anzoategui", true },
                    { 1733, "", 241, 3, "Apure", true },
                    { 1734, "", 241, 4, "Aragua", true },
                    { 1735, "", 241, 5, "Barinas", true },
                    { 1736, "", 241, 6, "Bolívar", true },
                    { 1737, "", 241, 7, "Carabobo", true },
                    { 1738, "", 241, 8, "Cojedes", true },
                    { 1739, "", 241, 9, "Delta Amacuro", true },
                    { 1740, "", 241, 10, "Distrito Capital", true },
                    { 1741, "", 241, 11, "Falcón", true },
                    { 1742, "", 241, 12, "Guárico", true },
                    { 1743, "", 241, 13, "Lara", true },
                    { 1744, "", 241, 14, "Mérida", true },
                    { 1745, "", 241, 15, "Miranda", true },
                    { 1746, "", 241, 16, "Monagas", true },
                    { 1747, "", 241, 17, "Nueva Esparta", true },
                    { 1748, "", 241, 18, "Portuguesa", true },
                    { 1749, "", 241, 19, "Sucre", true },
                    { 1750, "", 241, 20, "Táchira", true },
                    { 1751, "", 241, 21, "Trujillo", true },
                    { 1752, "", 241, 22, "Vargas", true },
                    { 1753, "", 241, 23, "Yaracuy", true },
                    { 1754, "", 241, 24, "Zulia", true },
                    { 1755, "HN", 242, 1, "Hà Nội", true },
                    { 1756, "HCM", 242, 2, "Hồ Chí Minh", true },
                    { 1757, "ĐN", 242, 3, "Đà Nẵng", true },
                    { 1758, "HP", 242, 4, "Hải Phòng", true },
                    { 1759, "CT", 242, 5, "Cần Thơ", true },
                    { 1760, "HG", 242, 6, "Hà Giang", true },
                    { 1761, "CB", 242, 6, "Cao Bằng", true },
                    { 1762, "BK", 242, 6, "Bắc Kạn", true },
                    { 1763, "TQ", 242, 6, "Tuyên Quang", true },
                    { 1764, "LC", 242, 6, "Lào Cai", true },
                    { 1765, "ĐB", 242, 6, "Điện Biên", true },
                    { 1766, "LC", 242, 6, "Lai Châu", true },
                    { 1767, "SL", 242, 6, "Sơn La", true },
                    { 1768, "YB", 242, 6, "Yên Bái", true },
                    { 1769, "HB", 242, 6, "Hòa Bình", true },
                    { 1770, "TN", 242, 6, "Thái Nguyên", true },
                    { 1771, "LS", 242, 6, "Lạng Sơn", true },
                    { 1772, "QN", 242, 6, "Quảng Ninh", true },
                    { 1773, "BG", 242, 6, "Bắc Giang", true },
                    { 1774, "PT", 242, 6, "Phú Thọ", true },
                    { 1775, "VP", 242, 6, "Vĩnh Phúc", true },
                    { 1776, "BN", 242, 6, "Bắc Ninh", true },
                    { 1777, "HD", 242, 6, "Hải Dương", true },
                    { 1778, "HY", 242, 6, "Hưng Yên", true },
                    { 1779, "TB", 242, 6, "Thái Bình", true },
                    { 1780, "HN", 242, 6, "Hà Nam", true },
                    { 1781, "NĐ", 242, 6, "Nam Định", true },
                    { 1782, "NB", 242, 6, "Ninh Bình", true },
                    { 1783, "TH", 242, 6, "Thanh Hóa", true },
                    { 1784, "NA", 242, 6, "Nghệ An", true },
                    { 1785, "HT", 242, 6, "Hà Tĩnh", true },
                    { 1786, "QB", 242, 6, "Quảng Bình", true },
                    { 1787, "QT", 242, 6, "Quảng Trị", true },
                    { 1788, "TTH", 242, 6, "Thừa Thiên Huế", true },
                    { 1789, "QN", 242, 6, "Quảng Nam", true },
                    { 1790, "QN", 242, 6, "Quảng Ngãi", true },
                    { 1791, "BĐ", 242, 6, "Bình Định", true },
                    { 1792, "PY", 242, 6, "Phú Yên", true },
                    { 1793, "KH", 242, 6, "Khánh Hòa", true },
                    { 1794, "NT", 242, 6, "Ninh Thuận", true },
                    { 1795, "BT", 242, 6, "Bình Thuận", true },
                    { 1796, "KT", 242, 6, "Kon Tum", true },
                    { 1797, "GL", 242, 6, "Gia Lai", true },
                    { 1798, "ĐL", 242, 6, "Đắk Lắk", true },
                    { 1799, "ĐN", 242, 6, "Đắk Nông", true },
                    { 1800, "LĐ", 242, 6, "Lâm Đồng", true },
                    { 1801, "BP", 242, 6, "Bình Phước", true },
                    { 1802, "TN", 242, 6, "Tây Ninh", true },
                    { 1803, "BD", 242, 6, "Bình Dương", true },
                    { 1804, "ĐN", 242, 6, "Đồng Nai", true },
                    { 1805, "BR", 242, 6, "Bà Rịa - Vũng Tàu", true },
                    { 1806, "LA", 242, 6, "Long An", true },
                    { 1807, "TG", 242, 6, "Tiền Giang", true },
                    { 1808, "BT", 242, 6, "Bến Tre", true },
                    { 1809, "TV", 242, 6, "Trà Vinh", true },
                    { 1810, "VL", 242, 6, "Vĩnh Long", true },
                    { 1811, "ĐT", 242, 6, "Đồng Tháp", true },
                    { 1812, "AG", 242, 6, "An Giang", true },
                    { 1813, "KG", 242, 6, "Kiên Giang", true },
                    { 1814, "HG", 242, 6, "Hậu Giang", true },
                    { 1815, "ST", 242, 6, "Sóc Trăng", true },
                    { 1816, "BL", 242, 6, "Bạc Liêu", true },
                    { 1817, "CM", 242, 6, "Cà Mau", true },
                    { 1818, "EC", 207, 0, "Eastern Cape", true },
                    { 1819, "FS", 207, 0, "Free State", true },
                    { 1820, "GP", 207, 0, "Gauteng", true },
                    { 1821, "KZN", 207, 0, "KwaZulu-Natal", true },
                    { 1822, "LP", 207, 0, "Limpopo", true },
                    { 1823, "MP", 207, 0, "Mpumalanga", true },
                    { 1824, "NC", 207, 0, "Northern Cape", true },
                    { 1825, "NW", 207, 0, "North West", true },
                    { 1826, "WC", 207, 0, "Western Cape", true },
                    { 1827, "BU", 249, 0, "Bulawayo", true },
                    { 1828, "HA", 249, 0, "Harare", true },
                    { 1829, "MA", 249, 0, "Manicaland", true },
                    { 1830, "MC", 249, 0, "Mashonaland Central", true },
                    { 1831, "ME", 249, 0, "Mashonaland East", true },
                    { 1832, "MW", 249, 0, "Mashonaland West", true },
                    { 1833, "MV", 249, 0, "Masvingo", true },
                    { 1834, "MN", 249, 0, "Matabeleland North", true },
                    { 1835, "MS", 249, 0, "Matabeleland South", true },
                    { 1836, "MI", 249, 0, "Midlands", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "DeliveryDate",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "DeliveryDate",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "DeliveryDate",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "ShippingMethod",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "ShippingMethod",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "ShippingMethod",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 592);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 593);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 594);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 595);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 596);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 597);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 599);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 605);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 606);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 607);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 609);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 617);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 618);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 619);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 623);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 625);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 626);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 627);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 628);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 629);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 631);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 632);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 633);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 635);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 636);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 637);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 638);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 639);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 640);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 641);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 644);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 645);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 646);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 647);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 648);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 649);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 650);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 651);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 652);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 653);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 654);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 655);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 656);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 657);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 658);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 659);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 660);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 661);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 662);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 663);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 664);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 665);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 667);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 668);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 669);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 670);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 671);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 672);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 673);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 674);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 675);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 676);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 677);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 678);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 679);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 680);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 681);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 682);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 683);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 684);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 685);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 686);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 687);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 688);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 689);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 690);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 691);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 692);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 693);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 694);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 695);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 696);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 697);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 698);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 699);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 704);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 705);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 706);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 707);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 708);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 709);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 710);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 711);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 712);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 713);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 714);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 715);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 716);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 717);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 718);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 719);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 720);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 721);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 722);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 723);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 724);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 725);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 726);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 727);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 728);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 729);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 730);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 731);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 732);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 733);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 734);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 735);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 736);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 737);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 738);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 739);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 740);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 741);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 742);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 743);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 744);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 745);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 746);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 747);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 748);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 749);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 750);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 752);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 753);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 754);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 755);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 756);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 757);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 758);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 759);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 763);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 765);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 766);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 767);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 769);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 770);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 773);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 774);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 775);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 777);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 778);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 779);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 782);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 783);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 785);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 786);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 787);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 790);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 791);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 793);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 794);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 797);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 799);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 805);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 806);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 808);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 809);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 810);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 811);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 812);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 813);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 814);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 815);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 816);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 817);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 819);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 820);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 821);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 822);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 823);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 824);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 825);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 826);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 827);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 828);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 829);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 830);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 831);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 832);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 833);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 834);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 835);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 836);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 837);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 838);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 839);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 840);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 841);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 842);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 843);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 844);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 845);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 846);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 847);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 848);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 849);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 850);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 851);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 852);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 853);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 854);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 855);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 856);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 857);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 858);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 859);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 860);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 861);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 862);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 863);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 864);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 865);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 866);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 867);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 868);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 869);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 870);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 871);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 872);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 873);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 874);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 875);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 876);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 877);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 878);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 879);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 880);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 881);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 882);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 883);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 884);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 885);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 886);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 887);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 888);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 889);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 890);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 891);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 892);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 893);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 894);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 895);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 896);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 897);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 898);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 899);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 902);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 903);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 904);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 905);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 906);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 907);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 908);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 909);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 910);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 911);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 912);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 913);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 914);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 915);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 916);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 917);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 918);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 919);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 920);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 921);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 922);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 923);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 924);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 925);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 926);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 927);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 928);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 929);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 930);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 931);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 932);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 933);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 934);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 935);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 936);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 937);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 938);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 939);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 940);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 941);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 942);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 943);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 944);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 945);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 946);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 947);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 948);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 949);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 950);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 951);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 952);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 953);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 954);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 955);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 956);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 957);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 958);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 959);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 960);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 961);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 962);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 963);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 964);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 965);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 966);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 967);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 968);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 969);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 970);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 971);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 972);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 973);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 974);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 975);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 976);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 977);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 978);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 979);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 980);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 981);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 982);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 983);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 984);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 985);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 986);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 987);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 988);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 989);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 990);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 991);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 992);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 993);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 994);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 995);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 996);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 997);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 998);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1048);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1049);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1058);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1059);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1069);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1071);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1072);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1073);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1074);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1075);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1076);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1077);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1078);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1079);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1084);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1085);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1086);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1087);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1088);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1089);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1090);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1091);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1092);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1093);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1094);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1095);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1096);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1097);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1098);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1099);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1109);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1122);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1123);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1124);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1125);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1126);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1127);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1128);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1129);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1130);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1131);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1132);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1133);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1134);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1135);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1136);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1138);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1139);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1140);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1141);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1142);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1143);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1144);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1145);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1146);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1147);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1148);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1149);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1150);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1152);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1153);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1154);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1155);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1156);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1157);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1158);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1159);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1160);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1161);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1162);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1163);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1164);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1165);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1166);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1167);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1168);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1169);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1170);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1171);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1172);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1173);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1174);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1175);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1176);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1177);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1178);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1179);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1180);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1181);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1182);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1183);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1184);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1185);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1186);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1187);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1188);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1189);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1190);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1191);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1192);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1193);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1194);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1195);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1196);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1197);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1198);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1199);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1208);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1209);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1218);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1219);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1222);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1223);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1224);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1225);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1226);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1227);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1228);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1229);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1230);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1231);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1232);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1233);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1235);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1236);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1237);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1238);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1249);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1250);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1251);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1252);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1253);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1254);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1255);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1256);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1257);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1258);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1259);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1260);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1261);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1262);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1263);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1264);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1265);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1266);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1267);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1268);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1269);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1270);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1271);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1272);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1273);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1274);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1275);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1276);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1277);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1278);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1279);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1280);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1281);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1282);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1283);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1284);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1285);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1286);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1287);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1288);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1289);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1290);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1291);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1292);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1293);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1294);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1295);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1296);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1297);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1298);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1299);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1303);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1304);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1305);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1306);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1307);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1308);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1309);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1310);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1311);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1312);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1313);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1314);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1315);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1316);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1317);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1318);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1319);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1320);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1321);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1322);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1323);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1324);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1325);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1326);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1327);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1328);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1329);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1330);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1331);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1332);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1333);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1334);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1335);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1336);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1337);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1338);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1339);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1340);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1341);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1342);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1343);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1344);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1345);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1346);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1347);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1348);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1349);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1350);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1351);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1352);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1353);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1354);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1355);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1356);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1357);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1358);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1359);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1360);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1361);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1362);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1363);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1364);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1365);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1366);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1367);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1368);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1369);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1370);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1371);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1372);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1373);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1374);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1375);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1376);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1377);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1378);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1379);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1380);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1381);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1382);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1383);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1384);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1385);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1386);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1387);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1388);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1389);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1390);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1391);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1392);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1393);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1394);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1395);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1396);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1397);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1398);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1399);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1400);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1401);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1402);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1403);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1404);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1405);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1406);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1407);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1408);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1409);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1410);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1411);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1412);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1413);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1414);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1415);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1416);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1417);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1418);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1419);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1420);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1421);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1422);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1423);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1424);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1425);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1426);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1427);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1428);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1429);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1430);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1431);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1432);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1433);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1434);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1435);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1436);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1437);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1438);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1439);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1440);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1441);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1442);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1443);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1444);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1445);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1446);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1447);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1448);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1449);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1450);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1451);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1452);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1453);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1454);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1455);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1456);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1457);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1458);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1459);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1460);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1461);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1462);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1463);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1464);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1465);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1466);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1467);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1468);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1469);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1470);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1471);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1472);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1473);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1474);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1475);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1476);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1477);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1478);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1479);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1480);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1481);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1482);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1483);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1484);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1485);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1486);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1487);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1488);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1489);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1490);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1491);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1492);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1493);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1494);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1495);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1496);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1497);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1498);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1499);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1500);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1501);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1502);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1503);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1504);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1505);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1506);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1507);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1508);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1509);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1510);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1511);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1512);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1513);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1514);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1515);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1516);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1517);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1518);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1519);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1520);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1521);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1522);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1523);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1524);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1525);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1526);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1527);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1528);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1529);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1530);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1531);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1532);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1533);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1534);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1535);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1536);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1537);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1538);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1539);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1540);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1541);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1542);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1543);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1544);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1545);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1546);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1547);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1548);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1549);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1550);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1551);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1552);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1553);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1554);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1555);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1556);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1557);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1558);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1559);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1560);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1561);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1562);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1563);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1564);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1565);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1566);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1567);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1568);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1569);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1570);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1571);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1572);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1573);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1574);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1575);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1576);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1577);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1578);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1579);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1580);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1581);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1582);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1583);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1584);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1585);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1586);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1587);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1588);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1589);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1590);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1591);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1592);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1593);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1594);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1595);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1596);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1597);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1598);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1599);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1600);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1601);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1602);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1603);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1604);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1605);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1606);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1607);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1608);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1609);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1610);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1611);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1612);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1613);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1614);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1615);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1616);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1617);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1618);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1619);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1620);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1621);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1622);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1623);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1624);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1625);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1626);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1627);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1628);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1629);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1630);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1631);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1632);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1633);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1634);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1635);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1636);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1637);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1638);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1639);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1640);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1641);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1642);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1643);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1644);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1645);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1646);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1647);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1648);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1649);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1650);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1651);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1652);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1653);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1654);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1655);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1656);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1657);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1658);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1659);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1660);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1661);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1662);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1663);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1664);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1665);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1666);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1667);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1668);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1669);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1670);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1671);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1672);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1673);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1674);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1675);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1676);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1677);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1678);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1679);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1680);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1681);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1682);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1683);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1684);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1685);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1686);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1687);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1688);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1689);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1690);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1691);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1692);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1693);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1694);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1695);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1696);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1697);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1698);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1699);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1700);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1701);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1702);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1703);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1704);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1705);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1706);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1707);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1708);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1709);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1710);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1711);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1712);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1713);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1714);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1715);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1716);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1717);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1718);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1719);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1720);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1721);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1722);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1723);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1724);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1725);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1726);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1727);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1728);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1729);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1730);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1731);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1732);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1733);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1734);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1735);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1736);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1737);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1738);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1739);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1740);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1741);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1742);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1743);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1744);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1745);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1746);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1747);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1748);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1749);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1750);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1751);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1752);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1753);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1754);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1755);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1756);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1757);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1758);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1759);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1760);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1761);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1762);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1763);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1764);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1765);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1766);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1767);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1768);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1769);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1770);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1771);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1772);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1773);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1774);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1775);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1776);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1777);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1778);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1779);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1780);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1781);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1782);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1783);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1784);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1785);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1786);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1787);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1788);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1789);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1790);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1791);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1792);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1793);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1794);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1795);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1796);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1797);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1798);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1799);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1800);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1801);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1802);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1803);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1804);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1805);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1806);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1807);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1808);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1809);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1810);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1811);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1812);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1813);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1814);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1815);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1816);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1817);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1818);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1819);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1820);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1821);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1822);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1823);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1824);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1825);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1826);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1827);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1828);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1829);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1830);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1831);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1832);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1833);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1834);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1835);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "StateProvince",
                keyColumn: "Id",
                keyValue: 1836);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                schema: "Sale",
                table: "Country",
                keyColumn: "Id",
                keyValue: 249);
        }
    }
}
