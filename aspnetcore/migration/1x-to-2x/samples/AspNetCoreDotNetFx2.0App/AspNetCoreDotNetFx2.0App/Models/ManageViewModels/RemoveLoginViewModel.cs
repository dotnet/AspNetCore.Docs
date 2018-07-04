using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDotNetFx2._0App.Models.ManageViewModels
{
    public class RemoveLoginViewModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
