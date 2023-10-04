using CsvHelper;
using CsvHelper.Configuration;
using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IToNeo.Infrastructure.Data
{
    public static class IToNeoContextSeed
    {
        private static string[] equipmentStatuses;
        private static List<EquipmentType> equipmentTypes;
        private static string[] organizations;
        private static string[] places;
        public static string[] employees;
        private static string[] equipments;
        private static string[] licenseTypes;
        private static string[] softwareLicenses;
        private static string[] softwareDevelopers;
        private static string[] softwares;
        private static readonly IReaderConfiguration csvReaderConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture){ Delimiter = ";", Encoding = Encoding.UTF8 };

        public static void Seed(IToNeoContext itoNeoContext, ILoggerFactory loggerFactory, bool isExtended = false)
        {
            try
            {
                if (!itoNeoContext.EquipmentStatuses.Any())
                {
                    itoNeoContext.EquipmentStatuses
                        .AddRange(GetPreconfiguredEquipmentStatuses());

                    itoNeoContext.SaveChanges();

                    equipmentStatuses = itoNeoContext.EquipmentStatuses.Select(es => es.Id).ToArray();
                }


                if (!itoNeoContext.EquipmentTypes.Any())
                {
                    itoNeoContext.EquipmentTypes
                        .AddRange(GetPreconfiguredEquipmentTypes());

                    itoNeoContext.SaveChanges();

                    equipmentTypes = itoNeoContext.EquipmentTypes.ToList();
                }


                if (!itoNeoContext.Organizations.Any())
                {
                    itoNeoContext.Organizations
                            .AddRange(GetPreconfiguredOrganizations());

                    itoNeoContext.SaveChanges();

                    organizations = itoNeoContext.Organizations.Select(o => o.Id).ToArray();
                }

                if (!itoNeoContext.Places.Any())
                {
                    itoNeoContext.Places.AddRange(GetPreconfiguredPlaces());

                    itoNeoContext.SaveChanges();

                    places = itoNeoContext.Places.Select(p => p.Id).ToArray();
                }


                if (!itoNeoContext.Employees.Any())
                {
                    itoNeoContext.Employees
                        .AddRange(GetPreconfiguredEmployees());

                    itoNeoContext.SaveChanges();

                    employees = itoNeoContext.Employees.Select(e => e.Id).ToArray();
                }

                if (!itoNeoContext.Equipments.Any())
                {
                    itoNeoContext.Equipments
                        .AddRange(GetPreconfiguredEquipments());

                    itoNeoContext.SaveChanges();

                    equipments = itoNeoContext.Equipments.Select(e => e.Id).ToArray();
                }


                if (!itoNeoContext.WriteOffs.Any())
                {
                    itoNeoContext.WriteOffs
                        .AddRange(GetPreconfiguredWriteOffs());
                }

                if (!itoNeoContext.Disposals.Any())
                {
                    itoNeoContext.Disposals
                        .AddRange(GetPreconfiguredDisposals());
                }


                if (!itoNeoContext.SoftwareLicenseTypes.Any())
                {
                    itoNeoContext.SoftwareLicenseTypes
                        .AddRange(GetPreconfiguredSoftwareLicenseTypes());

                    itoNeoContext.SaveChanges();

                    licenseTypes = itoNeoContext.SoftwareLicenseTypes.Select(lt => lt.Id).ToArray();
                }

                if (!itoNeoContext.SoftwareDevelopers.Any())
                {
                    itoNeoContext.SoftwareDevelopers
                        .AddRange(GetPreconfiguredSoftwareDevelopers());

                    itoNeoContext.SaveChanges();

                    softwareDevelopers = itoNeoContext.SoftwareDevelopers.Select(sd => sd.Id).ToArray();
                }

                if (!itoNeoContext.Softwares.Any())
                {
                    itoNeoContext.Softwares
                        .AddRange(GetPreconfiguredSoftwares());

                    itoNeoContext.SaveChanges();

                    softwares = itoNeoContext.Softwares.Select(s => s.Id).ToArray();
                }


                if (!itoNeoContext.SoftwareLicenses.Any())
                {
                    itoNeoContext.SoftwareLicenses
                        .AddRange(GetPreconfiguredSoftwareLicenses());

                    itoNeoContext.SaveChanges();

                    softwareLicenses = itoNeoContext.SoftwareLicenses.Select(sl => sl.Id).ToArray();
                }

                if (!itoNeoContext.Files.Any())
                {
                    itoNeoContext.Files
                        .AddRange(GetPreconfiguredFiles());
                }

                if (!itoNeoContext.EquipmentsSoftwareLicences.Any())
                {
                    itoNeoContext.EquipmentsSoftwareLicences
                        .AddRange(GetPreconfiguredEquipmentSoftwareLicences());
                }

                itoNeoContext.SaveChanges();

            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<IToNeoContext>();
                log.LogError(ex.Message);
            }
        }

        public static async Task SeedAsync(IToNeoContext itoNeoContext, ILoggerFactory loggerFactory, bool isExtended = false)   
        {
            try
            {
                if (!await itoNeoContext.EquipmentStatuses.AnyAsync())
                {
                    await itoNeoContext.EquipmentStatuses
                        .AddRangeAsync(GetPreconfiguredEquipmentStatuses());

                    await itoNeoContext.SaveChangesAsync();

                    equipmentStatuses = await itoNeoContext.EquipmentStatuses.Select(es => es.Id).ToArrayAsync();
                }


                if (!await itoNeoContext.EquipmentTypes.AnyAsync())
                {
                    await itoNeoContext.EquipmentTypes
                        .AddRangeAsync(GetPreconfiguredEquipmentTypes());

                    await itoNeoContext.SaveChangesAsync();

                    equipmentTypes = await itoNeoContext.EquipmentTypes.ToListAsync();
                }


                if (!await itoNeoContext.Organizations.AnyAsync())
                {
                    await itoNeoContext.Organizations
                            .AddRangeAsync(GetPreconfiguredOrganizations());

                    await itoNeoContext.SaveChangesAsync();

                    organizations = await itoNeoContext.Organizations.Select(o => o.Id).ToArrayAsync();
                }

                if (!await itoNeoContext.Places.AnyAsync())
                {
                    await itoNeoContext.Places.AddRangeAsync(GetPreconfiguredPlaces());

                    await itoNeoContext.SaveChangesAsync();

                    places = await itoNeoContext.Places.Select(p => p.Id).ToArrayAsync();
                }


                if (!await itoNeoContext.Employees.AnyAsync())
                {
                    if (isExtended)
                    {
                        await itoNeoContext.Employees.AddRangeAsync(GetExtendedPreconfiguredEmployees());
                    }
                    else
                    {
                        await itoNeoContext.Employees.AddRangeAsync(GetPreconfiguredEmployees());
                    }

                    await itoNeoContext.SaveChangesAsync();

                    employees = await itoNeoContext.Employees.Select(e => e.Id).ToArrayAsync();
                }

                if (!await itoNeoContext.Equipments.AnyAsync())
                {
                    if (isExtended)
                    {
                        await itoNeoContext.Equipments.AddRangeAsync(GetExtendedPreconfiguredEquipments());
                    }
                    else
                    {
                        await itoNeoContext.Equipments.AddRangeAsync(GetPreconfiguredEquipments());
                    }

                    await itoNeoContext.SaveChangesAsync();

                    equipments = await itoNeoContext.Equipments.Select(e => e.Id).ToArrayAsync();
                }


                if (!await itoNeoContext.WriteOffs.AnyAsync())
                {
                    await itoNeoContext.WriteOffs
                        .AddRangeAsync(GetPreconfiguredWriteOffs());
                }

                if (!await itoNeoContext.Disposals.AnyAsync())
                {
                    await itoNeoContext.Disposals
                        .AddRangeAsync(GetPreconfiguredDisposals());
                }


                if (!await itoNeoContext.SoftwareLicenseTypes.AnyAsync())
                {
                    await itoNeoContext.SoftwareLicenseTypes
                        .AddRangeAsync(GetPreconfiguredSoftwareLicenseTypes());

                    await itoNeoContext.SaveChangesAsync();

                    licenseTypes = await itoNeoContext.SoftwareLicenseTypes.Select(lt => lt.Id).ToArrayAsync();
                }

                if (!await itoNeoContext.SoftwareDevelopers.AnyAsync())
                {
                    await itoNeoContext.SoftwareDevelopers
                        .AddRangeAsync(GetPreconfiguredSoftwareDevelopers());

                    await itoNeoContext.SaveChangesAsync();

                    softwareDevelopers = await itoNeoContext.SoftwareDevelopers.Select(sd => sd.Id).ToArrayAsync();
                }

                if (!await itoNeoContext.Softwares.AnyAsync())
                {
                    await itoNeoContext.Softwares
                        .AddRangeAsync(GetPreconfiguredSoftwares());

                    await itoNeoContext.SaveChangesAsync();

                    softwares = await itoNeoContext.Softwares.Select(s => s.Id).ToArrayAsync();
                }


                if (!await itoNeoContext.SoftwareLicenses.AnyAsync())
                {
                    await itoNeoContext.SoftwareLicenses
                        .AddRangeAsync(GetPreconfiguredSoftwareLicenses());

                    await itoNeoContext.SaveChangesAsync();

                    softwareLicenses = await itoNeoContext.SoftwareLicenses.Select(sl => sl.Id).ToArrayAsync();
                }

                if (!await itoNeoContext.Files.AnyAsync())
                {
                    await itoNeoContext.Files
                        .AddRangeAsync(GetPreconfiguredFiles());
                }

                if (!await itoNeoContext.EquipmentsSoftwareLicences.AnyAsync())
                {
                    await itoNeoContext.EquipmentsSoftwareLicences
                        .AddRangeAsync(GetPreconfiguredEquipmentSoftwareLicences());
                }

                await itoNeoContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<IToNeoContext>();
                log.LogError(ex.Message);
            }
        }

        public static IEnumerable<EquipmentStatus> GetPreconfiguredEquipmentStatuses()
        {
            return new List<EquipmentStatus>()
            {
                new EquipmentStatus("Используется"),
                new EquipmentStatus("На складе"),
                new EquipmentStatus("В ремонте"),
                new EquipmentStatus("Списано"),
            };
        }

        public static IEnumerable<EquipmentType> GetPreconfiguredEquipmentTypes()
        {
            return new List<EquipmentType>()
            {
                new EquipmentType("IP телефон"),
                new EquipmentType("ИБП"),
                new EquipmentType("Монитор"),
                new EquipmentType("Компьютер"),
                new EquipmentType("Ноутбук")
            };
        }

        public static IEnumerable<Organization> GetPreconfiguredOrganizations()
        {
            return new List<Organization>()
            {
                new Organization("ООО Рустех"),
                new Organization("ОАО ГосКом"),
                new Organization("ООО ГорГос")
            };
        }

        public static IEnumerable<Place> GetPreconfiguredPlaces() {
            return new List<Place>()
            {
                new Place("Саратов ЗУ", "ул. Ленина 12"),
                new Place("Самара ГО", "ул. Садовая 180"),
                new Place("Москва ЗУ", "ул. Судакова 256")
            };
        }

        public static IEnumerable<Employee> GetPreconfiguredEmployees()
        {
            return new List<Employee>()
            {
                new Employee("Иван", "Иванов", "Иванович", "i.ivanov", organizations[0],
                    "Информационные технологии", "Специалист"),
                new Employee("Иван", "Сидоров", "Иванович", "i.sidorov", organizations[1],
                    "Юридическая служба", "Специалист"),
                new Employee("Иван", "Петров", "Иванович", "i.petrov", organizations[2],
                    "Планово-экономический отдел", "Специалист")
            };
        }

        public static IEnumerable<Employee> GetExtendedPreconfiguredEmployees()
        {
            var employees = new List<Employee>();
            var record = new
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                PatronymicName = string.Empty,
                Department = string.Empty,
                Position = string.Empty
            };

            using (var reader = new StreamReader("employees.csv"))
            using (var csv = new CsvReader(reader, csvReaderConfiguration))
            {
                var records = csv.GetRecords(record);
                foreach (var r in records)
                {
                    employees.Add(new Employee(
                        r.FirstName,
                        r.LastName,
                        r.PatronymicName,
                        null,
                        organizations[new Random().Next(organizations.Length)],
                        r.Department,
                        r.Position
                        ));
                }
            }
            return employees;
        }

        public static IEnumerable<Equipment> GetPreconfiguredEquipments()
        {
            return new List<Equipment>()
            {
                new Equipment("HP ProDesk 400 G7", equipmentTypes.Find(t => t.Name == "Ноутбук").Id, organizations[0], equipmentStatuses[0],
                    places[0], employees[0], "20-0001-01", "AAA11","Тест"),
                new Equipment("HP EliteDisplay E24", equipmentTypes.Find(t => t.Name == "Монитор").Id, organizations[0], equipmentStatuses[0],
                    places[0],  employees[0], "20-0001-02", "AAA12","Тест"),
                new Equipment("APC Back-UPS 500 ВА", equipmentTypes.Find(t => t.Name == "ИБП").Id, organizations[0], equipmentStatuses[0],
                    places[0], employees[0], "20-0001-03", "AAA13","Тест"),
                new Equipment("Fanvil X3S", equipmentTypes.Find(t => t.Name == "IP телефон").Id, organizations[0], equipmentStatuses[0],
                    places[0], employees[0], "20-0001-04", "AAA14","Тест"),       
                new Equipment("HP ProDesk 400 G7", equipmentTypes.Find(t => t.Name == "Ноутбук").Id, organizations[1], equipmentStatuses[0],
                    places[1], employees[1], "20-0002-01", "AAA21","Тест"),
                new Equipment("HP EliteDisplay E24", equipmentTypes.Find(t => t.Name == "Монитор").Id, organizations[1], equipmentStatuses[0],
                    places[1], employees[1], "20-0002-02", "AAA22","Тест"),
                new Equipment("APC Back-UPS 500 ВА", equipmentTypes.Find(t => t.Name == "ИБП").Id, organizations[1], equipmentStatuses[0],
                    places[1], employees[1], "20-0002-03", "AAA24","Тест"),
                new Equipment("Fanvil X3S", equipmentTypes.Find(t => t.Name == "IP телефон").Id, organizations[1], equipmentStatuses[0],
                    places[1], employees[1], "20-0002-04", "AAA24","Тест"),
                new Equipment("HP ProDesk 400 G7", equipmentTypes.Find(t => t.Name == "Компьютер").Id, organizations[2], equipmentStatuses[0],
                    places[2], employees[2], "20-0003-01", "AAA31","Тест"),
                new Equipment("HP EliteDisplay E24", equipmentTypes.Find(t => t.Name == "Монитор").Id, organizations[2], equipmentStatuses[0],
                    places[2], employees[2], "20-0003-02", "AAA32","Тест"),
                new Equipment("APC Back-UPS 500 ВА", equipmentTypes.Find(t => t.Name == "ИБП").Id, organizations[2], equipmentStatuses[0],
                    places[2], employees[2], "20-0003-03", "AAA34","Тест"),
                new Equipment("Fanvil X3S", equipmentTypes.Find(t => t.Name == "IP телефон").Id, organizations[2], equipmentStatuses[0],
                    places[2], employees[2], "20-0003-04", "AAA34","Тест"),
                new Equipment("HP ProBook 440 G7", equipmentTypes.Find(t => t.Name == "Ноутбук").Id, organizations[0], equipmentStatuses[1],
                    places[2], employees[2], "20-0004-01", "AAA41","Тест"),
                new Equipment("HP ProBook 440 G7", equipmentTypes.Find(t => t.Name == "Ноутбук").Id, organizations[1], equipmentStatuses[2],
                    places[2], employees[2], "20-0004-02", "AAA42","Тест"),
                new Equipment("HP ProBook 440 G7", equipmentTypes.Find(t => t.Name == "Ноутбук").Id, organizations[2], equipmentStatuses[3],
                    places[2], employees[2], "20-0004-03", "AAA43","Тест"),
            };
        }

        public static IEnumerable<Equipment> GetExtendedPreconfiguredEquipments()
        {
            var equipments = new List<Equipment>();

            equipments.AddRange(GetExtendedPreconfiguredEquipmentsFromCsv("ip_phones.csv", equipmentTypes.Find(t => t.Name == "IP телефон").Id));
            equipments.AddRange(GetExtendedPreconfiguredEquipmentsFromCsv("displays.csv", equipmentTypes.Find(t => t.Name == "Монитор").Id));
            equipments.AddRange(GetExtendedPreconfiguredEquipmentsFromCsv("laptops.csv", equipmentTypes.Find(t => t.Name == "Ноутбук").Id));
            equipments.AddRange(GetExtendedPreconfiguredEquipmentsFromCsv("pcs.csv", equipmentTypes.Find(t => t.Name == "Компьютер").Id));
            equipments.AddRange(GetExtendedPreconfiguredEquipmentsFromCsv("upss.csv", equipmentTypes.Find(t => t.Name == "ИБП").Id));

            return equipments;
        }

        public static IEnumerable<Equipment> GetExtendedPreconfiguredEquipmentsFromCsv(string path, string equipmentTypeId)
        {
            var equipment = new List<Equipment>();
            var record = new
            {
                Name = string.Empty,
                SerialNumber = string.Empty
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, csvReaderConfiguration))
            {
                var records = csv.GetRecords(record);
                foreach (var r in records)
                {
                    if (r.Name.Length >= 200) System.Console.WriteLine(r.Name);
                    equipment.Add(new Equipment(
                        r.Name,
                        equipmentTypeId,
                        organizations[new Random().Next(organizations.Length)],
                        equipmentStatuses[new Random().Next(equipmentStatuses.Length)],
                        places[new Random().Next(places.Length)],
                        employees[new Random().Next(employees.Length)],
                        null,
                        r.SerialNumber,
                        null));
                }          
            }

            return equipment;
        }

        public static IEnumerable<EquipmentWriteOff> GetPreconfiguredWriteOffs()
        {
            return new List<EquipmentWriteOff>()
            {
                new EquipmentWriteOff("1/1", DateTime.Now.Date, (float)0.01, "test1", equipments[0]),
                new EquipmentWriteOff("1/2", DateTime.Now.Date, (float)0.02, "test2", equipments[1]),
            };
        }

        public static IEnumerable<EquipmentDisposal> GetPreconfiguredDisposals()
        {
            return new List<EquipmentDisposal>()
            {
                new EquipmentDisposal("2/1", DateTime.Now.Date, (float)0.01, "test1", equipments[2]),
                new EquipmentDisposal("2/2", DateTime.Now.Date, (float)0.02, "test2", equipments[3]),
            };
        }

        public static IEnumerable<SoftwareLicenseType> GetPreconfiguredSoftwareLicenseTypes()
        {
            return new List<SoftwareLicenseType>()
            {
                new SoftwareLicenseType("oem"),
                new SoftwareLicenseType("box")
            };
        }

        public static IEnumerable<SoftwareDeveloper> GetPreconfiguredSoftwareDevelopers()
        {
            return new List<SoftwareDeveloper>()
            {
                new SoftwareDeveloper("Microsoft"),
                new SoftwareDeveloper("1c")
            };
        }

        public static IEnumerable<Software> GetPreconfiguredSoftwares()
        {
            return new List<Software>()
            {
                new Software("Office Professional 2016", "тест комментария", softwareDevelopers[1]),
                new Software("Office Professional 2019", "тест комментария", softwareDevelopers[1]),
                new Software("Windows 10 Pro", "тест комментария", softwareDevelopers[1]),
                new Software("предприятие 8.3", "тест комментария", softwareDevelopers[0]),
                new Software("предприятие 7.7", "тест комментария", softwareDevelopers[0])
            };
        }

        public static IEnumerable<SoftwareLicense> GetPreconfiguredSoftwareLicenses()
        {
            return new List<SoftwareLicense>()
            {
                new SoftwareLicense(licenseTypes[0], 2, "XXX-XXX-XX1", 
                    softwares[4], "тест комментария", organizations[0]),
                new SoftwareLicense(licenseTypes[1], 2, "XXX-XXX-XX2",
                    softwares[4], "тест комментария", organizations[0]),
                new SoftwareLicense(licenseTypes[1], 2, "XXX-XXX-XX3",
                    softwares[3], "тест комментария", organizations[1]),
                new SoftwareLicense(licenseTypes[0], 2, "XXX-XXX-XX4",
                    softwares[2], "тест комментария", organizations[2]),
                new SoftwareLicense(licenseTypes[0], 1, "XXX-XXX-XX5",
                    softwares[1], "тест комментария", organizations[1]),
                new SoftwareLicense(licenseTypes[0], 1, "XXX-XXX-XX6",
                    softwares[0], "тест комментария", organizations[0])
            };
        }

        public static IEnumerable<FileEntity> GetPreconfiguredFiles()
        {
            var content = Encoding.ASCII.GetBytes("test text");

            return new List<FileEntity>()
            {
                new FileEntity("test.txt", content, equipments[0], null, null),
                new FileEntity("test.txt", content, null, employees[0], null),
                new FileEntity("test.txt", content, null, null, softwareLicenses[0])
            };
        }

        public static IEnumerable<EquipmentSoftwareLicense> GetPreconfiguredEquipmentSoftwareLicences()
        {
            return new List<EquipmentSoftwareLicense>()
            {
                new EquipmentSoftwareLicense(equipments[1], softwareLicenses[0]),
                new EquipmentSoftwareLicense(equipments[1], softwareLicenses[2]),
                new EquipmentSoftwareLicense(equipments[1], softwareLicenses[3]),
                new EquipmentSoftwareLicense(equipments[5], softwareLicenses[5]),
                new EquipmentSoftwareLicense(equipments[5], softwareLicenses[2]),
                new EquipmentSoftwareLicense(equipments[5], softwareLicenses[3]),
                new EquipmentSoftwareLicense(equipments[8], softwareLicenses[1]),
                new EquipmentSoftwareLicense(equipments[8], softwareLicenses[4])
            };
        }
    }
}
