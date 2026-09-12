using System.Text.Json;
using ManufacturingERP.Domain.Entities;
using ManufacturingERP.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingERP.Infrastructure.Data;

public class NepalAdministrativeData
{
    private readonly ApplicationDbContext _context;

    public NepalAdministrativeData(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedProvinceDistrictsAndLocalGovernmentsAsync()
    {
       
        var provinces = new List<Province>
        {
            new Province
            {
                Name = "Koshi",
                NameInNepali = "कोशी"
            },
            new Province
            {
                Name = "Madhesh",
                NameInNepali = "मधेश"
            },
            new Province
            {
                Name = "Bagmati",
                NameInNepali = "बागमती"
            },
            new Province
            {
                Name = "Gandaki",
                NameInNepali = "गण्डकी"
            },
            new Province
            {
                Name = "Lumbini",
                NameInNepali = "लुम्बिनी"
            },
            new Province
            {
                Name = "Karnali",
                NameInNepali = "कर्णाली"
            },
            new Province
            {
                Name = "Sudurpashchim",
                NameInNepali = "सुदूरपश्चिम"
            }
        };

        var existingProvinces = await _context.Provinces
            .ToListAsync();

        var existingProvinceNames = existingProvinces
            .Select(x => x.Name)
            .ToHashSet();

        var newProvinces = provinces
            .Where(x => !existingProvinceNames.Contains(x.Name))
            .ToList();

        if (newProvinces.Count > 0)
        {
            await _context.Provinces.AddRangeAsync(newProvinces);
            await _context.SaveChangesAsync();
        }

        existingProvinces = await _context.Provinces.ToListAsync();


        var districts = new List<(string Name, string NameNp, string Province)>
        {
            // Koshi
            ("Bhojpur", "भोजपुर", "Koshi"),
            ("Dhankuta", "धनकुटा", "Koshi"),
            ("Ilam", "इलाम", "Koshi"),
            ("Jhapa", "झापा", "Koshi"),
            ("Khotang", "खोटाङ", "Koshi"),
            ("Morang", "मोरङ", "Koshi"),
            ("Okhaldhunga", "ओखलढुंगा", "Koshi"),
            ("Panchthar", "पाँचथर", "Koshi"),
            ("Sankhuwasabha", "संखुवासभा", "Koshi"),
            ("Solukhumbu", "सोलुखुम्बु", "Koshi"),
            ("Sunsari", "सुनसरी", "Koshi"),
            ("Taplejung", "ताप्लेजुङ", "Koshi"),
            ("Terhathum", "तेह्रथुम", "Koshi"),
            ("Udayapur", "उदयपुर", "Koshi"),

            // Madhesh
            ("Bara", "बारा", "Madhesh"),
            ("Dhanusha", "धनुषा", "Madhesh"),
            ("Mahottari", "महोत्तरी", "Madhesh"),
            ("Parsa", "पर्सा", "Madhesh"),
            ("Rautahat", "रौतहट", "Madhesh"),
            ("Saptari", "सप्तरी", "Madhesh"),
            ("Sarlahi", "सर्लाही", "Madhesh"),
            ("Siraha", "सिराहा", "Madhesh"),

            // Bagmati
            ("Bhaktapur", "भक्तपुर", "Bagmati"),
            ("Chitwan", "चितवन", "Bagmati"),
            ("Dhading", "धादिङ", "Bagmati"),
            ("Dolakha", "दोलखा", "Bagmati"),
            ("Kathmandu", "काठमाण्डौ", "Bagmati"),
            ("Kavrepalanchok", "काभ्रेपलाञ्चोक", "Bagmati"),
            ("Lalitpur", "ललितपुर", "Bagmati"),
            ("Makwanpur", "मकवानपुर", "Bagmati"),
            ("Nuwakot", "नुवाकोट", "Bagmati"),
            ("Ramechhap", "रामेछाप", "Bagmati"),
            ("Rasuwa", "रसुवा", "Bagmati"),
            ("Sindhuli", "सिन्धुली", "Bagmati"),
            ("Sindhupalchok", "सिन्धुपाल्चोक", "Bagmati"),

            // Gandaki
            ("Baglung", "बागलुङ", "Gandaki"),
            ("Gorkha", "गोरखा", "Gandaki"),
            ("Kaski", "कास्की", "Gandaki"),
            ("Lamjung", "लमजुङ", "Gandaki"),
            ("Manang", "मनाङ", "Gandaki"),
            ("Mustang", "मुस्ताङ", "Gandaki"),
            ("Myagdi", "म्याग्दी", "Gandaki"),
            ("Nawalpur", "नवलपुर", "Gandaki"),
            ("Parbat", "पर्वत", "Gandaki"),
            ("Syangja", "स्याङ्जा", "Gandaki"),
            ("Tanahun", "तनहुँ", "Gandaki"),

            // Lumbini
            ("Arghakhanchi", "अर्घाखाँची", "Lumbini"),
            ("Banke", "बाँके", "Lumbini"),
            ("Bardiya", "बर्दिया", "Lumbini"),
            ("Dang", "दाङ", "Lumbini"),
            ("Eastern Rukum", "पूर्वी रुकुम", "Lumbini"),
            ("Gulmi", "गुल्मी", "Lumbini"),
            ("Kapilvastu", "कपिलवस्तु", "Lumbini"),
            ("Parasi", "परासी", "Lumbini"),
            ("Palpa", "पाल्पा", "Lumbini"),
            ("Pyuthan", "प्युठान", "Lumbini"),
            ("Rolpa", "रोल्पा", "Lumbini"),
            ("Rupandehi", "रुपन्देही", "Lumbini"),

            // Karnali
            ("Dailekh", "दैलेख", "Karnali"),
            ("Dolpa", "डोल्पा", "Karnali"),
            ("Humla", "हुम्ला", "Karnali"),
            ("Jajarkot", "जाजरकोट", "Karnali"),
            ("Jumla", "जुम्ला", "Karnali"),
            ("Kalikot", "कालिकोट", "Karnali"),
            ("Mugu", "मुगु", "Karnali"),
            ("Salyan", "सल्यान", "Karnali"),
            ("Surkhet", "सुर्खेत", "Karnali"),
            ("Western Rukum", "पश्चिम रुकुम", "Karnali"),

            // Sudurpashchim
            ("Achham", "अछाम", "Sudurpashchim"),
            ("Baitadi", "बैतडी", "Sudurpashchim"),
            ("Bajhang", "बझाङ", "Sudurpashchim"),
            ("Bajura", "बाजुरा", "Sudurpashchim"),
            ("Dadeldhura", "डडेलधुरा", "Sudurpashchim"),
            ("Darchula", "दार्चुला", "Sudurpashchim"),
            ("Doti", "डोटी", "Sudurpashchim"),
            ("Kailali", "कैलाली", "Sudurpashchim"),
            ("Kanchanpur", "कञ्चनपुर", "Sudurpashchim")
        };

        var existingDistricts = await _context.Districts
            .ToListAsync();

        var newDistricts = new List<District>();

        foreach (var (name, nameNp, provinceName) in districts)
        {
            var province = existingProvinces
                .FirstOrDefault(x => x.Name == provinceName);

            if (province == null)
                continue;

            var alreadyExists = existingDistricts.Any(x =>
                x.Name == name &&
                x.ProvinceId == province.Id);

            if (alreadyExists)
                continue;

            newDistricts.Add(new District
            {
                ProvinceId = province.Id,
                Name = name,
                NameInNepali = nameNp
            });
        }

        if (newDistricts.Count > 0)
        {
            await _context.Districts.AddRangeAsync(newDistricts);
            await _context.SaveChangesAsync();
        }


        var jsonPath = Path.Combine(
            AppContext.BaseDirectory,
            "Data",
            "local_governments.json"
        );

        if (!File.Exists(jsonPath))
            return;

        var json = await File.ReadAllTextAsync(jsonPath);

        var localGovernments =
            JsonSerializer.Deserialize<List<LocalGovernmentSeedModel>>(json);

        if (localGovernments == null || localGovernments.Count == 0)
            return;

        var allDistricts = await _context.Districts
            .ToListAsync();

        var existingLocalGovernments =
            await _context.LocalGovernments.ToListAsync();

        var newLocalGovernments = new List<LocalGovernment>();

        foreach (var lg in localGovernments)
        {
            if (string.IsNullOrWhiteSpace(lg.name))
                continue;

            var province = existingProvinces
                .FirstOrDefault(x => x.Name == lg.province);

            if (province == null)
                continue;

            var district = allDistricts.FirstOrDefault(x =>
                x.Name == lg.district &&
                x.ProvinceId == province.Id);

            if (district == null)
                continue;

            var alreadyExists = existingLocalGovernments.Any(x =>
                x.Name == lg.name &&
                x.DistrictId == district.Id);

            if (alreadyExists)
                continue;

            var type = Enum.TryParse<LocalGovernmentType>(
                lg.type,
                true,
                out var parsedType)
                ? parsedType
                : LocalGovernmentType.Municipality;

            newLocalGovernments.Add(new LocalGovernment
            {
                ProvinceId = province.Id,
                DistrictId = district.Id,
                Type = type,
                WardCount = lg.wardCount,
                Name = lg.name,
                NameInNepali = lg.nameNp ?? string.Empty
            });
        }

        if (newLocalGovernments.Count > 0)
        {
            await _context.LocalGovernments
                .AddRangeAsync(newLocalGovernments);

            await _context.SaveChangesAsync();
        }
    }
}