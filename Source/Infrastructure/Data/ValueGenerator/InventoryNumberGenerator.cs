using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Linq;

namespace IToNeo.Infrastructure.Data.ValueGenerator
{
    class InventoryNumberGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues { get; } 

        public override string Next([NotNull] EntityEntry entry)
        {
            var context = (IToNeoContext)entry.Context;

            var lastEquipment = context.Equipments.Local.LastOrDefault() ?? context.Equipments.OrderBy(e => e.Id).LastOrDefault();

            var year = DateTime.Now.ToString("yy");

            if (lastEquipment != null)
            {
                var lastYear = lastEquipment.InventoryNumber.Split('-')[0];
                if (lastYear == year)
                {
                    var lastIN = int.Parse(lastEquipment.InventoryNumber.Split('-')[1]);
                    if (context.Equipments.Local.Count == 2)
                    {
                        var newN1 = Convert.ToString(lastIN + 2);
                        var netIN1 = $"{year}-{newN1.PadLeft(6, '0')}";
                        return netIN1;
                    }
                    var newN = Convert.ToString(lastIN + 1);
                    var netIN = $"{year}-{newN.PadLeft(6, '0')}";
                    return netIN;
                }
                return $"{year}-000001";
            }
            return $"{year}-000001";
        }
    }
}
