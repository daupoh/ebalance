﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBalance.src_2.models.Entities
{
    interface IWeightEntity:IEntity
    {
        double Weight { get; }
    }
}
