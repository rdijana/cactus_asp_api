﻿using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetCategoriesQuery:IQuery<CategorySearch,PagedResponse<CategoryDto>>
    {
    }
}
