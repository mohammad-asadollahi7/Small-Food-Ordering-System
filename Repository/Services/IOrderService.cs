﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services;

public interface IOrderService
{
     bool CreateOrUpdate(Food food, int userId);
}
