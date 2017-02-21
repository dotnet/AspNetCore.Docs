ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";