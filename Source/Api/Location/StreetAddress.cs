﻿using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Location
{
    public class StreetAddress
    {
        public IEnumerable<LocalizedText> StreetAddresses { get; set; }
        public string PostalCode { get; set; }
        public IEnumerable<LocalizedText> PostalDistricts { get; set; }
    }
}