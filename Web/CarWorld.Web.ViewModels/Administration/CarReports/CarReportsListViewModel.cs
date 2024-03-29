﻿using CarWorld.Web.ViewModels.Cars;
using System.Collections.Generic;

namespace CarWorld.Web.ViewModels.Administration.CarReports
{
    public class CarReportsListViewModel : PagingViewModel
    {
        public IEnumerable<CarReportsInListViewModel> Reports { get; set; }

        public string Search { get; set; }

        public string OrderBy { get; set; }
    }
}
