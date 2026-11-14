using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodworking_shop.Entities.Enums;

[Flags]
public enum MaterialType
{
    None = 0,
    Wood = 1,    // Дерево
    Metal = 2,   // Металл
    Varnish = 4, // Лак
    Glue = 8     // Клей
}
